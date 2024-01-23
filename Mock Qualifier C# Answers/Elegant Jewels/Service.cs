using System;

namespace ElegantJewels
{
    public class Service : Bill
    {
        public void ExtractDetails(string billDetails)
        {
            string[] details = billDetails.Split(':');
            MetalName = details[0];
            Weight = Convert.ToDouble(details[1]);
            PurityOfMetal = Convert.ToDouble(details[2]);
            WantDecoration = Convert.ToBoolean(details[3]);
        }

        public bool ValidateMetalName()
        {
            return MetalName == "Gold" || MetalName == "Silver";
        }

        public double CalculateTotalPrice()
        {
            double pricePerGram = MetalName == "Gold" ? 5000 : 100;
            double totalPrice = (pricePerGram * (PurityOfMetal / 100)) * Weight;
            if (WantDecoration)
            {
                totalPrice += totalPrice * 0.1;
            }
            return totalPrice;
        }
    }
}