using Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Data
{
    public class CustomerInfoRepository : Repository<Models.CustomerInfoTbl>, ICustomerInfoRepository
    {
        internal CustomerInfoRepository(DatabaseContext databaseContext) : base(databaseContext)
        {
        }

        public override void Update(CustomerInfoTbl entity)
        {
            var oldCust = DbSet.Find(entity.Id);
            if(oldCust==null)
            {
                return;
            }

            oldCust.CustomerName = entity.CustomerName;
            oldCust.CustomerCode = entity.CustomerCode;
            oldCust.CustomerGroupId = entity.CustomerGroupId;
            oldCust.CustomerTypeId = entity.CustomerTypeId;
            oldCust.RegisterTypeId = entity.RegisterTypeId;
            oldCust.Status = entity.Status;

            base.Update(oldCust);
        }

        public override async Task UpdateAsync(CustomerInfoTbl entity)
        {

            var oldCust =await DbSet.FindAsync(entity.Id);
            if (oldCust != null)
            {
                oldCust.CustomerName = entity.CustomerName;
                oldCust.CustomerCode = entity.CustomerCode;
                oldCust.CustomerGroupId = entity.CustomerGroupId;
                oldCust.CustomerTypeId = entity.CustomerTypeId;
                oldCust.RegisterTypeId = entity.RegisterTypeId;
                oldCust.Status = entity.Status;

                await base.UpdateAsync(entity);
            }

            
        }

        public void DecreaseScore(CustomerInfoTbl entity, int score)
        {
            entity.Score -= score;
            if (entity.Score <= 0)
                entity.Score = 0;

            base.Update(entity);
        }

        public async Task DecreaseScoreAsync(CustomerInfoTbl entity, int score)
        {
            entity.Score -= score;
            if (entity.Score <= 0)
                entity.Score = 0;

            await base.UpdateAsync(entity);
        }

        public CustomerInfoTbl GetById(long id)
        {
            var result = DbSet.Find(id);
            return result;
        }

        public async Task<CustomerInfoTbl> GetByIdAsync(long id)
        {
            var result = DbSet.FindAsync(id);
            return await result;
        }

        public void IncreaseScore(CustomerInfoTbl entity, int score)
        {
            entity.Score += score;
            base.Update(entity);
        }

        public async Task IncreaseScoreAsync(CustomerInfoTbl entity, int score)
        {
            entity.Score += score;
            await base.UpdateAsync(entity);
        }

        public void IncreaseScore(long Id, int score)
        {
            var entity = DbSet.Find(Id);
            if(entity!=null)
            {
                entity.Score += score;
                base.Update(entity);
            }
        }

        public async Task IncreaseScoreAsync(long Id, int score)
        {
            var entity = DbSet.Find(Id);
            if (entity != null)
            {
                entity.Score += score;
                await base.UpdateAsync(entity);
            }
        }

        public void DecreaseScore(long Id, int score)
        {
            var entity = DbSet.Find(Id);
            if (entity != null)
            {
                entity.Score -= score;
                entity.Score=entity.Score <= 0 ? 0 : entity.Score;
                base.Update(entity);
            }
        }

        public async Task DecreaseScoreAsync(long Id, int score)
        {
            var entity = DbSet.Find(Id);
            if (entity != null)
            {
                entity.Score -= score;
                entity.Score = entity.Score <= 0 ? 0 : entity.Score;
                await base.UpdateAsync(entity);
            }
        }

        public CustomerInfoTbl GetByCustomerCode(string code)
        {
            var entity = DbSet.FirstOrDefault(current => current.CustomerCode.Trim().ToLower().Equals(code.Trim().ToLower()));
            return entity;
        }

        public async Task<CustomerInfoTbl> GetByCustomerCodeAsync(string code)
        {
            CustomerInfoTbl entity = new CustomerInfoTbl();
            await Task.Run(() =>
            {
                entity=DbSet.FirstOrDefault(current => current.CustomerCode.Trim().ToLower().Equals(code.Trim().ToLower()));
            });

            return entity;
        }

       
    }
}
