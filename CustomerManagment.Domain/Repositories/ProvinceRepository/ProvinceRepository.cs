namespace Data
{
    public class ProvinceRepository : Base.Repository<Models.ProvinceTbl>, IProvinceRepository
    {
        internal ProvinceRepository(DatabaseContext databaseContext) : base(databaseContext)
        {
        }
    }
}
