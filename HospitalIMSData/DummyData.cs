using System;
using System.Collections.Generic;
using HospitalIMSModels;

namespace HospitalIMSData
{
    public class CreateDummyData
    {
        public CreateDummyData(
            List<Doctor> doctorList, 
            List<Patient> patientList, 
            List<Prescription> prescriptionList,
            List<Medication> medicationList,
            List<Nurse> nurseList,
            List<Staff> staffList) {

            Doctor doctor1 = new Doctor
            {
                id = 0,
                username = "juandelacruz",
                password = "MAMASBOY",
                name = "Juan Dela Cruz",
                age = 25,
                address = "Sample Address",
                birthday = new DateTime(1999, 1, 1),
                phoneNumber1 = 09123456789,
                phoneNumber2 = 09123456789,
                sex = 'M',
                type = "Cardiologist",
                licenseNo = 123456,
                signature = "JUAN DELA CRUZ"
            };
            Doctor doctor2 = new Doctor
            {
                id = 1,
                username = "juanasantos",
                password = "SecurePass@1999!",
                age = 25,
                name = "Juana Abadeer G. SANTOS",
                address = "Sample Address",
                birthday = new DateTime(1999, 1, 2),
                phoneNumber1 = 09123456789,
                phoneNumber2 = 09123456789,
                sex = 'F',
                licenseNo = 123457,
                type = "Dermatologist",
                signature = "JUANA ABADEER G. SANTOS"
            };
            Doctor doctor3 = new Doctor
            {
                id = 2,
                username = "pedroreyes",
                age = 25,
                password = "12345",
                name = "Pedro Q. Reyes",
                address = "Sample Address",
                birthday = new DateTime(1999, 1, 3),
                phoneNumber1 = 09123456789,
                phoneNumber2 = 09123456789,
                sex = 'M',
                type = "Opthamologist",
                licenseNo = 123458,
                signature = "PEDRO Q. REYES"
            };

            Patient patient1 = new Patient
            {
                id = 0,
                name = "Robert Randall",
                address = "Sample Address",
                age = "25",
                birthday = new DateTime(1999, 1, 1),
                phoneNumber1 = "09123456789",
                phoneNumber2 = "09123456789",
                sex = "M",
                weightKg = "72.5",
                heightFt = "5.9"

            };
            Patient patient2 = new Patient
            {
                id = 1,
                name = "Theresa Berry",
                address = "Sample Address",
                birthday = new DateTime(1999, 1, 2),
                phoneNumber1 = "09123456789",
                phoneNumber2 = "09123456789",
                age = "25",
                sex = "F",
                weightKg = "65.25",
                heightFt = "5.2"
            };
            Patient patient3 = new Patient
            {
                id = 2,
                name = "Julia Calvo",
                address = "Sample Address",
                birthday = new DateTime(1999, 1, 3),
                phoneNumber1 = "09123456789",
                phoneNumber2 = "09123456789",
                age = "25",
                sex = "F",
                heightFt = "4.11",
                weightKg = "125"
            };

            Nurse nurse1 = new Nurse
            {
                id = 0,
                name = "Proven L. Capuso",
                address = "Sample Address",
                username = "provencapuso",
                password = "12345",
                birthday = new DateTime(1999, 1, 1),
                phoneNumber1 = 09123456789,
                age = 25,
                phoneNumber2 = 09123456789,
                type = "Cardiac Nurse",
                sex = 'M'
            };
            Nurse nurse2 = new Nurse
            {
                id = 1,
                name = "Kikiana R. Rayulo",
                username = "kikianarayulo",
                password = "12345",
                address = "Sample Address",
                birthday = new DateTime(1999, 1, 2),
                phoneNumber1 = 09123456789,
                age = 25,
                phoneNumber2 = 09123456789,
                type = "Certified Registered Nurse Anesthetist",
                sex = 'F'
            };
            Nurse nurse3 = new Nurse
            {
                id = 2,
                name = "Maria Josefa J. Morgana",
                username = "mariajosefamorgana",
                password = "12345",
                address = "Sample Address",
                birthday = new DateTime(1999, 1, 3),
                phoneNumber1 = 09123456789,
                age = 25,
                phoneNumber2 = 09123456789,
                type = "Registered Nurse",
                sex = 'F'
            };
            
            Staff staff1 = new Staff
            {
                id = 0,
                name = "Maria Dolores Marquez",
                address = "Sample Address",
                birthday = new DateTime(1999, 1, 1),
                phoneNumber1 = 09123456789,
                age = 25,
                phoneNumber2 = 09123456789,
                sex = 'F',
                type = "Clinical Assistant"
            };
            Staff staff2 = new Staff
            {
                id = 1,
                name = "Julia Prieto",
                address = "Sample Address",
                birthday = new DateTime(1999, 1, 2),
                phoneNumber1 = 09123456789,
                age = 25,
                phoneNumber2 = 09123456789,
                sex = 'F',
                type = "Ward Clerk"
            };
            Staff staff3 = new Staff
            {
                id = 2,
                name = "Sebestian Soto",
                address = "Sample Address",
                birthday = new DateTime(1999, 1, 3),
                phoneNumber1 = 09123456789,
                age = 25,
                phoneNumber2 = 09123456789,
                sex = 'M',
                type = "Porter"
            };

            Medication medication1 = new Medication
            {
                id = 0,
                tradeName = "ASMALIS BRONCUTE",
                genericName = "SALBUTAMOL GUAIFENESIN",
                manufacturer = "UNILABO",
                dosageStrength = "5mL",
                quantity = 1,
                startTimeDrugTaken = new DateTime(2003, 12, 25),
                endTimeDrugTaken = new DateTime(2003, 12, 28)
            };

            Medication medication2 = new Medication
            {
                id = 1,
                tradeName = "APPEBALEW",
                genericName = "VITAMIN B-COMPLEX + IRON + LYSINE + BUCLIZINE HYDROCHLORIDE",
                manufacturer = "BALEWLABS",
                dosageStrength = "5mL",
                quantity = 1,
                startTimeDrugTaken = new DateTime(2003, 12, 25),
                endTimeDrugTaken = new DateTime(2003, 12, 31)
            };
            Medication medication3 = new Medication
            {
                id = 2,
                tradeName = "DAYBREAKER",
                genericName = "LEMBOREXANT",
                manufacturer = "NYAW NYAW INC.",
                dosageStrength = "5mg",
                quantity = 5,
                startTimeDrugTaken = new DateTime(2003, 12, 25),
                endTimeDrugTaken = new DateTime(2003, 12, 31)
            };

            doctorList.AddRange(new List<Doctor> { doctor1, doctor2, doctor3 });
            patientList.AddRange(new List<Patient> { patient1, patient2, patient3 });
            nurseList.AddRange(new List<Nurse> {nurse1, nurse2, nurse3});
            staffList.AddRange(new List<Staff> {staff1,staff2, staff3});
            medicationList.AddRange(new List<Medication> {medication1,medication2, medication3});

            prescriptionList.AddRange(
                new List<Prescription>
                {
                    new Prescription{
                        id = 0,
                        date = new DateTime(2003, 12, 25),
                        doctor = doctorList[2],
                        patient = patientList[0],
                        superscription = "Rx",
                        inscription = concatMedications(new List<Medication>
                            {
                                medication1,
                                medication2
                            }
                        )
                        ,
                        specialInstructions = "For each, take only once per day."
                    },
                    new Prescription{
                        id = 1,
                        date = new DateTime(2003, 12, 25),
                        doctor = doctorList[2],
                        patient = patientList[1],
                        superscription = "Rx",
                        inscription = concatMedications(new List<Medication>
                            {
                                medication1,
                                medication2,
                                medication3
                            }
                        )
                        ,
                        specialInstructions = "Take one before sleeping."
                    },
                    new Prescription{
                        id = 2,
                        date = new DateTime(2003, 12, 25),
                        doctor = doctorList[2],
                        patient = patientList[2],
                        superscription = "Rx",
                        inscription = concatMedications(new List<Medication>
                            {
                                medication3
                            }
                        )
                    },
                    new Prescription{
                        id = 3,
                        date = new DateTime(2003, 12, 25),
                        doctor = doctorList[2],
                        patient = patientList[1],
                        superscription = "Rx",
                        inscription = concatMedications(new List<Medication>
                            {
                                medication1,
                                medication2,
                                medication3
                            }
                        )
                        ,
                        specialInstructions = "Take one before sleeping."
                    },
                    new Prescription{
                        id = 4,
                        date = new DateTime(2003, 12, 25),
                        doctor = doctorList[0],
                        patient = patientList[1],
                        superscription = "Rx",
                        inscription = concatMedications(new List<Medication>
                            {
                                medication3
                            }
                        )
                        ,
                        specialInstructions = "Take one before sleeping."
                    },
                    new Prescription{
                        id = 5,
                        date = new DateTime(2003, 12, 25),
                        doctor = doctorList[1],
                        patient = patientList[2],
                        superscription = "Rx",
                        inscription = concatMedications(new List<Medication>
                            {
                                medication2
                            }
                        )
                    }
                }

            ) ;
        }
        public string concatMedications(List<Medication> medications)
        {
            string concatanated = "";
            foreach(Medication medicine in medications) {
                concatanated += medicine.tradeName + " ";
            }
            return concatanated;
        }
    }
}
