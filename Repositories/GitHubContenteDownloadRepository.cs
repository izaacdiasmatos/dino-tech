using Microsoft.AspNetCore.Mvc.Routing;
using Readgithubfile.API.Repositories.Interfaces;
using Readgithubfile.API.Utils;
using System;
using System.ComponentModel.DataAnnotations;
using System.Net.Http;
using System.Security.Policy;
using System.Text.RegularExpressions;

namespace Readgithubfile.API.Repositories
{
    public class GitHubContenteDownloadRepository : IGitHubContenteDownloadRepository
    {
        public GitHubContenteDownloadRepository() { }

        public string DownloadContent(string url)
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
        public bool ValidateUrl(string url)
        {
            using (var client = new HttpClient())
            {
                var response = client.GetAsync(url).Result;
                if (response.IsSuccessStatusCode)
                    return true;
                else return false;
            }
        }
        public bool ValidateUrlFormat(string url)
        {
            return url.StartsWith(StringMatcher.GITHUB_ROOT_URL) && Uri.IsWellFormedUriString(url, UriKind.RelativeOrAbsolute);
        }        
    }
}
