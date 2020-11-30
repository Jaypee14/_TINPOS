using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TINPOS_Project.Class.DbFunction
{
    //Derived Class (Child)
    class A02 : DBQTable
    {
        public override DataTable DataResult      { get; set; }
        public string tableName       { get { return "A02_EMPLOYEE"; } }
        public string txName          { get { return "TXA02"; } }
        //Column Index
        private int ID_i               { get { return 0; } }
        private int GUID_i             { get { return 1; } }

        //ColumnNames
        public string ID              { get; set; }
        public string GUID            { get; set; }
        public string UserID          { get; set; }
        public string FirstName       { get; set; }
        public string LastName        { get; set; }
        public string Password        { get; set; }
        public string CreatedBy       { get; set; }

        
        
        //Constructor
        public A02() 
        {
            //Default Columns.
            ID_C = ID_i;
            GUID_C = GUID_i;

            TableName = tableName;
            TxName = txName;
            Initialization();

            ID            = Table.Column.Name(0);
            GUID          = Table.Column.Name(1);
            UserID        = Table.Column.Name(2);
            FirstName     = Table.Column.Name(3);
            LastName      = Table.Column.Name(4);
            Password      = Table.Column.Name(5);
            CreatedBy     = Table.Column.Name(6);
        }

        public bool get_By_UserID(String userID) //temporary
        {
            DataResult = new DataTable();
            DataResult.Clear();
            string[] col = { UserID };
            string[] val = { userID };
            if (Get_All_By(col, val))
                return true;
            else
                return false;
        }

   

    }
}
