using AdditionBonusTask.Areas.Identity.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AdditionBonusTask.Models
{
    public class Comment
    {
        public int Id { get; set; }

        [StringLength(60, MinimumLength = 1)]
        public string CommentText { get; set; }

        [Display(Name = "Comment Date")]
        [DataType(DataType.Date)]
        public DateTime CommentDate { get; set; }

        public int PostId { get; set; }
        public Post Post { get; set; }

        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
    }
}
