using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;

public static class Extensions
{
    public static string ToXml(this object obj)
    {
        XmlSerializer s = new XmlSerializer(obj.GetType());
        using (StringWriter writer = new StringWriter())
        {
            s.Serialize(writer, obj);
            return writer.ToString();
        }
    }

    public static T FromXml<T>(this string data)
    {
        XmlSerializer s = new XmlSerializer(typeof(T));
        using (StringReader reader = new StringReader(data))
        {
            object obj = s.Deserialize(reader);
            return (T)obj;
        }
    }
                //    DLConfig dlc = new DLConfig();
            
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


                //sOutput.Append("<?xml version=\"1.0\" encoding=\"UTF-8\"?>").Append("\\n").Append("<application>").Append("\\n");

                //dlc.workingDir = this.txtWorkingDirectory.ToString();
                //dlc.defaultAuthority = this.txtDefaultAuthority.ToString();
                //dlc.primaryAuthority = this.txtPrimaryAuthority.ToString();

                //sOutput.Append("<workingDir>").
                //dlc.sourceSystem = this.txtSourceSystem.ToString();
                //dlc.sourceType = this.txtSourceType.ToString();
                //dlc.sourceDate = this.dateTimeSourceDate.ToString();

                //if (this.chkWorkflowDeleteOnClose.Checked)
                //    dlw.deleteOnClose = "true";
                //else
                //    dlw.deleteOnClose = "false";
                //if (this.chkWorkflowValidation.Checked)
                //    dlwv.enabled = "true";
                //else
                //    dlwv.enabled = "false";
            
                //dlwm.enabled = this.chkWorkflowMap.Text;
                //dlwm.overwrite = this.chkWorkflowMapOverwrite.Text;
                //if (this.chkWorkflowReduce.Checked)
                //    dlwr.enabled = "true";
                //else
                //    dlwr.enabled = "false";
                //if (this.chkWorkflowReduceOverwrite.Checked)
                //    dlwr.overwrite = "true";
                //else 
                //    dlwr.overwrite = "false";

                //if (this.chkWorkflowOutput.Checked)
                //    dlwo.enabled = "true";
                //else
                //    dlwo.enabled="false";
                //dlwo.path = this.txtWorkflowOutputFilePath.ToString();
                //if (this.chkWorkflowUpload.Checked)
                //    dlwu.enabled = "true";
                //else
                //    dlwu.enabled = "false";
                //if (this.chkWorkflowUploadOverwrite.Checked)
                //    dlwu.overwrite = "true";
                //else
                //    dlwu.overwrite = "false";

                //dlcs.CPTLabel = this.txtCodingSystemCPTLabel.ToString();
                //dlcs.ICD9DXLabel = this.txtCodingSystemICD9DX.ToString();
                //dlcs.ICD9SGLabel = this.txtCodingSystemICD9SG.ToString();

                //dls.key = this.txtSecurityKey.ToString();
                //dls.algorithm = this.txtSecurityAlgorithm.ToString();

                //dlep.server = this.txtEndpointServer.ToString();
                //dlep.batchName = this.txtEndpointBatchName.ToString();
                //dlep.username = this.txtEndpointUserName.ToString();
                //dlep.password = this.txtEndpointPassword.ToString();

                //if (chkCoverageEnabled.Checked)
                //{
                //    dlcv.path = this.txtCoveragePath.ToString();
                //    dlcv.sourceSystem = this.txtCoverageSourceSystem.ToString();
                //    dlcv.sourceType = this.txtCoverageSourceType.ToString();
                //    dlcv.sourceDate = this.dateTimeCoverageSourceDate.ToString();
                //    dlcv.linesToSkip = this.txtCrosswalkLineToSkip.ToString();
                //    dlcv.editType = this.txtCoverageSourceType.ToString();
                //}

                //if (chkCrosswalkEnabled.Checked)
                //{
                //    dlcw.path = this.txtCrosswalkPath.ToString();
                //    dlcw.sourceSystem = this.txtCrosswalkSourceSystem.ToString();
                //    dlcw.sourceType = this.txtCrosswalkSourceType.ToString();
                //    dlcw.sourceDate = this.dateTimeCrosswalkSourceDate.ToString();
                //    dlcw.linesToSkip = this.txtCrosswalkLineToSkip.ToString();
                //    dlcw.editType = this.txtCrosswalkSourceType.ToString();
                //}

                //if (chkDemographicsEnabled.Checked)
                //{
                //    dld.path = this.txtDemographicsPath.ToString();
                //    dld.sourceSystem = this.txtDemographicsSourceSystem.ToString();
                //    dld.sourceType = this.txtDemographicsSourceType.ToString();
                //    dld.sourceDate = this.dateTimeDemographicsSourceDate.ToString();
                //    dld.linesToSkip = this.txtDemographicsLineToSkip.ToString();
                //    dld.editType = this.txtDemographicsSourceType.ToString();
                //}

