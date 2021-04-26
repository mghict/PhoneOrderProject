using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using WebSites.Panles.Helper;

namespace WebSites.Panles.Services.Authorize
{
    public interface IUserService
    {
        Task<FluentResult<int>> CreateAsync(Models.Authorize.UserRegisterModel model);
        Task<FluentResult> UpdateAsync(Models.Authorize.UserInfoModel model);
        Task<FluentResult> DeleteAsync(int id);
        Task<Models.Authorize.UserInfoModel> GetByIdAsync(int id);
        Task<List<Models.Authorize.UserInfoModel>> GetAllAsync();
        Task<FluentResult> ResetAdminAsync(Models.Authorize.UserInfoModel model);
        Task<FluentResult> ResetUserAsync(Models.Authorize.UserInfoModel model);
        Task<Models.Authorize.UserModel> GetAllSearchAsync(string searchKey = "", int pageNumber = 0, int pageSize = 20);
        Task<Models.Authorize.UserModel> GetAllSearchByAppIdAndStoreIdAsync(int appId, float storeId = 0, string searchKey = "", int pageNumber = 0, int pageSize = 20);
        Task<List<Models.Authorize.UserRoleModel>> GetByUserId(int userId);
        Task<List<Models.Authorize.UserRoleModel>> GetByRoleId(int roleId);
        Task<FluentResult> DeleteRoleAsync(int id);
        Task<FluentResult> CreateRoleAsync(Models.Authorize.UserRoleModel model);

        Task<Models.Authorize.UserInfoModel> GetByUserNameAsync(long userName);
    }

    public class UserService : Base.ServiceBase, IUserService
    {
        public UserService(ICacheService cacheService, ServiceCaller serviceCaller, IHttpClientFactory clientFactory, IMapper mapper) : base(cacheService, serviceCaller, clientFactory, mapper)
        {
        }

        //
        public async Task<FluentResult> ResetAdminAsync(Models.Authorize.UserInfoModel model)
        {
            FluentResult ret = new FluentResult();

            var command = new
            {
                Id = model.Id,
                NewPass = model.Password,
                NewPassConfirm = model.PasswordConfirm
            };

            try
            {
                ret = await ServiceCaller.PostDataWithoutValue("Users/User/AdminResetPass", command);
                ret.WithSuccess("انجام شد");
            }
            catch (Exception ex)
            {
                ret = new FluentResult();
                ret.WithSuccess(ex.Message);
            }

            return ret;
        }

        public async Task<FluentResult> ResetUserAsync(Models.Authorize.UserInfoModel model)
        {
            FluentResult ret = new FluentResult();

            var command = new
            {
                Id = model.Id,
                NewPass = model.Password,
                NewPassConfirm = model.PasswordConfirm,
                CurrentPass=model.CurrentPassword
            };

            try
            {
                ret = await ServiceCaller.PostDataWithoutValue("Users/User/ResetPass", command);
                ret.WithSuccess("انجام شد");
            }
            catch (Exception ex)
            {
                ret = new FluentResult();
                ret.WithSuccess(ex.Message);
            }

            return ret;
        }

        public async Task<FluentResult<int>> CreateAsync(Models.Authorize.UserRegisterModel model)
        {
            FluentResult<int> ret = new FluentResult<int>();

            var command = new
            {
                Name = model.Name,
                Password = model.Password,
                ConfirmPassword = model.PasswordConfirm,
                Storeid=model.Storeid,
                Status=model.Status,
                UserName=model.UserName
            };

            try
            {
                ret = await ServiceCaller.PostDataWithValue<int>("Users/User/Create", command);
                if (ret != null && ret.IsSuccess)
                {
                    await CacheService.ClearTokenAsync(TokenCachClass.User);
                }
            }
            catch (Exception ex)
            {
                ret = new FluentResult<int>();
                ret.WithSuccess(ex.Message);
            }

            return ret;
        }

