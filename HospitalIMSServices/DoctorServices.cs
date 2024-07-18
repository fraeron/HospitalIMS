using HospitalIMSData;
using HospitalIMSModels;
using System;
using System.Collections.Generic;

namespace HospitalIMSServices
{
    public class DoctorServices 
    {
        DataServices dataServices;
        public List<Doctor> doctors;

        public DoctorServices() {
            dataServices = DataServices.GetDataService();
            doctors = dataServices.GetDoctors();
        }

        public IEnumerable<Doctor> GetAllDoctors()
        {
            return dataServices.GetDoctors();
        }

        public bool AddDoctor(Doctor doctor)
        {
            return dataServices.AddDoctor(doctor);
        }

        public bool UpdateDoctor(Doctor doctor)
        {
            return dataServices.UpdateDoctor(doctor);
        }

        public bool DeleteDoctor(int id)
        {
            bool result = false;
            foreach (var doctor in GetAllDoctors())
            {
                if (doctor.id == id)
                {
                    result = dataServices.RemoveDoctor(doctor);
                }
            }
            return result;
        }
    }
}