using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace Learning.OData.Client
{
    public static class ServiceHelper
    {
        public static void WaitUntilReady(Uri baseUri)
        {
            HttpClient httpClient = new HttpClient();
            httpClient.Timeout = TimeSpan.FromSeconds(60.0);
            while (true)
            {
                HttpResponseMessage response = httpClient.GetAsync(baseUri.AbsoluteUri).Result;
                if (response.IsSuccessStatusCode)
                {
                    break;
                }
            }
        }
    }
}
