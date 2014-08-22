namespace ApixioDataLoaderConfigGenerator
{
    partial class AddNewItem
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
            this.dateTimeSourceDate = new System.Windows.Forms.DateTimePicker();
            this.btnAddNewPath = new System.Windows.Forms.Button();
            this.txtSourceType = new System.Windows.Forms.TextBox();
            this.txtSourceSystem = new System.Windows.Forms.TextBox();
            this.txtPath = new System.Windows.Forms.TextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.btnSaveNew = new System.Windows.Forms.Button();
            this.btnCancelNew = new System.Windows.Forms.Button();
            this.cboFileType = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cboEditType = new System.Windows.Forms.ComboBox();
            this.chkUseDefaultSource = new System.Windows.Forms.CheckBox();
            this.chkSkipHeader = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // dateTimeSourceDate
            // 
            this.dateTimeSourceDate.CustomFormat = "yyyy-MM-dd";
            this.dateTimeSourceDate.Enabled = false;
            this.dateTimeSourceDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimeSourceDate.Location = new System.Drawing.Point(113, 207);
            this.dateTimeSourceDate.Name = "dateTimeSourceDate";
            this.dateTimeSourceDate.Size = new System.Drawing.Size(202, 20);
            this.dateTimeSourceDate.TabIndex = 8;
            // 
            // btnAddNewPath
            // 
            this.btnAddNewPath.Location = new System.Drawing.Point(373, 38);
            this.btnAddNewPath.Name = "btnAddNewPath";
            this.btnAddNewPath.Size = new System.Drawing.Size(25, 23);
            this.btnAddNewPath.TabIndex = 49;
            this.btnAddNewPath.Text = "...";
            this.btnAddNewPath.UseVisualStyleBackColor = true;
            this.btnAddNewPath.Click += new System.EventHandler(this.btnAddNewPath_Click);
            // 
            // txtSourceType
            // 
            this.txtSourceType.Enabled = false;
            this.txtSourceType.Location = new System.Drawing.Point(113, 180);
            this.txtSourceType.Name = "txtSourceType";
            this.txtSourceType.Size = new System.Drawing.Size(255, 20);
            this.txtSourceType.TabIndex = 7;
            this.txtSourceType.TextChanged += new System.EventHandler(this.txtSourceType_TextChanged);
            // 
            // txtSourceSystem
            // 
            this.txtSourceSystem.Enabled = false;
            this.txtSourceSystem.Location = new System.Drawing.Point(113, 152);
            this.txtSourceSystem.Name = "txtSourceSystem";
            this.txtSourceSystem.Size = new System.Drawing.Size(255, 20);
            this.txtSourceSystem.TabIndex = 6;
            this.txtSourceSystem.TextChanged += new System.EventHandler(this.txtSourceSystem_TextChanged);
            // 
            // txtPath
            // 
            this.txtPath.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.AllUrl;
            this.txtPath.Location = new System.Drawing.Point(113, 39);
            this.txtPath.Name = "txtPath";
            this.txtPath.Size = new System.Drawing.Size(253, 20);
            this.txtPath.TabIndex = 2;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(51, 69);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(52, 13);
            this.label23.TabIndex = 45;
            this.label23.Text = "Edit Type";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(35, 213);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(67, 13);
            this.label25.TabIndex = 43;
            this.label25.Text = "Source Date";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(35, 183);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(68, 13);
            this.label26.TabIndex = 42;
            this.label26.Text = "Source Type";
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(25, 156);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(78, 13);
            this.label27.TabIndex = 41;
            this.label27.Text = "Source System";
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(74, 43);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(29, 13);
            this.label28.TabIndex = 40;
            this.label28.Text = "Path";
            // 
            // btnSaveNew
            // 
            this.btnSaveNew.Location = new System.Drawing.Point(140, 233);
            this.btnSaveNew.Name = "btnSaveNew";
            this.btnSaveNew.Size = new System.Drawing.Size(75, 23);
            this.btnSaveNew.TabIndex = 9;
            this.btnSaveNew.Text = "&Save";
            this.btnSaveNew.UseVisualStyleBackColor = true;
            this.btnSaveNew.Click += new System.EventHandler(this.btnSaveNew_Click);
            // 
            // btnCancelNew
            // 
            this.btnCancelNew.Location = new System.Drawing.Point(248, 233);
            this.btnCancelNew.Name = "btnCancelNew";
            this.btnCancelNew.Size = new System.Drawing.Size(75, 23);
            this.btnCancelNew.TabIndex = 10;
            this.btnCancelNew.Text = "&Cancel";
            this.btnCancelNew.UseVisualStyleBackColor = true;
            this.btnCancelNew.Click += new System.EventHandler(this.btnCancelNew_Click);
            // 
            // cboFileType
            // 
            this.cboFileType.FormattingEnabled = true;
            this.cboFileType.Location = new System.Drawing.Point(113, 12);
            this.cboFileType.Name = "cboFileType";
            this.cboFileType.Size = new System.Drawing.Size(253, 21);
            this.cboFileType.TabIndex = 1;
            this.cboFileType.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(53, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 13);
            this.label1.TabIndex = 56;
            this.label1.Text = "File Type";
            // 
            // cboEditType
            // 
            this.cboEditType.FormattingEnabled = true;
            this.cboEditType.Location = new System.Drawing.Point(113, 65);
            this.cboEditType.Name = "cboEditType";
            this.cboEditType.Size = new System.Drawing.Size(253, 21);
            this.cboEditType.TabIndex = 3;
            // 
            // chkUseDefaultSource
            // 
            this.chkUseDefaultSource.AutoSize = true;
            this.chkUseDefaultSource.Checked = true;
            this.chkUseDefaultSource.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkUseDefaultSource.Location = new System.Drawing.Point(113, 129);
            this.chkUseDefaultSource.Name = "chkUseDefaultSource";
            this.chkUseDefaultSource.Size = new System.Drawing.Size(174, 17);
            this.chkUseDefaultSource.TabIndex = 5;
            this.chkUseDefaultSource.Text = "Use Default Source Information";
            this.chkUseDefaultSource.UseVisualStyleBackColor = true;
            this.chkUseDefaultSource.CheckedChanged += new System.EventHandler(this.chkUseDefaultSource_CheckedChanged);
            // 
            // chkSkipHeader
            // 
            this.chkSkipHeader.AutoSize = true;
            this.chkSkipHeader.Checked = true;
            this.chkSkipHeader.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkSkipHeader.Location = new System.Drawing.Point(113, 106);
            this.chkSkipHeader.Name = "chkSkipHeader";
            this.chkSkipHeader.Size = new System.Drawing.Size(113, 17);
            this.chkSkipHeader.TabIndex = 4;
            this.chkSkipHeader.Text = "Skip Header Lines";
            this.chkSkipHeader.UseVisualStyleBackColor = true;
            // 
            // AddNewItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(424, 273);
            this.ControlBox = false;
            this.Controls.Add(this.chkSkipHeader);
            this.Controls.Add(this.chkUseDefaultSource);
            this.Controls.Add(this.cboEditType);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cboFileType);
            this.Controls.Add(this.btnCancelNew);
            this.Controls.Add(this.btnSaveNew);
            this.Controls.Add(this.dateTimeSourceDate);
            this.Controls.Add(this.btnAddNewPath);
            this.Controls.Add(this.txtSourceType);
            this.Controls.Add(this.txtSourceSystem);
            this.Controls.Add(this.txtPath);
            this.Controls.Add(this.label23);
            this.Controls.Add(this.label25);
            this.Controls.Add(this.label26);
            this.Controls.Add(this.label27);
            this.Controls.Add(this.label28);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddNewItem";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "AddNewItem";
            this.Load += new System.EventHandler(this.AddNewItem_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dateTimeSourceDate;
        private System.Windows.Forms.Button btnAddNewPath;
        private System.Windows.Forms.TextBox txtSourceType;
        private System.Windows.Forms.TextBox txtSourceSystem;
        private System.Windows.Forms.TextBox txtPath;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Button btnSaveNew;
        private System.Windows.Forms.Button btnCancelNew;
        private System.Windows.Forms.ComboBox cboFileType;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboEditType;
        private System.Windows.Forms.CheckBox chkUseDefaultSource;
        private System.Windows.Forms.CheckBox chkSkipHeader;
    }
}