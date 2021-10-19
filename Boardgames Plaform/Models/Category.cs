using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BoardgamePlatform.Models
{
    public class Category
    {
        [Key]
        public int CategoryID { get; set; }
        [Required]
        public String Name { get; set; }

        public string ImgPath { get; set; }
    }
}
