using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Threading.Tasks;

namespace Readgithubfile.API.Utils
{
    public class RegexStrings
    {   
        public static string REGEX_GITHUB_FILE_SCRAP = "(?s)(?i)<div role=\"rowheader\" class=\"flex-auto min-width-0 col-md-2 mr-3\">(.*?)<\\/div>";
        public static string REGEX_GITHUB_FILE_STATS_SCRAP = "(?s)(?i)<div class=\"text-mono f6 flex-auto pr-3 flex-order-2 flex-md-order-1 mt-2 mt-md-0\">(.*?)<\\/div>";
    }
}
