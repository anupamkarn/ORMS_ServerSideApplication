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
    public class AuthenticationTablesController : ApiController
    {
        private ORMSITRONDbEntities db = new ORMSITRONDbEntities();

        //[ResponseType(typeof(UserTable))]
        //public IHttpActionResult GetUserTable(string UserName, string Password)
        //{
        //    UserTable user = db.UserTables.FirstOrDefault(c=>c.UserName==UserName);
        //    if (user == null)
        //    {
        //        return NotFound();
        //    }
        //    else
        //    {
        //        if (user.Password == Password)
        //        {
        //            return Ok();
        //        }
        //        else
        //        {
        //            return NotFound();
        //        }
        //    }
            
        //}

        // PUT: api/AuthenticationTables/5
        //[ResponseType(typeof(void))]
        //public IHttpActionResult PutUserTable(string id, UserTable userTable)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id != userTable.UserID)
        //    {
        //        return BadRequest();
        //    }

        //    db.Entry(userTable).State = EntityState.Modified;

            

        //    return StatusCode(HttpStatusCode.NoContent);
        //}

        // POST: api/AuthenticationTables
        // Login API for admin and customers
        public IHttpActionResult CreateCustomer(LoginInfo LoginData)
        {
            UserTable user = db.UserTables.FirstOrDefault(c=>c.UserName==LoginData.UserName && c.Password==LoginData.Password);
            if (user==null)
            {
                return Ok(new LoginStatus
                {
                    Status = 0,
                    Role = "",
                    CustomerID = "Not Avalable"
                });
            }
            else
            {
                CustomerTable Customer = db.CustomerTables.FirstOrDefault(c => c.UserID == user.UserID);
                if (Customer == null)
                {
                    return Ok(new LoginStatus
                    {
                        Status = 1,
                        Role = user.Role,
                        CustomerID = user.UserID
                    });
                }
                else
                {
                    return Ok(new LoginStatus
                    {
                        Status = 1,
                        Role = user.Role,
                        CustomerID = Customer.CustomerID
                    });
                }


        
            }
            
        }

       
    }
}