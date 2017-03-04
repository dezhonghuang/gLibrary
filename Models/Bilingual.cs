using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace gLibrary.Models
{
    public abstract class Bilingual
    {
        [Required]
        public string Name { get; set; }
        [Display(Name="Name in Other Language")]
        public string AlienName { get; set; }

        public string FullName
        {
            get
            {
                return this.AlienName.Length > 0 ? this.Name + " " + this.AlienName : this.Name;
            }
        }
    }
}