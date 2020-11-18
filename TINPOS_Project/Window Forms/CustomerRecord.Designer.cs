namespace TINPOS_Project.Window_Forms
{
    partial class CustomerRecord
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
            this.tbc_Main = new System.Windows.Forms.TabControl();
            this.tbp_Info = new System.Windows.Forms.TabPage();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.grb_Info_Contact = new System.Windows.Forms.GroupBox();
            this.txb_Email = new System.Windows.Forms.TextBox();
            this.lbl_Email = new System.Windows.Forms.Label();
            this.txb_Fax = new System.Windows.Forms.TextBox();
            this.lbl_Fax = new System.Windows.Forms.Label();
            this.txb_Cellular = new System.Windows.Forms.TextBox();
            this.lbl_Cellular = new System.Windows.Forms.Label();
            this.txb_Phone2 = new System.Windows.Forms.TextBox();
            this.lbl_Phone2 = new System.Windows.Forms.Label();
            this.txb_Phone1 = new System.Windows.Forms.TextBox();
            this.lbl_Phone1 = new System.Windows.Forms.Label();
            this.grb_Info_Address = new System.Windows.Forms.GroupBox();
            this.txb_Country = new System.Windows.Forms.TextBox();
            this.lbl_Country = new System.Windows.Forms.Label();
            this.txb_PostalCode = new System.Windows.Forms.TextBox();
            this.lbl_PostalCode = new System.Windows.Forms.Label();
            this.txb_ProvState = new System.Windows.Forms.TextBox();
            this.lbl_ProvState = new System.Windows.Forms.Label();
            this.txb_City = new System.Windows.Forms.TextBox();
            this.lbl_City = new System.Windows.Forms.Label();
            this.txb_Address2 = new System.Windows.Forms.TextBox();
            this.lbl_Address2 = new System.Windows.Forms.Label();
            this.txb_Address1 = new System.Windows.Forms.TextBox();
            this.lbl_Address1 = new System.Windows.Forms.Label();
            this.grb_Info_Others = new System.Windows.Forms.GroupBox();
            this.lbl_AlertMessage = new System.Windows.Forms.Label();
            this.txb_AlertMessage = new System.Windows.Forms.TextBox();
            this.lbl_Remarks = new System.Windows.Forms.Label();
            this.txb_Remarks = new System.Windows.Forms.TextBox();
            this.grb_Info_Basic = new System.Windows.Forms.GroupBox();
            this.btn_StoreLookup = new System.Windows.Forms.Button();
            this.txb_Store = new System.Windows.Forms.TextBox();
            this.lbl_Store = new System.Windows.Forms.Label();
            this.lbl_CustomerGroup = new System.Windows.Forms.Label();
            this.cmb_CustomerGroup = new System.Windows.Forms.ComboBox();
            this.txb_CompanyName = new System.Windows.Forms.TextBox();
            this.lbl_CompanyName = new System.Windows.Forms.Label();
            this.txb_LastName = new System.Windows.Forms.TextBox();
            this.lbl_LastName = new System.Windows.Forms.Label();
            this.txb_FirstName = new System.Windows.Forms.TextBox();
            this.lbl_FirstName = new System.Windows.Forms.Label();
            this.cmb_Salutation = new System.Windows.Forms.ComboBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.grb_TopControl = new System.Windows.Forms.GroupBox();
            this.chb_Deactivate = new System.Windows.Forms.CheckBox();
            this.txb_CustomerDesc = new System.Windows.Forms.TextBox();
            this.btn_Refresh = new System.Windows.Forms.Button();
            this.btn_NextCustomer = new System.Windows.Forms.Button();
            this.lbl_CustomerNo = new System.Windows.Forms.Label();
            this.txb_CustomerNo = new System.Windows.Forms.TextBox();
            this.grb_BottomControl = new System.Windows.Forms.GroupBox();
            this.btn_Remind = new System.Windows.Forms.Button();
            this.btn_Groupings = new System.Windows.Forms.Button();
            this.btn_Close = new System.Windows.Forms.Button();
            this.btn_Reports = new System.Windows.Forms.Button();
            this.btn_Delete = new System.Windows.Forms.Button();
            this.btn_New = new System.Windows.Forms.Button();
            this.btn_Lookup = new System.Windows.Forms.Button();
            this.btn_Save = new System.Windows.Forms.Button();
            this.tbc_Main.SuspendLayout();
            this.tbp_Info.SuspendLayout();
            this.grb_Info_Contact.SuspendLayout();
            this.grb_Info_Address.SuspendLayout();
            this.grb_Info_Others.SuspendLayout();
            this.grb_Info_Basic.SuspendLayout();
            this.grb_TopControl.SuspendLayout();
            this.grb_BottomControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbc_Main
            // 
            this.tbc_Main.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbc_Main.Controls.Add(this.tbp_Info);
            this.tbc_Main.Controls.Add(this.tabPage2);
            this.tbc_Main.Location = new System.Drawing.Point(12, 150);
            this.tbc_Main.Name = "tbc_Main";
            this.tbc_Main.SelectedIndex = 0;
            this.tbc_Main.Size = new System.Drawing.Size(971, 358);
            this.tbc_Main.TabIndex = 0;
            // 
            // tbp_Info
            // 
            this.tbp_Info.Controls.Add(this.groupBox7);
            this.tbp_Info.Controls.Add(this.grb_Info_Contact);
            this.tbp_Info.Controls.Add(this.grb_Info_Address);
            this.tbp_Info.Controls.Add(this.grb_Info_Others);
            this.tbp_Info.Controls.Add(this.grb_Info_Basic);
            this.tbp_Info.Location = new System.Drawing.Point(4, 22);
            this.tbp_Info.Name = "tbp_Info";
            this.tbp_Info.Padding = new System.Windows.Forms.Padding(3);
            this.tbp_Info.Size = new System.Drawing.Size(963, 332);
            this.tbp_Info.TabIndex = 0;
            this.tbp_Info.Text = "Info";
            this.tbp_Info.UseVisualStyleBackColor = true;
            // 
            // groupBox7
            // 
            this.groupBox7.Location = new System.Drawing.Point(679, 0);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(182, 251);
            this.groupBox7.TabIndex = 17;
            this.groupBox7.TabStop = false;
            // 
            // grb_Info_Contact
            // 
            this.grb_Info_Contact.Controls.Add(this.txb_Email);
            this.grb_Info_Contact.Controls.Add(this.lbl_Email);
            this.grb_Info_Contact.Controls.Add(this.txb_Fax);
            this.grb_Info_Contact.Controls.Add(this.lbl_Fax);
            this.grb_Info_Contact.Controls.Add(this.txb_Cellular);
            this.grb_Info_Contact.Controls.Add(this.lbl_Cellular);
            this.grb_Info_Contact.Controls.Add(this.txb_Phone2);
            this.grb_Info_Contact.Controls.Add(this.lbl_Phone2);
            this.grb_Info_Contact.Controls.Add(this.txb_Phone1);
            this.grb_Info_Contact.Controls.Add(this.lbl_Phone1);
            this.grb_Info_Contact.Location = new System.Drawing.Point(345, 106);
            this.grb_Info_Contact.Name = "grb_Info_Contact";
            this.grb_Info_Contact.Size = new System.Drawing.Size(328, 145);
            this.grb_Info_Contact.TabIndex = 15;
            this.grb_Info_Contact.TabStop = false;
            // 
            // txb_Email
            // 
            this.txb_Email.Location = new System.Drawing.Point(90, 114);
            this.txb_Email.Name = "txb_Email";
            this.txb_Email.Size = new System.Drawing.Size(214, 20);
            this.txb_Email.TabIndex = 18;
            // 
            // lbl_Email
            // 
            this.lbl_Email.AutoSize = true;
            this.lbl_Email.Location = new System.Drawing.Point(52, 117);
            this.lbl_Email.Name = "lbl_Email";
            this.lbl_Email.Size = new System.Drawing.Size(35, 13);
            this.lbl_Email.TabIndex = 17;
            this.lbl_Email.Text = "Email:";
            // 
            // txb_Fax
            // 
            this.txb_Fax.Location = new System.Drawing.Point(90, 91);
            this.txb_Fax.Name = "txb_Fax";
            this.txb_Fax.Size = new System.Drawing.Size(214, 20);
            this.txb_Fax.TabIndex = 16;
            // 
            // lbl_Fax
            // 
            this.lbl_Fax.AutoSize = true;
            this.lbl_Fax.Location = new System.Drawing.Point(57, 94);
            this.lbl_Fax.Name = "lbl_Fax";
            this.lbl_Fax.Size = new System.Drawing.Size(27, 13);
            this.lbl_Fax.TabIndex = 15;
            this.lbl_Fax.Text = "Fax:";
            // 
            // txb_Cellular
            // 
            this.txb_Cellular.Location = new System.Drawing.Point(90, 67);
            this.txb_Cellular.Name = "txb_Cellular";
            this.txb_Cellular.Size = new System.Drawing.Size(214, 20);
            this.txb_Cellular.TabIndex = 14;
            // 
            // lbl_Cellular
            // 
            this.lbl_Cellular.AutoSize = true;
            this.lbl_Cellular.Location = new System.Drawing.Point(40, 70);
            this.lbl_Cellular.Name = "lbl_Cellular";
            this.lbl_Cellular.Size = new System.Drawing.Size(44, 13);
            this.lbl_Cellular.TabIndex = 13;
            this.lbl_Cellular.Text = "Cellular:";
            // 
            // txb_Phone2
            // 
            this.txb_Phone2.Location = new System.Drawing.Point(90, 43);
            this.txb_Phone2.Name = "txb_Phone2";
            this.txb_Phone2.Size = new System.Drawing.Size(214, 20);
            this.txb_Phone2.TabIndex = 12;
            // 
            // lbl_Phone2
            // 
            this.lbl_Phone2.AutoSize = true;
            this.lbl_Phone2.Location = new System.Drawing.Point(35, 46);
            this.lbl_Phone2.Name = "lbl_Phone2";
            this.lbl_Phone2.Size = new System.Drawing.Size(50, 13);
            this.lbl_Phone2.TabIndex = 11;
            this.lbl_Phone2.Text = "Phone 2:";
            // 
            // txb_Phone1
            // 
            this.txb_Phone1.Location = new System.Drawing.Point(90, 19);
            this.txb_Phone1.Name = "txb_Phone1";
            this.txb_Phone1.Size = new System.Drawing.Size(213, 20);
            this.txb_Phone1.TabIndex = 10;
            // 
            // lbl_Phone1
            // 
            this.lbl_Phone1.AutoSize = true;
            this.lbl_Phone1.Location = new System.Drawing.Point(35, 22);
            this.lbl_Phone1.Name = "lbl_Phone1";
            this.lbl_Phone1.Size = new System.Drawing.Size(50, 13);
            this.lbl_Phone1.TabIndex = 9;
            this.lbl_Phone1.Text = "Phone 1:";
            // 
            // grb_Info_Address
            // 
            this.grb_Info_Address.Controls.Add(this.txb_Country);
            this.grb_Info_Address.Controls.Add(this.lbl_Country);
            this.grb_Info_Address.Controls.Add(this.txb_PostalCode);
            this.grb_Info_Address.Controls.Add(this.lbl_PostalCode);
            this.grb_Info_Address.Controls.Add(this.txb_ProvState);
            this.grb_Info_Address.Controls.Add(this.lbl_ProvState);
            this.grb_Info_Address.Controls.Add(this.txb_City);
            this.grb_Info_Address.Controls.Add(this.lbl_City);
            this.grb_Info_Address.Controls.Add(this.txb_Address2);
            this.grb_Info_Address.Controls.Add(this.lbl_Address2);
            this.grb_Info_Address.Controls.Add(this.txb_Address1);
            this.grb_Info_Address.Controls.Add(this.lbl_Address1);
            this.grb_Info_Address.Location = new System.Drawing.Point(6, 106);
            this.grb_Info_Address.Name = "grb_Info_Address";
            this.grb_Info_Address.Size = new System.Drawing.Size(328, 145);
            this.grb_Info_Address.TabIndex = 14;
            this.grb_Info_Address.TabStop = false;
            this.grb_Info_Address.Text = "Address";
            // 
            // txb_Country
            // 
            this.txb_Country.Location = new System.Drawing.Point(71, 114);
            this.txb_Country.Name = "txb_Country";
            this.txb_Country.Size = new System.Drawing.Size(214, 20);
            this.txb_Country.TabIndex = 16;
            // 
            // lbl_Country
            // 
            this.lbl_Country.AutoSize = true;
            this.lbl_Country.Location = new System.Drawing.Point(20, 117);
            this.lbl_Country.Name = "lbl_Country";
            this.lbl_Country.Size = new System.Drawing.Size(46, 13);
            this.lbl_Country.TabIndex = 15;
            this.lbl_Country.Text = "Country:";
            // 
            // txb_PostalCode
            // 
            this.txb_PostalCode.Location = new System.Drawing.Point(226, 91);
            this.txb_PostalCode.Name = "txb_PostalCode";
            this.txb_PostalCode.Size = new System.Drawing.Size(59, 20);
            this.txb_PostalCode.TabIndex = 14;
            // 
            // lbl_PostalCode
            // 
            this.lbl_PostalCode.AutoSize = true;
            this.lbl_PostalCode.Location = new System.Drawing.Point(131, 94);
            this.lbl_PostalCode.Name = "lbl_PostalCode";
            this.lbl_PostalCode.Size = new System.Drawing.Size(89, 13);
            this.lbl_PostalCode.TabIndex = 13;
            this.lbl_PostalCode.Text = "Postal Code/ZIP:";
            // 
            // txb_ProvState
            // 
            this.txb_ProvState.Location = new System.Drawing.Point(71, 91);
            this.txb_ProvState.Name = "txb_ProvState";
            this.txb_ProvState.Size = new System.Drawing.Size(54, 20);
            this.txb_ProvState.TabIndex = 12;
            // 
            // lbl_ProvState
            // 
            this.lbl_ProvState.AutoSize = true;
            this.lbl_ProvState.Location = new System.Drawing.Point(3, 94);
            this.lbl_ProvState.Name = "lbl_ProvState";
            this.lbl_ProvState.Size = new System.Drawing.Size(62, 13);
            this.lbl_ProvState.TabIndex = 11;
            this.lbl_ProvState.Text = "Prov/State:";
            // 
            // txb_City
            // 
            this.txb_City.Location = new System.Drawing.Point(71, 67);
            this.txb_City.Name = "txb_City";
            this.txb_City.Size = new System.Drawing.Size(214, 20);
            this.txb_City.TabIndex = 10;
            // 
            // lbl_City
            // 
            this.lbl_City.AutoSize = true;
            this.lbl_City.Location = new System.Drawing.Point(38, 70);
            this.lbl_City.Name = "lbl_City";
            this.lbl_City.Size = new System.Drawing.Size(27, 13);
            this.lbl_City.TabIndex = 9;
            this.lbl_City.Text = "City:";
            // 
            // txb_Address2
            // 
            this.txb_Address2.Location = new System.Drawing.Point(71, 43);
            this.txb_Address2.Name = "txb_Address2";
            this.txb_Address2.Size = new System.Drawing.Size(214, 20);
            this.txb_Address2.TabIndex = 8;
            // 
            // lbl_Address2
            // 
            this.lbl_Address2.AutoSize = true;
            this.lbl_Address2.Location = new System.Drawing.Point(27, 46);
            this.lbl_Address2.Name = "lbl_Address2";
            this.lbl_Address2.Size = new System.Drawing.Size(39, 13);
            this.lbl_Address2.TabIndex = 7;
            this.lbl_Address2.Text = "Line 2:";
            // 
            // txb_Address1
            // 
            this.txb_Address1.Location = new System.Drawing.Point(71, 19);
            this.txb_Address1.Name = "txb_Address1";
            this.txb_Address1.Size = new System.Drawing.Size(213, 20);
            this.txb_Address1.TabIndex = 6;
            // 
            // lbl_Address1
            // 
            this.lbl_Address1.AutoSize = true;
            this.lbl_Address1.Location = new System.Drawing.Point(26, 22);
            this.lbl_Address1.Name = "lbl_Address1";
            this.lbl_Address1.Size = new System.Drawing.Size(39, 13);
            this.lbl_Address1.TabIndex = 5;
            this.lbl_Address1.Text = "Line 1:";
            // 
            // grb_Info_Others
            // 
            this.grb_Info_Others.Controls.Add(this.lbl_AlertMessage);
            this.grb_Info_Others.Controls.Add(this.txb_AlertMessage);
            this.grb_Info_Others.Controls.Add(this.lbl_Remarks);
            this.grb_Info_Others.Controls.Add(this.txb_Remarks);
            this.grb_Info_Others.Location = new System.Drawing.Point(5, 248);
            this.grb_Info_Others.Name = "grb_Info_Others";
            this.grb_Info_Others.Size = new System.Drawing.Size(856, 78);
            this.grb_Info_Others.TabIndex = 16;
            this.grb_Info_Others.TabStop = false;
            // 
            // lbl_AlertMessage
            // 
            this.lbl_AlertMessage.AutoSize = true;
            this.lbl_AlertMessage.Location = new System.Drawing.Point(411, 17);
            this.lbl_AlertMessage.Name = "lbl_AlertMessage";
            this.lbl_AlertMessage.Size = new System.Drawing.Size(77, 13);
            this.lbl_AlertMessage.TabIndex = 14;
            this.lbl_AlertMessage.Text = "Alert Message:";
            // 
            // txb_AlertMessage
            // 
            this.txb_AlertMessage.Location = new System.Drawing.Point(494, 14);
            this.txb_AlertMessage.Multiline = true;
            this.txb_AlertMessage.Name = "txb_AlertMessage";
            this.txb_AlertMessage.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txb_AlertMessage.Size = new System.Drawing.Size(325, 53);
            this.txb_AlertMessage.TabIndex = 13;
            // 
            // lbl_Remarks
            // 
            this.lbl_Remarks.AutoSize = true;
            this.lbl_Remarks.Location = new System.Drawing.Point(14, 17);
            this.lbl_Remarks.Name = "lbl_Remarks";
            this.lbl_Remarks.Size = new System.Drawing.Size(52, 13);
            this.lbl_Remarks.TabIndex = 12;
            this.lbl_Remarks.Text = "Remarks:";
            // 
            // txb_Remarks
            // 
            this.txb_Remarks.Location = new System.Drawing.Point(72, 14);
            this.txb_Remarks.Multiline = true;
            this.txb_Remarks.Name = "txb_Remarks";
            this.txb_Remarks.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txb_Remarks.Size = new System.Drawing.Size(325, 53);
            this.txb_Remarks.TabIndex = 5;
            // 
            // grb_Info_Basic
            // 
            this.grb_Info_Basic.Controls.Add(this.btn_StoreLookup);
            this.grb_Info_Basic.Controls.Add(this.txb_Store);
            this.grb_Info_Basic.Controls.Add(this.lbl_Store);
            this.grb_Info_Basic.Controls.Add(this.lbl_CustomerGroup);
            this.grb_Info_Basic.Controls.Add(this.cmb_CustomerGroup);
            this.grb_Info_Basic.Controls.Add(this.txb_CompanyName);
            this.grb_Info_Basic.Controls.Add(this.lbl_CompanyName);
            this.grb_Info_Basic.Controls.Add(this.txb_LastName);
            this.grb_Info_Basic.Controls.Add(this.lbl_LastName);
            this.grb_Info_Basic.Controls.Add(this.txb_FirstName);
            this.grb_Info_Basic.Controls.Add(this.lbl_FirstName);
            this.grb_Info_Basic.Controls.Add(this.cmb_Salutation);
            this.grb_Info_Basic.Location = new System.Drawing.Point(5, 1);
            this.grb_Info_Basic.Name = "grb_Info_Basic";
            this.grb_Info_Basic.Size = new System.Drawing.Size(668, 106);
            this.grb_Info_Basic.TabIndex = 13;
            this.grb_Info_Basic.TabStop = false;
            // 
            // btn_StoreLookup
            // 
            this.btn_StoreLookup.Location = new System.Drawing.Point(607, 41);
            this.btn_StoreLookup.Name = "btn_StoreLookup";
            this.btn_StoreLookup.Size = new System.Drawing.Size(36, 20);
            this.btn_StoreLookup.TabIndex = 12;
            this.btn_StoreLookup.Text = "LU";
            this.btn_StoreLookup.UseVisualStyleBackColor = true;
            // 
            // txb_Store
            // 
            this.txb_Store.Location = new System.Drawing.Point(450, 41);
            this.txb_Store.Name = "txb_Store";
            this.txb_Store.Size = new System.Drawing.Size(157, 20);
            this.txb_Store.TabIndex = 11;
            // 
            // lbl_Store
            // 
            this.lbl_Store.AutoSize = true;
            this.lbl_Store.Location = new System.Drawing.Point(409, 44);
            this.lbl_Store.Name = "lbl_Store";
            this.lbl_Store.Size = new System.Drawing.Size(35, 13);
            this.lbl_Store.TabIndex = 10;
            this.lbl_Store.Text = "Store:";
            // 
            // lbl_CustomerGroup
            // 
            this.lbl_CustomerGroup.AutoSize = true;
            this.lbl_CustomerGroup.Location = new System.Drawing.Point(405, 20);
            this.lbl_CustomerGroup.Name = "lbl_CustomerGroup";
            this.lbl_CustomerGroup.Size = new System.Drawing.Size(39, 13);
            this.lbl_CustomerGroup.TabIndex = 8;
            this.lbl_CustomerGroup.Text = "Group:";
            // 
            // cmb_CustomerGroup
            // 
            this.cmb_CustomerGroup.FormattingEnabled = true;
            this.cmb_CustomerGroup.Location = new System.Drawing.Point(450, 17);
            this.cmb_CustomerGroup.Name = "cmb_CustomerGroup";
            this.cmb_CustomerGroup.Size = new System.Drawing.Size(192, 21);
            this.cmb_CustomerGroup.TabIndex = 7;
            // 
            // txb_CompanyName
            // 
            this.txb_CompanyName.Location = new System.Drawing.Point(93, 64);
            this.txb_CompanyName.Name = "txb_CompanyName";
            this.txb_CompanyName.Size = new System.Drawing.Size(192, 20);
            this.txb_CompanyName.TabIndex = 6;
            // 
            // lbl_CompanyName
            // 
            this.lbl_CompanyName.AutoSize = true;
            this.lbl_CompanyName.Location = new System.Drawing.Point(3, 67);
            this.lbl_CompanyName.Name = "lbl_CompanyName";
            this.lbl_CompanyName.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lbl_CompanyName.Size = new System.Drawing.Size(85, 13);
            this.lbl_CompanyName.TabIndex = 5;
            this.lbl_CompanyName.Text = "Company Name:";
            // 
            // txb_LastName
            // 
            this.txb_LastName.Location = new System.Drawing.Point(93, 41);
            this.txb_LastName.Name = "txb_LastName";
            this.txb_LastName.Size = new System.Drawing.Size(192, 20);
            this.txb_LastName.TabIndex = 4;
            // 
            // lbl_LastName
            // 
            this.lbl_LastName.AutoSize = true;
            this.lbl_LastName.Location = new System.Drawing.Point(27, 44);
            this.lbl_LastName.Name = "lbl_LastName";
            this.lbl_LastName.Size = new System.Drawing.Size(61, 13);
            this.lbl_LastName.TabIndex = 3;
            this.lbl_LastName.Text = "Last Name:";
            // 
            // txb_FirstName
            // 
            this.txb_FirstName.Location = new System.Drawing.Point(156, 17);
            this.txb_FirstName.Name = "txb_FirstName";
            this.txb_FirstName.Size = new System.Drawing.Size(129, 20);
            this.txb_FirstName.TabIndex = 2;
            // 
            // lbl_FirstName
            // 
            this.lbl_FirstName.AutoSize = true;
            this.lbl_FirstName.Location = new System.Drawing.Point(27, 20);
            this.lbl_FirstName.Name = "lbl_FirstName";
            this.lbl_FirstName.Size = new System.Drawing.Size(60, 13);
            this.lbl_FirstName.TabIndex = 1;
            this.lbl_FirstName.Text = "First Name:";
            // 
            // cmb_Salutation
            // 
            this.cmb_Salutation.FormattingEnabled = true;
            this.cmb_Salutation.Location = new System.Drawing.Point(93, 17);
            this.cmb_Salutation.Name = "cmb_Salutation";
            this.cmb_Salutation.Size = new System.Drawing.Size(57, 21);
            this.cmb_Salutation.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(963, 332);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // grb_TopControl
            // 
            this.grb_TopControl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grb_TopControl.Controls.Add(this.chb_Deactivate);
            this.grb_TopControl.Controls.Add(this.txb_CustomerDesc);
            this.grb_TopControl.Controls.Add(this.btn_Refresh);
            this.grb_TopControl.Controls.Add(this.btn_NextCustomer);
            this.grb_TopControl.Controls.Add(this.lbl_CustomerNo);
            this.grb_TopControl.Controls.Add(this.txb_CustomerNo);
            this.grb_TopControl.Location = new System.Drawing.Point(12, 12);
            this.grb_TopControl.Name = "grb_TopControl";
            this.grb_TopControl.Size = new System.Drawing.Size(967, 132);
            this.grb_TopControl.TabIndex = 1;
            this.grb_TopControl.TabStop = false;
            // 
            // chb_Deactivate
            // 
            this.chb_Deactivate.AutoSize = true;
            this.chb_Deactivate.Location = new System.Drawing.Point(32, 45);
            this.chb_Deactivate.Name = "chb_Deactivate";
            this.chb_Deactivate.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chb_Deactivate.Size = new System.Drawing.Size(85, 17);
            this.chb_Deactivate.TabIndex = 5;
            this.chb_Deactivate.Text = ":De-Activate";
            this.chb_Deactivate.UseVisualStyleBackColor = true;
            // 
            // txb_CustomerDesc
            // 
            this.txb_CustomerDesc.Location = new System.Drawing.Point(469, 19);
            this.txb_CustomerDesc.Multiline = true;
            this.txb_CustomerDesc.Name = "txb_CustomerDesc";
            this.txb_CustomerDesc.Size = new System.Drawing.Size(281, 85);
            this.txb_CustomerDesc.TabIndex = 4;
            // 
            // btn_Refresh
            // 
            this.btn_Refresh.Location = new System.Drawing.Point(362, 19);
            this.btn_Refresh.Name = "btn_Refresh";
            this.btn_Refresh.Size = new System.Drawing.Size(74, 20);
            this.btn_Refresh.TabIndex = 3;
            this.btn_Refresh.Text = "Refresh";
            this.btn_Refresh.UseVisualStyleBackColor = true;
            // 
            // btn_NextCustomer
            // 
            this.btn_NextCustomer.Location = new System.Drawing.Point(253, 19);
            this.btn_NextCustomer.Name = "btn_NextCustomer";
            this.btn_NextCustomer.Size = new System.Drawing.Size(103, 20);
            this.btn_NextCustomer.TabIndex = 2;
            this.btn_NextCustomer.Text = "Next Customer";
            this.btn_NextCustomer.UseVisualStyleBackColor = true;
            // 
            // lbl_CustomerNo
            // 
            this.lbl_CustomerNo.AutoSize = true;
            this.lbl_CustomerNo.Location = new System.Drawing.Point(6, 22);
            this.lbl_CustomerNo.Name = "lbl_CustomerNo";
            this.lbl_CustomerNo.Size = new System.Drawing.Size(94, 13);
            this.lbl_CustomerNo.TabIndex = 1;
            this.lbl_CustomerNo.Text = "Customer Number:";
            // 
            // txb_CustomerNo
            // 
            this.txb_CustomerNo.Location = new System.Drawing.Point(103, 19);
            this.txb_CustomerNo.Name = "txb_CustomerNo";
            this.txb_CustomerNo.Size = new System.Drawing.Size(144, 20);
            this.txb_CustomerNo.TabIndex = 0;
            // 
            // grb_BottomControl
            // 
            this.grb_BottomControl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grb_BottomControl.Controls.Add(this.btn_Remind);
            this.grb_BottomControl.Controls.Add(this.btn_Groupings);
            this.grb_BottomControl.Controls.Add(this.btn_Close);
            this.grb_BottomControl.Controls.Add(this.btn_Reports);
            this.grb_BottomControl.Controls.Add(this.btn_Delete);
            this.grb_BottomControl.Controls.Add(this.btn_New);
            this.grb_BottomControl.Controls.Add(this.btn_Lookup);
            this.grb_BottomControl.Controls.Add(this.btn_Save);
            this.grb_BottomControl.Location = new System.Drawing.Point(16, 510);
            this.grb_BottomControl.Name = "grb_BottomControl";
            this.grb_BottomControl.Size = new System.Drawing.Size(963, 50);
            this.grb_BottomControl.TabIndex = 0;
            this.grb_BottomControl.TabStop = false;
            // 
            // btn_Remind
            // 
            this.btn_Remind.Location = new System.Drawing.Point(767, 14);
            this.btn_Remind.Name = "btn_Remind";
            this.btn_Remind.Size = new System.Drawing.Size(85, 28);
            this.btn_Remind.TabIndex = 7;
            this.btn_Remind.Text = "Remind";
            this.btn_Remind.UseVisualStyleBackColor = true;
            // 
            // btn_Groupings
            // 
            this.btn_Groupings.Location = new System.Drawing.Point(679, 14);
            this.btn_Groupings.Name = "btn_Groupings";
            this.btn_Groupings.Size = new System.Drawing.Size(85, 28);
            this.btn_Groupings.TabIndex = 6;
            this.btn_Groupings.Text = "Groupings";
            this.btn_Groupings.UseVisualStyleBackColor = true;
            // 
            // btn_Close
            // 
            this.btn_Close.Location = new System.Drawing.Point(452, 14);
            this.btn_Close.Name = "btn_Close";
            this.btn_Close.Size = new System.Drawing.Size(85, 28);
            this.btn_Close.TabIndex = 5;
            this.btn_Close.Text = "Close";
            this.btn_Close.UseVisualStyleBackColor = true;
            // 
            // btn_Reports
            // 
            this.btn_Reports.Location = new System.Drawing.Point(364, 14);
            this.btn_Reports.Name = "btn_Reports";
            this.btn_Reports.Size = new System.Drawing.Size(85, 28);
            this.btn_Reports.TabIndex = 4;
            this.btn_Reports.Text = "Reports";
            this.btn_Reports.UseVisualStyleBackColor = true;
            // 
            // btn_Delete
            // 
            this.btn_Delete.Location = new System.Drawing.Point(276, 14);
            this.btn_Delete.Name = "btn_Delete";
            this.btn_Delete.Size = new System.Drawing.Size(85, 28);
            this.btn_Delete.TabIndex = 3;
            this.btn_Delete.Text = "Delete";
            this.btn_Delete.UseVisualStyleBackColor = true;
            // 
            // btn_New
            // 
            this.btn_New.Location = new System.Drawing.Point(188, 14);
            this.btn_New.Name = "btn_New";
            this.btn_New.Size = new System.Drawing.Size(85, 28);
            this.btn_New.TabIndex = 2;
            this.btn_New.Text = "New";
            this.btn_New.UseVisualStyleBackColor = true;
            // 
            // btn_Lookup
            // 
            this.btn_Lookup.Location = new System.Drawing.Point(100, 14);
            this.btn_Lookup.Name = "btn_Lookup";
            this.btn_Lookup.Size = new System.Drawing.Size(85, 28);
            this.btn_Lookup.TabIndex = 1;
            this.btn_Lookup.Text = "LookUp";
            this.btn_Lookup.UseVisualStyleBackColor = true;
            // 
            // btn_Save
            // 
            this.btn_Save.Location = new System.Drawing.Point(12, 14);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(85, 28);
            this.btn_Save.TabIndex = 0;
            this.btn_Save.Text = "Save";
            this.btn_Save.UseVisualStyleBackColor = true;
            this.btn_Save.Click += new System.EventHandler(this.btn_Save_Click);
            // 
            // CustomerRecord
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(995, 572);
            this.Controls.Add(this.tbc_Main);
            this.Controls.Add(this.grb_BottomControl);
            this.Controls.Add(this.grb_TopControl);
            this.Name = "CustomerRecord";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CustomerRecord";
            this.Load += new System.EventHandler(this.CustomerRecord_Load);
            this.tbc_Main.ResumeLayout(false);
            this.tbp_Info.ResumeLayout(false);
            this.grb_Info_Contact.ResumeLayout(false);
            this.grb_Info_Contact.PerformLayout();
            this.grb_Info_Address.ResumeLayout(false);
            this.grb_Info_Address.PerformLayout();
            this.grb_Info_Others.ResumeLayout(false);
            this.grb_Info_Others.PerformLayout();
            this.grb_Info_Basic.ResumeLayout(false);
            this.grb_Info_Basic.PerformLayout();
            this.grb_TopControl.ResumeLayout(false);
            this.grb_TopControl.PerformLayout();
            this.grb_BottomControl.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tbc_Main;
        private System.Windows.Forms.TabPage tbp_Info;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.GroupBox grb_TopControl;
        private System.Windows.Forms.GroupBox grb_BottomControl;
        private System.Windows.Forms.TextBox txb_CustomerDesc;
        private System.Windows.Forms.Button btn_Refresh;
        private System.Windows.Forms.Button btn_NextCustomer;
        private System.Windows.Forms.Label lbl_CustomerNo;
        private System.Windows.Forms.TextBox txb_CustomerNo;
        private System.Windows.Forms.CheckBox chb_Deactivate;
        private System.Windows.Forms.Button btn_StoreLookup;
        private System.Windows.Forms.TextBox txb_Store;
        private System.Windows.Forms.Label lbl_Store;
        private System.Windows.Forms.Label lbl_CustomerGroup;
        private System.Windows.Forms.ComboBox cmb_CustomerGroup;
        private System.Windows.Forms.TextBox txb_CompanyName;
        private System.Windows.Forms.Label lbl_CompanyName;
        private System.Windows.Forms.TextBox txb_LastName;
        private System.Windows.Forms.Label lbl_LastName;
        private System.Windows.Forms.TextBox txb_FirstName;
        private System.Windows.Forms.Label lbl_FirstName;
        private System.Windows.Forms.ComboBox cmb_Salutation;
        private System.Windows.Forms.GroupBox grb_Info_Contact;
        private System.Windows.Forms.GroupBox grb_Info_Address;
        private System.Windows.Forms.GroupBox grb_Info_Basic;
        private System.Windows.Forms.GroupBox grb_Info_Others;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.TextBox txb_Email;
        private System.Windows.Forms.Label lbl_Email;
        private System.Windows.Forms.TextBox txb_Fax;
        private System.Windows.Forms.Label lbl_Fax;
        private System.Windows.Forms.TextBox txb_Cellular;
        private System.Windows.Forms.Label lbl_Cellular;
        private System.Windows.Forms.TextBox txb_Phone2;
        private System.Windows.Forms.Label lbl_Phone2;
        private System.Windows.Forms.TextBox txb_Phone1;
        private System.Windows.Forms.Label lbl_Phone1;
        private System.Windows.Forms.TextBox txb_Country;
        private System.Windows.Forms.Label lbl_Country;
        private System.Windows.Forms.TextBox txb_PostalCode;
        private System.Windows.Forms.Label lbl_PostalCode;
        private System.Windows.Forms.TextBox txb_ProvState;
        private System.Windows.Forms.Label lbl_ProvState;
        private System.Windows.Forms.TextBox txb_City;
        private System.Windows.Forms.Label lbl_City;
        private System.Windows.Forms.TextBox txb_Address2;
        private System.Windows.Forms.Label lbl_Address2;
        private System.Windows.Forms.TextBox txb_Address1;
        private System.Windows.Forms.Label lbl_Address1;
        private System.Windows.Forms.Button btn_Remind;
        private System.Windows.Forms.Button btn_Groupings;
        private System.Windows.Forms.Button btn_Close;
        private System.Windows.Forms.Button btn_Reports;
        private System.Windows.Forms.Button btn_Delete;
        private System.Windows.Forms.Button btn_New;
        private System.Windows.Forms.Button btn_Lookup;
        private System.Windows.Forms.Button btn_Save;
        private System.Windows.Forms.Label lbl_AlertMessage;
        private System.Windows.Forms.TextBox txb_AlertMessage;
        private System.Windows.Forms.Label lbl_Remarks;
        private System.Windows.Forms.TextBox txb_Remarks;
    }
}