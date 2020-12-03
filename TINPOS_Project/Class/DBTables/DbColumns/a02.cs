using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace TINPOS_Project.Class.DBTables.DbColumns
{
    public static class a02
    {

        public static string TableName = "A02_EMPLOYEE";
        public static string TxName = "TXA02";
        public static string[,] txTable { get; set; }
        

        public static string ID { get; set; }
        public static string GUID { get; set; }
        public static string UserID { get; set; }
        public static string FirstName { get; set; }
        public static string LastName { get; set; }
        public static string Password { get; set; }
        public static string CreatedBy { get; set; }

        public static void Initialize()
        {
            zColumn.szTable = txTable;
            zColumn.Initialize();
            ID        = zColumn.Name(0);
            GUID      = zColumn.Name(1);
            UserID    = zColumn.Name(2);
            FirstName = zColumn.Name(3);
            LastName  = zColumn.Name(4);
            Password  = zColumn.Name(5);
            CreatedBy = zColumn.Name(6);
        }



    }
}
