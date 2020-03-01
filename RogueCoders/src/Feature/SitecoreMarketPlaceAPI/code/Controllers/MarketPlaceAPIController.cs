using RogueCoders.Feature.SitecoreMarketPlaceAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RogueCoders.Feature.SitecoreMarketPlaceAPI.Controllers
{
    public class MarketPlaceAPIController : Controller
    {
        private readonly IMarketPlaceAPI _sitecoreMarketPlaceAPI;
        public MarketPlaceAPIController(IMarketPlaceAPI sitecoreMarketPlaceAPI)
        {
            _sitecoreMarketPlaceAPI = sitecoreMarketPlaceAPI;
        }
        [System.Web.Mvc.HttpGet]
        public ActionResult GetRecommendedItems()
        {
            var json = _sitecoreMarketPlaceAPI.GetRecommendedItems();
            return Json(json, JsonRequestBehavior.AllowGet);
        }
        [System.Web.Mvc.HttpGet]
        public ActionResult GetTopDownloaded()
        {
            var json = _sitecoreMarketPlaceAPI.GetTopDownloaded();
            return Json(json, JsonRequestBehavior.AllowGet);
        }
        [System.Web.Mvc.HttpGet]
        public ActionResult GetSearchItem(string searchText)
        {
            var json = _sitecoreMarketPlaceAPI.GetSearchItem(searchText);
            return Json(json, JsonRequestBehavior.AllowGet);
        }

        [System.Web.Mvc.HttpPost]
        public ActionResult InstallPackage(string url)
        {
            string filePath = "~/App_Data/Packages/Package.zip";
            var servermapath = Server.MapPath(filePath);
            _sitecoreMarketPlaceAPI.InstallPackage(url, servermapath);
            return Json("", JsonRequestBehavior.AllowGet);
        }
    }
}