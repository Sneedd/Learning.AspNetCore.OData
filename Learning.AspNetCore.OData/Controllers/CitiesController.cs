using Learning.AspNetCore.OData.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Learning.AspNetCore.OData.Controllers
{
    public class CitiesController : ODataEntityControllerBase<City>
    {
        public CitiesController(EntityDbContext context) 
            : base(context)
        {
        }
    }
}
