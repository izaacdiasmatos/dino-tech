﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Readgithubfile.API.Models
{
    public class GitHubInfo
    {
        public string FileUrl { get; set; }
        public int Lines { get; set; }
        public float Bytes { get; set; }

        public GitHubInfo(string fileUrl, int lines, float bytes)
        {
            FileUrl = fileUrl;
            Lines = lines;
            Bytes = bytes;
        }
    }
}
