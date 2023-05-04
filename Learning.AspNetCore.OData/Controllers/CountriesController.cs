using Learning.AspNetCore.OData.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Learning.AspNetCore.OData.Controllers
{
    public class CountriesController : ODataEntityControllerBase<Country>
    {
        public CountriesController(EntityDbContext context) 
            : base(context)
        {
        }
    }
}
