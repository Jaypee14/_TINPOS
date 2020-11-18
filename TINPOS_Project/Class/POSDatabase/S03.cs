using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TINPOS_Project.Class.POSDatabase
{
    class S03
    {

        public String TableName = "S03_USER_ACCESS";
        public String[] Columns_C;
        public int ID_C = 0,
                      GUID_C = 1,
                      A02_ID_C = 2,
                      S02_ID_C = 3,
                      S01_ID_C = 4,
                      ACCESS_C = 5;

      //  public int ID;
        // public Guid   S03_GUID;
        //public string S01_ID;
        //public string S02_ID;
        //public string ACCESS;



        public void Initialization()
        {
            c_Database db = new c_Database();
            c_Shared shr = new c_Shared();
            Columns_C = shr.TX_Get("TXS03");
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
            shr.ErrorMessage("S03_AddValues()", shr.errMsg);
        }

        public DataTable get_S03_By_A02(int A02_ID)
        {
            c_Database db = new c_Database();
            Initialization();
            db.dbOpen();
            String query = "Select * from [" + TableName + "] " +
                            "Where " + Columns_C[A02_ID_C] + " = " + A02_ID;
            DataTable szData = db.dbSqlDataAdapter(query);
            return szData;
        }

        public DataTable Get_By_ID(int ID)
        {
            c_Database db = new c_Database();
            DataTable szData = db.Get_ByID(TableName, ID);
            return szData;
        }


    }
}
