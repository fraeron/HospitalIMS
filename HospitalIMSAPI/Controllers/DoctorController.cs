using HospitalIMSServices;
using HospitalIMSModels;
using Microsoft.AspNetCore.Mvc;

namespace HospitalIMSAPI.Controllers
{
    [ApiController]
    [Route("api/doctor")]
    public class DoctorController : Controller
    {
        Services services;
        DoctorServices doctorServices;

        public DoctorController()
        {
            services = new Services();
            doctorServices = new DoctorServices();
        }

        [HttpGet]
        public IEnumerable<Doctor> GetDoctors()
        {
            return doctorServices.GetAllDoctors();
        }

        [HttpPost]
        public JsonResult AddDoctor(Doctor request)
        {
            var result = doctorServices.AddDoctor(request);
            return new JsonResult(result);
        }

        [HttpPatch]
        public JsonResult UpdateDoctor(Doctor request)
        {
            var result = doctorServices.UpdateDoctor(request);
            return new JsonResult(result);
        }

        [HttpDelete]
        public JsonResult DeleteDoctor(int id)
        {
            var result = doctorServices.DeleteDoctor(id);
            return new JsonResult(result);
        }
    }
}
