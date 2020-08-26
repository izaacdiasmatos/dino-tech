using Readgithubfile.API.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

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
    }
}
