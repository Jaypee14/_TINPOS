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

    public partial class SM_SecurityMaintenance : Form
    {
       

        //Classes
        A02 a02 = new A02();
        S01 s01 = new S01();
        S02 s02 = new S02();
        S03 s03 = new S03();
        T01 t01 = new T01();
        c_Database db = new c_Database();
        
        
        //dgv_Main_Colnumbers
        int             dgc_ID                = 0,
                        /*dgc_No              = 1,*/
                        dgc_Screen            = 2,
                        dgc_TransName         = 3,
                        dgc_ParentAccess      = 4,
                        dgc_ExtraScreen       = 5,
                        dgc_Indicator         = 6;

        int             dgv_SelectedRowIndex  = 0;
        DataTable       queryTable            = new DataTable();
        bool            szMenuLevel           = false;
        int             szA02_ID              = 0;


        public SM_SecurityMaintenance()
        {
            InitializeComponent();
            a02.Initialization();
            s01.Initialization();
            s02.Initialization();
            s03.Initialization();
            t01.Initialization();

            DisableButtons();
        }

        private void SM_SecurityMaintenance_Load(object sender, EventArgs e)
        {

         
        }

        private void DisableButtons()
        {
            btn_Add.Enabled    = false;
            btn_Remove.Enabled = false;
            btn_Update.Enabled = false;
        }
        private void EnableButtons()
        {
            btn_Add.Enabled    = true;
            btn_Remove.Enabled = true;
            btn_Update.Enabled = true;
        }

        private void Initialize_queryTable()
        {
            queryTable.Clear();
            queryTable.Columns.Clear();
            queryTable.Columns.Add("ROWINDEX", typeof(int));
            queryTable.Columns.Add("ACTION", typeof(string));
            queryTable.Columns.Add("VALUES", typeof(string));
        }

       
     

        private void btn_Enquire_Click(object sender, EventArgs e)
        {
            //for Datagrid ID, if Menu Level, ID is from T01
            //if userID, ID is from S03.
            // ----------- if Transaction is not in S03 yet, ID is from T01.
            // ----------- if Transaction is in S03, ID is from S03.
            //Format of ID is Table_ID
            // -------example T01_1 or S03_1.

            c_Shared shr = new c_Shared();

            dgv_Main.Rows.Clear();

            int         szS02_ID            = 0;
            string      szUsrID_Menu        = cmb_ID.Text;
            int         sz_Extra_Access;
            
            DataTable   Extra_Access        = new DataTable();
            string      szDgv_ID            = "";

            if (szUsrID_Menu == string.Empty)
                return;

            //Search For Menu Level in S02
            DataTable szS02Data = new DataTable();
            szS02Data = db.Get_All(s02.TableName);
            var szResult = from myResult in szS02Data.AsEnumerable()
                           where myResult.Field<string>(s02.Columns_C[s02.Group_Name_C].ToString()) == szUsrID_Menu
                           select myResult;
            foreach (var result in szResult)
            {
                szMenuLevel = true;
                szS02_ID = result.Field<int>(s02.Columns_C[s02.ID_C]);
                cmb_Child.Text = result.Field<string>(s02.Columns_C[s02.Group_Name_C]).ToString();
            }
            if (szMenuLevel)
                goto Display_DGV;


            //Search for userID in A02
            DataTable szA02Data = new DataTable();
            szA02Data = a02.get_By_UserID(szUsrID_Menu);
            if (szA02Data.Rows.Count == 0)
            {
                shr.errMsg = "User ID/Menu Level not Found";
                goto Exit;
            }


            //Search for S03
            szA02_ID = Int32.Parse(szA02Data.Rows[0][a02.Columns_C[a02.ID_C]].ToString());
            DataTable szS03Data = s03.get_S03_By_A02(szA02_ID);
            if (szS03Data.Rows.Count == 0)
            {
                shr.errMsg = "No Menu Level linked to userID " + szUsrID_Menu.ToUpper();
                goto Exit;
            }

            Extra_Access.Columns.Add(s03.Columns_C[s03.S01_ID_C].ToString());
            Extra_Access.Columns.Add(s03.Columns_C[s03.ACCESS_C].ToString());
            Extra_Access.Columns.Add(s03.Columns_C[s03.ID_C].ToString());

            int szS03_Count = szS03Data.Rows.Count;
            for (int ix = 0; ix < szS03_Count; ix++)
            {
                //If S03_S02_ID is empty, get the S01 record and add value to sz_Extra_Access
                //else go to Display_DGV to display the Parent's Access
                if (szS02_ID == 0)
                {
                    int szS03_S02_ID = Int32.Parse(szS03Data.Rows[ix][s03.Columns_C[s03.S02_ID_C]].ToString());
                    if (szS03_S02_ID != 0)
                    {
                        szS02_ID = szS03_S02_ID;
                        continue;
                    }
                } 

                int szS03_S01_ID = Int32.Parse(szS03Data.Rows[ix][s03.Columns_C[s03.S01_ID_C]].ToString());
                int szS03_ACCESS = Int32.Parse(szS03Data.Rows[ix][s03.Columns_C[s03.ACCESS_C]].ToString());
                int szS03_ID     = Int32.Parse(szS03Data.Rows[ix][s03.Columns_C[s03.ID_C]].ToString());
                if (szS03_S01_ID != 0)
                {
                    Extra_Access.Rows.Add(szS03_S01_ID, szS03_ACCESS, szS03_ID);
                }
            }

            //Get S02
            DataTable szTempS02 = s02.Get_By_ID(szS02_ID);
            cmb_Parent.Text = szTempS02.Rows[0][s02.Columns_C[s02.Group_Name_C]].ToString();
            cmb_Child.Text = szA02Data.Rows[0][a02.Columns_C[a02.UserID_C]].ToString();
            txt_Name.Text = szA02Data.Rows[0][a02.Columns_C[a02.FirstName_C]].ToString() + " " +
                            szA02Data.Rows[0][a02.Columns_C[a02.LastName_C]].ToString();

        Display_DGV: //Search for T01
            DataTable szT01Data = new DataTable();
            szT01Data = t01.get_T01_By_S02(szS02_ID);
            int szRowCount = szT01Data.Rows.Count;
            int szDataNo = 0;
            int szScreenRowIndex = 0;
            int szScreenCount = 0;
            int szScreenTrans_P_Checked = 0;
            int szScreenTrans_C_Checked = 0;
            string szPrevScreenName = "";
            
            for (int ix = 0; ix < szRowCount; ix++)
            {
                
                int szT01_S01_ID = Int32.Parse(szT01Data.Rows[ix][t01.S01_ID_C].ToString());
                int szT01_Access = Int32.Parse(szT01Data.Rows[ix][t01.ACCESS_C].ToString());
                int szT01_ID     = Int32.Parse(szT01Data.Rows[ix][t01.ID_C].ToString());
                int szS03_ID = 0;

                sz_Extra_Access = szT01_Access;
                if (Extra_Access.Rows.Count != 0)
                {
                    szResult = from myResult in Extra_Access.AsEnumerable()
                               where myResult.Field<string>(s03.Columns_C[s03.S01_ID_C].ToString()) == szT01_S01_ID.ToString()
                               select myResult;
                    foreach (var result in szResult)
                    {
                       sz_Extra_Access = Int32.Parse(result.Field<string>(s03.Columns_C[s03.ACCESS_C]).ToString());
                       szS03_ID        = Int32.Parse(result.Field<string>(s03.Columns_C[s03.ID_C]).ToString());
                    }
                }
                if (szMenuLevel || szS03_ID == 0)
                    szDgv_ID = "T01_" + szT01_ID;
                else
                    szDgv_ID = "S03_" + szS03_ID;

                //Get S01
                DataTable szTempData     = s01.Get_By_ID(szT01_S01_ID);
                string szScreenName      = szTempData.Rows[0][s01.ScreenName_C].ToString();
                string szTransactionName = szTempData.Rows[0][s01.Transaction_C].ToString();
                int    szS01_ID          = Convert.ToInt32(szTempData.Rows[0][s01.ID_C]);


                //insert into dgv_Main
                if (szPrevScreenName == string.Empty)
                {
                    szPrevScreenName = szScreenName;
                    szDataNo++;
                    dgv_Main.Rows.Insert(ix, ""/*ID for screen*/, szDataNo, szScreenName, "", 0, 0, "");
                }

                if (szPrevScreenName != szScreenName || ix == szRowCount - 1)
                {
                    if (szScreenTrans_P_Checked == 0)
                        dgv_Screen_CheckState(szScreenRowIndex, 0, true);
                    else if (szScreenTrans_P_Checked == szScreenCount)
                        dgv_Screen_CheckState(szScreenRowIndex, 1, true);
                    else
                        dgv_Screen_CheckState(szScreenRowIndex, 2, true);

                    if (szScreenTrans_C_Checked == 0)
                        dgv_Screen_CheckState(szScreenRowIndex, 0, false);
                    else if (szScreenTrans_C_Checked == szScreenCount)
                        dgv_Screen_CheckState(szScreenRowIndex, 1, false);
                    else
                        dgv_Screen_CheckState(szScreenRowIndex, 2, false);
                }
                
                if (szPrevScreenName != szScreenName)
                {
                    szScreenRowIndex = ix + szDataNo;
                    dgv_Main.Rows.Insert(szScreenRowIndex, ""/*ID for screen*/, szDataNo + 1, szScreenName, "", 0, 0, "");
                    szPrevScreenName = szScreenName;
                    szDataNo++;
                    szScreenTrans_P_Checked = 0;
                    szScreenTrans_C_Checked = 0;
                }
                dgv_Main.Rows.Insert(ix + szDataNo, szDgv_ID, "", "", szTransactionName, szT01_Access, sz_Extra_Access, "");
                szScreenCount++;
                szScreenTrans_P_Checked = szScreenTrans_P_Checked + szT01_Access;
                szScreenTrans_C_Checked = szScreenTrans_C_Checked + sz_Extra_Access;
            }
            EnableButtons();
            Initialize_queryTable();
            return;
            Exit:
                shr.ErrorMessage("SM_Enquire()", shr.errMsg);
        }

        private void dgv_Main_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            DataGridViewCellStyle style =
               dgv_Main.ColumnHeadersDefaultCellStyle;
            style.Font = new Font(dgv_Main.Font, FontStyle.Bold);
            dgv_Main.RowHeadersVisible = false;
            dgv_Main.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv_Main.MultiSelect = false;

           //foreach(DataGridViewRow row in dgv_Main.Rows)
           // if (Convert.ToInt32(row.Cells[dgc_ExtraScreen].Value) != Convert.ToInt32(row.Cells[dgc_ParentAccess].Value))
           // {
           //     if (Convert.ToInt32(row.Cells[dgc_ExtraScreen].Value) == 0)
           //     {
           //         row.DefaultCellStyle.BackColor = Color.Red;
           //         row.DefaultCellStyle.ForeColor = Color.White;
           //     }
           //     else if (Convert.ToInt32(row.Cells[dgc_ExtraScreen].Value) == 2)
           //         row.DefaultCellStyle.BackColor = Color.LightGreen;
           //     else
           //         row.DefaultCellStyle.BackColor = Color.Green;
           // }
              

            //foreach (DataGridViewRow row in dgv_Main.Rows)
               
        }

        private void dgv_Main_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dgv_SelectedRowIndex = dgv_Main.SelectedCells[0].RowIndex;
        }

        private void dgv_Screen_CheckState(int rowIndex, int checkState, bool parent)
        {
            DataGridViewRow dgv_Rows = dgv_Main.Rows[rowIndex];
            if (parent)
                dgv_Rows.Cells[dgc_ParentAccess].Value = checkState;
            else
                dgv_Rows.Cells[dgc_ExtraScreen].Value = checkState;

        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            /*
             * Check first if there's an *.
             * If yes, remove the query statement
             * If not, 
             * Check if Child Access is 0, if not, do nothing.
             * If Menu Level, Add to T01, else, add to S03
             * create an insert or update query statement.
             * store it in an array.
             * Move an asterisk (*) to row. This will serve as an indicator that this row has been added.
             */
            c_Shared shr = new c_Shared();

            if (dgv_Main.SelectedCells.Count == 0)
                return;

            if (dgv_SelectedRowIndex == dgv_Main.Rows.Count - 1)
                return;

            int             row_idx        = dgv_SelectedRowIndex;
            DataGridViewRow dgv_Rows       = dgv_Main.Rows[row_idx];
            string          szTable_ID     = dgv_Rows.Cells[dgc_ID].Value.ToString();
            string          szScreen       = dgv_Rows.Cells[dgc_Screen].Value.ToString();
            string          szTransaction  = dgv_Rows.Cells[dgc_TransName].Value.ToString();
            int             szParent       = Convert.ToInt32(dgv_Rows.Cells[dgc_ParentAccess].Value);
            int             szExtraAccess  = Convert.ToInt32(dgv_Rows.Cells[dgc_ExtraScreen].Value);
            string          szIndicator    = dgv_Rows.Cells[dgc_Indicator].Value.ToString();
            bool            szAdd_Screen   = false;

            if (szExtraAccess == 1)
                return;

            if (szIndicator != string.Empty)
                goto UndoOnly;

            if (szTable_ID == string.Empty)
                szAdd_Screen = true;

            if (szMenuLevel)
                goto AddMenuLevel;

            //Insert/Update Values to S03
            string szTable = szTable_ID.Substring(0, 4);
            int    szID    = Convert.ToInt32(szTable_ID.Substring(4, szTable_ID.Length - 4));

            if (szAdd_Screen)
            {

                goto FinalStep;
            }


            if(szTable != "S03_"){
                //Insert Values
                if (szA02_ID == 0)
                {
                    shr.errMsg = "btn_Add_Click: Cannot insert value if A02_ID is zero.";
                    goto Exit;
                }
                DataTable szTempData = s01.Get_By_ID(szID);
                int szVal_A02_ID = szA02_ID;
                int szVal_S01_ID = Convert.ToInt32(szTempData.Rows[0][s01.ID_C]);

                string col_Values = szVal_A02_ID + "," +
                                    /*S03_S02_ID = null */ "," +
                                    szVal_S01_ID + "," +
                                     1;
                queryTable.Rows.Add(row_idx, szTransaction + "_++", col_Values);
                goto FinalStep;

            } else {
                //Update Access
                string col_Values = szID + "," +
                                    s03.Columns_C[s03.ACCESS_C] + "," +
                                     1;
                queryTable.Rows.Add(row_idx, szTransaction + "_-+", col_Values);
                goto FinalStep;
            }

            
         AddMenuLevel: //Insert/Update Values to T01
            if (szAdd_Screen)
            {
                //Insert/Update all that has screen szScreen
            }
             



           



           

            






        

         UndoOnly:
            //Undo subtract and remove query statement in array.
            return;

         FinalStep:
             dgv_Rows.Cells[dgc_Indicator].Value = "*";
             dgv_Rows.Cells[dgc_ExtraScreen].Value = 1;

            return;

         Exit:
            shr.ErrorMessage("SM_Enquire()", shr.errMsg);

        }

        private void btn_Remove_Click(object sender, EventArgs e)
        {
            /*
             Check first if there's an asterisk (*) in the row. 
             * If there is, remove the query statement in the array.
             * If no, 
             * Check if Child Access is 1. if not, do nothing.
             * create an insert or update query statement
             * store it in an array.
             * Move an asterisk.(*)
             */
        }





       

     

      

        

    }
}
