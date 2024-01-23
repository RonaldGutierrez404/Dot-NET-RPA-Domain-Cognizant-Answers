// Corus Concert app

using System;
using System.Globalization;

namespace CorusConcert
{
    public class Concert
    {
        public DateTime Date { get; set; }
        public string SeatingType { get; set; }
        public int VisitorsCount { get; set; }
    }

    public class ConcertDetails : Concert
    {
        public bool ValidateDay()
        {
            string day = Date.ToString("dddd", new CultureInfo("en-US"));
            return day == "Saturday" || day == "Sunday";
        }

        public double TicketPriceCalculation()
        {
            double pricePerVisitor = 0;
            double extraCharge = 0;

            switch (SeatingType)
            {
                case "First":
                    pricePerVisitor = 2000;
                    extraCharge = 0.2 * pricePerVisitor;
                    break;
                case "Second":
                    pricePerVisitor = 1000;
                    extraCharge = 0.1 * pricePerVisitor;
                    break;
                case "Normal":
                    pricePerVisitor = 500;
                    break;
            }

            return (VisitorsCount * pricePerVisitor) + extraCharge;
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        CorusConcert.ConcertDetails concert = new CorusConcert.ConcertDetails();

        Console.WriteLine("Enter the date");
        concert.Date = DateTime.ParseExact(Console.ReadLine(), "MM/dd/yyyy", CultureInfo.InvariantCulture);

        if (!concert.ValidateDay())
        {
            Console.WriteLine("Ticket is not available");
            return;
        }

        Console.WriteLine("Enter the seating type");
        concert.SeatingType = Console.ReadLine();

        Console.WriteLine("Enter the visitors count");
        concert.VisitorsCount = int.Parse(Console.ReadLine());

        double ticketCost = concert.TicketPriceCalculation();
        Console.WriteLine($"The ticket cost is {ticketCost}");
    }
}