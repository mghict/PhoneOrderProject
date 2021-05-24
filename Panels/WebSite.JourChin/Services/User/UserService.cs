using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using WebSite.JourChin.Helper;

namespace WebSite.JourChin.Services.User
{
    public interface IUserService
    {

        Task<Models.User.UserInfoModel> GetByIdAsync(int id);

        Task<FluentResults.Result> ResetUserAsync(Models.User.UserInfoModel model);

        Task<Models.User.UserInfoModel> GetByUserNameAsync(long userName);
    }

    public class UserService : Base.ServiceBase, IUserService
    {
        public UserService(ICachedMemoryService cacheService, ServiceCaller serviceCaller, IHttpClientFactory clientFactory, IMapper mapper) : base(cacheService, serviceCaller, clientFactory, mapper)
        {
        }


        public async Task<FluentResults.Result> ResetUserAsync(Models.User.UserInfoModel model)
        {
            FluentResults.Result ret = new FluentResults.Result();

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
                ret = new FluentResults.Result();
                ret.WithError(ex.Message);
            }

            return ret;
        }

        public async Task<Models.User.UserInfoModel> GetByIdAsync(int id)
        {
            FluentResults.Result<Models.User.UserInfoModel> ret = 
                new FluentResults.Result<Models.User.UserInfoModel>();

            var command = new
            {
                Id = id
            };

            try
            {
                ret = await ServiceCaller.PostDataWithValue<Models.User.UserInfoModel>("Users/User/GetById", command);
                if (ret == null || ret.IsFailed)
                {
                    ret.WithValue(new Models.User.UserInfoModel());
                }

            }
            catch (Exception ex)
            {
                ret.WithValue(new Models.User.UserInfoModel());
                ret.WithSuccess(ex.Message);
            }

            return ret.Value;
        }

        public async Task<Models.User.UserInfoModel> GetByUserNameAsync(long userName)
        {
            FluentResults.Result<Models.User.UserInfoModel> ret =
                new FluentResults.Result<Models.User.UserInfoModel>();

            var command = new
            {
                UserName = userName
            };

            try
            {
                ret = await ServiceCaller.PostDataWithValue<Models.User.UserInfoModel>("Users/User/GetByUserName", command);
                if (ret == null || ret.IsFailed)
                {
                    ret.WithValue(new Models.User.UserInfoModel());
                }

            }
            catch (Exception ex)
            {
                ret.WithValue(new Models.User.UserInfoModel());
                ret.WithSuccess(ex.Message);
            }

            return ret.Value;
        }


        
    }
}
