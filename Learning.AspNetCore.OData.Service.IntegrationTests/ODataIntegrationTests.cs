using System.Net;
using System.Net.Http.Json;
using Learning.AspNetCore.OData.Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;

namespace Learning.AspNetCore.OData.Service.IntegrationTests
{
    [TestClass]
    public class ODataIntegrationTests
    {
        private WebApplicationFactory<Startup> _factory;

        [TestInitialize]
        public void Setup()
        {
            _factory = new WebApplicationFactory<Startup>();
        }

        [TestCleanup]
        public void Cleanup()
        {
            _factory?.Dispose();
        }

        [TestMethod]
        public async Task CreateAndQueryAsync()
        {
            using (var client = _factory.CreateClient())
            {
                var response = await client.PostAsync("/odata/Countries", JsonContent.Create(new Country
                {
                    Id = 1,
                    Name = "Spain",
                }));
                Assert.AreEqual(HttpStatusCode.Created, response.StatusCode);

                response = await client.PostAsync("/odata/Countries", JsonContent.Create(new Country
                {
                    Id = 2,
                    Name = "Germany",
                }));
                Assert.AreEqual(HttpStatusCode.Created, response.StatusCode);

                response = await client.GetAsync("/odata/Countries?$OrderBy=Name");
                Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);

                var stringResult = await response.Content.ReadAsStringAsync();
                var queryResult = await response.Content.ReadFromJsonAsync<ODataQueryResult<Country>>();
                Assert.AreEqual(2, queryResult.Items.Count);
                Assert.AreEqual("Germany", queryResult.Items[0].Name);
                Assert.AreEqual("Spain", queryResult.Items[1].Name);
            }
        }
    }
}