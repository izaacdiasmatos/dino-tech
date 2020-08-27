using Microsoft.AspNetCore.Routing;
using Readgithubfile.API.Models;
using Readgithubfile.API.Models.Requests;
using Readgithubfile.API.Models.Responses;
using Readgithubfile.API.Repositories.Interfaces;
using Readgithubfile.API.Services.Interfaces;
using Readgithubfile.API.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Readgithubfile.API.Services
{
    public class GitHubParserService : IGitHubParserService
    {
        private readonly IGitHubParserRepository _gitHubParserRepository;
        private readonly IGitHubContenteDownloadRepository _gitHubContenteDownloadRepository;
        public GitHubParserService(IGitHubParserRepository gitHubParserRepository,
                                   IGitHubContenteDownloadRepository gitHubContenteDownloadRepository)
        {
            _gitHubParserRepository = gitHubParserRepository;
            _gitHubContenteDownloadRepository = gitHubContenteDownloadRepository;
        }

        public List<GitHubFileExtensionCollectionResponse> processGitHubRepositoryInfo(GitHubInfoRequest request)
        {
            ValidateExistentUrl(request);
            List<GitHubInfo> list = ScrapContent(request.Url);
            return list.GroupBy(g => g.FileExtension).Select(l => new GitHubFileExtensionCollectionResponse { Extetion = l.Key,ListInfo = l.ToList()}).ToList();
        }
        
        private List<GitHubInfo> ScrapContent(string url)
        {            
            List<GitHubInfo> listInfo = new List<GitHubInfo>();
            MatchCollection matches = _gitHubParserRepository.generateMatchCollectionFromUrl(RegexStrings.REGEX_GITHUB_FILE_SCRAP, url);

            foreach (Match match in matches)
            {
                string fileUrl = ConfigurationStrings.GITHUB_ROOT_URL + _gitHubParserRepository.BetweenStrings(match.Groups[0].Value, StringMatcher.GITHUB_FILE_SCRAP_START, StringMatcher.GITHUB_FILE_SCRAP_END);
                string rawUrl = fileUrl.Replace(ConfigurationStrings.GITHUB_ROOT_URL, ConfigurationStrings.GITHUB_RAW_CONTENT_URL).Replace(StringMatcher.GITHUB_BLOB, "");

                if (_gitHubContenteDownloadRepository.ValidateUrl(rawUrl))
                {
                    GitHubInfo githubFileInfo = new GitHubInfo(fileUrl, Path.GetExtension(fileUrl), 0, 0);
                    _gitHubParserRepository.ScrapStats(githubFileInfo);
                    listInfo.Add(githubFileInfo);
                }
                else
                {
                    listInfo.AddRange(ScrapContent(fileUrl));
                }
            }
            return listInfo;
        }

        private void ValidateExistentUrl(GitHubInfoRequest request)
        {
            if (_gitHubContenteDownloadRepository.ValidateUrl(request.Url) == false)
                throw new Exception("Not a valid URL");
        }
    }
}
