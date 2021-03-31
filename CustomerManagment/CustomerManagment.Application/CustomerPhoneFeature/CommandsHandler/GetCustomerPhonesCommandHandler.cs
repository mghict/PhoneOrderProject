using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using CustomerManagment.Application.CustomerPhoneFeature.Commands;
using CustomerManagment.Persistence;
using FluentResults;
using System.Linq;

namespace CustomerManagment.Application.CustomerPhoneFeature.CommandsHandler
{
    public class GetCustomerPhonesCommandHandler :
        Object,
        MediatR.IRequestHandler
        <Commands.GetCustomerPhonesCommand, FluentResults.Result<List<BehsamFramework.Models.CustomerPhoneModel>>>
    {
        protected AutoMapper.IMapper Mapper { get; }
        protected Persistence.IQueryUnitOfWork UnitOfWork { get; }

        public GetCustomerPhonesCommandHandler(IMapper mapper, IQueryUnitOfWork unitOfWork)
        {
            Mapper = mapper;
            UnitOfWork = unitOfWork;
        }
        public async Task<Result<List<BehsamFramework.Models.CustomerPhoneModel>>> Handle(GetCustomerPhonesCommand request, CancellationToken cancellationToken)
        {
            FluentResults.Result<List<BehsamFramework.Models.CustomerPhoneModel>> result = 
                new FluentResults.Result<List<BehsamFramework.Models.CustomerPhoneModel>>();

            try
            {
                result =
                    await BehsamFramework.Util.Utility.Validate<Commands.GetCustomerPhonesCommand,List<BehsamFramework.Models.CustomerPhoneModel>>
                        (validator: new Validators.GetCustomerPhonesValidator(), command: request);

                if (result.IsFailed)
                {
                    return result;
                }

                // **************************************************

                var operation = await UnitOfWork.CustomerPhoneRepository.GetCustomerPhonesAsync(request.Id);
                var retVal = Mapper.Map<
                        ICollection<Domain.Entities.CustomerPhoneTbl>,
                        ICollection<BehsamFramework.Models.CustomerPhoneModel>>(operation);

                if (operation != null)
                {
                    result.WithSuccess
                        (successMessage: BehsamFramework.Resources.Messages.SuccessInsert);

                    result.WithValue(retVal.ToList());
                    
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