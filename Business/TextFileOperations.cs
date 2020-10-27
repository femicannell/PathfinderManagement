using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace PathfinderManagement.Business
{
    public class TextFileOperations : ITextFileOperations
    {
        private readonly IWebHostEnvironment _webHostEnvironment;

        public TextFileOperations(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        public IEnumerable<string> LoadPathfinderInfo()
        {
            string webRootPath = _webHostEnvironment.WebRootPath;
            FileInfo filepath = new FileInfo(Path.Combine(webRootPath, "PathfinderInfo.txt"));
            string[] lines = System.IO.File.ReadAllLines(filepath.ToString());
            return lines.ToList();
        }
    }
}
