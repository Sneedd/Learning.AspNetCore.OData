using Learning.OData.Entities;
using System;
using System.Linq;
using System.Net.Http;

namespace Learning.OData.Client
{
    public static class Program
    {
        private static void Main(string[] args)
        {
            Uri baseUri = new Uri("http://localhost:5000/odata");
            ServiceHelper.WaitUntilReady(baseUri);

            DeleteAll(baseUri);
            AddDefaultItems(baseUri);
            QueryEntities(baseUri);
        }

        private static void DeleteAll(Uri baseUri)
        {
            Container container = new Container(baseUri);

            var continents = container.Continent.Where(a => a.Id != 0).ToList();
            foreach (var continent in continents)
            {
                container.DeleteObject(continent);
            }

            container.SaveChanges();
        }

        private static void QueryEntities(Uri baseUri)
        {
            Container container = new Container(baseUri);
            var continents = container.Continent
                .Expand(a => a.Countries)
                .Where(a => a.Id != 0)
                .ToList();
        }



        private static void AddDefaultItems(Uri baseUri)
        {
            Container container = new Container(baseUri);

            Continent europe = new Continent
            {
                Name = "Europe"
            };
            container.AddToContinent(europe);
            container.SaveChanges();


            Country germany = new Country
            {
                Name = "Germany",
                ContinentId = europe.Id,
            };
            container.AddToCountry(germany);
            container.SaveChanges();
        }
    }
}
