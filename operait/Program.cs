using Blazorise;
using Blazorise.Bootstrap5;
using Blazorise.Icons.FontAwesome;
using FeatureHubSDK;
using operait.Data;
using operait.Services;

namespace operait
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorPages();
            builder.Services.AddServerSideBlazor();
            builder.Services
                .AddBlazorise(options =>
                {
                    options.Immediate = true;
                })
                .AddBootstrap5Providers()
                .AddFontAwesomeIcons();

            builder.Services.AddSingleton<DatabaseService>();

            builder.Services.AddSingleton<IFeatureHubConfig>((sp) =>
            {
                var iConfiguration = sp.GetService<IConfiguration>();
                var featureHubEdgeUrl = iConfiguration["FeatureHubEdgeUrl"];
                var featureHubApiKey = iConfiguration["FeatureHubApiKey"];
                IFeatureHubConfig config = new EdgeFeatureHubConfig(featureHubEdgeUrl, featureHubApiKey);
                config.Init();
                return config;
            });

            var app = builder.Build();
            var ifh = app.Services.GetService<IFeatureHubConfig>();
            while (ifh.Readyness != Readyness.Ready)
            {
                await Task.Delay(100);
            }
            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseRouting();

            app.MapBlazorHub();
            app.MapFallbackToPage("/_Host");

            app.Run();
        }
    }
}