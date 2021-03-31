using DTOs.Base;
using Models;
using System.Linq;
using System.Threading.Tasks;

namespace Data
{
    public class CustomerAttributeItemRepository : Repository<Models.CustomerAttributeItemTbl>, ICustomerAttributeItemRepository
    {
        internal CustomerAttributeItemRepository(DatabaseContext databaseContext) : base(databaseContext)
        {
        }

        public GetEnumerableEntity<CustomerAttributeItemTbl> GetByCustomer(long custId)
        {
            var result = DbSet.Where(p => p.CustomerId == custId);
            return new GetEnumerableEntity<CustomerAttributeItemTbl>()
            {
                RowsCount=result.Count(),
                Data=result.AsEnumerable()
            };
        }

        public DTOs.Base.GetEnumerableEntity<CustomerAttributeItemTbl> GetByCustomerAndAttribute(long custId, int attrId)
        {
            var entity= DbSet.Where(p => p.CustomerId == custId && p.AttributeId==attrId);
            return new GetEnumerableEntity<CustomerAttributeItemTbl>
            {
                RowsCount = entity.Count(),
                Data = entity.AsEnumerable()
            };
        }

        public async Task<DTOs.Base.GetEnumerableEntity<CustomerAttributeItemTbl>> GetByCustomerAndAttributeAsync(long custId, int attrId)
        {
            return await Task.Run(() =>
            {
                var entity = DbSet.Where(p => p.CustomerId == custId && p.AttributeId == attrId);
                return new GetEnumerableEntity<CustomerAttributeItemTbl>
                {
                    RowsCount = entity.Count(),
                    Data = entity.AsEnumerable()
                };

            });
        }

        public async Task<GetEnumerableEntity<CustomerAttributeItemTbl>> GetByCustomerAsync(long custId)
        {
            return await Task.Run(() =>
            {
                var result = DbSet.Where(p => p.CustomerId == custId );
                return new GetEnumerableEntity<CustomerAttributeItemTbl>()
                {
                    RowsCount = result.Count(),
                    Data = result.AsEnumerable()
                };
            });
        }

        public CustomerAttributeItemTbl GetById(long id)
        {
            return DbSet.Find(id);
        }

        public async Task<CustomerAttributeItemTbl> GetByIdAsync(long id)
        {
            return await DbSet.FindAsync(id);
        }
    }
}
