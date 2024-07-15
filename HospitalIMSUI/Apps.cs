using HospitalIMSServices;
using HospitalIMSModels;
using System;
using System.Collections.Generic;

namespace HospitalIMSUI
{
    public class Apps
    {
        public static PatientServices patientServices = new PatientServices();
        public Services services = new Services();
        public static Utils utils = new Utils();

        public string GetName()
        {
            return services.GetName();
        }

        public Services.UserType VerifyUser(string username, string password)
        {
            return services.VerifyUser(username, password);
        }

        public void AddNewPatient()
        {
            Console.Clear();
            utils.CreateBanner("ADD A NEW PATIENT");
            Console.WriteLine("[ADDPATIENT] WARNING. This will require the user to input multiple answers.");
            Console.WriteLine("[ADDPATIENT] Proceed? Type 'y' to continue.");
            string userProceed = Console.ReadLine() ?? "";
            if (userProceed == "y")
            {
                Console.Write("[ADDPATIENT] Enter patient's name: ");
                string name = Console.ReadLine() ?? "";
                Console.Write("[ADDPATIENT] Enter patient's sex (M/F): ");
                string sex = Console.ReadLine() ?? "";
                Console.Write("[ADDPATIENT] Enter patient's age: ");
                string age = Console.ReadLine() ?? "";
                Console.Write("[ADDPATIENT] Enter patient's birthday (MMM-DD-YYYY): ");
                string birthday = Console.ReadLine() ?? "";
                Console.Write("[ADDPATIENT] Enter patient's weight in kilograms: ");
                string weightKg = Console.ReadLine() ?? "";
                Console.Write("[ADDPATIENT] Enter patient's height in feet: ");
                string heightFt = Console.ReadLine() ?? "";
                Console.Write("[ADDPATIENT] Enter patient's 1st phone number: ");
                string phoneNumber1 = Console.ReadLine() ?? "";
                Console.Write("[ADDPATIENT] Enter patient's 2nd phone number (optional): ");
                string phoneNumber2 = Console.ReadLine() ?? "";
                Console.Write("[ADDPATIENT] Enter patient's address: ");
                string address = Console.ReadLine() ?? "";
                if (patientServices.AddPatient(
                    new Patient()
                    {
                        id = 0, // Any number here. Will be auto-filled.
                        name = name,
                        sex = sex,
                        age = age,
                        birthday = DateTime.Parse(birthday),
                        weightKg = weightKg,
                        heightFt = heightFt,
                        phoneNumber1 = phoneNumber1,
                        phoneNumber2 = phoneNumber2,
                        address = address
                    }))
                {
                    Console.WriteLine("[ADDPATIENT] Patient added successfully.");
                }
                else
                {
                    Console.WriteLine("[ADDPATIENT] Failed to add new patient. Please try again.");
                }
                utils.PressToConfirm();
            }

        }

        public void SearchForPatient()
        {
            Console.Clear();
            utils.CreateBanner("SEARCH FOR A PATIENT");
            Console.Write("[PATIENTSEARCH] Please enter Patient ID: ");
            string id = Console.ReadLine() ?? "";
            Patient? patient = patientServices.SearchPatient(id);
            if (patient == null)
            {
                Console.WriteLine("[PATIENTSEARCH] Sorry. This patient does not exist.");
            }
            else
            {
                Console.WriteLine(
                    $"""
                    PATIENT FOUND.

                    Patient Name: {patient.name}
                    Patient Weight (kg): {patient.weightKg}
                    Patient Height (ft): {patient.heightFt}
                    Patient Address: {patient.address}
                    Patient Phone Number #1: {patient.phoneNumber1}
                    Patient Phone Number #2: {patient.phoneNumber2}
                    """
                    );
            }
            utils.PressToConfirm();
        }

