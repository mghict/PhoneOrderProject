using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SettingManagment.Application.StoreShippingFeature
{
    public class MappingProfile:AutoMapper.Profile
    {
        public MappingProfile()
        {
            
            CreateMap<Domain.Entities.StoreShippingTbl, Commands.CreateStoreShippingCommand>();
            CreateMap<Commands.CreateStoreShippingCommand, Domain.Entities.StoreShippingTbl>();

            CreateMap<Domain.Entities.StoreShippingTbl, Commands.UpdateStoreShippingCommand>();
            CreateMap<Commands.UpdateStoreShippingCommand, Domain.Entities.StoreShippingTbl>();


            CreateMap<Domain.Entities.StoreShippingAreaTbl, Commands.CreateStoreShippingAreaCommand>();
            CreateMap<Commands.CreateStoreShippingAreaCommand, Domain.Entities.StoreShippingAreaTbl>();

            CreateMap<Domain.Entities.StoreShippingAreaTbl, Commands.UpdateStoreShippingAreaCommand>();
            CreateMap<Commands.UpdateStoreShippingAreaCommand, Domain.Entities.StoreShippingAreaTbl>();
        }
    }
}
