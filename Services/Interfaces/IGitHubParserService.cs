using Readgithubfile.API.Models.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Readgithubfile.API.Services.Interfaces
{
    public interface IGitHubParserService
    {
        void ScrapGitHub(GitHubInfoRequest request);
    }
}
