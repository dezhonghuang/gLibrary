using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace gLibrary.Models
{
    public static class gMnts
    {
        //QR Code
        public const string QRCode = "http://www.gmenu.co.nz/Home/Order/";
        public const int QRCodeWidth = 300;
        public const int QRCodeHeight = 300;

        //Images
        public const string gMenuFolder = "gMenu/";
        public const string ImageFolder = "~/Images/";
        public const string DefaultFolder = "Default/";
        //public const string RestaurantFolder = "/Restaurants/";
        //public const string RestaurantDefault = "gMenuRestaurant.jpg";
        public const string DishFolder = "/Dishes/";
        public const string LogoFolder = "/Logo/";
        public const string LogoDefault = "gMenu.png";
        public const string DishDefault = "gMenuDish.jpg";
        public const string ThumbFolder = "Thumbnails/";

        //gMnt contants
        public const string RestaurantFolder = "~/Restaurants/";
        //gMenu contants
        //public const string RestaurantFolder = "http://mnt.gmenu.co.nz/Restaurants/";

        //Category
        public const string CategoryCategory = "Category";
        public const string CategoryId = "Id";
        public const string CategoryName = "Name";
        public const string CategoryAlienName = "AlienName";

        //Dish
        public const string DishDish = "Dish";
        public const string DishId = "Id";
        public const string DishName = "Name";
        public const string DishAlienName = "AlienName";
        public const string DishDescription = "Description";
        public const string DishCategoryId = "CategoryId";
        public const string DishImage = "Image";
        public const string DishPrice = "Price";
        public const int DefaultDishCategory = 9999;

        //Select list
        public const int NoSelection = 0;

        //Thumbnail Width
        public const int ThumbWidth = 80;

        //Excel columns
        public const long ExcelCity = 5;
        public const long ExcelSuburb = 4;
        public const long ExcelPostCode = 6;
        public const long ExcelStreet = 1;
        public const long ExcelNoRange = 2;
        public const string StreetNumber = "3";

        //Cookies
        public const string Cookie_SelectedDishs = "selectedDishes";

        //gMenu contact
        public const string gMenuContact = "http://gmenu.co.nz/Home/Contact";

        //tripleDES key prefix
        public const string TripleDesKeyPrefix = "NorthPark";
    }
}