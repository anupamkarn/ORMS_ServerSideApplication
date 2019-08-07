using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using ORMS_WebService.Models;

namespace ORMS_WebService.Controllers
{
    public class CustomerTablesController : ApiController
    {
        private ORMSITRONDbEntities db = new ORMSITRONDbEntities();

        // GET: api/CustomerTables
        // This APi is for counting number of items
        public int GetNumberOfItems(int i, string id)
        {
            int ItemQuantity = db.CartTables.Count(c => c.CustomerID == id);
            return ItemQuantity;
        }

           
        // GET: api/CustomerTables/5
        //This API is for getting products which are present in cart
        //[ResponseType(typeof(CustomerTable))]
        public Models.CartOrderDetails GetOrderDetailsFromCart(string id)
        {
            CartOrderDetails Cart = new CartOrderDetails();
            Cart.ListOfProductsInCart = new List<OrderProductLineForCart>();
            List<CartTable> CartProducts = db.CartTables.Where(c => c.CustomerID == id).ToList();
            foreach (var Product in CartProducts)
            {
                Cart.ListOfProductsInCart.Add(new OrderProductLineForCart { Rate = (int)Product.ProductTable.Prize, Quantity = Product.Quantity, DiscountRate = (int)Product.ProductTable.Discount });
            }

            return Cart;

        }

        // POST: api/CustomerTables/5/1/3
        //This API is for adding products to cart
        [ResponseType(typeof(void))]
        public IHttpActionResult PostAddProductsToCart(string id, int quantity, string ProID)
        {
            db.CartTables.Add(new CartTable {
                ProductID = ProID,
                CustomerID = id,
                Quantity = quantity,
                DateOfItemAdded = DateTime.Now
            });
            try
            {
                db.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                    }
                }
                throw;
            }
            return Ok(new {
                Status = "Product Added To cart"
            });
        }

        // POST: api/CustomerTables
        // This API will create an entry in order table after placing order
        [ResponseType(typeof(CustomerTable))]
        public IHttpActionResult PostCustomerTable(string id)
        {
            OrderTable Order = new OrderTable();
            CartOrderDetails cart = new CartOrderDetails();
            cart.ListOfProductsInCart = new List<OrderProductLineForCart>();

            List<CartTable> CartRows = db.CartTables.Where(c => c.CustomerID == id).ToList();

            foreach (CartTable CartItem in CartRows)
            {
                cart.ListOfProductsInCart.Add(new OrderProductLineForCart
                {
                    Quantity = CartItem.Quantity,
                    DiscountRate = (int)CartItem.ProductTable.Discount,
                    Rate = (int)CartItem.ProductTable.Prize
                });

                db.CartTables.Remove(CartItem);
            }
            Order.NetAmount = cart.TotalCartAmount;
            Order.CustomerID = id;
            Order.OrderDate = DateTime.Now;

            return Ok();
        }

        // DELETE: api/CustomerTables/5
        

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}

        //private bool CustomerTableExists(string id)
        //{
        //    return db.CustomerTables.Count(e => e.CustomerID == id) > 0;
        //}
    }
}