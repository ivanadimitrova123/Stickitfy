using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StickItFy.Models
{
    public class Sticker
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Image")]

        public string ImageUrl { get; set; }
        [Required]

        public string Category { get; set; }
        [Required]
        public string NameOfProduct { get; set; }

        public int Price { get; set; }

        public ICollection<Cart> Carts{ get; set; }

    }
}