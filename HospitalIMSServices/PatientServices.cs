using HospitalIMSData;
using HospitalIMSModels;
using System;
using System.Collections.Generic;

namespace HospitalIMSServices
{
    public class PatientServices
    {
        DataServices dataServices;

        public PatientServices() {
            dataServices = new DataServices();
        }

        public List<Patient> GetPatients()
        {
            return dataServices.GetPatients();
        }

        public Patient? SearchPatient(string givenId)
        {
            int id;
            Patient? foundPatient = null;
            List<Patient> patients = dataServices.GetPatients();
            if (Int32.TryParse(givenId, out id))
            {
                foreach (Patient patient in patients)
                {
                    if (patient.id == id)
                    {
                        foundPatient = patient;
                    }
                }
            }
            return foundPatient;
        }

        public bool RemovePatient(string patientId)
        {
            int id;
            List<Patient> patients = dataServices.GetPatients();
            if (Int32.TryParse(patientId, out id))
            {
                foreach (Patient patient in patients)
                {
                    if (patient.id == id)
                    {
                        dataServices.RemovePatient(patient);
                        return true;
                    }
                }
            }
            return false;
        }

        public bool UpdatePatient(Patient patient)
        {
            return dataServices.UpdatePatient(patient); ;
        }

        public bool AddPatient(Patient patient)
        {

            List<Patient> patients = dataServices.GetPatients();
            dataServices.AddPatient(new Patient
            {
                id = patients.Count + 1,
                name = patient.name,
                sex = patient.sex,
                age = patient.age,
                birthday = patient.birthday,
                weightKg = patient.weightKg,
                heightFt = patient.heightFt,
                phoneNumber1 = patient.phoneNumber1,
                phoneNumber2 = patient.phoneNumber2,
                address = patient.address
            });
            return true;
        }
    }
}
