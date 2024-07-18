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