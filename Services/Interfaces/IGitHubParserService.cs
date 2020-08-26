using Readgithubfile.API.Models;
using Readgithubfile.API.Models.Requests;
using Readgithubfile.API.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Readgithubfile.API.Services.Interfaces
{
    public interface IGitHubParserService
    {
        List<GitHubFileExtetionCollectionResponse> processGitHubRepositoryInfo(GitHubInfoRequest request);
    }
}
