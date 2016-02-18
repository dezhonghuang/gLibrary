using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

namespace gLibrary.Models
{
    class Location
    {
        public int Id { get; set; }
        public string Description { get; set; }
    }

    public class Table
    {
        [Key]
        [Display(Name="Table")]
        public int Id { get; set; }
        [Display(Name="Number")]
        public string TableNumber { get; set; }
        public int Seats { get; set; }
        [Display(Name="Restaurant")]
        public int RestaurantId { get; set; }

        public ICollection<Order> Orders { get; set; }
        public virtual Restaurant Restaurant { get; set; }
    }
}

