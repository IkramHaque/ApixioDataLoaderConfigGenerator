namespace ApixioDataLoaderConfigGenerator
{
    partial class FormDataLoader
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormDataLoader));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dateTimeSourceDate = new System.Windows.Forms.DateTimePicker();
            this.txtSourceType = new System.Windows.Forms.TextBox();
            this.txtSourceSystem = new System.Windows.Forms.TextBox();
            this.btnWorkingDirectory = new System.Windows.Forms.Button();
            this.txtPrimaryAuthority = new System.Windows.Forms.TextBox();
            this.txtDefaultAuthority = new System.Windows.Forms.TextBox();
            this.txtWorkingDirectory = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dgApixioFiles = new System.Windows.Forms.DataGridView();
            this.FileType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FilePath = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SourceOverride = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SkipHeader = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EditType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.chkDebugMode = new System.Windows.Forms.CheckBox();
            this.btnRunDataLoader = new System.Windows.Forms.Button();
            this.btnOpenDataLoaderFile = new System.Windows.Forms.Button();
            this.txtDataLoaderFilePath = new System.Windows.Forms.TextBox();
            this.chkWorkflowDeleteOnClose = new System.Windows.Forms.CheckBox();
            this.label96 = new System.Windows.Forms.Label();
            this.btnSaveConfig = new System.Windows.Forms.Button();
            this.btnOpenConfig = new System.Windows.Forms.Button();
            this.btnOpenConfigFile = new System.Windows.Forms.Button();
            this.txtConfigFilePath = new System.Windows.Forms.TextBox();
            this.label95 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.txtOutput = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtUploadUserName = new System.Windows.Forms.TextBox();
            this.chkWorkflowUpload = new System.Windows.Forms.CheckBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.chkWorkflowOutput = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnWorkflowFileName = new System.Windows.Forms.Button();
            this.txtWorkflowOutputFilePath = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.chkWorkflowMapOverwrite = new System.Windows.Forms.CheckBox();
            this.chkWorkflowMap = new System.Windows.Forms.CheckBox();
            this.chkWorkflowValidation = new System.Windows.Forms.CheckBox();
            this.chkWorkflowUploadOverwrite = new System.Windows.Forms.CheckBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btbDelete = new System.Windows.Forms.Button();
            this.SourceType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FileLocation = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OverrideSourceDetails = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtUploadPassword = new System.Windows.Forms.TextBox();
            this.txtUploadServer = new System.Windows.Forms.TextBox();
            this.txtUploadBatchName = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgApixioFiles)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox6.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dateTimeSourceDate);
            this.groupBox1.Controls.Add(this.txtSourceType);
            this.groupBox1.Controls.Add(this.txtSourceSystem);
            this.groupBox1.Controls.Add(this.btnWorkingDirectory);
            this.groupBox1.Controls.Add(this.txtPrimaryAuthority);
            this.groupBox1.Controls.Add(this.txtDefaultAuthority);
            this.groupBox1.Controls.Add(this.txtWorkingDirectory);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(1, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(754, 110);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "General";
            // 
            // dateTimeSourceDate
            // 
            this.dateTimeSourceDate.CustomFormat = "yyyy-MM-dd";
            this.dateTimeSourceDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimeSourceDate.Location = new System.Drawing.Point(496, 77);
            this.dateTimeSourceDate.Name = "dateTimeSourceDate";
            this.dateTimeSourceDate.Size = new System.Drawing.Size(252, 20);
            this.dateTimeSourceDate.TabIndex = 12;
            // 
            // txtSourceType
            // 
            this.txtSourceType.Location = new System.Drawing.Point(495, 50);
            this.txtSourceType.Name = "txtSourceType";
            this.txtSourceType.Size = new System.Drawing.Size(253, 20);
            this.txtSourceType.TabIndex = 11;
            // 
            // txtSourceSystem
            // 
            this.txtSourceSystem.Location = new System.Drawing.Point(495, 23);
            this.txtSourceSystem.Name = "txtSourceSystem";
            this.txtSourceSystem.Size = new System.Drawing.Size(253, 20);
            this.txtSourceSystem.TabIndex = 10;
            // 
            // btnWorkingDirectory
            // 
            this.btnWorkingDirectory.Location = new System.Drawing.Point(361, 20);
            this.btnWorkingDirectory.Name = "btnWorkingDirectory";
            this.btnWorkingDirectory.Size = new System.Drawing.Size(25, 23);
            this.btnWorkingDirectory.TabIndex = 9;
            this.btnWorkingDirectory.Text = "...";
            this.btnWorkingDirectory.UseVisualStyleBackColor = true;
            this.btnWorkingDirectory.Click += new System.EventHandler(this.btnWorkingDirectory_Click);
            // 
            // txtPrimaryAuthority
            // 
            this.txtPrimaryAuthority.Location = new System.Drawing.Point(101, 77);
            this.txtPrimaryAuthority.Name = "txtPrimaryAuthority";
            this.txtPrimaryAuthority.Size = new System.Drawing.Size(253, 20);
            this.txtPrimaryAuthority.TabIndex = 8;
            // 
            // txtDefaultAuthority
            // 
            this.txtDefaultAuthority.Location = new System.Drawing.Point(101, 49);
            this.txtDefaultAuthority.Name = "txtDefaultAuthority";
            this.txtDefaultAuthority.Size = new System.Drawing.Size(253, 20);
            this.txtDefaultAuthority.TabIndex = 7;
            // 
            // txtWorkingDirectory
            // 
            this.txtWorkingDirectory.Location = new System.Drawing.Point(101, 22);
            this.txtWorkingDirectory.Name = "txtWorkingDirectory";
            this.txtWorkingDirectory.Size = new System.Drawing.Size(253, 20);
            this.txtWorkingDirectory.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(428, 81);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Source Date";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(427, 54);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(68, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Source Type";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(417, 27);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(78, 13);
            this.label6.TabIndex = 3;
            this.label6.Text = "Source System";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 80);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Primary Authority";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Default Authority";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(2, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Working Directory";
            // 
            // dgApixioFiles
            // 
            this.dgApixioFiles.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgApixioFiles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgApixioFiles.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.FileType,
            this.FilePath,
            this.SourceOverride,
            this.SkipHeader,
            this.EditType});
            this.dgApixioFiles.Location = new System.Drawing.Point(1, 364);
            this.dgApixioFiles.MultiSelect = false;
            this.dgApixioFiles.Name = "dgApixioFiles";
            this.dgApixioFiles.ReadOnly = true;
            this.dgApixioFiles.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgApixioFiles.Size = new System.Drawing.Size(754, 145);
            this.dgApixioFiles.TabIndex = 3;
            // 
            // FileType
            // 
            this.FileType.HeaderText = "FileType";
            this.FileType.Name = "FileType";
            this.FileType.ReadOnly = true;
            this.FileType.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.FileType.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // FilePath
            // 
            this.FilePath.HeaderText = "FilePath";
            this.FilePath.Name = "FilePath";
            this.FilePath.ReadOnly = true;
            this.FilePath.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.FilePath.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // SourceOverride
            // 
            this.SourceOverride.HeaderText = "SourceOverride";
            this.SourceOverride.Name = "SourceOverride";
            this.SourceOverride.ReadOnly = true;
            this.SourceOverride.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.SourceOverride.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // SkipHeader
            // 
            this.SkipHeader.HeaderText = "SkipHeader";
            this.SkipHeader.Name = "SkipHeader";
            this.SkipHeader.ReadOnly = true;
            // 
            // EditType
            // 
            this.EditType.HeaderText = "EditType";
            this.EditType.Name = "EditType";
            this.EditType.ReadOnly = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.chkDebugMode);
            this.groupBox2.Controls.Add(this.btnRunDataLoader);
            this.groupBox2.Controls.Add(this.btnOpenDataLoaderFile);
            this.groupBox2.Controls.Add(this.txtDataLoaderFilePath);
            this.groupBox2.Controls.Add(this.chkWorkflowDeleteOnClose);
            this.groupBox2.Controls.Add(this.label96);
            this.groupBox2.Controls.Add(this.btnSaveConfig);
            this.groupBox2.Controls.Add(this.btnOpenConfig);
            this.groupBox2.Controls.Add(this.btnOpenConfigFile);
            this.groupBox2.Controls.Add(this.txtConfigFilePath);
            this.groupBox2.Controls.Add(this.label95);
            this.groupBox2.Location = new System.Drawing.Point(1, 536);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(754, 99);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            // 
            // chkDebugMode
            // 
            this.chkDebugMode.AutoSize = true;
            this.chkDebugMode.Location = new System.Drawing.Point(576, 74);
            this.chkDebugMode.Name = "chkDebugMode";
            this.chkDebugMode.Size = new System.Drawing.Size(123, 17);
            this.chkDebugMode.TabIndex = 30;
            this.chkDebugMode.Text = "Run In Debug Mode";
            this.chkDebugMode.UseVisualStyleBackColor = true;
            // 
            // btnRunDataLoader
            // 
            this.btnRunDataLoader.Enabled = false;
            this.btnRunDataLoader.Location = new System.Drawing.Point(553, 49);
            this.btnRunDataLoader.Name = "btnRunDataLoader";
            this.btnRunDataLoader.Size = new System.Drawing.Size(171, 23);
            this.btnRunDataLoader.TabIndex = 29;
            this.btnRunDataLoader.Text = "Save Config And &Run Loader";
            this.btnRunDataLoader.UseVisualStyleBackColor = true;
            this.btnRunDataLoader.Click += new System.EventHandler(this.btnRunDataLoader_Click);
            // 
            // btnOpenDataLoaderFile
            // 
            this.btnOpenDataLoaderFile.Location = new System.Drawing.Point(479, 44);
            this.btnOpenDataLoaderFile.Name = "btnOpenDataLoaderFile";
            this.btnOpenDataLoaderFile.Size = new System.Drawing.Size(25, 23);
            this.btnOpenDataLoaderFile.TabIndex = 28;
            this.btnOpenDataLoaderFile.Text = "...";
            this.btnOpenDataLoaderFile.UseVisualStyleBackColor = true;
            this.btnOpenDataLoaderFile.Click += new System.EventHandler(this.btnOpenDataLoaderFile_Click);
            // 
            // txtDataLoaderFilePath
            // 
            this.txtDataLoaderFilePath.Location = new System.Drawing.Point(101, 45);
            this.txtDataLoaderFilePath.Name = "txtDataLoaderFilePath";
            this.txtDataLoaderFilePath.Size = new System.Drawing.Size(372, 20);
            this.txtDataLoaderFilePath.TabIndex = 27;
            // 
            // chkWorkflowDeleteOnClose
            // 
            this.chkWorkflowDeleteOnClose.AutoSize = true;
            this.chkWorkflowDeleteOnClose.Location = new System.Drawing.Point(100, 76);
            this.chkWorkflowDeleteOnClose.Name = "chkWorkflowDeleteOnClose";
            this.chkWorkflowDeleteOnClose.Size = new System.Drawing.Size(183, 17);
            this.chkWorkflowDeleteOnClose.TabIndex = 9;
            this.chkWorkflowDeleteOnClose.Text = "Delete Internal DB on Completion";
            this.chkWorkflowDeleteOnClose.UseVisualStyleBackColor = true;
            // 
            // label96
            // 
            this.label96.AutoSize = true;
            this.label96.Location = new System.Drawing.Point(3, 49);
            this.label96.Name = "label96";
            this.label96.Size = new System.Drawing.Size(91, 13);
            this.label96.TabIndex = 26;
            this.label96.Text = "Data Loader Path";
            // 
            // btnSaveConfig
            // 
            this.btnSaveConfig.Location = new System.Drawing.Point(649, 19);
            this.btnSaveConfig.Name = "btnSaveConfig";
            this.btnSaveConfig.Size = new System.Drawing.Size(75, 23);
            this.btnSaveConfig.TabIndex = 25;
            this.btnSaveConfig.Text = "&Save";
            this.btnSaveConfig.UseVisualStyleBackColor = true;
            this.btnSaveConfig.Click += new System.EventHandler(this.btnSaveConfig_Click);
            // 
            // btnOpenConfig
            // 
            this.btnOpenConfig.Location = new System.Drawing.Point(553, 19);
            this.btnOpenConfig.Name = "btnOpenConfig";
            this.btnOpenConfig.Size = new System.Drawing.Size(75, 23);
            this.btnOpenConfig.TabIndex = 24;
            this.btnOpenConfig.Text = "&Load";
            this.btnOpenConfig.UseVisualStyleBackColor = true;
            this.btnOpenConfig.Click += new System.EventHandler(this.btnOpenConfig_Click);
            // 
            // btnOpenConfigFile
            // 
            this.btnOpenConfigFile.Location = new System.Drawing.Point(479, 18);
            this.btnOpenConfigFile.Name = "btnOpenConfigFile";
            this.btnOpenConfigFile.Size = new System.Drawing.Size(25, 23);
            this.btnOpenConfigFile.TabIndex = 23;
            this.btnOpenConfigFile.Text = "...";
            this.btnOpenConfigFile.UseVisualStyleBackColor = true;
            this.btnOpenConfigFile.Click += new System.EventHandler(this.btnOpenConfigFile_Click);
            // 
            // txtConfigFilePath
            // 
            this.txtConfigFilePath.Location = new System.Drawing.Point(101, 19);
            this.txtConfigFilePath.Name = "txtConfigFilePath";
            this.txtConfigFilePath.Size = new System.Drawing.Size(372, 20);
            this.txtConfigFilePath.TabIndex = 22;
            // 
            // label95
            // 
            this.label95.AutoSize = true;
            this.label95.Location = new System.Drawing.Point(33, 23);
            this.label95.Name = "label95";
            this.label95.Size = new System.Drawing.Size(62, 13);
            this.label95.TabIndex = 21;
            this.label95.Text = "Config Path";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtOutput);
            this.groupBox3.Controls.Add(this.groupBox6);
            this.groupBox3.Controls.Add(this.groupBox5);
            this.groupBox3.Controls.Add(this.groupBox4);
            this.groupBox3.Controls.Add(this.chkWorkflowValidation);
            this.groupBox3.Location = new System.Drawing.Point(1, 118);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(754, 245);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Workflow";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(539, 7);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(128, 104);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 13;
            this.pictureBox1.TabStop = false;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.pictureBox1);
            this.groupBox6.Controls.Add(this.label8);
            this.groupBox6.Controls.Add(this.txtUploadUserName);
            this.groupBox6.Controls.Add(this.chkWorkflowUpload);
            this.groupBox6.Location = new System.Drawing.Point(0, 125);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(754, 114);
            this.groupBox6.TabIndex = 12;
            this.groupBox6.TabStop = false;
            // 
            // txtOutput
            // 
            this.txtOutput.Location = new System.Drawing.Point(457, 65);
            this.txtOutput.Name = "txtOutput";
            this.txtOutput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtOutput.Size = new System.Drawing.Size(287, 20);
            this.txtOutput.TabIndex = 6;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(157, 14);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(60, 13);
            this.label8.TabIndex = 5;
            this.label8.Text = "User Name";
            // 
            // txtUploadUserName
            // 
            this.txtUploadUserName.Location = new System.Drawing.Point(223, 11);
            this.txtUploadUserName.Name = "txtUploadUserName";
            this.txtUploadUserName.Size = new System.Drawing.Size(209, 20);
            this.txtUploadUserName.TabIndex = 4;
            // 
            // chkWorkflowUpload
            // 
            this.chkWorkflowUpload.AutoSize = true;
            this.chkWorkflowUpload.Location = new System.Drawing.Point(8, 11);
            this.chkWorkflowUpload.Name = "chkWorkflowUpload";
            this.chkWorkflowUpload.Size = new System.Drawing.Size(60, 17);
            this.chkWorkflowUpload.TabIndex = 3;
            this.chkWorkflowUpload.Text = "Upload";
            this.chkWorkflowUpload.UseVisualStyleBackColor = true;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.chkWorkflowOutput);
            this.groupBox5.Controls.Add(this.label7);
            this.groupBox5.Controls.Add(this.btnWorkflowFileName);
            this.groupBox5.Controls.Add(this.txtWorkflowOutputFilePath);
            this.groupBox5.Location = new System.Drawing.Point(0, 88);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(442, 34);
            this.groupBox5.TabIndex = 11;
            this.groupBox5.TabStop = false;
            // 
            // chkWorkflowOutput
            // 
            this.chkWorkflowOutput.AutoSize = true;
            this.chkWorkflowOutput.Location = new System.Drawing.Point(7, 11);
            this.chkWorkflowOutput.Name = "chkWorkflowOutput";
            this.chkWorkflowOutput.Size = new System.Drawing.Size(89, 17);
            this.chkWorkflowOutput.TabIndex = 13;
            this.chkWorkflowOutput.Text = "Output JSON";
            this.chkWorkflowOutput.UseVisualStyleBackColor = true;
            this.chkWorkflowOutput.CheckedChanged += new System.EventHandler(this.chkWorkflowOutput_CheckedChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(119, 13);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(54, 13);
            this.label7.TabIndex = 12;
            this.label7.Text = "File Name";
            // 
            // btnWorkflowFileName
            // 
            this.btnWorkflowFileName.Enabled = false;
            this.btnWorkflowFileName.Location = new System.Drawing.Point(407, 8);
            this.btnWorkflowFileName.Name = "btnWorkflowFileName";
            this.btnWorkflowFileName.Size = new System.Drawing.Size(25, 23);
            this.btnWorkflowFileName.TabIndex = 11;
            this.btnWorkflowFileName.Text = "...";
            this.btnWorkflowFileName.UseVisualStyleBackColor = true;
            this.btnWorkflowFileName.Click += new System.EventHandler(this.btnWorkflowFileName_Click);
            // 
            // txtWorkflowOutputFilePath
            // 
            this.txtWorkflowOutputFilePath.Enabled = false;
            this.txtWorkflowOutputFilePath.Location = new System.Drawing.Point(179, 10);
            this.txtWorkflowOutputFilePath.Name = "txtWorkflowOutputFilePath";
            this.txtWorkflowOutputFilePath.Size = new System.Drawing.Size(225, 20);
            this.txtWorkflowOutputFilePath.TabIndex = 10;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.chkWorkflowMapOverwrite);
            this.groupBox4.Controls.Add(this.chkWorkflowMap);
            this.groupBox4.Location = new System.Drawing.Point(0, 56);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(292, 34);
            this.groupBox4.TabIndex = 10;
            this.groupBox4.TabStop = false;
            // 
            // chkWorkflowMapOverwrite
            // 
            this.chkWorkflowMapOverwrite.AutoSize = true;
            this.chkWorkflowMapOverwrite.Enabled = false;
            this.chkWorkflowMapOverwrite.Location = new System.Drawing.Point(118, 13);
            this.chkWorkflowMapOverwrite.Name = "chkWorkflowMapOverwrite";
            this.chkWorkflowMapOverwrite.Size = new System.Drawing.Size(71, 17);
            this.chkWorkflowMapOverwrite.TabIndex = 5;
            this.chkWorkflowMapOverwrite.Text = "Overwrite";
            this.chkWorkflowMapOverwrite.UseVisualStyleBackColor = true;
            // 
            // chkWorkflowMap
            // 
            this.chkWorkflowMap.AutoSize = true;
            this.chkWorkflowMap.Location = new System.Drawing.Point(7, 12);
            this.chkWorkflowMap.Name = "chkWorkflowMap";
            this.chkWorkflowMap.Size = new System.Drawing.Size(70, 17);
            this.chkWorkflowMap.TabIndex = 4;
            this.chkWorkflowMap.Text = "Generate";
            this.chkWorkflowMap.UseVisualStyleBackColor = true;
            this.chkWorkflowMap.CheckedChanged += new System.EventHandler(this.chkWorkflowMap_CheckedChanged);
            // 
            // chkWorkflowValidation
            // 
            this.chkWorkflowValidation.AutoSize = true;
            this.chkWorkflowValidation.Location = new System.Drawing.Point(8, 33);
            this.chkWorkflowValidation.Name = "chkWorkflowValidation";
            this.chkWorkflowValidation.Size = new System.Drawing.Size(64, 17);
            this.chkWorkflowValidation.TabIndex = 8;
            this.chkWorkflowValidation.Text = "Validate";
            this.chkWorkflowValidation.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkWorkflowValidation.UseVisualStyleBackColor = true;
            this.chkWorkflowValidation.CheckedChanged += new System.EventHandler(this.chkWorkflowValidation_CheckedChanged);
            // 
            // chkWorkflowUploadOverwrite
            // 
            this.chkWorkflowUploadOverwrite.AutoSize = true;
            this.chkWorkflowUploadOverwrite.Location = new System.Drawing.Point(8, 335);
            this.chkWorkflowUploadOverwrite.Name = "chkWorkflowUploadOverwrite";
            this.chkWorkflowUploadOverwrite.Size = new System.Drawing.Size(71, 17);
            this.chkWorkflowUploadOverwrite.TabIndex = 4;
            this.chkWorkflowUploadOverwrite.Text = "Overwrite";
            this.chkWorkflowUploadOverwrite.UseVisualStyleBackColor = true;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(240, 515);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 6;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(330, 515);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(75, 23);
            this.btnEdit.TabIndex = 7;
            this.btnEdit.Text = "Edit";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btbDelete
            // 
            this.btbDelete.Location = new System.Drawing.Point(418, 515);
            this.btbDelete.Name = "btbDelete";
            this.btbDelete.Size = new System.Drawing.Size(75, 23);
            this.btbDelete.TabIndex = 8;
            this.btbDelete.Text = "Delete";
            this.btbDelete.UseVisualStyleBackColor = true;
            this.btbDelete.Click += new System.EventHandler(this.btbDelete_Click);
            // 
            // SourceType
            // 
            this.SourceType.HeaderText = "Source Type";
            this.SourceType.Name = "SourceType";
            this.SourceType.ReadOnly = true;
            // 
            // FileLocation
            // 
            this.FileLocation.HeaderText = "File Location";
            this.FileLocation.Name = "FileLocation";
            this.FileLocation.ReadOnly = true;
            // 
            // OverrideSourceDetails
            // 
            this.OverrideSourceDetails.HeaderText = "Override Source Details";
            this.OverrideSourceDetails.Name = "OverrideSourceDetails";
            this.OverrideSourceDetails.ReadOnly = true;
            // 
            // txtUploadPassword
            // 
            this.txtUploadPassword.Location = new System.Drawing.Point(224, 282);
            this.txtUploadPassword.Name = "txtUploadPassword";
            this.txtUploadPassword.Size = new System.Drawing.Size(209, 20);
            this.txtUploadPassword.TabIndex = 9;
            // 
            // txtUploadServer
            // 
            this.txtUploadServer.Location = new System.Drawing.Point(224, 309);
            this.txtUploadServer.Name = "txtUploadServer";
            this.txtUploadServer.Size = new System.Drawing.Size(209, 20);
            this.txtUploadServer.TabIndex = 10;
            // 
            // txtUploadBatchName
            // 
            this.txtUploadBatchName.Location = new System.Drawing.Point(224, 338);
            this.txtUploadBatchName.Name = "txtUploadBatchName";
            this.txtUploadBatchName.Size = new System.Drawing.Size(209, 20);
            this.txtUploadBatchName.TabIndex = 11;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(165, 285);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(53, 13);
            this.label11.TabIndex = 12;
            this.label11.Text = "Password";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(177, 312);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(38, 13);
            this.label12.TabIndex = 13;
            this.label12.Text = "Server";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(152, 341);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(66, 13);
            this.label13.TabIndex = 14;
            this.label13.Text = "Batch Name";
            // 
            // FormDataLoader
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(757, 637);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txtUploadBatchName);
            this.Controls.Add(this.txtUploadServer);
            this.Controls.Add(this.txtUploadPassword);
            this.Controls.Add(this.chkWorkflowUploadOverwrite);
            this.Controls.Add(this.btbDelete);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.dgApixioFiles);
            this.Controls.Add(this.groupBox1);
            this.HelpButton = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormDataLoader";
            this.Text = "Apixio Data Loader";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgApixioFiles)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker dateTimeSourceDate;
        private System.Windows.Forms.TextBox txtSourceType;
        private System.Windows.Forms.TextBox txtSourceSystem;
        private System.Windows.Forms.Button btnWorkingDirectory;
        private System.Windows.Forms.TextBox txtPrimaryAuthority;
        private System.Windows.Forms.TextBox txtDefaultAuthority;
        private System.Windows.Forms.TextBox txtWorkingDirectory;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox chkDebugMode;
        private System.Windows.Forms.Button btnRunDataLoader;
        private System.Windows.Forms.Button btnOpenDataLoaderFile;
        private System.Windows.Forms.TextBox txtDataLoaderFilePath;
        private System.Windows.Forms.Label label96;
        private System.Windows.Forms.Button btnSaveConfig;
        private System.Windows.Forms.Button btnOpenConfig;
        private System.Windows.Forms.Button btnOpenConfigFile;
        private System.Windows.Forms.TextBox txtConfigFilePath;
        private System.Windows.Forms.Label label95;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox chkWorkflowDeleteOnClose;
        private System.Windows.Forms.CheckBox chkWorkflowValidation;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.CheckBox chkWorkflowMapOverwrite;
        private System.Windows.Forms.CheckBox chkWorkflowMap;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.CheckBox chkWorkflowOutput;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnWorkflowFileName;
        private System.Windows.Forms.TextBox txtWorkflowOutputFilePath;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btbDelete;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.CheckBox chkWorkflowUploadOverwrite;
        private System.Windows.Forms.CheckBox chkWorkflowUpload;
        //private System.Windows.Forms.DataGridViewCheckBoxColumn Enabled;
        public System.Windows.Forms.DataGridView dgApixioFiles;
        //public System.Windows.Forms.DataGridViewCheckBoxColumn Enabled;
        public System.Windows.Forms.DataGridViewTextBoxColumn SourceType;
        public System.Windows.Forms.DataGridViewTextBoxColumn FileLocation;
        public System.Windows.Forms.DataGridViewTextBoxColumn OverrideSourceDetails;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtUploadUserName;
        private System.Windows.Forms.TextBox txtUploadPassword;
        private System.Windows.Forms.TextBox txtUploadServer;
        private System.Windows.Forms.TextBox txtUploadBatchName;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.DataGridViewTextBoxColumn FileType;
        private System.Windows.Forms.DataGridViewTextBoxColumn FilePath;
        private System.Windows.Forms.DataGridViewTextBoxColumn SourceOverride;
        private System.Windows.Forms.DataGridViewTextBoxColumn SkipHeader;
        private System.Windows.Forms.DataGridViewTextBoxColumn EditType;
        private System.Windows.Forms.TextBox txtOutput;
    }
}