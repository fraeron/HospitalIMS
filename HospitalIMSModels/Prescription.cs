using System;
using System.Collections.Generic;

namespace HospitalIMSModels
{
    public class Prescription
    {
        public required int id;
        public Patient patient;
        public Doctor doctor;
        public required DateTime date;
        public required string superscription;
        public required string inscription;
        public string? specialInstructions;
    }
}
