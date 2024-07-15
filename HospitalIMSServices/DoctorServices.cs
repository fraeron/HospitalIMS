using HospitalIMSData;
using HospitalIMSModels;
using System;
using System.Collections.Generic;

namespace HospitalIMSServices
{
    public class DoctorServices 
    {
        static DataServices dataServices = new DataServices();
        private List<Doctor> doctors = new List<Doctor>();

        public List<Doctor> GetAllDoctors()
        {
            DataServices dataService = new DataServices();
            return dataService.GetDoctors();
        }

        public List<Doctor> GetDoctorsByStatus(int status)
        {
            List<Doctor> doctorsByStatus = new List<Doctor>();

            foreach (var user in GetAllDoctors())
            {
                if (user.status == status)
                {
                    doctorsByStatus.Add(user);
                }
            }

            return doctorsByStatus;
        }

        public Boolean AddDoctor(Doctor doctor)
        {
            return true;
        }

        public Boolean UpdateDoctor(Doctor doctor)
        {
            return true;
        }

        public Boolean DeleteDoctor(int id)
        {
            foreach (var doctor in GetAllDoctors())
            {
                if (doctor.id == id)
                {
                    doctors.Remove(doctor);
                }
            }
            return true;
        }
    }
}