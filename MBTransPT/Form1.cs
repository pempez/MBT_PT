using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MBTransPT
{
    public partial class Form1 : Form
    {
        string connection = "";
        public Form1()
        {
            InitializeComponent();
        }

      

        private void komitentiToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void osnovniPodaciToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Firma f1 = new Firma();
            this.groupBox1.Controls.Clear();
            this.groupBox1.Controls.Add(f1.GetGroupBox());
            f1.GetGroupBox().Dock = DockStyle.Fill;
            f1.GetGroupBox().Show(); 
        }

        private void radniciToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormKomitenti f1 = new FormKomitenti();
            this.groupBox1.Controls.Clear();
            this.groupBox1.Controls.Add(f1.GetGroupBox());
            f1.GetGroupBox().Dock = DockStyle.Fill;
            f1.GetGroupBox().Show(); 
        }

        private void naloziToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormNoviNalog f1 = new FormNoviNalog();
            this.groupBox1.Controls.Clear();
            this.groupBox1.Controls.Add(f1.GetGroupBox());
            f1.GetGroupBox().Dock = DockStyle.Fill;
            f1.GetGroupBox().Show(); 
        }

        private void drugiNaloziToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormNoviNalog f1 = new FormNoviNalog("aa");
            this.groupBox1.Controls.Clear();
            this.groupBox1.Controls.Add(f1.GetGroupBox());
            f1.GetGroupBox().Dock = DockStyle.Fill;
            f1.GetGroupBox().Show();
        }

        private void spisakNalogaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormSpisakNaloga f1 = new FormSpisakNaloga();
            this.groupBox1.Controls.Clear();
            this.groupBox1.Controls.Add(f1.GetGroupBox());
            f1.GetGroupBox().Dock = DockStyle.Fill;
            f1.GetGroupBox().Show(); 
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
             TreeNode node = ((TreeView)sender).SelectedNode;
             switch (node.Name)
             {
                 case "NodeRadnici":
                     node.Expand();
                     radniciToolStripMenuItem_Click(null, null);
                     treeView1.SelectedNode = node;
                     treeView1.SelectedNode = null;
                     break;
                 case "NodeOsnovniPodaci":
                     node.Expand();
                     osnovniPodaciToolStripMenuItem_Click(null, null);
                     treeView1.SelectedNode = node;
                     treeView1.SelectedNode = null;
                     break;
                 case "NodeRelacije":
                     node.Expand();
                     relacijeToolStripMenuItem_Click(null, null);
                     treeView1.SelectedNode = node;
                     treeView1.SelectedNode = null;
                     break;
                 case "NodeLiceRelacije":
                     node.Expand();
                      liceRelacijeToolStripMenuItem_Click(null, null);
                     treeView1.SelectedNode = node;
                     treeView1.SelectedNode = null;
                     break;
                 case "NodeNalozi":
                     node.Expand();
                     naloziToolStripMenuItem_Click(null, null);
                     treeView1.SelectedNode = node;
                     treeView1.SelectedNode = null;
                     break;
                 case "NodeSpisakNaloga":
                     node.Expand();
                     spisakNalogaToolStripMenuItem_Click(null, null);
                     treeView1.SelectedNode = node;
                     treeView1.SelectedNode = null;
                     break;
                 case "NodeDrugiNalozi" :
                     node.Expand();
                     drugiNaloziToolStripMenuItem_Click(null, null);
                     treeView1.SelectedNode = node;
                     treeView1.SelectedNode = null;
                     break;

             }

            
        }

        private void relacijeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormRelacije f1 = new FormRelacije();
            this.groupBox1.Controls.Clear();
            this.groupBox1.Controls.Add(f1.GetGroupBox());
            f1.GetGroupBox().Dock = DockStyle.Fill;
            f1.GetGroupBox().Show(); 
        }

        private void liceRelacijeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormLiceRelacija f1 = new FormLiceRelacija();
            this.groupBox1.Controls.Clear();
            this.groupBox1.Controls.Add(f1.GetGroupBox());
            f1.GetGroupBox().Dock = DockStyle.Fill;
            f1.GetGroupBox().Show();
        }

       
    }
}
