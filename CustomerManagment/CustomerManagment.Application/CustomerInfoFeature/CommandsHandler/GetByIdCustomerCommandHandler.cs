using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using BehsamFramework.Models;
using CustomerManagment.Application.CustomerInfoFeature.Commands;
using CustomerManagment.Persistence;
using FluentResults;

namespace CustomerManagment.Application.CustomerInfoFeature.CommandsHandler
{
    public class GetByIdCustomerCommandHandler :
         Object,
         MediatR.IRequestHandler
         <Commands.GetByIdCustomerCommand, FluentResults.Result<BehsamFramework.Models.CustomerInfoModel>>
    {
        protected AutoMapper.IMapper Mapper { get; }
        protected Persistence.IQueryUnitOfWork UnitOfWork { get; }

        public GetByIdCustomerCommandHandler(IMapper mapper, IQueryUnitOfWork unitOfWork)
        {
            Mapper = mapper;
            UnitOfWork = unitOfWork;
        }

        public async Task<Result<BehsamFramework.Models.CustomerInfoModel>> Handle(GetByIdCustomerCommand request, CancellationToken cancellationToken)
        {
            FluentResults.Result<BehsamFramework.Models.CustomerInfoModel> result =
                new FluentResults.Result<BehsamFramework.Models.CustomerInfoModel>();

            try
            {
                result =
                    await BehsamFramework.Util.Utility.Validate<Commands.GetByIdCustomerCommand, BehsamFramework.Models.CustomerInfoModel>
                        (validator: new Validators.GetByIdCustomerValidator(), command: request);

                if (result.IsFailed)
                {
                    return result;
                }

                // **************************************************


                var cust = await UnitOfWork.CustomerRepository.GetByIdAsync(request.Id);

                BehsamFramework.Models.CustomerInfoModel response =
                    new CustomerInfoModel();
                response=Mapper.Map<BehsamFramework.Models.CustomerInfoModel>(cust);
                
                
                result.WithValue(response);
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