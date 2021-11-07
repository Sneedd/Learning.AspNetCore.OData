using Learning.AspNetCore.OData.Entities;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Learning.AspNetCore.OData.Controllers
{
    public class ContinentController : ODataEntityControllerBase<Continent>
    {
        public ContinentController(EntityDbContext context)
            : base(context)
        {
        }
    }
}
