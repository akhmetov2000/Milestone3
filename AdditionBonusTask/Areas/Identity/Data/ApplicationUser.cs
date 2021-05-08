using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using AdditionBonusTask.Models;
using Microsoft.AspNetCore.Identity;

namespace AdditionBonusTask.Areas.Identity.Data
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        [PersonalData]
        [Column(TypeName="nvarchar(100)")]
        public String FirstName { get; set; }

        [PersonalData]
        [Column(TypeName = "nvarchar(100)")]
        public String LastName { get; set; }

        public ICollection<Post> Posts { get; set; }

        public Message Messages { get; set; }
        public Dialog Dialogs { get; set; }
        //public Friend Friends { get; set; }
        public Person Persons { get; set; }
        public ICollection<Comment> Comments { get; set; }
    }
}
