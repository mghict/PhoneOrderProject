using AutoMapper;
using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AccessManagment.Application.ApplicationInfo.Commands;
using AccessManagment.Domain.Entities;

namespace AccessManagment.Application.ApplicationInfo.CommandsHandler
{
    public class UpdateApplicationInfoCommandHandler:
        MediatR.IRequestHandler
        <Commands.UpdateApplicationInfoCommand, FluentResults.Result<Domain.Entities.ApplicationInfoTbl>>
    {
        protected AutoMapper.IMapper Mapper { get; }
        protected Persistence.IUnitOfWork UnitOfWork { get; }
        public UpdateApplicationInfoCommandHandler(IMapper mapper, Persistence.IUnitOfWork unitOfWork)
        {
            Mapper = mapper;
            UnitOfWork = unitOfWork;
        }

        public async Task<Result<Domain.Entities.ApplicationInfoTbl>> Handle(UpdateApplicationInfoCommand request, CancellationToken cancellationToken)
        {
            Result<Domain.Entities.ApplicationInfoTbl> result = 
                new Result<Domain.Entities.ApplicationInfoTbl>();

            try
            {
                result =
                    await BehsamFramework.Util.Utility.Validate<Commands.UpdateApplicationInfoCommand,Domain.Entities.ApplicationInfoTbl>
                        (validator: new Validators.UpdateApplicationInfoValidator(), command: request);

                if (result.IsFailed)
                {
                    return result;
                }

                // **************************************************
                var entity = Mapper.Map<Domain.Entities.ApplicationInfoTbl>(request);

                var isTrue = await UnitOfWork.ApplicationInfoRepository.UpdateAsync(entity);

                if (!isTrue)
                {
                    throw new Exception(BehsamFramework.Resources.Messages.ErrorDone);
                }

                result.WithValue(entity);
                result.WithSuccess(BehsamFramework.Resources.Messages.SuccessDone);

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
