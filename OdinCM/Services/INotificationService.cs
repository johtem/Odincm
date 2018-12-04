using OdinCM.Areas.Identity.Data;
using OdinCM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OdinCM.Services
{
    public interface INotificationService
    {
        Task<bool> NotifyAuthorNewComment(CoreOdinUser author, Article article, Comment comment);
    }
}
