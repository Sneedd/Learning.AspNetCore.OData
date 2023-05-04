using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Learning.AspNetCore.OData.Service.IntegrationTests
{
    public class ODataQueryResult<Tentity>
    {
        [JsonPropertyName("@odata.context")]
        public string ODataMetadata { get; set; }

        [JsonPropertyName("value")]
        public List<Tentity> Items { get; set; }
    }
}
