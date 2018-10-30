namespace MBTransPT
{
    partial class Form1
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
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("Osnovni podaci");
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("Radnici");
            System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode("Korisnici", new System.Windows.Forms.TreeNode[] {
            treeNode7,
            treeNode8});
            System.Windows.Forms.TreeNode treeNode10 = new System.Windows.Forms.TreeNode("Putni trošak");
            System.Windows.Forms.TreeNode treeNode11 = new System.Windows.Forms.TreeNode("Spisak naloga");
            System.Windows.Forms.TreeNode treeNode12 = new System.Windows.Forms.TreeNode("Nalozi", new System.Windows.Forms.TreeNode[] {
            treeNode10,
            treeNode11});
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.komitentiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.osnovniPodaciToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.radniciToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.putniTrosakToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.naloziToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.spisakNalogaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.šifarnikToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.relacijeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.treeView2 = new System.Windows.Forms.TreeView();
            this.menuStrip1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.komitentiToolStripMenuItem,
            this.putniTrosakToolStripMenuItem,
            this.šifarnikToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1062, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // komitentiToolStripMenuItem
            // 
            this.komitentiToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.osnovniPodaciToolStripMenuItem,
            this.radniciToolStripMenuItem});
            this.komitentiToolStripMenuItem.Name = "komitentiToolStripMenuItem";
            this.komitentiToolStripMenuItem.Size = new System.Drawing.Size(64, 20);
            this.komitentiToolStripMenuItem.Text = "Korisnici";
            this.komitentiToolStripMenuItem.Click += new System.EventHandler(this.komitentiToolStripMenuItem_Click);
            // 
            // osnovniPodaciToolStripMenuItem
            // 
            this.osnovniPodaciToolStripMenuItem.Name = "osnovniPodaciToolStripMenuItem";
            this.osnovniPodaciToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.osnovniPodaciToolStripMenuItem.Text = "Osnovni Podaci";
            this.osnovniPodaciToolStripMenuItem.Click += new System.EventHandler(this.osnovniPodaciToolStripMenuItem_Click);
            // 
            // radniciToolStripMenuItem
            // 
            this.radniciToolStripMenuItem.Name = "radniciToolStripMenuItem";
            this.radniciToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.radniciToolStripMenuItem.Text = "Radnici";
            this.radniciToolStripMenuItem.Click += new System.EventHandler(this.radniciToolStripMenuItem_Click);
            // 
            // putniTrosakToolStripMenuItem
            // 
            this.putniTrosakToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.naloziToolStripMenuItem,
            this.spisakNalogaToolStripMenuItem});
            this.putniTrosakToolStripMenuItem.Name = "putniTrosakToolStripMenuItem";
            this.putniTrosakToolStripMenuItem.Size = new System.Drawing.Size(85, 20);
            this.putniTrosakToolStripMenuItem.Text = "Putni Trosak";
            // 
            // naloziToolStripMenuItem
            // 
            this.naloziToolStripMenuItem.Name = "naloziToolStripMenuItem";
            this.naloziToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.naloziToolStripMenuItem.Text = "Novi Nalog";
            this.naloziToolStripMenuItem.Click += new System.EventHandler(this.naloziToolStripMenuItem_Click);
            // 
            // spisakNalogaToolStripMenuItem
            // 
            this.spisakNalogaToolStripMenuItem.Name = "spisakNalogaToolStripMenuItem";
            this.spisakNalogaToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.spisakNalogaToolStripMenuItem.Text = "Spisak Naloga";
            this.spisakNalogaToolStripMenuItem.Click += new System.EventHandler(this.spisakNalogaToolStripMenuItem_Click);
            // 
            // šifarnikToolStripMenuItem
            // 
            this.šifarnikToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.relacijeToolStripMenuItem});
            this.šifarnikToolStripMenuItem.Name = "šifarnikToolStripMenuItem";
            this.šifarnikToolStripMenuItem.Size = new System.Drawing.Size(58, 20);
            this.šifarnikToolStripMenuItem.Text = "Šifarnik";
            this.šifarnikToolStripMenuItem.Visible = false;
            // 
            // relacijeToolStripMenuItem
            // 
            this.relacijeToolStripMenuItem.Name = "relacijeToolStripMenuItem";
            this.relacijeToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.relacijeToolStripMenuItem.Text = "Relacije";
            this.relacijeToolStripMenuItem.Click += new System.EventHandler(this.relacijeToolStripMenuItem_Click);
            // 
            // treeView1
            // 
            this.treeView1.Location = new System.Drawing.Point(0, 0);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(121, 97);
            this.treeView1.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.AutoSize = true;
            this.groupBox1.Location = new System.Drawing.Point(150, 27);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(912, 478);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.treeView2);
            this.groupBox2.Location = new System.Drawing.Point(0, 28);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(148, 475);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            // 
            // treeView2
            // 
            this.treeView2.Location = new System.Drawing.Point(5, 13);
            this.treeView2.Name = "treeView2";
            treeNode7.Name = "NodeOsnovniPodaci";
            treeNode7.Text = "Osnovni podaci";
            treeNode8.Name = "NodeRadnici";
            treeNode8.Text = "Radnici";
            treeNode9.Name = "nodeKorisnici";
            treeNode9.Text = "Korisnici";
            treeNode10.Name = "NodeNalozi";
            treeNode10.Text = "Putni trošak";
            treeNode11.Name = "NodeSpisakNaloga";
            treeNode11.Text = "Spisak naloga";
            treeNode12.Name = "NodePutniTrosak";
            treeNode12.Text = "Nalozi";
            this.treeView2.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode9,
            treeNode12});
            this.treeView2.Size = new System.Drawing.Size(133, 461);
            this.treeView2.TabIndex = 0;
            this.treeView2.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1062, 505);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuStrip1);
            this.Name = "Form1";
            this.Text = "Putni Trošak";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem komitentiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem putniTrosakToolStripMenuItem;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.ToolStripMenuItem osnovniPodaciToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem radniciToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem naloziToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem spisakNalogaToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TreeView treeView2;
        private System.Windows.Forms.ToolStripMenuItem šifarnikToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem relacijeToolStripMenuItem;

    }
}

