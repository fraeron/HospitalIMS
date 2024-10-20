using HospitalIMSWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;

namespace HospitalIMSWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        // Init. variables for Cataas API.
        
        private string APIURL = "https://cataas.com/cat?json=true";

        public HomeController(ILogger<HomeController> logger)
        {
            
            _logger = logger;
        }

        public async Task<Cat> GetCat()
        {
            Cat cat = new Cat();
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(APIURL);
                var result = await response.Content.ReadAsStringAsync();
                cat = JsonConvert.DeserializeObject<Cat>(result);
            }
            return cat;
        }

        public async Task<IActionResult> Index()
        {
            return View(await GetCat());
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public async Task<IActionResult> Unfinished()
        {
            return View(await GetCat());
        }

        public async Task<IActionResult> About()
        {
            return View(await GetCat());
        }

        public IActionResult Contact()
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
