using System.Collections.Generic;
using System.Data.SqlClient;
using System;
using HospitalIMSModels;
using System.Data.SqlTypes;
using System.Data;

namespace HospitalIMSData
{
    public class SqlDBData
    {
        string localConnectionString =
            "Data Source=localhost\\SQLEXPRESS;" +
            "Initial Catalog=PedroHospital;" +
            "Integrated Security=True;" +
            "TrustServerCertificate=True";
        string remoteConnectionString =
            "Server=tcp:20.2.210.49,1433;" +
            "Database=PedroHospital;" +
            "User Id=sa;" +
            "Password=Talaganaman@123!";
        SqlConnection sqlConnection;

        public SqlDBData()
        {
            sqlConnection = new SqlConnection(remoteConnectionString);
        }

        public List<Doctor> GetDoctors()
        {
            string selectStatement = "SELECT * FROM doctors";
            if (sqlConnection.State != ConnectionState.Open)
                sqlConnection.Open();
            SqlCommand selectCommand = new SqlCommand(selectStatement, sqlConnection);
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
                    birthday = DateTime.Parse(reader["birthday"].ToString()),
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
            if (sqlConnection.State != ConnectionState.Open)
                sqlConnection.Open();
            SqlCommand selectCommand = new SqlCommand(selectStatement, sqlConnection);
            List<Patient> patients = new List<Patient>();
            SqlDataReader reader = selectCommand.ExecuteReader();
            while (reader.Read())
            {
                patients.Add(new Patient()
                {
                    id = Convert.ToInt16(reader["id"]),
                    name = reader["name"].ToString(),
                    sex = reader["sex"].ToString(),
                    age = reader["age"].ToString(),
                    birthday = DateTime.Parse(reader["birthday"].ToString()),
                    phoneNumber1 = reader["phoneNumber1"].ToString(),
                    phoneNumber2 = reader["phoneNumber2"].ToString(),
                    address = reader["address"].ToString(),
                    weightKg = reader["phoneNumber1"].ToString(),
                    heightFt = reader["phoneNumber1"].ToString()
                });
            }
            sqlConnection.Close();
            return patients;
        }

        public List<Nurse> GetNurses()
        {
            string selectStatement = "SELECT * FROM nurses";
            if (sqlConnection.State != ConnectionState.Open)
                sqlConnection.Open();
            SqlCommand selectCommand = new SqlCommand(selectStatement, sqlConnection);
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
                    birthday = DateTime.Parse(reader["birthday"].ToString()),
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
            if (sqlConnection.State != ConnectionState.Open)
                sqlConnection.Open();
            SqlCommand selectCommand = new SqlCommand(selectStatement, sqlConnection);
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
                    birthday = DateTime.Parse(reader["birthday"].ToString()),
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
            if (sqlConnection.State != ConnectionState.Open)
                sqlConnection.Open();
            SqlCommand selectCommand = new SqlCommand(selectStatement, sqlConnection);
            List<Prescription> prescriptions = new List<Prescription>();
            SqlDataReader reader = selectCommand.ExecuteReader();
            while (reader.Read())
            {
                prescriptions.Add(new Prescription()
                {
                    id = Convert.ToInt16(reader["id"]),
                    //doctor = GetDoctor(reader["doctor"].ToString()),
                    //patient = GetPatient(reader["patient"].ToString()),
                    superscription = reader["superscription"].ToString(),
                    inscription = reader["inscription"].ToString(),
                    date = DateTime.Parse(reader["date"].ToString())
                });
            }
            sqlConnection.Close();
            return prescriptions;
        }

