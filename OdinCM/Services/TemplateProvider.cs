using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace OdinCM.Services
{
    public class TemplateProvider : ITemplateProvider
    {
        public const string DEFAULT_TEMPLATE_EXTENSION = "tmpl";
        private readonly string _templateRootFolder;

        public TemplateProvider(IHostingEnvironment hostingEnvironment)
        {
            _templateRootFolder = Path.Combine(hostingEnvironment.ContentRootPath, "EmailTemplates"); ;
        }

        public async Task<string> GetTemplateContent(string templateName)
        {
            var fullPath = GetFullPath(_templateRootFolder, $"{templateName}.{DEFAULT_TEMPLATE_EXTENSION}");

            if (!File.Exists(fullPath))
            {
                throw new Exception($"Template {templateName} was not found in {_templateRootFolder}");
            }

            return await File.ReadAllTextAsync(fullPath);
        }

        private string GetFullPath(string path, string filename)
        {
            return Path.Combine(path, filename);
        }
    }
}
