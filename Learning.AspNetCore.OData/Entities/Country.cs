using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Learning.AspNetCore.OData.Entities
{
    [Table("Countries")]
    public class Country : IEntity
    {
        [Key, Column("Id")]
        public int Id { get; set; }

        [Column("Name")]
        [JsonPropertyName("Name")]
        public string Name { get; set; }

        [Column("ContinentId")]
        public int ContinentId { get; set; }

        public Continent Continent { get; set; }

        public IList<City> Cities { get; set; }
    }
}
