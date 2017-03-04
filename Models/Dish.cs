using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

namespace gLibrary.Models
{
    public enum MenuType
    {
        SingleTextual, BilingualTextual, SingleGraphical, BilingualGraphical
    }

    public class Dish
    {
        public Dish() {
            CategoryId = gMnts.DefaultDishCategory;
        }

        [Key]
        public int Id { get; set; }
        public Bilingual Bilingual { get; set; }
        public string Introduction { get; set; }
        [Display(Name = "Picture")]
        public string DishImage { get; set; }
        public string ImageFolder { get { return String.Format(gMnts.RestaurantFolder + RestaurantId.ToString() + gMnts.DishFolder); } }
        public string ThumbFolder { get { return String.Format(gMnts.RestaurantFolder + RestaurantId.ToString() + gMnts.DishFolder + gMnts.ThumbFolder); } }

        public string PartialPage
        {
            get { 
                bool i, l;

                i = this.DishImage.Length > 0;
                l = this.Bilingual.AlienName.Length > 0;

                string pType = Convert.ToInt32(l).ToString() + Convert.ToInt32(i).ToString();

                MenuType pageValue = (MenuType)Convert.ToInt32(pType, 2);

                return (pageValue.ToString());
            }
        }
            
        public void UploadImage(HttpPostedFileBase file, string imagePath)
        {
            this.DishImage = Path.GetFileName(file.FileName);
            Directory.CreateDirectory(imagePath);
            file.SaveAs(imagePath + this.DishImage);

            //create thumbnail
            Image image = Image.FromFile(imagePath + this.DishImage);
            int tWidth = gMnts.ThumbWidth;
            if (tWidth > image.Width)
                tWidth = image.Width;

            int tHeight = Convert.ToInt32((float)tWidth / (float)image.Width * image.Height);
            if (tHeight > 0)
            {
                Image thumb = image.GetThumbnailImage(tWidth, tHeight, () => false, IntPtr.Zero);
                Directory.CreateDirectory(imagePath + gMnts.ThumbFolder);
                thumb.Save(imagePath + gMnts.ThumbFolder + this.DishImage);
            }
        }

        //[DisplayFormat(DataFormatString="{0:c2}")]
        public decimal Price { get; set; }
        [Display(Name="Category")]
        public int CategoryId { get; set; }
        [Display(Name = "Restaurant")]
        public int RestaurantId { get; set; }

        public virtual Category Category { get; set; }
        public virtual Restaurant Restaurant { get; set; }
    }
}