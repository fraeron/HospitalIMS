using System;

namespace HospitalIMSModels
{
    public class Doctor
    {
        public required int id;
        public required string username;
        public required string password;
        public required string name;
        public required char sex;
        public required string address;
        public required long phoneNumber1;
        public required long phoneNumber2;
        public required DateTime birthday;
        public required byte age;
        public required string type;
        public required int licenseNo;
        public required string signature;
        public int status = 1;
    }
}
