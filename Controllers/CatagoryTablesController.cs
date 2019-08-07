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
    public class CatagoryTablesController : ApiController
    {
        private ORMSITRONDbEntities db = new ORMSITRONDbEntities();

        // GET: api/CatagoryTables
        public IQueryable<CatagoryTable> GetCatagoryTables()
        {
            return db.CatagoryTables;
        }

        // GET: api/CatagoryTables/5
        [ResponseType(typeof(CatagoryTable))]
        public IHttpActionResult GetCatagoryTable(string id)
        {
            CatagoryTable catagoryTable = db.CatagoryTables.Find(id);
            if (catagoryTable == null)
            {
                return NotFound();
            }

            return Ok(catagoryTable);
        }

        // PUT: api/CatagoryTables/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCatagoryTable(string id, CatagoryTable catagoryTable)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != catagoryTable.CatagoryID)
            {
                return BadRequest();
            }

            db.Entry(catagoryTable).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CatagoryTableExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/CatagoryTables
        [ResponseType(typeof(CatagoryTable))]
        public IHttpActionResult PostCatagoryTable(CatagoryTable catagoryTable)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.CatagoryTables.Add(catagoryTable);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (CatagoryTableExists(catagoryTable.CatagoryID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = catagoryTable.CatagoryID }, catagoryTable);
        }

        // DELETE: api/CatagoryTables/5
        [ResponseType(typeof(CatagoryTable))]
        public IHttpActionResult DeleteCatagoryTable(string id)
        {
            CatagoryTable catagoryTable = db.CatagoryTables.Find(id);
            if (catagoryTable == null)
            {
                return NotFound();
            }

            db.CatagoryTables.Remove(catagoryTable);
            db.SaveChanges();

            return Ok(catagoryTable);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CatagoryTableExists(string id)
        {
            return db.CatagoryTables.Count(e => e.CatagoryID == id) > 0;
        }
    }
}