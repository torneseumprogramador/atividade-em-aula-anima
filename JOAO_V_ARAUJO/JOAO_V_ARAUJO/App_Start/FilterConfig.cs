using System.Web;
using System.Web.Mvc;

namespace JOAO_V_ARAUJO_E_GEORDANI_PAIANO
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
