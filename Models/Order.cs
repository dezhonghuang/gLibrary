using gLibrary.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace gLibrary.Models
{
    public enum DishStatus
    {
        Cancelled, Ordered, Preparing, Cooking, Filled
    }

    public enum OrderStatus
    {
        Cancelled, Ordered, Preparing, Cooking, Filled, Paid
    }

    public class Order
    {
        decimal _total;

        private UnitOfWork _unitOfWork = new UnitOfWork();

        public Order()
        {
            OrderDateTime = DateTime.Now;
            _total = 0;
            Status = OrderStatus.Ordered;
        }

        public int Id { get; set; }
        public DateTime OrderDateTime { get; set; }
        public int RestaurantId { get; set; }
        public int TableId { get; set; }
        public decimal Total
        {
            get
            {
                decimal? total = (from orderDetails in _unitOfWork.GetRepository<OrderDetail>().Get()
                                    where orderDetails.OrderId == this.Id
                                    select orderDetails.Quantity * orderDetails.Price).Sum();

                return total ?? decimal.Zero;
            }
            set
            {
                this._total = value;
            }
        }
        public OrderStatus Status { get; set; }

        public ICollection<OrderDetail> OrderDetails { get; set; }
        public virtual Table Table { get; set; }
    }

    public class OrderDetail
    {
        public OrderDetail()
        {
            DishStatus = DishStatus.Ordered;
        }

        public int Id { get; set; }
        public int DishId { get; set; }
        //[Display(Name = "Qty")]
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public DishStatus DishStatus { get; set; }
        public int OrderId { get; set; }

        public virtual Dish Dish { get; set; }
        public virtual Order Order { get; set; }
    }
}
