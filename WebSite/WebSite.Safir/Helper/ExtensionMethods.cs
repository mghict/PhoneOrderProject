using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using System.Collections.Specialized;
using System.Web;

namespace WebSite.Safir.Helper
{
    public static class ExtensionMethods
    {
        public static NameValueCollection QueryString(this NavigationManager navigationManager)
        {
            return HttpUtility.ParseQueryString(new Uri(navigationManager.Uri).Query);
        }

        public static string QueryString(this NavigationManager navigationManager, string key)
        {
            return navigationManager.QueryString()[key];
        }

        public static long ToLong(this string input)
        {
            try
            {
                long retVal = Convert.ToInt64(input);
                return retVal;
            }
            catch
            {
                return 0;
            }
        }

        public static int ToInt(this string input)
        {
            try
            {
                int retVal = Convert.ToInt32(input);
                return retVal;
            }
            catch
            {
                return 0;
            }
        }
    }
}
