using Microsoft.AspNetCore.Mvc;
using SiteProxy.Helpers;
using HtmlAgilityPack;
using SiteProxy.Services.Interfaces;

namespace SiteProxy.Controllers
{
    [Route("/")]
    [ApiController]
    public class ProxyController : ControllerBase
    {
        private readonly IHtmlDownloader _downloader;
        private readonly IHtmlParser _htmlParser;

        public ProxyController(IHtmlDownloader downloader, IHtmlParser htmlParser)
        {
            _downloader = downloader;
            _htmlParser = htmlParser;
        }

        [Route("{*queryvalues}")]
        public async Task<ContentResult> Index()
        {
            var html = await _downloader.GetHtmlFromSite(new Uri(Constants.Site + Request.Path));
            html = _htmlParser.ModifyAllWordsByNumLetters(html, Constants.Modifier, Constants.NumOfLetters);

            return new ContentResult()
            {
                Content = html,
                StatusCode = 200,
                ContentType = "text/html"
            };
        }
    }
}