        public void AddMedication()
        {
            Console.Clear();
            utils.CreateBanner("ADD A NEW MEDICATION DATA");
            Console.WriteLine("[ADDMEDICINE] WARNING. This will require the user to input multiple answers.");
            Console.WriteLine("[ADDMEDICINE] Proceed? Type 'y' to continue.");
            string userProceed = Console.ReadLine() ?? "";
            if (userProceed == "y")
            {
                Console.Write("[ADDMEDICINE] Enter medicine's trade name: ");
                string tradeName = Console.ReadLine() ?? "";
                Console.Write("[ADDMEDICINE] Enter medicine's generic name: ");
                string genericName = Console.ReadLine() ?? "";
                Console.Write("[ADDMEDICINE] Enter medicine's manufacturer: ");
                string manufacturer = Console.ReadLine() ?? "";
                Console.Write("[ADDMEDICINE] Enter medicine's dosage strength: ");
                string dosageStrength = Console.ReadLine() ?? "";
                Console.Write("[ADDMEDICINE] Enter medicine's quantity: ");
                string quantity = Console.ReadLine() ?? "";
                Console.Write("[ADDMEDICINE] Enter medicine's start date and time to be taken: ");
                string startDateTime = Console.ReadLine() ?? "";
                Console.Write("[ADDMEDICINE] Enter medicine's end date and time to be taken: ");
                string endDateTime = Console.ReadLine() ?? "";
                if (services.AddMedication(
                    tradeName,
                    genericName,
                    manufacturer,
                    dosageStrength,
                    quantity,
                    startDateTime,
                    endDateTime
                    ))
                {
                    Console.WriteLine("[ADDMEDICINE] Medication(s) added successfully.");
                }
                else
                {
                    Console.WriteLine("[ADDMEDICINE] Failed to add new medication data. Please try again.");
                }
                utils.PressToConfirm();
            }
        }

        public void DeleteMedication()
        {
            Console.Clear();
            utils.CreateBanner("DELETE A MEDICATION DATA");
            Console.Write("[DELETEMEDICATION] Please enter Medication Data ID: ");
            string id = Console.ReadLine() ?? "";
            if (services.RemoveMedication(id))
            {
                Console.WriteLine("[DELETEMEDICATION] Medication data has been removed.");
            }
            else
            {
                Console.WriteLine("[DELETEMEDICATION] Sorry. This medication data does not exist.");
            }
            utils.PressToConfirm();
        }

        public void DeleteOldPatient()
        {
            Console.Clear();
            utils.CreateBanner("DELETE A PATIENT");
            Console.Write("[DELETEPATIENT] Please enter Patient ID: ");
            string id = Console.ReadLine() ?? "";
            if (patientServices.RemovePatient(id))
            {
                Console.WriteLine("[DELETEPATIENT] Patient has been removed.");
            }
            else
            {
                Console.WriteLine("[DELETEPATIENT] Sorry. This patient does not exist.");
            }
            utils.PressToConfirm();
        }

        public void ViewPersonalInformation()
        {
            Console.Clear();
            utils.CreateBanner("YOUR PERSONAL INFORMATION");
            Doctor? doctor = null;
            Nurse? nurse = null;
            switch (services.CurrentUserType())
            {
                case 'D':
                    doctor = services.GetDoctor();
                    break;
                case 'N':
                    nurse = services.GetNurse();
                    break;
            }
            if (doctor != null)
            {
                Console.WriteLine("[VIEWINFO] Your personal information:");
                Console.WriteLine("[VIEWINFO] Your username: " + doctor.username);
                Console.WriteLine("[VIEWINFO] Your pasword: " + doctor.password);
                Console.WriteLine("[VIEWINFO] Your name: " + doctor.name);
                Console.WriteLine("[VIEWINFO] Your age: " + doctor.age);
                Console.WriteLine("[VIEWINFO] Your sex: " + doctor.sex);
                Console.WriteLine("[VIEWINFO] Your birthday: " + doctor.birthday);
                Console.WriteLine("[VIEWINFO] Your 1st phone number: " + doctor.phoneNumber1);
                Console.WriteLine("[VIEWINFO] Your 2nd phone number: " + doctor.phoneNumber2);
                Console.WriteLine("[VIEWINFO] Your type: " + doctor.type);
                Console.WriteLine("[VIEWINFO] Your registered license number: " + doctor.licenseNo);
                Console.WriteLine("[VIEWINFO] Your signature: " + doctor.signature);
            }
            else if (nurse != null)
            {
                Console.WriteLine("[VIEWINFO] Your personal information:");
                Console.WriteLine("[VIEWINFO] Your username: " + nurse.username);
                Console.WriteLine("[VIEWINFO] Your pasword: " + nurse.password);
                Console.WriteLine("[VIEWINFO] Your name: " + nurse.name);
                Console.WriteLine("[VIEWINFO] Your sex: " + nurse.sex);
                Console.WriteLine("[VIEWINFO] Your birthday: " + nurse.birthday);
                Console.WriteLine("[VIEWINFO] Your 1st phone number: " + nurse.phoneNumber1);
                Console.WriteLine("[VIEWINFO] Your 2nd phone number: " + nurse.phoneNumber2);
                Console.WriteLine("[VIEWINFO] Your type: " + nurse.type);
            }
            utils.PressToConfirm();
        }

