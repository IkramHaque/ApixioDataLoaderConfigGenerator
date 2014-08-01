using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using ApixioDataLoaderConfigGenerator;
using System.Xml;
using System.Diagnostics;

namespace ApixioDataLoaderConfigGenerator
{
    public partial class FormMain : Form
    {
        private Boolean fileOpened = false;
        private string openFileName;
        private string openFolder;

        public FormMain()
        {
            InitializeComponent();
        }

        private void btnOpenConfigFile_Click(object sender, EventArgs e)
        {
            //reset all controls
            Initialize();
            // If a file is not opened, then set the initial directory to the 
            // FolderBrowserDialog.SelectedPath value. 
            if (!fileOpened) 
            {
                openFileDialog1.InitialDirectory = folderBrowserDialogWorkingDirectory.SelectedPath;
                openFileDialog1.FileName = null;
            }


            this.folderBrowserDialogWorkingDirectory.ShowNewFolderButton = false;
            DialogResult _result =  this.openFileDialog1.ShowDialog();
            if (_result == DialogResult.OK)
            {
                openFileName = openFileDialog1.FileName;
                txtConfigFilePath.Text = openFileName;

                try
                {
                    

                    LoadConfigFileWorkflow(openFileName);
                    LoadConfigFileCodingSecurityEndPoint(openFileName);
                    LoadConfigFileAPO(openFileName);
                    Debug.WriteLine("Done");
                }
                catch (Exception exp)
                {
                    MessageBox.Show("An error occurred while attempting to load the file. The error is:"
                                    + System.Environment.NewLine + exp.ToString() + System.Environment.NewLine);
                    fileOpened = false;
                }
            }
        }

        private void btnOpenDataLoaderFile_Click(object sender, EventArgs e)
        {
            // If a file is not opened, then set the initial directory to the 
            // FolderBrowserDialog.SelectedPath value. 
            if (!fileOpened)
            {
                openFileDialog1.InitialDirectory = folderBrowserDialogWorkingDirectory.SelectedPath;
                openFileDialog1.FileName = null;
            }


            this.folderBrowserDialogWorkingDirectory.ShowNewFolderButton = false;
            DialogResult _result = this.openFileDialog1.ShowDialog();
            if (_result == DialogResult.OK)
            {
                openFileName = openFileDialog1.FileName;
                txtDataLoaderFilePath.Text = openFileName;

                try
                {
                }
                catch (Exception exp)
                {
                    MessageBox.Show("An error occurred while attempting to load the file: " + openFileName + ". The error is:"
                                    + System.Environment.NewLine + exp.ToString() + System.Environment.NewLine);
                    fileOpened = false;
                }
            }

        }

