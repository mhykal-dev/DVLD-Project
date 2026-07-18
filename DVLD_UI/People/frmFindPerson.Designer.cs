namespace DVLD_UI.People
{
    partial class frmFindPerson
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
            this.btnClose = new System.Windows.Forms.Button();
            this.ctrNewPersonCardWithFilter2 = new DVLD_UI.People.User_Controls.CTRNewPersonCardWithFilter();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Image = global::DVLD_UI.Properties.Resources.Close_32;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(722, 419);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(117, 44);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // ctrNewPersonCardWithFilter2
            // 
            this.ctrNewPersonCardWithFilter2.FilterEnabled = true;
            this.ctrNewPersonCardWithFilter2.Location = new System.Drawing.Point(9, 12);
            this.ctrNewPersonCardWithFilter2.Name = "ctrNewPersonCardWithFilter2";
            this.ctrNewPersonCardWithFilter2.ShowAddPerson = true;
            this.ctrNewPersonCardWithFilter2.Size = new System.Drawing.Size(829, 382);
            this.ctrNewPersonCardWithFilter2.TabIndex = 2;
            // 
            // frmFindPerson
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(862, 475);
            this.Controls.Add(this.ctrNewPersonCardWithFilter2);
            this.Controls.Add(this.btnClose);
            this.Name = "frmFindPerson";
            this.Text = "frmFindPerson";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmFindPerson_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnClose;
        private User_Controls.CTRNewPersonCardWithFilter ctrNewPersonCardWithFilter2;
    }
}