﻿using System.Data;
using System.Threading.Tasks;
using Dapper;

namespace StoreManagment.Persistence.Repositories
{
    public class OrderItemsRepository :
        BehsamFramework.DapperDomain.Repository<Domain.Entities.OrderItems, long>,
        Domain.IRepositories.IOrderItemsRepository
    {
        protected internal OrderItemsRepository(IDbConnection _db) : base(_db)
        {
        }

        public async Task<bool> ChangeOrderItemStatusAsync(long id, int status)
        {
            var query = "update [dbo].[CustomerPreOrderItemsTbl] set Status=@Status where ID=@Id";

            var param = new
            {
                @Id = id,
                @Status = status
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

        public async Task<bool> ReplaceProductItemAsync(long orginalId, int replaceId,int count)
        {

            try
            {
                var query = "exec [dbo].[OrderItemReplaceProduct] @OrginalId,@ProductId,@Quantity";

                var param = new
                {
                    @OrginalId=orginalId,
                    @ProductId= replaceId,
                    @Quantity= count
                };

                var item = await db.QueryFirstAsync<bool>(query, param);

                return item;
            }
            catch
            {
                return false;
            }
        }
    }
}
