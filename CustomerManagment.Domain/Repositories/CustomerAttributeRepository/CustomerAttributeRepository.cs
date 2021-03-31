using DTOs.Base;
using Models;
using System.Linq;
using System.Threading.Tasks;

namespace Data
{
    internal class CustomerAttributeRepository : Repository<Models.CustomerAttributeTbl>, ICustomerAttributeRepository
    {
        internal CustomerAttributeRepository(DatabaseContext databaseContext) : base(databaseContext)
        {
        }

        public GetEnumerableEntity<CustomerAttributeTbl> GetByAttributeId(int id)
        {
            var entity= DbSet.Where(p => p.AttributeId == id);
            return new GetEnumerableEntity<CustomerAttributeTbl>()
            {
                RowsCount = entity.Count(),
                Data = entity.AsEnumerable()
            };
        }

        public GetEnumerableEntity<CustomerAttributeTbl> GetByAttributeId(int id, bool IsSortedByPriority)
        {
            var entity = DbSet.Where(p => p.AttributeId == id);
            if(IsSortedByPriority)
            {
                entity = entity.OrderBy(p => p.Priority);
            }
            return new GetEnumerableEntity<CustomerAttributeTbl>()
            {
                RowsCount = entity.Count(),
                Data = entity.AsEnumerable()
            };
        }

        public GetEnumerableEntity<CustomerAttributeTbl> GetByAttributeId(int id, bool IsSortedByPriority, byte status)
        {
            var entity = DbSet.Where(p => p.AttributeId == id && p.Status==status);

            if (IsSortedByPriority)
            {
                entity = entity.OrderBy(p => p.Priority);
            }

            return new GetEnumerableEntity<CustomerAttributeTbl>()
            {
                RowsCount = entity.Count(),
                Data = entity.AsEnumerable()
            };
        }

        public async Task<GetEnumerableEntity<CustomerAttributeTbl>> GetByAttributeIdAsync(int id)
        {
            return await Task.Run(() =>
            {
                var entity = DbSet.Where(p => p.AttributeId == id);
                return new GetEnumerableEntity<CustomerAttributeTbl>()
                {
                    RowsCount = entity.Count(),
                    Data = entity.AsEnumerable()
                };
            });
        }

        public async Task<GetEnumerableEntity<CustomerAttributeTbl>> GetByAttributeIdAsync(int id, bool IsSortedByPriority)
        {
            return await Task.Run(() =>
            {
                var entity = DbSet.Where(p => p.AttributeId == id);

                if(IsSortedByPriority)
                {
                    entity = entity.OrderBy(p => p.Priority);
                }

                return new GetEnumerableEntity<CustomerAttributeTbl>()
                {
                    RowsCount = entity.Count(),
                    Data = entity.AsEnumerable()
                };
            });
        }

        public async Task<GetEnumerableEntity<CustomerAttributeTbl>> GetByAttributeIdAsync(int id, bool IsSortedByPriority, byte status)
        {
            return await Task.Run(() =>
            {
                var entity = DbSet.Where(p => p.AttributeId == id && p.Status==status);

                if (IsSortedByPriority)
                {
                    entity = entity.OrderBy(p => p.Priority);
                }

                return new GetEnumerableEntity<CustomerAttributeTbl>()
                {
                    RowsCount = entity.Count(),
                    Data = entity.AsEnumerable()
                };
            });
        }

        public CustomerAttributeTbl GetById(int id)
        {
            return DbSet.Find(id);
        }

        public async Task<CustomerAttributeTbl> GetByIdAsync(int id)
        {
            return await DbSet.FindAsync(id);
        }
    }
}
