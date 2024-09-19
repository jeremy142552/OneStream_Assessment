using Microsoft.AspNetCore.Components.Web;
using OneStream_Assessment_BlazorWeb.Components;
using OneStream_Assessment_Services.FrontEnd;

namespace OneStream_Assessment_BlazorWeb
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorComponents()
                .AddInteractiveServerComponents();
            //builder.Services.AddRazorPages();
            //builder.Services.AddServerSideBlazor();

            // Add HttpContextAccessor
            builder.Services.AddHttpContextAccessor();

            // Explicitly add HttpClient and IHttpClientFactory
            builder.Services.AddHttpClient();

            // Register FrontEndService
            builder.Services.AddScoped<IFrontEndService, FrontEndService>();

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
            app.UseAntiforgery();

            app.MapRazorComponents<App>()
                .AddInteractiveServerRenderMode();

            app.Run();
        }
    }
}
