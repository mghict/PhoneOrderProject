using BehsamFramework.Models;
using FluentResults;
using SettingManagment.Application.StoreFeature.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SettingManagment.Application.StoreFeature.CommandsHandler
{
    public class StoreInfoPaginationCommandHandler :
        Object,
        MediatR.IRequestHandler
        <Commands.StoreInfoPaginationCommand, FluentResults.Result<BehsamFramework.Models.StoreInfoListModel>>
    {

        protected Persistence.IQueryUnitOfWork UnitOfWork { get; }

        public StoreInfoPaginationCommandHandler(Persistence.IQueryUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }

        public async Task<Result<StoreInfoListModel>> Handle(StoreInfoPaginationCommand request, CancellationToken cancellationToken)
        {
            FluentResults.Result<BehsamFramework.Models.StoreInfoListModel> result =
                new FluentResults.Result<BehsamFramework.Models.StoreInfoListModel>();

            try
            {


                // **************************************************
                

                var cust = await UnitOfWork.StoreQueryRepository.GetStoreByPaginationAsync(request.PageNumber,request.PageSize, request.SearchKey);

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
