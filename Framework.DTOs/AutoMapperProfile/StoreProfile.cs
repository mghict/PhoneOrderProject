namespace DTOs.AutoMapperProfile
{
    public class StoreProfile : AutoMapper.Profile
    {
        public StoreProfile() : base()
        {
            CreateMap<DTOs.Input.Store.AddDto, Models.StoreInfoTbl>();
            CreateMap<Models.StoreInfoTbl, DTOs.Input.Store.AddDto>();


            CreateMap<DTOs.Input.Store.EditDto, Models.StoreInfoTbl>();
            CreateMap<Models.StoreInfoTbl, DTOs.Input.Store.EditDto>();

            CreateMap<DTOs.Results.Store.EntityDto, Models.StoreInfoTbl>();
            CreateMap<Models.StoreInfoTbl, DTOs.Results.Store.EntityDto>();
        }
    }
}
