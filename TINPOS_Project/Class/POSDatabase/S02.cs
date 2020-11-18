using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TINPOS_Project.Class.POSDatabase
{
    class S02
    {
        public String TableName = "S02_GROUP_ACCESS";
        public String[] Columns_C;
        public int ID_C = 0,
                      GUID_C = 1,
                      Group_Name_C = 2,
                      Description_C = 3;
              

      //  public int ID;
        // public Guid   S02_GUID;
        //public string Transaction;
        //public string Description;
        //public string ScreenName;


        public void Initialization()
        {
            c_Database db = new c_Database();
            c_Shared shr = new c_Shared();
            Columns_C = shr.TX_Get("TXS02");
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
            shr.ErrorMessage("S02_AddValues()", shr.errMsg);
        }

        public DataTable Get_By_ID(int ID)
        {
            c_Database db = new c_Database();
            DataTable szData = db.Get_ByID(TableName, ID);
            return szData;
        }


    }
}
