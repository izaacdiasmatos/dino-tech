using System.Collections.Generic;

namespace Readgithubfile.API.Models.Responses
{
    public class GitHubFileExtensionCollectionResponse
    {
        public string Extetion { get; set; }
        public List<GitHubInfo> ListInfo { get; set; }
    }
}
