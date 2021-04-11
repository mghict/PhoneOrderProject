using AccessManagment.Application.PageInfo.Commands;
using AccessManagment.Persistence;
using AutoMapper;
using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace AccessManagment.Application.PageInfo.CommandsHandler
{
    public class GetAllInfoCommandHandler :
        Object,
        MediatR.IRequestHandler
        <Commands.GetAllPageInfoCommand, FluentResults.Result<List<Domain.Entities.PageInfoTbl>>>
    {
        protected AutoMapper.IMapper Mapper { get; }
        protected Persistence.IQueryUnitOfWork UnitOfWork { get; }

        public GetAllInfoCommandHandler(IMapper mapper, IQueryUnitOfWork unitOfWork)
        {
            Mapper = mapper;
            UnitOfWork = unitOfWork;
        }

        public async Task<Result<List<Domain.Entities.PageInfoTbl>>> Handle(GetAllPageInfoCommand request, CancellationToken cancellationToken)
        {
            Result<List<Domain.Entities.PageInfoTbl>> result = new Result<List<Domain.Entities.PageInfoTbl>>();

            try
            {
                

                // **************************************************

                var entity = await UnitOfWork.PageInfoQueryRepository.GetAllAsync();

                if (entity == null)
                {
                    throw new Exception(BehsamFramework.Resources.Messages.ErrorDone);
                }

                result.WithValue(entity.ToList());
                result.WithSuccess(BehsamFramework.Resources.Messages.SuccessDone);
            }
            catch (Exception ex)
            {
                result.WithError(ex.Message);
            }

            return result;
        }
    }
}
