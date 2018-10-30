namespace MBTransPT
{
    partial class FormSpisakNaloga
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnENalog = new System.Windows.Forms.Button();
            this.btnSpisakBanka = new System.Windows.Forms.Button();
            this.btnVirmani = new System.Windows.Forms.Button();
            this.btnStampaj = new System.Windows.Forms.Button();
            this.btnObrisiNalog = new System.Windows.Forms.Button();
            this.dgvNalozi = new System.Windows.Forms.DataGridView();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNalozi)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.btnENalog);
            this.groupBox1.Controls.Add(this.btnSpisakBanka);
            this.groupBox1.Controls.Add(this.btnVirmani);
            this.groupBox1.Controls.Add(this.btnStampaj);
            this.groupBox1.Controls.Add(this.btnObrisiNalog);
            this.groupBox1.Controls.Add(this.dgvNalozi);
            this.groupBox1.Location = new System.Drawing.Point(1, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(492, 307);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Spisak naloga";
            // 
            // btnENalog
            // 
            this.btnENalog.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnENalog.Location = new System.Drawing.Point(37, 252);
            this.btnENalog.Name = "btnENalog";
            this.btnENalog.Size = new System.Drawing.Size(75, 43);
            this.btnENalog.TabIndex = 5;
            this.btnENalog.Text = "Pravljenje e-naloga";
            this.btnENalog.UseVisualStyleBackColor = true;
            this.btnENalog.Click += new System.EventHandler(this.btnENalog_Click);
            // 
            // btnSpisakBanka
            // 
            this.btnSpisakBanka.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSpisakBanka.Location = new System.Drawing.Point(129, 252);
            this.btnSpisakBanka.Name = "btnSpisakBanka";
            this.btnSpisakBanka.Size = new System.Drawing.Size(75, 43);
            this.btnSpisakBanka.TabIndex = 4;
            this.btnSpisakBanka.Text = "Spisak za banku";
            this.btnSpisakBanka.UseVisualStyleBackColor = true;
            this.btnSpisakBanka.Click += new System.EventHandler(this.btnSpisakBanka_Click);
            // 
            // btnVirmani
            // 
            this.btnVirmani.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnVirmani.Location = new System.Drawing.Point(222, 252);
            this.btnVirmani.Name = "btnVirmani";
            this.btnVirmani.Size = new System.Drawing.Size(75, 43);
            this.btnVirmani.TabIndex = 3;
            this.btnVirmani.Text = "Virmani";
            this.btnVirmani.UseVisualStyleBackColor = true;
            this.btnVirmani.Click += new System.EventHandler(this.btnVirmani_Click);
            // 
            // btnStampaj
            // 
            this.btnStampaj.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStampaj.Location = new System.Drawing.Point(312, 252);
            this.btnStampaj.Name = "btnStampaj";
            this.btnStampaj.Size = new System.Drawing.Size(75, 43);
            this.btnStampaj.TabIndex = 2;
            this.btnStampaj.Text = "Štampa naloga";
            this.btnStampaj.UseVisualStyleBackColor = true;
            this.btnStampaj.Click += new System.EventHandler(this.btnStampaj_Click);
            // 
            // btnObrisiNalog
            // 
            this.btnObrisiNalog.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnObrisiNalog.Location = new System.Drawing.Point(405, 252);
            this.btnObrisiNalog.Name = "btnObrisiNalog";
            this.btnObrisiNalog.Size = new System.Drawing.Size(75, 43);
            this.btnObrisiNalog.TabIndex = 1;
            this.btnObrisiNalog.Text = "Obriši";
            this.btnObrisiNalog.UseVisualStyleBackColor = true;
            this.btnObrisiNalog.Click += new System.EventHandler(this.btnObrisiNalog_Click);
            // 
            // dgvNalozi
            // 
            this.dgvNalozi.AllowUserToAddRows = false;
            this.dgvNalozi.AllowUserToDeleteRows = false;
            this.dgvNalozi.AllowUserToOrderColumns = true;
            this.dgvNalozi.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvNalozi.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvNalozi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvNalozi.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvNalozi.Location = new System.Drawing.Point(0, 45);
            this.dgvNalozi.Name = "dgvNalozi";
            this.dgvNalozi.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvNalozi.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvNalozi.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvNalozi.Size = new System.Drawing.Size(492, 201);
            this.dgvNalozi.TabIndex = 0;
            this.dgvNalozi.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvNalozi_CellDoubleClick);
            // 
            // FormSpisakNaloga
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(493, 310);
            this.Controls.Add(this.groupBox1);
            this.Name = "FormSpisakNaloga";
            this.Text = "FormSpisakNaloga";
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvNalozi)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnObrisiNalog;
        private System.Windows.Forms.DataGridView dgvNalozi;
        private System.Windows.Forms.Button btnStampaj;
        private System.Windows.Forms.Button btnVirmani;
        private System.Windows.Forms.Button btnSpisakBanka;
        private System.Windows.Forms.Button btnENalog;
    }
}