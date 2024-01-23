// 10. Asian Theatre
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Movie
{
    public string MovieTitle { get; set; }
    public string SeatType { get; set; }
    public string Dimension { get; set; }
    public float Cost { get; set; }
}

public class Service : Movie
{
    public bool ValidateSeatType(string seatType)
    {
        if (seatType == "Gold" || seatType == "Diamond" || seatType == "Elite")
            return true;
        else
            return false;
    }

    public bool ValidateDimension(string dimension)
    {
        if (dimension == "2D" || dimension == "3D")
            return true;
        else
            return false;
    }

    public Movie FindCost()
    {
        Movie movie = new Movie();

        if (SeatType == "Gold")
        {
            if (Dimension == "2D")
                movie.Cost = 190;
            else if (Dimension == "3D")
                movie.Cost = 240;
        }
        else if (SeatType == "Diamond")
        {
            if (Dimension == "2D")
                movie.Cost = 210;
            else if (Dimension == "3D")
                movie.Cost = 260;
        }
        else if (SeatType == "Elite")
        {
            if (Dimension == "2D")
                movie.Cost = 250;
            else if (Dimension == "3D")
                movie.Cost = 300;
        }

        movie.MovieTitle = MovieTitle;
        movie.SeatType = SeatType;
        movie.Dimension = Dimension;

        return movie;
    }
}

public class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter the Movie Title");
        string movieTitle = Console.ReadLine();

        Console.WriteLine("Enter the Seat Type");
        string seatType = Console.ReadLine();

        Console.WriteLine("Enter the Dimension");
        string dimension = Console.ReadLine();

        Service service = new Service();
        service.MovieTitle = movieTitle;
        service.SeatType = seatType;
        service.Dimension = dimension;

        if (service.ValidateSeatType(seatType))
        {
            if (service.ValidateDimension(dimension))
            {
                Movie movie = service.FindCost();
                Console.WriteLine("\n" + movie.MovieTitle + "_" + movie.SeatType[0] + "_" + movie.Dimension + "_" + movie.Cost.ToString());
            }
            else
            {
                Console.WriteLine("\nInvalid Dimension");
            }
        }
        else
        {
            Console.WriteLine("\nInvalid Seat Type");
        }
    }
}
