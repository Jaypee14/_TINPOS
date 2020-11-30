using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TINPOS_Project.Class.DbFunction
{
    //Derived Class (Child)
    class S00 : DBQTable
    {
        public override DataTable DataResult      { get; set; }
        public string tableName       { get { return "S00_SCREENS"; } }
        public string txName          { get { return "TXS00"; } }
        //Column Index
        private int ID_i                 { get { return 0; } }
        private int GUID_i               { get { return 1; } }


        public string ID                  { get; set; }
        public string GUID                { get; set; }
        public string Screen              { get; set; }
        public string Description         { get; set; }

   
        //Constructor
        public S00() 
        {
            //Default Columns.
            ID_C = ID_i;
            GUID_C = GUID_i;

            TableName = tableName;
            TxName = txName;
            Initialization();

            ID          = Table.Column.Name(0);
            GUID        = Table.Column.Name(1);
            Screen      = Table.Column.Name(2);
            Description = Table.Column.Name(3);
        }
       


    }
}
