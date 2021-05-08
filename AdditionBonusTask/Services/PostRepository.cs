using AdditionBonusTask.Data;
using AdditionBonusTask.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdditionBonusTask.Services
{
    public class PostRepository: IPostRepository
    {
        readonly AuthDbContext _context;

        public PostRepository(AuthDbContext context)
        {
            _context = context;
        }

        public void Add(Post post)
        {
            _context.Add(post);
        }

        public Task DeletePost(Post post)
        {
            _context.Posts.Remove(post);
            return _context.SaveChangesAsync();
        }

        public Task<List<Post>> GetAll()
        {
            return _context.Posts.ToListAsync();
        }

        public Task<List<Post>> GetPosts(Expression<Func<Post, bool>> predicate)
        {
            return _context.Posts.Where(predicate).ToListAsync();
        }

        public Task Save()
        {
            return _context.SaveChangesAsync();
        }
    }
}
