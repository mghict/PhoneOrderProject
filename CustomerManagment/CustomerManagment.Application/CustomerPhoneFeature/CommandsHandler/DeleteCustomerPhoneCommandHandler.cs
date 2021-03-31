using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using CustomerManagment.Application.CustomerPhoneFeature.Commands;
using CustomerManagment.Persistence;
using FluentResults;

namespace CustomerManagment.Application.CustomerPhoneFeature.CommandsHandler
{
    public class DeleteCustomerPhoneCommandHandler :
        Object,
        MediatR.IRequestHandler
        <Commands.DeleteCustomerPhoneCommand, FluentResults.Result>
    {
        protected AutoMapper.IMapper Mapper { get; }
        protected Persistence.IUnitOfWork UnitOfWork { get; }

        public DeleteCustomerPhoneCommandHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {
            Mapper = mapper;
            UnitOfWork = unitOfWork;
        }
        public async Task<Result> Handle(DeleteCustomerPhoneCommand request, CancellationToken cancellationToken)
        {
            FluentResults.Result result = new FluentResults.Result();

            try
            {
                result =
                    await BehsamFramework.Util.Utility.Validate<Commands.DeleteCustomerPhoneCommand, long>
                        (validator: new Validators.DeleteCustomerPhoneValidator(), command: request);

                if (result.IsFailed)
                {
                    return result;
                }

                // **************************************************

                var operation = await UnitOfWork.CustomerPhoneRepository.DeleteByIdAsync(request.Id);

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