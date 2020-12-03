using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace TINPOS_Project.Class.DBTables.DbColumns
{
    public static class t01
    {

        public static string TableName = "T01_GROUP_ACCESS_INV";
        public static string TxName = "TXT01";
        public static string[,] txTable { get; set; }
        

        public static string ID { get; set; }
        public static string GUID { get; set; }
        public static string S02_ID { get; set; }
        public static string S01_ID { get; set; }
        public static string ACCESS { get; set; }
        public static void Initialize()
        {
            zColumn.szTable = txTable;
            zColumn.Initialize();
            ID        = zColumn.Name(0);
            GUID      = zColumn.Name(1);
            S02_ID    = zColumn.Name(2);
            S01_ID    = zColumn.Name(3);
            ACCESS    = zColumn.Name(4);
        }



    }
}
