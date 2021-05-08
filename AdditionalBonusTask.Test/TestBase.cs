using AdditionBonusTask.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdditionalBonusTask.Test
{
    public abstract class TestBase
    {
        protected AuthDbContext GetDbContext()
        {
            var options = new DbContextOptionsBuilder<AuthDbContext>()
                                  .UseInMemoryDatabase(Guid.NewGuid().ToString())
                                  .Options;
            return new AuthDbContext(options);
        }
    }
}
