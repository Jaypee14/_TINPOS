using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TINPOS_Project.Class.DBTables.DbColumns;

namespace TINPOS_Project.Class.DbFunction
{
    //Derived Class (Child)
    class A02 : DBQTable
    {
   //     string _TableName = "A02_EMPLOYEE";  
   ////     public override DataTable DataResult      { get; set; }
   //     public string txName          { get { return "TXA02"; } }
        //Column Index
        //private int ID_i               { get { return 0; } }
        //private int GUID_i             { get { return 1; } }

        //ColumnNames
        //public string ID              { get; set; }
        //public string GUID            { get; set; }
        //public string UserID          { get; set; }
        //public string FirstName       { get; set; }
        //public string LastName        { get; set; }
        //public string Password        { get; set; }
        //public string CreatedBy       { get; set; }

        
        
        //Constructor
        public A02() 
        {
            //Default Columns.
            //ID_C = ID_i;
            //GUID_C = GUID_i;

            TableName = a02.TableName;
            Initialization(a02.txTable);

            //ID            = c_TXTable.Column.Name(0);
            //GUID          = c_TXTable.Column.Name(1);
            //UserID        = c_TXTable.Column.Name(2);
            //FirstName     = c_TXTable.Column.Name(3);
            //LastName      = c_TXTable.Column.Name(4);
            //Password      = c_TXTable.Column.Name(5);
            //CreatedBy     = c_TXTable.Column.Name(6);
        }

        public bool get_By_UserID(String userID) //temporary
        {
            DataResult = new DataTable();
            DataResult.Clear();
            ColumnName = new string[] { a02.UserID };
            Values = new string[] { userID };
            if (GetAll_By())
                return true;
            else
                return false;
        }

   

    }
}
