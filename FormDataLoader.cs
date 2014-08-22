using System.Collections.Generic;
using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.IO;
using System.Diagnostics;

namespace ApixioDataLoaderConfigGenerator
{
    public partial class FormDataLoader : Form
    {
        private Boolean fileOpened = false;
        private string openFileName;
        Boolean _log_is_paused = false;
        public FormDataLoader()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            using (AddNewItem AddWindow = new AddNewItem())
            {
                if (AddWindow.ShowDialog() == DialogResult.OK)
                {
                    //System.Diagnostics.Debug.WriteLine("I got: " + "true" + " " + AddWindow.FileType + " " + AddWindow.Path + " " + AddWindow.EditType + " " + AddWindow.DefaultSource + " " + AddWindow.SkipHeader);
                    string[] row0 = { AddWindow.FileType, AddWindow.Path, AddWindow.DefaultSource, AddWindow.SkipHeader, AddWindow.EditType};
                    //this.dgApixioFiles.Rows.Add();
                    dgApixioFiles.Rows.Insert(dgApixioFiles.RowCount - 1, row0);
                    this.dgApixioFiles.Update();
                    AddWindow.Close();
                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            
            if (this.dgApixioFiles.SelectedRows.Count != 0)
            {

                string _fileType, _filePath, _editType, _skipHeader, _sourceOverride;
                int _selectedRow = dgApixioFiles.SelectedRows[0].Index;

                _fileType = dgApixioFiles.CurrentRow.Cells["FileType"].Value.ToString();
                _filePath = dgApixioFiles.CurrentRow.Cells["FilePath"].Value.ToString();
                _editType = dgApixioFiles.CurrentRow.Cells["EditType"].Value.ToString();
                _skipHeader = dgApixioFiles.CurrentRow.Cells["SkipHeader"].Value.ToString();
                _sourceOverride = dgApixioFiles.CurrentRow.Cells["SourceOverride"].Value.ToString();
                using (AddNewItem AddWindow = new AddNewItem(_fileType, _filePath, _editType, _skipHeader, _sourceOverride))
                {
                    System.Diagnostics.Debug.WriteLine("Sending: " + dgApixioFiles.CurrentRow.Cells["FileType"].Value.ToString() + ", " + dgApixioFiles.CurrentRow.Cells["FilePath"].Value.ToString() + ", " + dgApixioFiles.CurrentRow.Cells["EditType"].Value.ToString() + ", " + dgApixioFiles.CurrentRow.Cells["SkipHeader"].Value.ToString() + ", " + dgApixioFiles.CurrentRow.Cells["SourceOverride"].Value.ToString());
                    
                    if (AddWindow.ShowDialog() == DialogResult.OK)
                    {
                        //string[] row0 = { "true", AddWindow.FileType, AddWindow.Path, AddWindow.DefaultSource, AddWindow.SkipHeader, AddWindow.EditType };
                        //this.dgApixioFiles.Rows.Add();
                        dgApixioFiles.EditMode = DataGridViewEditMode.EditProgrammatically;
                        dgApixioFiles.Rows[_selectedRow].Cells[0].Value = AddWindow.FileType;
                        dgApixioFiles.Rows[_selectedRow].Cells[1].Value = AddWindow.Path;
                        dgApixioFiles.Rows[_selectedRow].Cells[2].Value = AddWindow.DefaultSource;
                        dgApixioFiles.Rows[_selectedRow].Cells[3].Value = AddWindow.SkipHeader;
                        dgApixioFiles.Rows[_selectedRow].Cells[4].Value = AddWindow.EditType;
                        dgApixioFiles.EndEdit();
                        //this.dgApixioFiles.Update();
                        AddWindow.Close();
                    }
                }
            }
        }

        private void btbDelete_Click(object sender, EventArgs e)
        {
            //must select a row first

            if (this.dgApixioFiles.SelectedRows.Count > 0 &&
               this.dgApixioFiles.SelectedRows[0].Index !=
               this.dgApixioFiles.Rows.Count - 1)
            {
                this.dgApixioFiles.Rows.RemoveAt(
                    this.dgApixioFiles.SelectedRows[0].Index);
            }
        }


        private void btnWorkingDirectory_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.FolderBrowserDialog folderBrowserDialogWorkingDirectory = new FolderBrowserDialog();
            System.Windows.Forms.OpenFileDialog openFileDialog1 = new OpenFileDialog();
            Boolean fileOpened = false;
            //string openFileName;
            string openFolder;

            folderBrowserDialogWorkingDirectory.ShowNewFolderButton = false;
            // Show the FolderBrowserDialog.
            DialogResult result = folderBrowserDialogWorkingDirectory.ShowDialog();
            if (result == DialogResult.OK)
            {
                openFolder = folderBrowserDialogWorkingDirectory.SelectedPath;
                if (!fileOpened)
                {
                    // No file is opened, bring up openFileDialog in selected path.
                    openFileDialog1.InitialDirectory = openFolder;
                    openFileDialog1.DefaultExt = "json";
                    openFileDialog1.Filter = "JSON (*.json)|*.json|All files (*.*)|*.*"; openFileDialog1.FileName = null;
                    txtWorkingDirectory.Text = openFolder;
                }
            }

        }

