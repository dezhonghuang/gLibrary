using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace gLibrary.Models
{
    public class Bilingual
    {
        public string Name { get; set; }
        [Display(Name="Alien Name")]
        public string AlienName { get; set; }
        public string OutputFormat { get; set; }

        public string FullName
        {
            get
            {
                if ((OutputFormat == String.Empty) || (OutputFormat == null))
                {
                    OutputFormat = "{0, 50} {1, 12}";
                }

                return String.Format(OutputFormat, Name, AlienName);
            }
        }
    }
}