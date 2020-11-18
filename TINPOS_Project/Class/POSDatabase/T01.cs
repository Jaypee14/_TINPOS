using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TINPOS_Project.Class.POSDatabase
{
    class T01
    {
        public String TableName = "T01_GROUP_ACCESS_INV";
        public String[] Columns_C;
        public int ID_C = 0,
                      GUID_C = 1,
                      S02_ID_C = 2,
                      S01_ID_C = 3,
                      ACCESS_C = 4;
              

      //  public int ID; 
        // public Guid   T01_GUID;
        //public string Transaction;
        //public string Description;
        //public string ScreenName;


        public void Initialization()
        {
            c_Database db = new c_Database();
            c_Shared shr = new c_Shared();
            Columns_C = shr.TX_Get("TXT01");
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
            shr.ErrorMessage("T01_AddValues()", shr.errMsg);
        }

        public DataTable get_T01_By_S02(int S02_ID)
        {
            c_Database db = new c_Database();
            Initialization();
            db.dbOpen();
            String query = "Select * from [" + TableName + "] " +
                            "Where " + Columns_C[S02_ID_C] + " = " + S02_ID ;
            DataTable szData = db.dbSqlDataAdapter(query);
            return szData;

        }


    }
}
