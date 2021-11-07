using Default;
using System;
using System.Linq;

namespace Learning.OData.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            Container container = new Container(new Uri("http://localhost:5000"));
            var result = container.Continent.Where(a => a.Name.StartsWith("A")).ToList();

            Console.WriteLine("Hello World!");
        }
    }
}
