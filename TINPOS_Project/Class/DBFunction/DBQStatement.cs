using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Reflection;
using TINPOS_Project.Class._Interface;
using TINPOS_Project.Class.ProjectClass;



namespace TINPOS_Project.Class.DbFunction
{

    class DBQStatement : IDBQStatement
    {
        
        //Variables
        SqlConnection    sql_con;
        private string Connection { get { return @"Server=192.168.100.12,1005;Initial Catalog=db_POSDatabase;User ID=sa;Password=Jaypz100519"; } }

        private string _TableName;
        public string TableName
        {
            get { return _TableName; }
            set { _TableName = value; }
        }

        private string[,] _ColumnName;
        public string[,] ColumnName
        {
            get { return _ColumnName; }
            set { _ColumnName = value; }
        }

        private string[] _Values;
        public string[] Values
        {
            get { return _Values; }
            set { _Values = value; }
        }

        private string _Condition;
        public string Condition
        {
            get { return _Condition; }
            set { _Condition = value; }
        }

        private string _DbStatus;
        public string DbStatus
        {
            get { return _DbStatus; }
            set { _DbStatus = value; }
        } 

        //*********** PROCEDURES

        public bool dbOpen()
        {
            sql_con = new SqlConnection(Connection);   
            try
            {
                sql_con.Open();
                return true;
            }
            catch (Exception e)
            {
                _DbStatus = e.Message;
                return false;
            }
        }
        public void dbClose()
        {
            if (sql_con.State == ConnectionState.Open)
                sql_con.Close();
           
        }
        public bool INSERT_INTO()
        {
            Boolean hasGuid = false;
            String szColumnNames = "";
            String szValues = "";
            int szColCount = _ColumnName.GetLength(0);
            int szRowCount = _Values.Count();
            string szTableID = _TableName.Substring(0, 4) + "ID";

            if ((szColCount - 2) != szRowCount) //Less 2 because ID and GUID has default values
            {
                _DbStatus = "Columns and Values does not match.";
                goto ErrorMsg;
            }

            for (int ix = 0; ix < szColCount; ix++)
            {
                if (_ColumnName[ix, 0] == szTableID)
                    continue;

                if (_ColumnName[ix, 0].Contains("_GUID"))
                    hasGuid = true;

                szColumnNames = szColumnNames + _ColumnName[ix, 0];
               

                if (_ColumnName[ix,1].Contains('G')) //GUID
                    szValues = "@guidValue";

                else if (_ColumnName[ix, 1].Contains('9')) //Int
                {
                    if (_Values[ix - 2] != string.Empty)
                        szValues = szValues + _Values[ix - 2];
                    else
                        szValues = szValues + 0;
                }

                else if (_ColumnName[ix, 1].Contains('X')) //String
                    szValues = szValues + "'" + _Values[ix-2] + "'";

                if (ix != szColCount - 1)
                {
                    szColumnNames = szColumnNames + ", ";
                    szValues = szValues + ", ";
                }
            }

            if (dbOpen())
            {
                using (SqlTransaction trans = sql_con.BeginTransaction())
                using (SqlCommand cmd = sql_con.CreateCommand())
                {
                    cmd.Transaction = trans;
                    cmd.CommandText = @"INSERT INTO " +
                        _TableName +
                        "(" +
                        szColumnNames +
                        ") VALUES (" +
                       szValues +
                        ")";

                    if (hasGuid == true)
                        cmd.Parameters.AddWithValue("@guidValue", Guid.NewGuid());
                    try
                    {
                        cmd.ExecuteNonQuery();
                    }
                    catch  (Exception e)
                    {
                        _DbStatus = e.Message;
                        goto ErrorMsg;
                    }

                    trans.Commit();
                    cmd.Dispose();
                    dbClose();
                }
                return true;
            }
        ErrorMsg:
            return false;
        }
        public bool Update_Table()
        {
            //check if both have same length.
            int colCount = _ColumnName.GetLength(0);
            int valCount = _Values.Count();
            if (colCount != valCount)
            {
                _DbStatus = "Columns and Values do not match.";
                goto Exit;
            }

            string q_set = "";

            for (int ix = 0; ix < colCount; ix++)
            {
                if (_ColumnName[ix, 1].Contains('9')) //Int
                    q_set = q_set + _ColumnName[ix, 0] + " = " + _Values[ix];

                else if (_ColumnName[ix, 1].Contains('X')) //String
                    q_set = q_set + _ColumnName[ix, 0] + " = '" + _Values[ix] + "'";

                if (ix < colCount - 1)
                    q_set = q_set + ", ";
            }

            String query = "Update [" + _TableName + "] " +
                            "Set " + q_set +
                            " Where " + _Condition;
            try
            {
                if (dbOpen())
                {
                    using (SqlCommand command = sql_con.CreateCommand())
                    {
                        command.CommandText = query;
                        command.ExecuteNonQuery();
                        dbClose();
                        return true;
                    }
                }
                else
                    goto Exit;
            }
            catch (Exception e)
            {
                _DbStatus = e.Message;
                goto Exit;
            }

        Exit:
            return false;
        }
        public DataTable SelectAll(String TableName)
        {
            String query = "Select * from [" + TableName + "]";
          //  resultTable = new DataTable();
            try
            {
                if (dbOpen())
                {
                    using (SqlDataAdapter reader = new SqlDataAdapter(query, sql_con))
                    {
                        DataSet datatable = new DataSet();
                        reader.Fill(datatable);
                        dbClose();
                        return datatable.Tables[0];
                    }
                }
                else
                    goto Exit;
            }
            catch (Exception e)
            {
                _DbStatus = e.Message;
                goto Exit;
            }
            Exit:
            return null;
        }
        public DataTable SelectAll_By(string TableName, string[,] columns, string[] values)
        {
            int colCount = columns.GetLength(0);
            int valCount = values.Count();

            if (colCount != valCount)
            {
                _DbStatus = "Columns and Values do not match.";
                goto Exit;
            }

            string q_condition = "";

            for (int ix = 0; ix < colCount; ix++)
            {
                if (columns[ix,1].Contains('9')) //Integer
                    q_condition = q_condition + columns[ix, 0] + " = " + values[ix];
               
                else if(columns[ix,1].Contains('X')) //String
                    q_condition = q_condition + columns[ix, 0] + " = '" + values[ix] + "'";

                if (ix < colCount - 1)
                    q_condition = q_condition + " and ";
            }

            String query = "Select * from [" + TableName + "] " +
                            "Where " + q_condition;
            try
            {
                if (dbOpen())
                {
                    using (SqlDataAdapter reader = new SqlDataAdapter(query, sql_con))
                    {
                        DataSet datatable = new DataSet();
                        reader.Fill(datatable);
                        dbClose();
                        if (datatable.Tables[0].Rows.Count <= 0)
                            goto Exit;

                        return datatable.Tables[0];
                        //return true;
                    }
                }
                else
                    goto Exit;
            }
            catch (Exception e)
            {
                _DbStatus = e.Message;
                goto Exit;
            }

        Exit:
            return null;
        }


    }
}
