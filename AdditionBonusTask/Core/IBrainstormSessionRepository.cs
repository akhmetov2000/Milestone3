using AdditionBonusTask.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdditionBonusTask.Core
{
    public interface IBrainstormSessionRepository
    {
        Task<Comment> GetByIdAsync(int id);
        Task<List<Comment>> ListAsync();
        Task AddAsync(Comment session);
        Task UpdateAsync(Comment session);
    }
}
