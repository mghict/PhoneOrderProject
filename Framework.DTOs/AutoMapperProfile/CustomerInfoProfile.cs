namespace DTOs.AutoMapperProfile
{
    public class CustomerInfoProfile :AutoMapper.Profile
    {
        public CustomerInfoProfile() : base()
        {
            CreateMap<Input.CustomerDto.AddDto, Models.CustomerInfoTbl>()
                .ForMember(dest => dest.RegisterDate, opt => opt.MapFrom(src => System.DateTime.Now))
                .ForMember(dest => dest.RegisterTime, opt => opt.MapFrom(src => System.DateTime.Now.TimeOfDay))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => 1));

            CreateMap<Input.CustomerDto.EditDto, Models.CustomerInfoTbl>();
            CreateMap<Models.CustomerInfoTbl, Results.CustomerInfo.EntityDto>();

        }
    }
}
