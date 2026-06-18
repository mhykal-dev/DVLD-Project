namespace DVLD_UI.Tests.Tests
{
    partial class frmScheduleTests
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmScheduleTests));
            this.ctrScheduleTests1 = new DVLD_UI.Tests.User_Controls.ctrScheduleTests();
            this.btnClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ctrScheduleTests1
            // 
            this.ctrScheduleTests1.Location = new System.Drawing.Point(8, 7);
            this.ctrScheduleTests1.Name = "ctrScheduleTests1";
            this.ctrScheduleTests1.Size = new System.Drawing.Size(542, 725);
            this.ctrScheduleTests1.TabIndex = 0;
            // 
            // btnClose
            // 
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(225, 738);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(124, 53);
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // frmScheduleTests
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(557, 803);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.ctrScheduleTests1);
            this.Name = "frmScheduleTests";
            this.Text = "frmScheduleTests";
            this.ResumeLayout(false);

        }

        #endregion

        private User_Controls.ctrScheduleTests ctrScheduleTests1;
        private System.Windows.Forms.Button btnClose;
    }
}