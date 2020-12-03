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

    public partial class SM_SecurityMaintenance : Form
    {
        #region Declarations
        //Classes
        A02 A02 = new A02();
        S00 S00 = new S00();
        S01 S01 = new S01();
        S02 S02 = new S02();
        S03 S03 = new S03();
        T01 T01 = new T01();
        Tinposparm param = new Tinposparm();
        Shared shr = new Shared();

        
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
        #endregion



        #region Form Functions
        
        public SM_SecurityMaintenance()
        {
            InitializeComponent();
            LoadDefaults();
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
        }

        private void dgv_Main_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dgv_SelectedRowIndex = dgv_Main.SelectedCells[0].RowIndex;
        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            dgvMain_Add_Subtract("Add");
        }

        private void btn_Subtract_Click(object sender, EventArgs e)
        {
            dgvMain_Add_Subtract("Subtract");
        }

        private void cmb_ID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter)
                return;
            btn_Enquire_Click(sender, e);
        }

        private void btn_Back_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_UpdateLink_Click(object sender, EventArgs e)
        {

            
            if (cmb_Parent.Text == string.Empty)
                return;
            if (cmb_Child.Text == string.Empty)
                return;

            string szUsrID = cmb_Child.Text.ToUpper();
            string szMenuLevel = cmb_Parent.Text.ToUpper();
            cmb_ID.Text = szUsrID;

            //search if userID Exists in A02.
            if(!A02.get_By_UserID(szUsrID)) //not found
            {
                shr.errMsg = A02.DbStatus;
                goto Exit;
            }
            szA02_ID = Convert.ToInt32(A02.ValueOf(a02.ID));

            //search if menu level exists in S02.
            if (!S02.GetAll()) //no S02 found
            {
                shr.errMsg = S02.DbStatus;
                goto Exit;
            }
            bool szFound = false;
            for (int ix = 0; ix < S02.DataResult.Rows.Count; ix++)
            {
                if (S02.ValueOf(s02.Group_Name, ix) == szMenuLevel)
                {
                    szS02_ID = Convert.ToInt32(S02.ValueOf(s02.ID, ix));
                    szFound = true;
                }
            }
            if (!szFound)
            {
                shr.errMsg = szMenuLevel + " not found.";
                goto Exit;
            }

            //search if userID exist in S03.
            S03.ColumnName = new string[] { s03.A02_ID };
            S03.Values = new string[]     { szA02_ID.ToString()};
            bool s03Found = S03.GetAll_By();
            if (!s03Found)
            {
                //Insert values to S03
                S03.ColumnName = new string[] 
                                   {    s03.A02_ID,
                                        s03.S02_ID,
                                   };
                S03.Values = new string[]
                                    {   szA02_ID.ToString(),
                                        szS02_ID.ToString(),
                                         /*""/*S03_S01_ID = null,*/
                                         /*""S03_ACCESS = null*/
                                    };
                S03.Insert();
                goto FinalStep;
            }
            //Update Menu Level in S03
            //int szS03_ID = Convert.ToInt32(s03.ValueOf(s03.ID));
            S03.ColumnName = new string[] { s03.S02_ID };
            S03.Values     = new string[] { szS02_ID.ToString() };
            string s03Condition = s03.ID + " = " + S03.ValueOf(s03.ID);
            S03.Update(s03Condition);

        FinalStep:
            btn_Enquire_Click(sender, e);
            return;
        Exit:
            shr.ErrorMessage("SM_Link()", shr.errMsg);
        }

        private void btn_Update_Click(object sender, EventArgs e)
        {
            //
            if (queryTable.Rows.Count == 0)
                return;
            dataGridView1.DataSource = queryTable;

            int dgvCount = dataGridView1.Rows.Count;
            int ix = 1;
            foreach (DataGridViewRow dgvRow in dataGridView1.Rows)
            {

                string colAction = dgvRow.Cells[1].Value.ToString();
                string colValues = dgvRow.Cells[2].Value.ToString();
                string[] values = colValues.Split(',');

                if (szMenuLevel)
                {
                    //Update T01
                   // int szT01_ID = Convert.ToInt32(values[0]);
                    string szT01_Access = values[1].ToString();
                    T01.ColumnName = new string[] { t01.ACCESS };
                    T01.Values     = new string[] { szT01_Access };
                    string t01Condition = t01.ID + " = " + values[0];
                    T01.Update(t01Condition);
                    goto Next;
                }

                if (colAction.Substring(0, 1) == "_")
                {
                    //update S03
                    //int szS03_ID = Convert.ToInt32(values[0]);
                    string szS03_Access = values[1];
                    S03.ColumnName = new string[] { s03.ACCESS };
                    S03.Values     = new string[] { szS03_Access };
                    string s03Condition = s03.ID + " = " + values[0];
                    S03.Update(s03Condition);
                }
                else
                {
                    //insert S03
                    S03.ColumnName = new string[] 
                                   { s03.A02_ID,
                                   /*  s03.S02_ID_C,*/
                                     s03.S01_ID,
                                     s03.ACCESS
                                   };
                    S03.Values = new string[] 
                                      { values[0], /*S03_A02_ID*/
                                       /* values[1], /*S03_S02_ID = blank*/  
                                        values[2], /*S03_S01_ID*/  
                                        values[3], /*S03_ACCESS*/
                                      };
                    S03.Insert();
                }
            Next:
                if (ix == dgvCount - 1)
                    goto FinalStep;
                ix++;
            }
        FinalStep:
            btn_Enquire_Click(sender, e);
            return;
        }

        private void btn_AddMenuLevel_Click(object sender, EventArgs e)
        {
            //Show this option for super Administrator only.
            ML_MenuLevel ML = new ML_MenuLevel();
            ML.ShowDialog();
            if (!ML.Saved)
                return;
            cmb_ID.Text = ML.MenuLevel;
            btn_Enquire_Click(sender, e);
        }

        #endregion



        #region Private Functions

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


            if (param.add_S02_MenuLevel) //Transaction
                btn_AddMenuLevel.Visible = true;
            else
                btn_AddMenuLevel.Visible = false;

            //how to initialize a class once and use the value in all class???????
            
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

            string szUsrID_Menu = cmb_ID.Text.ToUpper();
            int sz_Extra_Access;

            DataTable Extra_Access = new DataTable();
            string szDgv_ID = "";

            if (szUsrID_Menu == string.Empty)
                return;

            //Search For Menu Level in S02
            S02.GetAll(); 
            DataTable szS02Data = S02.DataResult;
            var szResult = from myResult in szS02Data.AsEnumerable()
                           where myResult.Field<string>(s02.Group_Name) == szUsrID_Menu
                           select myResult;
            foreach (var result in szResult)
            {
                szMenuLevel = true;
                szS02_ID = result.Field<int>(s02.ID);
                cmb_Child.Text = result.Field<string>(s02.Group_Name).ToString();
            }
            if (szMenuLevel)
                goto Display_DGV;

            //Search for userID in A02
            bool a02Found = A02.get_By_UserID(szUsrID_Menu);
            if (!a02Found)
            {
                shr.errMsg = "User ID/Menu Level not Found";
                goto Exit;
            }

            //Search for S03
            szA02_ID       = Convert.ToInt32(A02.ValueOf(a02.ID));
            cmb_Child.Text = A02.ValueOf(a02.UserID);
            txt_Name.Text  = shr.toTitleCase(A02.ValueOf(a02.FirstName) + " " +
                                             A02.ValueOf(a02.LastName));

            S03.ColumnName = new string[] { s03.A02_ID };
            S03.Values     = new string[] { szA02_ID.ToString() };
            bool s03Found = S03.GetAll_By();
            if (!s03Found)
            {
                shr.errMsg = "No Menu Level linked to userID " + szUsrID_Menu.ToUpper();
                goto Exit;
            }

            Extra_Access.Columns.Add(s03.S01_ID);
            Extra_Access.Columns.Add(s03.ACCESS);
            Extra_Access.Columns.Add(s03.ID);

            int szS03_Count = S03.DataResult.Rows.Count;
            for (int ix = 0; ix < szS03_Count; ix++)
            {
                //If S03_S02_ID is empty, get the S01 record and add value to sz_Extra_Access
                //else go to Display_DGV to display the Parent's Access
                if (szS02_ID == 0)
                {
                    int szS03_S02_ID = Int32.Parse(S03.ValueOf(s03.S02_ID, ix));
                    if (szS03_S02_ID != 0)
                    {
                        szS02_ID = szS03_S02_ID;
                        continue;
                    }
                }
                int szS03_S01_ID = Int32.Parse(S03.ValueOf(s03.S01_ID, ix));
                int szS03_ACCESS = Int32.Parse(S03.ValueOf(s03.ACCESS, ix));
                int szS03_ID = Int32.Parse(S03.ValueOf(s03.ID, ix));
                if (szS03_S01_ID != 0)
                {
                    Extra_Access.Rows.Add(szS03_S01_ID, szS03_ACCESS, szS03_ID);
                }
            }

            //Get S02
            S02.ColumnName = new string[] {s02.ID};
            S02.Values     = new string[] {szS02_ID.ToString()};
            bool s02Found = S02.GetAll_By();
            cmb_Parent.Text = S02.ValueOf(s02.Group_Name);
            

        Display_DGV: //Search for T01
            T01.ColumnName = new string[] {t01.S02_ID};
            T01.Values     = new string[] {szS02_ID.ToString() };
            bool t01Found = T01.GetAll_By();
            int szRowCount = T01.DataResult.Rows.Count;
            int szDataNo = 0;
            int szScreenRowIndex = 0;
            int szScreenCount = 0;
            int szScreenTrans_P_Checked = 0;
            int szScreenTrans_C_Checked = 0;
            string szPrevScreen = "";

            for (int ix = 0; ix < szRowCount; ix++)
            {

                int szT01_S01_ID = Int32.Parse(T01.ValueOf(t01.S01_ID, ix));
                int szT01_Access = Int32.Parse(T01.ValueOf(t01.ACCESS, ix));
                int szT01_ID = Int32.Parse(T01.ValueOf(t01.ID, ix));
                int szS03_ID = 0;

                sz_Extra_Access = szT01_Access;
                if (Extra_Access.Rows.Count != 0)
                {
                    szResult = from myResult in Extra_Access.AsEnumerable()
                               where myResult.Field<string>(s03.S01_ID) == szT01_S01_ID.ToString()
                               select myResult;
                    foreach (var result in szResult)
                    {
                        sz_Extra_Access = Int32.Parse(result.Field<string>(s03.ACCESS).ToString());
                        szS03_ID = Int32.Parse(result.Field<string>(s03.ID).ToString());
                    }
                }
                if (szMenuLevel)
                    szDgv_ID = "S02_" + szT01_ID;
                else if (szS03_ID == 0)
                    szDgv_ID = "S01_" + szT01_S01_ID;
                else
                    szDgv_ID = "S03_" + szS03_ID;

                //Get S01
                S01.ColumnName = new string[] { s01.ID };
                S01.Values     = new string[] { szT01_S01_ID.ToString() };
                S01.GetAll_By();
                int szS00_ID = Convert.ToInt32(S01.ValueOf(s01.S00_ID));
                //Get ScreenName
                S00.ColumnName = new string[] { s00.ID };
                S00.Values     = new string[] { szS00_ID.ToString() };
                S00.GetAll_By();
                string szScreen = S00.ValueOf(s00.Screen);
                string szScreenDesc = S00.ValueOf(s00.Description);
                string szTransactionName = S01.ValueOf(s01.Transaction);
                int szS01_ID = Convert.ToInt32(S01.ValueOf(s01.ID));


                //insert into dgv_Main
                if (szPrevScreen == string.Empty)
                {
                    szPrevScreen = szScreen;
                    szDataNo++;
                    dgv_Main.Rows.Insert(ix, "S00_" + szS00_ID, szDataNo, szScreen, szScreenDesc, 0, 0, "");
                }

                if (szPrevScreen != szScreen)
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

                if (ix == szRowCount - 1)
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
            }
            return;
        Exit:
            shr.ErrorMessage("SM_Enquire()", shr.errMsg);

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
            //c_Shared shr = new c_Shared();

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
            if (szTable == "S01_")
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
                S01.ColumnName = new string[] { s01.S00_ID };
                S01.Values     = new string[] { szID.ToString() };
                bool s01Found = S01.GetAll_By();
                DataTable szS01Data = S01.DataResult;
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

                    int szS01_ID = data.Field<int>(s01.ID);
                    int szS03_ID = 0;
                    bool hasS03S01 = false;
                    S03.ColumnName = new string[] { s03.A02_ID };
                    S03.Values     = new string[] { szA02_ID.ToString() };
                    bool s03Found = S03.GetAll_By();
                    DataTable szS03Data = S03.DataResult;
                    var s03result = from mys03result in szS03Data.AsEnumerable()
                                    select mys03result;
                    foreach (var s03data in s03result)
                    {
                        try
                        {
                            if (s03data.Field<int>(s03.S01_ID) == szS01_ID)
                            {
                                szS03_ID = s03data.Field<int>(s03.ID);
                                hasS03S01 = true;
                            }
                        }
                        catch {/* Do nothing */}
                    }

                    if (!hasS03S01)
                        queryTable.Rows.Add(row_idx + ix, szScreen + szaction, szA02_ID + "," + string.Empty + "," + szS01_ID + "," + szExt_access);
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
                S01.ColumnName = new string[] { s01.S00_ID };
                S01.Values     = new string[] { szID.ToString() };
                bool s01Found = S01.GetAll_By();
                DataTable szS01Data = S01.DataResult;
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
                    int szS01_ID = data.Field<int>(s01.ID);
                    T01.ColumnName = new string[] {t01.S01_ID};
                    T01.Values     = new string[] {szS01_ID.ToString()};
                    T01.GetAll_By();
                    DataTable szT01Data = T01.DataResult;
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

            return;

        Exit:
            shr.ErrorMessage("SM_Enquire()", shr.errMsg);

        }

        private string Insert_Values(int ID, int Access)
        {
            S01.ColumnName = new string[] { s01.ID };
            S01.Values = new string[] { ID.ToString() };
            S01.GetAll_By();
            int szVal_A02_ID = szA02_ID;
            int szVal_S01_ID = Convert.ToInt32(S01.ValueOf(s01.ID));

            string col_Values = szVal_A02_ID + "," +
                /*S03_S02_ID = null */ "," +
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
                         where myresult.Field<int>(t01.S02_ID) == szS02_ID
                         select myresult;
            foreach (var mydata in result)
            {
                int szT01_ID = mydata.Field<int>(t01.ID);
                return szT01_ID;
            }
            return 0;
        }

        #endregion

    }
}
