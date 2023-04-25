using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System;
using System.Text;
using System.Collections.Specialized;

namespace ContactReportAPI.Helper
{
    public static class RestHelper
    {
        public static async Task<HttpResponseMessage> GetRequestAsync(string url, HttpRequestMessage Query = null)
        {
            try
            {
                HttpResponseMessage response;
                using (HttpClient client = new HttpClient())
                {
                    if (Query != null)
                    {
                         response = await client.GetAsync(url + Query.RequestUri.Query);

                    }
                    else
                    {
                        response = await client.GetAsync(url);
                    }

                    if (response.IsSuccessStatusCode)
                    {
                        Console.Write("Success");
                    }
                    else
                    {
                        Console.Write("Failure");
                    }

                    return response;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public static async Task PostRequestAsync(string url,string model)
        {
            using (HttpClient client = new HttpClient())
            {
                HttpContent content = new StringContent(model);
                HttpResponseMessage response = await client.PostAsync(url, content);

                if (response.IsSuccessStatusCode)
                {
                    // Data sent successfully
                }
                else
                {
                    // Error sending data
                }
            }
        }
    }
}
