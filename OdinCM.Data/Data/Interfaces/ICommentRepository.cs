using OdinCM.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OdinCM.Data.Data.Interfaces
{
    public interface ICommentRepository : IDisposable
    {
        Task CreateComment(Comment commentModel);
    }
}
