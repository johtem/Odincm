﻿using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using OdinCM.Configuration;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace OdinCM.Services
{
    public class EmailNotifier : IEmailNotifier
    {
        private readonly EmailNotifications _configuration;
        private readonly ILogger _logger;

        public EmailNotifier(IConfiguration configuration, ILoggerFactory loggerFactory)
        {
            _configuration = configuration.GetSection(nameof(EmailNotifications)).Get<EmailNotifications>();
            _logger = loggerFactory.CreateLogger<EmailNotifier>();
        }

        public async Task<bool> SendEmailAsync(string recipientEmail, string subject, string body)
        {
            return await SendEmailAsync(recipientEmail, string.Empty, subject, body);
        }

        public async Task<bool> SendEmailAsync(string recipientEmail, string recipientName, string subject, string body)
        {
            if (string.IsNullOrWhiteSpace(_configuration.SendGridApiKey))
            {
                _logger.LogInformation($"Missing SendGridApiKey setting in {nameof(EmailNotifications)}");

                return false;
            }

            if (string.IsNullOrWhiteSpace(_configuration.FromEmailAddress))
            {
                _logger.LogInformation($"Missing from FromEmailAddress setting in {nameof(EmailNotifications)}");

                return false;
            }

            if (string.IsNullOrWhiteSpace(recipientEmail))
            {
                throw new ArgumentException(nameof(recipientEmail));
            }

            var message = new SendGridMessage();
            var from = new EmailAddress(_configuration.FromEmailAddress, _configuration.FromName);
            var to = new EmailAddress(recipientEmail, recipientName);

            message.SetFrom(from);
            message.AddTo(to);
            message.SetSubject(subject);
            message.AddContent(MimeType.Html, body);

            var client = new SendGridClient(_configuration.SendGridApiKey);

            var response = await client.SendEmailAsync(message);

            _logger.LogInformation($"Sent email form {from.Email} to {to.Email} response {response.StatusCode}");

            return response.StatusCode == HttpStatusCode.OK;
        }
    }
}
