using HospitalIMSServices;
using HospitalIMSModels;
using Microsoft.AspNetCore.Mvc;

namespace HospitalIMSAPI.Controllers
{
    [ApiController]
    [Route("api/doctor")]
    public class DoctorController : Controller
    {
        DoctorServices _doctorGetServices;

        public DoctorController()
        {
            _doctorGetServices = new DoctorServices();
        }

        [HttpGet]
        public List<Doctor> GetDoctors()
        {
            var activeusers = _doctorGetServices.GetDoctorsByStatus(1);

            List<Doctor> users = new List<Doctor>();

            foreach (var item in activeusers)
            {
                users.Add(new Doctor {
                    id = item.id,
                    name = item.name,
                    sex = item.sex,
                    address = item.address,
                    phoneNumber1 = item.phoneNumber1,
                    phoneNumber2 = item.phoneNumber2,
                    birthday = item.birthday,
                    age = item.age,
                    type = item.type,
                    licenseNo = item.licenseNo,
                    signature = item.signature,
                    username = item.username, 
                    password = item.password, 
                    status = item.status 
                });
            }

            return users;
        }

        [HttpPost]
        public JsonResult AddDoctor(Doctor request)
        {
            var result = _doctorGetServices.AddDoctor(request);
            return new JsonResult(result);
        }

        [HttpPatch]
        public JsonResult UpdateDoctor(Doctor request)
        {
            var result = _doctorGetServices.UpdateDoctor(request);
            return new JsonResult(result);
        }

        [HttpDelete]
        public JsonResult DeleteDoctor(int id)
        {
            var result = _doctorGetServices.DeleteDoctor(id);
            return new JsonResult(result);
        }
    }
}
