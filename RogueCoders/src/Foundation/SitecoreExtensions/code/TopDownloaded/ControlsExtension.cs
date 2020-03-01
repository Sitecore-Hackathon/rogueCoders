using Sitecore.Diagnostics;
using Sitecore.Mvc.Presentation;

namespace RogueCoders.Foundation.SitecoreExtensions.TopDownloaded
{
    public static class ControlsExtension
    {
        public static GetTopDownloaded GetTopDownloaded(this Sitecore.Mvc.Controls controls, Rendering rendering)
        {
            Assert.ArgumentNotNull((object)controls, nameof(controls));
            Assert.ArgumentNotNull((object)rendering, nameof(rendering));
            var showRenderingList = new GetTopDownloaded(controls.GetParametersResolver(rendering));
            return showRenderingList;
        }
    }
}