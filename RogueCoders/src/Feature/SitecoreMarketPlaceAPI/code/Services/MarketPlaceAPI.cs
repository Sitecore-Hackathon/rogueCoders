using Sitecore.ApplicationCenter.Applications;
using Sitecore.Data.Engines;
using Sitecore.Install.Files;
using Sitecore.Install.Framework;
using Sitecore.Install.Items;
using Sitecore.Install.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace RogueCoders.Feature.SitecoreMarketPlaceAPI.Services
{
    public class MarketPlaceAPI : IMarketPlaceAPI
    {
        public string GetRecommendedItems()
        {
            var result = ReadAPI("https://sitecoremodulemock.azure-api.net/recommended");
            return result;
        }
        public string GetTopDownloaded()
        {
            var result = ReadAPI("https://sitecoremodulemock.azure-api.net/topdownloads");
            return result;
        }
        public string GetSearchItem(string searchText = "")
        {
            string result;
            if (string.IsNullOrEmpty(searchText))
            {
                result = ReadAPI("https://sitecoremodulemock.azure-api.net/search");
            }
            else
            {
                result = ReadAPI("https://sitecoremodulemock.azure-api.net/searchbyname");
            }
            return result;
        }
        public bool InstallPackage(string url,string servermappath)
        {
            using (var client = new WebClient())
            {
                byte[] bytes = client.DownloadData(url);
                System.IO.File.WriteAllBytes(servermappath, bytes);
                using (new SyncOperationContext())
                {
                    IProcessingContext context = new SimpleProcessingContext();
                    IItemInstallerEvents events = new DefaultItemInstallerEvents(new BehaviourOptions(InstallMode.Overwrite, MergeMode.Undefined));
                    context.AddAspect(events);
                    IFileInstallerEvents events1 = new DefaultFileInstallerEvents(true);
                    context.AddAspect(events1);

                    Sitecore.Install.Installer installer = new Sitecore.Install.Installer();
                    installer.InstallPackage(servermappath, context);
                }
                return true;
            }
        }
        private string ReadAPI(string address, string searchText = "")
        {
            var request = (HttpWebRequest)WebRequest.Create(address);

            request.Method = "POST";
            request.ContentType = "application/json";
            request.ContentLength = 0;

            var result = string.Empty;

            using (var response = (HttpWebResponse)request.GetResponse())
            {
                using (var stream = response.GetResponseStream())
                {
                    using (var sr = new StreamReader(stream))
                    {
                        result = sr.ReadToEnd();
                    }
                }
            }
            return result;
        }
    }
}