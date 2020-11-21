using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TINPOS_Project.Class.POSDatabase
{
    class S01
    {
        public String TableName = "S01_SCRN_TRANS";
        public String[] Columns_C;
        public int ID_C = 0,
                    GUID_C = 1,
                    Transaction_C = 2,
                    Description_C = 3,
                    S00_ID_C = 4;
                      

        public int ID;



        public void Initialization()
        {
            c_Shared shr = new c_Shared();
            Columns_C = shr.TX_Get("TXS01");
        }

        public string[] getColumnName(int[] colIndex)
        {
            int colCount = colIndex.Count();
            string[] columns = new string[colCount];
            for (int ix = 0; ix < colCount; ix++)
            {
                columns[ix] = Columns_C[colIndex[ix]];
            }
            return columns;
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
            shr.ErrorMessage("S01_AddValues()", shr.errMsg);
        }

        /// <summary>
        /// Get all by column Index. For Int data types only
        /// </summary>
        /// <param name="colIndex">Column Index. Column type must be Int.</param>
        /// <param name="_ID">Value of ID to search</param>
        /// <returns></returns>
        public DataTable get_All_By(int[] colIndex, int[] values)
        {
            c_Shared shr = new c_Shared();
            c_Database db = new c_Database();
            Initialization();
            //check if both have same length.
            int colCount = colIndex.Count();
            int idxCount = values.Count();

            if (colCount != idxCount)
            {
                shr.errMsg = "Columns and Values do not match.";
                goto Exit;
            }

            string[] columns = getColumnName(colIndex);
            DataTable szData = db.Get_All_By(TableName, columns, values);
            return szData;

        Exit:
            shr.ErrorMessage(TableName + "get_All_By() ", shr.errMsg);
            return null;
        }

    }
}
