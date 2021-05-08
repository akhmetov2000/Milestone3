using AdditionBonusTask.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdditionBonusTask.Services
{
   public interface IPostRepository
    {
        void Add(Post post);
        Task Save();

        Task DeletePost(Post post);
        Task<List<Post>> GetAll();
        Task<List<Post>> GetPosts(Expression<Func<Post, bool>> predicate);
    }
}
