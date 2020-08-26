using Readgithubfile.API.Models.Requests;
using Readgithubfile.API.Repositories.Interfaces;
using Readgithubfile.API.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Readgithubfile.API.Services
{
    public class GitHubParserService : IGitHubParserService
    {
        private readonly IGitHubParserRepository _gitHubParserRepository;
        public GitHubParserService(IGitHubParserRepository gitHubParserRepository)
        {
            _gitHubParserRepository = gitHubParserRepository;
        }

        public void ScrapGitHub(GitHubInfoRequest request)
        {
            _gitHubParserRepository.DonwloadURLContent(request.Url);
        }
    }
}
