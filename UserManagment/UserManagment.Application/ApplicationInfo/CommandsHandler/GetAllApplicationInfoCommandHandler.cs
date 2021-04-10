using AutoMapper;
using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using UserManagment.Application.ApplicationInfo.Commands;
using UserManagment.Domain.Entities;

namespace UserManagment.Application.ApplicationInfo.CommandsHandler
{
    public class GetAllApplicationInfoCommandHandler:
        object,
        MediatR.IRequestHandler
        <Commands.GetAllApplicationInfoCommand, FluentResults.Result<List<Domain.Entities.ApplicationInfoTbl>>>
    {
        protected AutoMapper.IMapper Mapper { get; }
        protected Persistence.IQueryUnitOfWork UnitOfWork { get; }
        public GetAllApplicationInfoCommandHandler(IMapper mapper, Persistence.IQueryUnitOfWork unitOfWork)
        {
            Mapper = mapper;
            UnitOfWork = unitOfWork;
        }

        public async Task<Result<List<Domain.Entities.ApplicationInfoTbl>>> Handle(GetAllApplicationInfoCommand request, CancellationToken cancellationToken)
        {
            Result<List<Domain.Entities.ApplicationInfoTbl>> result = 
                new Result<List<Domain.Entities.ApplicationInfoTbl>>();

            try
            {



                var applications = (await UnitOfWork.ApplicationInfoQueryRepository.GetAllAsync()).ToList();
                if (applications == null || applications.Count<=0)
                {
                    throw new Exception(BehsamFramework.Resources.Messages.DataNotFound);
                }

                result.WithValue(applications);
                // **************************************************

                // **************************************************


                result.WithSuccess
                    (successMessage: BehsamFramework.Resources.Messages.SuccessInsert);
            }
            catch (Exception e)
            {
                result.WithError(e.Message);
            }
            finally
            {

            }
            return result;
        }
    }
}
