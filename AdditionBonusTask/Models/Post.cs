using AdditionBonusTask.Areas.Identity.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AdditionBonusTask.Models
{
    public class Post
    {
        public int Id { get; set; }

        [StringLength(60, MinimumLength = 3)]
        public string PostText { get; set; }

        [StringLength(60, MinimumLength = 3)]
        public string PostImage { get; set; }

        [Display(Name = "Public Date")]
        [DataType(DataType.Date)]
        public DateTime PublicDate { get; set; }

        public string UserId { get; set; }
        public ApplicationUser User { get; set; }

        public ICollection<Comment> Comments { get; set; }
    }
}
