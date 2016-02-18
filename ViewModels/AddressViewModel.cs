using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using gLibrary.Models;
using System.ComponentModel.DataAnnotations;

namespace gLibrary.ViewModels
{
    public class AddressViewModel
    {
        public Restaurant Restaurant { get; set; }
        public Address Address { get; set; }
    }
}
