using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Readgithubfile.API.Utils
{
    public class StringMatcher
    {
        public static string GITHUB_FILE_SCRAP_START = "href=\"";
        public static string GITHUB_FILE_SCRAP_END = "\">";
        public static string GITHUB_LINES_SCRAP_START = "mt-md-0\">";
        public static string GITHUB_LINES_SCRAP_END = " lines";
        public static string GITHUB_STATS_SPAN_ENDING_TAG = "file-info-divider\"></span>";
        public static string GITHUB_STATS_DIV_ENDING_TAG = " </div>";
        public static string GITHUB_BLOB = "blob/";
    }
}
