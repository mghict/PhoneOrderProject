using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace WebSite.JourChin.Helper
{
    public class TokenCachClass
    {
        public static CancellationTokenSource UserActivity = new CancellationTokenSource();
    }
}