        public async Task<FluentResult> UpdateAsync(Models.Authorize.UserInfoModel model)
        {
            FluentResult ret = new FluentResult();

            float sId = 0.0f;
            System.Globalization.NumberStyles style = System.Globalization.NumberStyles.AllowDecimalPoint;
            System.Globalization.CultureInfo info = System.Globalization.CultureInfo.InvariantCulture;
            float.TryParse(model.Storeid, style, info, out sId);

            var command = new
            {
                Name = model.Name,
                Storeid = sId,
                Status = model.Status,
                Id=model.Id
            };

            try
            {
                ret = await ServiceCaller.PostDataWithoutValue("Users/User/Update", command);
                if (ret != null && ret.IsSuccess)
                {
                    await CacheService.ClearTokenAsync(TokenCachClass.User);
                }
            }
            catch (Exception ex)
            {
                ret = new FluentResult();
                ret.WithSuccess(ex.Message);
            }

            return ret;
        }

        public async Task<FluentResult> DeleteAsync(int id)
        {
            FluentResult ret = new FluentResult();

            var command = new
            {
                Id=id
            };

            try
            {
                ret = await ServiceCaller.PostDataWithoutValue("Users/User/Delete", command);
                if (ret != null && ret.IsSuccess)
                {
                    await CacheService.ClearTokenAsync(TokenCachClass.User);
                }
            }
            catch (Exception ex)
            {
                ret = new FluentResult();
                ret.WithSuccess(ex.Message);
            }

            return ret;
        }

        private async Task<Models.Authorize.UserInfoModel> getById(int id)
        {
            FluentResult<Models.Authorize.UserInfoModel> ret = 
                new FluentResult<Models.Authorize.UserInfoModel>();

            var command = new
            {
                Id = id
            };

            try
            {
                ret = await ServiceCaller.PostDataWithValue<Models.Authorize.UserInfoModel>("Users/User/GetById", command);
                if (ret == null || ret.IsFailed)
                {
                    ret.WithValue(new Models.Authorize.UserInfoModel());
                }

            }
            catch (Exception ex)
            {
                ret.WithValue(new Models.Authorize.UserInfoModel());
                ret.WithSuccess(ex.Message);
            }

            return ret.Value;
        }

        public async Task<Models.Authorize.UserInfoModel> GetByIdAsync(int id)
        {
            string key = $"UserInfo-ById-{id}";

            Models.Authorize.UserInfoModel ret =
                new Models.Authorize.UserInfoModel();

            ret = await CacheService.GetAsync<Models.Authorize.UserInfoModel>(key);

            if (ret == null || ret.Id<=0)
            {
                ret = await getById(id);
                await CacheService.RemoveAndSetAsync(
                        ret,
                        key,
                        TimeSpan.FromMinutes(10),
                        TimeSpan.FromMinutes(5),
                        Microsoft.Extensions.Caching.Memory.CacheItemPriority.Normal,
                        TokenCachClass.User);
            }

            return ret;
        }

        private async Task<Models.Authorize.UserInfoModel> getByUserName(long userName)
        {
            FluentResult<Models.Authorize.UserInfoModel> ret =
                new FluentResult<Models.Authorize.UserInfoModel>();

            var command = new
            {
                UserName = userName
            };

            try
            {
                ret = await ServiceCaller.PostDataWithValue<Models.Authorize.UserInfoModel>("Users/User/GetByUserName", command);
                if (ret == null || ret.IsFailed)
                {
                    ret.WithValue(new Models.Authorize.UserInfoModel());
                }

            }
            catch (Exception ex)
            {
                ret.WithValue(new Models.Authorize.UserInfoModel());
                ret.WithSuccess(ex.Message);
            }

            return ret.Value;
        }

        public async Task<Models.Authorize.UserInfoModel> GetByUserNameAsync(long userName)
        {
            string key = $"UserInfo-ByUserName-{userName}";

            Models.Authorize.UserInfoModel ret =
                new Models.Authorize.UserInfoModel();

            ret = await CacheService.GetAsync<Models.Authorize.UserInfoModel>(key);

            if (ret == null)
            {
                ret = await getByUserName(userName);
                await CacheService.RemoveAndSetAsync(
                        ret,
                        key,
                        TimeSpan.FromMinutes(10),
                        TimeSpan.FromMinutes(5),
                        Microsoft.Extensions.Caching.Memory.CacheItemPriority.Normal,
                        TokenCachClass.User);
            }

            return ret;
        }

