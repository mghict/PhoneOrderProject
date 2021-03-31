using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;
using WebSites.Panles.Models;

namespace WebSites.Panles.Helper
{
    public class StaticValues
    {
        private CustomerListModel _customerListModel=new CustomerListModel();
        private List<AttributeStatus> _status = new List<AttributeStatus>();

        private ICacheService _cacheService;
        private ServiceCaller<CustomerListModel> _service;
        private ServiceCaller _serviceCaller;
        private IHttpClientFactory _clientFactory;

        public StaticValues(ICacheService cacheService, IHttpClientFactory clientFactory)
        {

            _clientFactory = clientFactory;
            _service = new ServiceCaller<CustomerListModel>(_clientFactory);
            _cacheService = cacheService;
            _serviceCaller = new ServiceCaller(_clientFactory);
        }

        public CustomerListModel CustomerListModel
        {
            get
            {
                CustomerListModel ret = new CustomerListModel();
                ret = _cacheService.GetOrSet(ret,
                    TimeSpan.FromHours(8),
                    TimeSpan.FromHours(1),
                    CacheItemPriority.High,
                    TokenCachClass.CustomerList,
                    GetFromService);

                _customerListModel = ret;
                
                return _customerListModel;
            }
        }
        public CustomerAttribute CustomerListModel_Group
        {
            get
            {
                CustomerListModel ret = CustomerListModel;
                if (ret == null || ret.CustomerGroup.Value==null)
                {
                    ret = GetFromService();
                    ret = _cacheService.RemoveAndSet(ret,
                        TimeSpan.FromHours(8),
                        TimeSpan.FromHours(1),
                        CacheItemPriority.High,
                        TokenCachClass.CustomerList);
                }

                if (!_customerListModel.CustomerGroup.IsSuccess )
                {
                    _cacheService.ClearCache(ret);
                }
                return ret.CustomerGroup.Value;
            }
        }
        public CustomerAttribute CustomerListModel_Type
        {
            get
            {
                CustomerListModel ret =  CustomerListModel;
                if (ret == null || ret.CustomerType.Value==null)
                {
                    ret = GetFromService();
                    ret = _cacheService.RemoveAndSet(ret,
                        TimeSpan.FromHours(8),
                        TimeSpan.FromHours(1),
                        CacheItemPriority.High,
                        TokenCachClass.CustomerList);
                }
                if (!_customerListModel.CustomerType.IsSuccess)
                {
                    _cacheService.ClearCache(ret);
                }
                return ret.CustomerType.Value;
            }
        }
        public CustomerAttribute CustomerListModel_RegisterType
        {
            get
            {
                CustomerListModel ret = CustomerListModel;
                if (ret == null || ret.CustomerRegisterType.Value==null)
                {
                    ret = GetFromService();
                    ret = _cacheService.RemoveAndSet(ret,
                        TimeSpan.FromHours(8),
                        TimeSpan.FromHours(1),
                        CacheItemPriority.High,
                        TokenCachClass.CustomerList);
                }
                if (!_customerListModel.CustomerRegisterType.IsSuccess)
                {
                    _cacheService.ClearCache(ret);
                }
                return ret.CustomerRegisterType.Value;
            }
        }
        public CustomerAttribute CustomerListModel_Education
        {
            get
            {
                CustomerListModel ret = CustomerListModel;
                if (ret == null || ret.CustomerEducation.Value==null)
                {
                    ret = GetFromService();
                    ret = _cacheService.RemoveAndSet(ret,
                        TimeSpan.FromHours(8),
                        TimeSpan.FromHours(1),
                        CacheItemPriority.High,
                        TokenCachClass.CustomerList);
                }

                if (!_customerListModel.CustomerEducation.IsSuccess)
                {
                    _cacheService.ClearCache(ret);
                }

                return ret.CustomerEducation.Value;
            }
        }
        public CustomerAttribute CustomerListModel_Job
        {
            get
            {
                CustomerListModel ret = CustomerListModel;
                if (ret == null || ret.CustomerJob.Value==null)
                {
                    ret = GetFromService();
                    ret = _cacheService.RemoveAndSet(ret,
                        TimeSpan.FromHours(8),
                        TimeSpan.FromHours(1),
                        CacheItemPriority.High,
                        TokenCachClass.CustomerList);
                }
                if (!_customerListModel.CustomerJob.IsSuccess)
                {
                    _cacheService.ClearCache(ret);
                }
                return ret.CustomerJob.Value;
            }
        }
        public CustomerAttribute CustomerListModel_Sex
        {
            get
            {
                CustomerListModel ret = CustomerListModel;
                if (ret == null || ret.CustomerSex.Value==null)
                {
                    ret = GetFromService();
                    ret = _cacheService.RemoveAndSet(ret,
                        TimeSpan.FromHours(8),
                        TimeSpan.FromHours(1),
                        CacheItemPriority.High,
                        TokenCachClass.CustomerList);
                }
                if (!_customerListModel.CustomerSex.IsSuccess)
                {
                    _cacheService.ClearCache(ret);
                }
                return ret.CustomerSex.Value;
            }
        }
        private CustomerListModel GetFromService()
        {

            return _service.GetDataWithValueAggregate("Customer/List").Result;
        }

        /// <summary>
        /// Status
        /// </summary>
        /// <returns>All Status in DB</returns>
        
        public List<AttributeStatus> GetStatuses
        {
            get
            {
                List<AttributeStatus> ret = new List<AttributeStatus>();

                ret =_cacheService.GetOrSetAsync(ret,
                    TimeSpan.FromHours(8),
                    TimeSpan.FromHours(1),
                    CacheItemPriority.High,
                    TokenCachClass.AttributeStatusAdd,
                    GetStatusService).Result;

                _status = ret;
                if (_status.Count < 1)
                {
                    _cacheService.ClearCache(ret);
                }
                return _status;
            }
        }
        private async Task< List<AttributeStatus>> GetStatusService()
        {
            List<AttributeStatus> retVal = new List<AttributeStatus>();
            try
            {
                var result = await _serviceCaller.GetDataWithValue<List<AttributeStatus>>("Status");
                if (result.IsSuccess)
                {
                    return result.Value;
                }
                else
                {
                    return retVal;
                }
            }
            catch (Exception ex)
            {

                return retVal;
            }

        }
    }
}
