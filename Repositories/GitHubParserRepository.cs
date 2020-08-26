using Readgithubfile.API.Models;
using Readgithubfile.API.Repositories.Interfaces;
using Readgithubfile.API.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Reflection.Metadata;
using System.Runtime.ConstrainedExecution;
using System.Security.Policy;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Readgithubfile.API.Repositories
{
    public class GitHubParserRepository : IGitHubParserRepository
    {
        public GitHubParserRepository() { }        

        public List<GitHubInfo> ScrapUrl(string url)
        {
            //Validate URL from Git
            List<GitHubInfo> listInfo = new List<GitHubInfo>();
            MatchCollection matches = generateMatchCollectionFromUrl(RegexStrings.REGEX_GITHUB_FILE_SCRAP, url);

            foreach (Match match in matches)
            {
                string fileUrl = RegexStrings.GITHUB_ROOT_URL + betweenStrings(match.Groups[0].Value, RegexStrings.GITHUB_FILE_SCRAP_START, RegexStrings.GITHUB_FILE_SCRAP_END);
                string rawUrl = fileUrl.Replace(RegexStrings.GITHUB_ROOT_URL, RegexStrings.GITHUB_RAW_CONTENT_URL).Replace(RegexStrings.GITHUB_BLOB, "");

                if (ExistUrl(rawUrl))
                {                    
                    GitHubInfo githubFileInfo = new GitHubInfo(fileUrl, Path.GetExtension(fileUrl),0,0);
                }
            }

            return listInfo;
        }

        public void scrapGitHubStats(GitHubInfo info)
        {
            Match match = generateMatchFromUrl(RegexStrings.REGEX_GITHUB_FILE_STATS_SCRAP, info.FileUrl);

            while (match.Success)
            {
                int lines;
                string[] sizeInfo;

                try
                {
                    lines = Int32.Parse(betweenStrings(match.Value, RegexStrings.GITHUB_LINES_SCRAP_START, RegexStrings.GITHUB_LINES_SCRAP_END).Trim());
                }
                catch (Exception)
                {
                    lines = 0;
                }                

                try
                {
                    sizeInfo = betweenStrings(match.Value, RegexStrings.GITHUB_STATS_SPAN_ENDING_TAG, RegexStrings.GITHUB_STATS_DIV_ENDING_TAG).Trim().Split(" ");
                }
                catch (Exception)
                {
                    sizeInfo = betweenStrings(match.Value, RegexStrings.GITHUB_LINES_SCRAP_START, RegexStrings.GITHUB_STATS_DIV_ENDING_TAG).Trim().Split(" ");
                }

                float size = (sizeInfo != null && sizeInfo.Length > 0) ? this.convertGithubSizeToBytes(sizeInfo) : 0;
                info.Lines = lines;
                info.Bytes = size;
            }
        }

        private MatchCollection generateMatchCollectionFromUrl(string regex, string url)
        {
            string urlContents = DonwloadURLContent(url);
            return Regex.Matches(urlContents, regex);
            //Pattern pattern = Pattern.compile(regex, Pattern.DOTALL | Pattern.UNIX_LINES);            
	    }
        private Match generateMatchFromUrl(string regex, string url)
        {
            string urlContents = DonwloadURLContent(url);
            return Regex.Match(urlContents, regex);
            //Pattern pattern = Pattern.compile(regex, Pattern.DOTALL | Pattern.UNIX_LINES);            
        }

        public string DonwloadURLContent(string url)
        {        
            using (var client = new HttpClient())
            {
                var response = client.GetAsync(url).Result;
                if (response.IsSuccessStatusCode)
                {
                    return response.Content.ReadAsStringAsync().Result;                    
                }
                return "";
            }
        }

        public bool ExistUrl(string url)
        {
            using (var client = new HttpClient())
            {
                var response = client.GetAsync(url).Result;
                if (response.IsSuccessStatusCode)
                    return true;
                else return false;
            }
        }

        public static string betweenStrings(string text, string start, string end)
        {
            int p1 = text.IndexOf(start) + start.Length;
            int p2 = text.IndexOf(end, p1);

            if (end == "") return (text.Substring(p1));
            else return text.Substring(p1, p2 - p1);
        }

        private float convertGithubSizeToBytes(string[] githubSize)
        {
            float size = float.Parse(githubSize[0]);

            switch (githubSize[1].ToUpper())
            {
                case "KB":
                    return (size * 1000);
                case "MB":
                    return (size * 1000000);
                case "GB":
                    return (size * 1000000000);
                default: // Already in bytes
                    return size;
            }
        }
    }
}
