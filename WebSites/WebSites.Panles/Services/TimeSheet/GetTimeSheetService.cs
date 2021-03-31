using AutoMapper;
using BehsamFramework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using WebSites.Panles.Helper;
using BehsamFramework.Util;

namespace WebSites.Panles.Services.TimeSheet
{
    public interface IGetTimeSheetService
    {
        Task<List<BehsamFramework.Models.TimeSheetTableModel>> ExecuteAsync(DateTime dateTime);
    }
    public class GetTimeSheetService :Base.ServiceBase, IGetTimeSheetService
    {
        public GetTimeSheetService(ICacheService cacheService, ServiceCaller serviceCaller, IHttpClientFactory clientFactory, IMapper mapper) : base(cacheService, serviceCaller, clientFactory, mapper)
        {
        }

        public async Task<List<TimeSheetTableModel>> ExecuteAsync(DateTime dateTime)
        {
            List<TimeSheetTableModel> ret = new List<TimeSheetTableModel>();
            string key = "TimeSheet" + dateTime.GetPersianDate();
            
            ret =await CacheService.GetOrSetAsync(
                ret,
                dateTime,
                key,
                TimeSpan.FromHours(8),
                TimeSpan.FromHours(7),
                Microsoft.Extensions.Caching.Memory.CacheItemPriority.High,
                TokenCachClass.TimeSheetToken,
                GetData
                );

            if(ret==null)
            {
                ret= new List<TimeSheetTableModel>();
            }

            return ret;
        }

        private async Task<List<TimeSheetTableModel>> GetData(DateTime dateTime)
        {
            List<TimeSheetTableModel> result = new List<TimeSheetTableModel>();

            var Command = new
            {
                RequestDate = dateTime
            };

            FluentResult<List<BehsamFramework.Models.TimeSheetTableModel>> model =
                new FluentResult<List<TimeSheetTableModel>>();

            try
            {
                model = await ServiceCaller.PostDataWithValue<List<TimeSheetTableModel>>("Setting/TimeSheetGeneral", Command);
                

                if(model==null || model.Value==null || model.IsFailed)
                {
                    throw new Exception("اطلاعات یافت نشد");
                }

            }
            catch (Exception ex)
            {
                model = new FluentResult<List<TimeSheetTableModel>>()
                {
                    Value=new List<TimeSheetTableModel>()
                };
                model.WithError(ex.Message);
            }

            return model.Value;
        }
    }
}
