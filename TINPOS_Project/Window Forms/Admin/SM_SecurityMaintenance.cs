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
        S00 s00 = new S00();
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
        int             szS02_ID              = 0;
        //queryTable Rows
        /*RowIndex = 0
          Action = 1
          Value = 2
         */

        public SM_SecurityMaintenance()
        {
            InitializeComponent();
            a02.Initialization();
            s00.Initialization();
            s01.Initialization();
            s02.Initialization();
            s03.Initialization();
            t01.Initialization();

            LoadDefaults();
        }

        private void SM_SecurityMaintenance_Load(object sender, EventArgs e)
        {

         
        }

        private void LoadDefaults()
        {
            cmb_ID.Text = cmb_ID.Text.ToUpper();

            cmb_Parent.Text = string.Empty;
            cmb_Child.Text = string.Empty;
            txt_Name.Text = string.Empty;

            btn_Add.Enabled    = false;
            btn_Subtract.Enabled = false;
            btn_Update.Enabled = false;

            szA02_ID = 0;
            szS02_ID = 0;
            szMenuLevel = false;
            queryTable = new DataTable();
            Initialize_queryTable();
            dgv_SelectedRowIndex = 0;

            dgv_Main.Rows.Clear();
        }
        private void EnableButtons()
        {
            btn_Add.Enabled    = true;
            btn_Subtract.Enabled = true;
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

        private void Enquire()
        {
            //for Datagrid ID, if Menu Level, ID is from T01
            //if userID, ID is from S03.
            // ----------- if Transaction is not in S03 yet, ID is from T01.
            // ----------- if Transaction is in S03, ID is from S03.
            //Format of ID is Table_ID
            // -------example T01_1 or S03_1.

            c_Shared shr = new c_Shared();

            string szUsrID_Menu = cmb_ID.Text.ToUpper();
            int sz_Extra_Access;

            DataTable Extra_Access = new DataTable();
            string szDgv_ID = "";

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
            int[] col = {s03.A02_ID_C};
            int[] val = { szA02_ID };
            DataTable szS03Data = s03.get_All_By(col, val);
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
                int szS03_ID = Int32.Parse(szS03Data.Rows[ix][s03.Columns_C[s03.ID_C]].ToString());
                if (szS03_S01_ID != 0)
                {
                    Extra_Access.Rows.Add(szS03_S01_ID, szS03_ACCESS, szS03_ID);
                }
            }

            //Get S02
            int[] s02Col = {s02.ID_C};
            int[] s02Val = {szS02_ID};
            DataTable szTempS02 = s02.get_All_By(s02Col, s02Val);
            cmb_Parent.Text = szTempS02.Rows[0][s02.Columns_C[s02.Group_Name_C]].ToString();
            cmb_Child.Text = szA02Data.Rows[0][a02.Columns_C[a02.UserID_C]].ToString();
            txt_Name.Text = szA02Data.Rows[0][a02.Columns_C[a02.FirstName_C]].ToString() + " " +
                            szA02Data.Rows[0][a02.Columns_C[a02.LastName_C]].ToString();
            txt_Name.Text = shr.toTitleCase(txt_Name.Text);

        Display_DGV: //Search for T01
            DataTable szT01Data = new DataTable();
            int[] t01Col = {t01.S02_ID_C};
            int[] t01Val = {szS02_ID };
            szT01Data = t01.get_All_By(t01Col, t01Val);
            int szRowCount = szT01Data.Rows.Count;
            int szDataNo = 0;
            int szScreenRowIndex = 0;
            int szScreenCount = 0;
            int szScreenTrans_P_Checked = 0;
            int szScreenTrans_C_Checked = 0;
            string szPrevScreen = "";

            for (int ix = 0; ix < szRowCount; ix++)
            {

                int szT01_S01_ID = Int32.Parse(szT01Data.Rows[ix][t01.S01_ID_C].ToString());
                int szT01_Access = Int32.Parse(szT01Data.Rows[ix][t01.ACCESS_C].ToString());
                int szT01_ID = Int32.Parse(szT01Data.Rows[ix][t01.ID_C].ToString());
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
                        szS03_ID = Int32.Parse(result.Field<string>(s03.Columns_C[s03.ID_C]).ToString());
                    }
                }
                if (szMenuLevel)
                    szDgv_ID = "S02_" + szT01_ID;
                else if (szS03_ID == 0)
                    szDgv_ID = "T01_" + szT01_ID;
                else
                    szDgv_ID = "S03_" + szS03_ID;

                //Get S01
                int[] s01Col = { s01.ID_C };
                int[] s01Val = { szT01_S01_ID };
                DataTable szTempData = s01.get_All_By(s01Col, s01Val);
                int szS00_ID = Convert.ToInt32(szTempData.Rows[0][s01.S00_ID_C]);
                //Get ScreenName
                int[] s00Col = { s00.ID_C };
                int[] s00Val = { szS00_ID };
                DataTable szS00Data = s00.get_All_By(s00Col, s00Val);
                string szScreen = szS00Data.Rows[0][s00.Screen_C].ToString();
                string szScreenDesc = szS00Data.Rows[0][s00.Description_C].ToString();
                string szTransactionName = szTempData.Rows[0][s01.Transaction_C].ToString();
                int szS01_ID = Convert.ToInt32(szTempData.Rows[0][s01.ID_C]);


                //insert into dgv_Main
                if (szPrevScreen == string.Empty)
                {
                    szPrevScreen = szScreen;
                    szDataNo++;
                    dgv_Main.Rows.Insert(ix, "S00_" + szS00_ID, szDataNo, szScreen, szScreenDesc, 0, 0, "");
                }

                if (szPrevScreen != szScreen || ix == szRowCount - 1)
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

                if (szPrevScreen != szScreen)
                {
                    szScreenRowIndex = ix + szDataNo;
                    dgv_Main.Rows.Insert(szScreenRowIndex, "S00_" + szS00_ID, szDataNo + 1, szScreen, szScreenDesc, 0, 0, "");
                    szPrevScreen = szScreen;
                    szDataNo++;
                    szScreenTrans_P_Checked = 0;
                    szScreenTrans_C_Checked = 0;
                    szScreenCount = 0;
                }
                dgv_Main.Rows.Insert(ix + szDataNo, szDgv_ID, "", "", szTransactionName, szT01_Access, sz_Extra_Access, "");
                szScreenCount++;
                szScreenTrans_P_Checked = szScreenTrans_P_Checked + szT01_Access;
                szScreenTrans_C_Checked = szScreenTrans_C_Checked + sz_Extra_Access;
            }
           // tempjay
            dataGridView1.DataSource = queryTable;
            return;
        Exit:
            shr.ErrorMessage("SM_Enquire()", shr.errMsg);

        }
       
        private void btn_Enquire_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            LoadDefaults();
            Enquire();
            EnableButtons();
            Cursor.Current = Cursors.Default;
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

        private void dgvMain_Add_Subtract(string Function)
        {
            int szExt_access = 0;
            string szaction = "_--";
            bool szfunc_Add = false;
            if (Function == "Add")
            {
                szfunc_Add = true;
                szExt_access = 1;
                szaction = "_++";
            }

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

            int row_idx = dgv_SelectedRowIndex;
            DataGridViewRow dgv_Rows = dgv_Main.Rows[row_idx];
            string szTable_ID = dgv_Rows.Cells[dgc_ID].Value.ToString();
            string szScreen = dgv_Rows.Cells[dgc_Screen].Value.ToString();
            string szTransaction = dgv_Rows.Cells[dgc_TransName].Value.ToString();
            int szParent = Convert.ToInt32(dgv_Rows.Cells[dgc_ParentAccess].Value);
            int szExtraAccess = Convert.ToInt32(dgv_Rows.Cells[dgc_ExtraScreen].Value);
            string szIndicator = dgv_Rows.Cells[dgc_Indicator].Value.ToString();
            string szTable = szTable_ID.Substring(0, 4);
            int szID = Convert.ToInt32(szTable_ID.Substring(4, szTable_ID.Length - 4));

            if (szExtraAccess == szExt_access)
                return;

            if (szIndicator != string.Empty)
                goto UndoOnly;

            if (szTable_ID == string.Empty)
                return;

            if (szMenuLevel)
                goto AddMenuLevel;

            //Insert/Update Values to S03
            if (szA02_ID == 0)
            {
                shr.errMsg = "btn_Add_Click: Cannot insert value if A02_ID is zero.";
                goto Exit;
            }
            if (szTable == "T01_")
            {
                //Insert Values
                queryTable.Rows.Add(row_idx, szTransaction + szaction, Insert_Values(szID, szExt_access));
                goto FinalStep;

            }
            if (szTable == "S03_")
            {
                //Update Access
                queryTable.Rows.Add(row_idx, "_" + szTransaction + szaction, szID + "," + szExt_access);
                goto FinalStep;
            }
        CheckAllScreen:
            if (szTable == "S00_")
            {               
                int ix = 0;
                int[] s01Col = { s01.S00_ID_C };
                int[] s01Val = { szID };
                DataTable szS01Data = s01.get_All_By(s01Col, s01Val);
                var result = from myResult in szS01Data.AsEnumerable()
                             select myResult;
                foreach (var data in result)
                {
                    ix++;

                    if ((szfunc_Add && ChildAccess(row_idx + ix)) ||
                        (!szfunc_Add && !ChildAccess(row_idx + ix)))
                        continue;

                    if (HasRowIndicator(row_idx + ix))
                    {
                        delete_from_QueryTable(row_idx + ix);
                        goto EndCheckAllScreen;

                    }

                    int szS01_ID = data.Field<int>(s01.Columns_C[s01.ID_C]);
                    int szS03_ID = 0;
                    bool hasS03S01 = false;
                    int[] s03col = { s03.A02_ID_C };
                    int[] s03val = { szA02_ID };
                    DataTable szS03Data = s03.get_All_By(s03col, s03val);
                    var s03result = from mys03result in szS03Data.AsEnumerable()
                                    select mys03result;
                    foreach (var s03data in s03result)
                    {
                        try
                        {
                            if (s03data.Field<int>(s03.Columns_C[s03.S01_ID_C]) == szS01_ID)
                            {
                                szS03_ID = s03data.Field<int>(s03.Columns_C[s03.ID_C]);
                                hasS03S01 = true;
                            }
                        }
                        catch {/* Do nothing */}
                    }

                    if (!hasS03S01)
                        queryTable.Rows.Add(row_idx + ix, szScreen + szaction, szA02_ID + ", ," + szS01_ID + "," + szExt_access);
                    else
                        queryTable.Rows.Add(row_idx + ix, "_" + szScreen + szaction, szS03_ID + "," + szExt_access);

                EndCheckAllScreen:
                    setIndicator_Child(row_idx + ix, szExt_access);
                }
                goto FinalStep;
            }

        AddMenuLevel: //Update Values to T01 only
            if(szTable != "S00_"){
                queryTable.Rows.Add(row_idx, "_" + szTransaction + szaction, szID + "," + szExt_access);
                goto FinalStep;
            }

            if(szTable == "S00_")
            {
                //from s00, get S01
                //from s01, get T01 where S02_ID == szS02_ID
                int ix = 0;
                int[] s01Col = { s01.S00_ID_C };
                int[] s01Val = { szID };
                DataTable szS01Data = s01.get_All_By(s01Col, s01Val);
                var result = from myResult in szS01Data.AsEnumerable()
                              select myResult;
                foreach (var data in result)
                {
                    ix++;

                    if ((szfunc_Add && ChildAccess(row_idx + ix)) ||
                       (!szfunc_Add && !ChildAccess(row_idx + ix)))
                        continue;

                    if (HasRowIndicator(row_idx + ix))
                    {
                        delete_from_QueryTable(row_idx + ix);
                        goto EndCheckAllScreen;

                    }
                    int szS01_ID = data.Field<int>(s01.Columns_C[s01.ID_C]);
                    int[] t01Col = {t01.S01_ID_C};
                    int[] t01Val = {szS01_ID};
                    DataTable szT01Data = t01.get_All_By(t01Col, t01Val);
                    int szT01_ID = get_ID_from_T01(szT01Data);
                    if (szT01_ID == 0)
                    {
                        shr.errMsg = "Error in T01. T01_ID not found.";
                        goto Exit;
                    }
                    queryTable.Rows.Add(row_idx + ix, "_" + szScreen + szaction, szT01_ID + "," + szExt_access);

                EndCheckAllScreen:
                    setIndicator_Child(row_idx + ix, szExt_access);
                }
                goto FinalStep;
            }

        UndoOnly:
            if (szTable == "S00_")
            {
                goto CheckAllScreen;
            }
            delete_from_QueryTable(row_idx);

        FinalStep:
            if (szTable != "S00_")
                setIndicator_Child(row_idx, szExt_access);
            /*Check if all transaction's ExtraScreen under S00_ is checked.
              If all checked, set S00_ ExtraScreen to checked.
              If all unchecked, set S00_ ExtraScreen to unchecked.
              If not all are checked, set S00_ ExtraScreen to Intermediate.
            */
            int szS00_index = 0;
            for(int i = row_idx; i >= 0; i--)
            {
               // get the rowindex of S00_
                DataGridViewRow szRow = dgv_Main.Rows[i];
                if (szRow.Cells[dgc_ID].Value.ToString().Substring(0,4) == "S00_")
                {
                    szS00_index = i;
                    break;
                }
            }
            int szRowCount = 0;
            int szRowChecked = 0;
            for (int i = szS00_index + 1; i < dgv_Main.Rows.Count - 1; i++)
            {
                DataGridViewRow szRow = dgv_Main.Rows[i];
                if (szRow.Cells[dgc_ID].Value.ToString().Substring(0, 4) == "S00_")
                    break;
                int szChecked = Convert.ToInt32(szRow.Cells[dgc_ExtraScreen].Value);
                szRowChecked = szRowChecked + szChecked;
                szRowCount++;
            }
            DataGridViewRow szS00_row = dgv_Main.Rows[szS00_index];
            if (szRowChecked == 0)
                szS00_row.Cells[dgc_ExtraScreen].Value = 0;
            else if (szRowChecked == szRowCount)
                szS00_row.Cells[dgc_ExtraScreen].Value = 1;
            else
                szS00_row.Cells[dgc_ExtraScreen].Value = 2;

            szS00_row.Cells[dgc_Indicator].Value = "*";

                //tempjay

                dataGridView1.DataSource = queryTable;
            return;

        Exit:
            shr.ErrorMessage("SM_Enquire()", shr.errMsg);

        }



        private void btn_Add_Click(object sender, EventArgs e)
        {
            dgvMain_Add_Subtract("Add");

        }

        private string Insert_Values(int ID, int Access)
        {
            int[] s01Col = { s01.ID_C };
            int[] s01Val = { ID };
            DataTable szTempData = s01.get_All_By(s01Col, s01Val);
            int szVal_A02_ID = szA02_ID;
            int szVal_S01_ID = Convert.ToInt32(szTempData.Rows[0][s01.ID_C]);

            string col_Values = szVal_A02_ID + "," +
                /*S03_S02_ID = null */ " ," +
                                szVal_S01_ID + "," +
                                 Access;
            return col_Values;
        }

        private bool ParentAccess(int rowIndex)
        {
            DataGridViewRow dgv_Rows = dgv_Main.Rows[rowIndex];
            int Access = Convert.ToInt32(dgv_Rows.Cells[dgc_ParentAccess].Value);
            if (Access == 1)
                return true;
            else
                return false;
        }

        private bool ChildAccess(int rowIndex)
        {
            DataGridViewRow dgv_Rows = dgv_Main.Rows[rowIndex];
            int Access = Convert.ToInt32(dgv_Rows.Cells[dgc_ExtraScreen].Value);
            if (Access == 1)
                return true;
            else
                return false;
        }

        private void setIndicator_Child(int rowIndex, int extra_Screen_Access)
        {
            DataGridViewRow dgv_Rows = dgv_Main.Rows[rowIndex];
            string Indicator   = dgv_Rows.Cells[dgc_Indicator].Value.ToString();
            int    ExtraScreen = Convert.ToInt32(dgv_Rows.Cells[dgc_ExtraScreen].Value);
            if (Indicator == "*")
                dgv_Rows.Cells[dgc_Indicator].Value = "";
            else
                dgv_Rows.Cells[dgc_Indicator].Value = "*";

            if (ExtraScreen != extra_Screen_Access)
                dgv_Rows.Cells[dgc_ExtraScreen].Value = extra_Screen_Access;


        }

        private bool HasRowIndicator(int rowIndex)
        {
            DataGridViewRow dgv_Rows = dgv_Main.Rows[rowIndex];
            string Indicator = dgv_Rows.Cells[dgc_Indicator].Value.ToString();
            if (Indicator != "*")
                return false;
            else
                return true;
        }

        private void delete_from_QueryTable(int rowIndex)
        {
            for (int i = queryTable.Rows.Count - 1; i >= 0; i--)
            {
                DataRow row = queryTable.Rows[i];
                if (Convert.ToInt32(row["ROWINDEX"]) == rowIndex)
                    row.Delete();
            } 
        }

        private int get_ID_from_T01(DataTable data)
        {
            var result = from myresult in data.AsEnumerable()
                         where myresult.Field<int>(t01.Columns_C[t01.S02_ID_C]) == szS02_ID
                         select myresult;
            foreach (var mydata in result)
            {
                int szT01_ID = mydata.Field<int>(t01.Columns_C[t01.ID_C]);
                return szT01_ID;
            }
            return 0;
        }

        private void btn_Subtract_Click(object sender, EventArgs e)
        {
            dgvMain_Add_Subtract("Subtract");
        }

        private void cmb_ID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter)
                return;
            btn_Enquire_Click( sender, e);
        }

        private void btn_Back_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_UpdateLink_Click(object sender, EventArgs e)
        {
            
            c_Shared shr = new c_Shared();
            if (cmb_Parent.Text == string.Empty)
                return;
            if (cmb_Child.Text == string.Empty)
                return;

            string szUsrID = cmb_Child.Text.ToUpper();
            string szMenuLevel = cmb_Parent.Text.ToUpper();
            cmb_ID.Text = szUsrID;

            //search if userID Exists in A02.
            DataTable szA02Data = new DataTable();
            szA02Data = a02.get_By_UserID(szUsrID);
            if (szA02Data.Rows.Count == 0)
            {
                shr.errMsg = "User ID not Found";
                goto Exit;
            }
            szA02_ID = Int32.Parse(szA02Data.Rows[0][a02.Columns_C[a02.ID_C]].ToString());

            //search if menu level exists in S02.
            DataTable szS02Data = new DataTable();
            szS02Data = db.Get_All(s02.TableName);
            var szResult = from myResult in szS02Data.AsEnumerable()
                           where myResult.Field<string>(s02.Columns_C[s02.Group_Name_C].ToString()) == szMenuLevel
                           select myResult;
            foreach (var result in szResult)
            {
                szS02_ID = result.Field<int>(s02.Columns_C[s02.ID_C]);
            }

            //search if userID and Menu level exist in S03.
            int[] column = { s03.A02_ID_C,
                             s03.S02_ID_C };
            int[] values = { szA02_ID,
                             szS02_ID };
            DataTable szS03Data = s03.get_All_By(column, values);
            if (szS03Data.Rows.Count == 0)
            {
               //Insert values to S03

                string[] s03Values ={szA02_ID.ToString(),
                                     szS02_ID.ToString(),
                                     ""/*S03_S01_ID = null*/,
                                     ""};
                s03.AddValues(s03Values);
                btn_Enquire_Click(sender, e);
                return;
            }
               //Update Menu Level in S03



            return;
        Exit:
            shr.ErrorMessage("SM_Link()", shr.errMsg);

        }

        private void btn_Update_Click(object sender, EventArgs e)
        {
            //
            if (queryTable.Rows.Count == 0)
                return;
            
            DataGridView dgv = new DataGridView();
            dataGridView1.DataSource = queryTable;

            int dgvCount = dataGridView1.Rows.Count;
            int ix = 1;
            foreach( DataGridViewRow dgvRow in dataGridView1.Rows){

                string colAction = dgvRow.Cells[1].Value.ToString();
                string colValues = dgvRow.Cells[2].Value.ToString();
                string[] values = colValues.Split(',');

                if (szMenuLevel)
                {
                    //Update T01
                    int szT01_ID = Convert.ToInt32(values[0]);
                    string szT01_Access = values[1].ToString();
                    int[] t01Col = { t01.ACCESS_C };
                    string[] t01Val = { szT01_Access };
                    t01.update_By_ID(t01Col, t01Val, szT01_ID);
                    goto Next;
                }
               
                if (colAction.Substring(0, 1) == "_")
                {
                    //update S03
                    int      szS03_ID     = Convert.ToInt32(values[0]);
                    string   szS03_Access = values[1];
                    int[]    s03Col       = {s03.ACCESS_C};
                    string[] s03Val       = {szS03_Access};
                    s03.update_By_ID(s03Col, s03Val, szS03_ID);
                } 
                else
                {
                    //insert S03
                    string[] s03Val = { values[0], /*S03_A02_ID*/
                                        values[1], /*S03_S02_ID = blank*/  
                                        values[2], /*S03_S01_ID*/  
                                        values[3], /*S03_ACCESS*/
                                      };
                    s03.AddValues(s03Val);

                }

            Next:
                if (ix == dgvCount - 1)
                    goto FinalStep;
                ix++;
            }
            FinalStep:
            btn_Enquire_Click(sender,e);
            return;

        }

       





       

     

      

        

    }
}
