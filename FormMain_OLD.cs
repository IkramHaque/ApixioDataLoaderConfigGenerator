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
using System.Xml.Serialization;
using System.Diagnostics;
using System.Configuration;
namespace ApixioDataLoaderConfigGenerator
{
    public partial class FormMain_OLD : Form
    {
        private Boolean fileOpened = false;
        private string openFileName;
        private string openFolder;

        public FormMain_OLD()
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
                    ProgressBar.Value = 0;

                    LoadConfigFileWorkflow(openFileName);
                    LoadConfigFileCodingSecurityEndPoint(openFileName);
                    LoadConfigFileAPO(openFileName);

                    ProgressBar.Value = 100;
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
                            foreach(XmlNode innerNodes in node)
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
                                        foreach(XmlNode level3Node in innerNodes)
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
                                    case "reduce":
                                        foreach (XmlNode level3Node in innerNodes)
                                        {
                                            if (level3Node.Name.Equals("enabled"))
                                            {
                                                if (level3Node.InnerText.Equals("true"))
                                                    chkWorkflowReduce.Checked = true;
                                                else
                                                    chkWorkflowReduce.Checked = false;
                                            }
                                            if (level3Node.Name.Equals("overwrite"))
                                            {
                                                if (level3Node.InnerText.Equals("true"))
                                                    chkWorkflowReduceOverwrite.Checked = true;
                                                else
                                                    chkWorkflowReduceOverwrite.Checked = false;
                                            }

                                        }
                                        break;
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
            this.chkWorkflowUploadOverwrite.Checked = false;
            this.chkWorkflowUpload.Checked = false;
            this.txtWorkflowOutputFilePath.Text = "";
            this.chkWorkflowOutput.Checked=false;
            this.chkWorkflowReduceOverwrite.Checked = false;
            this.chkWorkflowReduce.Checked = false;
            this.chkWorkflowMapOverwrite.Checked = false;
            this.chkWorkflowMap.Checked = false;
            this.chkWorkflowValidation.Checked = false;
            this.chkWorkflowDeleteOnClose.Checked = false;
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
            this.txtDefaultAuthority.Text="";
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

        private void btnSaveConfig_Click(object sender, EventArgs e)
        {
            try
            {
                SaveConfigXML(openFileName);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error writing to file: " + openFileName + ". The error is: " + ex.Message);
            }
        }

