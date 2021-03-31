using System.Data;

namespace DataDapper.Repositories.UserGeoTrack
{
    public class UserGeoRepository : Repository<Models.UserGeoTrackTbl, int>, IUserGeoRepository
    {
        internal UserGeoRepository(IDbConnection idbConnection) : base(idbConnection)
        {
        }
    }
}
