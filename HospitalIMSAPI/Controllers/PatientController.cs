using HospitalIMSServices;
using HospitalIMSModels;
using Microsoft.AspNetCore.Mvc;

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
            return _patientGetServices.GetPatients();
        }

        [HttpPost("AddPatient")]
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

        [HttpPost("SendEmail")]
        public JsonResult SendEmail(Patient request, string subject, string date, string time, string service)
        {
            var result = _patientGetServices.SendEmail(request.id.ToString(), subject, date, time, service);
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
