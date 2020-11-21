﻿using System;
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
        //Column Index
        public int ID_C = 0,
                      GUID_C = 1,
                      A02_ID_C = 2,
                      S02_ID_C = 3,
                      S01_ID_C = 4,
                      ACCESS_C = 5;




        public void Initialization()
        {
            c_Database db = new c_Database();
            c_Shared shr = new c_Shared();
            Columns_C = shr.TX_Get("TXS03");
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

            db.INSERT_INTO(TableName, Columns_C, Values);
            return;


        //ErrorMsg:
        //    shr.ErrorMessage("S03_AddValues()", shr.errMsg);
        }


        /// <summary>
        /// Get all by column Index. For Int data types only
        /// </summary>
        /// <param name="colIndex">Column Index. Column type must be Int.</param>
        /// <param name="values">Value of ID to search</param>
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

        /// <summary>
        /// Update Values where TableID == ID 
        /// </summary>
        /// <param name="colIndex">Column to be updated</param>
        /// <param name="values">Values</param>
        /// <param name="ID">Condition: TableID = ID</param>
        /// <returns></returns>
         public void update_By_ID(int[] colIndex, string[] values, int ID)
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
            db.Update_Table(TableName, columns, values, Columns_C[ID_C] + " = " + ID);

            return;
        Exit:
            shr.ErrorMessage(TableName + "update_By_ID() ", shr.errMsg);
        }
       


    }
}
