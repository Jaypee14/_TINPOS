namespace TINPOS_Project.Window_Forms.Admin
{
    partial class SM_SecurityMaintenance
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btn_Enquire = new System.Windows.Forms.Button();
            this.dgv_Main = new System.Windows.Forms.DataGridView();
            this.grb_Bottom = new System.Windows.Forms.GroupBox();
            this.btn_Back = new System.Windows.Forms.Button();
            this.btn_AddMenuLevel = new System.Windows.Forms.Button();
            this.btn_Add = new System.Windows.Forms.Button();
            this.btn_Update = new System.Windows.Forms.Button();
            this.btn_Subtract = new System.Windows.Forms.Button();
            this.grb_TopRight = new System.Windows.Forms.GroupBox();
            this.btn_UpdateLink = new System.Windows.Forms.Button();
            this.cmb_Child = new System.Windows.Forms.ComboBox();
            this.lbl_Child = new System.Windows.Forms.Label();
            this.cmb_Parent = new System.Windows.Forms.ComboBox();
            this.lbl_Parent = new System.Windows.Forms.Label();
            this.cmb_ID = new System.Windows.Forms.ComboBox();
            this.lbl_ID = new System.Windows.Forms.Label();
            this.txt_Name = new System.Windows.Forms.TextBox();
            this.btn_SearchID = new System.Windows.Forms.Button();
            this.grb_TopLeft = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.col_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_No = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_Screen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_TransactionName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_ParentAccess = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.col_ExtraScreen = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.col_Edited = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Main)).BeginInit();
            this.grb_Bottom.SuspendLayout();
            this.grb_TopRight.SuspendLayout();
            this.grb_TopLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_Enquire
            // 
            this.btn_Enquire.Location = new System.Drawing.Point(6, 19);
            this.btn_Enquire.Name = "btn_Enquire";
            this.btn_Enquire.Size = new System.Drawing.Size(84, 24);
            this.btn_Enquire.TabIndex = 1;
            this.btn_Enquire.Text = "Enquire";
            this.btn_Enquire.UseVisualStyleBackColor = true;
            this.btn_Enquire.Click += new System.EventHandler(this.btn_Enquire_Click);
            // 
            // dgv_Main
            // 
            this.dgv_Main.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv_Main.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Main.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_ID,
            this.col_No,
            this.col_Screen,
            this.col_TransactionName,
            this.col_ParentAccess,
            this.col_ExtraScreen,
            this.col_Edited});
            this.dgv_Main.Location = new System.Drawing.Point(18, 115);
            this.dgv_Main.MultiSelect = false;
            this.dgv_Main.Name = "dgv_Main";
            this.dgv_Main.ReadOnly = true;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_Main.RowHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgv_Main.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.dgv_Main.Size = new System.Drawing.Size(757, 425);
            this.dgv_Main.TabIndex = 2;
            this.dgv_Main.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_Main_CellClick);
            this.dgv_Main.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgv_Main_CellPainting);
            // 
            // grb_Bottom
            // 
            this.grb_Bottom.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grb_Bottom.Controls.Add(this.btn_Back);
            this.grb_Bottom.Controls.Add(this.btn_AddMenuLevel);
            this.grb_Bottom.Controls.Add(this.btn_Add);
            this.grb_Bottom.Controls.Add(this.btn_Update);
            this.grb_Bottom.Controls.Add(this.btn_Enquire);
            this.grb_Bottom.Controls.Add(this.btn_Subtract);
            this.grb_Bottom.Location = new System.Drawing.Point(12, 546);
            this.grb_Bottom.Name = "grb_Bottom";
            this.grb_Bottom.Size = new System.Drawing.Size(757, 54);
            this.grb_Bottom.TabIndex = 3;
            this.grb_Bottom.TabStop = false;
            // 
            // btn_Back
            // 
            this.btn_Back.Location = new System.Drawing.Point(634, 19);
            this.btn_Back.Name = "btn_Back";
            this.btn_Back.Size = new System.Drawing.Size(84, 24);
            this.btn_Back.TabIndex = 6;
            this.btn_Back.Text = "Back";
            this.btn_Back.UseVisualStyleBackColor = true;
            this.btn_Back.Click += new System.EventHandler(this.btn_Back_Click);
            // 
            // btn_AddMenuLevel
            // 
            this.btn_AddMenuLevel.Location = new System.Drawing.Point(530, 19);
            this.btn_AddMenuLevel.Name = "btn_AddMenuLevel";
            this.btn_AddMenuLevel.Size = new System.Drawing.Size(98, 24);
            this.btn_AddMenuLevel.TabIndex = 4;
            this.btn_AddMenuLevel.Text = "Add Menu Level";
            this.btn_AddMenuLevel.UseVisualStyleBackColor = true;
            this.btn_AddMenuLevel.Visible = false;
            // 
            // btn_Add
            // 
            this.btn_Add.Location = new System.Drawing.Point(186, 19);
            this.btn_Add.Name = "btn_Add";
            this.btn_Add.Size = new System.Drawing.Size(84, 24);
            this.btn_Add.TabIndex = 3;
            this.btn_Add.Text = "Add";
            this.btn_Add.UseVisualStyleBackColor = true;
            this.btn_Add.Click += new System.EventHandler(this.btn_Add_Click);
            // 
            // btn_Update
            // 
            this.btn_Update.Location = new System.Drawing.Point(96, 19);
            this.btn_Update.Name = "btn_Update";
            this.btn_Update.Size = new System.Drawing.Size(84, 24);
            this.btn_Update.TabIndex = 2;
            this.btn_Update.Text = "Update";
            this.btn_Update.UseVisualStyleBackColor = true;
            this.btn_Update.Click += new System.EventHandler(this.btn_Update_Click);
            // 
            // btn_Subtract
            // 
            this.btn_Subtract.Location = new System.Drawing.Point(276, 19);
            this.btn_Subtract.Name = "btn_Subtract";
            this.btn_Subtract.Size = new System.Drawing.Size(84, 24);
            this.btn_Subtract.TabIndex = 5;
            this.btn_Subtract.Text = "Subtract";
            this.btn_Subtract.UseVisualStyleBackColor = true;
            this.btn_Subtract.Click += new System.EventHandler(this.btn_Subtract_Click);
            // 
            // grb_TopRight
            // 
            this.grb_TopRight.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grb_TopRight.Controls.Add(this.btn_UpdateLink);
            this.grb_TopRight.Controls.Add(this.cmb_Child);
            this.grb_TopRight.Controls.Add(this.lbl_Child);
            this.grb_TopRight.Controls.Add(this.cmb_Parent);
            this.grb_TopRight.Controls.Add(this.lbl_Parent);
            this.grb_TopRight.Location = new System.Drawing.Point(252, 12);
            this.grb_TopRight.Name = "grb_TopRight";
            this.grb_TopRight.Size = new System.Drawing.Size(517, 97);
            this.grb_TopRight.TabIndex = 4;
            this.grb_TopRight.TabStop = false;
            this.grb_TopRight.Text = "User Menu Link";
            // 
            // btn_UpdateLink
            // 
            this.btn_UpdateLink.Location = new System.Drawing.Point(416, 40);
            this.btn_UpdateLink.Name = "btn_UpdateLink";
            this.btn_UpdateLink.Size = new System.Drawing.Size(84, 21);
            this.btn_UpdateLink.TabIndex = 5;
            this.btn_UpdateLink.Text = "Update Link";
            this.btn_UpdateLink.UseVisualStyleBackColor = true;
            this.btn_UpdateLink.Click += new System.EventHandler(this.btn_UpdateLink_Click);
            // 
            // cmb_Child
            // 
            this.cmb_Child.FormattingEnabled = true;
            this.cmb_Child.Location = new System.Drawing.Point(262, 40);
            this.cmb_Child.Name = "cmb_Child";
            this.cmb_Child.Size = new System.Drawing.Size(148, 21);
            this.cmb_Child.TabIndex = 3;
            // 
            // lbl_Child
            // 
            this.lbl_Child.AutoSize = true;
            this.lbl_Child.Location = new System.Drawing.Point(223, 43);
            this.lbl_Child.Name = "lbl_Child";
            this.lbl_Child.Size = new System.Drawing.Size(33, 13);
            this.lbl_Child.TabIndex = 4;
            this.lbl_Child.Text = "Child:";
            // 
            // cmb_Parent
            // 
            this.cmb_Parent.FormattingEnabled = true;
            this.cmb_Parent.Location = new System.Drawing.Point(62, 40);
            this.cmb_Parent.Name = "cmb_Parent";
            this.cmb_Parent.Size = new System.Drawing.Size(148, 21);
            this.cmb_Parent.TabIndex = 1;
            // 
            // lbl_Parent
            // 
            this.lbl_Parent.AutoSize = true;
            this.lbl_Parent.Location = new System.Drawing.Point(19, 43);
            this.lbl_Parent.Name = "lbl_Parent";
            this.lbl_Parent.Size = new System.Drawing.Size(41, 13);
            this.lbl_Parent.TabIndex = 2;
            this.lbl_Parent.Text = "Parent:";
            // 
            // cmb_ID
            // 
            this.cmb_ID.FormattingEnabled = true;
            this.cmb_ID.Location = new System.Drawing.Point(45, 29);
            this.cmb_ID.Name = "cmb_ID";
            this.cmb_ID.Size = new System.Drawing.Size(158, 21);
            this.cmb_ID.TabIndex = 0;
            this.cmb_ID.Text = "MN1000";
            this.cmb_ID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmb_ID_KeyDown);
            // 
            // lbl_ID
            // 
            this.lbl_ID.AutoSize = true;
            this.lbl_ID.Location = new System.Drawing.Point(3, 29);
            this.lbl_ID.Name = "lbl_ID";
            this.lbl_ID.Size = new System.Drawing.Size(40, 26);
            this.lbl_ID.TabIndex = 0;
            this.lbl_ID.Text = "User/\r\n Menu:";
            // 
            // txt_Name
            // 
            this.txt_Name.Location = new System.Drawing.Point(45, 56);
            this.txt_Name.Name = "txt_Name";
            this.txt_Name.ReadOnly = true;
            this.txt_Name.Size = new System.Drawing.Size(182, 20);
            this.txt_Name.TabIndex = 0;
            // 
            // btn_SearchID
            // 
            this.btn_SearchID.Location = new System.Drawing.Point(204, 29);
            this.btn_SearchID.Name = "btn_SearchID";
            this.btn_SearchID.Size = new System.Drawing.Size(23, 21);
            this.btn_SearchID.TabIndex = 5;
            this.btn_SearchID.Text = "O";
            this.btn_SearchID.UseVisualStyleBackColor = true;
            // 
            // grb_TopLeft
            // 
            this.grb_TopLeft.Controls.Add(this.txt_Name);
            this.grb_TopLeft.Controls.Add(this.btn_SearchID);
            this.grb_TopLeft.Controls.Add(this.cmb_ID);
            this.grb_TopLeft.Controls.Add(this.lbl_ID);
            this.grb_TopLeft.Location = new System.Drawing.Point(12, 12);
            this.grb_TopLeft.Name = "grb_TopLeft";
            this.grb_TopLeft.Size = new System.Drawing.Size(234, 97);
            this.grb_TopLeft.TabIndex = 6;
            this.grb_TopLeft.TabStop = false;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(396, 366);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(373, 150);
            this.dataGridView1.TabIndex = 7;
            this.dataGridView1.Visible = false;
            // 
            // col_ID
            // 
            this.col_ID.HeaderText = "ID";
            this.col_ID.Name = "col_ID";
            this.col_ID.ReadOnly = true;
            this.col_ID.Visible = false;
            // 
            // col_No
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.col_No.DefaultCellStyle = dataGridViewCellStyle1;
            this.col_No.HeaderText = "No";
            this.col_No.Name = "col_No";
            this.col_No.ReadOnly = true;
            this.col_No.Width = 30;
            // 
            // col_Screen
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.col_Screen.DefaultCellStyle = dataGridViewCellStyle2;
            this.col_Screen.HeaderText = "Screen";
            this.col_Screen.Name = "col_Screen";
            this.col_Screen.ReadOnly = true;
            this.col_Screen.Width = 50;
            // 
            // col_TransactionName
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.col_TransactionName.DefaultCellStyle = dataGridViewCellStyle3;
            this.col_TransactionName.HeaderText = "Transaction Name";
            this.col_TransactionName.Name = "col_TransactionName";
            this.col_TransactionName.ReadOnly = true;
            this.col_TransactionName.Width = 300;
            // 
            // col_ParentAccess
            // 
            this.col_ParentAccess.HeaderText = " Parent Access";
            this.col_ParentAccess.IndeterminateValue = "-1";
            this.col_ParentAccess.Name = "col_ParentAccess";
            this.col_ParentAccess.ReadOnly = true;
            this.col_ParentAccess.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.col_ParentAccess.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.col_ParentAccess.ThreeState = true;
            this.col_ParentAccess.Width = 60;
            // 
            // col_ExtraScreen
            // 
            this.col_ExtraScreen.HeaderText = "Extra Access";
            this.col_ExtraScreen.IndeterminateValue = "-1";
            this.col_ExtraScreen.Name = "col_ExtraScreen";
            this.col_ExtraScreen.ReadOnly = true;
            this.col_ExtraScreen.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.col_ExtraScreen.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.col_ExtraScreen.ThreeState = true;
            this.col_ExtraScreen.Width = 60;
            // 
            // col_Edited
            // 
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.col_Edited.DefaultCellStyle = dataGridViewCellStyle4;
            this.col_Edited.HeaderText = "*";
            this.col_Edited.Name = "col_Edited";
            this.col_Edited.ReadOnly = true;
            this.col_Edited.Visible = false;
            this.col_Edited.Width = 20;
            // 
            // SM_SecurityMaintenance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(781, 612);
            this.Controls.Add(this.grb_TopLeft);
            this.Controls.Add(this.grb_TopRight);
            this.Controls.Add(this.grb_Bottom);
            this.Controls.Add(this.dgv_Main);
            this.Controls.Add(this.dataGridView1);
            this.Name = "SM_SecurityMaintenance";
            this.Text = "Security Maintenance";
            this.Load += new System.EventHandler(this.SM_SecurityMaintenance_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Main)).EndInit();
            this.grb_Bottom.ResumeLayout(false);
            this.grb_TopRight.ResumeLayout(false);
            this.grb_TopRight.PerformLayout();
            this.grb_TopLeft.ResumeLayout(false);
            this.grb_TopLeft.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_Enquire;
        private System.Windows.Forms.DataGridView dgv_Main;
        private System.Windows.Forms.GroupBox grb_Bottom;
        private System.Windows.Forms.Button btn_Back;
        private System.Windows.Forms.Button btn_Subtract;
        private System.Windows.Forms.Button btn_AddMenuLevel;
        private System.Windows.Forms.Button btn_Add;
        private System.Windows.Forms.Button btn_Update;
        private System.Windows.Forms.GroupBox grb_TopRight;
        private System.Windows.Forms.Button btn_UpdateLink;
        private System.Windows.Forms.ComboBox cmb_Child;
        private System.Windows.Forms.Label lbl_Child;
        private System.Windows.Forms.ComboBox cmb_Parent;
        private System.Windows.Forms.Label lbl_Parent;
        private System.Windows.Forms.ComboBox cmb_ID;
        private System.Windows.Forms.Label lbl_ID;
        private System.Windows.Forms.TextBox txt_Name;
        private System.Windows.Forms.Button btn_SearchID;
        private System.Windows.Forms.GroupBox grb_TopLeft;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_No;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_Screen;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_TransactionName;
        private System.Windows.Forms.DataGridViewCheckBoxColumn col_ParentAccess;
        private System.Windows.Forms.DataGridViewCheckBoxColumn col_ExtraScreen;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_Edited;
    }
}