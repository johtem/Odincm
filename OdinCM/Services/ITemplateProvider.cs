using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OdinCM.Services
{
    public interface ITemplateProvider
    {
        Task<string> GetTemplateContent(string templateName);
    }
}
