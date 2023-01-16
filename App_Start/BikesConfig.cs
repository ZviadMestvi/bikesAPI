using System.Web.Http;

namespace CompareBikes.App_Start
{
    public class BikesConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.EnableCors();

            // Web API route
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "BikesApi",
                routeTemplate: "api/{controller}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