        private void chkWorkflowMap_CheckedChanged(object sender, EventArgs e)
        {
            if (chkWorkflowMap.Checked)
            {
                this.chkWorkflowMapOverwrite.Enabled = true;
            }
            else
            {
                this.chkWorkflowMapOverwrite.Enabled = false;
            }
        }

        private void chkWorkflowOutput_CheckedChanged(object sender, EventArgs e)
        {
            if (chkWorkflowOutput.Checked)
            {
                this.txtWorkflowOutputFilePath.Enabled = true;
                this.btnWorkflowFileName.Enabled = true;
            }
            else
            {
                this.txtWorkflowOutputFilePath.Enabled = false;
                this.btnWorkflowFileName.Enabled = false;
            }
        }

        private void chkWorkflowValidation_CheckedChanged(object sender, EventArgs e)
        {
            if (chkWorkflowValidation.Checked)
            {
                chkWorkflowMap.Enabled = false;
                chkWorkflowMapOverwrite.Enabled = false;
                chkWorkflowOutput.Enabled = false;
                chkWorkflowUpload.Enabled = false;
                chkWorkflowUploadOverwrite.Enabled = false;

                txtUploadUserName.Enabled = false;
                txtUploadPassword.Enabled = false;
                txtUploadServer.Enabled = false;
                txtUploadBatchName.Enabled = false;
            }
            else
            {
                chkWorkflowMap.Enabled = true;
                chkWorkflowMapOverwrite.Enabled = true;
                chkWorkflowOutput.Enabled = true;
                chkWorkflowUpload.Enabled = true;
                chkWorkflowUploadOverwrite.Enabled = true;

                txtUploadUserName.Enabled = true;
                txtUploadPassword.Enabled = true;
                txtUploadServer.Enabled = true;
                txtUploadBatchName.Enabled = true;

            }

        }

