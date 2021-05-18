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
    public class GetAllCustomerCommandHandler :
         Object,
         MediatR.IRequestHandler
         <Commands.GetAllCustomerCommand, FluentResults.Result<BehsamFramework.Models.CustomerInfoListModel>>
    {
        protected AutoMapper.IMapper Mapper { get; }
        protected Persistence.IQueryUnitOfWork UnitOfWork { get; }

        public GetAllCustomerCommandHandler(IMapper mapper, IQueryUnitOfWork unitOfWork)
        {
            Mapper = mapper;
            UnitOfWork = unitOfWork;
        }

        public async Task<Result<CustomerInfoListModel>> Handle(GetAllCustomerCommand request, CancellationToken cancellationToken)
        {
            FluentResults.Result<BehsamFramework.Models.CustomerInfoListModel> result =
                new FluentResults.Result<BehsamFramework.Models.CustomerInfoListModel>();

            try
            {
                //if (request.PageNumber < 0)
                //{
                //    request.PageNumber = 1;
                //}

                //if ( request.PageSize < 10)
                //{
                //    request.PageSize = 10;
                //}

                // **************************************************


                var cust = await UnitOfWork.CustomerRepository.GetAllByPageingAndSearch(request.PageNumber, request.PageSize, request.SearchKey);

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