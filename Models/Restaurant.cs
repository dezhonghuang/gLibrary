using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Drawing;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;
using System.IO;

namespace gLibrary.Models
{
    public class Restaurant
    {
        public Restaurant()
        {
            Logo = gMnts.LogoDefault;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Range(0, int.MaxValue, ErrorMessage="Please enter a number bigger than 0")]
        [DisplayFormat(DataFormatString="{0:00000}")]
        public int Id { get; set; }
        public Bilingual Bilingual { get; set; }
        [ForeignKey("Address")]
        public int? AddressId { get; set; }
        public string Phone { get; set; }
        public string Logo { get; set; }
        public string LogoFolder { get { return String.Format(gMnts.RestaurantFolder + Id.ToString() + gMnts.LogoFolder); } }

        public void UploadLogo(HttpPostedFileBase file, string logoPath)
        {
            this.Logo = Path.GetFileName(file.FileName);
            Directory.CreateDirectory(logoPath);
            file.SaveAs(logoPath + this.Logo);
        }

        public virtual ICollection<Dish> Dishes { get; set; }
        public virtual ICollection<Category> Categories { get; set; }
        public virtual Address Address { get; set; }
    }

    public class QRModel
    {
        public int Rid { get; set; }
        [Display(Name = "Table")]
        public int Tid{ get; set; }

        [Display(Name="Restaurant")]
        public string RestaurantName { get; set; }

        public string Encrypt() {
            string output = "";

            char[] charArray = Rid.ToString("00000").ToArray();
            for (int i = 0; i < charArray.Length; i++)
            {
                int c = Convert.ToInt32(charArray[i]) + 9;
                string s = Convert.ToChar(c).ToString();
                output += s;
            }

            return output;
        }

        public int Decrypt(string input)
        {
            string output = "";
            char[] charArray = input.ToCharArray();

            for (int i = 0; i < charArray.Length; i++)
            {
                int c = Convert.ToInt32(charArray[i]) - 9;
                string s = Convert.ToChar(c).ToString();
                output += s;
            }

            return Convert.ToInt32(output) + 0;
        }
    }
}