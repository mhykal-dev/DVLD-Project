namespace DVLD_UI.Users
{
    partial class frmChangePassword
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
            this.ctrChangeUserPassword1 = new DVLD_UI.Users.User_Controls.ctrChangeUserPassword();
            this.SuspendLayout();
            // 
            // ctrChangeUserPassword1
            // 
            this.ctrChangeUserPassword1.Location = new System.Drawing.Point(12, 23);
            this.ctrChangeUserPassword1.Name = "ctrChangeUserPassword1";
            this.ctrChangeUserPassword1.Size = new System.Drawing.Size(863, 405);
            this.ctrChangeUserPassword1.TabIndex = 0;
            // 
            // frmChangePassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(893, 450);
            this.Controls.Add(this.ctrChangeUserPassword1);
            this.Name = "frmChangePassword";
            this.Text = "frmChangePassword";
            this.ResumeLayout(false);

        }

        #endregion

        private User_Controls.ctrChangeUserPassword ctrChangeUserPassword1;
    }
}