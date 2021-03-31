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
    public class GetCustomerBySearchCommandHandler :
         Object,
         MediatR.IRequestHandler
         <Commands.GetCustomerBySearchCommand, FluentResults.Result<BehsamFramework.Models.CustomerInfoModel>>
    {
        protected AutoMapper.IMapper Mapper { get; }
        protected Persistence.IQueryUnitOfWork UnitOfWork { get; }

        public GetCustomerBySearchCommandHandler(IMapper mapper, IQueryUnitOfWork unitOfWork)
        {
            Mapper = mapper;
            UnitOfWork = unitOfWork;
        }

        public async Task<Result<CustomerInfoModel>> Handle(GetCustomerBySearchCommand request, CancellationToken cancellationToken)
        {
            FluentResults.Result<BehsamFramework.Models.CustomerInfoModel> result =
                new FluentResults.Result<BehsamFramework.Models.CustomerInfoModel>();

            try
            {
                

                // **************************************************
                if(string.IsNullOrEmpty(request.SearchKey.Trim()))
                {
                    return result.WithError("مقدار جستجو صحیح نمی باشد");
                }

                var cust = await UnitOfWork.CustomerRepository.GetCustomerBySearch( request.SearchKey);

                if (cust == null)
                {
                    result.WithError("اطلاعات وجود ندارد");
                }

                result.WithValue(cust);
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