using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TINPOS_Project.Class.DbFunction;
using TINPOS_Project.Class.ProjectClass;

namespace TINPOS_Project.Class.DbFunction
{
    //Base Class (Parent)
    class DBQTable
    
    {
        /// <summary>
        /// TxTable Class
        /// </summary>
        public TXTable Table;
        private DataTable _DataResult;

        /// <summary>
        /// Type DataTable. Returns result of select query.
        /// </summary>
        public virtual DataTable DataResult { get; set; }

        public String TableName     { get; set; }
        /// <summary>
        /// Type Multidimentional String[,]
        /// </summary>
        public String[,] TXTable    { get; set; }
        /// <summary>
        /// All Data Types of columns
        /// </summary>
        public String[] AllColumnTypes  { get; set; }
        /// <summary>
        /// All Column names. Returns an array of string[]
        /// </summary>
        public String[] AllColumnNames  { get; set; }
        public String TxName        { get; set; }
        /// <summary>
        /// Default columns
        /// </summary>
        public int ID_C             { get; set; }
        public int GUID_C           { get; set; }



        DBQStatement statement = new DBQStatement();
        Shared shr = new Shared();


        public void Initialization()
        {
            Table = new TXTable(TxName);
            AllColumnNames = Table.Column.AllNames;
            AllColumnTypes = Table.Column.AllTypes;
            TXTable = Table.TableArray;

        }
        /// <summary>
        /// Add Column Type of a Column
        /// </summary>
        /// <param name="columnName">Column Name</param>
        /// <returns>Returns a multidimentional array string[,]</returns>
        public string[,] addColumnType(string[] columnName)
        {
            int colCount = columnName.Count();
            string[,] columns = new string[colCount, 2];
            for (int ix = 0; ix < colCount; ix++)
            {
                columns[ix, 0] = columnName[ix];
                columns[ix, 1] = Table.Column.Typeof(columnName[ix]);
            }
            return columns;
        }
        /// <summary>
        /// Get all by column Index.
        /// </summary>
        /// <param name="columnName">Column Name.</param>
        /// <param name="values">Value to search</param>
        /// <returns>Returns a DataTable</returns>
        public bool Get_All_By(string[] columnName, string[] values)
        {
            //check if both have same length.
            _DataResult = new DataTable();
            _DataResult.Clear();
            int colCount = columnName.Count();
            int idxCount = values.Count();

            if (colCount != idxCount)
            {
                shr.errMsg = "Columns and Values do not match.";
                goto Exit;
            }

            string[,] columns = addColumnType(columnName);
            bool found = statement.SelectAll_By(TableName, columns, values);
            if (found)
            {
                _DataResult = statement.resultTable;
                InitializeDataTable();
                return true;
            }
            else
                return false ;

        Exit:
            shr.ErrorMessage(TableName + "get_All_By() ", shr.errMsg);
            return false;
        }
        /// <summary>
        /// Add values into Table
        /// </summary>
        /// <param name="columnName">Column name to add</param>
        /// <param name="Values">Values</param>
        public virtual void AddValues(string[] columnName, String[] Values)
        {
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
            string[,] columnsToAdd = addColumnType(columnName);

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

            if (statement.INSERT_INTO(TableName, columns, Values))
                return;
            else
                shr.errMsg = "Error while Inserting into Database.";

        ErrorMsg:
            shr.ErrorMessage("A02_AddValues()", shr.errMsg);
        }
        /// <summary>
        /// Update Values where TableID == ID 
        /// </summary>
        /// <param name="columnName">Column to be updated</param>
        /// <param name="values">Values</param>
        /// <param name="ID">Condition: TableID = ID</param>
        public void update_By_ID(string[] columnName, string[] values, int ID)
        {
            //check if both have same length.
            int colCount = columnName.Count();
            int idxCount = values.Count();

            if (colCount != idxCount)
            {
                shr.errMsg = "Columns and Values do not match.";
                goto Exit;
            }
            string[,] columns = addColumnType(columnName);
            bool update = statement.Update_Table(TableName, columns, values, AllColumnNames[ID_C] + " = " + ID);
            if (update)
                return;
            else
                shr.errMsg = "Error while Updating records in database.";
                
        Exit:
            shr.ErrorMessage(TableName + "update_By_ID() ", shr.errMsg);
        }
        /// <summary>
        /// Get All records.
        /// </summary>
        /// <returns></returns>
        public bool GetAll()
        {
            _DataResult = new DataTable();
            _DataResult.Clear();
            if (statement.SelectAll(TableName))
            {
                _DataResult = statement.resultTable;
                InitializeDataTable();
                return true;
            }
            else
                return false;
        }
        /// <summary>
        /// Default 0 if DataResult has one row.
        /// </summary>
        /// <param name="row">Row index</param>
        /// <param name="ColumnName">Column Name</param>
        /// <returns>Returns Value string from DataResult</returns>
        public string ValueOf(string ColumnName, int row = 0)
        {
            return DataResult.Rows[row][ColumnName].ToString();
        }
        public void InitializeDataTable()
        {
            DataResult = new DataTable();
            DataResult.Clear();
            DataResult = _DataResult;
        }
      
        

    }
}