        private void btnOpenConfig_Click(object sender, EventArgs e)
        {
            btnOpenConfigFile_Click(sender, e);
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
                            txtDefaultDirectory.Text = node.InnerText;
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
                            foreach(XmlNode innerNodes in node)
                            {
                                switch (innerNodes.Name)
                                {
                                    case "deleteOnClose":
                                        if (innerNodes.InnerText.Equals("true"))
                                            chkWorkflowDeleteOnClose.SetItemChecked(0,true);
                                        else
                                            chkWorkflowDeleteOnClose.SetItemChecked(0, false);
                                        break;
                                    case "validation":
                                        XmlNode level3 = innerNodes.ChildNodes.Item(0);
                                        if (level3.InnerText.Equals("true"))
                                            chkWorkflowValidation.SetItemChecked(0, true);
                                        else
                                            chkWorkflowValidation.SetItemChecked(0, false);
                                        break;
                                    case "map":
                                        foreach(XmlNode level3Node in innerNodes)
                                        {
                                            if (level3Node.Name.Equals("enabled"))
                                            {
                                                if (level3Node.InnerText.Equals("true"))
                                                    chkWorkflowMap.SetItemChecked(0, true);
                                                else
                                                    chkWorkflowMap.SetItemChecked(0, false);
                                            }
                                            if (level3Node.Name.Equals("overwrite"))
                                            {
                                                if (level3Node.InnerText.Equals("true"))
                                                    chkWorkflowMapOverwrite.SetItemChecked(0, true);
                                                else
                                                    chkWorkflowMapOverwrite.SetItemChecked(0, false);
                                            }

                                        }
                                        break;
                                    case "reduce":
                                        foreach (XmlNode level3Node in innerNodes)
                                        {
                                            if (level3Node.Name.Equals("enabled"))
                                            {
                                                if (level3Node.InnerText.Equals("true"))
                                                    chkWorkflowReduce.SetItemChecked(0, true);
                                                else
                                                    chkWorkflowReduce.SetItemChecked(0, false);
                                            }
                                            if (level3Node.Name.Equals("overwrite"))
                                            {
                                                if (level3Node.InnerText.Equals("true"))
                                                    chkWorkflowReduceOverwrite.SetItemChecked(0, true);
                                                else
                                                    chkWorkflowReduceOverwrite.SetItemChecked(0, false);
                                            }

                                        }
                                        break;
                                    case "output":
                                        foreach (XmlNode level3Node in innerNodes)
                                        {
                                            if (level3Node.Name.Equals("enabled"))
                                            {
                                                if (level3Node.InnerText.Equals("true"))
                                                    chkWorkflowOutput.SetItemChecked(0, true);
                                                else
                                                    chkWorkflowOutput.SetItemChecked(0, false);
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
                                                    chkWorkflowUpload.SetItemChecked(0, true);
                                                else
                                                    chkWorkflowUpload.SetItemChecked(0, false);
                                            }
                                            if (level3Node.Name.Equals("overwrite"))
                                            {
                                                if (level3Node.InnerText.Equals("true"))
                                                    chkWorkflowUploadOverwrite.SetItemChecked(0, true);
                                                else
                                                    chkWorkflowUploadOverwrite.SetItemChecked(0, false);
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
                Debug.WriteLine("Error Loading XML file: " + thisXMLFile + ". The error is: " + ex.Message);
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
                        case "codingSystems":
                            foreach (XmlNode innerNodes in node)
                            {
                                switch (innerNodes.Name)
                                {
                                    case "CPTLabel":
                                        txtCodingSystemCPTLabel.Text = innerNodes.InnerText;
                                        break;
                                    case "ICD9DXLabel":
                                        txtCodingSystemICD9DX.Text = innerNodes.InnerText;
                                        break;
                                    case "ICD9SGLabel":
                                        txtCodingSystemICD9SG.Text = innerNodes.InnerText;
                                        break;
                                }
                            }
                            break;
                        case "security":
                            foreach (XmlNode innerNodes in node)
                            {
                                switch (innerNodes.Name)
                                {
                                    case "key":
                                        txtSecurityKey.Text = innerNodes.InnerText;
                                        break;
                                    case "algorithm":
                                        txtSecurityAlgorithm.Text = innerNodes.InnerText;
                                        break;
                                }
                            }
                            break;
                        case "endpoint":
                            foreach (XmlNode innerNodes in node)
                            {
                                switch (innerNodes.Name)
                                {
                                    case "server":
                                        txtEndpointServer.Text = innerNodes.InnerText;
                                        break;
                                    case "batchName":
                                        txtEndpointBatchName.Text = innerNodes.InnerText;
                                        break;
                                    case "username":
                                        txtEndpointUserName.Text = innerNodes.InnerText;
                                        break;
                                    case "password":
                                        txtEndpointPassword.Text = innerNodes.InnerText;
                                        break;
                                }
                            }
                            break;

                    }

                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error Loading XML file: " + thisXMLFile + ". The error is: " + ex.Message);
            }
        }
        private void LoadConfigFileAPO(string thisXMLFile)
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
                        case "coverage":
                            chkCoverageEnabled.Checked = true;
                            foreach (XmlNode innerNodes in node)
                            {
                                switch (innerNodes.Name)
                                {
                                    case "path":
                                        txtCoveragePath.Text = innerNodes.InnerText.Replace("/","\\");
                                        break;
                                    case "sourceSystem":
                                        txtCoverageSourceSystem.Text = innerNodes.InnerText;
                                        break;
                                    case "sourceType":
                                        txtCoverageSourceType.Text = innerNodes.InnerText;
                                        break;
                                    case "sourceDate":
                                        dateTimeCoverageSourceDate.Text = innerNodes.InnerText;
                                        break;
                                    case "linesToSkip":
                                        txtCoverageLineToSkip.Text = innerNodes.InnerText;
                                        break;
                                    case "editType":
                                        txtCoverageEditType.Text = innerNodes.InnerText;
                                        break;
                                }
                            }
                            break;
                        case "crosswalk":
                            chkCrosswalkEnabled.Checked = true;
                            foreach (XmlNode innerNodes in node)
                            {
                                switch (innerNodes.Name)
                                {
                                    case "path":
                                        txtCrosswalkPath.Text = innerNodes.InnerText.Replace("/","\\");;
                                        break;
                                    case "sourceSystem":
                                        txtCrosswalkSourceSystem.Text = innerNodes.InnerText;
                                        break;
                                    case "sourceType":
                                        txtCrosswalkSourceType.Text = innerNodes.InnerText;
                                        break;
                                    case "sourceDate":
                                        dateTimeCrosswalkSourceDate.Text = innerNodes.InnerText;
                                        break;
                                    case "linesToSkip":
                                        txtCrosswalkLineToSkip.Text = innerNodes.InnerText;
                                        break;
                                    case "editType":
                                        txtCrosswalkEditType.Text = innerNodes.InnerText;
                                        break;
                                }
                            }
                            break;
                        case "demographics":
                            chkDemographicsEnabled.Checked = true;
                            foreach (XmlNode innerNodes in node)
                            {
                                switch (innerNodes.Name)
                                {
                                    case "path":
                                        txtDemographicsPath.Text = innerNodes.InnerText.Replace("/","\\");;
                                        break;
                                    case "sourceSystem":
                                        txtDemographicsSourceSystem.Text = innerNodes.InnerText;
                                        break;
                                    case "sourceType":
                                        txtDemographicsSourceType.Text = innerNodes.InnerText;
                                        break;
                                    case "sourceDate":
                                        dateTimeDemographicsSourceDate.Text = innerNodes.InnerText;
                                        break;
                                    case "linesToSkip":
                                        txtDemographicsLineToSkip.Text = innerNodes.InnerText;
                                        break;
                                    case "editType":
                                        txtDemographicsEditType.Text = innerNodes.InnerText;
                                        break;
                                }
                            }                                
                            break;
                        case "documents":
                            chkDocumentsEnabled.Checked = true;
                            foreach (XmlNode innerNodes in node)
                            {
                                switch (innerNodes.Name)
                                {
                                    case "path":
                                        txtDocumentsPath.Text = innerNodes.InnerText.Replace("/","\\");;
                                        break;
                                    case "sourceSystem":
                                        txtDocumentsSourceSystem.Text = innerNodes.InnerText;
                                        break;
                                    case "sourceType":
                                        txtDocumentsSourceType.Text = innerNodes.InnerText;
                                        break;
                                    case "sourceDate":
                                        dateTimeDocumentsSourceDate.Text = innerNodes.InnerText;
                                        break;
                                    case "linesToSkip":
                                        txtDocumentsLineToSkip.Text = innerNodes.InnerText;
                                        break;
                                    case "editType":
                                        txtDocumentsEditType.Text = innerNodes.InnerText;
                                        break;
                                }
                            }
                            break;
                        case "encounters":
                            chkEncountersEnabled.Checked = true;
                            foreach (XmlNode innerNodes in node)
                            {
                                switch (innerNodes.Name)
                                {
                                    case "path":
                                        txtEncountersPath.Text = innerNodes.InnerText.Replace("/","\\");;
                                        break;
                                    case "sourceSystem":
                                        txtEncountersSourceSystem.Text = innerNodes.InnerText;
                                        break;
                                    case "sourceType":
                                        txtEncountersSourceType.Text = innerNodes.InnerText;
                                        break;
                                    case "sourceDate":
                                        dateTimeEncountersSourceDate.Text = innerNodes.InnerText;
                                        break;
                                    case "linesToSkip":
                                        txtEncountersLineToSkip.Text = innerNodes.InnerText;
                                        break;
                                    case "editType":
                                        txtEncountersEditType.Text = innerNodes.InnerText;
                                        break;
                                }
                            }
                            break;
                        case "events":
                            chkEventsEnabled.Checked = true;
                            foreach (XmlNode innerNodes in node)
                            {
                                switch (innerNodes.Name)
                                {
                                    case "path":
                                        txtEventsPath.Text = innerNodes.InnerText.Replace("/","\\");;
                                        break;
                                    case "sourceSystem":
                                        txtEventsSourceSystem.Text = innerNodes.InnerText;
                                        break;
                                    case "sourceType":
                                        txtEventsSourceType.Text = innerNodes.InnerText;
                                        break;
                                    case "sourceDate":
                                        dateTimeEventsSourceDate.Text = innerNodes.InnerText;
                                        break;
                                    case "linesToSkip":
                                        txtEventsLineToSkip.Text = innerNodes.InnerText;
                                        break;
                                    case "editType":
                                        txtEventsEditType.Text = innerNodes.InnerText;
                                        break;
                                }
                            }
                            break;
                        case "problems":
                            chkProblemsEnabled.Checked = true;
                            foreach (XmlNode innerNodes in node)
                            {
                                switch (innerNodes.Name)
                                {
                                    case "path":
                                        txtProblemsPath.Text = innerNodes.InnerText.Replace("/","\\");;
                                        break;
                                    case "sourceSystem":
                                        txtProblemsSourceSystem.Text = innerNodes.InnerText;
                                        break;
                                    case "sourceType":
                                        txtProblemsSourceType.Text = innerNodes.InnerText;
                                        break;
                                    case "sourceDate":
                                        dateTimeProblemsSourceDate.Text = innerNodes.InnerText;
                                        break;
                                    case "linesToSkip":
                                        txtProblemsLineToSkip.Text = innerNodes.InnerText;
                                        break;
                                    case "editType":
                                        txtProblemsEditType.Text = innerNodes.InnerText;
                                        break;
                                }
                            }
                            break;
                        case "problemsmora":
                            chkProblemsMORAEnabled.Checked = true;
                            foreach (XmlNode innerNodes in node)
                            {
                                switch (innerNodes.Name)
                                {
                                    case "path":
                                        txtProblemsMORAPath.Text = innerNodes.InnerText.Replace("/","\\");;
                                        break;
                                    case "sourceSystem":
                                        txtProblemsMORASourceSystem.Text = innerNodes.InnerText;
                                        break;
                                    case "sourceType":
                                        txtProblemsMORASourceType.Text = innerNodes.InnerText;
                                        break;
                                    case "sourceDate":
                                        dateTimeProblemsMORASourceDate.Text = innerNodes.InnerText;
                                        break;
                                    case "linesToSkip":
                                        txtProblemsMORALineToSkip.Text = innerNodes.InnerText;
                                        break;
                                    case "editType":
                                        txtProblemsMORAEditType.Text = innerNodes.InnerText;
                                        break;
                                }
                            }
                            break;
                        case "problemsmorb":
                            chkProblemsMORBEnabled.Checked = true;
                            foreach (XmlNode innerNodes in node)
                            {
                                switch (innerNodes.Name)
                                {
                                    case "path":
                                        txtProblemsMORBPath.Text = innerNodes.InnerText.Replace("/","\\");;
                                        break;
                                    case "sourceSystem":
                                        txtProblemsMORBSourceSystem.Text = innerNodes.InnerText;
                                        break;
                                    case "sourceType":
                                        txtProblemsMORBSourceType.Text = innerNodes.InnerText;
                                        break;
                                    case "sourceDate":
                                        dateTimeProblemsMORBSourceDate.Text = innerNodes.InnerText;
                                        break;
                                    case "linesToSkip":
                                        txtProblemsMORBLineToSkip.Text = innerNodes.InnerText;
                                        break;
                                    case "editType":
                                        txtProblemsMORBEditType.Text = innerNodes.InnerText;
                                        break;
                                }
                            }
                            break;
                        case "problemsmorc":
                            chkProblemsMORCEnabled.Checked = true;
                            foreach (XmlNode innerNodes in node)
                            {
                                switch (innerNodes.Name)
                                {
                                    case "path":
                                        txtProblemsMORCPath.Text = innerNodes.InnerText.Replace("/","\\");;
                                        break;
                                    case "sourceSystem":
                                        txtProblemsMORCSourceSystem.Text = innerNodes.InnerText;
                                        break;
                                    case "sourceType":
                                        txtProblemsMORCSourceType.Text = innerNodes.InnerText;
                                        break;
                                    case "sourceDate":
                                        dateTimeProblemsMORCSourceDate.Text = innerNodes.InnerText;
                                        break;
                                    case "linesToSkip":
                                        txtProblemsMORCLineToSkip.Text = innerNodes.InnerText;
                                        break;
                                    case "editType":
                                        txtProblemsMORCEditType.Text = innerNodes.InnerText;
                                        break;
                                }
                            }
                            break;
                        case "problemsraps":
                            chkProblemsRAPSEnabled.Checked = true;
                            foreach (XmlNode innerNodes in node)
                            {
                                switch (innerNodes.Name)
                                {
                                    case "path":
                                        txtProblemsRAPSPath.Text = innerNodes.InnerText.Replace("/","\\");;
                                        break;
                                    case "sourceSystem":
                                        txtProblemsRAPSSourceSystem.Text = innerNodes.InnerText;
                                        break;
                                    case "sourceType":
                                        txtProblemsRAPSSourceType.Text = innerNodes.InnerText;
                                        break;
                                    case "sourceDate":
                                        dateTimeProblemsRAPSSourceDate.Text = innerNodes.InnerText;
                                        break;
                                    case "linesToSkip":
                                        txtProblemsRAPSLineToSkip.Text = innerNodes.InnerText;
                                        break;
                                    case "editType":
                                        txtProblemsRAPSEditType.Text = innerNodes.InnerText;
                                        break;
                                }
                            }
                            break;
                        case "procedures":
                            chkProceduresEnabled.Checked = true;
                            foreach (XmlNode innerNodes in node)
                            {
                                switch (innerNodes.Name)
                                {
                                    case "path":
                                        txtProceduresPath.Text = innerNodes.InnerText.Replace("/","\\");;
                                        break;
                                    case "sourceSystem":
                                        txtProceduresSourceSystem.Text = innerNodes.InnerText;
                                        break;
                                    case "sourceType":
                                        txtProceduresSourceType.Text = innerNodes.InnerText;
                                        break;
                                    case "sourceDate":
                                        dateTimeProceduresSourceDate.Text = innerNodes.InnerText;
                                        break;
                                    case "linesToSkip":
                                        txtProceduresLineToSkip.Text = innerNodes.InnerText;
                                        break;
                                    case "editType":
                                        txtProceduresEditType.Text = innerNodes.InnerText;
                                        break;
                                }
                            }
                            break;
                        case "providers":
                            chkProvidersEnabled.Checked = true;
                            foreach (XmlNode innerNodes in node)
                            {
                                switch (innerNodes.Name)
                                {
                                    case "path":
                                        txtProvidersPath.Text = innerNodes.InnerText.Replace("/","\\");
                                        break;
                                    case "sourceSystem":
                                        txtProvidersSourceSystem.Text = innerNodes.InnerText;
                                        break;
                                    case "sourceType":
                                        txtProvidersSourceType.Text = innerNodes.InnerText;
                                        break;
                                    case "sourceDate":
                                        dateTimeProvidersSourceDate.Text = innerNodes.InnerText;
                                        break;
                                    case "linesToSkip":
                                        txtProvidersLineToSkip.Text = innerNodes.InnerText;
                                        break;
                                    case "editType":
                                        txtProvidersEditType.Text = innerNodes.InnerText;
                                        break;
                                }
                            }
                            break;

                    }

                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error Loading XML file: " + thisXMLFile + ". The error is: " + ex.Message);
            }
        }
        private void Initialize()
        {
            this.chkWorkflowUploadOverwrite.SetItemChecked(0, false);
            this.chkWorkflowUpload.SetItemChecked(0, false);
            this.txtWorkflowOutputFilePath.Text = "";
            this.chkWorkflowOutput.SetItemChecked(0,false);
            this.chkWorkflowReduceOverwrite.SetItemChecked(0, false);
            this.chkWorkflowReduce.SetItemChecked(0, false);
            this.chkWorkflowMapOverwrite.SetItemChecked(0, false);
            this.chkWorkflowMap.SetItemChecked(0, false);
            this.chkWorkflowValidation.SetItemChecked(0, false);
            this.chkWorkflowDeleteOnClose.SetItemChecked(0, false);
            this.txtCodingSystemICD9SG.Text = "";
            this.txtCodingSystemICD9DX.Text="";
            this.txtCodingSystemCPTLabel.Text="";
            this.txtSecurityAlgorithm.Text="";
            this.txtSecurityKey.Text="";
            this.txtEndpointPassword.Text="";
            this.txtEndpointUserName.Text="";
            this.txtEndpointBatchName.Text="";
            this.txtEndpointServer.Text="";
            this.chkCoverageEnabled.Checked= false;
            this.dateTimeCoverageSourceDate.Text = Convert.ToString(DateTime.Today);
            this.txtCoverageEditType.Text="";
            this.txtCoverageLineToSkip.Text="";
            this.txtCoverageSourceType.Text="";
            this.txtCoverageSourceSystem.Text="";
            this.txtCoveragePath.Text="";
            this.chkCrosswalkEnabled.Checked= false;
            this.dateTimeCrosswalkSourceDate.Text = Convert.ToString(DateTime.Today);
            this.txtCrosswalkEditType.Text="";
            this.txtCrosswalkLineToSkip.Text="";
            this.txtCrosswalkSourceType.Text="";
            this.txtCrosswalkSourceSystem.Text="";
            this.txtCrosswalkPath.Text="";
            this.chkDemographicsEnabled.Checked= false;
            this.dateTimeDemographicsSourceDate.Text = Convert.ToString(DateTime.Today);
            this.txtDemographicsEditType.Text="";
            this.txtDemographicsLineToSkip.Text="";
            this.txtDemographicsSourceType.Text="";
            this.txtDemographicsSourceSystem.Text="";
            this.txtDemographicsPath.Text="";
            this.chkDocumentsEnabled.Checked= false;
            this.dateTimeDocumentsSourceDate.Text = Convert.ToString(DateTime.Today);
            this.txtDocumentsEditType.Text="";
            this.txtDocumentsLineToSkip.Text="";
            this.txtDocumentsSourceType.Text="";
            this.txtDocumentsSourceSystem.Text="";
            this.txtDocumentsPath.Text="";
            this.chkEncountersEnabled.Checked= false;
            this.dateTimeEncountersSourceDate.Text = Convert.ToString(DateTime.Today);
            this.txtEncountersEditType.Text="";
            this.txtEncountersLineToSkip.Text="";
            this.txtEncountersSourceType.Text="";
            this.txtEncountersSourceSystem.Text="";
            this.txtEncountersPath.Text="";
            this.chkEventsEnabled.Checked= false;
            this.dateTimeEventsSourceDate.Text = Convert.ToString(DateTime.Today);
            this.txtEventsEditType.Text="";
            this.txtEventsLineToSkip.Text="";
            this.txtEventsSourceType.Text="";
            this.txtEventsSourceSystem.Text="";
            this.txtEventsPath.Text="";
            this.chkProblemsEnabled.Checked= false;
            this.dateTimeProblemsSourceDate.Text = Convert.ToString(DateTime.Today);
            this.txtProblemsEditType.Text="";
            this.txtProblemsLineToSkip.Text="";
            this.txtProblemsSourceType.Text="";
            this.txtProblemsSourceSystem.Text="";
            this.txtProblemsPath.Text="";
            this.chkProblemsMORAEnabled.Checked= false;
            this.dateTimeProblemsMORASourceDate.Text = Convert.ToString(DateTime.Today);
            this.txtProblemsMORAEditType.Text="";
            this.txtProblemsMORALineToSkip.Text="";
            this.txtProblemsMORASourceType.Text="";
            this.txtProblemsMORASourceSystem.Text="";
            this.txtProblemsMORAPath.Text="";
            this.label59 = new System.Windows.Forms.Label();
            this.chkProblemsMORBEnabled.Checked= false;
            this.dateTimeProblemsMORBSourceDate.Text = Convert.ToString(DateTime.Today);
            this.txtProblemsMORBEditType.Text="";
            this.txtProblemsMORBLineToSkip.Text="";
            this.txtProblemsMORBSourceType.Text="";
            this.txtProblemsMORBSourceSystem.Text="";
            this.txtProblemsMORBPath.Text="";
            this.chkProblemsMORCEnabled.Checked= false;
            this.dateTimeProblemsMORCSourceDate.Text = Convert.ToString(DateTime.Today);
            this.txtProblemsMORCEditType.Text="";
            this.txtProblemsMORCLineToSkip.Text="";
            this.txtProblemsMORCSourceType.Text="";
            this.txtProblemsMORCSourceSystem.Text="";
            this.txtProblemsMORCPath.Text="";
            this.chkProblemsRAPSEnabled.Checked= false;
            this.dateTimeProblemsRAPSSourceDate.Text = Convert.ToString(DateTime.Today);
            this.txtProblemsRAPSEditType.Text="";
            this.txtProblemsRAPSLineToSkip.Text="";
            this.txtProblemsRAPSSourceType.Text="";
            this.txtProblemsRAPSSourceSystem.Text="";
            this.txtProblemsRAPSPath.Text="";
            this.chkProceduresEnabled.Checked= false;
            this.dateTimeProceduresSourceDate.Text = Convert.ToString(DateTime.Today);
            this.txtProceduresEditType.Text="";
            this.txtProceduresLineToSkip.Text="";
            this.txtProceduresSourceType.Text="";
            this.txtProceduresSourceSystem.Text="";
            this.txtProceduresPath.Text="";
            this.chkProvidersEnabled.Checked= false;
            this.dateTimeProvidersSourceDate.Text = Convert.ToString(DateTime.Today);
            this.txtProvidersEditType.Text="";
            this.txtProvidersLineToSkip.Text="";
            this.txtProvidersSourceType.Text="";
            this.txtProvidersSourceSystem.Text="";
            this.txtProvidersPath.Text="";
            this.dateTimeSourceDate.Text = Convert.ToString(DateTime.Today);
            this.txtSourceType.Text="";
            this.txtSourceSystem.Text="";
            this.txtPrimaryAuthority.Text="";
            this.txtDefaultDirectory.Text="";
            this.txtWorkingDirectory.Text="";
            this.txtConfigFilePath.Text="";
            this.txtDataLoaderFilePath.Text="";
        }

