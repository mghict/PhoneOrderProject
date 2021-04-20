using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BehsamFramework.Util;
using BehsamFramework.Utility;

namespace WebSites.Panles.Mapper
{
    public class CustomerInfoModelProfile:AutoMapper.Profile
    {

        public CustomerInfoModelProfile() : base()
        {
            Mapping();
        }
        
        private void Mapping()
        {
            CreateMap<BehsamFramework.Models.CustomerInfoModel, Models.CustomerInfoModel>().ConvertUsing<CustomerInfoConverter>(); 
            CreateMap<Models.CustomerInfoModel, BehsamFramework.Models.CustomerInfoModel>();

            CreateMap<Models.CustomerInfoListModel, BehsamFramework.Models.CustomerInfoListModel>();
            CreateMap<BehsamFramework.Models.CustomerInfoListModel, Models.CustomerInfoListModel>();

            CreateMap<BehsamFramework.Models.CustomerInfoModel, Models.Customer.CustomerInfoModel>().ConvertUsing<ModelsCustomerCustomerInfoConverter>();
            CreateMap<Models.Customer.CustomerInfoModel, BehsamFramework.Models.CustomerInfoModel>();

            CreateMap<Models.Customer.CustomerInfoModel, Models.Customer.CustomerUpdateModel>();

            CreateMap<BehsamFramework.Models.CustomerPhoneModel, Models.CustomerPhone.CustomerPhoneModel>().ConvertUsing<Models_CustomerPhone_CustomerPhoneConverter>();
            CreateMap<Models.CustomerPhone.CustomerPhoneModel,BehsamFramework.Models.CustomerPhoneModel>();

            CreateMap<Models.CustomerPhone.CustomerPhoneModel, Models.CustomerPhone.CustomerPhoneUpdateModel> ();
            CreateMap<BehsamFramework.Models.CustomerPhoneModel, Models.CustomerPhone.CustomerPhoneUpdateModel>();

            CreateMap<BehsamFramework.Models.CustomerAddressModel, Models.CustomerAddress.CustomerAddressModel>().ConvertUsing<Models_CustomerAddress_CustomerAddressModelConverter>();
            CreateMap<Models.CustomerAddress.CustomerAddressModel, Models.CustomerAddress.CustomerAddressUpdateModel>();
        }
    }

    public class CustomerInfoConverter : ITypeConverter<BehsamFramework.Models.CustomerInfoModel, Models.CustomerInfoModel>
    {
        private Helper.StaticValues StaticValues;
        public CustomerInfoConverter(Helper.StaticValues staticValues)
        {
            StaticValues = staticValues;
        }
        public Models.CustomerInfoModel Convert(BehsamFramework.Models.CustomerInfoModel source, Models.CustomerInfoModel destination, ResolutionContext context)
        {
            destination = new Models.CustomerInfoModel();
            destination.CustomerCode = source.CustomerCode;
            destination.CustomerGroupId = source.CustomerGroupId;
            destination.CustomerGroupStr = StaticValues.CustomerListModel_Group.ValuesList.FirstOrDefault(p => p.Id == source.CustomerGroupId).Name;
            destination.CustomerName = source.CustomerName;
            destination.CustomerTypeId = source.CustomerTypeId;
            destination.CustomerTypeStr = StaticValues.CustomerListModel_Type.ValuesList.FirstOrDefault(p => p.Id == source.CustomerTypeId).Name;
            destination.Education = source.Education;
            destination.EducationStr = StaticValues.CustomerListModel_Education.ValuesList.FirstOrDefault(p => p.Id == source.Education).Name;
            destination.Id = source.Id;
            destination.Job = source.Job;
            destination.JobStr = StaticValues.CustomerListModel_Job.ValuesList.FirstOrDefault(p => p.Id == source.Job).Name;
            destination.RegisterDate = source.RegisterDate;
            destination.RegisterDateStr = source.RegisterDate.ToPersianDate();
            destination.RegisterTypeId = source.RegisterTypeId;
            destination.RegisterTypeStr = StaticValues.CustomerListModel_RegisterType.ValuesList.FirstOrDefault(p => p.Id == source.RegisterTypeId).Name;
            destination.Score = source.Score;
            destination.Sex = source.Sex;
            destination.SexStr = StaticValues.CustomerListModel_Sex.ValuesList.FirstOrDefault(p => p.Id == source.Sex).Name;
            destination.Status = source.Status;
            destination.StatusStr = StaticValues.GetStatuses.FirstOrDefault(p => p.StatusId == source.Status && p.Subject.ToLower().Equals("CustomerStatus".ToLower())).Name?? "نامشخص" ;
            destination.WaletPrice = source.WaletPrice;
            destination.DefaultMobile = source.DefaultMobile.ToString("00000000000");

            return destination;
        }
    }

