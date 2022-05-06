using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

using CRUD.Models;


namespace CRUD
{
    public class Connection
    {
        public static String DT = "localhost\\SQLEXPRESS";

        public static String UsersBD = "bd_usuarios";

        public String UsersStr = @"Data Source = " + DT + @";
                                    Initial Catalog = " + UsersBD + @";
                                    Integrated Security = True;
                                    Connect Timeout = 30;
                                    Encrypt=False;
                                    TrustServerCertificate=False;
                                    ApplicationIntent=ReadWrite;
                                    MultiSubnetFailover=False";




    }
}