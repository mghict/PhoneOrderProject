using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data
{
    public interface ICustomerInfoRepository : Base.IRepository<Models.CustomerInfoTbl>
    {
       void IncreaseScore(Models.CustomerInfoTbl entity, int score);
        Task IncreaseScoreAsync(Models.CustomerInfoTbl entity, int score);

        void IncreaseScore(long Id, int score);
        Task IncreaseScoreAsync(long Id, int score);

        void DecreaseScore(Models.CustomerInfoTbl entity, int score);
        Task DecreaseScoreAsync(Models.CustomerInfoTbl entity, int score);

        void DecreaseScore(long Id, int score);
        Task DecreaseScoreAsync(long Id, int score);

        Models.CustomerInfoTbl GetById(long id);
        Task <Models.CustomerInfoTbl> GetByIdAsync(long id);

        Models.CustomerInfoTbl GetByCustomerCode(string code);
        Task<Models.CustomerInfoTbl> GetByCustomerCodeAsync(string code);

    }
}
