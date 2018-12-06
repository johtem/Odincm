using OdinCM.Data.Data.Interfaces;
using OdinCM.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OdinCM.Data.Data.Repositories
{
    public class CommentSqliteRepository : ICommentRepository
    {

        public CommentSqliteRepository(OdinCMContext context)
        {
            Context = context;
        }

        public OdinCMContext Context { get; }



        public async Task CreateComment(Comment commentModel)
        {
            await Context.Comments.AddAsync(commentModel);
            await Context.SaveChangesAsync();
        }


        public void Dispose()
        {
            this.Context.Dispose();
        }
    }
}
