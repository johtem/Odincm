using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using OdinCM.Areas.Identity.Data;
using OdinCM.Configuration;
using OdinCM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OdinCM.Services
{
    public class NotificationService : INotificationService
    {
        private readonly IEmailMessageFormatter _emailMessageFormatter;
        private readonly IEmailNotifier _emailNotifier;
        private readonly UserManager<CoreOdinUser> _userManager;
        private readonly AppSettings _appSettings;

        public NotificationService(
            IEmailMessageFormatter emailMessageFormatter,
            IEmailNotifier emailNotifier,
            UserManager<CoreOdinUser> userManager,
            IConfiguration configuration)
        {
            _emailMessageFormatter = emailMessageFormatter;
            _emailNotifier = emailNotifier;
            _userManager = userManager;
            _appSettings = configuration.Get<AppSettings>();
        }

        public async Task<bool> NotifyAuthorNewComment(CoreOdinUser author, Article article, Comment comment)
        {
            if (!author.CanNotify) return false;
            if (string.IsNullOrWhiteSpace(author.Email)) return false;

            var model = new
            {
                AuthorName = author.UserName,
                Title = "CoreWiki Notification",
                CommentDisplayName = comment.DisplayName,
                ArticleTitle = article.Topic,
                ArticleUrl = GetUrlForArticle(article)
            };
            var messageBody = await _emailMessageFormatter.FormatEmailMessage("NewComment", model);

            return await _emailNotifier.SendEmailAsync(author.Email, "Someone said something about your article", messageBody);
        }

        private string GetUrlForArticle(Article article)
        {
            return $"{_appSettings.Url}{article.Topic}";
        }
    }
}
