using System;

namespace HospitalIMSModels
{
    public class Patient
    {
        public required int id;
        public required string name;
        public required string sex;
        public required string age;
        public required DateTime birthday;
        public required string phoneNumber1;
        public string? phoneNumber2 = null;
        public required string address;
        public required string weightKg;
        public required string heightFt;
    }
}
