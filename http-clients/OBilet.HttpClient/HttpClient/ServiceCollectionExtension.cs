using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net.Http.Headers;

namespace OBilet.HttpClient
{
    public static class ServiceCollectionExtension
    {
        public static void AddOBiletHttpClient(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            var options = configuration.GetSection(OBiletOptions.OBilet).Get<OBiletOptions>();

            serviceCollection.AddHttpClient<OBiletHttpClient>(client =>
            {
                client.BaseAddress = new Uri(options.BaseUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.AcceptLanguage.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Add("Authorization", "Basic " + options.ApiKey);
            });
        }

    }
}
