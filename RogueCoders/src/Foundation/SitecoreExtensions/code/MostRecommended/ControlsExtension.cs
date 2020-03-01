using Sitecore.Diagnostics;
using Sitecore.Mvc.Presentation;

namespace RogueCoders.Foundation.SitecoreExtensions.MostRecommended
{
    public static class ControlsExtension
    {
        public static GetMostRecommended ShowMostRecommended(this Sitecore.Mvc.Controls controls, Rendering rendering)
        {
            Assert.ArgumentNotNull((object)controls, nameof(controls));
            Assert.ArgumentNotNull((object)rendering, nameof(rendering));
            var showRenderingList = new GetMostRecommended(controls.GetParametersResolver(rendering));
            return showRenderingList;
        }
    }
}