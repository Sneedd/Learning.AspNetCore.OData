using Learning.AspNetCore.OData.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Learning.AspNetCore.OData.Controllers
{
    public class CountryController : ODataEntityControllerBase<Country>
    {
        public CountryController(EntityDbContext context) 
            : base(context)
        {
        }
    }
}
