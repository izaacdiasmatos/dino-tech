using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Readgithubfile.API.Models;
using Readgithubfile.API.Models.Responses;
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
        private readonly IGitHubContenteDownloadRepository _gitHubContenteDownloadRepository;

        public GitHubParserRepository(IGitHubContenteDownloadRepository gitHubContenteDownloadRepository)
        {
            _gitHubContenteDownloadRepository = gitHubContenteDownloadRepository;
        }        
        
        public void ScrapStats(GitHubInfo info)
        {
            Match match = generateMatchFromUrl(RegexStrings.REGEX_GITHUB_FILE_STATS_SCRAP, info.FileUrl);

            if(match.Success)
            {
                int lines = 0;
                string[] sizeInfo;
                try
                {
                    lines = Int32.Parse(BetweenStrings(match.Value, StringMatcher.GITHUB_LINES_SCRAP_START, StringMatcher.GITHUB_LINES_SCRAP_END).Trim());
                }
                catch { }                

                try
                {
                    sizeInfo = BetweenStrings(match.Value, StringMatcher.GITHUB_STATS_SPAN_ENDING_TAG, StringMatcher.GITHUB_STATS_DIV_ENDING_TAG).Trim().Split(" ");
                }
                catch (Exception)
                {
                    sizeInfo = BetweenStrings(match.Value, StringMatcher.GITHUB_LINES_SCRAP_START, StringMatcher.GITHUB_STATS_DIV_ENDING_TAG).Trim().Split(" ");
                }

                float size = (sizeInfo != null && sizeInfo.Length > 0) ? this.ConvertSizeToBytes(sizeInfo) : 0;
                info.Lines = lines;
                info.Bytes = size;
            }
        }

        public MatchCollection generateMatchCollectionFromUrl(string regex, string url)
        {
            string urlContents = _gitHubContenteDownloadRepository.DownloadContent(url);
            return Regex.Matches(urlContents, regex);
            //Pattern pattern = Pattern.compile(regex, Pattern.DOTALL | Pattern.UNIX_LINES);            
	    }
        public Match generateMatchFromUrl(string regex, string url)
        {
            string urlContents = _gitHubContenteDownloadRepository.DownloadContent(url);
            return Regex.Match(urlContents, regex);
            //Pattern pattern = Pattern.compile(regex, Pattern.DOTALL | Pattern.UNIX_LINES);            
        }        

        public string BetweenStrings(string text, string start, string end)
        {
            if (text.IndexOf(start) > 0)
            {
                int p1 = text.IndexOf(start) + start.Length;
                int p2 = text.IndexOf(end, p1);
                return text.Substring(p1, p2 - p1);
            }
            else throw new Exception();
        }

        private float ConvertSizeToBytes(string[] githubSize)
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
                default:
                    return size;
            }
        }
    }
}
