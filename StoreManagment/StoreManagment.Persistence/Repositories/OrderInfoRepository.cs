using StoreManagment.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Dapper.Contrib;
using Dapper.Contrib.Extensions;
using System.Transactions;

namespace StoreManagment.Persistence.Repositories
{
    public class OrderInfoRepository :
        BehsamFramework.DapperDomain.Repository<Domain.Entities.OrderInfo, long>,
        Domain.IRepositories.IOrderInfoRepository
    {
        protected internal OrderInfoRepository(IDbConnection _db) : base(_db)
        {
        }

        public async Task<bool> ChangeOrderStatus(long orderCode, byte status, string reason)
        {
            var query = "exec dbo.OrderChangeStatus @OrderCode,@Status,@Reason";
            var param = new
            {
                @OrderCode = orderCode,
                @Status = status,
                @Reason = reason
            };

            bool response = false;

            try
            {
                await db.ExecuteAsync(query, param);
                response = true;
            }
            catch (Exception ex)
            {
                response = false;
            }

            return response;
        }

        public async Task RegisterOrderAsync(OrderInfo entity)
        {
            db.Open();

            var isoLevel = System.Data.IsolationLevel.Serializable;
            using (var transaction = db.BeginTransaction(isoLevel))
            {
                try
                {
                    var effect = db.Insert(entity, transaction);

                    entity.Detail.OrderId = effect;


                    foreach (var item in entity.Items)
                    {
                        item.OrderId = effect;
                    }

                    var items = entity.Items;
                    var detail = entity.Detail;

                    var detailEffect = db.Insert(detail, transaction);
                    var itemEffect = await db.InsertAsync(items, transaction);
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw new Exception("عدم امکان درج اطلاعات");
                }

            }

            return;
        }

        public async Task UpdateOrderAsync(OrderInfo entity)
        {
            db.Open();

            var isoLevel = System.Data.IsolationLevel.Serializable;
            using (var transaction = db.BeginTransaction(isoLevel))
            {

                try
                {
                    var query = "Delete from CustomerPreOrderItemsTbl where OrderID=@OrderID";
                    var param = new
                    {
                        @OrderID = entity.Id
                    };

                    var res = await db.ExecuteAsync(query, param,transaction);

                    //-----------------------------------------
                    //-----------------------------------------
                    
                    await db.UpdateAsync(entity, transaction);

                    //-----------------------------------------
                    //-----------------------------------------

                    foreach (var item in entity.Items)
                    {
                        item.OrderId = entity.Id;
                    }

                    entity.Detail.OrderId = entity.Id;

                    var items = entity.Items;
                    var respIns = await db.InsertAsync(items,transaction);

                    transaction.Commit();

                    if (entity.OrderState==4)
                    {
                        long resultStatus =0;
                        query = "Select count(ID) from [dbo].[CustomerPreOrderItemsTbl] where OrderId=@OrderID and Status=3";
                        try
                        {
                            resultStatus =await db.QueryFirstAsync<long>(query, param);
                        }
                        catch(Exception ex)
                        {
                            resultStatus = -1;
                        }

                        if(resultStatus==0)
                        {
                            query = "update [dbo].[CustomerPreOrderInfoTbl] set OrderState=3 where ID=@OrderID ";
                            await db.ExecuteAsync(query, param);
                        }
                    }

                    
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw new Exception("عدم امکان درج اطلاعات" + Environment.NewLine + ex.Message);
                }

            }

            return;
        }

    }
}
