using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess.Client;

namespace ProjectManagement.Infrastructures.Helper
{
    public class OracleDbConnection
    {
        public static OracleConnection GetOldConnection()
        {
            const string connectionString = "Data Source=(DESCRIPTION="
                                            + "(ADDRESS=(PROTOCOL=TCP)(HOST=192.168.119.138)(PORT=1521))"
                                            + "(CONNECT_DATA=(SERVICE_NAME=PROD)));"
                                            + "User Id=APPSWG;Password=APPSWG#;";

            var oldConnection = new OracleConnection(connectionString);
            return oldConnection;
        }

        public static OracleConnection GetNewConnection()
        {
            const string connectionString = "Data Source=(DESCRIPTION="
                                            + "(ADDRESS=(PROTOCOL=TCP)(HOST=192.168.119.138)(PORT=1521))"
                                            + "(CONNECT_DATA=(SERVICE_NAME=PROD)));"
                                            + "User Id=APPSWG;Password=APPSWG#;";

            var newConnection = new OracleConnection(connectionString);
            return newConnection;
        }
    }
}
