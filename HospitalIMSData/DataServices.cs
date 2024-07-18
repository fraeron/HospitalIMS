// Hospital Information Management System Data Layer

using System;
using System.Collections.Generic;
using HospitalIMSModels;

namespace HospitalIMSData
{
    public class DataServices
    {
        List<Doctor> doctorList = new List<Doctor>();
        List<Patient> patientList = new List<Patient>();
        List<Prescription> prescriptionList = new List<Prescription>();
        List<Medication> medicationList = new List<Medication>();
        List<Nurse> nurseList = new List<Nurse>();
        List<Staff> staffList = new List<Staff>();
        SqlDBData sqlData = null;

        // Use singleton pattern to avoid most I/O errors from multiple instances.
        private static readonly DataServices dataServiceSingleton = new DataServices();

        // Set true if using SQL database, otherwise, use dummy data.
        bool useSqlDatabase = true;

        public DataServices()
        {
            if (useSqlDatabase)
            {
                sqlData = new SqlDBData();
                GetSqlData();
            }
            else
            {
                CreateDummyData dummy = new CreateDummyData(
                    doctorList,
                    patientList,
                    prescriptionList,
                    medicationList,
                    nurseList,
                    staffList
                );
            }
        }

        public static DataServices GetDataService()
        {
            return dataServiceSingleton;
        }

        public List<Doctor> GetDoctors()
        {
            doctorList = sqlData.GetDoctors();
            return doctorList;
        }

        public void GetSqlData()
        {
            doctorList = sqlData.GetDoctors();
            patientList = sqlData.GetPatients();
            prescriptionList = sqlData.GetPrescriptions();
            medicationList = sqlData.GetMedications();
            nurseList = sqlData.GetNurses();
            staffList = sqlData.GetStaffs();
        }

        public Doctor? GetDoctor(string username, string password)
        {
            doctorList = sqlData.GetDoctors();
            Doctor? foundDoctor = null;
            foreach (Doctor doctor in doctorList)
            {
                if (doctor.username == username && doctor.password == password)
                {
                    foundDoctor = doctor;
                }
            }
            return foundDoctor;
        }

        public Nurse? GetNurse(string username, string password)
        {
            nurseList = sqlData.GetNurses();
            Nurse? foundNurse = null;
            foreach (Nurse nurse in nurseList)
            {
                if (nurse.username == username && nurse.password == password)
                {
                    foundNurse = nurse;
                }
            }
            return foundNurse;
        }

        public List<Patient> GetPatients()
        {
            patientList = sqlData.GetPatients();
            return patientList;
        }

        public bool AddPatient(Patient patient)
        {
            if (useSqlDatabase)
            {
                return sqlData.AddPatient(patient) != -1;
            } else
            {
                patientList.Add(patient);
                return true;
            }
        }

        public bool UpdatePatient(Patient patient)
        {
            if (useSqlDatabase)
            {
                return sqlData.UpdatePatient(patient) != -1;
            }
            else
            {
                // Do nothing. Non-SQL functions does not support editing.
                return true;
            }
        }

        public bool RemovePatient(Patient patient)
        {
            if (useSqlDatabase)
            {
                return sqlData.DeletePatient(patient.name) != -1;
            } else
            {
                patientList.Remove(patient);
                return true;
            }
        }

        public bool RemoveDoctor(Doctor doctor)
        {
            if (useSqlDatabase)
            {
                return sqlData.DeleteDoctor(Convert.ToString(doctor.id)) != -1;
            }
            else
            {
                doctorList.Remove(doctor);
                return true;
            }
        }

        public bool AddDoctor(Doctor doctor)
        {
            if (useSqlDatabase)
            {
                return sqlData.AddDoctor(doctor) != -1;
            }
            else
            {
                doctorList.Add(doctor);
                return true;
            }
        }

        public bool UpdateDoctor(Doctor doctor)
        {
            if (useSqlDatabase)
            {
                return sqlData.UpdateDoctor(doctor) != -1;
            }
            else
            {
                // Do nothing. Non-SQL functions does not support editing.
                return true;
            }
        }

        public List<Prescription> GetPrescriptions()
        {
            return prescriptionList;
        }

        public List<Medication> GetMedications()
        {
            return medicationList;
        }

        public void AddMedication (Medication medication)
        {
            if (useSqlDatabase)
            {
                sqlData.AddMedication(medication);
            } else
            {
                medicationList.Add(medication);
            }
        }

        public void RemoveMedication (Medication medication)
        {
            if (useSqlDatabase) { 
                sqlData.DeleteMedication(medication.tradeName);
            } else
            {
                medicationList.Remove(medication);
            }
        }
    }
}
