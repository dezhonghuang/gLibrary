using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace gLibrary.Models
{
    public class Country
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<State> States { get; set; }
    }

    public class State
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CountryId { get; set; }

        public virtual ICollection<City> Cities { get; set; }
    }

    public class City
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int StateId { get; set; }

        public virtual ICollection<Suburb> Suburbs { get; set; }
    }

    public class Suburb
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CityId { get; set; }

        public virtual ICollection<Street> Streets { get; set; }
    }

    public class Street
    {
        public Street()
        {
            NoRange = new NoRange();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public NoRange NoRange { get; set; }
        public string PostCode { get; set; }
        public int SuburbId { get; set; }
        public int CityId { get; set; }
        public int StateId { get; set; }
        public int CountryId { get; set; }

        public virtual Suburb Suburb { get; set; }
        public virtual City City { get; set; }
        public virtual State State { get; set; }
        public virtual Country Country { get; set; }
    }

    public class NoRange
    {
        public string RangeStart { get; set; }
        public string RangeEnd { get; set; }
    }

    public class Address
    {
        [Key]
        public int Id { get; set; }
        public string StreetNumber { get; set; }
        public int StreetId { get; set; }

        [ForeignKey("StreetId")]
        public virtual Street Street { get; set; }

        [Display(Name="Address")]
        public string FullAddress { 
            get {
                return (Street != null) ? StreetNumber + " " + Street.Name + " " + Street.PostCode : "";
            }
        }
    }
}