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
using TINPOS_Project.Class.POSDatabase;

namespace TINPOS_Project.Window_Forms.Admin
{
    public partial class ML_MenuLevel : Form
    {
        S01 s01 = new S01();
        S02 s02 = new S02();
        T01 t01 = new T01();

        public bool Saved = false;
        public string MenuLevel;

        public ML_MenuLevel()
        {
            InitializeComponent();
            s01.Initialization();
            s02.Initialization();
            t01.Initialization();

        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            c_Shared shr = new c_Shared();
            c_Database db = new c_Database();
            //check first if Menu Level do not exist.
            int[] s02Col = {s02.Group_Name_C};
            string[] s02Val = {txb_Name.Text};
            DataTable szS02Data = s02.get_All_By(s02Col, s02Val);
            if (szS02Data.Rows.Count != 0) //Menu Level exist
            {
                shr.errMsg = "Existing Menu Level.";
                goto Exit;
            }
            //Add to S02
            //Get all S01
            //Insert all S01 to T01.

            /*
             (TXS02),_4
                S02_ID,9
                S02_GUID,G
                S02_GROUP_NAME,X
                S02_DESCRIPTION,X;
             */
            int[] s02_Col = {   s02.Group_Name_C,
                                s02.Description_C
                            };
            string[] s02_Val = {txb_Name.Text,
                                txb_Description.Text
                               };
            s02.AddValues(s02_Col,s02_Val); // Add to s02.

            szS02Data = new DataTable();
            szS02Data = s02.get_All_By(s02Col,s02Val);
            int szS02_ID = szS02Data.Rows[0].Field<int>(s02.Columns_C[s02.ID_C]); //get the S02 ID


            DataTable s01Data = db.Get_All(s01.TableName);
          
            int[] t01_Col = { t01.S02_ID_C,
                              t01.S01_ID_C,
                              t01.ACCESS_C
                            };
            string[] t01_Val = new string[t01_Col.GetLength(0)];

            var result = from myresult in s01Data.AsEnumerable()
                         select myresult;
            foreach (var data in result)
            {
                int szS01_ID = data.Field<int>(s01.Columns_C[s01.ID_C]);
                t01_Val[0] = szS02_ID.ToString();
                t01_Val[1] = szS01_ID.ToString();
                t01_Val[2] = "0";
                t01.AddValues(t01_Col, t01_Val);             
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
