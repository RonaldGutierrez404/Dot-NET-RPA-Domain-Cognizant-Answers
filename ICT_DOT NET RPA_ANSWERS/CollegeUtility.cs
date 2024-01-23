using System;
using System.Collections.Generic;
using System.Data;
using Oracle.ManagedDataAccess.Client;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ADO_Net_App1
{
    public class CollegeUtility
    {
        DBHandler dbHandler = new DBHandler();

        public bool DeleteCollegeById(int id)
        {
            // Get the connection
            OracleConnection conn = dbHandler.GetConnection();

            // Open the connection
            conn.Open();

            // Prepare the SQL command
            OracleCommand cmd = new OracleCommand($"DELETE FROM College WHERE id = {id}", conn);

            // Execute the command
            int rowsAffected = cmd.ExecuteNonQuery();

            // Close the connection
            conn.Close();

            // Return true if a row was deleted, false otherwise
            return rowsAffected > 0;
        }

        public College GetCollegeById(int id)
        {
            // Get the connection
            OracleConnection conn = dbHandler.GetConnection();

            // Open the connection
            conn.Open();

            // Prepare the SQL command
            OracleCommand cmd = new OracleCommand($"SELECT * FROM College WHERE id = {id}", conn);

            // Execute the command and get the result
            OracleDataReader reader = cmd.ExecuteReader();

            // Create a new College object
            College college = null;

            // If a result was found, initialize the College object
            if (reader.Read())
            {
                college = new College(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetInt32(3));
            }

            // Close the connection
            conn.Close();

            // Return the College object
            return college;
        }

        public int CalculateFees(string collegeName, string department)
        {
            // Define the tuition fees and hostel fees for each college and department
            Dictionary<string, Dictionary<string, int>> tuitionFees = new Dictionary<string, Dictionary<string, int>>
            {
                { "PSG", new Dictionary<string, int> { { "ECE", 25000 }, { "CSE", 30000 }, { "MECH", 35000 } } },
                { "COE", new Dictionary<string, int> { { "ECE", 28500 }, { "CSE", 35600 }, { "MECH", 23450 } } },
                { "NIT", new Dictionary<string, int> { { "ECE", 45500 }, { "CSE", 43000 }, { "MECH", 55000 } } }
            };
            Dictionary<string, int> hostelFees = new Dictionary<string, int> { { "PSG", 20000 }, { "COE", 18500 }, { "NIT", 35000 } };

            // Calculate the fees
            int fees = tuitionFees[collegeName][department] + hostelFees[collegeName];

            // Return the calculated fees
            return fees;
        }
    }
}