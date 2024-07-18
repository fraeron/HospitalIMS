using System;

namespace HospitalIMSModels
{
    public class Doctor
    {
        public required int id { get; set; }
        public required string username { get; set; }
        public required string password { get; set; }
        public required string name { get; set; }
        public required char sex { get; set; }
        public required string address { get; set; }
        public required long phoneNumber1 { get; set; }
        public required long phoneNumber2 { get; set; }
        public required DateTime birthday { get; set; }
        public required byte age { get; set; }
        public required string type { get; set; }
        public required int licenseNo { get; set; }
        public required string signature { get; set; }
    }
}
