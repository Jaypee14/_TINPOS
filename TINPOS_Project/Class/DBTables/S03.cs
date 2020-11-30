using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TINPOS_Project.Class.DbFunction
{
    //Derived Class (Child)
    class S03 : DBQTable
    {
        public override DataTable DataResult      { get; set; }
        public string tableName          { get { return "S03_USER_ACCESS"; } }
        public string txName             { get { return "TXS03"; } }
        //Column Index
        private int ID_i                 { get { return 0; } }
        private int GUID_i               { get { return 1; } }

        public string ID                 { get; set; }
        public string GUID               { get; set; }
        public string A02_ID             { get; set; }
        public string S02_ID             { get; set; }
        public string S01_ID             { get; set; }
        public string ACCESS             { get; set; }

        //Constructor
        public S03() 
        {
            //Default Columns.
            ID_C = ID_i;
            GUID_C = GUID_i;

            TableName = tableName;
            TxName = txName;
            Initialization();

            ID     = Table.Column.Name(0);
            GUID   = Table.Column.Name(1);
            A02_ID = Table.Column.Name(2);
            S02_ID = Table.Column.Name(3);
            S01_ID = Table.Column.Name(4);
            ACCESS = Table.Column.Name(5);

        }

        public int get_MenuLevel(int userID)
        {
            int menuID = 0;
            string[] col = { A02_ID };
            string[] val = { userID.ToString() };
            Get_All_By(col, val);
            DataTable data = DataResult;
            data.DefaultView.Sort = S02_ID + " desc";
            data = data.DefaultView.ToTable();
            if (data.Rows.Count > 0)
            {
                DataRow row = data.Rows[0];
                menuID = Convert.ToInt32(row[S02_ID]);
            }
            return menuID;
        }

     


    }
}
