using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AdditionBonusTask.Models
{
    public class InputModel
    {
        [Required]
        public string Slug { get; set; }

        public InputModel(string slug)
        {
            Slug = slug;
        }
    }
}
