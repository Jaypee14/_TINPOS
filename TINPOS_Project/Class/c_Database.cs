﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Reflection;
using TINPOS_Project.Class.POSDatabase;


namespace TINPOS_Project.Class
{
  
    class c_Database
    {
        
       /******************   DATABASE CONNECTION AND QUERIES  ****************
        * 
        * 07/11/20     JL     #00000
        * 
        *********************************************************************/


        //************* DECLARATION
        //Classes
       // c_TX_Database    txdb = new c_TX_Database();
        c_Shared         shr = new c_Shared();
 

        //Variables
        SqlConnection    sql_con;
        public String conStr = @"Server=192.168.100.12,1005;Initial Catalog=db_POSDatabase;User ID=sa;Password=Jaypz100519";

             

        //*********** PROCEDURES

        public void dbOpen()
        {           
            sql_con = new SqlConnection(conStr);   
            try
            {
                sql_con.Open();
                
            }
            catch (Exception e)
            {
                shr.ErrorMessage("dbConnect()", e.Message);
                sql_con.Close();
                System.Environment.Exit(0);
            }

        }

        public void dbClose()
        {
            if (sql_con.State == ConnectionState.Open)
                sql_con.Close();
        }



        public DataTable dbSqlDataAdapter(String query)
        {
            try
            {
                dbOpen();
                using (SqlDataAdapter reader = new SqlDataAdapter(query, sql_con))
                {
                    DataSet datatable = new DataSet();
                    reader.Fill(datatable);
                    dbClose();
                    return datatable.Tables[0];
                }
            }
            catch (Exception e)
            {
                shr.ErrorMessage("QueryError: ", query + " " + e.Message);
                return null;
            }
        }

        public void dbExecuteNonQuery(string query)
        {
            try
            {
                dbOpen();
                using (SqlCommand command = sql_con.CreateCommand()){
                    command.CommandText = query;
                    command.ExecuteNonQuery();
                    dbClose();
                }
            }
            catch (Exception e)
            {
                shr.ErrorMessage("UpdateError: ", query + " " + e.Message);
            }
        }

        public void INSERT_INTO(String TableName, String[] ColumnName , String[] Values)
        {
            Boolean hasGuid = false;
            String szColumnNames = "";
            String szValues = "";
            int szColCount = ColumnName.Count();
            int szRowCount = Values.Count();
            string szTableID = TableName.Substring(0, 4) + "ID";

            int ix = 0;
            var szCheckColumns = from szColName in ColumnName
                              select szColName;
            foreach (var szColName in szCheckColumns)
            {

                if (szColName == szTableID)
                    goto Next;

                if (szColName.Contains("_GUID"))
                    hasGuid = true;

                szColumnNames = szColumnNames + szColName;

                if (ix != szColCount - 1)
                    szColumnNames = szColumnNames + ", ";
            Next:
                ix++;
            }

            ix = 0;
            if (hasGuid)
                szValues = "@guidValue, ";
            var szCheckValues = from szVal in Values
                                select szVal;
            foreach (var szVal in szCheckValues)
            {
                szValues = szValues + "'" + szVal + "'";

                if (ix != szRowCount - 1)
                    szValues = szValues + ", ";
                ix++;
            }
       
            dbOpen();
            using (SqlTransaction trans = sql_con.BeginTransaction())
            using (SqlCommand cmd = sql_con.CreateCommand())
            {
                cmd.Transaction = trans;
                cmd.CommandText = @"INSERT INTO " + 
                    TableName       +
                    "("             +
                    szColumnNames   +
                    ") VALUES ("    +
                   szValues         +
                    ")"             ;

                if (hasGuid == true)
                    cmd.Parameters.AddWithValue("@guidValue", Guid.NewGuid());
                try {
                    cmd.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    shr.errMsg = e.Message;
                    goto ErrorMsg;
                }
                    
                trans.Commit();
                cmd.Dispose();
                dbClose();
            }

            return;

        ErrorMsg:
            shr.ErrorMessage("InsertInto()", shr.errMsg);
        
        }

        public DataTable Get_All(String TableName)
        {
            String query = "Select * from [" + TableName + "]";
            DataTable szData = dbSqlDataAdapter(query);
            return szData;
        }

        public DataTable Get_All_By(string TableName, string[] columns, int[] values)
        {
           
            //check if both have same length.
            int colCount = columns.Count();
            int valCount = values.Count();

            if (colCount != valCount)
            {
                shr.errMsg = "Columns and Values do not match.";
                goto Exit;
            }

            string q_condition = "";

            for (int ix = 0; ix < colCount; ix++)
            {
                q_condition = q_condition + columns[ix] + " = " + values[ix];
                if (ix < colCount - 1)
                    q_condition = q_condition + " and ";
            }

            String query = "Select * from [" + TableName + "] " +
                            "Where " + q_condition;
            DataTable szData = dbSqlDataAdapter(query);
            return szData;

        Exit:
            shr.ErrorMessage(TableName + ": ", shr.errMsg);
            return null;
        }

        public void Update_Table(string TableName, string[] Columns, string[] Values, string Condition)
        {
            //check if both have same length.
            int colCount = Columns.Count();
            int valCount = Values.Count();
            if (colCount != valCount)
            {
                shr.errMsg = "Columns and Values do not match.";
                goto Exit;
            }

            string q_set = "";

            for (int ix = 0; ix < colCount; ix++)
            {
                q_set = q_set + Columns[ix] + " = " + Values[ix];
                if (ix < colCount - 1)
                    q_set = q_set + ", ";
            }

            String query = "Update [" + TableName + "] " +
                            "Set " + q_set +
                            " Where " + Condition;
            dbExecuteNonQuery(query);
            return;

            Exit:
            shr.ErrorMessage(TableName + ": ", shr.errMsg);
        }
          


    }
}
