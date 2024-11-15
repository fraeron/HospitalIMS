using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using HospitalIMSWeb;
using Newtonsoft.Json;
using HospitalIMSModels;
using HospitalIMSServices;

namespace HospitalIMSWeb.Controllers
{
    public class DoctorController : Controller
    {
        private string ApiUrl = "https://localhost:7109/api/patient";
        PatientServices services = new PatientServices();

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
            return View(id);
        }

        // GET: DoctorController/SendEmail
        public ActionResult SendEmail(int id)
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SendEmail(Patient patient, string subject, 
            string date, string time, string service)
        {
            // For some reason, sending using inputs then accepting it as strings in this function allows it.
            try
            {
                services.SendEmail(patient.id.ToString(), subject, date, time, service);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
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
