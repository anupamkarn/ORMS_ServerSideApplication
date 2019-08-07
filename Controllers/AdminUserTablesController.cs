using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using ORMS_WebService.Models;

namespace ORMS_WebService.Controllers
{
    public class AdminUserTablesController : ApiController
    {
        private ORMSITRONDbEntities db = new ORMSITRONDbEntities();

        // GET: api/AdminUserTables
        //API for getting users
        public IEnumerable<dynamic> GetUserTables()
        {
            var Customers = db.CustomerTables.Select(c => new {
                customername = c.CustomerName,
                email = c.EmailID,
                status = c.Status,
                customerid =c.CustomerID,
                userid =c.UserID
            }).ToList();
            return Customers;
        }

        // GET: api/AdminUserTables/5
        //[ResponseType(typeof(UserTable))]
        //public IHttpActionResult GetUserTable(string id)
        //{
        //    UserTable userTable = db.UserTables.Find(id);
        //    if (userTable == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(userTable);
        //}

        // PUT: api/AdminUserTables/5
        // Updating every user status in complement value 
        [HttpPut]
        [ResponseType(typeof(void))]
        
        public IHttpActionResult PutCustomerStatus(string id, string status)
        {
            CustomerTable customer = db.CustomerTables.FirstOrDefault(c => c.CustomerID == id);
            if (customer.Status == "1")
            {
                customer.Status = "0";
            }
            else
            {
                customer.Status = "1";
            }
            db.SaveChanges();
            return Ok();
            //if (!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}

            //if (id != userTable.UserID)
            //{
            //    return BadRequest();
            //}

            //db.Entry(userTable).State = EntityState.Modified;

            //try
            //{
            //    db.SaveChanges();
            //}
            //catch (DbUpdateConcurrencyException)
            //{
            //    if (!UserTableExists(id))
            //    {
            //        return NotFound();
            //    }
            //    else
            //    {
            //        throw;
            //    }
            //}

            //return StatusCode(HttpStatusCode.NoContent);
        }

        //// POST: api/AdminUserTables
        //[ResponseType(typeof(UserTable))]
        //public IHttpActionResult PostUserTable(UserTable userTable)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    db.UserTables.Add(userTable);

        //    try
        //    {
        //        db.SaveChanges();
        //    }
        //    catch (DbUpdateException)
        //    {
        //        if (UserTableExists(userTable.UserID))
        //        {
        //            return Conflict();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return CreatedAtRoute("DefaultApi", new { id = userTable.UserID }, userTable);
        //}

        //// DELETE: api/AdminUserTables/5
        //[ResponseType(typeof(UserTable))]
        //public IHttpActionResult DeleteUserTable(string id)
        //{
        //    UserTable userTable = db.UserTables.Find(id);
        //    if (userTable == null)
        //    {
        //        return NotFound();
        //    }

        //    db.UserTables.Remove(userTable);
        //    db.SaveChanges();

        //    return Ok(userTable);
        //}

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}

        //private bool UserTableExists(string id)
        //{
        //    return db.UserTables.Count(e => e.UserID == id) > 0;
        //}
    }
}