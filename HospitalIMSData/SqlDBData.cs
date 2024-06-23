using System.Collections.Generic;
using System.Data.SqlClient;
using System;
using HospitalIMSModels;

namespace HospitalIMSData
{
    public class SqlDBData
    {
        string connectionString = """
            Data Source = localhost\\SQLEXPRESS;
            Initial Catalog = PedroHospital; 
            Integrated Security = True;
            """;

        SqlConnection sqlConnection;

        public SqlDBData()
        {
            sqlConnection = new SqlConnection(connectionString);
        }

        public List<Doctor> GetDoctors()
        {
            string selectStatement = "SELECT * FROM doctors";
            SqlCommand selectCommand = new SqlCommand(selectStatement, sqlConnection);
            sqlConnection.Open();
            List<Doctor> doctors = new List<Doctor>();
            SqlDataReader reader = selectCommand.ExecuteReader();
            while (reader.Read())
            {
                doctors.Add(new Doctor()
                {
                    id = Convert.ToInt16(reader["id"]),
                    username = reader["username"].ToString(),
                    password = reader["password"].ToString(),
                    name = reader["name"].ToString(),
                    age = Convert.ToByte(reader["age"]),
                    address = reader["address"].ToString(),
                    birthday = new DateTime(Convert.ToInt64(reader["birthday"])),
                    phoneNumber1 = Convert.ToInt64(reader["phoneNumber1"]),
                    phoneNumber2 = Convert.ToInt64(reader["phoneNumber2"]),
                    sex = reader["sex"].ToString()[0],
                    type = reader["type"].ToString(),
                    licenseNo = Convert.ToInt32(reader["licenseNo"]),
                    signature = reader["signature"].ToString()
                });
            }
            sqlConnection.Close();
            return doctors;
        }

        public List<Patient> GetPatients()
        {
            string selectStatement = "SELECT * FROM patients";
            SqlCommand selectCommand = new SqlCommand(selectStatement, sqlConnection);
            sqlConnection.Open();
            List<Patient> patients = new List<Patient>();
            SqlDataReader reader = selectCommand.ExecuteReader();
            while (reader.Read())
            {
                patients.Add(new Patient()
                {
                    id = Convert.ToInt16(reader["id"]),
                    name = reader["name"].ToString(),
                    sex = reader["sex"].ToString()[0],
                    age = Convert.ToByte(reader["age"]),
                    birthday = new DateTime(Convert.ToInt64(reader["birthday"])),
                    phoneNumber1 = Convert.ToInt64(reader["phoneNumber1"]),
                    phoneNumber2 = Convert.ToInt64(reader["phoneNumber2"]),
                    address = reader["address"].ToString(),
                    weightKg = Convert.ToInt64(reader["phoneNumber1"]),
                    heightFt = Convert.ToInt64(reader["phoneNumber1"])
                });
            }
            sqlConnection.Close();
            return patients;
        }

        public List<Nurse> GetNurses()
        {
            string selectStatement = "SELECT * FROM nurses";
            SqlCommand selectCommand = new SqlCommand(selectStatement, sqlConnection);
            sqlConnection.Open();
            List<Nurse> nurses = new List<Nurse>();
            SqlDataReader reader = selectCommand.ExecuteReader();
            while (reader.Read())
            {
                nurses.Add(new Nurse()
                {
                    id = Convert.ToInt16(reader["id"]),
                    username = reader["username"].ToString(),
                    password = reader["password"].ToString(),
                    name = reader["name"].ToString(),
                    age = Convert.ToByte(reader["age"]),
                    address = reader["address"].ToString(),
                    birthday = new DateTime(Convert.ToInt64(reader["birthday"])),
                    phoneNumber1 = Convert.ToInt64(reader["phoneNumber1"]),
                    phoneNumber2 = Convert.ToInt64(reader["phoneNumber2"]),
                    sex = reader["sex"].ToString()[0],
                    type = reader["type"].ToString(),
                });
            }
            sqlConnection.Close();
            return nurses;
        }

        public List<Staff> GetStaffs()
        {
            string selectStatement = "SELECT * FROM staffs";
            SqlCommand selectCommand = new SqlCommand(selectStatement, sqlConnection);
            sqlConnection.Open();
            List<Staff> staffs = new List<Staff>();
            SqlDataReader reader = selectCommand.ExecuteReader();
            while (reader.Read())
            {
                staffs.Add(new Staff()
                {
                    id = Convert.ToInt16(reader["id"]),
                    name = reader["name"].ToString(),
                    age = Convert.ToByte(reader["age"]),
                    address = reader["address"].ToString(),
                    birthday = new DateTime(Convert.ToInt64(reader["birthday"])),
                    phoneNumber1 = Convert.ToInt64(reader["phoneNumber1"]),
                    phoneNumber2 = Convert.ToInt64(reader["phoneNumber2"]),
                    sex = reader["sex"].ToString()[0],
                    type = reader["type"].ToString(),
                });
            }
            sqlConnection.Close();
            return staffs;
        }

