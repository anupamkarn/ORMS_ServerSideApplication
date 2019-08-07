using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ORMS_WebService.Models
{
    public class CartOrderDetails
    {
        public List<OrderProductLineForCart> ListOfProductsInCart { get; set; }
        public int DiscountedAmount { get { return ListOfProductsInCart.Sum(c => c.DiscountRate); } }
        public int TotalCartAmount { get { return ListOfProductsInCart.Sum(c => c.TotalAmount); } }
    }
    public class OrderProductLineForCart
    {
        public int Quantity { get; set; }
        public int Rate { get; set; }
        public int DiscountRate { get; set; }
        public int DiscountAmount { get { return (GrossAmount * DiscountRate) / 100; } }
        public int GrossAmount { get { return Quantity * Rate; } }
        public int TotalAmount { get { return GrossAmount - DiscountAmount; } }
    }
}