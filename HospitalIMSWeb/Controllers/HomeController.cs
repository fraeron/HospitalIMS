using HospitalIMSWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;

namespace HospitalIMSWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            Cat cat = new Cat();
            // Cataas API.
            string APIURL = "https://cataas.com/cat?json=true";
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(APIURL);

                var result = await response.Content.ReadAsStringAsync();
                cat = JsonConvert.DeserializeObject<Cat>(result);
            }

            return View(cat);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
