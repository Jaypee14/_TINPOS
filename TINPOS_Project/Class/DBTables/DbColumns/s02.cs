using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace TINPOS_Project.Class.DBTables.DbColumns
{
    public static class s02
    {

        public static string TableName = "S02_GROUP_ACCESS";
        public static string TxName = "TXS02";
        public static string[,] txTable { get; set; }
        

        public static string ID { get; set; }
        public static string GUID { get; set; }
        public static string Group_Name { get; set; }
        public static string Description { get; set; }
        public static void Initialize()
        {
            zColumn.szTable = txTable;
            zColumn.Initialize();
            ID        = zColumn.Name(0);
            GUID      = zColumn.Name(1);
            Group_Name = zColumn.Name(2);
            Description = zColumn.Name(3);
        }



    }
}
