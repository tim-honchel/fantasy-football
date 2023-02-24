using FantasyFootballDraftGuide.Data.Data;
using FantasyFootballDraftGuide.Data.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace FantasyFootballDraftGuide.Data.Configuration
{
    public static class DataLayerConfiguration
    {
        public static IServiceCollection AddDataScope(this IServiceCollection services)
        {
            services.AddTransient<IRulesRepository, RulesRepository>();

            return services;
        }



    }
}
