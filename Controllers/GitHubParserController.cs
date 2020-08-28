using Microsoft.AspNetCore.Mvc;
using Readgithubfile.API.Models;
using Readgithubfile.API.Models.Requests;
using Readgithubfile.API.Models.Responses;
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
		public ActionResult<List<GitHubFileExtensionCollectionResponse>>  WebScrapProcessing([FromBody] GitHubInfoRequest request)
        {
            try
            {
				return Ok(_gitHubParserService.processGitHubRepositoryInfo(request));
            }
            catch(Exception e)
            {
				return BadRequest(e.Message);
            }
			
		}
	}
}
