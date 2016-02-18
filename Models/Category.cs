using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using System.ComponentModel.DataAnnotations.Schema;

namespace gLibrary.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        public Bilingual Bilingual { get; set; }
        public int RestaurantId { get; set; }

        public string Name
        {
            get { return Bilingual.Name; }
        }

        [ForeignKey("RestaurantId")]
        public virtual Restaurant Restaurant { get; set; }
        public virtual ICollection<Dish> Dishes { get; set; }
    }
}