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
using TINPOS_Project.Class._Interface;
using TINPOS_Project.Class.DBTables.DbColumns;

namespace TINPOS_Project.Class.DbFunction
{
    //Base Class (Parent)
    class DBQTable
    
    {
        public IDBQStatement dbqStatement;
        
        public DBQTable()
        {
            this.dbqStatement = new DBQStatement();
        }

        /// <summary>
        /// Type DataTable. Returns result of select query.
        /// </summary>
        private DataTable _DataResult;
        public DataTable DataResult
        {
            get
            {
                return _DataResult;
            } 
            set 
            {
                _DataResult = new DataTable();
                _DataResult.Clear();
                _DataResult = value;
            }
        }

        private string _TableName;
        public virtual string TableName     
        {
            get { return _TableName; }
            set { _TableName = value; }
        }

        string[] _ColumnName;
        public string[] ColumnName
        {
            get { return _ColumnName; }
            set { _ColumnName = value; }
        }

        string[] _Values;
        public string[] Values
        {
            get { return _Values; }
            set { _Values = value; }
        }

        string _Condition;
        public string Condition
        {
            get { return _Condition; }
            set { _Condition = value; }
        }

        string _DbStatus;
        public string DbStatus
        {
            get { return _DbStatus; }
            set { _DbStatus = value; }
        } 

        /// <summary>
        /// Type Multidimentional String[,]
        /// </summary>
        public String[,] _TXTable;
        /// <summary>
        /// All Data Types of columns
        /// </summary>
      //  public String[] AllColumnTypes  { get; set; }
        /// <summary>
        /// All Column names. Returns an array of string[]
        /// </summary>
       // public String[] AllColumnNames  { get; set; }
        //string _TxName;
        //public String TxName
        //{
        //    get { return _TxName;  }
        //    set { _TxName = value;  }
        //}
        /// <summary>
        /// Default columns
        /// </summary>
        //public int ID_C             { get; set; }
        //public int GUID_C           { get; set; }

        public void Initialization(string[,] table)
        {
            //c_TXTable = new TXTable(_TxName);
         //   AllColumnNames = txTable.Column.AllNames;
         //   AllColumnTypes = txTable.Column.AllTypes;
            _TXTable = table;

        }
        /// <summary>
        /// Add Column Type of a Column
        /// </summary>
        /// <param name="columnName">Column Name</param>
        /// <returns>Returns a multidimentional array string[,]</returns>
        public string[,] addColumnType(string[] columnName)
        {
            zColumn.szTable = _TXTable;
            zColumn.Initialize();
            int colCount = columnName.Count();
            string[,] columns = new string[colCount, 2];
            for (int ix = 0; ix < colCount; ix++)
            {
                columns[ix, 0] = columnName[ix];
                columns[ix, 1] = zColumn.Typeof(columnName[ix]);
            }
            return columns;
        }
        /// <summary>
        /// Get all by column Index. 
        /// Set Value to properties ColumnName and Values before calling this function
        /// </summary>
        /// <param name="columnName">Column Name.</param>
        /// <param name="values">Value to search</param>
        /// <returns>Returns a DataTable</returns>
        public bool GetAll_By()
        {
            //check if both have same length.
            _DataResult = new DataTable();
            _DataResult.Clear();
            int colCount = _ColumnName.Count();
            int idxCount = _Values.Count();

            if (colCount != idxCount)
            {
                _DbStatus = "Columns and Values do not match.";
                goto Exit;
            }

            string[,] columns = addColumnType(_ColumnName);
            _DataResult = dbqStatement.SelectAll_By(_TableName, columns, _Values);
            if (_DataResult != null) //found
            {
                return true;
            }
            else
                _DbStatus = dbqStatement.DbStatus;
        Exit:
            return false;
        }
        public virtual string[,] addDefaultColumns()
        {
            string[,] defaultColumns = {
                                      {_TXTable[0,0],_TXTable[0,1]}, //TableID
                                      {_TXTable[1,0],_TXTable[1,1]} //GUID
                                    };
            return defaultColumns;
        }
        public virtual string[] addDefaultValues()
        {
            return _Values;
        }

        /// <summary>
        /// Add values into Table
        /// Set Value to properties ColumnName and Values before calling this function
        /// </summary>
        /// <param name="columnName">Column name to add</param>
        /// <param name="Values">Values</param>
        public virtual void Insert()
        {
            int valCount = _Values.GetLength(0);
            if (valCount <= 0)
            {
                _DbStatus = "No Values to Add.";
                goto ErrorMsg;
            }

            string[,] defaultColumns = addDefaultColumns();
            string[,] columnsToAdd = addColumnType(_ColumnName);

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
            //Table dbTable = new Table();
            String[] newValues = addDefaultValues();
            dbqStatement.TableName = _TableName;
            dbqStatement.ColumnName = columns;
            dbqStatement.Values = newValues;
            if (dbqStatement.INSERT_INTO())
                return;
            else
                _DbStatus = dbqStatement.DbStatus;

        ErrorMsg:
            return;
        }
        /// <summary>
        /// Update Values where TableID == ID 
        /// Set Value to properties ColumnName and Values before calling this function
        /// </summary>
        /// <param name="columnName">Column to be updated</param>
        /// <param name="values">Values</param>
        /// <param name="ID">Condition: TableID = ID</param>
        public void Update( string Condition)
        {
            //check if both have same length.
            int colCount = _ColumnName.Count();
            int idxCount = _Values.Count();

            if (colCount != idxCount)
            {
                _DbStatus = "Columns and Values do not match.";
                goto Exit;
            }
            string[,] columns = addColumnType(_ColumnName);
           // Table dbTable = new Table();
            dbqStatement.TableName = _TableName;
            dbqStatement.ColumnName = columns;
            dbqStatement.Values = _Values;
            dbqStatement.Condition = Condition;
            bool update = dbqStatement.Update_Table();
            if (update)
                return;
            else
                _DbStatus = dbqStatement.DbStatus;

        Exit:
            return;
        }
        /// <summary>
        /// Get All records.
        /// </summary>
        /// <returns></returns>
        public bool GetAll()
        {
            _DataResult = new DataTable();
            _DataResult.Clear();
            _DataResult = dbqStatement.SelectAll(_TableName);
            if (_DataResult != null) //found
            {
                //  _DataResult = statement.resultTable;
               // InitializeDataTable();
                return true;
            }
            else
                _DbStatus = dbqStatement.DbStatus;
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
    }
}
