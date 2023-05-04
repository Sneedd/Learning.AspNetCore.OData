using Learning.AspNetCore.OData.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Learning.AspNetCore.OData.Controllers
{
    public class ContinentsController : ODataEntityControllerBase<Continent>
    {
        public ContinentsController(EntityDbContext context)
            : base(context)
        {
        }
    }
}
