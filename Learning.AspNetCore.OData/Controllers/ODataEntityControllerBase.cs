using System.IO;
using System.Linq;
using Learning.AspNetCore.OData.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Deltas;
using Microsoft.AspNetCore.OData.Formatter;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Results;
using Microsoft.AspNetCore.OData.Routing.Controllers;

namespace Learning.AspNetCore.OData.Controllers
{
    public abstract class ODataEntityControllerBase<Tentity> : ODataController
        where Tentity : class, IEntity
    {
        protected EntityDbContext DbContext { get; }

        protected ODataEntityControllerBase(EntityDbContext context)
        {
            this.DbContext = context;
        }

        //[HttpGet]
        [EnableQuery]
        public IQueryable<Tentity> Get()
        {
            return this.DbContext.Set<Tentity>();
        }

        //[HttpGet]
        [EnableQuery]
        public SingleResult<Tentity> Get([FromODataUri] int key)
        {
            return SingleResult.Create(this.DbContext.Set<Tentity>().Where(a => a.Id == key));
        }

        [HttpPost]
        public IActionResult Post([FromBody] Tentity entity)
        {
            if (entity.Id == 0)
            {
                entity.Id = this.DbContext.Set<Tentity>().Max(a => a.Id) + 1;
            }
            this.DbContext.Add(entity);
            this.DbContext.SaveChanges();
            return this.Created(entity);
        }

        [HttpPatch]
        public IActionResult Patch([FromODataUri] int key, Delta<Tentity> delta)
        {
            Tentity entity = this.DbContext.Find<Tentity>(key);
            delta.CopyChangedValues(entity);
            this.DbContext.Update(entity);
            this.DbContext.SaveChanges();
            return this.Updated(entity);
        }

        [HttpPut]
        public IActionResult Put([FromODataUri] int key, [FromBody] Tentity entity)
        {
            this.DbContext.Update(entity);
            this.DbContext.SaveChanges();
            return this.Updated(entity);
        }

        [HttpDelete]
        public IActionResult Delete([FromBody] Tentity entity)
        {
            this.DbContext.Remove(entity);
            this.DbContext.SaveChanges();
            return this.Delete(entity);
        }
    }
}
