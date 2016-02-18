using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace gLibrary.Models
{
    public class User
    {
        public User()
        {
            CreateDate = DateTime.Now;
        }

        public int Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public int? RestaurantId { get; set; }
        public DateTime? CreateDate { get; set; }
        public string Comment { get; set; }
    }
}