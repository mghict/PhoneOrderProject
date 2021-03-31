using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using CustomerManagment.Application.CustomerPhoneFeature.Commands;
using CustomerManagment.Persistence;
using FluentResults;

namespace CustomerManagment.Application.CustomerPhoneFeature.CommandsHandler
{
    public class GetByIdCustomerPhoneCommandHandler :
        Object,
        MediatR.IRequestHandler
        <Commands.GetByIdCustomerPhoneCommand, FluentResults.Result<BehsamFramework.Models.CustomerPhoneModel>>
    {
        protected AutoMapper.IMapper Mapper { get; }
        protected Persistence.IQueryUnitOfWork UnitOfWork { get; }

        public GetByIdCustomerPhoneCommandHandler(IMapper mapper, IQueryUnitOfWork unitOfWork)
        {
            Mapper = mapper;
            UnitOfWork = unitOfWork;
        }
        public async Task<Result<BehsamFramework.Models.CustomerPhoneModel>> Handle(GetByIdCustomerPhoneCommand request, CancellationToken cancellationToken)
        {
            FluentResults.Result<BehsamFramework.Models.CustomerPhoneModel> result = 
                new FluentResults.Result<BehsamFramework.Models.CustomerPhoneModel>();

            try
            {
                result =
                    await BehsamFramework.Util.Utility.Validate<Commands.GetByIdCustomerPhoneCommand, BehsamFramework.Models.CustomerPhoneModel>
                        (validator: new Validators.GetByIdCustomerPhoneValidator(), command: request);

                if (result.IsFailed)
                {
                    return result;
                }

                // **************************************************

                var operation = await UnitOfWork.CustomerPhoneRepository.GetByIdAsync(request.Id);

                if (operation != null)
                {
                    result.WithSuccess
                        (successMessage: BehsamFramework.Resources.Messages.SuccessInsert);

                    result.WithValue(Mapper.Map<BehsamFramework.Models.CustomerPhoneModel>(operation));
                    
                }
                else
                {
                    result.WithSuccess
                        (successMessage: BehsamFramework.Resources.Messages.ErrorDone);
                }
                // **************************************************

                // **************************************************
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