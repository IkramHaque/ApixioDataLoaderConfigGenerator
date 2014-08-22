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
using System.Diagnostics;
using System.Configuration;

namespace ApixioDataLoaderConfigGenerator
{
            

    public partial class AddNewItem : Form
    {
        private Boolean fileOpened = false;
        private string openFileName;
        //private string openFolder;

        public AddNewItem()
        {
            InitializeComponent();
        }

        public AddNewItem(string _FileType, string _FilePath, string _EditType, string _SkipHeader, string _UseDefault)
        {
            InitializeComponent();

            //Load Edit Items
            cboFileType.Text =  _FileType;
            txtPath.Text = _FilePath;
            cboEditType.Text = _EditType;
            if (_SkipHeader == "Skip Header")
            {
                chkSkipHeader.Checked = true;
            }
            else
            {
                chkSkipHeader.Checked = false;
            } 
            if (_UseDefault == "Use Default")
            {
                chkUseDefaultSource.Checked = true;
            }
            else
            {
                string[] notDefault = _UseDefault.Split(',');
                chkUseDefaultSource.Checked = false;
                txtSourceSystem.Text = notDefault[0];
                txtSourceType.Text = notDefault[1];
                dateTimeSourceDate.Text = notDefault[2];
            }

        }

        private void btnCancelNew_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnAddNewPath_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.OpenFileDialog openFileDialog1 = new OpenFileDialog();
            System.Windows.Forms.FolderBrowserDialog folderBrowserDialogWorkingDirectory = new FolderBrowserDialog();

            if (!fileOpened)
            {
                openFileDialog1.InitialDirectory = folderBrowserDialogWorkingDirectory.SelectedPath;
                openFileDialog1.DefaultExt = "csv";
                openFileDialog1.Filter = "Text files (*.csv)|*.csv|All files (*.*)|*.*";
                openFileDialog1.FileName = null;
            }


            folderBrowserDialogWorkingDirectory.ShowNewFolderButton = false;
            DialogResult _result = openFileDialog1.ShowDialog();
            if (_result == DialogResult.OK)
            {
                openFileName = openFileDialog1.FileName;
                txtPath.Text = openFileName;
            }

        }

        private void btnSaveNew_Click(object sender, EventArgs e)
        {
            //var MainWindow = new FormDataLoader();

            //string[] row0 = {"true", "Hello", "There", "World" };
            try
            {
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                
                //this.Close();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
            //dgApixioFiles
            //MainWindow.dgApixioFiles.Rows.Add(row0);
            
            
            //this.Close();

        }

        private void chkUseDefaultSource_CheckedChanged(object sender, EventArgs e)
        {
            if (!chkUseDefaultSource.Checked)
            {
                this.txtSourceSystem.Enabled=true;
                this.txtSourceType.Enabled=true;
                this.dateTimeSourceDate.Enabled = true;
            }
            else
            {
                this.txtSourceSystem.Enabled = false;
                this.txtSourceType.Enabled = false;
                this.dateTimeSourceDate.Enabled = false;

            }
        }

        private void AddNewItem_Load(object sender, EventArgs e)
        {
            string thisDirectory = Directory.GetCurrentDirectory();
            string line="";
            int lineNum = 0;
            string[] fileType;
            string[] editType;
            FileStream thisConfig = new FileStream(thisDirectory + "\\ApixioDataLoaderConfig.txt", FileMode.Open, FileAccess.Read);
            try
            {
                
                //Read combo items
                using (TextReader reader = new StreamReader(thisConfig))
                {
                    
                    thisConfig = null;
                    while ((line = reader.ReadLine())!= null)
                    {
                        lineNum++;
                        switch (lineNum)

                        {
                            case 1:
                            fileType = line.Split(',');
                            for (int i=0; i < fileType.Length; i++)
                            {
                                this.cboFileType.Items.Add(fileType[i]);
                            }
                            break;
                            case 2:
                        
                            editType = line.Split(',');
                            for (int i=0; i < editType.Length; i++)
                            {
                                this.cboEditType.Items.Add(editType[i]);
                            }
                                //set to Active
                            this.cboEditType.SelectedIndex = 0;
                            break;
                        }
                    }
                }
            }
            finally
            {
                if (thisConfig != null)
                    thisConfig.Dispose();
            }
            //read the 
        }

        public string FileType
        {
            get
            {
                return cboFileType.Text;
            }
            set
            {
                cboFileType.Text = FileType;
            }
        }
        public string Path
        {
            get
            {
                return txtPath.Text;
            }
            set
            {
                txtPath.Text = Path;
            }
        }
        public string EditType
        {
            get
            {
                return cboEditType.Text;
            }
            set
            {
                cboEditType.Text = EditType;
            }
        }
        public string SkipHeader
        {
           get
           {
                if (chkSkipHeader.Checked) 
                {
                    return "Skip Header";
                }
               else
                {
                    return "No Header Skip";
                }
           }
            set
            {
                if (SkipHeader=="Skip Header")
                {
                    chkSkipHeader.Checked = true;
                }
                else
                {
                    chkSkipHeader.Checked = false;
                }
            }
        }

        public string DefaultSource
        {
            get
            {
                if (chkUseDefaultSource.Checked)
                {
                    return "Use Default";
                }
                else
                {
                    return txtSourceSystem.Text + "," + txtSourceType.Text + "," + dateTimeSourceDate.Text;
                }
            }
            set
            {
                if (DefaultSource == "Use Default")
                {
                    chkUseDefaultSource.Checked = true;
                }
                else
                {
                    string[] notDefault = DefaultSource.Split(',');
                    chkUseDefaultSource.Checked = false;
                    txtSourceSystem.Text = notDefault[0];
                    txtSourceType.Text = notDefault[1];
                    dateTimeSourceDate.Text = notDefault[2]; 
                }
            }
        }

        private void txtSourceSystem_TextChanged(object sender, EventArgs e)
        {
            //Check for comma
            if (txtSourceSystem.Text.Contains(","))
            {
                MessageBox.Show("Text may not contain any commas!", "Error", MessageBoxButtons.OK);
                txtSourceSystem.Text = txtSourceSystem.Text.Replace(",", "");
            }
        }

        private void txtSourceType_TextChanged(object sender, EventArgs e)
        {
            //Check for comma
            if (txtSourceType.Text.Contains(","))
            {
                MessageBox.Show("Text may not contain any commas!", "Error", MessageBoxButtons.OK);
                txtSourceType.Text = txtSourceType.Text.Replace(",", "");
            }

        }

    }

}

