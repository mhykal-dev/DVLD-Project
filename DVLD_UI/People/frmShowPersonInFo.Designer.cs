namespace DVLD_UI.People
{
    partial class frmShowPersonInFo
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
            this.ctrNewPersonCard1 = new DVLD_UI.People.User_Controls.CTRNewPersonCard();
            this.btnClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ctrNewPersonCard1
            // 
            this.ctrNewPersonCard1.Location = new System.Drawing.Point(6, 12);
            this.ctrNewPersonCard1.Name = "ctrNewPersonCard1";
            this.ctrNewPersonCard1.Size = new System.Drawing.Size(836, 310);
            this.ctrNewPersonCard1.TabIndex = 0;
            // 
            // btnClose
            // 
            this.btnClose.Image = global::DVLD_UI.Properties.Resources.Close_32;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(682, 328);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(148, 45);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // frmShowPersonInFo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(854, 382);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.ctrNewPersonCard1);
            this.Name = "frmShowPersonInFo";
            this.Text = "frmShowPersonInFo";
            this.ResumeLayout(false);

        }

        #endregion

        private User_Controls.CTRNewPersonCard ctrNewPersonCard1;
        private System.Windows.Forms.Button btnClose;
    }
}