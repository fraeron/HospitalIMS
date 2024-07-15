using HospitalIMSServices;
using HospitalIMSModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net;
using System.Xml.Linq;

namespace HospitalIMSAPI.Controllers
{
    [ApiController]
    [Route("api/patient")]
    public class PatientController : Controller
    {
        PatientServices _patientGetServices;

        public PatientController()
        {
            _patientGetServices = new PatientServices();
        }

        [HttpGet]
        public List<Patient> GetPatients()
        {
            var patients = _patientGetServices.GetPatients();

            List<Patient> patient = new List<Patient>();

            foreach (var item in patients)
            {
                patient.Add(new Patient
                {
                    id = item.id,
                    name = item.name,
                    sex = item.sex,
                    address = item.address,
                    phoneNumber1 = item.phoneNumber1,
                    phoneNumber2 = item.phoneNumber2,
                    birthday = item.birthday,
                    weightKg = item.weightKg,
                    heightFt = item.heightFt,
                    age = item.age
                });
            }

            return patients;
        }

        [HttpPost]
        public JsonResult AddPatient(Patient request)
        {
            var result = _patientGetServices.AddPatient(request);
            return new JsonResult(result);
        }

        [HttpPatch]
        public JsonResult UpdatePatient(Patient request)
        {
            var result = _patientGetServices.UpdatePatient(request);
            return new JsonResult(result);
        }

        [HttpDelete]
        public JsonResult DeletePatient(String id)
        {
            var result = _patientGetServices.RemovePatient(id);
            return new JsonResult(result);
        }
    }
}
