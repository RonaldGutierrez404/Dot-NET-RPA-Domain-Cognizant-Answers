using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess.Client;
using System.Configuration;

namespace ADO_Net_App1
{
    public class DBHandler
    {
        public OracleConnection GetConnection()
        {
            // Create a new OracleConnection object with the connection string from DBConnection
            OracleConnection conn = new OracleConnection(DBConnection.connStr);

            // Return the OracleConnection object
            return conn;
        }
    }
}