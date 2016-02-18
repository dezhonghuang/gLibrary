using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using gLibrary.Models;
using gLibrary.DAL;

namespace gLibrary.ViewModels
{
    public class DishViewModel
    {
        public Dish Dish { get; set; }
        public int Quantity { get; set; }
        public bool Ticked { get; set; }
    }

    public class OrderViewModel
    {
        public int OrderId { get; set; }
        public int RestaurantId { get; set; }
        public int TableId { get; set; }
        public IList<DishViewModel> Dishes { get; set; }
        //public decimal OrderTotal { get; set; }
    }

    public class OrderListModel
    {
        public Order Order { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }
    }
}
