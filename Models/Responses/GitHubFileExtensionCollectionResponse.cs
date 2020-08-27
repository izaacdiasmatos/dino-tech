using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;

namespace Readgithubfile.API.Models.Responses
{
    public class GitHubFileExtensionCollectionResponse
    {
        public string Extetion { get; set; }
        public List<GitHubInfo> ListInfo { get; set; }
    }
}
