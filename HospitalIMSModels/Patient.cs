using System;

namespace HospitalIMSModels
{
    public class Patient
    {
        public required int id;
        public required string name;
        public required char sex;
        public required byte age;
        public required DateTime birthday;
        public required long phoneNumber1;
        public required long phoneNumber2;
        public required string address;
        public required double weightKg;
        public required double heightFt;
    }
}