        private void SaveConfigXML(string fileName)
        {
            StringBuilder sOutput = new StringBuilder();
            try 
            { 
                
                //DLConfig dlc = new DLConfig();
            
                //DLWorkflow dlw = new DLWorkflow();
                //DLWorkflowValidation dlwv = new DLWorkflowValidation();
                //DLWorkflowMap dlwm = new DLWorkflowMap();
                //DLWorkflowReduce dlwr = new DLWorkflowReduce();
                //DLWorkflowOutput dlwo = new DLWorkflowOutput();
                //DLWorkflowUpload dlwu = new DLWorkflowUpload();

                //DLCodingSystems dlcs = new DLCodingSystems();

                //DLSecurity dls = new DLSecurity();

                //DLEndpoint dlep = new DLEndpoint();

                //DLCoverage dlcv = new DLCoverage();
                //DLCrosswalk dlcw = new DLCrosswalk();
                //DLDemographics dld = new DLDemographics();
                //DLDocuments dldoc = new DLDocuments();
                //DLEncounters dle = new DLEncounters();
                //DLEvents dlev = new DLEvents();


                //DLProblems dlp = new DLProblems();
                //DLProblemsmora dlma = new DLProblemsmora();
                //DLProblemsmorb dlmb = new DLProblemsmorb();
                //DLProblemsmorc dlmc = new DLProblemsmorc();
                //DLProblemsraps dlr = new DLProblemsraps();

                //DLProcedures dlproc = new DLProcedures();
                //DLProviders dlprov= new DLProviders();


                sOutput.Append("<?xml version=\"1.0\" encoding=\"UTF-8\"?>").Append("\n").Append("<application>").Append("\n");

                sOutput.Append("<workingDir>").Append(this.txtWorkingDirectory.Text).Append("</workingDir>").Append("\n");
                sOutput.Append("<defaultAuthority>").Append(this.txtDefaultAuthority.Text).Append("</defaultAuthority>").Append("\n");
                sOutput.Append("<primaryAuthority>").Append(txtPrimaryAuthority.Text).Append("</primaryAuthority>").Append("\n");
                
                //dlc.workingDir = this.txtWorkingDirectory.Text;
                //dlc.defaultAuthority = this.txtDefaultAuthority.Text;
                //dlc.primaryAuthority = this.txtPrimaryAuthority.Text;


                sOutput.Append("<sourceSystem>").Append(this.txtSourceSystem.Text).Append("</sourceSystem>").Append("\n");
                sOutput.Append("<sourceType>").Append(this.txtSourceType.Text).Append("</sourceType>").Append("\n");
                sOutput.Append("<sourceDate>").Append(dateTimeSourceDate.Text).Append("</sourceDate>").Append("\n");

                sOutput.Append("<workflow>").Append("\n");

                if (this.chkWorkflowDeleteOnClose.Checked)
                    sOutput.Append("<deleteOnClose>").Append("true").Append("</deleteOnClose>").Append("\n");
                else
                    sOutput.Append("<deleteOnClose>").Append("false").Append("</deleteOnClose>").Append("\n");

                sOutput.Append("<validation>").Append("\n");
                if (this.chkWorkflowValidation.Checked)
                    sOutput.Append("<enabled>").Append("true").Append("</enabled>").Append("\n");
                else
                    sOutput.Append("<enabled>").Append("false").Append("</enabled>").Append("\n");
                sOutput.Append("</validation>").Append("\n");

                sOutput.Append("<map>").Append("\n");
                if (this.chkWorkflowMap.Checked)
                    sOutput.Append("<enabled>").Append("true").Append("</enabled>").Append("\n");
                else
                    sOutput.Append("<enabled>").Append("false").Append("</enabled>").Append("\n");
                if (this.chkWorkflowMapOverwrite.Checked)
                    sOutput.Append("<overwrite>").Append("true").Append("</overwrite>").Append("\n");
                else
                    sOutput.Append("<overwrite>").Append("false").Append("</overwrite>").Append("\n");
                sOutput.Append("</map>").Append("\n");
                //dlwm.enabled = this.chkWorkflowMap.Text;
                //dlwm.overwrite = this.chkWorkflowMapOverwrite.Text;

                sOutput.Append("<reduce>").Append("\n");
                if (this.chkWorkflowReduce.Checked)
                    sOutput.Append("<enabled>").Append("true").Append("</enabled>").Append("\n");
                else
                    sOutput.Append("<enabled>").Append("false").Append("</enabled>").Append("\n");
                if (this.chkWorkflowReduceOverwrite.Checked)
                    sOutput.Append("<overwrite>").Append("true").Append("</overwrite>").Append("\n");
                else
                    sOutput.Append("<overwrite>").Append("false").Append("</overwrite>").Append("\n");
                sOutput.Append("</reduce>").Append("\n");
                //if (this.chkWorkflowReduce.Checked)
                //    dlwr.enabled = "true";
                //else
                //    dlwr.enabled = "false";
                //if (this.chkWorkflowReduceOverwrite.Checked)
                //    dlwr.overwrite = "true";
                //else 
                //    dlwr.overwrite = "false";


                sOutput.Append("<output>").Append("\n");
                if (this.chkWorkflowOutput.Checked)
                    sOutput.Append("<enabled>").Append("true").Append("</enabled>").Append("\n");
                else
                    sOutput.Append("<enabled>").Append("false").Append("</enabled>").Append("\n");
                sOutput.Append("<path>").Append(txtWorkflowOutputFilePath.Text).Append("</path>").Append("\n");
                sOutput.Append("</output>").Append("\n");
                //if (this.chkWorkflowOutput.Checked)
                //    dlwo.enabled = "true";
                //else
                //    dlwo.enabled="false";
                //dlwo.path = this.txtWorkflowOutputFilePath.Text;
                //if (this.chkWorkflowUpload.Checked)
                //    dlwu.enabled = "true";
                //else
                //    dlwu.enabled = "false";

                sOutput.Append("<upload>").Append("\n");
                if (this.chkWorkflowUpload.Checked)
                    sOutput.Append("<enabled>").Append("true").Append("</enabled>").Append("\n");
                else
                    sOutput.Append("<enabled>").Append("false").Append("</enabled>").Append("\n");
                if (this.chkWorkflowUploadOverwrite.Checked)
                    sOutput.Append("<overwrite>").Append("true").Append("</overwrite>").Append("\n");
                else
                    sOutput.Append("<overwrite>").Append("false").Append("</overwrite>").Append("\n");
                sOutput.Append("</upload>").Append("\n");
                sOutput.Append("</workflow>").Append("\n");
                //if (this.chkWorkflowUploadOverwrite.Checked)
                //    dlwu.overwrite = "true";
                //else
                //    dlwu.overwrite = "false";
                sOutput.Append("<codingSystems>").Append("\n");
                sOutput.Append("<CPTLabel>").Append(txtCodingSystemCPTLabel.Text).Append("</CPTLabel>").Append("\n");
                sOutput.Append("<ICD9DXLabel>").Append(txtCodingSystemICD9DX.Text).Append("</ICD9DXLabel>").Append("\n");
                sOutput.Append("<ICD9SGLabel>").Append(txtCodingSystemICD9SG.Text).Append("</ICD9SGLabel>").Append("\n");
                sOutput.Append("</codingSystems>").Append("\n");
                //dlcs.ICD9DXLabel = this.txtCodingSystemICD9DX.Text;
                //dlcs.ICD9SGLabel = this.txtCodingSystemICD9SG.Text;

                sOutput.Append("<security>").Append("\n");
                sOutput.Append("<key>").Append(txtSecurityKey.Text).Append("</key>").Append("\n");
                sOutput.Append("<algorithm>").Append(txtSecurityAlgorithm.Text).Append("</algorithm>").Append("\n");
                sOutput.Append("</security>").Append("\n");
                //dls.key = this.txtSecurityKey.Text;
                //dls.algorithm = this.txtSecurityAlgorithm.Text;

                sOutput.Append("<endpoint>").Append("\n");
                sOutput.Append("<server>").Append(txtEndpointServer.Text).Append("</server>").Append("\n");
                sOutput.Append("<batchName>").Append(txtEndpointBatchName.Text).Append("</batchName>").Append("\n");
                sOutput.Append("<username>").Append(txtEndpointUserName.Text).Append("</username>").Append("\n");
                sOutput.Append("<password>").Append(txtEndpointPassword.Text).Append("</password>").Append("\n");
                sOutput.Append("</endpoint>").Append("\n");
                //dlep.server = this.txtEndpointServer.Text;
                //dlep.batchName = this.txtEndpointBatchName.Text;
                //dlep.username = this.txtEndpointUserName.Text;
                //dlep.password = this.txtEndpointPassword.Text;

                if (chkCoverageEnabled.Checked)
                {
                    sOutput.Append("<coverage>").Append("\n");
                    sOutput.Append("<path>").Append(txtCoveragePath.Text).Append("</path>").Append("\n");
                    sOutput.Append("<sourceSystem>").Append(txtCoverageSourceSystem.Text).Append("</sourceSystem>").Append("\n");
                    sOutput.Append("<sourceType>").Append(txtCoverageSourceType.Text).Append("</sourceType>").Append("\n");
                    sOutput.Append("<sourceDate>").Append(dateTimeCoverageSourceDate.Text).Append("</sourceDate>").Append("\n");
                    sOutput.Append("<linesToSkip>").Append(txtCoverageLineToSkip.Text).Append("</linesToSkip>").Append("\n");
                    sOutput.Append("<editType>").Append(txtCoverageEditType.Text).Append("</editType>").Append("\n");
                    sOutput.Append("</coverage>").Append("\n");
                    //dlcv.path = this.txtCoveragePath.Text;
                    //dlcv.sourceSystem = this.txtCoverageSourceSystem.Text;
                    //dlcv.sourceType = this.txtCoverageSourceType.Text;
                    //dlcv.sourceDate = this.dateTimeCoverageSourceDate.Text;
                    //dlcv.linesToSkip = this.txtCrosswalkLineToSkip.Text;
                    //dlcv.editType = this.txtCoverageSourceType.Text;
                }

                if (chkCrosswalkEnabled.Checked)
                {
                    sOutput.Append("<crosswalk>").Append("\n");
                    sOutput.Append("<path>").Append(txtCrosswalkPath.Text).Append("</path>").Append("\n");
                    sOutput.Append("<sourceSystem>").Append(txtCrosswalkSourceSystem.Text).Append("</sourceSystem>").Append("\n");
                    sOutput.Append("<sourceType>").Append(txtCrosswalkSourceType.Text).Append("</sourceType>").Append("\n");
                    sOutput.Append("<sourceDate>").Append(dateTimeCrosswalkSourceDate.Text).Append("</sourceDate>").Append("\n");
                    sOutput.Append("<linesToSkip>").Append(txtCrosswalkLineToSkip.Text).Append("</linesToSkip>").Append("\n");
                    sOutput.Append("<editType>").Append(txtCrosswalkEditType.Text).Append("</editType>").Append("\n");
                    sOutput.Append("</crosswalk>").Append("\n");
                    //dlcw.path = this.txtCrosswalkPath.Text;
                    //dlcw.sourceSystem = this.txtCrosswalkSourceSystem.Text;
                    //dlcw.sourceType = this.txtCrosswalkSourceType.Text;
                    //dlcw.sourceDate = this.dateTimeCrosswalkSourceDate.Text;
                    //dlcw.linesToSkip = this.txtCrosswalkLineToSkip.Text;
                    //dlcw.editType = this.txtCrosswalkSourceType.Text;
                }

                if (chkDemographicsEnabled.Checked)
                {
                    sOutput.Append("<demographics>").Append("\n");
                    sOutput.Append("<path>").Append(txtDemographicsPath.Text).Append("</path>").Append("\n");
                    sOutput.Append("<sourceSystem>").Append(txtDemographicsSourceSystem.Text).Append("</sourceSystem>").Append("\n");
                    sOutput.Append("<sourceType>").Append(txtDemographicsSourceType.Text).Append("</sourceType>").Append("\n");
                    sOutput.Append("<sourceDate>").Append(dateTimeDemographicsSourceDate.Text).Append("</sourceDate>").Append("\n");
                    sOutput.Append("<linesToSkip>").Append(txtDemographicsLineToSkip.Text).Append("</linesToSkip>").Append("\n");
                    sOutput.Append("<editType>").Append(txtDemographicsEditType.Text).Append("</editType>").Append("\n");
                    sOutput.Append("</demographics>").Append("\n");
                    //dld.path = this.txtDemographicsPath.Text;
                    //dld.sourceSystem = this.txtDemographicsSourceSystem.Text;
                    //dld.sourceType = this.txtDemographicsSourceType.Text;
                    //dld.sourceDate = this.dateTimeDemographicsSourceDate.Text;
                    //dld.linesToSkip = this.txtDemographicsLineToSkip.Text;
                    //dld.editType = this.txtDemographicsSourceType.Text;
                }

                if (chkDocumentsEnabled.Checked)
                {
                    sOutput.Append("<documents>").Append("\n");
                    sOutput.Append("<path>").Append(txtDocumentsPath.Text).Append("</path>").Append("\n");
                    sOutput.Append("<sourceSystem>").Append(txtDocumentsSourceSystem.Text).Append("</sourceSystem>").Append("\n");
                    sOutput.Append("<sourceType>").Append(txtDocumentsSourceType.Text).Append("</sourceType>").Append("\n");
                    sOutput.Append("<sourceDate>").Append(dateTimeDocumentsSourceDate.Text).Append("</sourceDate>").Append("\n");
                    sOutput.Append("<linesToSkip>").Append(txtDocumentsLineToSkip.Text).Append("</linesToSkip>").Append("\n");
                    sOutput.Append("<editType>").Append(txtDocumentsEditType.Text).Append("</editType>").Append("\n");
                    sOutput.Append("</documents>").Append("\n");
                    //dldoc.path = this.txtDocumentsPath.Text;
                    //dldoc.sourceSystem = this.txtDocumentsSourceSystem.Text;
                    //dldoc.sourceType = this.txtDocumentsSourceType.Text;
                    //dldoc.sourceDate = this.dateTimeDocumentsSourceDate.Text;
                    //dldoc.linesToSkip = this.txtDocumentsLineToSkip.Text;
                    //dldoc.editType = this.txtDocumentsSourceType.Text;
                }

                if (chkEncountersEnabled.Checked)
                {
                    sOutput.Append("<encounters>").Append("\n");
                    sOutput.Append("<path>").Append(txtEncountersPath.Text).Append("</path>").Append("\n");
                    sOutput.Append("<sourceSystem>").Append(txtEncountersSourceSystem.Text).Append("</sourceSystem>").Append("\n");
                    sOutput.Append("<sourceType>").Append(txtEncountersSourceType.Text).Append("</sourceType>").Append("\n");
                    sOutput.Append("<sourceDate>").Append(dateTimeEncountersSourceDate.Text).Append("</sourceDate>").Append("\n");
                    sOutput.Append("<linesToSkip>").Append(txtEncountersLineToSkip.Text).Append("</linesToSkip>").Append("\n");
                    sOutput.Append("<editType>").Append(txtEncountersEditType.Text).Append("</editType>").Append("\n");
                    sOutput.Append("</encounters>").Append("\n");
                    //dle.path = this.txtEncountersPath.Text;
                    //dle.sourceSystem = this.txtEncountersSourceSystem.Text;
                    //dle.sourceType = this.txtEncountersSourceType.Text;
                    //dle.sourceDate = this.dateTimeEncountersSourceDate.Text;
                    //dle.linesToSkip = this.txtEncountersLineToSkip.Text;
                    //dle.editType = this.txtEncountersSourceType.Text;
                }

                if (chkEventsEnabled.Checked)
                {
                    sOutput.Append("<events>").Append("\n");
                    sOutput.Append("<path>").Append(txtEventsPath.Text).Append("</path>").Append("\n");
                    sOutput.Append("<sourceSystem>").Append(txtEventsSourceSystem.Text).Append("</sourceSystem>").Append("\n");
                    sOutput.Append("<sourceType>").Append(txtEventsSourceType.Text).Append("</sourceType>").Append("\n");
                    sOutput.Append("<sourceDate>").Append(dateTimeEventsSourceDate.Text).Append("</sourceDate>").Append("\n");
                    sOutput.Append("<linesToSkip>").Append(txtEventsLineToSkip.Text).Append("</linesToSkip>").Append("\n");
                    sOutput.Append("<editType>").Append(txtEventsEditType.Text).Append("</editType>").Append("\n");
                    sOutput.Append("</events>").Append("\n");
                    //dlev.path = this.txtEventsPath.Text;
                    //dlev.sourceSystem = this.txtEventsSourceSystem.Text;
                    //dlev.sourceType = this.txtEventsSourceType.Text;
                    //dlev.sourceDate = this.dateTimeEventsSourceDate.Text;
                    //dlev.linesToSkip = this.txtEventsLineToSkip.Text;
                    //dlev.editType = this.txtEventsSourceType.Text;
                }

                if (chkProblemsEnabled.Checked)
                {
                    sOutput.Append("<problems>").Append("\n");
                    sOutput.Append("<path>").Append(txtProblemsPath.Text).Append("</path>").Append("\n");
                    sOutput.Append("<sourceSystem>").Append(txtProblemsSourceSystem.Text).Append("</sourceSystem>").Append("\n");
                    sOutput.Append("<sourceType>").Append(txtProblemsSourceType.Text).Append("</sourceType>").Append("\n");
                    sOutput.Append("<sourceDate>").Append(dateTimeProblemsSourceDate.Text).Append("</sourceDate>").Append("\n");
                    sOutput.Append("<linesToSkip>").Append(txtProblemsLineToSkip.Text).Append("</linesToSkip>").Append("\n");
                    sOutput.Append("<editType>").Append(txtProblemsEditType.Text).Append("</editType>").Append("\n");
                    sOutput.Append("</problems>").Append("\n");
                    //dlp.path = this.txtProblemsPath.Text;
                    //dlp.sourceSystem = this.txtProblemsSourceSystem.Text;
                    //dlp.sourceType = this.txtProblemsSourceType.Text;
                    //dlp.sourceDate = this.dateTimeProblemsSourceDate.Text;
                    //dlp.linesToSkip = this.txtProblemsLineToSkip.Text;
                    //dlp.editType = this.txtProblemsSourceType.Text;
                }

                if (chkProblemsMORAEnabled.Checked)
                {
                    sOutput.Append("<problemsmora>").Append("\n");
                    sOutput.Append("<path>").Append(txtProblemsMORAPath.Text).Append("</path>").Append("\n");
                    sOutput.Append("<sourceSystem>").Append(txtProblemsMORASourceSystem.Text).Append("</sourceSystem>").Append("\n");
                    sOutput.Append("<sourceType>").Append(txtProblemsMORASourceType.Text).Append("</sourceType>").Append("\n");
                    sOutput.Append("<sourceDate>").Append(dateTimeProblemsMORASourceDate.Text).Append("</sourceDate>").Append("\n");
                    sOutput.Append("<linesToSkip>").Append(txtProblemsMORALineToSkip.Text).Append("</linesToSkip>").Append("\n");
                    sOutput.Append("<editType>").Append(txtProblemsMORAEditType.Text).Append("</editType>").Append("\n");
                    sOutput.Append("</problemsmora>").Append("\n");
                    //dlma.path = this.txtProblemsMORAPath.Text;
                    //dlma.sourceSystem = this.txtProblemsMORASourceSystem.Text;
                    //dlma.sourceType = this.txtProblemsMORASourceType.Text;
                    //dlma.sourceDate = this.dateTimeProblemsMORASourceDate.Text;
                    //dlma.linesToSkip = this.txtProblemsMORALineToSkip.Text;
                    //dlma.editType = this.txtProblemsMORASourceType.Text;
                }

                if (chkProblemsMORBEnabled.Checked)
                {
                    sOutput.Append("<problemsmorb>").Append("\n");
                    sOutput.Append("<path>").Append(txtProblemsMORBPath.Text).Append("</path>").Append("\n");
                    sOutput.Append("<sourceSystem>").Append(txtProblemsMORBSourceSystem.Text).Append("</sourceSystem>").Append("\n");
                    sOutput.Append("<sourceType>").Append(txtProblemsMORBSourceType.Text).Append("</sourceType>").Append("\n");
                    sOutput.Append("<sourceDate>").Append(dateTimeProblemsMORBSourceDate.Text).Append("</sourceDate>").Append("\n");
                    sOutput.Append("<linesToSkip>").Append(txtProblemsMORBLineToSkip.Text).Append("</linesToSkip>").Append("\n");
                    sOutput.Append("<editType>").Append(txtProblemsMORBEditType.Text).Append("</editType>").Append("\n");
                    sOutput.Append("</problemsmorb>").Append("\n");
                    //dlmb.path = this.txtProblemsMORBPath.Text;
                    //dlmb.sourceSystem = this.txtProblemsMORBSourceSystem.Text;
                    //dlmb.sourceType = this.txtProblemsMORBSourceType.Text;
                    //dlmb.sourceDate = this.dateTimeProblemsMORBSourceDate.Text;
                    //dlmb.linesToSkip = this.txtProblemsMORBLineToSkip.Text;
                    //dlmb.editType = this.txtProblemsMORBSourceType.Text;
                }

                if (chkProblemsMORCEnabled.Checked)
                {
                    sOutput.Append("<problemsmorc>").Append("\n");
                    sOutput.Append("<path>").Append(txtProblemsMORCPath.Text).Append("</path>").Append("\n");
                    sOutput.Append("<sourceSystem>").Append(txtProblemsMORCSourceSystem.Text).Append("</sourceSystem>").Append("\n");
                    sOutput.Append("<sourceType>").Append(txtProblemsMORCSourceType.Text).Append("</sourceType>").Append("\n");
                    sOutput.Append("<sourceDate>").Append(dateTimeProblemsMORCSourceDate.Text).Append("</sourceDate>").Append("\n");
                    sOutput.Append("<linesToSkip>").Append(txtProblemsMORCLineToSkip.Text).Append("</linesToSkip>").Append("\n");
                    sOutput.Append("<editType>").Append(txtProblemsMORCEditType.Text).Append("</editType>").Append("\n");
                    sOutput.Append("</problemsmorc>").Append("\n");
                    //dlmc.path = this.txtProblemsMORCPath.Text;
                    //dlmc.sourceSystem = this.txtProblemsMORCSourceSystem.Text;
                    //dlmc.sourceType = this.txtProblemsMORCSourceType.Text;
                    //dlmc.sourceDate = this.dateTimeProblemsMORCSourceDate.Text;
                    //dlmc.linesToSkip = this.txtProblemsMORCLineToSkip.Text;
                    //dlmc.editType = this.txtProblemsMORCSourceType.Text;
                }

                if (chkProblemsRAPSEnabled.Checked)
                {
                    sOutput.Append("<!-- NOTE: Unlike other base objects, this value is a directory rather than a file -->").Append("\n");
                    sOutput.Append("<problemsraps>").Append("\n");
                    sOutput.Append("<path>").Append(txtProblemsRAPSPath.Text).Append("</path>").Append("\n");
                    sOutput.Append("<sourceSystem>").Append(txtProblemsRAPSSourceSystem.Text).Append("</sourceSystem>").Append("\n");
                    sOutput.Append("<sourceType>").Append(txtProblemsRAPSSourceType.Text).Append("</sourceType>").Append("\n");
                    sOutput.Append("<sourceDate>").Append(dateTimeProblemsRAPSSourceDate.Text).Append("</sourceDate>").Append("\n");
                    sOutput.Append("<linesToSkip>").Append(txtProblemsRAPSLineToSkip.Text).Append("</linesToSkip>").Append("\n");
                    sOutput.Append("<editType>").Append(txtProblemsRAPSEditType.Text).Append("</editType>").Append("\n");
                    sOutput.Append("</problemsraps>").Append("\n");
                    //dlmc.path = this.txtProblemsMORCPath.Text;
                    //dlmc.sourceSystem = this.txtProblemsMORCSourceSystem.Text;
                    //dlmc.sourceType = this.txtProblemsMORCSourceType.Text;
                    //dlmc.sourceDate = this.dateTimeProblemsMORCSourceDate.Text;
                    //dlmc.linesToSkip = this.txtProblemsMORCLineToSkip.Text;
                    //dlmc.editType = this.txtProblemsMORCSourceType.Text;
                }
                if (chkProceduresEnabled.Checked)
                {
                    sOutput.Append("<procedures>").Append("\n");
                    sOutput.Append("<path>").Append(txtProceduresPath.Text).Append("</path>").Append("\n");
                    sOutput.Append("<sourceSystem>").Append(txtProceduresSourceSystem.Text).Append("</sourceSystem>").Append("\n");
                    sOutput.Append("<sourceType>").Append(txtProceduresSourceType.Text).Append("</sourceType>").Append("\n");
                    sOutput.Append("<sourceDate>").Append(dateTimeProceduresSourceDate.Text).Append("</sourceDate>").Append("\n");
                    sOutput.Append("<linesToSkip>").Append(txtProceduresLineToSkip.Text).Append("</linesToSkip>").Append("\n");
                    sOutput.Append("<editType>").Append(txtProceduresEditType.Text).Append("</editType>").Append("\n");
                    sOutput.Append("</procedures>").Append("\n");
                    //dlproc.path = this.txtProceduresPath.Text;
                    //dlproc.sourceSystem = this.txtProceduresSourceSystem.Text;
                    //dlproc.sourceType = this.txtProceduresSourceType.Text;
                    //dlproc.sourceDate = this.dateTimeProceduresSourceDate.Text;
                    //dlproc.linesToSkip = this.txtProceduresLineToSkip.Text;
                    //dlproc.editType = this.txtProceduresSourceType.Text;
                }

                if (chkProvidersEnabled.Checked)
                {
                    sOutput.Append("<providers>").Append("\n");
                    sOutput.Append("<path>").Append(txtProvidersPath.Text).Append("</path>").Append("\n");
                    sOutput.Append("<sourceSystem>").Append(txtProvidersSourceSystem.Text).Append("</sourceSystem>").Append("\n");
                    sOutput.Append("<sourceType>").Append(txtProvidersSourceType.Text).Append("</sourceType>").Append("\n");
                    sOutput.Append("<sourceDate>").Append(dateTimeProvidersSourceDate.Text).Append("</sourceDate>").Append("\n");
                    sOutput.Append("<linesToSkip>").Append(txtProvidersLineToSkip.Text).Append("</linesToSkip>").Append("\n");
                    sOutput.Append("<editType>").Append(txtProvidersEditType.Text).Append("</editType>").Append("\n");
                    sOutput.Append("</providers>").Append("\n");
                    //dlprov.path = this.txtProvidersPath.Text;
                    //dlprov.sourceSystem = this.txtProvidersSourceSystem.Text;
                    //dlprov.sourceType = this.txtProvidersSourceType.Text;
                    //dlprov.sourceDate = this.dateTimeProvidersSourceDate.Text;
                    //dlprov.linesToSkip = this.txtProvidersLineToSkip.Text;
                    //dlprov.editType = this.txtProvidersSourceType.Text;
                }
                sOutput.Append("</application>").Append("\n");
                // write out
                ProgressBar.Value = 0;
                using(StreamWriter w = File.CreateText(txtConfigFilePath.Text))
                {
                    w.WriteLine(sOutput.ToString().Replace("\\","/"));
                    ProgressBar.Value = 100;
                }
                //ProgressBar.Value = 0;

            //XmlSerializer xs = new XmlSerializer(typeof(DLConfig));
            //TextWriter tw = new StreamWriter(@"c:\temp\test.xml");
            //xs.Serialize(tw, dlc);
            
            //XmlSerializer xs = new XmlSerializer(typeof(DLProblems));
            //xs.Serialize(tw, dlp);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error: " + ex.Message);
            }
        }

