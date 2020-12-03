using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TINPOS_Project.Class.DBTables.DbColumns;

namespace TINPOS_Project.Class.DbFunction
{
    //Derived Class (Child)
    class S03 : DBQTable
    {
        //Constructor
        public S03() 
        {

            TableName = s03.TableName;
            Initialization(s03.txTable);
        }

        public int get_MenuLevel(int userID)
        {
            int menuID = 0;
            ColumnName = new string[] { s03.A02_ID };
            Values = new string[] { userID.ToString() };
            if (GetAll_By())
            {
                DataTable data = DataResult;
                data.DefaultView.Sort = s03.S02_ID + " desc";
                data = data.DefaultView.ToTable();
                if (data.Rows.Count > 0)
                {
                    DataRow row = data.Rows[0];
                    menuID = Convert.ToInt32(row[s03.S02_ID]);
                }
                return menuID;
            } //Error in Query
            return 0;
        }

     


    }
}
