using BehsamFramework.Models;
using CustomerManagment.Domain.Entities;
using CustomerManagment.Domain.IRepository.CustomerInfo;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerManagment.Persistence.Repositories.CustomerInfo
{
    public class CustomerInfoQueryRepository :
        BehsamFramework.DapperDomain.QueryRepository<Domain.Entities.CustomerInfoTbl, long>,
        Domain.IRepository.CustomerInfo.ICustomerQueryRepository
    {
        protected internal CustomerInfoQueryRepository(IDbConnection _db) : base(_db)
        {
        }

        public async Task<CustomerInfoListModel> GetAllByPageingAndSearch(int pageNumber, int pageSize, string search)
        {

            //var query = "Select COUNT(Id) as CustomerCount  FROM dbo.CustomerInfoTbl ;";
            //var builder = new SqlBuilder();    
            //if (!string.IsNullOrEmpty(search))
            //{
            //    long mobile = 0;
            //    if (long.TryParse(search, out mobile))
            //    {
            //        builder.Where($"CustomerName like '%{search}%' or CustomerCode='{search}' or DefaultMobile={mobile}");
            //    }
            //    else
            //    {
            //        builder.Where($"CustomerName like '%{search}%' or CustomerCode='{search}' ");
            //    }

            //}

            //var qu=builder.AddTemplate("select * from dbo.CustomerInfoTbl /**where**/ order by Id OFFSET @PageNumer ROWS FETCH NEXT @PageSize ROWS ONLY");
            //query += qu.RawSql;

            //pageNumber = pageNumber - 1;
            //var param = new
            //{
            //    @PageNumer = pageNumber <= 0 ? 0 : pageNumber,
            //    @PageSize = pageSize
            //};


            var query = " exec [GetAllCustomerByPageingAndSearch] @Search,@PageNumber,@PageSize";
            var param = new
            {
                @Search= search,
                @PageNumber = pageNumber <= 0 ? 0 : pageNumber,
                @PageSize = pageSize
            };

            CustomerInfoListModel custList =new CustomerInfoListModel();
            custList.CustomerInfos = new List<CustomerInfoModel>();

            using (var list = await db.QueryMultipleAsync(query,param))
            {
                custList.RowCount = list.ReadFirst<long>();
                var temp= list.Read<CustomerInfoModel>().ToList();
                custList.CustomerInfos.AddRange(temp);
                
            }

            return custList;
        }

        public async Task<CustomerInfoTbl> GetCustomerByDefaultMobileAsync(long mobileNumber)
        {
            var query = "Select *  FROM dbo.CustomerInfoTbl where DefaultMobile=@mobile ;";

            var entity = await db.QueryFirstAsync<CustomerInfoTbl>(query, new { @mobile = mobileNumber });
            
            return entity;
        }

        public async Task<CustomerInfoModel> GetCustomerBySearch(string search)
        {
            
            
            //string param = "";

            //long mobile = 0;
            //if (long.TryParse(search, out mobile))
            //{
            //    param = $" or b.PhoneValue = {mobile} or a.DefaultMobile = {mobile}";
            //}


            //string query3= "SELECT distinct a.* " +
            //                 " FROM [dbo].[CustomerInfoTbl] a " +
            //                 " inner join " +
            //                 "     [dbo].[CustomerPhoneTbl] b " +
            //                 " on a.ID = b.CustomerID " +
            //                 " where  a.Status = 2 and " +
            //                $"        b.Status = 2 and b.PhoneValue = {mobile}";

            //string query1 = $"select a.* from [dbo].[CustomerInfoTbl] a  where a.DefaultMobile = {mobile} and a.Status=2";
            //string query2= $"select a.* from [dbo].[CustomerInfoTbl] a  where cast(a.CustomerCode as bigint) = {search.Trim()} and a.Status=2";

            //var entity = new CustomerInfoModel();
            //try
            //{
            //    entity = await db.QueryFirstAsync<CustomerInfoModel>(query1);
            //}catch(Exception  ex)
            //{

            //}
            //if(entity==null)
            //{
            //    try
            //    {
            //        entity = await db.QueryFirstAsync<CustomerInfoModel>(query2);
            //    }
            //    catch (Exception ex)
            //    {

            //    }
            //    if (entity == null)
            //    {
            //        entity = await db.QueryFirstAsync<CustomerInfoModel>(query3);
            //    }
            //}

            var query = "exec dbo.GetCustomerBySearch @Search";
            var param = new
            {
                @Search = search
            };

            var entity = await db.QueryFirstAsync<CustomerInfoModel>(query,param);

            return entity;


        }
    }
}