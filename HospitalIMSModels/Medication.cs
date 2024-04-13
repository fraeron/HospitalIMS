using System;


namespace HospitalIMSModels
{
    public class Medication
    {
        public required int id;
        public required string tradeName;
        public required string genericName;
        public required string manufacturer;
        public required string dosageStrength;
        public required int quantity;
        public required DateTime startTimeDrugTaken;
        public required DateTime endTimeDrugTaken;
    }
}