        public List<Prescription> GetPrescriptions()
        {
            string selectStatement = "SELECT * FROM prescriptions";
            SqlCommand selectCommand = new SqlCommand(selectStatement, sqlConnection);
            sqlConnection.Open();
            List<Prescription> prescriptions = new List<Prescription>();
            SqlDataReader reader = selectCommand.ExecuteReader();
            while (reader.Read())
            {
                prescriptions.Add(new Prescription()
                {
                    id = Convert.ToInt16(reader["id"]),
                    doctor = GetDoctor(reader["doctor"].ToString()),
                    patient = GetPatient(reader["patient"].ToString()),
                    superscription = reader["superscription"].ToString(),
                    inscription = reader["inscription"].ToString(),
                    date = new DateTime(Convert.ToInt64(reader["date"])),
                });
            }
            sqlConnection.Close();
            return prescriptions;
        }

        public List<Medication> GetMedications()
        {
            string selectStatement = "SELECT * FROM medications";
            SqlCommand selectCommand = new SqlCommand(selectStatement, sqlConnection);
            sqlConnection.Open();
            List<Medication> medications = new List<Medication>();
            SqlDataReader reader = selectCommand.ExecuteReader();
            while (reader.Read())
            {
                medications.Add(new Medication()
                {
                    id = Convert.ToInt16(reader["id"]),
                    tradeName = reader["tradeName"].ToString(),
                    genericName = reader["genericName"].ToString(),
                    manufacturer = reader["manufacturer"].ToString(),
                    dosageStrength = reader["dosageStrength"].ToString(),
                    quantity = Convert.ToInt16(reader["quantity"]),
                    startTimeDrugTaken = new DateTime(Convert.ToInt64(reader["startTimeDrugTaken"])),
                    endTimeDrugTaken = new DateTime(Convert.ToInt64(reader["endTimeDrugTaken"])),
                });
            }
            sqlConnection.Close();
            return medications;
        }

        public Doctor? GetDoctor(string username)
        {
            Doctor? foundDoctor = null;
            foreach (Doctor doctor in GetDoctors())
            {
                if (doctor.username == username)
                {
                    foundDoctor = doctor;
                }
            }
            return foundDoctor;
        }

        public Patient? GetPatient(string name)
        {
            Patient? foundPatient = null;
            foreach (Patient patient in GetPatients())
            {
                if (patient.name == name)
                {
                    foundPatient = patient;
                }
            }
            return foundPatient;
        }

        public int AddPatient(Patient patient)
        {
            int success;
            string insertStatement = """
                INSERT INTO users 
                VALUES (
                    @id,
                    @name,
                    @sex,
                    @age,
                    @birthday,
                    @phoneNumber1,
                    @phoneNumber2,
                    @address,
                    @weightKg,
                    @heightFt
                )
                """;
            SqlCommand insertCommand = new SqlCommand(insertStatement, sqlConnection);
            insertCommand.Parameters.AddWithValue("@id", patient.id);
            insertCommand.Parameters.AddWithValue("@name", patient.name);
            insertCommand.Parameters.AddWithValue("@sex", patient.sex);
            insertCommand.Parameters.AddWithValue("@age", patient.age);
            insertCommand.Parameters.AddWithValue("@birthday", patient.birthday);
            insertCommand.Parameters.AddWithValue("@phoneNumber1", patient.phoneNumber1);
            insertCommand.Parameters.AddWithValue("@phoneNumber2", patient.phoneNumber2);
            insertCommand.Parameters.AddWithValue("@address", patient.address);
            insertCommand.Parameters.AddWithValue("@weightKg", patient.weightKg);
            insertCommand.Parameters.AddWithValue("@heightFt", patient.heightFt);
            sqlConnection.Open();
            success = insertCommand.ExecuteNonQuery();
            sqlConnection.Close();
            return success;
        }

        public int DeletePatient(string name)
        {
            int success;
            string deleteStatement = $"DELETE FROM patients WHERE name = @name";
            SqlCommand deleteCommand = new SqlCommand(deleteStatement, sqlConnection);
            sqlConnection.Open();
            deleteCommand.Parameters.AddWithValue("@name", name);
            success = deleteCommand.ExecuteNonQuery();
            sqlConnection.Close();
            return success;
        }

        public int AddMedication(string tradeName)
        {
            int success;
            string insertStatement = "INSERT INTO medications VALUES @tradeName";
            SqlCommand insertCommand = new SqlCommand(insertStatement, sqlConnection);
            insertCommand.Parameters.AddWithValue("@tradeName", tradeName);
            sqlConnection.Open();
            success = insertCommand.ExecuteNonQuery();
            sqlConnection.Close();
            return success;
        }

        public int DeleteMedication(string tradeName)
        {
            int success;
            string deleteStatement = $"DELETE FROM medications WHERE tradeName = @tradeName";
            SqlCommand deleteCommand = new SqlCommand(deleteStatement, sqlConnection);
            sqlConnection.Open();
            deleteCommand.Parameters.AddWithValue("@tradeName", tradeName);
            success = deleteCommand.ExecuteNonQuery();
            sqlConnection.Close();
            return success;
        }
    }
}
