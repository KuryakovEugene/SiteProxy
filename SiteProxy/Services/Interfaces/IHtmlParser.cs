namespace SiteProxy.Services.Interfaces
{
    public interface IHtmlParser
    {
        string ModifyAllWordsByNumLetters(string html, string modifier, int numLetters);
    }
}
