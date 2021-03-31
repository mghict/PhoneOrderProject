using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataDapper
{
    public interface IUnitOfWork:Base.IUnitOfWork
    {
        //Facad Of Repository

        Repositories.AreaInfo.IAreaInfoRepository AreaInfoRepository { get; }
        Repositories.AreaGeo.IAreaGeoRepository AreaGeoRepository { get; }
        Repositories.CityInfo.ICityInfoRepository CityInfoRepository { get; }
        Repositories.Province.IProvinceRepository ProvinceRepository { get; }

        //--------------------------------------
        //--------------------------------------

        Repositories.CustomerAddress.ICustomerAddressRepository CustomerAddressRepository { get; }
        Repositories.CustomerAttribute.ICustomerAttributeRepository CustomerAttributeRepository { get; }
        Repositories.CustomerAttributeItem.ICustomerAttributeItemRepository CustomerAttributeItemRepository { get; }
        Repositories.CustomerInfo.ICustomerRepository CustomerRepository { get; }
        Repositories.CustomerPhone.ICustomerPhoneRepository CustomerPhoneRepository { get; }

        //--------------------------------------
        //--------------------------------------

        Repositories.CategoryInfo.ICategoryRepository CategoryRepository { get; }
        Repositories.Product.IProductRepository ProductRepository { get; }
        Repositories.StoreArea.IStoreAreaRepository StoreAreaRepository { get; }
        Repositories.StoreInfo.IStoreRepository StoreRepository { get; }
        Repositories.StoreProduct.IStoreProductRepository StoreProductRepository { get; }
        Repositories.StoreCustomeTimeSheet.IStoreCustomeTimeSheetRepository StoreCustomeTimeSheetRepository { get; }
        Repositories.StoreTimeSheet.IStoreTimeSheetRepository StoreTimeSheetRepository { get; }
        Repositories.StoreInActive.IStoreInActiveRepository StoreInActiveRepository { get; }

        //--------------------------------------------------------------

        Repositories.UserInfo.IUserRepository UserRepository { get; }
        Repositories.RoleInfo.IRoleRepository RoleRepository { get; }
        Repositories.UserRole.IUserRoleRepository UserRoleRepository { get; }
        Repositories.UserGeoTrack.IUserGeoRepository UserGeoRepository { get; }

    }
}
