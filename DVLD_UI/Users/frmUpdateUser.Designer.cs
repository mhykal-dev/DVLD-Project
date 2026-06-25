namespace DVLD_UI.Users
{
    partial class frmUpdateUser
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.ctrNewPersonCard1 = new DVLD_UI.People.User_Controls.CTRNewPersonCard();
            this.btnUpdatePersonalInFo = new System.Windows.Forms.Button();
            this.ctrUpdateUser1 = new DVLD_UI.Users.User_Controls.ctrUpdateUser();
            this.groupBox1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ctrUpdateUser1);
            this.groupBox1.Location = new System.Drawing.Point(6, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(835, 336);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "UpdateUserLogin InFo";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(855, 398);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(847, 372);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Login InFo";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.btnUpdatePersonalInFo);
            this.tabPage2.Controls.Add(this.ctrNewPersonCard1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(847, 372);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "PersonalDetails";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // ctrNewPersonCard1
            // 
            this.ctrNewPersonCard1.Location = new System.Drawing.Point(11, 22);
            this.ctrNewPersonCard1.Name = "ctrNewPersonCard1";
            this.ctrNewPersonCard1.Size = new System.Drawing.Size(824, 302);
            this.ctrNewPersonCard1.TabIndex = 0;
            // 
            // btnUpdatePersonalInFo
            // 
            this.btnUpdatePersonalInFo.Image = global::DVLD_UI.Properties.Resources.Save_32;
            this.btnUpdatePersonalInFo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUpdatePersonalInFo.Location = new System.Drawing.Point(680, 322);
            this.btnUpdatePersonalInFo.Name = "btnUpdatePersonalInFo";
            this.btnUpdatePersonalInFo.Size = new System.Drawing.Size(155, 44);
            this.btnUpdatePersonalInFo.TabIndex = 31;
            this.btnUpdatePersonalInFo.Text = "Update";
            this.btnUpdatePersonalInFo.UseVisualStyleBackColor = true;
            this.btnUpdatePersonalInFo.Click += new System.EventHandler(this.btnUpdatePersonalInFo_Click);
            // 
            // ctrUpdateUser1
            // 
            this.ctrUpdateUser1.Location = new System.Drawing.Point(6, 19);
            this.ctrUpdateUser1.Name = "ctrUpdateUser1";
            this.ctrUpdateUser1.Size = new System.Drawing.Size(816, 260);
            this.ctrUpdateUser1.TabIndex = 0;
            // 
            // frmUpdateUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 436);
            this.Controls.Add(this.tabControl1);
            this.Name = "frmUpdateUser";
            this.Text = "frmUpdateUser";
            this.Load += new System.EventHandler(this.frmUpdateUser_Load);
            this.groupBox1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private People.User_Controls.CTRNewPersonCard ctrNewPersonCard1;
        private System.Windows.Forms.Button btnUpdatePersonalInFo;
        private User_Controls.ctrUpdateUser ctrUpdateUser1;
    }
}