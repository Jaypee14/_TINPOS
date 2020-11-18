using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TINPOS_Project.Class.POSDatabase
{
    class A02
    {
        public String TableName = "A02_EMPLOYEE";
        public String[] Columns_C;
        public int ID_C = 0,
                      GUID_C = 1,
                      UserID_C = 2,
                      FirstName_C = 3,
                      LastName_C = 4,
                      Password_C = 5,
                      CreatedBy_C = 6;

       // public int ID;
        // public Guid   A02_GUID;
        //public string Transaction;
        //public string Description;
        //public string ScreenName;


        public void Initialization()
        {
            c_Database db = new c_Database();
            c_Shared shr = new c_Shared();
            Columns_C = shr.TX_Get("TXA02");
        }

        public void AddValues(String[] Values)
        {
            c_Database db = new c_Database();
            c_Shared shr = new c_Shared();
            Initialization();

            int ix = Values.GetLength(0);
            for (int i = 0; i < ix; i++)
            {
                if (Values[i] == "")
                {
                    shr.errMsg = "Invalid Transaction Name";
                    goto ErrorMsg;
                }
            }
            db.INSERT_INTO(TableName, Columns_C, Values);
            return;


        ErrorMsg:
            shr.ErrorMessage("A02_AddValues()", shr.errMsg);
        }

        public DataTable get_By_UserID(String userID)
        {
            c_Database db = new c_Database();
            db.dbOpen();
            Initialization();
            String query = "Select * from [" + TableName + "] " +
                            "Where " + Columns_C[UserID_C] + " = '" + userID + "'";
            DataTable szData = db.dbSqlDataAdapter(query);
            return szData;

        }

        



    }
}
