using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using HospitalIMSWeb;
using Newtonsoft.Json;
using HospitalIMSModels;

namespace HospitalIMSWeb.Controllers
{
    public class DashboardController : Controller
    {
        private string ApiUrl = "https://localhost:7109/api/doctor";


        // GET: DoctorDashboardController
        public async Task<ActionResult> Index()
        {
            List<Doctor> users = new List<Doctor>();

            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(ApiUrl);

                var result = await response.Content.ReadAsStringAsync();
                users = JsonConvert.DeserializeObject<List<Doctor>>(result);
            }

            return View(users);
        }

        // GET: DoctorDashboardController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: DoctorDashboardController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DoctorDashboardController/Create
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

        // GET: DoctorDashboardController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: DoctorDashboardController/Edit/5
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

        // GET: DoctorDashboardController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: DoctorDashboardController/Delete/5
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
