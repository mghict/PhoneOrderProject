using BillManagement.Domain.Entities;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace BillManagement.Persistence.Repositories
{
    public class OrderRepository :
        BehsamFramework.DapperDomain.Repository<Domain.Entities.Order, long>,
        Domain.IRepositories.IOrderRepository
    {
        protected internal OrderRepository(IDbConnection _db) : base(_db)
        {
        }

        public async Task<bool> UpdateBill(OrderRequest order)
        {
            try
            {
                var query = "select ID from CustomerPreOrderInfoTbl where OrderState=11 and OrderCode=@OrderCode";
                var paramOrder = new
                {
                    @OrderCode = order.OrderCode
                };

                var orderId = await db.QueryFirstOrDefaultAsync<long>(query, paramOrder);

                int discountPrice = 0, taxPrice = 0, totalPrice = 0, finalPrice = 0;

                if (orderId > 0)
                {

                    db.Open();
                    var isoLevel = System.Data.IsolationLevel.Serializable;
                    using (var transaction = db.BeginTransaction(isoLevel))
                    {
                        foreach (var item in order.OrderItems)
                        {
                            query = "update CustomerPreOrderItemsTbl " +
                                   "set Status=@Status,Quantity=@Quantity,UnitPrice=@UnitPrice,TaxPrice=@TaxPrice,DiscountPrice=@DiscountPrice " +
                                   "where OrderID=@OrderID and ProductID=@ProductID";

                            var paramDetails = new
                            {
                                @Status = 5,
                                @Quantity = item.Quantity,
                                @UnitPrice = item.UnitPrice,
                                @TaxPrice = item.TaxPrice,
                                @DiscountPrice = item.DiscountPrice,
                                @OrderID = orderId,
                                @ProductID = item.ProductId
                            };

                            await db.ExecuteAsync(query, paramDetails, transaction);

                            discountPrice += item.DiscountPrice;
                            taxPrice += item.TaxPrice;
                            totalPrice += (item.Quantity * item.UnitPrice);
                        }

                        finalPrice += totalPrice + taxPrice - discountPrice;

                        query = "update CustomerPreOrderInfoTbl " +
                                "set OrderState=12 ,"+
                                    "TotalPrice=@TotalPrice ," +
                                    "DiscountPrice=@DiscountPrice ," +
                                    "TaxPrice=@TaxPrice ," +
                                    "FinalPrice=@FinalPrice+ShippingPrice" +
                                "where ID=@id";
                        var paramMaster = new
                        {
                            @id = orderId
                        };

                        await db.ExecuteAsync(query, paramMaster, transaction);

                        transaction.Commit();
                        return true;
                    }
                }
                else
                {
                    return false;
                }

            }
            catch
            {
                return false;
            }
        }
    }
}
