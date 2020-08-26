using Microsoft.AspNetCore.Mvc;
using Readgithubfile.API.Models;
using Readgithubfile.API.Models.Requests;
using Readgithubfile.API.Services.Interfaces;
using System;
using System.Collections.Generic;

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
		public ActionResult<List<GitHubInfo>>  ProcessGitHubInfo([FromBody] GitHubInfoRequest request)
        {
			return Ok(_gitHubParserService.ScrapGitHub(request));
		}
	}
}
