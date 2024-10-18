// Hospital Information Management System Business Layer

using HospitalIMSData;
using HospitalIMSModels;
using System;
using System.Collections.Generic;

namespace HospitalIMSServices
{
    public class Services
    {
        public DataServices dataServices = DataServices.GetDataService();
        static Doctor? currentDoctor = null;
        static Nurse? currentNurse = null;
        static bool isLogin = false;

        public enum UserType
        {
            Doctor,
            Nurse,
            Invalid
        }

        public string makeAppointmentMessage(Patient patient, Doctor doctor, String date, String time, String service)
        {
            string template = """
                        <p>Dear {0},</p><br>
                        <p>
                            Thanks for getting in touch with Pedro Grace Hospital. 
                            This is a confirmation email regarding your appointment. The details are as follows:
                        </p><br>

                        <p>Date: {1}</p>
                        <p>Time: {2}</p>
                        <p>Provider: Doctor {3}</p>
                        <p>Service: {4}</p><br>

                        <p>
                            Please arrive 15 minutes early and bring your identification and insurance card if required.
                            If you need to cancel or reschedule, please call us at +63 912 345 6789 at least 24 hours before this appointment.
                        </p><br>
                        <p>Please don't hesitate to reach out if you have any questions or concerns. We look forward to seeing you!</p><br>

                        <p>Sincerely,</p>
                        <p>Doctor {3}</p>
                        <p>Hospital {5}</p>
                        <p>{6}</p>
                        <p>+63 912 345 6789</p>
                        <p>Pedro Grace Hospital</p>

                """;

            string style = "<style>p{margin:0}</style>";
            return style + String.Format(
                template, patient.name, date, time, doctor.name, service, doctor.type, doctor.username + "@pedrogracehospital.com");
        }

        public UserType VerifyUser(string username, string password)
        {
            Doctor? doctor = dataServices.GetDoctor(username, password);
            Nurse? nurse = dataServices.GetNurse(username, password);

            if (doctor != null)
            {
                currentDoctor = doctor;
                isLogin = true;
                return UserType.Doctor;
            } 
            else if (nurse != null)
            {
                currentNurse = nurse;
                isLogin = true;
                return UserType.Nurse;
            }
            {
                isLogin = false;
                return UserType.Invalid;
            }
        }

        public string GetName()
        {
            string name = "";
            if (isLogin)
            {
                if (currentDoctor != null)
                {
                    name = currentDoctor.name;
                }
                else if (currentNurse != null) {
                    name = currentNurse.name;
                }
            }  
            return name;
        }

        public Doctor? GetDoctor()
        {
            return currentDoctor;
        }

        public Nurse? GetNurse()
        {
            return currentNurse;
        }

        public char CurrentUserType()
        {
            char userType = '0';
            if (currentDoctor != null)
            {
                userType = 'D';
            }
            else if (currentNurse != null)
            {
                userType = 'N';
            }
            return userType;
        }

        public bool RemoveMedication(string medicationId)
        {
            int id;
            List<Medication> medications = dataServices.GetMedications();
            if (Int32.TryParse(medicationId, out id))
            {
                foreach (Medication medication in medications)
                {
                    if (medication.id == id)
                    {
                        dataServices.RemoveMedication(medication);
                        return true;
                    }
                }
            }
            return false;
        }

        public List<Prescription> GetPrescriptions()
        {
            List<Prescription> collected = new List<Prescription>();
            foreach (Prescription prescription in dataServices.GetPrescriptions())
            {
                if (prescription.doctor == currentDoctor)
                {
                    collected.Add(prescription);
                }
            }
            return collected;
        }

        public List<Medication> GetMedications()
        {
            return dataServices.GetMedications();
        }

        public bool AddMedication(
            string tradeName,
            string genericName,
            string manufacturer,
            string dosageStrength,
            string quantity,
            string startDateTime,
            string endDateTime
        )
        {
            int intQuantity;
            try
            {
                DateTime dtStart = DateTime.Parse(startDateTime);
                DateTime dtEnd = DateTime.Parse(startDateTime);
                if (int.TryParse(quantity, out intQuantity))
                {
                    List<Medication> medications = dataServices.GetMedications();
                    dataServices.AddMedication(new Medication
                    {
                        id = medications.Count + 1,
                        tradeName = tradeName, 
                        genericName = genericName, 
                        dosageStrength = dosageStrength, 
                        endTimeDrugTaken = dtEnd, 
                        manufacturer = manufacturer, 
                        quantity = intQuantity, 
                        startTimeDrugTaken = dtStart
                    });
                    return true;
                }
            }
            catch (System.FormatException)
            {
                return false;
            }
            return false;

        }
    }
}