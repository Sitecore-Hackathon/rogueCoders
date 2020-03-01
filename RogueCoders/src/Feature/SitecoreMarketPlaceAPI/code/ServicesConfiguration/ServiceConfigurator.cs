using Microsoft.Extensions.DependencyInjection;
using RogueCoders.Feature.SitecoreMarketPlaceAPI.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RogueCoders.Feature.SitecoreMarketPlaceAPI.Services;
using Sitecore.DependencyInjection;

namespace RogueCoders.Feature.SitecoreMarketPlaceAPI.ServicesConfiguration
{
    public class ServiceConfigurator : IServicesConfigurator
    {
        public void Configure(IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped(typeof(IMarketPlaceAPI), typeof(MarketPlaceAPI));
            serviceCollection.AddTransient(typeof(MarketPlaceAPIController));
        }
    }
}