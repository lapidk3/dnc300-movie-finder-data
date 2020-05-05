using System.Web;
using System.Web.Mvc;

namespace dnc_300_movie_finder_data
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
