using Microsoft.AspNetCore.Mvc;
using Readgithubfile.API.Models;
using Readgithubfile.API.Models.Requests;
using Readgithubfile.API.Services.Interfaces;
using System;

namespace Readgithubfile.API.Controllers
{
	[ApiController]
	[Route("readgithubfile/githubparse")]
	public class GitHubParserController : ControllerBase
	{
		private readonly IGitHubParserService _gitHubParserService;
		public GitHubParserController(IGitHubParserService gitHubParserService)
		{
			_gitHubParserService = gitHubParserService;
		}

		[HttpPost]
		[Route("")]
		public void ProcessGitHubInfo([FromBody] GitHubInfoRequest request)
        {
			_gitHubParserService.ScrapGitHub(request);
		}
	}
}
