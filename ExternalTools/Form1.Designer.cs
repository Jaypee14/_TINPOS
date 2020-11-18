namespace ExternalTools
{
    partial class w_Converter
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
            this.tabConverter = new System.Windows.Forms.TabControl();
            this.tab_Binary = new System.Windows.Forms.TabPage();
            this.label3 = new System.Windows.Forms.Label();
            this.btn_text_to_binary = new System.Windows.Forms.Button();
            this.btn_binary_to_text = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_output = new System.Windows.Forms.TextBox();
            this.txt_input = new System.Windows.Forms.TextBox();
            this.tab_Encryption = new System.Windows.Forms.TabPage();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_Output_E = new System.Windows.Forms.TextBox();
            this.txt_Input_E = new System.Windows.Forms.TextBox();
            this.btn_Encrypt = new System.Windows.Forms.Button();
            this.btn_decrypt = new System.Windows.Forms.Button();
            this.tabConverter.SuspendLayout();
            this.tab_Binary.SuspendLayout();
            this.tab_Encryption.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabConverter
            // 
            this.tabConverter.Controls.Add(this.tab_Binary);
            this.tabConverter.Controls.Add(this.tab_Encryption);
            this.tabConverter.Location = new System.Drawing.Point(12, 12);
            this.tabConverter.Name = "tabConverter";
            this.tabConverter.SelectedIndex = 0;
            this.tabConverter.Size = new System.Drawing.Size(441, 311);
            this.tabConverter.TabIndex = 0;
            // 
            // tab_Binary
            // 
            this.tab_Binary.Controls.Add(this.label3);
            this.tab_Binary.Controls.Add(this.btn_text_to_binary);
            this.tab_Binary.Controls.Add(this.btn_binary_to_text);
            this.tab_Binary.Controls.Add(this.label2);
            this.tab_Binary.Controls.Add(this.label1);
            this.tab_Binary.Controls.Add(this.txt_output);
            this.tab_Binary.Controls.Add(this.txt_input);
            this.tab_Binary.Location = new System.Drawing.Point(4, 22);
            this.tab_Binary.Name = "tab_Binary";
            this.tab_Binary.Padding = new System.Windows.Forms.Padding(3);
            this.tab_Binary.Size = new System.Drawing.Size(433, 285);
            this.tab_Binary.TabIndex = 1;
            this.tab_Binary.Text = "Binary";
            this.tab_Binary.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(192, 248);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Convert";
            // 
            // btn_text_to_binary
            // 
            this.btn_text_to_binary.Location = new System.Drawing.Point(264, 243);
            this.btn_text_to_binary.Name = "btn_text_to_binary";
            this.btn_text_to_binary.Size = new System.Drawing.Size(142, 23);
            this.btn_text_to_binary.TabIndex = 5;
            this.btn_text_to_binary.Text = "Text to Binary";
            this.btn_text_to_binary.UseVisualStyleBackColor = true;
            this.btn_text_to_binary.Click += new System.EventHandler(this.btn_text_to_binary_Click);
            // 
            // btn_binary_to_text
            // 
            this.btn_binary_to_text.Location = new System.Drawing.Point(21, 243);
            this.btn_binary_to_text.Name = "btn_binary_to_text";
            this.btn_binary_to_text.Size = new System.Drawing.Size(142, 23);
            this.btn_binary_to_text.TabIndex = 4;
            this.btn_binary_to_text.Text = "Binary to Text";
            this.btn_binary_to_text.UseVisualStyleBackColor = true;
            this.btn_binary_to_text.Click += new System.EventHandler(this.btn_binary_to_text_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 133);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Output:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Input:";
            // 
            // txt_output
            // 
            this.txt_output.Location = new System.Drawing.Point(6, 149);
            this.txt_output.Multiline = true;
            this.txt_output.Name = "txt_output";
            this.txt_output.Size = new System.Drawing.Size(421, 88);
            this.txt_output.TabIndex = 1;
            // 
            // txt_input
            // 
            this.txt_input.Location = new System.Drawing.Point(6, 30);
            this.txt_input.Multiline = true;
            this.txt_input.Name = "txt_input";
            this.txt_input.Size = new System.Drawing.Size(421, 88);
            this.txt_input.TabIndex = 0;
            // 
            // tab_Encryption
            // 
            this.tab_Encryption.Controls.Add(this.btn_decrypt);
            this.tab_Encryption.Controls.Add(this.btn_Encrypt);
            this.tab_Encryption.Controls.Add(this.label4);
            this.tab_Encryption.Controls.Add(this.label5);
            this.tab_Encryption.Controls.Add(this.txt_Output_E);
            this.tab_Encryption.Controls.Add(this.txt_Input_E);
            this.tab_Encryption.Location = new System.Drawing.Point(4, 22);
            this.tab_Encryption.Name = "tab_Encryption";
            this.tab_Encryption.Padding = new System.Windows.Forms.Padding(3);
            this.tab_Encryption.Size = new System.Drawing.Size(433, 285);
            this.tab_Encryption.TabIndex = 2;
            this.tab_Encryption.Text = "Encryption";
            this.tab_Encryption.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(18, 133);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Output:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(18, 12);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(34, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Input:";
            // 
            // txt_Output_E
            // 
            this.txt_Output_E.Location = new System.Drawing.Point(6, 149);
            this.txt_Output_E.Multiline = true;
            this.txt_Output_E.Name = "txt_Output_E";
            this.txt_Output_E.Size = new System.Drawing.Size(421, 88);
            this.txt_Output_E.TabIndex = 5;
            // 
            // txt_Input_E
            // 
            this.txt_Input_E.Location = new System.Drawing.Point(6, 30);
            this.txt_Input_E.Multiline = true;
            this.txt_Input_E.Name = "txt_Input_E";
            this.txt_Input_E.Size = new System.Drawing.Size(421, 88);
            this.txt_Input_E.TabIndex = 4;
            // 
            // btn_Encrypt
            // 
            this.btn_Encrypt.Location = new System.Drawing.Point(21, 243);
            this.btn_Encrypt.Name = "btn_Encrypt";
            this.btn_Encrypt.Size = new System.Drawing.Size(142, 23);
            this.btn_Encrypt.TabIndex = 8;
            this.btn_Encrypt.Text = "Encrypt Text";
            this.btn_Encrypt.UseVisualStyleBackColor = true;
            this.btn_Encrypt.Click += new System.EventHandler(this.btn_Encrypt_Click);
            // 
            // btn_decrypt
            // 
            this.btn_decrypt.Location = new System.Drawing.Point(264, 243);
            this.btn_decrypt.Name = "btn_decrypt";
            this.btn_decrypt.Size = new System.Drawing.Size(142, 23);
            this.btn_decrypt.TabIndex = 9;
            this.btn_decrypt.Text = "Decrypt Text";
            this.btn_decrypt.UseVisualStyleBackColor = true;
            this.btn_decrypt.Click += new System.EventHandler(this.btn_decrypt_Click);
            // 
            // w_Converter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(465, 335);
            this.Controls.Add(this.tabConverter);
            this.Name = "w_Converter";
            this.Text = "Converter";
            this.tabConverter.ResumeLayout(false);
            this.tab_Binary.ResumeLayout(false);
            this.tab_Binary.PerformLayout();
            this.tab_Encryption.ResumeLayout(false);
            this.tab_Encryption.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabConverter;
        private System.Windows.Forms.TabPage tab_Binary;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btn_text_to_binary;
        private System.Windows.Forms.Button btn_binary_to_text;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_output;
        private System.Windows.Forms.TextBox txt_input;
        private System.Windows.Forms.TabPage tab_Encryption;
        private System.Windows.Forms.Button btn_decrypt;
        private System.Windows.Forms.Button btn_Encrypt;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txt_Output_E;
        private System.Windows.Forms.TextBox txt_Input_E;
    }
}

