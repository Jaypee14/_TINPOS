﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TINPOS_Project.Class.POSDatabase
{
    class T01old
    {
        public String TableName = "T01_GROUP_ACCESS_INV";
        public String[,] TXTable;
        public String[] Type_C; 
        public String[] Columns_C;
        public int ID_C = 0, //Index
                      GUID_C = 1,
                      S02_ID_C = 2,
                      S01_ID_C = 3,
                      ACCESS_C = 4;
              


        public void Initialization()
        {
            c_Shared shr = new c_Shared();
            TXTable = shr.TX_Get("TXT01");
            int colCount = TXTable.GetLength(0);
            string[] Columns = new string[colCount];
            string[] Type = new string[colCount];
            for (int ix = 0; ix < colCount; ix++)
            {
                Columns[ix] = TXTable[ix, 0];
                Type[ix] = TXTable[ix, 1];
            }
            Columns_C = Columns;
            Type_C = Type;
        }


        /// <summary>
        /// Add values into Table
        /// </summary>
        /// <param name="colIndex">Column index to add</param>
        /// <param name="Values">Values</param>
        public void AddValues(int[] colIndex, String[] Values)
        {
            c_Database db = new c_Database();
            c_Shared shr = new c_Shared();
            Initialization();

            int valCount = Values.GetLength(0);
            if (valCount <= 0)
            {
                shr.errMsg = "No Values to Add.";
                goto ErrorMsg;
            }

            string[,] defaultColumns = {
                                      {TXTable[ID_C,0],TXTable[ID_C,1]}, //TableID
                                      {TXTable[GUID_C,0],TXTable[GUID_C,1]} //GUID
                                    };
            string[,] columnsToAdd = getColumnName(colIndex);

            int defColCount = defaultColumns.GetLength(0);
            int colCount = defColCount + columnsToAdd.GetLength(0);
            string[,] columns = new string[colCount, 2];
            for (int i = 0; i < colCount; i++)
            {
                if (i < defColCount)
                {
                    columns[i, 0] = defaultColumns[i, 0];
                    columns[i, 1] = defaultColumns[i, 1];
                    continue;
                }
                columns[i, 0] = columnsToAdd[i - defColCount, 0];
                columns[i, 1] = columnsToAdd[i - defColCount, 1];
            }

            db.INSERT_INTO(TableName, columns, Values);
            return;


        ErrorMsg:
            shr.ErrorMessage("T01_AddValues()", shr.errMsg);
        }



        public string[,] getColumnName(int[] colIndex)
        {
            int colCount = colIndex.Count();
            string[,] columns = new string[colCount, 2];
            for (int ix = 0; ix < colCount; ix++)
            {
                columns[ix, 0] = TXTable[colIndex[ix], 0];
                columns[ix, 1] = TXTable[colIndex[ix], 1];
            }
            return columns;
        }

        /// <summary>
        /// Get all by column Index.
        /// </summary>
        /// <param name="colIndex">Column Index.</param>
        /// <param name="values">Value to search</param>
        /// <returns></returns>
        public DataTable get_All_By(int[] colIndex, string[] values)
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

            string[,] columns = getColumnName(colIndex);
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
            string[,] columns = getColumnName(colIndex);
            db.Update_Table(TableName, columns, values, Columns_C[ID_C] + " = " + ID);
            return;

        Exit:
            shr.ErrorMessage(TableName + "update_By_ID() ", shr.errMsg);
        }


    }
}
