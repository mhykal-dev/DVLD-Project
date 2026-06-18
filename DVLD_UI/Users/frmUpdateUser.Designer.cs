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
            this.ctrUpdateUser1 = new DVLD_UI.Users.User_Controls.ctrUpdateUser();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ctrUpdateUser1);
            this.groupBox1.Location = new System.Drawing.Point(22, 54);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1012, 386);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "UpdateUserLogin InFo";
            // 
            // ctrUpdateUser1
            // 
            this.ctrUpdateUser1.Location = new System.Drawing.Point(32, 41);
            this.ctrUpdateUser1.Name = "ctrUpdateUser1";
            this.ctrUpdateUser1.PersonID = 0;
            this.ctrUpdateUser1.Size = new System.Drawing.Size(958, 315);
            this.ctrUpdateUser1.TabIndex = 0;
            this.ctrUpdateUser1.UserID = 0;
            // 
            // frmUpdateUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1046, 472);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmUpdateUser";
            this.Text = "frmUpdateUser";
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private User_Controls.ctrUpdateUser ctrUpdateUser1;
    }
}