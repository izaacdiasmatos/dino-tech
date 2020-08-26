using Readgithubfile.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Readgithubfile.API.Repositories.Interfaces
{
    public interface IGitHubParserRepository
    {
        void ScrapStats(GitHubInfo info);
        MatchCollection generateMatchCollectionFromUrl(string regex, string url);
        Match generateMatchFromUrl(string regex, string url);
        string BetweenStrings(string text, string start, string end);
    }
}
