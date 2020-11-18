using System;
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
            using (SqlDataAdapter reader = new SqlDataAdapter(query, sql_con))
            {
                DataSet datatable = new DataSet();
                reader.Fill(datatable);
                dbClose();
                return datatable.Tables[0];
            }
        }

        public void INSERT_INTO(String TableName, String[] ColumnName , String[] Values)
        {
            Boolean hasGuid = false;
            String szColumnNames = "";
            String szValues = "";
            int szColCount = ColumnName.GetLength(0);
            int szRowCount = Values.GetLength(0);

            int ix = 0;
            var szCheckColumns = from szColName in ColumnName
                              select szColName;
            foreach (var szColName in szCheckColumns)
            {
                if (szColName.Contains("_ID"))
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




        /*      public string GET_ALL(String TableName) 
              {
                  S01_SCRN_TRANS S01 = new S01_SCRN_TRANS();
                  SqlCommand cmd = new SqlCommand("Select * from [" + TableName + "]", sql_con);
                  using (SqlDataReader reader = cmd.ExecuteReader())
                  {
                      while (reader.Read())
                      {
                          S01 = shr.MapToClass<S01_SCRN_TRANS>(reader);
                          MessageBox.Show(S01.S01_GUID.ToString());
                      }
                      return "";
                  }
              }*/
        public DataTable Get_All(String TableName)
        {
            dbOpen();
            String query = "Select * from [" + TableName + "]";

            DataTable szData = dbSqlDataAdapter(query);
            return szData;

            //using (SqlDataAdapter reader = new SqlDataAdapter(query, sql_con)) ----------111520
            //{
            //    DataSet datatable = new DataSet();
            //    reader.Fill(datatable);
            //    dbClose();
            //    return datatable.Tables[0];
            //}
        }
          
        public DataTable Get_ByID(String TableName, int ID)
        {
            dbOpen();
            String query = "Select * from [" + TableName + "] " +
                            "Where " + TableName.Substring(0,3) + "_ID = " + ID ;

            DataTable szData = dbSqlDataAdapter(query);
            return szData;


            //using (SqlDataAdapter reader = new SqlDataAdapter(query, sql_con))  ------------111520
            //{
            //    DataSet datatable = new DataSet();
            //    reader.Fill(datatable);
            //    dbClose();
            //    return datatable.Tables[0];
            //}

        }

    }
}
