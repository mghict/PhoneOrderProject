using StoreManagment.Domain.Entities;
using System.Data;
using System.Threading.Tasks;
using Dapper;
using System;

namespace StoreManagment.Persistence.Repositories
{
    public class OrderUserActivityRepository :
        BehsamFramework.DapperDomain.Repository<Domain.Entities.CustomerPreOrderUserActive, long>,
        Domain.IRepositories.IOrderUserActiveRepository
    {
        protected internal OrderUserActivityRepository(IDbConnection _db) : base(_db)
        {
        }

        public override async Task<bool> DeleteAsync(CustomerPreOrderUserActive entity)
        {

            entity.CreateDate = System.DateTime.Now;

            var query = "Delete from CustomerPreOrderUserActive where UserId=@UserId and OrderCode=@OrderCode";
            var param = new
            {
                @UserId = entity.UserId,
                @OrderCode = entity.OrderCode
            };

            try
            {
                var result = await db.ExecuteAsync(query, param);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public override async Task<CustomerPreOrderUserActive> InsertAsync(CustomerPreOrderUserActive entity)
        {
            entity.CreateDate = System.DateTime.Now;
            return (await base.InsertAsync(entity));
        }

        public override async Task<bool> UpdateAsync(CustomerPreOrderUserActive obj)
        {
            obj.CreateDate = System.DateTime.Now;

            //var query = "Update CustomerPreOrderUserActive set Status=@Status, CreateDate=@CreateDate where UserId=@UserId and OrderCode=@OrderCode";
            var query = "select max(id) id from CustomerPreOrderUserActive where OrderCode=@OrderCode";
            var paramId = new
            {
                @OrderCode = obj.OrderCode
            };

            try
            {
                var id = await db.QueryFirstAsync<long>(query, paramId);
                if(id<=0)
                {
                    return false;
                }

                query = "Update CustomerPreOrderUserActive set Status=@Status, CreateDate=@CreateDate where Id=@Id";
                var param = new
                {
                    @Status = obj.Status,
                    @CreateDate = obj.CreateDate,
                    @Id=id
                };


                var result = await db.ExecuteAsync(query, param);
                return true;

            }
            catch(Exception ex)
            {
                return false;
            }

            
        }
    }
}
