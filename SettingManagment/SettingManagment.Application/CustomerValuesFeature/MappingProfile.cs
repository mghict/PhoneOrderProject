using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SettingManagment.Application.CustomerValuesFeature
{
    public class MappingProfile:AutoMapper.Profile
    {
        public MappingProfile()
        {
 
            CreateMap<BehsamFramework.Models.StoreOrderModel, Domain.Entities.Stores>();
            CreateMap<Domain.Entities.Stores, BehsamFramework.Models.StoreOrderModel>();


            CreateMap<Domain.Entities.CategoryInfoTbl, BehsamFramework.Models.CategoryShowModel>();
            CreateMap<BehsamFramework.Models.CategoryShowModel,Domain.Entities.CategoryInfoTbl>();

            CreateMap<Domain.Entities.ProductInfoTbl, BehsamFramework.Models.ProductShowModel>();
            CreateMap<BehsamFramework.Models.ProductShowModel,Domain.Entities.ProductInfoTbl>();
        }
    }
}
