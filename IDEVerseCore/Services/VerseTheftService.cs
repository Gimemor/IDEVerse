using System.Data.Common;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using AngleSharp;
using AngleSharp.Html.Dom;
using AngleSharp.Html.Parser;
using AngleSharp.XPath;
using IdeVerseContracts.Services;

namespace IDEVerseCore.Services
{
    public class VerseTheftService : IVerseTheftService
    {
        public async Task<string[]> GetRhymes(string originalLine, int? stressPosition = null)
        {
            using var httpClient = new HttpClient();
            var url = $"https://rifme.net/r/{originalLine}";
            if (stressPosition != null)
            {
                url = url + "/" + stressPosition;
            }
            httpClient.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/90.0.4430.93 Safari/537.36");

            var result =  await httpClient.GetAsync(url);
            var data = await result.Content.ReadAsStringAsync();
            var config = Configuration.Default.WithXPath();
            var context = BrowsingContext.New(config);
            var parser = context.GetService<IHtmlParser>();
            var document = parser.ParseDocument(data);
            var selected = document.Body.SelectNodes("//ul[@id='tochnye']/li/@data-w");
            var values =  selected.Select(x => ((IHtmlListItemElement)x).TextContent).ToArray();
            return  values;
        }
    }
}