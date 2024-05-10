using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicalStoreApplication
{
    public class MedicineDetails
    {
        private static int s_medicineID = 2000;

        public string MedicineID { get; }
        public string MedicineName { get; set; }
        public int AvailableCount { get; set; }
        public Double Price { get; set; }
        public DateTime DateOfExpiry { get; set; }

        public MedicineDetails(string medicineName, int availableCount,double price, DateTime dateOfExpiry)
        {
            s_medicineID++;
            MedicineID = "MD" + s_medicineID;
            MedicineName = medicineName;
            AvailableCount = availableCount;
            Price = price;
            DateOfExpiry = dateOfExpiry;
        }

    }
}