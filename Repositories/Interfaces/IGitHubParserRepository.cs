using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Readgithubfile.API.Repositories.Interfaces
{
    public interface IGitHubParserRepository
    {
        Task DonwloadURLContent(string url);
    }
}
