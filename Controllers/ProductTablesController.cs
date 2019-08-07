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
    public class ProductTablesController : ApiController
    {
        private ORMSITRONDbEntities db = new ORMSITRONDbEntities();

        // GET: api/ProductTables
        public IEnumerable<dynamic> GetProductTables()
        {
            var ProductList = db.ProductTables.Select(p=>new { p.ProductName, p.Prize, p.ProductID }).ToList();
            return ProductList;
        }

        // GET: api/ProductTables/5
        [ResponseType(typeof(ProductTable))]
        public IHttpActionResult GetProductTableByID(string id)
        {
            List<ProductTable> productTable = db.ProductTables.Where(c => c.CatagoryID == id).ToList();
            if (productTable == null)
            {
                return NotFound();
            }

            return Ok(productTable);
        }

        // PUT: api/ProductTables/5
        //[ResponseType(typeof(void))]
        //public IHttpActionResult PutProductTable(string id, ProductTable productTable)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id != productTable.ProductID)
        //    {
        //        return BadRequest();
        //    }

        //    db.Entry(productTable).State = EntityState.Modified;

        //    try
        //    {
        //        db.SaveChanges();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!ProductTableExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return StatusCode(HttpStatusCode.NoContent);
        //}

        // POST: api/ProductTables
        //[ResponseType(typeof(ProductTable))]
        //public IHttpActionResult PostProductTable(ProductTable productTable)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    db.ProductTables.Add(productTable);

        //    try
        //    {
        //        db.SaveChanges();
        //    }
        //    catch (DbUpdateException)
        //    {
        //        if (ProductTableExists(productTable.ProductID))
        //        {
        //            return Conflict();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return CreatedAtRoute("DefaultApi", new { id = productTable.ProductID }, productTable);
        //}

        //// DELETE: api/ProductTables/5
        //[ResponseType(typeof(ProductTable))]
        //public IHttpActionResult DeleteProductTable(string id)
        //{
        //    ProductTable productTable = db.ProductTables.Find(id);
        //    if (productTable == null)
        //    {
        //        return NotFound();
        //    }

        //    db.ProductTables.Remove(productTable);
        //    db.SaveChanges();

        //    return Ok(productTable);
        //}

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}

        //private bool ProductTableExists(string id)
        //{
        //    return db.ProductTables.Count(e => e.ProductID == id) > 0;
        //}
    }
}