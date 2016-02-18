using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace gLibrary.Models
{
    public class GLAccount
    {
        [Key]
        public string Account { get; set; }
        public string Description { get; set; }
        public bool Active { get; set; }
    }

    public class GeneralLedger
    {
        public GeneralLedger()
        {
            PostingDateTime = DateTime.Now;
            Debits = 0;
            Credits = 0;
        }

        [Key]
        public int TransactionNumber { get; set; }
        public DateTime PostingDateTime { get; set; }
        public string Description { get; set; }
        public string GLAccount { get; set; }
        public decimal Debits { get; set; }
        public decimal Credits { get; set; }
    }
}