        private void btnWorkingDirectory_Click(object sender, EventArgs e)
        {
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
                    openFileDialog1.FileName = null;
                    txtWorkingDirectory.Text = openFolder;
                }
            }
        }

        private void btnWorkflowFileName_Click(object sender, EventArgs e)
        {
            if (!fileOpened)
            {
                openFileDialog1.InitialDirectory = folderBrowserDialogWorkingDirectory.SelectedPath;
                openFileDialog1.FileName = null;
            }


            this.folderBrowserDialogWorkingDirectory.ShowNewFolderButton = false;
            DialogResult _result = this.openFileDialog1.ShowDialog();
            if (_result == DialogResult.OK)
            {
                openFileName = openFileDialog1.FileName;
                txtWorkflowOutputFilePath.Text = openFileName;
            }

        }

        private void btnCoverage_Click(object sender, EventArgs e)
        {
            if (!fileOpened)
            {
                openFileDialog1.InitialDirectory = folderBrowserDialogWorkingDirectory.SelectedPath;
                openFileDialog1.FileName = null;
            }


            this.folderBrowserDialogWorkingDirectory.ShowNewFolderButton = false;
            DialogResult _result = this.openFileDialog1.ShowDialog();
            if (_result == DialogResult.OK)
            {
                openFileName = openFileDialog1.FileName;
                txtCoveragePath.Text = openFileName;
            }

        }

        private void btnCrosswalk_Click(object sender, EventArgs e)
        {
            if (!fileOpened)
            {
                openFileDialog1.InitialDirectory = folderBrowserDialogWorkingDirectory.SelectedPath;
                openFileDialog1.FileName = null;
            }


            this.folderBrowserDialogWorkingDirectory.ShowNewFolderButton = false;
            DialogResult _result = this.openFileDialog1.ShowDialog();
            if (_result == DialogResult.OK)
            {
                openFileName = openFileDialog1.FileName;
                txtCrosswalkPath.Text = openFileName;
            }

        }

        private void btnDemographics_Click(object sender, EventArgs e)
        {
            if (!fileOpened)
            {
                openFileDialog1.InitialDirectory = folderBrowserDialogWorkingDirectory.SelectedPath;
                openFileDialog1.FileName = null;
            }


            this.folderBrowserDialogWorkingDirectory.ShowNewFolderButton = false;
            DialogResult _result = this.openFileDialog1.ShowDialog();
            if (_result == DialogResult.OK)
            {
                openFileName = openFileDialog1.FileName;
                txtDemographicsPath.Text = openFileName;
            }

        }

        private void btnDocuments_Click(object sender, EventArgs e)
        {
            if (!fileOpened)
            {
                openFileDialog1.InitialDirectory = folderBrowserDialogWorkingDirectory.SelectedPath;
                openFileDialog1.FileName = null;
            }


            this.folderBrowserDialogWorkingDirectory.ShowNewFolderButton = false;
            DialogResult _result = this.openFileDialog1.ShowDialog();
            if (_result == DialogResult.OK)
            {
                openFileName = openFileDialog1.FileName;
                txtDocumentsPath.Text = openFileName;
            }

        }

        private void btnEncounters_Click(object sender, EventArgs e)
        {
            if (!fileOpened)
            {
                openFileDialog1.InitialDirectory = folderBrowserDialogWorkingDirectory.SelectedPath;
                openFileDialog1.FileName = null;
            }


            this.folderBrowserDialogWorkingDirectory.ShowNewFolderButton = false;
            DialogResult _result = this.openFileDialog1.ShowDialog();
            if (_result == DialogResult.OK)
            {
                openFileName = openFileDialog1.FileName;
                txtEncountersPath.Text = openFileName;
            }

        }

        private void btnEvents_Click(object sender, EventArgs e)
        {
            if (!fileOpened)
            {
                openFileDialog1.InitialDirectory = folderBrowserDialogWorkingDirectory.SelectedPath;
                openFileDialog1.FileName = null;
            }


            this.folderBrowserDialogWorkingDirectory.ShowNewFolderButton = false;
            DialogResult _result = this.openFileDialog1.ShowDialog();
            if (_result == DialogResult.OK)
            {
                openFileName = openFileDialog1.FileName;
                txtEventsPath.Text = openFileName;
            }

        }

        private void btnProblems_Click(object sender, EventArgs e)
        {
            if (!fileOpened)
            {
                openFileDialog1.InitialDirectory = folderBrowserDialogWorkingDirectory.SelectedPath;
                openFileDialog1.FileName = null;
            }


            this.folderBrowserDialogWorkingDirectory.ShowNewFolderButton = false;
            DialogResult _result = this.openFileDialog1.ShowDialog();
            if (_result == DialogResult.OK)
            {
                openFileName = openFileDialog1.FileName;
                txtProblemsPath.Text = openFileName;
            }

        }

        private void btnProblemsMORA_Click(object sender, EventArgs e)
        {
            if (!fileOpened)
            {
                openFileDialog1.InitialDirectory = folderBrowserDialogWorkingDirectory.SelectedPath;
                openFileDialog1.FileName = null;
            }


            this.folderBrowserDialogWorkingDirectory.ShowNewFolderButton = false;
            DialogResult _result = this.openFileDialog1.ShowDialog();
            if (_result == DialogResult.OK)
            {
                openFileName = openFileDialog1.FileName;
                txtProblemsMORAPath.Text = openFileName;
            }

        }

        private void btnProblemsMORB_Click(object sender, EventArgs e)
        {
            if (!fileOpened)
            {
                openFileDialog1.InitialDirectory = folderBrowserDialogWorkingDirectory.SelectedPath;
                openFileDialog1.FileName = null;
            }


            this.folderBrowserDialogWorkingDirectory.ShowNewFolderButton = false;
            DialogResult _result = this.openFileDialog1.ShowDialog();
            if (_result == DialogResult.OK)
            {
                openFileName = openFileDialog1.FileName;
                txtProblemsMORBPath.Text = openFileName;
            }

        }

        private void btnProblemsMORC_Click(object sender, EventArgs e)
        {
            if (!fileOpened)
            {
                openFileDialog1.InitialDirectory = folderBrowserDialogWorkingDirectory.SelectedPath;
                openFileDialog1.FileName = null;
            }


            this.folderBrowserDialogWorkingDirectory.ShowNewFolderButton = false;
            DialogResult _result = this.openFileDialog1.ShowDialog();
            if (_result == DialogResult.OK)
            {
                openFileName = openFileDialog1.FileName;
                txtProblemsMORCPath.Text = openFileName;
            }

        }

        private void btnProblemsRAPS_Click(object sender, EventArgs e)
        {
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
                    openFileDialog1.FileName = null;
                    txtProblemsRAPSPath.Text = openFolder;
                }
            }

        }

        private void btnProcedures_Click(object sender, EventArgs e)
        {
            if (!fileOpened)
            {
                openFileDialog1.InitialDirectory = folderBrowserDialogWorkingDirectory.SelectedPath;
                openFileDialog1.FileName = null;
            }


            this.folderBrowserDialogWorkingDirectory.ShowNewFolderButton = false;
            DialogResult _result = this.openFileDialog1.ShowDialog();
            if (_result == DialogResult.OK)
            {
                openFileName = openFileDialog1.FileName;
                txtProceduresPath.Text = openFileName;
            }

        }

        private void btnProviders_Click(object sender, EventArgs e)
        {
            if (!fileOpened)
            {
                openFileDialog1.InitialDirectory = folderBrowserDialogWorkingDirectory.SelectedPath;
                openFileDialog1.FileName = null;
            }


            this.folderBrowserDialogWorkingDirectory.ShowNewFolderButton = false;
            DialogResult _result = this.openFileDialog1.ShowDialog();
            if (_result == DialogResult.OK)
            {
                openFileName = openFileDialog1.FileName;
                txtProvidersPath.Text = openFileName;
            }

        }

    }
}