        private StringBuilder BuilXMLFromGrid(DataGridViewRow row)
        {
            StringBuilder sOutput = new StringBuilder();
            try
            {
                sOutput.Append("<path>").Append(row.Cells["FilePath"].Value.ToString()).Append("</path>").Append("\n");
                if (row.Cells["SourceOverride"].Value.ToString() == "Use Defalt")
                {
                    sOutput.Append("<sourceSystem>").Append(txtSourceSystem.Text).Append("</sourceSystem>").Append("\n");
                    sOutput.Append("<sourceType>").Append(txtSourceType.Text).Append("</sourceType>").Append("\n");
                    sOutput.Append("<sourceDate>").Append(dateTimeSourceDate.Text).Append("</sourceDate>").Append("\n");
                }
                else
                {
                    string[] notDefault = row.Cells["SourceOverride"].Value.ToString().Split(',');
                    sOutput.Append("<sourceSystem>").Append(notDefault[0]).Append("</sourceSystem>").Append("\n");
                    sOutput.Append("<sourceType>").Append(notDefault[1]).Append("</sourceType>").Append("\n");
                    sOutput.Append("<sourceDate>").Append(notDefault[2]).Append("</sourceDate>").Append("\n");
                }
                if (row.Cells["SkipHeader"].Value.ToString() == "Skip Header")
                    sOutput.Append("<linesToSkip>1</linesToSkip>").Append("\n");
                else
                    sOutput.Append("<linesToSkip>0</linesToSkip>").Append("\n");
                sOutput.Append("<editType>").Append(row.Cells["EditType"].Value.ToString()).Append("</editType>").Append("\n");

                return sOutput;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Cannot build XML from Grid. The error is: " + ex.Message);
                return sOutput;
            }

        }
        private void SaveConfigXML(string fileName)
        {
            StringBuilder sOutput = new StringBuilder();
            try
            {
                sOutput.Append("<?xml version=\"1.0\" encoding=\"UTF-8\"?>").Append("\n").Append("<application>").Append("\n");

                sOutput.Append("<workingDir>").Append(this.txtWorkingDirectory.Text).Append("</workingDir>").Append("\n");
                sOutput.Append("<defaultAuthority>").Append(this.txtDefaultAuthority.Text).Append("</defaultAuthority>").Append("\n");
                sOutput.Append("<primaryAuthority>").Append(txtPrimaryAuthority.Text).Append("</primaryAuthority>").Append("\n");

                sOutput.Append("<sourceSystem>").Append(this.txtSourceSystem.Text).Append("</sourceSystem>").Append("\n");
                sOutput.Append("<sourceType>").Append(this.txtSourceType.Text).Append("</sourceType>").Append("\n");
                sOutput.Append("<sourceDate>").Append(dateTimeSourceDate.Text).Append("</sourceDate>").Append("\n");

                sOutput.Append("<workflow>").Append("\n");

                if (this.chkWorkflowDeleteOnClose.Checked)
                    sOutput.Append("<deleteOnClose>").Append("true").Append("</deleteOnClose>").Append("\n");
                else
                    sOutput.Append("<deleteOnClose>").Append("false").Append("</deleteOnClose>").Append("\n");

                sOutput.Append("<validation>").Append("\n");
                if ((this.chkWorkflowValidation.Enabled) && (this.chkWorkflowValidation.Checked))
                    sOutput.Append("<enabled>").Append("true").Append("</enabled>").Append("\n");
                else
                    sOutput.Append("<enabled>").Append("false").Append("</enabled>").Append("\n");
                sOutput.Append("</validation>").Append("\n");

                sOutput.Append("<map>").Append("\n");
                if ((this.chkWorkflowMap.Enabled) && (this.chkWorkflowMap.Checked))
                    sOutput.Append("<enabled>").Append("true").Append("</enabled>").Append("\n");
                else
                    sOutput.Append("<enabled>").Append("false").Append("</enabled>").Append("\n");
                if ((this.chkWorkflowMapOverwrite.Enabled) && (this.chkWorkflowMapOverwrite.Checked))
                    sOutput.Append("<overwrite>").Append("true").Append("</overwrite>").Append("\n");
                else
                    sOutput.Append("<overwrite>").Append("false").Append("</overwrite>").Append("\n");
                sOutput.Append("</map>").Append("\n");

                sOutput.Append("<reduce>").Append("\n");
                if ((this.chkWorkflowMap.Enabled) && (this.chkWorkflowMap.Checked))
                    sOutput.Append("<enabled>").Append("true").Append("</enabled>").Append("\n");
                else
                    sOutput.Append("<enabled>").Append("false").Append("</enabled>").Append("\n");
                if ((this.chkWorkflowMapOverwrite.Enabled) && (this.chkWorkflowMapOverwrite.Checked))
                    sOutput.Append("<overwrite>").Append("true").Append("</overwrite>").Append("\n");
                else
                    sOutput.Append("<overwrite>").Append("false").Append("</overwrite>").Append("\n");
                sOutput.Append("</reduce>").Append("\n");

                sOutput.Append("<output>").Append("\n");
                if ((this.chkWorkflowOutput.Enabled) && (this.chkWorkflowOutput.Checked))
                    sOutput.Append("<enabled>").Append("true").Append("</enabled>").Append("\n");
                else
                    sOutput.Append("<enabled>").Append("false").Append("</enabled>").Append("\n");
                sOutput.Append("<path>").Append(txtWorkflowOutputFilePath.Text).Append("</path>").Append("\n");
                sOutput.Append("</output>").Append("\n");

                sOutput.Append("<upload>").Append("\n");
                if ((this.chkWorkflowUpload.Enabled) && (this.chkWorkflowUpload.Checked))
                    sOutput.Append("<enabled>").Append("true").Append("</enabled>").Append("\n");
                else
                    sOutput.Append("<enabled>").Append("false").Append("</enabled>").Append("\n");
                if (this.chkWorkflowUploadOverwrite.Checked)
                    sOutput.Append("<overwrite>").Append("true").Append("</overwrite>").Append("\n");
                else
                    sOutput.Append("<overwrite>").Append("false").Append("</overwrite>").Append("\n");
                sOutput.Append("</upload>").Append("\n");
                sOutput.Append("</workflow>").Append("\n");

                //sOutput.Append("<codingSystems>").Append("\n");
                //sOutput.Append("<CPTLabel>").Append(txtCodingSystemCPTLabel.Text).Append("</CPTLabel>").Append("\n");
                //sOutput.Append("<ICD9DXLabel>").Append(txtCodingSystemICD9DX.Text).Append("</ICD9DXLabel>").Append("\n");
                //sOutput.Append("<ICD9SGLabel>").Append(txtCodingSystemICD9SG.Text).Append("</ICD9SGLabel>").Append("\n");
                //sOutput.Append("</codingSystems>").Append("\n");

                //sOutput.Append("<security>").Append("\n");
                //sOutput.Append("<key>").Append(txtSecurityKey.Text).Append("</key>").Append("\n");
                //sOutput.Append("<algorithm>").Append(txtSecurityAlgorithm.Text).Append("</algorithm>").Append("\n");
                //sOutput.Append("</security>").Append("\n");

                sOutput.Append("<endpoint>").Append("\n");
                sOutput.Append("<server>").Append(txtUploadServer.Text).Append("</server>").Append("\n");
                sOutput.Append("<batchName>").Append(txtUploadBatchName.Text).Append("</batchName>").Append("\n");
                sOutput.Append("<username>").Append(txtUploadUserName.Text).Append("</username>").Append("\n");
                sOutput.Append("<password>").Append(txtUploadPassword.Text).Append("</password>").Append("\n");
                sOutput.Append("</endpoint>").Append("\n");


                foreach (DataGridViewRow row in dgApixioFiles.Rows)
                {
                    if (row.Index < dgApixioFiles.Rows.Count - 1)
                    {
                        switch (row.Cells["FileType"].Value.ToString())
                        {
                            case "Coverage":
                                sOutput.Append("<coverage>").Append("\n");
                                sOutput.Append(BuilXMLFromGrid(row));
                                sOutput.Append("</coverage>").Append("\n");
                                break;
                            case "Crosswalk":
                                sOutput.Append("<crosswalk>").Append("\n");
                                sOutput.Append(BuilXMLFromGrid(row));
                                sOutput.Append("</crosswalk>").Append("\n");
                                break;
                            case "Demographics":
                                sOutput.Append("<demographics>").Append("\n");
                                sOutput.Append(BuilXMLFromGrid(row));
                                sOutput.Append("</demographics>").Append("\n");
                                break;
                            case "Documents":
                                sOutput.Append("<documents>").Append("\n");
                                sOutput.Append(BuilXMLFromGrid(row));
                                sOutput.Append("</documents>").Append("\n");
                                break;
                            case "Encounters":
                                sOutput.Append("<encounters>").Append("\n");
                                sOutput.Append(BuilXMLFromGrid(row));
                                sOutput.Append("</encounters>").Append("\n");
                                break;
                            case "Events":
                                sOutput.Append("<events>").Append("\n");
                                sOutput.Append(BuilXMLFromGrid(row));
                                sOutput.Append("</events>").Append("\n");
                                break;
                            case "Problems":
                                sOutput.Append("<problems>").Append("\n");
                                sOutput.Append(BuilXMLFromGrid(row));
                                sOutput.Append("</problems>").Append("\n");
                                break;
                            case "MORA":
                                sOutput.Append("<problemsmora>").Append("\n");
                                sOutput.Append(BuilXMLFromGrid(row));
                                sOutput.Append("</problemsmora>").Append("\n");
                                break;
                            case "MORB":
                                sOutput.Append("<problemsmorb>").Append("\n");
                                sOutput.Append(BuilXMLFromGrid(row));
                                sOutput.Append("</problemsmorb>").Append("\n");
                                break;
                            case "MORC":
                                sOutput.Append("<problemsmorc>").Append("\n");
                                sOutput.Append(BuilXMLFromGrid(row));
                                sOutput.Append("</problemsmorc>").Append("\n");
                                break;
                            case "RAPS":
                                sOutput.Append("<problemsraps>").Append("\n");
                                sOutput.Append(BuilXMLFromGrid(row));
                                sOutput.Append("</problemsraps>").Append("\n");
                                break;
                            case "Procedures":
                                sOutput.Append("<procedures>").Append("\n");
                                sOutput.Append(BuilXMLFromGrid(row));
                                sOutput.Append("</procedures>").Append("\n");
                                break;
                            case "Providers":
                                sOutput.Append("<providers>").Append("\n");
                                sOutput.Append(BuilXMLFromGrid(row));
                                sOutput.Append("</providers>").Append("\n");
                                break;
                            default:
                                break;
                        }
                    }

                }

                sOutput.Append("</application>").Append("\n");

                // write out
                using (StreamWriter w = File.CreateText(fileName))
                //using (StreamWriter w = File.CreateText("C:\\Temp\\Text.xml"))
                {
                    w.WriteLine(sOutput.ToString().Replace("\\", "/"));
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Error saving config file. The error is: " + ex.Message);
            }
        }

        private void btnOpenConfigFile_Click(object sender, EventArgs e)
        {

            System.Windows.Forms.OpenFileDialog openFileDialog1 = new OpenFileDialog();
            System.Windows.Forms.FolderBrowserDialog folderBrowserDialogWorkingDirectory = new FolderBrowserDialog();

            if (!fileOpened)
            {
                openFileDialog1.InitialDirectory = folderBrowserDialogWorkingDirectory.SelectedPath;
                openFileDialog1.DefaultExt = "XML";
                openFileDialog1.Filter = "XML files (*.XML)|*.XML|All files (*.*)|*.*";
                openFileDialog1.FileName = null;
            }


            folderBrowserDialogWorkingDirectory.ShowNewFolderButton = false;
            DialogResult _result = openFileDialog1.ShowDialog();
            if (_result == DialogResult.OK)
            {
                ResetComponent();

                openFileName = openFileDialog1.FileName;
                txtConfigFilePath.Text = openFileName;

                LoadConfigFileWorkflow(openFileName);
                LoadConfigFileCodingSecurityEndPoint(openFileName);
                LoadConfigFileAPO(openFileName);

                //check if both config and loader files are referenced
                if ((txtConfigFilePath.Text != "") && (txtDataLoaderFilePath.Text != ""))
                    btnRunDataLoader.Enabled = true;
                else
                    btnRunDataLoader.Enabled = false;

            }            
        }

        private void btnWorkflowFileName_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.OpenFileDialog openFileDialog1 = new OpenFileDialog();
            System.Windows.Forms.FolderBrowserDialog folderBrowserDialogWorkingDirectory = new FolderBrowserDialog();

            if (!fileOpened)
            {
                openFileDialog1.InitialDirectory = folderBrowserDialogWorkingDirectory.SelectedPath;
                openFileDialog1.DefaultExt = "JSON";
                openFileDialog1.Filter = "JSON files (*.JSON)|*.JSON|All files (*.*)|*.*";
                openFileDialog1.FileName = null;
            }


            folderBrowserDialogWorkingDirectory.ShowNewFolderButton = false;
            DialogResult _result = openFileDialog1.ShowDialog();
            if (_result == DialogResult.OK)
            {
                openFileName = openFileDialog1.FileName;
                txtWorkflowOutputFilePath.Text = openFileName;
            }

        }

