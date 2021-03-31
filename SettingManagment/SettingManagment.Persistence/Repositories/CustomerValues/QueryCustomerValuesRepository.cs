using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using SettingManagment.Domain.Entities;

namespace SettingManagment.Persistence.Repositories.CustomerValues
{
    public class QueryCustomerValuesRepository:
        BehsamFramework.DapperDomain.QueryRepository<Domain.Entities.CustomerAttribute,int>,
        Domain.IRepositories.IQueryCustomerValuesRepository
    {
        protected internal QueryCustomerValuesRepository(IDbConnection _db) : base(_db)
        {
        }

        public async Task<CustomerAttribute> GetCustomerAttributeByIdAsync(int attributeId)
        {
            var query = "SELECT [Id],[Name] ,[IsMandetory],[SName] FROM [dbo].[AttributeCategoryDetailTbl] a where a.[AttributeCategoryId]=1 and a.id=@Id and status=1; "+
                        "SELECT [Id],[Name],[IsDefault],[AttributeCategoryDetailId] FROM [dbo].[AttributeCategoryDetailInfoTbl] a where a.[AttributeCategoryDetailId]=@Id and status=1";
           
            var param = new
            {
                @Id = attributeId
            };

            CustomerAttribute customerAttribute;

            using(var list=await db.QueryMultipleAsync(query,param))
            {
                customerAttribute = list.Read<CustomerAttribute>().ToList().FirstOrDefault();
                customerAttribute.ValuesList = list.Read<CustomerAttributeValues>().ToList();
            }

            return customerAttribute;
        }
    }
}
