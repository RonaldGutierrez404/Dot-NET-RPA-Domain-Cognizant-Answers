using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Motors_Hut
{
    public class Service : Parking
    {
        public void ExtractDetails(string parkingDetails)
        {
            var details = parkingDetails.Split(':');
            VehicleNumber = details[0];
            VehicleType = details[1];
            NumberOfDays = int.Parse(details[2]);
        }

        public bool ValidateVehicleType()
        {
            return VehicleType == "2 Wheeler" || VehicleType == "3 Wheeler" || VehicleType == "4 Wheeler";
        }

        public double CalculateTotalAmount()
        {
            double pricePerDay = 0;

            switch (VehicleType)
            {
                case "2 Wheeler":
                    pricePerDay = 50;
                    break;
                case "3 Wheeler":
                    pricePerDay = 70;
                    break;
                case "4 Wheeler":
                    pricePerDay = 100;
                    break;
            }

            return NumberOfDays * pricePerDay;
        }
    }
}