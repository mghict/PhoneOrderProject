using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using WebSites.Panles.Helper;
using WebSites.Panles.Models.TimeSheet;

namespace WebSites.Panles.Services.TimeSheet
{
    public interface ITimeSheetService
    {
        Task<List<Models.TimeSheet.StoreTimeSheetTbl>> GetAll();
        Task<Models.TimeSheet.StoreTimeSheetTbl> GetById(byte id);
        Task<FluentResult> UpdateTimeSheet(byte id,TimeSpan fromTime,TimeSpan toTime,byte stepTime,bool status);
    }

    public class TimeSheetService : Base.ServiceBase, ITimeSheetService
    {
        public TimeSheetService(ICacheService cacheService, ServiceCaller serviceCaller, IHttpClientFactory clientFactory, IMapper mapper) : base(cacheService, serviceCaller, clientFactory, mapper)
        {
        }

        private async Task<List<StoreTimeSheetTbl>> getAll()
        {
            List<StoreTimeSheetTbl> result = new List<StoreTimeSheetTbl>();
            var command = new { };
            try
            {
                var res= await ServiceCaller.PostDataWithValue<List<StoreTimeSheetTbl>>("Setting/TimeSheet/GetAllTimeSheet", command);
                if(res!=null && res.IsSuccess)
                {
                    result = res.Value;
                }
            }
            catch
            {
                result = new List<StoreTimeSheetTbl>();
            }

            return result;
        }

        public async Task<List<StoreTimeSheetTbl>> GetAll()
        {
            List<StoreTimeSheetTbl> result = new List<StoreTimeSheetTbl>();

            string key = "StoreTimeSheetTblGetAll";

            result = await CacheService.GetOrSetAsync<List<StoreTimeSheetTbl>>(
                        result,
                        key,
                        TimeSpan.FromHours(8),
                        TimeSpan.FromHours(1),
                        Microsoft.Extensions.Caching.Memory.CacheItemPriority.Normal,
                        TokenCachClass.TimeSheetToken,
                        getAll
                     );

            return result;
        }

        public async Task<FluentResult> UpdateTimeSheet(byte id, TimeSpan fromTime, TimeSpan toTime, byte stepTime, bool status)
        {
            FluentResult result = new FluentResult();
            var command = new { 
                Id=id,
                FromTime=fromTime,
                ToTime=toTime,
                StepTime=stepTime,
                Status=status
            };
            try
            {
                result = await ServiceCaller.PostDataWithoutValue("Setting/TimeSheet/UpdateTimeSheet", command);
                if (result!=null && result.IsSuccess)
                {
                    CacheService.ClearToken(TokenCachClass.TimeSheetToken);
                }
            }
            catch
            {
                result = new FluentResult() {IsFailed=true };
            }

            return result;
        }

        public async Task<StoreTimeSheetTbl> GetById(byte id)
        {
            var result = await GetAll();
            if(result!=null && result.Count>0)
            {
                return result.FirstOrDefault(p => p.Id == id);
            }
            else
            {
                return new StoreTimeSheetTbl();
            }
        }
    }
}
