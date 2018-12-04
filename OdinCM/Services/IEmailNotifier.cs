using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OdinCM.Services
{
    public interface IEmailNotifier
    {
        Task<bool> SendEmailAsync(string recipientEmail, string subject, string body);
        Task<bool> SendEmailAsync(string recipientEmail, string recpientName, string subject, string body);
    }
}
