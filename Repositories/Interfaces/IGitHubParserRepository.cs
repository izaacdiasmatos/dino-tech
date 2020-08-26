using Readgithubfile.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Readgithubfile.API.Repositories.Interfaces
{
    public interface IGitHubParserRepository
    {
        string DonwloadURLContent(string url);
        public List<GitHubInfo> ScrapUrl(string url);
    }
}
