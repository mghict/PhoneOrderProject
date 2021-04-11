
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using BehsamFramework.DTOs.OutPutDTOs.TokenDTO;
using crypto;
using FluentResults;

namespace AccessManagment.Application.ApplicationInfo.CommandsHandler
{
    public class UpdateApplicationInfoCommandHandler :
        MediatR.IRequestHandler
        <Commands.UpdateApplicationInfoCommand, FluentResults.Result>
    {
        protected AutoMapper.IMapper Mapper { get; }
        protected Persistence.IUnitOfWork UnitOfWork { get; }
        public UpdateApplicationInfoCommandHandler(IMapper mapper, Persistence.UnitOfWork unitOfWork)
        {
            Mapper = mapper;
            UnitOfWork = unitOfWork;
        }

        public async Task<Result> Handle(Commands.UpdateApplicationInfoCommand request, CancellationToken cancellationToken)
        {
            FluentResults.Result result = new FluentResults.Result();

            try
            {
                result =
                    await BehsamFramework.Util.Utility.Validate<Commands.UpdateApplicationInfoCommand>
                        (validator: new Validators.UpdateApplicationInfoValidator(), command: request);

                if (result.IsFailed)
                {
                    return result;
                }

                // **************************************************
                var entity=Mapper.Map<Domain.Entities.ApplicationInfoTbl>(request);

                var isTrue = await UnitOfWork.ApplicationInfoRepository.UpdateAsync(entity);
                
                if (!isTrue )
                {
                    throw new Exception(BehsamFramework.Resources.Messages.ErrorDone);
                }

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
