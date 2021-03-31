using Models;
using DTOs.Base;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Data
{
    public class CustomerAddressRepository : Repository<Models.CustomerAddressTbl>, ICustomerAddressRepository
    {
        internal CustomerAddressRepository(DatabaseContext databaseContext) : base(databaseContext)
        {
        }

        public GetEnumerableEntity<CustomerAddressTbl> GetByAddressType(int addressType)
        {
            var result=DbSet.Where(p => p.AddressType == addressType);
            return new GetEnumerableEntity<CustomerAddressTbl>()
            {
                Data = result.AsEnumerable(),
                RowsCount = result.Count()
            };
        }

        public GetEnumerableEntity<CustomerAddressTbl> GetByAddressType(int addressType, int PageNo, int PageSize)
        {
            var result = DbSet.Where(p => p.AddressType == addressType);
            return new GetEnumerableEntity<CustomerAddressTbl>()
            {
                Data = result.ToPaged(PageNo,PageSize),
                RowsCount = result.Count()
            };
        }

        public async Task<GetEnumerableEntity<CustomerAddressTbl>> GetByAddressTypeAsync(int addressType)
        {
            return await Task.Run(()=>
            {
                var result = DbSet.Where(p => p.AddressType == addressType);
                return new GetEnumerableEntity<CustomerAddressTbl>()
                {
                    Data = result.AsEnumerable(),
                    RowsCount = result.Count()
                };
             });
        }

        public async Task<GetEnumerableEntity<CustomerAddressTbl>> GetByAddressTypeAsync(int addressType, int PageNo, int PageSize)
        {
            return await Task.Run(() =>
            {
                var result = DbSet.Where(p => p.AddressType == addressType);
                return new GetEnumerableEntity<CustomerAddressTbl>()
                {
                    Data = result.ToPaged(PageNo,PageSize),
                    RowsCount = result.Count()
                };
            });
        }

        public GetEnumerableEntity<CustomerAddressTbl> GetByCustomerId(long customerId)
        {

            var result = DbSet.Where(p => p.CustomerId == customerId);
            return new GetEnumerableEntity<CustomerAddressTbl>()
            {
                Data = result.AsEnumerable(),
                RowsCount = result.Count()
            };

        }

        public async Task<GetEnumerableEntity<CustomerAddressTbl>> GetByCustomerIdAsync(long customerId)
        {
            return await Task.Run(() =>
            {
                var result = DbSet.Where(p => p.CustomerId == customerId);
                return new GetEnumerableEntity<CustomerAddressTbl>()
                {
                    Data = result.AsEnumerable(),
                    RowsCount = result.Count()
                };
            });
        }

        public GetEnumerableEntity<CustomerAddressTbl> GetByCustomerIdWithAddressType(long customerId, int addressType)
        {
            var result = DbSet.Where(p => p.CustomerId == customerId && p.AddressType==addressType);
            return new GetEnumerableEntity<CustomerAddressTbl>()
            {
                Data = result.AsEnumerable(),
                RowsCount = result.Count()
            };
        }

        public GetEnumerableEntity<CustomerAddressTbl> GetByCustomerIdWithAddressType(long customerId, int addressType, int PageNo, int PageSize)
        {
            var result = DbSet.Where(p => p.CustomerId == customerId && p.AddressType == addressType);
            return new GetEnumerableEntity<CustomerAddressTbl>()
            {
                Data = result.ToPaged(PageNo,PageSize),
                RowsCount = result.Count()
            };
        }

        public async Task<GetEnumerableEntity<CustomerAddressTbl>> GetByCustomerIdWithAddressTypeAsync(long customerId, int addressType)
        {
            return await Task.Run(() =>
            {
                var result = DbSet.Where(p => p.CustomerId == customerId && p.AddressType == addressType);
                return new GetEnumerableEntity<CustomerAddressTbl>()
                {
                    Data = result.AsEnumerable(),
                    RowsCount = result.Count()
                };
            });
        }

        public async Task<GetEnumerableEntity<CustomerAddressTbl>> GetByCustomerIdWithAddressTypeAsync(long customerId, int addressType, int PageNo, int PageSize)
        {
            return await Task.Run(() =>
            {
                var result = DbSet.Where(p => p.CustomerId == customerId && p.AddressType == addressType);
                return new GetEnumerableEntity<CustomerAddressTbl>()
                {
                    Data =result.ToPaged(PageNo,PageSize),
                    RowsCount = result.Count()
                };
            });
        }

        public GetEnumerableEntity<CustomerAddressTbl> GetByCustomerIdWithAreaId(long customerId, int areaId)
        {
            var result = DbSet.Where(p => p.CustomerId == customerId && p.AreaId == areaId);
            return new GetEnumerableEntity<CustomerAddressTbl>()
            {
                Data = result.AsEnumerable(),
                RowsCount = result.Count()
            };
        }

        public GetEnumerableEntity<CustomerAddressTbl> GetByCustomerIdWithAreaId(long customerId, int areaId, int PageNo, int PageSize)
        {
            var result = DbSet.Where(p => p.CustomerId == customerId && p.AreaId == areaId);
            return new GetEnumerableEntity<CustomerAddressTbl>()
            {
                Data = result.ToPaged(PageNo,PageSize),
                RowsCount = result.Count()
            };
        }

        public async Task<GetEnumerableEntity<CustomerAddressTbl>> GetByCustomerIdWithAreaIdAsync(long customerId, int areaId)
        {
            return await Task.Run(()=>
                {
                    var result = DbSet.Where(p => p.CustomerId == customerId && p.AreaId == areaId);
                    return new GetEnumerableEntity<CustomerAddressTbl>()
                    {
                        Data = result.AsEnumerable(),
                        RowsCount = result.Count()
                    };
                });
        }

        public async Task<GetEnumerableEntity<CustomerAddressTbl>> GetByCustomerIdWithAreaIdAsync(long customerId, int areaId, int PageNo, int PageSize)
        {
            return await Task.Run(() =>
            {
                var result = DbSet.Where(p => p.CustomerId == customerId && p.AreaId == areaId);
                return new GetEnumerableEntity<CustomerAddressTbl>()
                {
                    Data = result.ToPaged(PageNo, PageSize),
                    RowsCount = result.Count()
                };
            });
        }

        public CustomerAddressTbl GetById(long Id)
        {
            return DbSet.Find(Id);
        }

        public async Task<CustomerAddressTbl> GetByIdAsync(long Id)
        {
            return await DbSet.FindAsync(Id);
        }
    }
}
