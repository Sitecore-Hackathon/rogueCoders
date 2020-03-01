using Sitecore.Diagnostics;
using Sitecore.ExperienceEditor.Speak.Ribbon;
using Sitecore.ExperienceEditor.Speak.Server;
using Sitecore.Extensions.StringExtensions;
using Sitecore.Globalization;
using Sitecore.Mvc.Presentation;
using Sitecore.Web.UI.Controls;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;

namespace RogueCoders.Foundation.SitecoreExtensions.TopDownloaded
{
    public class GetTopDownloaded : RibbonComponentControlBase
    {
        private readonly RequestRepository _requestRepository = new RequestRepository();

        public GetTopDownloaded()
        {
            
        }

        public GetTopDownloaded(RenderingParametersResolver parametersResolver)
          : base(parametersResolver)
        {
            Assert.ArgumentNotNull((object)parametersResolver, nameof(parametersResolver));
            this.InitializeControl(parametersResolver);
        }

        public virtual IEnumerable<ComponentBase> Controls { get; set; }

        protected void InitializeControl(RenderingParametersResolver renderingParametersResolver)
        {
            this.Class = "sc-TopDownloaded";
            this.Requires.Script("client", "TopDownloaded.js");
            this.Attributes[(object)"data-sc-module-heading"] = renderingParametersResolver.GetString("Heading", string.Empty);
        }
        protected override void PreRender()
        {
            base.PreRender();
        }

        protected override void Render(HtmlTextWriter output)
        {
            Assert.ArgumentNotNull((object)output, nameof(output));
            base.Render(output);
            this.AddAttributes(output);
            output.AddAttribute(HtmlTextWriterAttribute.Class, Translate.Text(this.Class));
            output.RenderBeginTag("div");
            output.RenderEndTag();
        }

        public HtmlString HtmlAttributes
        {
            get
            {
                string text = this.Render();
                int num1 = text.IndexOf(">", StringComparison.Ordinal);
                if (num1 >= 0)
                    text = text.Left(num1 + 1);
                if (text.EndsWith("/>"))
                    text = text.Left(text.Length - 2);
                else if (text.EndsWith(">"))
                    text = text.Left(text.Length - 1);
                int num2 = text.IndexOf(" ", StringComparison.Ordinal);
                if (num2 >= 0)
                    text = text.Mid(num2 + 1);
                return new HtmlString(text.Trim());
            }
        }
    }
}