using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using HospitalIMSWeb;
using Newtonsoft.Json;
using HospitalIMSModels;

namespace HospitalIMSWeb.Controllers
{
    public class DoctorController : Controller
    {
        private string ApiUrl = "https://localhost:7109/api/patient";


        // GET: DoctorController
        public async Task<ActionResult> Index(int id)
        {
            List<Patient> patients = new List<Patient>();

            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(ApiUrl);

                var result = await response.Content.ReadAsStringAsync();
                patients = JsonConvert.DeserializeObject<List<Patient>>(result);
            }

            return View(patients);
        }

        // GET: DoctorController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: DoctorController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DoctorController/Create
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

        // GET: DoctorController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: DoctorController/Edit/5
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

        // GET: DoctorController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: DoctorController/Delete/5
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
