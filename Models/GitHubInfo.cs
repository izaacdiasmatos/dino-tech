using System;
using System.ComponentModel.DataAnnotations;

namespace Readgithubfile.API.Models
{
    public class GitHubInfo
    {
        [Required(ErrorMessage = "This property is required")]        
        public string FileUrl { get; set; }

        [Required(ErrorMessage = "This property is required")]
        public string FileName { get; set; }

        [Required(ErrorMessage = "This property is required")]
        public string FileExtension { get; set; }

        [Required(ErrorMessage = "This property is required")]
        [Range(0, float.MaxValue, ErrorMessage = "Lines quantity can't be negative")]
        public int Lines { get; set; }

        [Required(ErrorMessage = "This property is required")]
        [Range(0, float.MaxValue, ErrorMessage = "Bytes size can't be negative")]
        public float Bytes { get; set; }

        public GitHubInfo(string fileUrl, string fileExtension, string fileName, int lines, float bytes)
        {
            FileUrl = fileUrl;
            FileName = fileName;
            FileExtension = fileExtension;
            Lines = lines;
            Bytes = bytes;
        }
    }
}

