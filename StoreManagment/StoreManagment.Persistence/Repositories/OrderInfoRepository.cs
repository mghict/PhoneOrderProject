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

        public async Task RegisterOrderAsync(OrderInfo entity)
        {

           

            db.Open();

            var isoLevel = System.Data.IsolationLevel.Serializable;
            using (var transaction = db.BeginTransaction(isoLevel))
            {
                try
                {
                    var effect =db.Insert(entity, transaction);

                    entity.Detail.OrderId = effect;


                    foreach (var item in entity.Items)
                    {
                        item.OrderId = effect;
                    }

                    var items = entity.Items;
                    var detail = entity.Detail;

                    var detailEffect = db.Insert(detail,transaction);
                    var itemEffect = await db.InsertAsync(items,transaction);
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
    }
}
