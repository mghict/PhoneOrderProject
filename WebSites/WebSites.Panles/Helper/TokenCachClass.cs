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
        public static CancellationTokenSource StoreToken = new CancellationTokenSource();
        public static CancellationTokenSource InActiveToken = new CancellationTokenSource();
        public static CancellationTokenSource StoreInActiveToken = new CancellationTokenSource();
        public static CancellationTokenSource Product = new CancellationTokenSource();
        public static CancellationTokenSource Page = new CancellationTokenSource();
        public static CancellationTokenSource User = new CancellationTokenSource();
        public static CancellationTokenSource Area = new CancellationTokenSource();
        public static CancellationTokenSource AreaType = new CancellationTokenSource();
        public static CancellationTokenSource City = new CancellationTokenSource();
        public static CancellationTokenSource Province = new CancellationTokenSource();
        public static CancellationTokenSource GlobalShipping = new CancellationTokenSource();
        public static CancellationTokenSource GlobalShippingPrice = new CancellationTokenSource();
        public static CancellationTokenSource GlobalShippingDistance = new CancellationTokenSource();
        public static CancellationTokenSource StoreShipping = new CancellationTokenSource();
        public static CancellationTokenSource StoreShippingArea = new CancellationTokenSource();
        public static CancellationTokenSource UserActivity = new CancellationTokenSource();
    }
}
