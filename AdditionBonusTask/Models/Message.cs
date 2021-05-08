using AdditionBonusTask.Areas.Identity.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AdditionBonusTask.Models
{
    public class Message
    {
        public int Id { get; set; }

        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string MessageText { get; set; }

        [Display(Name = "Date of Message")]
        [DataType(DataType.Date)]
        public DateTime DateOfMessage { get; set; }

        public string UserReceiverId { get; set; }
        public ApplicationUser User { get; set; }

        public int DialogId { get; set; }
        public Dialog Dialog { get; set; }
    }
}
