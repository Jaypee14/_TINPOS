using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;



namespace TINPOS_Project.Class
{

    class c_Database
    {
        
       /******************   DATABASE CONNECTION AND QUERIES  ****************
        * 
        * 07/11/20     JL     #00000
        * 
        * 
        * 
        * 
        * 
        *********************************************************************/


        //************* DECLARATION
        //Classes
        c_TX_Database tx_db = new c_TX_Database();
        c_Shared tx_sh = new c_Shared();


        //Variables
        SqlConnection sql_con;




        //*********** PROCEDURES

        public void dbOpen()
        {           
            sql_con = new SqlConnection(tx_db.conStr);   
            try
            {
                sql_con.Open();
            }
            catch (Exception e)
            {
                tx_sh.ErrorMessage("dbConnect()", e.Message);
                sql_con.Close();
                System.Environment.Exit(0);
            }
        }

        public void dbClose()
        {
            if (sql_con.State == ConnectionState.Open)
                sql_con.Close();
        }
         
        



    }
}
