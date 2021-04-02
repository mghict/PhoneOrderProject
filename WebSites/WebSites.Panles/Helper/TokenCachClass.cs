using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace WebSites.Panles.Helper
{
    public class TokenCachClass
    {
        public static CancellationTokenSource CustomerList = new CancellationTokenSource();
        public static CancellationTokenSource CustomerPhonesAdd = new CancellationTokenSource();
        public static CancellationTokenSource CustomerAddressesAdd = new CancellationTokenSource();
        public static CancellationTokenSource AttributeStatusAdd = new CancellationTokenSource();
        public static CancellationTokenSource TimeSheetToken = new CancellationTokenSource();
        public static CancellationTokenSource CatgoryToken = new CancellationTokenSource();
        public static CancellationTokenSource CatgoryProductToken = new CancellationTokenSource();
        public static CancellationTokenSource CachedOrderToken = new CancellationTokenSource();
        public static CancellationTokenSource CachedMessageToken = new CancellationTokenSource();
    }
}
