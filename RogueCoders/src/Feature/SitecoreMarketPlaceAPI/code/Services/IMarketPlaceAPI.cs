using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace RogueCoders.Feature.SitecoreMarketPlaceAPI.Services
{
    public interface IMarketPlaceAPI
    {
        string GetRecommendedItems();
        string GetTopDownloaded();
        string GetSearchItem(string searchText = "");
        bool InstallPackage(string url,string serverpath);
    }
}
