using AdditionBonusTask.Areas.Identity.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdditionBonusTask.Models
{
    public class Person
    {
        public int Id { get; set; }

        public string FriendSenderId { get; set; }
        public ApplicationUser User { get; set; }

        //public ICollection<Friend> Friends { get; set; }

    }
}
