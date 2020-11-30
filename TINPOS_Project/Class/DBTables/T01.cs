using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TINPOS_Project.Class.DbFunction
{
    //Derived Class (Child)
    class T01 : DBQTable
    {
        public override DataTable DataResult      { get; set; }

        public string tableName         { get { return "T01_GROUP_ACCESS_INV"; } }
        public string txName            { get { return "TXT01"; } }
        //Column Index
        public int ID_i                 { get { return 0; } }
        public int GUID_i               { get { return 1; } }
     

        public string ID                 { get; set; }
        public string GUID               { get; set; }
        public string S02_ID             { get; set; }
        public string S01_ID             { get; set; }
        public string ACCESS             { get; set; }
   
        //Constructor
        public T01() 
        {
            //Default Columns.
            ID_C = ID_i;
            GUID_C = GUID_i;

            TableName = tableName;
            TxName = txName;
            Initialization();

            ID          = Table.Column.Name(0);
            GUID        = Table.Column.Name(1);
            S02_ID      = Table.Column.Name(2);
            S01_ID      = Table.Column.Name(3);
            ACCESS      = Table.Column.Name(4);
        }

      
    }
}
