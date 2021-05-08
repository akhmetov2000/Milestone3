using AdditionBonusTask.Areas.Identity.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdditionBonusTask.Models
{
    public class Friend
    {
        public int Id { get; set; }

        public string FriendSenderId { get; set; }
        //public ApplicationUser User { get; set; }

        public string ReceiverId { get; set; }
        //public Person Person { get; set; }


    }
}
