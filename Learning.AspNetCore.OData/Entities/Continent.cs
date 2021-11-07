using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Learning.AspNetCore.OData.Entities
{
    [Table("Continents")]
    public class Continent : IEntity
    {
        [Key, Column("Id")]
        public int Id { get; set; }

        [Column("Name")]
        public string Name { get; set; }

        public IList<Country> Countries { get; set; }
    }
}
