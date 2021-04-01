using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Primitives;
using WebSites.Panles.Helper;
using WebSites.Panles.Models;

namespace WebSites.Panles.Areas.CallCenter.Controllers
{
    [Area("CallCenter")]
    public class CustomerController : Controller
    {
        IMemoryCache _memoryCache;
        private ICacheService CacheService;
        private IHttpClientFactory ClientFactory;
        private ServiceCaller<CustomerListModel> Service;
        private ServiceCaller<long> ServiceInsert;
        protected ServiceCaller serviceCaller;
        protected AutoMapper.IMapper Mapper;
        private Services.Authorize.IAuthorizeService AuthorizeService;


        private StaticValues staticValues;


        private Services.Customer.IGetCustomer GetCustomer;
        private Services.CustomerPhone.IGetCustomerPhone GetCustomerPhone;
        private Services.CustomerAddress.IGetCustomerAddressService GetCustomerAddressService;
        public CustomerController(
                                  Services.Authorize.IAuthorizeService authorizeService,
                                  AutoMapper.IMapper mapper,
                                  IMemoryCache memoryCache, 
                                  IHttpClientFactory _clientFactory, 
                                  ICacheService _cacheService, 
                                  StaticValues StaticValues,
                                  Services.Customer.IGetCustomer _getCustomer,
                                  Services.CustomerPhone.IGetCustomerPhone _getCustomerPhone,
                                  Services.CustomerAddress.IGetCustomerAddressService _getCustomerAddressService)
        {
            staticValues = StaticValues;
            _memoryCache = memoryCache;
            ClientFactory = _clientFactory;
            Service = new ServiceCaller<CustomerListModel>(ClientFactory);
            ServiceInsert = new ServiceCaller<long>(ClientFactory);
            serviceCaller = new ServiceCaller(ClientFactory);
            CacheService = _cacheService;
            Mapper = mapper;
            GetCustomer = _getCustomer;
            GetCustomerPhone = _getCustomerPhone;
            GetCustomerAddressService = _getCustomerAddressService;
            AuthorizeService = authorizeService;
            //GetCustomer =new Services.Customer.GetCustomer(CacheService, serviceCaller, ClientFactory,Mapper);
        }

        [WebSites.Panles.Helper.Authorize.CustomAuthorize]
        public IActionResult Index(int page = 1, int pagesize = 10, string searchkey = "")
        {
            GetPagianationDataModel command =
                new GetPagianationDataModel()
                {
                    PageNumber=page,
                    PageSize=pagesize,
                    SearchKey=searchkey
                };


            FluentResult<BehsamFramework.Models.CustomerInfoListModel> retVal =
                new FluentResult<BehsamFramework.Models.CustomerInfoListModel>();

            try
            {
                //retVal = await serviceCaller.PostDataWithValue<BehsamFramework.Models.CustomerInfoListModel>("Customer/GetCustomers", command);
                var res =  serviceCaller.PostDataWithValue<BehsamFramework.Models.CustomerInfoListModel>("Customer/GetCustomers", command);

                res.Wait();

                retVal = res.Result;
            }
            catch
            {
                retVal = new FluentResult<BehsamFramework.Models.CustomerInfoListModel>();
            }
            
            return View(Mapper.Map<Models.CustomerInfoListModel>( retVal.Value));
        }
        public void RegisterFiller()
        {
            try
            {
                CustomerListModel ret = new CustomerListModel();
                ret = staticValues.CustomerListModel;

                //if (ret == null)
                //{
                //    return Json(new { IsSuccess = false, errors = "خطا در واکشی اطلاعات" });
                //}

                var customerGroup = ret.CustomerGroup.Value.ValuesList.ToList();
                ViewBag.customerGroup = new SelectList(customerGroup, "Id", "Name");

                var customerEducation = ret.CustomerEducation.Value.ValuesList.ToList();
                ViewBag.customerEducation = new SelectList(customerEducation, "Id", "Name");

                var customerJob = ret.CustomerJob.Value.ValuesList.ToList();
                ViewBag.customerJob = new SelectList(customerJob, "Id", "Name");

                var customerRegisterType = ret.CustomerRegisterType.Value.ValuesList.ToList();
                ViewBag.customerRegisterType = new SelectList(customerRegisterType, "Id", "Name");

                var customerSex = ret.CustomerSex.Value.ValuesList.ToList();
                ViewBag.customerSex = new SelectList(customerSex, "Id", "Name");

                var customerType = ret.CustomerType.Value.ValuesList.ToList();
                ViewBag.customerType = new SelectList(customerType, "Id", "Name");

                //return Json(new { IsSuccess = true, errors ="" });

            }
            catch 
            {
                //return Json(new { IsSuccess = "False", Errors = "خطا \n" + ex.Message });

            }
        }