        public void ViewPrescript(Prescription target)
        {
            Console.Clear();
            utils.CreateBanner("PRESCRIPTION HISTORY");
            Console.WriteLine($"""
                [[==================================================================================================================]]
                [[==================================================================================================================]]
                                            
                                             ___   ___   ____  __   __    ___   _   ___  _____  _   ___   _     
                                            | |_) | |_) | |_  ( (` / /`  | |_) | | | |_)  | |  | | / / \ | |\ | 
                                            |_|   |_| \ |_|__ _)_) \_\_, |_| \ |_| |_|    |_|  |_| \_\_/ |_| \|

                                                                   PEDRO GRACE HOSPITAL
                                                       Sample City, Sample Province, Philippines, 12345

                      ===========================================================================================================     
                      FOR (Full name, address, & phone number) (if under 12, give age)
                      -----------------------------------------------------------------------------------------------------------
                      {target.patient.name}, {target.patient.address}, {target.patient.phoneNumber1}
                      -----------------------------------------------------------------------------------------------------------
                      DATE:
                      {target.date}
                      -----------------------------------------------------------------------------------------------------------
                      PRESCRIPTION NO:
                      {target.id}
                      ===========================================================================================================
                
                      {target.superscription}
                      {target.inscription}

                      SPECIAL INSTRUCTIONS:
                      {target.specialInstructions}

                      ==========================================================================================================
                                                                                            {target.doctor.signature}
                                                                                            PRESCRIBER: {target.doctor.name}
                                                                                            LICENSE NO: {target.doctor.licenseNo}
                                                                                            -----------------------------------
                                                                                            SIGNATURE AND LICENSE OF PRESCRIBER

                [[==================================================================================================================]]
                [[==================================================================================================================]]
                
                """);
            utils.PressToConfirm();
        }

        public void ViewPrescriptHistory()
        {
            Console.Clear();
            utils.CreateBanner("YOUR PRESCRIPTION HISTORY");
            List<Prescription> prescriptions = services.GetPrescriptions();
            if (prescriptions.Count != 0)
            {
                List<String> history = new List<String>();
                foreach (Prescription p in prescriptions)
                {
                    history.Add(p.date.ToString() + " - ID: " + p.id);
                }
                history.Add("RETURN TO HISTORY MENU");
                string? userInput = null;
                int intChoice = 0;
                int exitChoice = history.Count;
                while (intChoice != exitChoice)
                {
                    Console.Clear();
                    utils.CreateBanner("YOUR PRESCRIPTION HISTORY");
                    utils.CreateMenu(history);
                    Console.Write("[PRESCRIPTHISTORY] Please type a prescription to view: ");
                    userInput = Console.ReadLine() ?? "";
                    int.TryParse(userInput, out intChoice);
                    if (intChoice != exitChoice && intChoice != 0)
                    {
                        ViewPrescript(prescriptions[intChoice - 1]);
                    } 
                    else if (intChoice != exitChoice)
                    {
                        Console.WriteLine("[PRESCRIPTHISTORY] Please type a correct value.");
                    }
                }
            }
            else
            {
                Console.WriteLine("[PRESCRIPTHISTORY] Sorry! You do not have any history of prescriptions given.");
                utils.PressToConfirm();
            }
        }

        public void ViewMedicineList()
        {
            Console.Clear();
            utils.CreateBanner("MEDICINE DATABASE");
            List<Medication> medications = services.GetMedications();
            List<String> history = new List<String>();
            foreach (Medication m in medications)
            {
                history.Add(m.genericName);
            }
            utils.CreateMenu(history);
            utils.PressToConfirm();
        }

    }
}
