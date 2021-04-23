using CustomerManagment.Application.CustomerAddressFeature.Commands;
using CustomerManagment.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CustomerManagment.Application.CustomerAddressFeature.CommandsHandler
{
    public class DefineCustomerAddressAreaCommandHandler :
        MediatR.IRequestHandler<Commands.DefineCustomerAddressAreaCommand>
    {
        private Persistence.IQueryUnitOfWork QueryUnitOfWork;
        private Persistence.IUnitOfWork UnitOfWork;

        public DefineCustomerAddressAreaCommandHandler(IQueryUnitOfWork queryUnitOfWork, IUnitOfWork unitOfWork)
        {
            QueryUnitOfWork = queryUnitOfWork;
            UnitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(DefineCustomerAddressAreaCommand request, CancellationToken cancellationToken)
        {
            await UnitOfWork.CustomerAddressAreaInfoRepository.DisableAllAsync(request.CustomerAddressId);

            NumberStyles style = NumberStyles.AllowDecimalPoint;
            CultureInfo info = CultureInfo.InvariantCulture;

            float tempLat = 0.0f,tempLng=0.0f;

            float.TryParse(request.Lat.ToString(info), style, info, out tempLat);
            float.TryParse(request.Lng.ToString(info), style, info, out tempLng);

            var custPoint = new PointF()
            {
                X=tempLat,
                Y = tempLng
            };

            var lst =await QueryUnitOfWork.AreaGeoQueryRepository.GetAllAsync();

            var pointList = lst.Select(p => p.AreaId).Distinct();

            foreach (var item in pointList)
            {
                
                var points = lst.Where(p => p.AreaId == item).Select(s => new PointF
                {
                    X = s.Latitude,
                    Y = s.Longitude
                });

                var result = IsInPolygon(points.ToArray(), custPoint);
                

                if(result)
                {
                    var isExist =await QueryUnitOfWork.CustomerAddressAreaInfoQueryRepository.GetByAreaAndCustomer(item, request.CustomerAddressId);

                    if (isExist == null || isExist.Id <= 0)
                    {
                        var entity= new Domain.Entities.CustomerAddressAreaInfo
                        {
                            AreaId = item,
                            CustomerAddressId = request.CustomerAddressId,
                            Status = true
                        };
                        var insertResult = await UnitOfWork.CustomerAddressAreaInfoRepository.InsertAsync(entity);
                    }
                    else
                    {
                        await UnitOfWork.CustomerAddressAreaInfoRepository.EnableAsync(isExist.Id);
                    }
                }
            }


            await UnitOfWork.CustomerAddressAreaInfoRepository.RemoveAllDisableAsync(request.CustomerAddressId);

            return Unit.Value;

        }

        public static bool IsInPolygon(Point[] poly, Point point)
        {
            var coef = poly.Skip(1).Select((p, i) =>
                                            (point.Y - poly[i].Y) * (p.X - poly[i].X)
                                          - (point.X - poly[i].X) * (p.Y - poly[i].Y))
                                    .ToList();

            if (coef.Any(p => p == 0))
                return true;

            for (int i = 1; i < coef.Count(); i++)
            {
                if (coef[i] * coef[i - 1] < 0)
                    return false;
            }
            return true;
        }

        public static bool IsInPolygon(PointF[] poly, PointF point)
        {
            var coef = poly.Skip(1).Select((p, i) =>
                                            (point.Y - poly[i].Y) * (p.X - poly[i].X)
                                          - (point.X - poly[i].X) * (p.Y - poly[i].Y))
                                    .ToList();

            if (coef.Any(p => p == 0))
                return true;

            for (int i = 1; i < coef.Count(); i++)
            {
                if (coef[i] * coef[i - 1] < 0)
                    return false;
            }
            return true;
        }

    }
}
