using System;

namespace HospitalIMSModels
{
    public class Patient
    {
        public required int id { get; set; }
        public required string name { get; set; }
        public required string sex { get; set; }
        public required string age { get; set; }
        public required DateTime birthday { get; set; }
        public required string phoneNumber1 { get; set; }
        public string? phoneNumber2 { get; set; }
        public required string address { get; set; }
        public required string weightKg { get; set; }
        public required string heightFt { get; set; }
    }
}
