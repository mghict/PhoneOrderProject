using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreManagment.Application.OrderInfoFeature
{
    public class MapperProfile:AutoMapper.Profile
    {
        public MapperProfile():base()
        {
            CreateMap<Commands.CreateOrderItemsReserveCommand,Domain.Entities.OrderItemsReserve>()
                .ForMember(dest=>dest.Status,opt=>opt.MapFrom(src=>true));
            CreateMap<Domain.Entities.OrderItemsReserve,Commands.CreateOrderItemsReserveCommand>();


            CreateMap<Commands.UpdateOrderItemsReserveCommand, Domain.Entities.OrderItemsReserve>();
            CreateMap<Domain.Entities.OrderItemsReserve, Commands.UpdateOrderItemsReserveCommand>();
        }
    }
}
