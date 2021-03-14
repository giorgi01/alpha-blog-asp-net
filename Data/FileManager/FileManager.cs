﻿using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Alpha_blog.Data.FileManager
{

    public class FileManager : IFileManager
    {
        private string _imagePath;

        public FileManager(IConfiguration config)
        {
            _imagePath = config["Path:Images"];
        }

        public async Task<string> SaveImage(IFormFile image)
        {
            var savePath = Path.Combine(_imagePath);
            if (!Directory.Exists(savePath))
            {
                Directory.CreateDirectory(savePath);
            }

            var mime = image.FileName.Substring(image.FileName.LastIndexOf('.'));
            var fileName = $"img_{DateTime.Now.ToString("dd-MM-yyyy-mm-ss")}{mime}";

            using(var fileStream = new FileStream(Path.Combine(savePath, fileName), FileMode.Create))
            {
                await image.CopyToAsync(fileStream);
            }

            return fileName;
        }

        public FileStream ImageStream(string image)
        {
            return new FileStream(Path.Combine(_imagePath, image), FileMode.Open, FileAccess.Read);
        }
    }
}
