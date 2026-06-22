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
            this.ctrNewPersonCardWithFilter1 = new DVLD_UI.People.User_Controls.CTRNewPersonCardWithFilter();
            this.btnClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ctrNewPersonCardWithFilter1
            // 
            this.ctrNewPersonCardWithFilter1.FilterEnabled = true;
            this.ctrNewPersonCardWithFilter1.Location = new System.Drawing.Point(12, 12);
            this.ctrNewPersonCardWithFilter1.Name = "ctrNewPersonCardWithFilter1";
            this.ctrNewPersonCardWithFilter1.ShowAddPerson = true;
            this.ctrNewPersonCardWithFilter1.Size = new System.Drawing.Size(837, 401);
            this.ctrNewPersonCardWithFilter1.TabIndex = 0;
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
            // frmFindPerson
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(862, 475);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.ctrNewPersonCardWithFilter1);
            this.Name = "frmFindPerson";
            this.Text = "frmFindPerson";
            this.ResumeLayout(false);

        }

        #endregion

        private User_Controls.CTRNewPersonCardWithFilter ctrNewPersonCardWithFilter1;
        private System.Windows.Forms.Button btnClose;
    }
}