        [HttpGet(Name = "Register")]
        public IActionResult Register()
        {
            RegisterFiller();
            //CustomerRegisterModel model = new CustomerRegisterModel();
            return View();
        }

        [HttpPost(Name = "Register")]
        //public async Task<IActionResult> Register(CustomerRegisterModel model)
        public IActionResult Register(CustomerRegisterModel model)
        {
            
            try
            {
                RegisterFiller();

                model.Status = 2;
                model.RegisterTypeId = 6;
                if (ModelState.IsValid)
                {

                    //var ret = await ServiceInsert.PostDataWithValue("Customer/create", model);
                    var ret =  ServiceInsert.PostDataWithValue("Customer/create", model).Result;

                    if (ret != null)
                    {
                        //return Json(new { IsSuccess = ret.IsSuccess, Errors = ret.Errors.ToList().ToString(), Value = ret.Value });
                        if(ret.IsFailed)
                        {
                            throw new Exception(ret.GetErrors());
                        }
                        CacheService.ClearToken(TokenCachClass.CustomerList);
                        return RedirectToAction("Index", "Customer",new { area= "CallCenter" });
                    }
                    else
                    {
                        throw new Exception("خطا در عملیات");
                    }
                }
                else
                {
                    ModelState.AddModelError("خطا","اطلاعات را وارد کنید");
                    return View("Register",model);
                }

            }
            catch (Exception e)
            {
                //return Json(new {IsSuccess=false,Errors=e.Message });
                
                ModelState.AddModelError("خطا", e.Message);
                return View("Register", model);
            }

        }

        [HttpPost(Name = "Delete")]
        public async Task<IActionResult> Delete(long customerId)
        {
            try
            {
                var model = new
                {
                    Id = customerId
                };
                var ret = await ServiceInsert.PostDataWithValue("Customer/Remove", model);

                if (ret != null)
                {
                    if(ret.IsSuccess)
                    {
                        await CacheService.ClearCacheAsync("CustomerInfo" + model.Id.ToString());
                        CacheService.ClearToken(TokenCachClass.CustomerList);
                    }
                    return Json(new { IsSuccess = ret.IsSuccess, Errors = ret.GetErrors(), Value = ret.Value });
                }
                else
                {
                    throw new Exception("خطا در عملیات");
                }

            }
            catch (Exception e)
            {
                return Json(new { IsSuccess = false, Errors = e.Message });
            }

        }

        [HttpGet(Name = "Update")]
        public async Task< IActionResult> Update(long customerId)
        {
            RegisterFiller();
            StatusFiller();
            var ret = await GetCustomer.GetCustomerInfoAsync(customerId);
            var model=Mapper.Map<Models.Customer.CustomerUpdateModel>(ret);
            return View(model);
        }

        [HttpPost(Name = "Update")]
        public async Task< IActionResult> Update(Models.Customer.CustomerUpdateModel model)
        {
            
            try
            {
                RegisterFiller();
                StatusFiller();

                if (ModelState.IsValid)
                {

                    var ret = await ServiceInsert.PostDataWithValue("Customer/Update", model);

                    if (ret != null)
                    {
                        
                        if (ret.IsFailed)
                        {
                            throw new Exception(ret.GetErrors());
                        }
                        await CacheService.ClearCacheAsync("CustomerInfo"+model.Id.ToString());
                        CacheService.ClearToken(TokenCachClass.CustomerList);
                        return RedirectToAction("Index", "Customer", new { area = "CallCenter" });
                    }
                    else
                    {
                        throw new Exception("خطا در عملیات");
                    }
                }
                else
                {
                    ModelState.AddModelError("خطا", "اطلاعات را وارد کنید");
                    return View("Update", model);
                }

            }
            catch (Exception e)
            {

                ModelState.AddModelError("خطا", e.Message);
                return View("Update", model);
            }
        }


        [HttpGet(Name = "CustomerProfile")]
        public async Task<IActionResult> CustomerProfile(long customerId)
        {
            var model = new Models.Customer.CustomerProfileModel();

            await Task.Run(async() =>
            {
                var customerInfo = await GetCustomer.GetCustomerInfoAsync(customerId);
                var customerPhones =await GetCustomerPhone.Execute(customerId);
                var customerAddress =await GetCustomerAddressService.ExecuteGetAddresses(customerId);

                model.GetCustomerInfo =  customerInfo;
                model.GetCustomerPhones = customerPhones;
                model.GetCustomerAddresses = customerAddress;

            });

            return View(model);

        }
        
        public void StatusFiller()
        {
            try
            {
                var ret = staticValues.GetStatuses;

                var customerStatus = ret.Where(p => p.Subject.ToLower().Equals("CustomerStatus".ToLower()) && p.Status==true);
                ViewBag.customerStatus = new SelectList(customerStatus, "StatusId", "Name");
            }
            catch
            {

            }
        }
    }
}
