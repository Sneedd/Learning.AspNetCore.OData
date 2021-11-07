﻿using Learning.AspNetCore.OData.Entities;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

        [HttpGet]
        [EnableQuery]
        public IQueryable<Tentity> Get()
        {
            return this.DbContext.Set<Tentity>();
        }

        [HttpGet]
        [EnableQuery]
        public SingleResult<Tentity> Get([FromODataUri] int key)
        {
            return SingleResult.Create(this.DbContext.Set<Tentity>().Where(a => a.Id == key));
        }

        [HttpPost]
        public IActionResult Post(Tentity entity)
        {
            this.DbContext.Add(entity);
            this.DbContext.SaveChanges();
            return this.Created(entity);
        }

        [HttpPatch]
        public IActionResult Patch(int key, Delta<Tentity> delta)
        {
            Tentity entity = this.DbContext.Find<Tentity>(key);
            delta.CopyChangedValues(entity);
            this.DbContext.Update(entity);
            this.DbContext.SaveChanges();
            return this.Updated(entity);
        }

        [HttpDelete]
        public IActionResult Delete(Tentity entity)
        {
            this.DbContext.Remove(entity);
            this.DbContext.SaveChanges();
            return this.Delete(entity);
        }
    }
}