        public List<Medication> GetMedications()
        {
            string selectStatement = "SELECT * FROM medications";
            if (sqlConnection.State != ConnectionState.Open)
                sqlConnection.Open();
            SqlCommand selectCommand = new SqlCommand(selectStatement, sqlConnection);
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
                    startTimeDrugTaken = DateTime.Parse(reader["startTimeDrugTaken"].ToString()),
                    endTimeDrugTaken = DateTime.Parse(reader["endTimeDrugTaken"].ToString()),
                });
            }
            sqlConnection.Close();
            return medications;
        }

        public Doctor? GetDoctor(string id)
        {
            Doctor? foundDoctor = null;
            foreach (Doctor doctor in GetDoctors())
            {
                if (doctor.id == Convert.ToInt32(id))
                {
                    foundDoctor = doctor;
                }
            }
            return foundDoctor;
        }

        public Patient? GetPatient(string id)
        {
            Patient? foundPatient = null;
            foreach (Patient patient in GetPatients())
            {
                if (patient.id == Convert.ToInt32(id))
                {
                    foundPatient = patient;
                }
            }
            return foundPatient;
        }

        public int AddDoctor(Doctor doctor)
        {
            int success;
            string insertStatement = """
                INSERT INTO doctors 
                VALUES (
                    @id,
                    @username,
                    @password,
                    @name,
                    @age,
                    @birthday,
                    @address,
                    @phoneNumber1,
                    @phoneNumber2,
                    @sex,
                    @type,
                    @licenseNo,
                    @signature
                )
                """;
            SqlCommand insertCommand = new SqlCommand(insertStatement, sqlConnection);
            insertCommand.Parameters.AddWithValue("@id", doctor.id);
            insertCommand.Parameters.AddWithValue("@username", doctor.username);
            insertCommand.Parameters.AddWithValue("@password", doctor.password);
            insertCommand.Parameters.AddWithValue("@name", doctor.name);
            insertCommand.Parameters.AddWithValue("@age", doctor.age);
            insertCommand.Parameters.AddWithValue("@birthday", doctor.birthday);
            insertCommand.Parameters.AddWithValue("@address", doctor.address);
            insertCommand.Parameters.AddWithValue("@phoneNumber1", doctor.phoneNumber1);
            insertCommand.Parameters.AddWithValue("@phoneNumber2", doctor.phoneNumber2);
            insertCommand.Parameters.AddWithValue("@sex", doctor.sex);
            insertCommand.Parameters.AddWithValue("@type", doctor.type);
            insertCommand.Parameters.AddWithValue("@licenseNo", doctor.licenseNo);
            insertCommand.Parameters.AddWithValue("@signature", doctor.signature);
            sqlConnection.Open();
            try
            {
                success = insertCommand.ExecuteNonQuery();

            }
            catch (SqlTypeException ex)
            {
                return -1;
            }
            sqlConnection.Close();
            return success;
        }

        public int UpdateDoctor(Doctor doctor)
        {
            int success;
            string insertStatement = """
                UPDATE doctors 
                SET 
                    username=@username,
                    password=@password,
                    name=@name,
                    age=@age,
                    birthday=@birthday,
                    address=@address,
                    phoneNumber1=@phoneNumber1,
                    phoneNumber2=@phoneNumber2,
                    sex=@sex,
                    type=@type,
                    licenseNo=@licenseNo,
                    signature=@signature
                WHERE
                id = @id
                """;
            SqlCommand updateCommand = new SqlCommand(insertStatement, sqlConnection);
            updateCommand.Parameters.AddWithValue("@id", doctor.id);
            updateCommand.Parameters.AddWithValue("@username", doctor.username);
            updateCommand.Parameters.AddWithValue("@password", doctor.password);
            updateCommand.Parameters.AddWithValue("@name", doctor.name);
            updateCommand.Parameters.AddWithValue("@age", doctor.age);
            updateCommand.Parameters.AddWithValue("@birthday", doctor.birthday);
            updateCommand.Parameters.AddWithValue("@address", doctor.address);
            updateCommand.Parameters.AddWithValue("@phoneNumber1", doctor.phoneNumber1);
            updateCommand.Parameters.AddWithValue("@phoneNumber2", doctor.phoneNumber2);
            updateCommand.Parameters.AddWithValue("@sex", doctor.sex);
            updateCommand.Parameters.AddWithValue("@type", doctor.type);
            updateCommand.Parameters.AddWithValue("@licenseNo", doctor.licenseNo);
            updateCommand.Parameters.AddWithValue("@signature", doctor.signature);
            sqlConnection.Open();
            success = updateCommand.ExecuteNonQuery();
            sqlConnection.Close();
            return success;
        }

        public int AddPatient(Patient patient)
        {
            int success;
            string insertStatement = """
                INSERT INTO patients 
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
            try
            {
                success = insertCommand.ExecuteNonQuery();

            } catch (SqlTypeException ex) {
                return -1;
            }
            sqlConnection.Close();
            return success;
        }

        public int DeleteDoctor(string id)
        {
            int success;
            string deleteStatement = $"DELETE FROM doctors WHERE id = @id";
            SqlCommand deleteCommand = new SqlCommand(deleteStatement, sqlConnection);
            sqlConnection.Open();
            deleteCommand.Parameters.AddWithValue("@id", id);
            success = deleteCommand.ExecuteNonQuery();
            sqlConnection.Close();
            return success;
        }

        public int UpdatePatient(Patient patient)
        {
            int success;
            string insertStatement = """
                UPDATE patients 
                SET
                    name=@name,
                    sex=@sex,
                    age=@age,
                    birthday=@birthday,
                    phoneNumber1=@phoneNumber1,
                    phoneNumber2=@phoneNumber2,
                    address=@address,
                    weightKg=@weightKg,
                    heightFt=@heightFt
                WHERE
                id=@id
                """;
            SqlCommand updateCommand = new SqlCommand(insertStatement, sqlConnection);
            updateCommand.Parameters.AddWithValue("@id", patient.id);
            updateCommand.Parameters.AddWithValue("@name", patient.name);
            updateCommand.Parameters.AddWithValue("@sex", patient.sex);
            updateCommand.Parameters.AddWithValue("@age", patient.age);
            updateCommand.Parameters.AddWithValue("@birthday", patient.birthday);
            updateCommand.Parameters.AddWithValue("@phoneNumber1", patient.phoneNumber1);
            updateCommand.Parameters.AddWithValue("@phoneNumber2", patient.phoneNumber2);
            updateCommand.Parameters.AddWithValue("@address", patient.address);
            updateCommand.Parameters.AddWithValue("@weightKg", patient.weightKg);
            updateCommand.Parameters.AddWithValue("@heightFt", patient.heightFt);
            sqlConnection.Open(); 
            success = updateCommand.ExecuteNonQuery();
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

        public int AddMedication(Medication medication)
        {
            int success;
            string insertStatement = """
                INSERT INTO medications 
                VALUES (
                    @id,
                    @tradeName,
                    @genericName,
                    @manufacturer,
                    @dosageStrength,
                    @quantity,
                    @startTimeDrugTaken,
                    @endTimeDrugTaken
                )
                """;
            SqlCommand insertCommand = new SqlCommand(insertStatement, sqlConnection);
            insertCommand.Parameters.AddWithValue("@id", medication.id);
            insertCommand.Parameters.AddWithValue("@tradeName", medication.tradeName);
            insertCommand.Parameters.AddWithValue("@genericName", medication.genericName);
            insertCommand.Parameters.AddWithValue("@manufacturer", medication.manufacturer);
            insertCommand.Parameters.AddWithValue("@dosageStrength", medication.dosageStrength);
            insertCommand.Parameters.AddWithValue("@quantity", medication.quantity);
            insertCommand.Parameters.AddWithValue("@startTimeDrugTaken", medication.startTimeDrugTaken);
            insertCommand.Parameters.AddWithValue("@endTimeDrugTaken", medication.endTimeDrugTaken);
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
