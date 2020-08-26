using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Threading.Tasks;

namespace Readgithubfile.API.Utils
{
    public class RegexStrings
    {
        public static string GITHUB_ROOT_URL = "https://github.com";
        public static string GITHUB_RAW_CONTENT_URL = "https://raw.githubusercontent.com";
        public static string GITHUB_BLOB = "blob/";
        //public static string REGEX_GITHUB_FILE_SCRAP = "(?s)(?i)<td class=\"content\">(.*?)<\\/td>";
        public static string REGEX_GITHUB_FILE_SCRAP = "(?s)(?i)<div role=\"rowheader\" class=\"flex-auto min-width-0 col-md-2 mr-3\">(.*?)<\\/div>";
        public static string REGEX_GITHUB_FILE_STATS_SCRAP = "(?s)(?i)<div class=\"text-mono f6 flex-auto pr-3 flex-order-2 flex-md-order-1 mt-2 mt-md-0\">(.*?)<\\/div>";
        public static string GITHUB_FILE_SCRAP_START = "href=\"";
        public static string GITHUB_FILE_SCRAP_END = "\">";
        public static string GITHUB_LINES_SCRAP_START = "mt-md-0\">";
        public static string GITHUB_LINES_SCRAP_END = " lines";
        public static string GITHUB_STATS_SPAN_ENDING_TAG = "file-info-divider\"></span>";
        public static string GITHUB_STATS_DIV_ENDING_TAG = " </div>";
    }
}
