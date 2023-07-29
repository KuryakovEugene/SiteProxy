using SiteProxy.Services;
using SiteProxy.Services.Interfaces;

namespace SiteProxy
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers(); 

            builder.Services.AddTransient<IHtmlParser, HtmlParser>();
            builder.Services.AddTransient<IHtmlDownloader, HtmlDownloader>();

            var app = builder.Build();

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}