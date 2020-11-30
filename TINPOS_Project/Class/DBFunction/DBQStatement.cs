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
       // String conStr = @"Server=192.168.100.12,1005;Initial Catalog=db_POSDatabase;User ID=sa;Password=Jaypz10051";

        public string Connection { get { return @"Server=192.168.100.12,1005;Initial Catalog=db_POSDatabase;User ID=sa;Password=Jaypz100519"; } }
        /// <summary>
        /// returns DataTable. Result of Select All statement. Use this if selecting more than one row.
        /// </summary>
        public DataTable resultTable { get; set; }
        /// <summary>
        /// returns Array of string. Use this if selecting one row only
        /// </summary>
     //   public string[] resultString { get; set; }


        //*********** PROCEDURES

        public bool dbOpen()
        {
            sql_con = new SqlConnection(Connection);   
            try
            {
                sql_con.Open();
                return true;
            }
            catch
            {
                //ErrorMessage("dbConnect()", e.Message);
                //sql_con.Close();
                ////System.Environment.Exit(0);
                return false;
            }
        }
        public void dbClose()
        {
            if (sql_con.State == ConnectionState.Open)
                sql_con.Close();
           
        }
        public bool INSERT_INTO(String TableName, String[,] ColumnName , String[] Values)
        {
            Boolean hasGuid = false;
            String szColumnNames = "";
            String szValues = "";
            int szColCount = ColumnName.GetLength(0);
            int szRowCount = Values.Count();
            string szTableID = TableName.Substring(0, 4) + "ID";

            if ((szColCount - 2) != szRowCount) //Less 2 because ID and GUID has default values
            {
                //errMsg = "Columns and Values does not match.";
                goto ErrorMsg;
            }

            for (int ix = 0; ix < szColCount; ix++)
            {
                if (ColumnName[ix, 0] == szTableID)
                    continue;

                if (ColumnName[ix, 0].Contains("_GUID"))
                    hasGuid = true;

                szColumnNames = szColumnNames + ColumnName[ix, 0];
               

                if (ColumnName[ix,1].Contains('G')) //GUID
                    szValues = "@guidValue";

                else if (ColumnName[ix, 1].Contains('9')) //Int
                {
                    if (Values[ix - 2] != string.Empty)
                        szValues = szValues + Values[ix - 2];
                    else
                        szValues = szValues + 0;
                }

                else if (ColumnName[ix, 1].Contains('X')) //String
                    szValues = szValues + "'" + Values[ix-2] + "'";

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
                        TableName +
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
                    catch // (Exception e)
                    {
                        //errMsg = e.Message;
                        goto ErrorMsg;
                    }

                    trans.Commit();
                    cmd.Dispose();
                    dbClose();
                }
                return true;
            }
        ErrorMsg:
            //ErrorMessage("InsertInto() " + TableName + ": ", errMsg);
            return false;
        }
        public bool Update_Table(string TableName, string[,] Columns, string[] Values, string Condition)
        {
            //check if both have same length.
            int colCount = Columns.GetLength(0);
            int valCount = Values.Count();
            if (colCount != valCount)
            {
                //errMsg = "Columns and Values do not match.";
                goto Exit;
            }

            string q_set = "";

            for (int ix = 0; ix < colCount; ix++)
            {
                if (Columns[ix, 1].Contains('9')) //Int
                    q_set = q_set + Columns[ix, 0] + " = " + Values[ix];

                else if (Columns[ix, 1].Contains('X')) //String
                    q_set = q_set + Columns[ix, 0] + " = '" + Values[ix] + "'";

                if (ix < colCount - 1)
                    q_set = q_set + ", ";
            }

            String query = "Update [" + TableName + "] " +
                            "Set " + q_set +
                            " Where " + Condition;
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
            catch
            {
                //ErrorMessage("UpdateError: ", query + " " + e.Message);
                goto Exit;
            }

        Exit:
            //ErrorMessage(TableName + ": ", errMsg);
            return false;
        }
        public bool SelectAll(String TableName)
        {
            String query = "Select * from [" + TableName + "]";
            resultTable = new DataTable();
            try
            {
                if (dbOpen())
                {
                    using (SqlDataAdapter reader = new SqlDataAdapter(query, sql_con))
                    {
                        DataSet datatable = new DataSet();
                        reader.Fill(datatable);
                        dbClose();
                        resultTable = datatable.Tables[0];
                        if (resultTable.Rows.Count <= 0) //if no records found
                            return false;

                        return true;
                    }
                }
                else
                    goto Exit;
            }
            catch //(Exception e)
            {
                goto Exit;
            }
            Exit:
            //ErrorMessage("QueryError: ", query + " " + e.Message);
            return false;
        }
        public bool SelectAll_By(string TableName, string[,] columns, string[] values)
        {
            resultTable = new DataTable();
            //check if both have same length.
            int colCount = columns.GetLength(0);
            int valCount = values.Count();

            if (colCount != valCount)
            {
                //errMsg = "Columns and Values do not match.";
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
            //DataTable szData = dbSqlDataAdapter(query);
            //return szData;
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

                        resultTable = datatable.Tables[0];
                        return true;
                    }
                }
                else
                    goto Exit;
            }
            catch //(Exception e)
            {
                goto Exit;
            }

        Exit:
            //ErrorMessage(TableName + ": ", errMsg);
            return false;
        }


    }
}