    public class ModelsCustomerCustomerInfoConverter : ITypeConverter<BehsamFramework.Models.CustomerInfoModel, Models.Customer.CustomerInfoModel>
    {
        private Helper.StaticValues StaticValues;
        public ModelsCustomerCustomerInfoConverter(Helper.StaticValues staticValues)
        {
            StaticValues = staticValues;
        }
        public Models.Customer.CustomerInfoModel Convert(BehsamFramework.Models.CustomerInfoModel source, Models.Customer.CustomerInfoModel destination, ResolutionContext context)
        {
            destination = new Models.Customer.CustomerInfoModel();
            destination.CustomerCode = source.CustomerCode;
            destination.CustomerGroupId = source.CustomerGroupId;
            destination.CustomerGroupStr = StaticValues.CustomerListModel_Group.ValuesList.FirstOrDefault(p => p.Id == source.CustomerGroupId).Name;
            destination.CustomerName = source.CustomerName;
            destination.CustomerTypeId = source.CustomerTypeId;
            destination.CustomerTypeStr = StaticValues.CustomerListModel_Type.ValuesList.FirstOrDefault(p => p.Id == source.CustomerTypeId).Name;
            destination.Education = source.Education;
            destination.EducationStr = StaticValues.CustomerListModel_Education.ValuesList.FirstOrDefault(p => p.Id == source.Education).Name;
            destination.Id = source.Id;
            destination.Job = source.Job;
            destination.JobStr = StaticValues.CustomerListModel_Job.ValuesList.FirstOrDefault(p => p.Id == source.Job).Name;
            destination.RegisterDate = source.RegisterDate;
            destination.RegisterDateStr = source.RegisterDate.ToPersianDate();
            destination.RegisterTypeId = source.RegisterTypeId;
            destination.RegisterTypeStr = StaticValues.CustomerListModel_RegisterType.ValuesList.FirstOrDefault(p => p.Id == source.RegisterTypeId).Name;
            destination.Score = source.Score;
            destination.Sex = source.Sex;
            destination.SexStr = StaticValues.CustomerListModel_Sex.ValuesList.FirstOrDefault(p => p.Id == source.Sex).Name;
            destination.Status = source.Status;
            destination.StatusStr = StaticValues.GetStatuses.FirstOrDefault(p => p.StatusId == source.Status && p.Subject.ToLower().Equals("CustomerStatus".ToLower())).Name ?? "نامشخص";
            destination.WaletPrice = source.WaletPrice;
            destination.DefaultMobile = source.DefaultMobile.ToString("00000000000");

            return destination;
        }
    }

    public class Models_CustomerPhone_CustomerPhoneConverter : ITypeConverter<BehsamFramework.Models.CustomerPhoneModel, Models.CustomerPhone.CustomerPhoneModel>
    {
        private Helper.StaticValues StaticValues;
        public Models_CustomerPhone_CustomerPhoneConverter(Helper.StaticValues staticValues)
        {
            StaticValues = staticValues;
        }
        public Models.CustomerPhone.CustomerPhoneModel Convert(BehsamFramework.Models.CustomerPhoneModel source, Models.CustomerPhone.CustomerPhoneModel destination, ResolutionContext context)
        {
            destination = new Models.CustomerPhone.CustomerPhoneModel();
            destination.CustomerId = source.CustomerId;
            destination.Id = source.Id;
            destination.PhoneType = source.PhoneType;
            destination.PhoneTypeStr = StaticValues.GetStatuses.FirstOrDefault(p => p.StatusId == source.PhoneType && p.Subject.ToLower().Equals("CustomerPhoneType".ToLower())).Name ?? "نامشخص";
            destination.PhoneValue = source.PhoneValue  ;
            destination.PhoneValueStr = source.PhoneValue.ToString("00000000000");
            destination.Status = source.Status;
            destination.StatusStr = StaticValues.GetStatuses.FirstOrDefault(p => p.StatusId == source.Status && p.Subject.ToLower().Equals("CustomerPhoneStatus".ToLower())).Name ?? "نامشخص";

            return destination;
        }
    }

    public class Models_CustomerAddress_CustomerAddressModelConverter : ITypeConverter<BehsamFramework.Models.CustomerAddressModel, Models.CustomerAddress.CustomerAddressModel>
    {
        private Helper.StaticValues StaticValues;
        public Models_CustomerAddress_CustomerAddressModelConverter(Helper.StaticValues staticValues)
        {
            StaticValues = staticValues;
        }
        public Models.CustomerAddress.CustomerAddressModel Convert(BehsamFramework.Models.CustomerAddressModel source, Models.CustomerAddress.CustomerAddressModel destination, ResolutionContext context)
        {
            destination = new Models.CustomerAddress.CustomerAddressModel();
            destination.CustomerId = source.CustomerId;
            destination.Id = source.Id;
            destination.AddressType = source.AddressType;
            destination.AddressTypeStr = StaticValues.GetStatuses.FirstOrDefault(p => p.StatusId == source.AddressType && p.Subject.ToLower().Equals("CustomerAddressType".ToLower())).Name ?? "نامشخص";
            destination.AddressValue = source.AddressValue;
            destination.AreaId = source.AreaId;
            destination.AreaName = source.AreaName;
            destination.Latitude = source.Latitude;
            destination.Longitude = source.Longitude;
            destination.Status = source.Status;
            destination.StatusStr = StaticValues.GetStatuses.FirstOrDefault(p => p.StatusId == source.Status && p.Subject.ToLower().Equals("CustomerAddressStatus".ToLower())).Name ?? "نامشخص";
            
            return destination;
        }
    }
}
