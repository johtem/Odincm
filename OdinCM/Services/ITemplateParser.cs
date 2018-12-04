using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OdinCM.Services
{
    public interface ITemplateParser
    {
        string Format<T>(string template, T model) where T : class;
    }
}
