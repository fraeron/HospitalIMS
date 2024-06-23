// Hospital Information Management System Data Layer

using System.Collections.Generic;
using HospitalIMSModels;

namespace HospitalIMSData
{
    public class DataServices
    {
        List<Doctor> doctorList = new List<Doctor> ();
        List<Patient> patientList = new List<Patient> ();
        List<Prescription> prescriptionList = new List<Prescription> ();
        List<Medication> medicationList = new List<Medication> ();
        List<Nurse> nurseList = new List<Nurse> ();
        List<Staff> staffList = new List<Staff>();

        SqlDBData sqlData = null;

        // Set true if using SQL database, otherwise, use dummy data.
        bool useSqlDatabase = true;

        public DataServices()
        {
            if (useSqlDatabase)
            {
                sqlData = new SqlDBData();
                GetSqlData();
            } else
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
            Doctor? foundDoctor = null;
            foreach(Doctor doctor in doctorList)
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
            Nurse? foundNurse = null;
            foreach(Nurse nurse in nurseList)
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
            return patientList;
        }

        public void AddPatient(Patient patient)
        {
            if (useSqlDatabase)
            {
                sqlData.AddPatient(patient)
            } else
            {
                patientList.Add(patient);
            }
        }

        public void RemovePatient(Patient patient)
        {
            if (useSqlDatabase)
            {
                sqlData.DeletePatient(patient.name);
            } else
            {
                patientList.Remove(patient);
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
                sqlData.AddMedication(medication.tradeName);
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
