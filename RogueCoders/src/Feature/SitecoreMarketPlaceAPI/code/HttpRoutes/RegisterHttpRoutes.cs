using Sitecore.Pipelines;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;

namespace RogueCoders.Feature.SitecoreMarketPlaceAPI.HttpRoutes
{
    public class RegisterHttpRoutes
    {
        public void Process(PipelineArgs args)
        {
            Configure(RouteTable.Routes);
        }

        protected void Configure(RouteCollection routes)
        {
            routes.MapHttpRoute("GetRecommendedItems", "api/sitecore/MarketPlaceAPI/GetRecommendedItems/{id}", new
            {
                controller = "MarketPlaceAPI",
                action = "GetRecommendedItems"
            });
            routes.MapHttpRoute("GetTopDownloaded", "api/sitecore/MarketPlaceAPI/GetTopDownloaded/{id}", new
            {
                controller = "MarketPlaceAPI",
                action = "GetTopDownloaded"
            });
            routes.MapHttpRoute("GetSearchItem", "api/sitecore/MarketPlaceAPI/GetSearchItem/{id}", new
            {
                controller = "MarketPlaceAPI",
                action = "GetSearchItem"
            });
            routes.MapHttpRoute("InstallPackage", "api/sitecore/MarketPlaceAPI/InstallPackage/{id}", new
            {
                controller = "MarketPlaceAPI",
                action = "InstallPackage"
            });
        }
    }
}