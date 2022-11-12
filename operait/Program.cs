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
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorPages();
            builder.Services.AddServerSideBlazor();
            builder.Services.AddSingleton<WeatherForecastService>();
            builder.Services
                .AddBlazorise(options =>
                {
                    options.Immediate = true;
                })
                .AddBootstrap5Providers()
                .AddFontAwesomeIcons();

            builder.Services.AddSingleton<DatabaseService>();

            IFeatureHubConfig config = new EdgeFeatureHubConfig("http://192.168.0.117:8085/", "6b0617b2-cc9b-4846-b9ad-b80c131851c8/kTqupKKcN3Y7kGLGDFAfBv4MXdVkn7*EtBXtwVL2dFGmNVKvkvJ");
            builder.Services.Add(ServiceDescriptor.Singleton(typeof(IFeatureHubConfig), config));
            config.Init();

            var app = builder.Build();

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