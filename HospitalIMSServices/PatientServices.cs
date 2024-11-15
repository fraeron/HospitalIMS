using HospitalIMSData;
using HospitalIMSModels;
using System;
using System.Collections.Generic;

namespace HospitalIMSServices
{
    public class PatientServices
    {
        DataServices dataServices;
        public List<Patient> patients;
        public MailkitServices mimeService = new MailkitServices();
        public Services services = new Services();
        private AWSServices s3services = new AWSServices();

        public PatientServices()
        {
            dataServices = DataServices.GetDataService();
            patients = dataServices.GetPatients();
        }

        public List<Patient> GetPatients()
        {
            return dataServices.GetPatients();
        }


        public bool SendEmail(string patientId, string subject, string date, string time, string service)
        {
            try
            {
                // Fixed output for now.
                string result = mimeService.SendAppointmentAndReturnContent(
                    services.makeAppointmentMessage(
                            SearchPatient(patientId),
                            services.GetDoctor(),
                            date,
                            time,
                            service
                        ),
                    subject);

                // Save first to a local text file.
                // Ex. pattern of text file: 2001-01-24_12-59-24PM.txt
                string pattern = "yyyy-MM-dd_hh-mm-sstt";
                DateTime localDate = DateTime.Now;
                string fileName = localDate.ToString(pattern) + ".txt";
                string txtPath = services.SaveStringToTextFile(result, fileName);

                // Upload to AWS S3.
                s3services.uploadFile(txtPath);

                return true;
            } catch (Exception ex)
            {
                return false;
            }
            
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
