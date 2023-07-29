using SiteProxy.Services.Interfaces;

namespace SiteProxy.Services
{
    public class HtmlDownloader : IHtmlDownloader
    {
        public async Task<string> GetHtmlFromSite(Uri uri)
        {
            string result;

            using (HttpClient client = new())
            {
                HttpRequestMessage httpRequestMessage = new()
                {
                    Method = HttpMethod.Get,
                    RequestUri = uri
                };
                httpRequestMessage.Headers.Add("Accept", "*/*");
                httpRequestMessage.Headers.Add("User-Agent", "PostmanRuntime/7.32.3");


                var responce = await client.SendAsync(httpRequestMessage);
                var content = responce.Content;
                result = await content.ReadAsStringAsync();
            }

            return result;
        }
    }
}