                //if (chkDocumentsEnabled.Checked)
                //{
                //    dldoc.path = this.txtDocumentsPath.ToString();
                //    dldoc.sourceSystem = this.txtDocumentsSourceSystem.ToString();
                //    dldoc.sourceType = this.txtDocumentsSourceType.ToString();
                //    dldoc.sourceDate = this.dateTimeDocumentsSourceDate.ToString();
                //    dldoc.linesToSkip = this.txtDocumentsLineToSkip.ToString();
                //    dldoc.editType = this.txtDocumentsSourceType.ToString();
                //}

                //if (chkEncountersEnabled.Checked)
                //{
                //    dle.path = this.txtEncountersPath.ToString();
                //    dle.sourceSystem = this.txtEncountersSourceSystem.ToString();
                //    dle.sourceType = this.txtEncountersSourceType.ToString();
                //    dle.sourceDate = this.dateTimeEncountersSourceDate.ToString();
                //    dle.linesToSkip = this.txtEncountersLineToSkip.ToString();
                //    dle.editType = this.txtEncountersSourceType.ToString();
                //}

                //if (chkEventsEnabled.Checked)
                //{
                //    dlev.path = this.txtEventsPath.ToString();
                //    dlev.sourceSystem = this.txtEventsSourceSystem.ToString();
                //    dlev.sourceType = this.txtEventsSourceType.ToString();
                //    dlev.sourceDate = this.dateTimeEventsSourceDate.ToString();
                //    dlev.linesToSkip = this.txtEventsLineToSkip.ToString();
                //    dlev.editType = this.txtEventsSourceType.ToString();
                //}

                //if (chkProblemsEnabled.Checked)
                //{
                //    dlp.path = this.txtProblemsPath.ToString();
                //    dlp.sourceSystem = this.txtProblemsSourceSystem.ToString();
                //    dlp.sourceType = this.txtProblemsSourceType.ToString();
                //    dlp.sourceDate = this.dateTimeProblemsSourceDate.ToString();
                //    dlp.linesToSkip = this.txtProblemsLineToSkip.ToString();
                //    dlp.editType = this.txtProblemsSourceType.ToString();
                //}

                //if (chkProblemsMORAEnabled.Checked)
                //{
                //    dlma.path = this.txtProblemsMORAPath.ToString();
                //    dlma.sourceSystem = this.txtProblemsMORASourceSystem.ToString();
                //    dlma.sourceType = this.txtProblemsMORASourceType.ToString();
                //    dlma.sourceDate = this.dateTimeProblemsMORASourceDate.ToString();
                //    dlma.linesToSkip = this.txtProblemsMORALineToSkip.ToString();
                //    dlma.editType = this.txtProblemsMORASourceType.ToString();
                //}

                //if (chkProblemsMORBEnabled.Checked)
                //{
                //    dlmb.path = this.txtProblemsMORBPath.ToString();
                //    dlmb.sourceSystem = this.txtProblemsMORBSourceSystem.ToString();
                //    dlmb.sourceType = this.txtProblemsMORBSourceType.ToString();
                //    dlmb.sourceDate = this.dateTimeProblemsMORBSourceDate.ToString();
                //    dlmb.linesToSkip = this.txtProblemsMORBLineToSkip.ToString();
                //    dlmb.editType = this.txtProblemsMORBSourceType.ToString();
                //}

                //if (chkProblemsRAPSEnabled.Checked)
                //{
                //    dlmc.path = this.txtProblemsMORCPath.ToString();
                //    dlmc.sourceSystem = this.txtProblemsMORCSourceSystem.ToString();
                //    dlmc.sourceType = this.txtProblemsMORCSourceType.ToString();
                //    dlmc.sourceDate = this.dateTimeProblemsMORCSourceDate.ToString();
                //    dlmc.linesToSkip = this.txtProblemsMORCLineToSkip.ToString();
                //    dlmc.editType = this.txtProblemsMORCSourceType.ToString();
                //}

                //if (chkProceduresEnabled.Checked)
                //{
                //    dlproc.path = this.txtProceduresPath.ToString();
                //    dlproc.sourceSystem = this.txtProceduresSourceSystem.ToString();
                //    dlproc.sourceType = this.txtProceduresSourceType.ToString();
                //    dlproc.sourceDate = this.dateTimeProceduresSourceDate.ToString();
                //    dlproc.linesToSkip = this.txtProceduresLineToSkip.ToString();
                //    dlproc.editType = this.txtProceduresSourceType.ToString();
                //}

                //if (chkProvidersEnabled.Checked)
                //{
                //    dlprov.path = this.txtProvidersPath.ToString();
                //    dlprov.sourceSystem = this.txtProvidersSourceSystem.ToString();
                //    dlprov.sourceType = this.txtProvidersSourceType.ToString();
                //    dlprov.sourceDate = this.dateTimeProvidersSourceDate.ToString();
                //    dlprov.linesToSkip = this.txtProvidersLineToSkip.ToString();
                //    dlprov.editType = this.txtProvidersSourceType.ToString();
                //}

}