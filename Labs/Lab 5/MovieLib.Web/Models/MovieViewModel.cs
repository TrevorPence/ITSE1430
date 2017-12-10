using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MovieLib.Web.Models
{
    public class MovieViewModel
    {
        public int Id { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string Title { get; set; }

        public string Description { get; set; }

        [Range(0, Double.MaxValue)]
        public decimal Length { get; set; }

        public bool IsOwned { get; set; }
    }
}