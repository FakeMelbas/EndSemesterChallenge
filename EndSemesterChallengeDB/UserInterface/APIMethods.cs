using EndSemesterChallAPI.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace UserInterface
{
    public class APIMethods
    {
        public static async Task<List<TourEvent1>> FindTourEvents()
        {
            HttpClient client = new HttpClient();


            client.BaseAddress = new Uri("https://coffeeapi101.azurewebsites.net/api/");

            HttpResponseMessage httpResponseMessage = await client.GetAsync("TourEventsView");

            var posts = JsonConvert.DeserializeObject<List<TourEvent1>>(posts);

            return content;
        }
    }

}
