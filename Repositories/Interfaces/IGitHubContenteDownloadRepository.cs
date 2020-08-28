using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Readgithubfile.API.Repositories.Interfaces
{
    public interface IGitHubContenteDownloadRepository
    {
        string DownloadContent(string url);
        bool ValidateUrl(string url);
        bool ValidateUrlFormat(string url);
    }
}
