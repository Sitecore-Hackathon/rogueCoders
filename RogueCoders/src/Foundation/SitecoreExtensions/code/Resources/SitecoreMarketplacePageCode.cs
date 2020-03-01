using Sitecore;
using Sitecore.Mvc.Presentation;
using Sitecore.Web.PageCodes;

namespace RogueCoders.Foundation.SitecoreExtensions.Resources
{
    public class SitecoreMarketplacePageCode : PageCodeBase
    {
        private Rendering HeaderTitle { get; set; }
        public override void Initialize()
        {
            this.SetTitle();
        }

        private void SetTitle()
        {
            if (Context.Item.Name == "Dashboard")
                this.HeaderTitle.Parameters["Text"] = "DashBoard";
            else
                this.HeaderTitle.Parameters["Text"] = Context.Item.DisplayName;
        }
    }
}