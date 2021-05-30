﻿using AutoMapper;
using FluentResults;
using SettingManagment.Application.StoreShippingFeature.Commands;
using SettingManagment.Persistence;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SettingManagment.Application.StoreShippingFeature.CommandsHandler
{
    public class UpdateShippingGlobalDistanceCommandHandler :
        MediatR.IRequestHandler<Commands.UpdateShippingGlobalDistanceCommand, FluentResults.Result>
    {
        protected AutoMapper.IMapper Mapper { get; }
        protected Persistence.IUnitOfWork UnitOfWork { get; }
        protected Persistence.IQueryUnitOfWork QueryUnitOfWork { get; }

        public UpdateShippingGlobalDistanceCommandHandler(IMapper mapper, IUnitOfWork unitOfWork, IQueryUnitOfWork queryUnitOfWork)
        {
            Mapper = mapper;
            UnitOfWork = unitOfWork;
            QueryUnitOfWork = queryUnitOfWork;
        }

        public async Task<Result> Handle(UpdateShippingGlobalDistanceCommand request, CancellationToken cancellationToken)
        {
            FluentResults.Result result =
                new FluentResults.Result();

            try
            {
                result =
                    await BehsamFramework.Util.Utility.Validate<Commands.UpdateShippingGlobalDistanceCommand>
                        (validator: new Validation.UpdateShippingGlobalDistanceValidator(), command: request);

                if (result.IsFailed)
                {
                    return result;
                }

                // **************************************************
                var entity = Mapper.Map<Domain.Entities.StoreGeneralShippingByDistanceTbl>(request);

                //---------------------------------------------------------------------------------
                //کنترل تکراری نبودن اطلاعات
                //---------------------------------------------------------------------------------
                var isExists = await UnitOfWork.ShippingGlobalDistanceRepository.ExistsInRangeAsync(entity.FromDistance, entity.ToDistance);
                if (isExists == -1)
                {
                    result.WithError("خطا در زمان ورود اطلاعات");
                    return result;
                }
                else if (isExists == 0)
                {
                    result.WithError("اطلاعات برای بازه مشخص شده وجود ندارد");
                    return result;
                }
                else if (isExists != entity.Id)
                {
                    result.WithError("اطلاعات برای بازه مشخص شده وجود دارد");
                    return result;
                }

                //---------------------------------------------------------------------------------
                //کنترل مبلغ با مبلغ کرایه کلی
                //---------------------------------------------------------------------------------
                var shippingGlobal = await QueryUnitOfWork.ShippingGlobalQueryRepository.GetAllAsync();
                foreach (var item in shippingGlobal.ToList())
                {
                    if (item.ShippingPrice < entity.ShippingPrice)
                    {
                        result.WithError("کرایه مشخص شده از کرایه کلی تعریف شده بیشتر است");
                        return result;
                    }
                }

                //************************************************************************
                //************************************************************************

                var inActive = await UnitOfWork.ShippingGlobalDistanceRepository.UpdateAsync(entity);


                // **************************************************

                // **************************************************

                if (inActive)
                {
                    result.WithSuccess
                        (successMessage: BehsamFramework.Resources.Messages.SuccessInsert);

                }
                else
                {
                    result.WithError
                        (BehsamFramework.Resources.Messages.ErrorDone);
                }
            }
            catch (Exception e)
            {
                result.WithError(e.Message);
            }

            return result;
        }
    }
}
