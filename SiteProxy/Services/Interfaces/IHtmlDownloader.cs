namespace SiteProxy.Services.Interfaces
{
    public interface IHtmlDownloader
    {
        Task<string> GetHtmlFromSite(Uri uri);
    }
}