        private void btnOpenDataLoaderFile_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.OpenFileDialog openFileDialog1 = new OpenFileDialog();
            System.Windows.Forms.FolderBrowserDialog folderBrowserDialogWorkingDirectory = new FolderBrowserDialog();

            if (!fileOpened)
            {
                openFileDialog1.InitialDirectory = folderBrowserDialogWorkingDirectory.SelectedPath;
                openFileDialog1.DefaultExt = "JAR";
                openFileDialog1.Filter = "JAR files (*.JAR)|*.JAR|All files (*.*)|*.*";
                openFileDialog1.FileName = null;
            }


            folderBrowserDialogWorkingDirectory.ShowNewFolderButton = false;
            DialogResult _result = openFileDialog1.ShowDialog();
            if (_result == DialogResult.OK)
            {
                openFileName = openFileDialog1.FileName;
                txtDataLoaderFilePath.Text = openFileName;
                //check if both config and loader files are referenced
                if ((txtConfigFilePath.Text != "") && (txtDataLoaderFilePath.Text != ""))
                    btnRunDataLoader.Enabled = true;
                else
                    btnRunDataLoader.Enabled = false;

            }     
        }

        private void LoadConfigFileWorkflow(string thisXMLFile)
        {
            try
            {
                XmlDocument _xmlFile = new XmlDocument();
                _xmlFile.Load(thisXMLFile);
                foreach (XmlNode node in _xmlFile.DocumentElement.ChildNodes)
                {
                    //Debug.WriteLine(node.Name);
                    switch (node.Name)
                    {
                        case "workingDir":
                            txtWorkingDirectory.Text = node.InnerText.Replace("/", "\\");
                            break;
                        case "defaultAuthority":
                            txtDefaultAuthority.Text = node.InnerText;
                            break;
                        case "primaryAuthority":
                            txtPrimaryAuthority.Text = node.InnerText;
                            break;
                        case "sourceSystem":
                            txtSourceSystem.Text = node.InnerText;
                            break;
                        case "sourceType":
                            txtSourceType.Text = node.InnerText;
                            break;
                        case "sourceDate":
                            dateTimeSourceDate.Text = node.InnerText;
                            break;
                        case "workflow":
                            foreach (XmlNode innerNodes in node)
                            {
                                switch (innerNodes.Name)
                                {
                                    case "deleteOnClose":
                                        if (innerNodes.InnerText.Equals("true"))
                                            chkWorkflowDeleteOnClose.Checked = true;
                                        else
                                            chkWorkflowDeleteOnClose.Checked = false;
                                        break;
                                    case "validation":
                                        XmlNode level3 = innerNodes.ChildNodes.Item(0);
                                        if (level3.InnerText.Equals("true"))
                                            chkWorkflowValidation.Checked = true;
                                        else
                                            chkWorkflowValidation.Checked = false;
                                        break;
                                    case "map":
                                        foreach (XmlNode level3Node in innerNodes)
                                        {
                                            if (level3Node.Name.Equals("enabled"))
                                            {
                                                if (level3Node.InnerText.Equals("true"))
                                                    chkWorkflowMap.Checked = true;
                                                else
                                                    chkWorkflowMap.Checked = false;
                                            }
                                            if (level3Node.Name.Equals("overwrite"))
                                            {
                                                if (level3Node.InnerText.Equals("true"))
                                                    chkWorkflowMapOverwrite.Checked = true;
                                                else
                                                    chkWorkflowMapOverwrite.Checked = false;
                                            }

                                        }
                                        break;
                                    //case "reduce":
                                    //    foreach (XmlNode level3Node in innerNodes)
                                    //    {
                                    //        if (level3Node.Name.Equals("enabled"))
                                    //        {
                                    //            if (level3Node.InnerText.Equals("true"))
                                    //                chkWorkflowReduce.Checked = true;
                                    //            else
                                    //                chkWorkflowReduce.Checked = false;
                                    //        }
                                    //        if (level3Node.Name.Equals("overwrite"))
                                    //        {
                                    //            if (level3Node.InnerText.Equals("true"))
                                    //                chkWorkflowReduceOverwrite.Checked = true;
                                    //            else
                                    //                chkWorkflowReduceOverwrite.Checked = false;
                                    //        }

                                    //    }
                                    //    break;
                                    case "output":
                                        foreach (XmlNode level3Node in innerNodes)
                                        {
                                            if (level3Node.Name.Equals("enabled"))
                                            {
                                                if (level3Node.InnerText.Equals("true"))
                                                    chkWorkflowOutput.Checked = true;
                                                else
                                                    chkWorkflowOutput.Checked = false;
                                            }
                                            if (level3Node.Name.Equals("path"))
                                                txtWorkflowOutputFilePath.Text = level3Node.InnerText.Replace("/", "\\");

                                        }
                                        break;
                                    case "upload":
                                        foreach (XmlNode level3Node in innerNodes)
                                        {
                                            if (level3Node.Name.Equals("enabled"))
                                            {
                                                if (level3Node.InnerText.Equals("true"))
                                                    chkWorkflowUpload.Checked = true;
                                                else
                                                    chkWorkflowUpload.Checked = false;
                                            }
                                            if (level3Node.Name.Equals("overwrite"))
                                            {
                                                if (level3Node.InnerText.Equals("true"))
                                                    chkWorkflowUploadOverwrite.Checked = true;
                                                else
                                                    chkWorkflowUploadOverwrite.Checked = false;
                                            }

                                        }
                                        break;

                                }
                            }
                            break;

                    }

                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Error Loading XML file: " + thisXMLFile + ". The error is: " + ex.Message);
            }
        }
        
        private void LoadConfigFileCodingSecurityEndPoint(string thisXMLFile)
        {
            try
            {
                XmlDocument _xmlFile = new XmlDocument();
                _xmlFile.Load(thisXMLFile);
                foreach (XmlNode node in _xmlFile.DocumentElement.ChildNodes)
                {
                    //Debug.WriteLine(node.Name);
                    switch (node.Name)
                    {
                        //case "codingSystems":
                        //    foreach (XmlNode innerNodes in node)
                        //    {
                        //        switch (innerNodes.Name)
                        //        {
                        //            case "CPTLabel":
                        //                txtCodingSystemCPTLabel.Text = innerNodes.InnerText;
                        //                break;
                        //            case "ICD9DXLabel":
                        //                txtCodingSystemICD9DX.Text = innerNodes.InnerText;
                        //                break;
                        //            case "ICD9SGLabel":
                        //                txtCodingSystemICD9SG.Text = innerNodes.InnerText;
                        //                break;
                        //        }
                        //    }
                        //    break;
                        //case "security":
                        //    foreach (XmlNode innerNodes in node)
                        //    {
                        //        switch (innerNodes.Name)
                        //        {
                        //            case "key":
                        //                txtSecurityKey.Text = innerNodes.InnerText;
                        //                break;
                        //            case "algorithm":
                        //                txtSecurityAlgorithm.Text = innerNodes.InnerText;
                        //                break;
                        //        }
                        //    }
                        //    break;
                        case "endpoint":
                            foreach (XmlNode innerNodes in node)
                            {
                                switch (innerNodes.Name)
                                {
                                    case "server":
                                        txtUploadServer.Text = innerNodes.InnerText;
                                        break;
                                    case "batchName":
                                        txtUploadBatchName.Text = innerNodes.InnerText;
                                        break;
                                    case "username":
                                        txtUploadUserName.Text = innerNodes.InnerText;
                                        break;
                                    case "password":
                                        txtUploadPassword.Text = innerNodes.InnerText;
                                        break;
                                }
                            }
                            break;

                    }

                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Error Loading XML file: " + thisXMLFile + ". The error is: " + ex.Message);
            }
        }
       
        private void LoadConfigFileAPO(string thisXMLFile)
        {
            ///string[] row0 = { AddWindow.FileType, AddWindow.Path, AddWindow.DefaultSource, AddWindow.EditType, AddWindow.SkipHeader };
            ///dgApixioFiles.Rows.Insert(dgApixioFiles.RowCount - 1, row0);
            ///this.dgApixioFiles.Update();
            ///
            List<string> thisList = new List<string>();
            string[] row0;


            try
            {
                XmlDocument _xmlFile = new XmlDocument();
                _xmlFile.Load(thisXMLFile);
                foreach (XmlNode node in _xmlFile.DocumentElement.ChildNodes)
                {
                    //Debug.WriteLine(node.Name);
                    switch (node.Name)
                    {
                        case "coverage":
                            thisList.Add("Coverage");
                            thisList.AddRange(ConfigFileAPO(node));
                            row0 = thisList.ToArray();
                            dgApixioFiles.Rows.Insert(dgApixioFiles.RowCount - 1, row0);
                            this.dgApixioFiles.Update();
                            thisList.Clear();
                            break;
                        case "crosswalk":
                            thisList.Add("Crosswalk");
                            thisList.AddRange(ConfigFileAPO(node));
                            row0 = thisList.ToArray();
                            dgApixioFiles.Rows.Insert(dgApixioFiles.RowCount - 1, row0);
                            this.dgApixioFiles.Update();
                            thisList.Clear();
                            break;
                        case "demographics":
                            thisList.Add("Demographics");
                            thisList.AddRange(ConfigFileAPO(node));
                            row0 = thisList.ToArray();
                            dgApixioFiles.Rows.Insert(dgApixioFiles.RowCount - 1, row0);
                            this.dgApixioFiles.Update();
                            thisList.Clear();
                            break;
                        case "documents":
                            thisList.Add("Documents");
                            thisList.AddRange(ConfigFileAPO(node));
                            row0 = thisList.ToArray();
                            dgApixioFiles.Rows.Insert(dgApixioFiles.RowCount - 1, row0);
                            this.dgApixioFiles.Update();
                            thisList.Clear();
                            break;
                        case "encounters":
                            thisList.Add("Encounters");
                            thisList.AddRange(ConfigFileAPO(node));
                            row0 = thisList.ToArray();
                            dgApixioFiles.Rows.Insert(dgApixioFiles.RowCount - 1, row0);
                            this.dgApixioFiles.Update();
                            thisList.Clear();
                            break;
                        case "events":
                            thisList.Add("Events");
                            thisList.AddRange(ConfigFileAPO(node));
                            row0 = thisList.ToArray();
                            dgApixioFiles.Rows.Insert(dgApixioFiles.RowCount - 1, row0);
                            this.dgApixioFiles.Update();
                            thisList.Clear();
                            break;
                        case "problems":
                            thisList.Add("Problems");
                            thisList.AddRange(ConfigFileAPO(node));
                            row0 = thisList.ToArray();
                            dgApixioFiles.Rows.Insert(dgApixioFiles.RowCount - 1, row0);
                            this.dgApixioFiles.Update();
                            thisList.Clear();
                            break;
                        case "problemsmora":
                            thisList.Add("MORA");
                            thisList.AddRange(ConfigFileAPO(node));
                            row0 = thisList.ToArray();
                            dgApixioFiles.Rows.Insert(dgApixioFiles.RowCount - 1, row0);
                            this.dgApixioFiles.Update();
                            thisList.Clear();
                            break;
                        case "problemsmorb":
                            thisList.Add("MORB");
                            thisList.AddRange(ConfigFileAPO(node));
                            row0 = thisList.ToArray();
                            dgApixioFiles.Rows.Insert(dgApixioFiles.RowCount - 1, row0);
                            this.dgApixioFiles.Update();
                            thisList.Clear();
                            break;
                        case "problemsmorc":
                            thisList.Add("MORC");
                            thisList.AddRange(ConfigFileAPO(node));
                            row0 = thisList.ToArray();
                            dgApixioFiles.Rows.Insert(dgApixioFiles.RowCount - 1, row0);
                            this.dgApixioFiles.Update();
                            thisList.Clear();
                            break;
                        case "problemsraps":
                            thisList.Add("RAPS");
                            thisList.AddRange(ConfigFileAPO(node));
                            row0 = thisList.ToArray();
                            dgApixioFiles.Rows.Insert(dgApixioFiles.RowCount - 1, row0);
                            this.dgApixioFiles.Update();
                            thisList.Clear();
                            break;
                        case "procedures":
                            thisList.Add("Procedures");
                            thisList.AddRange(ConfigFileAPO(node));
                            row0 = thisList.ToArray();
                            dgApixioFiles.Rows.Insert(dgApixioFiles.RowCount - 1, row0);
                            this.dgApixioFiles.Update();
                            thisList.Clear();
                            break;
                        case "providers":
                            thisList.Add("Providers");
                            thisList.AddRange(ConfigFileAPO(node));
                            row0 = thisList.ToArray();
                            dgApixioFiles.Rows.Insert(dgApixioFiles.RowCount - 1, row0);
                            this.dgApixioFiles.Update();
                            thisList.Clear();
                            break;
                    }

                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Error Loading XML file: " + thisXMLFile + ". The error is: " + ex.Message);
            }
        }

        private List<string> ConfigFileAPO(XmlNode outerNode)
        {
            List<string> thisList = new List<string>();
            int useDefaultCount = 0;
            string saveSource = "";

            try
            {
                //Debug.WriteLine(node.Name);
                foreach (XmlNode innerNodes in outerNode)
                {
                    switch (innerNodes.Name)
                    {
                        case "path":
                            thisList.Add(innerNodes.InnerText.Replace("/", "\\"));
                            break;

                        case "sourceSystem":
                            saveSource = innerNodes.InnerText;
                            if (saveSource == txtSourceSystem.Text)
                                useDefaultCount++;
                            break;
                        case "sourceType":
                            saveSource += "," + innerNodes.InnerText;
                            if (saveSource == txtSourceType.Text)
                                useDefaultCount++;
                            break;
                        case "sourceDate":
                            saveSource += "," + innerNodes.InnerText;
                            if (saveSource == dateTimeSourceDate.Text)
                                useDefaultCount++;

                            if (useDefaultCount == 3)
                                thisList.Add("Use Default");
                            else
                                thisList.Add(saveSource);
                            break;

                        case "linesToSkip":
                            if (innerNodes.InnerText == "1")
                                thisList.Add("Skip Header");
                            else
                                thisList.Add("No Header Skip");
                            break;
                        case "editType":
                            thisList.Add(innerNodes.InnerText);
                            break;
                        default:
                            break;
                    }
                }
                useDefaultCount = 0;
                saveSource = "";
                return thisList;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Error Constructing XML file. The error is: " + ex.Message);
                return thisList;
            }
        }

        private void ResetComponent()
        {
            try
            {

            this.dateTimeSourceDate.Text = DateTime.Today.ToString(); 
            this.txtSourceType.Text = "";
            this.txtSourceSystem.Text = "";
            this.txtPrimaryAuthority.Text = "";
            this.txtDefaultAuthority.Text = "";
            this.txtWorkingDirectory.Text = "";
            this.dgApixioFiles.Rows.Clear();
            this.chkDebugMode.Checked = false;
            this.txtDataLoaderFilePath.Text = "";
            this.chkWorkflowDeleteOnClose.Checked = false;
            this.txtConfigFilePath.Text = "";
            this.txtUploadUserName.Text = "";
            this.chkWorkflowUpload.Checked = false;
            this.chkWorkflowOutput.Checked = false;
            this.txtWorkflowOutputFilePath.Text = "";
            this.chkWorkflowMapOverwrite.Checked = false;
            this.chkWorkflowMap.Checked = false;
            this.chkWorkflowValidation.Checked = false;
            this.chkWorkflowUploadOverwrite.Checked = false;
            this.txtUploadPassword.Text = "";
            this.txtUploadServer.Text = "";
            this.txtUploadBatchName.Text = "";
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Error reseting controls. The error is:" + ex.Message);
            }
        }

        public void ControlSetFocus(Control control)
        {
            // Set focus to the control, if it can receive focus. 
            if (control.CanFocus)
            {
                control.Focus();
            }
        }
        private void btnOpenConfig_Click(object sender, EventArgs e)
        {
            btnOpenConfigFile_Click(sender, e);
        }

        private void btnSaveConfig_Click(object sender, EventArgs e)
        {
            //if there are working dicrectory or a file in the config path, show error
            if ((txtWorkingDirectory.Text == "") && (txtConfigFilePath.Text == ""))
            {
                if (MessageBox.Show("Please select an Existing config file or Enter a working forlder to create a new one", "Warning", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
                {
                    ControlSetFocus(txtWorkingDirectory);
                }
            }
            else
            {
                if (txtConfigFilePath.Text != "")
                {
                    SaveConfigXML(txtConfigFilePath.Text);
                }
                else
                { 
                    SaveConfigXML(txtWorkingDirectory.Text + "\\config.xml");   
                }
            }
        }

        private void btnRunDataLoader_Click(object sender, EventArgs e)
        {
            StringBuilder sCommand = new StringBuilder();
            Process pProcess = new Process();
            string fileToCheck;
            string consoleOutputPath = "";
            try
            {
                //path to read the file for output to UI
                consoleOutputPath = txtDataLoaderFilePath.Text;
                consoleOutputPath = consoleOutputPath.Substring(0, consoleOutputPath.LastIndexOf('\\')); 

                
                //save first
                SaveConfigXML(txtConfigFilePath.Text);

                string sWorkingDir = txtWorkingDirectory.Text;
                sWorkingDir = sWorkingDir.Replace("\\", "/");
                sCommand.Append("java -XX:MaxPermSize=1g -Xmx32g -Dconfig=").Append(txtConfigFilePath.Text);
                if (chkDebugMode.Checked)
                    sCommand.Append(" -DworkingDir=").Append(sWorkingDir);
                sCommand.Append(" -cp \".;").Append(txtDataLoaderFilePath.Text).Append("\" com.apixio.loader.PatientLoader");
                sCommand.ToString().Replace("\\", "/");
                sCommand.Append(" > \"").Append(consoleOutputPath).Append("\\logs\\Output.log\"");
                Debug.WriteLine(sCommand.ToString());

                File.WriteAllText(txtWorkingDirectory.Text+"\\RunThis.bat", sCommand.ToString());

                pProcess.StartInfo.FileName = txtWorkingDirectory.Text + "\\RunThis.bat";
                //pProcess.StartInfo.
                pProcess.StartInfo.CreateNoWindow = false;
                pProcess.StartInfo.WindowStyle = ProcessWindowStyle.Normal;
                pProcess.Start();

                _log_is_paused = false;
                txtOutput.Text = "";

                
                //if (chkWorkflowValidation.Checked)
                //    fileToCheck = "console.log";
                //else
                //{
                    fileToCheck = "Output.log";
                //}
                var asnycResult = MonitorFile(consoleOutputPath + "\\logs\\" + fileToCheck);

                //sOutput = pProcess.StandardOutput.ReadToEnd();
                //Wait for process to finish
                pProcess.WaitForExit();

                _log_is_paused = true;
                //txtOutput.AppendText(asnycResult.Result);

                //pProcess.Close();
            }
            catch (Exception EX)
            {
                Debug.WriteLine("Error running data loader. The error is: " + EX.Message);
            }
        }

        private async Task<string> MonitorFile(string fileName)
        {
            try
            {


                string time_stamp = "";
                string asyncResult;

                FileStream _log_stream = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);


                StreamReader _stream_reader = new StreamReader(_log_stream);


                time_stamp = DateTime.Now.ToString();


                txtOutput.AppendText("\r\nBegin Log Capture @ " + time_stamp + "\r\n\r\n");

                while (_log_is_paused == false)
                {
                    txtOutput.AppendText(_stream_reader.ReadToEnd());
                    txtOutput.ScrollToCaret();
                    await Task.Delay(50);
                }


                time_stamp = DateTime.Now.ToString();


                txtOutput.AppendText("\r\n\r\nEnd Log Capture @ " + time_stamp + "\r\n");
                asyncResult = "Process Done";
                return asyncResult;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error Running MonitorFIle. The error is: " + ex.Message);
                return "Error";
            }

        }
    }

}
