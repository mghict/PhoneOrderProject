using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using CustomerManagment.Application.CustomerPhoneFeature.Commands;
using CustomerManagment.Persistence;
using FluentResults;

namespace CustomerManagment.Application.CustomerPhoneFeature.CommandsHandler
{
    public class UpdateCustomerPhoneCommandHandler :
        Object,
        MediatR.IRequestHandler
        <Commands.UpdateCustomerPhoneCommand, FluentResults.Result>
    {
        protected AutoMapper.IMapper Mapper { get; }
        protected Persistence.IUnitOfWork UnitOfWork { get; }
        protected Persistence.IQueryUnitOfWork QueryUnitOfWork { get; }

        public UpdateCustomerPhoneCommandHandler(IMapper mapper, IUnitOfWork unitOfWork, IQueryUnitOfWork queryUnitOfWork)
        {
            Mapper = mapper;
            UnitOfWork = unitOfWork;
            QueryUnitOfWork = queryUnitOfWork;
        }
        public async Task<Result> Handle(UpdateCustomerPhoneCommand request, CancellationToken cancellationToken)
        {
            FluentResults.Result result = new FluentResults.Result();

            try
            {
                result =
                    await BehsamFramework.Util.Utility.Validate<Commands.UpdateCustomerPhoneCommand,long>
                        (validator: new Validators.UpdateCustomerPhoneValidator(), command: request);

                if (result.IsFailed)
                {
                    return result;
                }

                // **************************************************
                var entity = Mapper.Map<Domain.Entities.CustomerPhoneTbl>(request);
                try
                {

                    var existPhone = await QueryUnitOfWork.CustomerPhoneRepository.GetByPhoneAsync(request.PhoneValue);

                    if (existPhone != null)
                    {
                        if (existPhone.Id != request.Id)
                        {
                            result.WithError("تلفن برای مشتری دیگری ثبت شده است");
                            return result;
                        }
                    }
                }
                catch (Exception ex)
                {
                    
                }
                var operation = await UnitOfWork.CustomerPhoneRepository.UpdateAsync(entity);

                if (operation)
                    result.WithSuccess
                        (successMessage: BehsamFramework.Resources.Messages.SuccessInsert);
                else
                {
                    result.WithSuccess
                        (successMessage: BehsamFramework.Resources.Messages.ErrorDone);
                }
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