namespace TINPOS_Project.Window_Forms.Admin
{
    partial class ML_MenuLevel
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
            this.grb_1 = new System.Windows.Forms.GroupBox();
            this.txb_Name = new System.Windows.Forms.TextBox();
            this.txb_Description = new System.Windows.Forms.TextBox();
            this.lbl_Name = new System.Windows.Forms.Label();
            this.lbl_Description = new System.Windows.Forms.Label();
            this.grb_2 = new System.Windows.Forms.GroupBox();
            this.btn_Save = new System.Windows.Forms.Button();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.grb_1.SuspendLayout();
            this.grb_2.SuspendLayout();
            this.SuspendLayout();
            // 
            // grb_1
            // 
            this.grb_1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grb_1.Controls.Add(this.lbl_Description);
            this.grb_1.Controls.Add(this.lbl_Name);
            this.grb_1.Controls.Add(this.txb_Description);
            this.grb_1.Controls.Add(this.txb_Name);
            this.grb_1.Location = new System.Drawing.Point(12, 5);
            this.grb_1.Name = "grb_1";
            this.grb_1.Size = new System.Drawing.Size(293, 142);
            this.grb_1.TabIndex = 0;
            this.grb_1.TabStop = false;
            // 
            // txb_Name
            // 
            this.txb_Name.Location = new System.Drawing.Point(75, 19);
            this.txb_Name.Name = "txb_Name";
            this.txb_Name.Size = new System.Drawing.Size(212, 20);
            this.txb_Name.TabIndex = 0;
            // 
            // txb_Description
            // 
            this.txb_Description.Location = new System.Drawing.Point(75, 45);
            this.txb_Description.Multiline = true;
            this.txb_Description.Name = "txb_Description";
            this.txb_Description.Size = new System.Drawing.Size(212, 78);
            this.txb_Description.TabIndex = 1;
            // 
            // lbl_Name
            // 
            this.lbl_Name.AutoSize = true;
            this.lbl_Name.Location = new System.Drawing.Point(6, 22);
            this.lbl_Name.Name = "lbl_Name";
            this.lbl_Name.Size = new System.Drawing.Size(38, 13);
            this.lbl_Name.TabIndex = 2;
            this.lbl_Name.Text = "Name:";
            // 
            // lbl_Description
            // 
            this.lbl_Description.AutoSize = true;
            this.lbl_Description.Location = new System.Drawing.Point(6, 48);
            this.lbl_Description.Name = "lbl_Description";
            this.lbl_Description.Size = new System.Drawing.Size(63, 13);
            this.lbl_Description.TabIndex = 3;
            this.lbl_Description.Text = "Description:";
            // 
            // grb_2
            // 
            this.grb_2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grb_2.Controls.Add(this.btn_Cancel);
            this.grb_2.Controls.Add(this.btn_Save);
            this.grb_2.Location = new System.Drawing.Point(12, 144);
            this.grb_2.Name = "grb_2";
            this.grb_2.Size = new System.Drawing.Size(293, 52);
            this.grb_2.TabIndex = 1;
            this.grb_2.TabStop = false;
            // 
            // btn_Save
            // 
            this.btn_Save.Location = new System.Drawing.Point(128, 16);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(75, 23);
            this.btn_Save.TabIndex = 0;
            this.btn_Save.Text = "Save";
            this.btn_Save.UseVisualStyleBackColor = true;
            this.btn_Save.Click += new System.EventHandler(this.btn_Save_Click);
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.Location = new System.Drawing.Point(209, 16);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(75, 23);
            this.btn_Cancel.TabIndex = 1;
            this.btn_Cancel.Text = "Cancel";
            this.btn_Cancel.UseVisualStyleBackColor = true;
            // 
            // ML_MenuLevel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(317, 204);
            this.Controls.Add(this.grb_1);
            this.Controls.Add(this.grb_2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ML_MenuLevel";
            this.Text = "Menu Level";
            this.grb_1.ResumeLayout(false);
            this.grb_1.PerformLayout();
            this.grb_2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grb_1;
        private System.Windows.Forms.Label lbl_Description;
        private System.Windows.Forms.Label lbl_Name;
        private System.Windows.Forms.TextBox txb_Description;
        private System.Windows.Forms.TextBox txb_Name;
        private System.Windows.Forms.GroupBox grb_2;
        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.Button btn_Save;
    }
}