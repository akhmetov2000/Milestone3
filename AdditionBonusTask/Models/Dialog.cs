using AdditionBonusTask.Areas.Identity.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AdditionBonusTask.Models
{
    public class Dialog
    {
        public int Id { get; set; }


        public string UserSenderId { get; set; }
        public ApplicationUser User { get; set; }

        public ICollection<Message> Messages{ get; set; }

    }
}
