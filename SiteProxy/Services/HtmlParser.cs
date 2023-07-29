using HtmlAgilityPack;
using SiteProxy.Services.Interfaces;

namespace SiteProxy.Services
{
    public class HtmlParser : IHtmlParser
    {
        public string ModifyAllWordsByNumLetters(string html, string modifier, int numLetters)
        {
            var htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(html);

            var textNodes = htmlDoc.DocumentNode
                .SelectSingleNode("//body")
                .DescendantsAndSelf()
                .Where(n => n.NodeType == HtmlNodeType.Text);

            foreach (var textNode in textNodes)
            {
                string[] words = textNode.InnerHtml.Split(' ');
                for (int i = 0; i < words.Length; i++)
                {
                    if (words[i].Length == numLetters)
                    {
                        words[i] += modifier;
                    }
                }
                textNode.InnerHtml = string.Join(" ", words);
            }

            return htmlDoc.DocumentNode.OuterHtml;
        }
    }
}
