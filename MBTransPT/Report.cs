using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using System.IO;
using CrystalDecisions.Shared;

namespace MBTransPT
{
    public partial class Report : Form
    {
        public Report(ReportDocument rep)
        {

            InitializeComponent();
           

            TextReader textReader = new StreamReader("c:\\Program files\\IT\\MB\\dblogon.txt");
            string uid = textReader.ReadLine();
            string pwd = textReader.ReadLine();
            string server = textReader.ReadLine();
            string db = textReader.ReadLine();
            textReader.Close();

            //rep.SetDatabaseLogon(uid, pwd);

            ConnectionInfo crConnectionInfo = new ConnectionInfo();
            crConnectionInfo.ServerName = server;
            crConnectionInfo.DatabaseName = db;
            crConnectionInfo.UserID = uid;
            crConnectionInfo.Password = pwd;

            TableLogOnInfos crTableLogonInfos = new TableLogOnInfos();

            foreach (CrystalDecisions.CrystalReports.Engine.Table table in rep.Database.Tables)
            {
                TableLogOnInfo crTableLogonInfo = new TableLogOnInfo();
                crTableLogonInfo.TableName = table.Name;
                crTableLogonInfo.ConnectionInfo = crConnectionInfo;
                crTableLogonInfos.Add(crTableLogonInfo);
                table.ApplyLogOnInfo(crTableLogonInfo);
            }

            crystalReportViewer1.LogOnInfo = crTableLogonInfos;
            crystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            crystalReportViewer1.ReportSource = rep;
        }
    }
}