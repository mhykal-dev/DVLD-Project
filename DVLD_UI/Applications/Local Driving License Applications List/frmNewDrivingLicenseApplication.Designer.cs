namespace DVLD_UI.Applications.Local_Driving_License_Applications_List.Driving_Licenses_Applications.Driving_Licenses_Applications
{
    partial class frmNewDrivingLicenseApplication
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmNewDrivingLicenseApplication));
            this.lblTitle = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tpPersonalInFo = new System.Windows.Forms.TabPage();
            this.ctrNewPersonCardWithFilter1 = new DVLD_UI.People.User_Controls.CTRNewPersonCardWithFilter();
            this.btnNext = new System.Windows.Forms.Button();
            this.tpApplicationInFo = new System.Windows.Forms.TabPage();
            this.cmbClasses = new System.Windows.Forms.ComboBox();
            this.lblCreatedBy = new System.Windows.Forms.Label();
            this.lblFees = new System.Windows.Forms.Label();
            this.lblApplicationDate = new System.Windows.Forms.Label();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblID = new System.Windows.Forms.Label();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tpPersonalInFo.SuspendLayout();
            this.tpApplicationInFo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Uighur", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.Firebrick;
            this.lblTitle.Location = new System.Drawing.Point(191, 9);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(455, 45);
            this.lblTitle.TabIndex = 9;
            this.lblTitle.Text = "New Local Driving License Application";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tpPersonalInFo);
            this.tabControl1.Controls.Add(this.tpApplicationInFo);
            this.tabControl1.Location = new System.Drawing.Point(12, 58);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(865, 491);
            this.tabControl1.TabIndex = 8;
            // 
            // tpPersonalInFo
            // 
            this.tpPersonalInFo.Controls.Add(this.ctrNewPersonCardWithFilter1);
            this.tpPersonalInFo.Controls.Add(this.btnNext);
            this.tpPersonalInFo.Location = new System.Drawing.Point(4, 22);
            this.tpPersonalInFo.Name = "tpPersonalInFo";
            this.tpPersonalInFo.Padding = new System.Windows.Forms.Padding(3);
            this.tpPersonalInFo.Size = new System.Drawing.Size(857, 465);
            this.tpPersonalInFo.TabIndex = 0;
            this.tpPersonalInFo.Text = "Personal InFo";
            this.tpPersonalInFo.UseVisualStyleBackColor = true;
            // 
            // ctrNewPersonCardWithFilter1
            // 
            this.ctrNewPersonCardWithFilter1.FilterEnabled = true;
            this.ctrNewPersonCardWithFilter1.Location = new System.Drawing.Point(19, 19);
            this.ctrNewPersonCardWithFilter1.Name = "ctrNewPersonCardWithFilter1";
            this.ctrNewPersonCardWithFilter1.ShowAddPerson = true;
            this.ctrNewPersonCardWithFilter1.Size = new System.Drawing.Size(843, 386);
            this.ctrNewPersonCardWithFilter1.TabIndex = 6;
            this.ctrNewPersonCardWithFilter1.OnPersonSelectedev += new System.Action<int>(this.ctrNewPersonCardWithFilter1_OnPersonSelectedev);
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(655, 411);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(192, 47);
            this.btnNext.TabIndex = 5;
            this.btnNext.Text = "Next";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // tpApplicationInFo
            // 
            this.tpApplicationInFo.Controls.Add(this.cmbClasses);
            this.tpApplicationInFo.Controls.Add(this.lblCreatedBy);
            this.tpApplicationInFo.Controls.Add(this.lblFees);
            this.tpApplicationInFo.Controls.Add(this.lblApplicationDate);
            this.tpApplicationInFo.Controls.Add(this.pictureBox5);
            this.tpApplicationInFo.Controls.Add(this.label2);
            this.tpApplicationInFo.Controls.Add(this.lblID);
            this.tpApplicationInFo.Controls.Add(this.pictureBox4);
            this.tpApplicationInFo.Controls.Add(this.pictureBox3);
            this.tpApplicationInFo.Controls.Add(this.pictureBox2);
            this.tpApplicationInFo.Controls.Add(this.pictureBox1);
            this.tpApplicationInFo.Controls.Add(this.label6);
            this.tpApplicationInFo.Controls.Add(this.label5);
            this.tpApplicationInFo.Controls.Add(this.label4);
            this.tpApplicationInFo.Controls.Add(this.label3);
            this.tpApplicationInFo.Location = new System.Drawing.Point(4, 22);
            this.tpApplicationInFo.Name = "tpApplicationInFo";
            this.tpApplicationInFo.Padding = new System.Windows.Forms.Padding(3);
            this.tpApplicationInFo.Size = new System.Drawing.Size(857, 465);
            this.tpApplicationInFo.TabIndex = 1;
            this.tpApplicationInFo.Text = "ApplicationInFo";
            this.tpApplicationInFo.UseVisualStyleBackColor = true;
            // 
            // cmbClasses
            // 
            this.cmbClasses.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbClasses.FormattingEnabled = true;
            this.cmbClasses.Location = new System.Drawing.Point(302, 230);
            this.cmbClasses.Name = "cmbClasses";
            this.cmbClasses.Size = new System.Drawing.Size(260, 21);
            this.cmbClasses.TabIndex = 18;
            // 
            // lblCreatedBy
            // 
            this.lblCreatedBy.AutoSize = true;
            this.lblCreatedBy.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.lblCreatedBy.Location = new System.Drawing.Point(296, 365);
            this.lblCreatedBy.Name = "lblCreatedBy";
            this.lblCreatedBy.Size = new System.Drawing.Size(41, 21);
            this.lblCreatedBy.TabIndex = 17;
            this.lblCreatedBy.Text = "[???]";
            // 
            // lblFees
            // 
            this.lblFees.AutoSize = true;
            this.lblFees.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.lblFees.Location = new System.Drawing.Point(296, 297);
            this.lblFees.Name = "lblFees";
            this.lblFees.Size = new System.Drawing.Size(25, 21);
            this.lblFees.TabIndex = 16;
            this.lblFees.Text = "15";
            // 
            // lblApplicationDate
            // 
            this.lblApplicationDate.AutoSize = true;
            this.lblApplicationDate.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.lblApplicationDate.Location = new System.Drawing.Point(296, 179);
            this.lblApplicationDate.Name = "lblApplicationDate";
            this.lblApplicationDate.Size = new System.Drawing.Size(41, 21);
            this.lblApplicationDate.TabIndex = 15;
            this.lblApplicationDate.Text = "[???]";
            // 
            // pictureBox5
            // 
            this.pictureBox5.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox5.BackgroundImage")));
            this.pictureBox5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox5.Location = new System.Drawing.Point(225, 357);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(28, 29);
            this.pictureBox5.TabIndex = 14;
            this.pictureBox5.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(52, 365);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 21);
            this.label2.TabIndex = 13;
            this.label2.Text = "Created By:";
            // 
            // lblID
            // 
            this.lblID.AutoSize = true;
            this.lblID.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.lblID.Location = new System.Drawing.Point(296, 120);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(41, 21);
            this.lblID.TabIndex = 12;
            this.lblID.Text = "[???]";
            // 
            // pictureBox4
            // 
            this.pictureBox4.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox4.BackgroundImage")));
            this.pictureBox4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox4.Location = new System.Drawing.Point(225, 289);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(28, 29);
            this.pictureBox4.TabIndex = 7;
            this.pictureBox4.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox3.BackgroundImage")));
            this.pictureBox3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox3.Location = new System.Drawing.Point(225, 230);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(28, 29);
            this.pictureBox3.TabIndex = 6;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox2.BackgroundImage")));
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox2.Location = new System.Drawing.Point(225, 171);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(28, 29);
            this.pictureBox2.TabIndex = 5;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Location = new System.Drawing.Point(225, 112);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(28, 29);
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.label6.Location = new System.Drawing.Point(52, 297);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(135, 21);
            this.label6.TabIndex = 3;
            this.label6.Text = "Application Fees:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.label5.Location = new System.Drawing.Point(52, 238);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(108, 21);
            this.label5.TabIndex = 2;
            this.label5.Text = "License Class:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(52, 179);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(136, 21);
            this.label4.TabIndex = 1;
            this.label4.Text = "Application Date:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(52, 120);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(140, 21);
            this.label3.TabIndex = 0;
            this.label3.Text = "D.L.ApplicationID:";
            // 
            // btnClose
            // 
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(473, 551);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(192, 47);
            this.btnClose.TabIndex = 7;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.Enabled = false;
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(671, 551);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(192, 47);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // frmNewDrivingLicenseApplication
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(883, 606);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.Name = "frmNewDrivingLicenseApplication";
            this.Text = "frmNewDrivingLicenseApplication";
            this.Activated += new System.EventHandler(this.frmNewDrivingLicenseApplication_Activated);
            this.Load += new System.EventHandler(this.frmNewDrivingLicenseApplication_Load);
            this.tabControl1.ResumeLayout(false);
            this.tpPersonalInFo.ResumeLayout(false);
            this.tpApplicationInFo.ResumeLayout(false);
            this.tpApplicationInFo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tpPersonalInFo;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.TabPage tpApplicationInFo;
        private System.Windows.Forms.Label lblID;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.ComboBox cmbClasses;
        private System.Windows.Forms.Label lblCreatedBy;
        private System.Windows.Forms.Label lblFees;
        private System.Windows.Forms.Label lblApplicationDate;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.Label label2;
        private People.User_Controls.CTRNewPersonCardWithFilter ctrNewPersonCardWithFilter1;
    }
}