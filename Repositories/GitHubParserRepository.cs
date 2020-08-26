using Readgithubfile.API.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Readgithubfile.API.Repositories
{
    public class GitHubParserRepository : IGitHubParserRepository
    {
        public GitHubParserRepository() { }

        public async Task DonwloadURLContent(string url)
        {        
            using (var client = new HttpClient())
            {
                var response = await client.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    var htmlBody = await response.Content.ReadAsStringAsync();

                    string start = "<div class=\"text-mono f6 flex-auto pr-3 flex-order-2 flex-md-order-1 mt-2 mt-md-0\">";
                    string end = "</div>";

                    string final = betweenStrings(htmlBody, start, end);
                    Console.WriteLine(final);
                }
            }
        }

        public static string betweenStrings(string text, string start, string end)
        {
            int p1 = text.IndexOf(start) + start.Length;
            int p2 = text.IndexOf(end, p1);

            if (end == "") return (text.Substring(p1));
            else return text.Substring(p1, p2 - p1);
        }
    }
}
