// Hospital Information Management System Business Layer

using HospitalIMSDL;
using HospitalIMSModels;
using System;
using System.Collections.Generic;

namespace HospitalIMSBL
{
    public class Services
    {
        static DataServices dataServices = new DataServices();
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

        public bool AddPatient(
            string name,
            string sex,
            string age,
            string birthday,
            string weightKg,
            string heightFt,
            string phoneNumber1,
            string phoneNumber2,
            string address)
        {
            byte bAge;
            char cSex;
            double dWeightKg;
            double dHeightFt;
            long lPhoneNumber1;
            long lPhoneNumber2;
            try
            {
                DateTime dtBirthday = DateTime.Parse(birthday);
                if (sex.Length == 1 && (sex[0] == 'M' || sex[0] == 'F'))
                {
                    cSex = sex[0];
                    if (byte.TryParse(age, out bAge))
                    {
                        if (double.TryParse(weightKg, out dWeightKg))
                        {
                            if (double.TryParse(heightFt, out dHeightFt))
                            {
                                if (long.TryParse(phoneNumber1, out lPhoneNumber1))
                                {
                                    if (long.TryParse(phoneNumber2, out lPhoneNumber2))
                                    {
                                        List<Patient> patients = dataServices.GetPatients();
                                        dataServices.AddPatient(new Patient
                                        {
                                            id = patients.Count + 1,
                                            name = name,
                                            sex = cSex,
                                            age = bAge,
                                            birthday = dtBirthday,
                                            weightKg = dWeightKg,
                                            heightFt = dHeightFt,
                                            phoneNumber1 = lPhoneNumber1,
                                            phoneNumber2 = lPhoneNumber2,
                                            address = address
                                        });
                                        return true;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (System.FormatException)
            {
                return false;
            }
            return false;
            
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