        private void btnRunDataLoader_Click(object sender, EventArgs e)
        {
            StringBuilder sCommand = new StringBuilder();
            Process pProcess = new Process();
            string sOutput;
            try
            {
                string sWorkingDir = txtWorkingDirectory.Text;
                sWorkingDir = sWorkingDir.Replace("\\", "/");
                sCommand.Append("java -XX:MaxPermSize=1g -Xmx8g -Dconfig=").Append("\"").Append(txtConfigFilePath.Text).Append("\"");
                if (chkDebugMode.Checked)
                    sCommand.Append(" -DworkingDir=").Append("\"").Append(sWorkingDir).Append("\"");
                sCommand.Append(" -cp \".;").Append(txtDataLoaderFilePath.Text).Append("\" com.apixio.loader.PatientLoader");
                Debug.WriteLine(sCommand.ToString());

                File.WriteAllText(txtWorkingDirectory.Text+"\\RunThis.bat", sCommand.ToString());

                pProcess.StartInfo.FileName = txtWorkingDirectory.Text + "\\RunThis.bat";
                pProcess.StartInfo.UseShellExecute = false;
                pProcess.StartInfo.RedirectStandardOutput = true;
                //pProcess.StartInfo.
                pProcess.StartInfo.CreateNoWindow = false;
                pProcess.Start();
                sOutput = pProcess.StandardOutput.ReadToEnd();

                //Wait for process to finish
                pProcess.WaitForExit();
            }
            catch (Exception EX)
            {
                Debug.WriteLine("Error running data loader. The error is: " + EX.Message);
            }
        }
        //private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        //{
        //    // Open App.Config of executable
        //    System.Configuration.Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
        //    // Add an Application Setting.
        //    //config.AppSettings.Settings.Remove("LastDateFeesChecked");
        //    config.AppSettings.Settings.Add("LastDateFeesChecked", DateTime.Now.ToShortDateString());
        //    // Save the configuration file.
        //    config.Save(ConfigurationSaveMode.Modified);
        //    // Force a reload of a changed section.
        //    ConfigurationManager.RefreshSection("appSettings");
        //}

    }
}