        private async Task<List<Models.Authorize.UserInfoModel>> getAll()
        {
            FluentResult<List<Models.Authorize.UserInfoModel>> ret =
                new FluentResult<List<Models.Authorize.UserInfoModel>>();

            var command = new
            {
                
            };

            try
            {
                ret = await ServiceCaller.PostDataWithValue<List<Models.Authorize.UserInfoModel>>("Users/User/GetAll", command);
                
                if (ret == null || ret.IsFailed)
                {
                    ret.WithValue(new List<Models.Authorize.UserInfoModel>());
                }

            }
            catch (Exception ex)
            {
                ret.WithValue(new List<Models.Authorize.UserInfoModel>());
                ret.WithSuccess(ex.Message);
            }

            return ret.Value;
        }

        public async Task<List<Models.Authorize.UserInfoModel>> GetAllAsync()
        {
            string key = $"UserInfo-All";

            List<Models.Authorize.UserInfoModel> ret =
                new List<Models.Authorize.UserInfoModel>();

            ret = await CacheService.GetAsync<List<Models.Authorize.UserInfoModel>>(key);

            if (ret == null)
            {
                ret = await getAll();
                await CacheService.RemoveAndSetAsync(
                        ret,
                        key,
                        TimeSpan.FromMinutes(10),
                        TimeSpan.FromMinutes(5),
                        Microsoft.Extensions.Caching.Memory.CacheItemPriority.Normal,
                        TokenCachClass.User);
            }

            return ret;
        }

        private async Task<Models.Authorize.UserModel> getAllSearch(string searchKey="",int pageNumber=0,int pageSize=20)
        {
            FluentResult<Models.Authorize.UserModel> ret =
                new FluentResult<Models.Authorize.UserModel>();

            var command = new
            {
                SearchKey= searchKey,
                PageNumber= pageNumber,
                PageSize= pageSize
            };



            try
            {
                ret = await ServiceCaller.PostDataWithValue<Models.Authorize.UserModel>("Users/User/GetAllBySearch", command);

                if (ret == null || ret.IsFailed ||ret.Value==null || ret.Value.RowCount==0 || ret.Value.Users==null || ret.Value.Users.Count==0)
                {
                    throw new Exception("اطلاعات جود ندارد");
                }

            }
            catch (Exception ex)
            {
                ret.WithValue(new Models.Authorize.UserModel());
                ret.WithSuccess(ex.Message);
            }

            return ret.Value;
        }

        public async Task<Models.Authorize.UserModel> GetAllSearchAsync(string searchKey = "", int pageNumber = 0, int pageSize = 20)
        {
            string key = $"UserInfo-All-{searchKey}-{pageNumber}-{pageSize}";

            Models.Authorize.UserModel ret =
                new Models.Authorize.UserModel();

            ret = await CacheService.GetAsync<Models.Authorize.UserModel>(key);

            if (ret == null)
            {
                ret = await getAllSearch(searchKey,pageNumber,pageSize);
                await CacheService.RemoveAndSetAsync(
                        ret,
                        key,
                        TimeSpan.FromMinutes(10),
                        TimeSpan.FromMinutes(5),
                        Microsoft.Extensions.Caching.Memory.CacheItemPriority.Normal,
                        TokenCachClass.User);
            }

            return ret;
        }

