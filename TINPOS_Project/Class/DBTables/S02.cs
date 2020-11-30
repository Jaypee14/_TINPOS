using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TINPOS_Project.Class.DbFunction
{
    //Derived Class (Child)
    class S02 : DBQTable
    {
        public override DataTable DataResult      { get; set; }
        public string tableName       { get { return "S02_GROUP_ACCESS"; } }
        public string txName          { get { return "TXS02"; } }
        //Column Index
        private int ID_i                 { get { return 0; } }
        private int GUID_i               { get { return 1; } }
      

        public string ID                 { get; set; }
        public string GUID               { get; set; }
        public string Group_Name         { get; set; }
        public string Description        { get; set; }
   
        //Constructor
        public S02() 
        {
            //Default Columns.
            ID_C = ID_i;
            GUID_C = GUID_i;

            TableName = tableName;
            TxName = txName;
            Initialization();

            ID          = Table.Column.Name(0);
            GUID        = Table.Column.Name(1);
            Group_Name  = Table.Column.Name(2);
            Description = Table.Column.Name(3);

        }

       


    }
}
