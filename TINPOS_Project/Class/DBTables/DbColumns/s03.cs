using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace TINPOS_Project.Class.DBTables.DbColumns
{
    public static class s03
    {

        public static string TableName = "S03_USER_ACCESS";
        public static string TxName = "TXS03";
        public static string[,] txTable { get; set; }
        

        public static string ID { get; set; }
        public static string GUID { get; set; }
        public static string A02_ID { get; set; }
        public static string S02_ID { get; set; }
        public static string S01_ID { get; set; }
        public static string ACCESS { get; set; }
        public static void Initialize()
        {
            zColumn.szTable = txTable;
            zColumn.Initialize();
            ID        = zColumn.Name(0);
            GUID      = zColumn.Name(1);
            A02_ID    = zColumn.Name(2);
            S02_ID    = zColumn.Name(3);
            S01_ID    = zColumn.Name(4);
            ACCESS    = zColumn.Name(5);
        }



    }
}
