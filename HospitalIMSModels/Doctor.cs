using System;

namespace HospitalIMSModels
{
    public class Doctor
    {
        public int id { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string name { get; set; }
        public char sex { get; set; }
        public string address { get; set; }
        public long phoneNumber1 { get; set; }
        public long phoneNumber2 { get; set; }
        public DateTime birthday { get; set; }
        public byte age { get; set; }
        public string type { get; set; }
        public int licenseNo { get; set; }
        public string signature { get; set; }
    }
}
