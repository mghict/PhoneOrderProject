namespace Data
{
    public interface IUnitOfWork : Base.IUnitOfWork
    {
        // **********
        // Area
        // **********
        IAreaGeoRepository AreaGeoRepository { get; }
        IAreaInfoRepository AreaInfoRepository { get; }

        // **********
        // Customer
        // **********
        ICustomerInfoRepository CustomerInfoRepository { get; }
        ICustomerAddressRepository CustomerAddressRepository { get; }
        ICustomerAttributeItemRepository CustomerAttributeItemRepository { get; }
        ICustomerAttributeRepository CustomerAttributeRepository { get; }
        ICustomerPhoneRepository CustomerPhoneRepository { get; }

        // **********
        IUserInfoRepository UserInfoRepository { get; }
        // **********

        // **********
        IProvinceRepository ProvinceRepository { get; }
        // **********

    }
}
