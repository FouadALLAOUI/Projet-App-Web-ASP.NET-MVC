using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Projet_RIO71_app.Models
{
    public class Search
    {
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Display(Name = "Prix Minimale")]
        public int MinPrix { get; set; }

        [Display(Name = "Prix Maximale")]
        public int MaxPrix { get; set; }
    }
}