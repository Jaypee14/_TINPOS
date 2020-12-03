using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TINPOS_Project.Class;
using TINPOS_Project.Class.DbFunction;
using TINPOS_Project.Class.ProjectClass;
using TINPOS_Project.Class.DBTables.DbColumns;

namespace TINPOS_Project.Window_Forms.Admin
{
    public partial class ML_MenuLevel : Form
    {
        S01 S01 = new S01();
        S02 S02 = new S02();
        T01 T01 = new T01();
        Shared shr = new Shared();

        public bool Saved = false;
        public string MenuLevel;

        public ML_MenuLevel()
        {
            InitializeComponent();

        }

        private void btn_Save_Click(object sender, EventArgs e)
        {

            //check first if Menu Level do not exist.
            S02.ColumnName = new string[] {s02.Group_Name};
            S02.Values     = new string[] {txb_Name.Text};
            bool s02Found = S02.GetAll_By();
            if (s02Found) //Menu Level exist
            {
                shr.errMsg = "Existing Menu Level.";
                goto Exit;
            }
            //Add to S02
            //Get all S01
            //Insert all S01 to T01.

            S02.ColumnName = new string[]
                            {   s02.Group_Name,
                                s02.Description
                            };
            S02.Values = new string[]
                            {   txb_Name.Text,
                                txb_Description.Text
                            };
            S02.Insert(); // Add to s02.

            s02Found = S02.GetAll_By();
            int szS02_ID = Convert.ToInt32(S02.ValueOf(s02.ID)); //get the S02 ID


            if (!S01.GetAll()) //no S01 found
            {
                shr.errMsg = "No Transactions found";
                goto Exit;
            }
            DataTable s01Data = S01.DataResult;
            T01.ColumnName = new string[]
                            { t01.S02_ID,
                              t01.S01_ID,
                              t01.ACCESS
                            };
            string[] t01_Val = new string[T01.ColumnName.GetLength(0)];

            var result = from myresult in s01Data.AsEnumerable()
                         select myresult;
            foreach (var data in result)
            {
                int szS01_ID = data.Field<int>(s01.ID);
                t01_Val[0] = szS02_ID.ToString();
                t01_Val[1] = szS01_ID.ToString();
                t01_Val[2] = "0";
                T01.Values = t01_Val;
                T01.Insert();             
            }

            Saved = true;
            MenuLevel = txb_Name.Text;
            this.Close();
            return;

            Exit:
            shr.ErrorMessage("AddMenuLevel:", shr.errMsg);
            Saved = false;
        }
    }
}
