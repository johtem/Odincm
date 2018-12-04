using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OdinCM.Services
{
    public interface IEmailMessageFormatter
    {
        Task<string> FormatEmailMessage<T>(string templateName, T model) where T : class;
    }
}