        private async Task<Models.Authorize.UserModel> getAllSearchByAppIdAndStoreId(int appId,float storeId=0, string searchKey = "", int pageNumber = 0, int pageSize = 20)
        {
            FluentResult<Models.Authorize.UserModel> ret =
                new FluentResult<Models.Authorize.UserModel>();

            var command = new
            {
                ApplicationId=appId,
                StoreId=storeId,
                SearchKey = searchKey,
                PageNumber = pageNumber,
                PageSize = pageSize
            };



            try
            {
                ret = await ServiceCaller.PostDataWithValue<Models.Authorize.UserModel>("Users/User/GetAllBySearchAppIdAndStoreId", command);

                if (ret == null || ret.IsFailed || ret.Value == null || ret.Value.RowCount == 0 || ret.Value.Users == null || ret.Value.Users.Count == 0)
                {
                    throw new Exception("اطلاعات جود ندارد");
                }

            }
            catch (Exception ex)
            {
                ret.WithValue(new Models.Authorize.UserModel());
                ret.WithSuccess(ex.Message);
            }

            return ret.Value;
        }
        public async Task<Models.Authorize.UserModel> GetAllSearchByAppIdAndStoreIdAsync(int appId, float storeId = 0, string searchKey = "", int pageNumber = 0, int pageSize = 20)
        {
            string key = $"UserInfo-All-{appId}-{storeId}-{searchKey}-{pageNumber}-{pageSize}";

            Models.Authorize.UserModel ret =
                new Models.Authorize.UserModel();

            ret = await CacheService.GetAsync<Models.Authorize.UserModel>(key);

            if (ret == null)
            {
                ret = await getAllSearchByAppIdAndStoreId(appId,storeId,searchKey, pageNumber, pageSize);
                await CacheService.RemoveAndSetAsync(
                        ret,
                        key,
                        TimeSpan.FromMinutes(10),
                        TimeSpan.FromMinutes(5),
                        Microsoft.Extensions.Caching.Memory.CacheItemPriority.Normal,
                        TokenCachClass.User);
            }

            return ret;
        }
        //----------------------------
        public async Task<FluentResult> CreateRoleAsync(Models.Authorize.UserRoleModel model)
        {
            FluentResult ret = new FluentResult();

            var command = new
            {
                RoleId=model.RoleId,
                UserId=model.UserId,
                Status = model.Status,
            };

            try
            {
                ret = await ServiceCaller.PostDataWithoutValue("Users/User/CreateRole", command);
            }
            catch (Exception ex)
            {
                ret = new FluentResult();
                ret.WithSuccess(ex.Message);
            }

            return ret;
        }

        public async Task<FluentResult> DeleteRoleAsync(int id)
        {
            FluentResult ret = new FluentResult();

            var command = new
            {
                Id = id
            };

            try
            {
                ret = await ServiceCaller.PostDataWithoutValue("Users/User/DeleteRole", command);
            }
            catch (Exception ex)
            {
                ret = new FluentResult();
                ret.WithSuccess(ex.Message);
            }

            return ret;
        }

        public async Task<List<Models.Authorize.UserRoleModel>> GetByRoleId(int roleId)
        {
            FluentResult<List<Models.Authorize.UserRoleModel>> ret =
                new FluentResult<List<Models.Authorize.UserRoleModel>>();

            var command = new
            {
                RoleId=roleId
            };

            try
            {
                ret = await ServiceCaller.PostDataWithValue<List<Models.Authorize.UserRoleModel>>("Users/User/GetUserRoleByRole", command);

                if (ret == null || ret.IsFailed)
                {
                    ret.WithValue(new List<Models.Authorize.UserRoleModel>());
                }

            }
            catch (Exception ex)
            {
                ret.WithValue(new List<Models.Authorize.UserRoleModel>());
                ret.WithSuccess(ex.Message);
            }

            return ret.Value;
        }

        public async Task<List<Models.Authorize.UserRoleModel>> GetByUserId(int userId)
        {
            FluentResult<List<Models.Authorize.UserRoleModel>> ret =
                new FluentResult<List<Models.Authorize.UserRoleModel>>();

            var command = new
            {
                UserId = userId
            };

            try
            {
                ret = await ServiceCaller.PostDataWithValue<List<Models.Authorize.UserRoleModel>>("Users/User/GetUserRoleByUser", command);

                if (ret == null || ret.IsFailed)
                {
                    ret.WithValue(new List<Models.Authorize.UserRoleModel>());
                }

            }
            catch (Exception ex)
            {
                ret.WithValue(new List<Models.Authorize.UserRoleModel>());
                ret.WithSuccess(ex.Message);
            }

            return ret.Value;
        }
    }
}
