using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using HospitalIMSWeb;
using Newtonsoft.Json;
using HospitalIMSModels;
using HospitalIMSWeb.Models;

namespace HospitalIMSWeb.Controllers
{
    public class AdminController : Controller
    {
        private string DoctorApiUrl = "https://localhost:7109/api/doctor";
        private string CloudflareApiUrl = "https://speed.cloudflare.com/meta";


        // GET: AdminController
        public async Task<ActionResult> Index(int id)
        {
            List<Doctor> users = new List<Doctor>();

            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(DoctorApiUrl);

                var result = await response.Content.ReadAsStringAsync();
                users = JsonConvert.DeserializeObject<List<Doctor>>(result);
            }

            return View(users);
        }

        public async Task<ActionResult> Trace()
        {
            Cloudflare cloudflare = new Cloudflare();

            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(CloudflareApiUrl);

                var result = await response.Content.ReadAsStringAsync();
                cloudflare = JsonConvert.DeserializeObject<Cloudflare>(result);
            }
            return View(cloudflare);
        }

        // GET: AdminController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: AdminController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AdminController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AdminController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: AdminController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AdminController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AdminController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
