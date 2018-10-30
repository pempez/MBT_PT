namespace MBTransPT
{
    partial class FormNoviNalog
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbFirma = new System.Windows.Forms.ComboBox();
            this.btnUnesiNalog = new System.Windows.Forms.Button();
            this.tbGodina = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tbMesec = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tbBrojNaloga = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.gbNovaStavka = new System.Windows.Forms.GroupBox();
            this.btnNoviKomitent = new System.Windows.Forms.Button();
            this.btnIzmeni = new System.Windows.Forms.Button();
            this.tbRedndacija = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.cbZiro = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnUnesi = new System.Windows.Forms.Button();
            this.cbLice = new System.Windows.Forms.ComboBox();
            this.tbIznos = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblUkupno = new System.Windows.Forms.Label();
            this.btnObrisiStavku = new System.Windows.Forms.Button();
            this.btnDodajStavku = new System.Windows.Forms.Button();
            this.dgvStavke = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.btnPreuzmiAktivna = new System.Windows.Forms.Button();
            this.tbUkupno = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.gbNovaStavka.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStavke)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.cbFirma);
            this.groupBox1.Controls.Add(this.btnUnesiNalog);
            this.groupBox1.Controls.Add(this.tbGodina);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.tbMesec);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.tbBrojNaloga);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.gbNovaStavka);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.dateTimePicker1);
            this.groupBox1.Controls.Add(this.btnPreuzmiAktivna);
            this.groupBox1.Location = new System.Drawing.Point(5, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(793, 448);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Novi nalog";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(386, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 13);
            this.label3.TabIndex = 19;
            this.label3.Text = "Firma";
            // 
            // cbFirma
            // 
            this.cbFirma.FormattingEnabled = true;
            this.cbFirma.Location = new System.Drawing.Point(424, 18);
            this.cbFirma.Name = "cbFirma";
            this.cbFirma.Size = new System.Drawing.Size(265, 21);
            this.cbFirma.TabIndex = 18;
            // 
            // btnUnesiNalog
            // 
            this.btnUnesiNalog.Location = new System.Drawing.Point(706, 48);
            this.btnUnesiNalog.Name = "btnUnesiNalog";
            this.btnUnesiNalog.Size = new System.Drawing.Size(75, 23);
            this.btnUnesiNalog.TabIndex = 17;
            this.btnUnesiNalog.Text = "Unesi nalog";
            this.btnUnesiNalog.UseVisualStyleBackColor = true;
            this.btnUnesiNalog.Click += new System.EventHandler(this.btnUnesiNalog_Click);
            // 
            // tbGodina
            // 
            this.tbGodina.Location = new System.Drawing.Point(277, 51);
            this.tbGodina.Name = "tbGodina";
            this.tbGodina.Size = new System.Drawing.Size(44, 20);
            this.tbGodina.TabIndex = 16;
            this.tbGodina.Leave += new System.EventHandler(this.tbGodina_Leave);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(223, 54);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(41, 13);
            this.label8.TabIndex = 15;
            this.label8.Text = "Godina";
            // 
            // tbMesec
            // 
            this.tbMesec.Location = new System.Drawing.Point(379, 52);
            this.tbMesec.Name = "tbMesec";
            this.tbMesec.Size = new System.Drawing.Size(32, 20);
            this.tbMesec.TabIndex = 14;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(333, 56);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(39, 13);
            this.label7.TabIndex = 13;
            this.label7.Text = "Mesec";
            // 
            // tbBrojNaloga
            // 
            this.tbBrojNaloga.Location = new System.Drawing.Point(270, 19);
            this.tbBrojNaloga.Name = "tbBrojNaloga";
            this.tbBrojNaloga.Size = new System.Drawing.Size(51, 20);
            this.tbBrojNaloga.TabIndex = 12;
            this.tbBrojNaloga.Leave += new System.EventHandler(this.tbBrojNaloga_Leave);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(204, 19);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(60, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Broj naloga";
            // 
            // gbNovaStavka
            // 
            this.gbNovaStavka.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbNovaStavka.Controls.Add(this.tbUkupno);
            this.gbNovaStavka.Controls.Add(this.btnNoviKomitent);
            this.gbNovaStavka.Controls.Add(this.btnIzmeni);
            this.gbNovaStavka.Controls.Add(this.tbRedndacija);
            this.gbNovaStavka.Controls.Add(this.label9);
            this.gbNovaStavka.Controls.Add(this.cbZiro);
            this.gbNovaStavka.Controls.Add(this.label5);
            this.gbNovaStavka.Controls.Add(this.btnUnesi);
            this.gbNovaStavka.Controls.Add(this.cbLice);
            this.gbNovaStavka.Controls.Add(this.tbIznos);
            this.gbNovaStavka.Controls.Add(this.label4);
            this.gbNovaStavka.Controls.Add(this.label2);
            this.gbNovaStavka.Location = new System.Drawing.Point(0, 351);
            this.gbNovaStavka.Name = "gbNovaStavka";
            this.gbNovaStavka.Size = new System.Drawing.Size(793, 107);
            this.gbNovaStavka.TabIndex = 10;
            this.gbNovaStavka.TabStop = false;
            this.gbNovaStavka.Text = "Nova stavka";
            this.gbNovaStavka.Visible = false;
            // 
            // btnNoviKomitent
            // 
            this.btnNoviKomitent.Location = new System.Drawing.Point(0, 18);
            this.btnNoviKomitent.Name = "btnNoviKomitent";
            this.btnNoviKomitent.Size = new System.Drawing.Size(65, 28);
            this.btnNoviKomitent.TabIndex = 16;
            this.btnNoviKomitent.Text = "Novo lice";
            this.btnNoviKomitent.UseVisualStyleBackColor = true;
            this.btnNoviKomitent.Click += new System.EventHandler(this.btnNoviKomitent_Click);
            // 
            // btnIzmeni
            // 
            this.btnIzmeni.Location = new System.Drawing.Point(13, 72);
            this.btnIzmeni.Name = "btnIzmeni";
            this.btnIzmeni.Size = new System.Drawing.Size(75, 23);
            this.btnIzmeni.TabIndex = 15;
            this.btnIzmeni.Text = "Izmeni";
            this.btnIzmeni.UseVisualStyleBackColor = true;
            this.btnIzmeni.Visible = false;
            this.btnIzmeni.Click += new System.EventHandler(this.btnIzmeni_Click);
            // 
            // tbRedndacija
            // 
            this.tbRedndacija.Location = new System.Drawing.Point(646, 22);
            this.tbRedndacija.Name = "tbRedndacija";
            this.tbRedndacija.Size = new System.Drawing.Size(118, 20);
            this.tbRedndacija.TabIndex = 14;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(529, 22);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(111, 13);
            this.label9.TabIndex = 13;
            this.label9.Text = "Refundacija troskova:";
            // 
            // cbZiro
            // 
            this.cbZiro.FormattingEnabled = true;
            this.cbZiro.Location = new System.Drawing.Point(122, 47);
            this.cbZiro.Name = "cbZiro";
            this.cbZiro.Size = new System.Drawing.Size(211, 21);
            this.cbZiro.TabIndex = 12;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(61, 50);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Ziro racun";
            // 
            // btnUnesi
            // 
            this.btnUnesi.Location = new System.Drawing.Point(706, 72);
            this.btnUnesi.Name = "btnUnesi";
            this.btnUnesi.Size = new System.Drawing.Size(75, 23);
            this.btnUnesi.TabIndex = 10;
            this.btnUnesi.Text = "Unesi";
            this.btnUnesi.UseVisualStyleBackColor = true;
            this.btnUnesi.Click += new System.EventHandler(this.btnUnesi_Click);
            // 
            // cbLice
            // 
            this.cbLice.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbLice.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbLice.FormattingEnabled = true;
            this.cbLice.Location = new System.Drawing.Point(122, 20);
            this.cbLice.Name = "cbLice";
            this.cbLice.Size = new System.Drawing.Size(211, 21);
            this.cbLice.TabIndex = 4;
            this.cbLice.SelectedIndexChanged += new System.EventHandler(this.cbLice_SelectedIndexChanged);
            // 
            // tbIznos
            // 
            this.tbIznos.Location = new System.Drawing.Point(401, 21);
            this.tbIznos.Name = "tbIznos";
            this.tbIznos.Size = new System.Drawing.Size(118, 20);
            this.tbIznos.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(339, 23);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Dnevnica:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(83, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Lice: ";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.lblUkupno);
            this.groupBox2.Controls.Add(this.btnObrisiStavku);
            this.groupBox2.Controls.Add(this.btnDodajStavku);
            this.groupBox2.Controls.Add(this.dgvStavke);
            this.groupBox2.Location = new System.Drawing.Point(0, 78);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(793, 267);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Stavke naloga";
            // 
            // lblUkupno
            // 
            this.lblUkupno.AutoSize = true;
            this.lblUkupno.Location = new System.Drawing.Point(7, 205);
            this.lblUkupno.Name = "lblUkupno";
            this.lblUkupno.Size = new System.Drawing.Size(0, 13);
            this.lblUkupno.TabIndex = 3;
            // 
            // btnObrisiStavku
            // 
            this.btnObrisiStavku.Location = new System.Drawing.Point(6, 238);
            this.btnObrisiStavku.Name = "btnObrisiStavku";
            this.btnObrisiStavku.Size = new System.Drawing.Size(75, 23);
            this.btnObrisiStavku.TabIndex = 2;
            this.btnObrisiStavku.Text = "Obriši stavku";
            this.btnObrisiStavku.UseVisualStyleBackColor = true;
            this.btnObrisiStavku.Click += new System.EventHandler(this.btnObrisiStavku_Click);
            // 
            // btnDodajStavku
            // 
            this.btnDodajStavku.Location = new System.Drawing.Point(650, 238);
            this.btnDodajStavku.Name = "btnDodajStavku";
            this.btnDodajStavku.Size = new System.Drawing.Size(131, 23);
            this.btnDodajStavku.TabIndex = 1;
            this.btnDodajStavku.Text = "Dodaj stavku";
            this.btnDodajStavku.UseVisualStyleBackColor = true;
            this.btnDodajStavku.Visible = false;
            this.btnDodajStavku.Click += new System.EventHandler(this.btnDodajStavku_Click);
            // 
            // dgvStavke
            // 
            this.dgvStavke.AllowUserToAddRows = false;
            this.dgvStavke.AllowUserToDeleteRows = false;
            this.dgvStavke.AllowUserToOrderColumns = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvStavke.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvStavke.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvStavke.DefaultCellStyle = dataGridViewCellStyle5;
            this.dgvStavke.Location = new System.Drawing.Point(6, 19);
            this.dgvStavke.Name = "dgvStavke";
            this.dgvStavke.ReadOnly = true;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvStavke.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvStavke.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvStavke.Size = new System.Drawing.Size(779, 183);
            this.dgvStavke.TabIndex = 0;
            this.dgvStavke.Click += new System.EventHandler(this.dgvStavke_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Datum isplate";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(81, 19);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(95, 20);
            this.dateTimePicker1.TabIndex = 1;
            this.dateTimePicker1.Value = new System.DateTime(2018, 1, 4, 0, 0, 0, 0);
            // 
            // btnPreuzmiAktivna
            // 
            this.btnPreuzmiAktivna.Location = new System.Drawing.Point(13, 49);
            this.btnPreuzmiAktivna.Name = "btnPreuzmiAktivna";
            this.btnPreuzmiAktivna.Size = new System.Drawing.Size(183, 23);
            this.btnPreuzmiAktivna.TabIndex = 0;
            this.btnPreuzmiAktivna.Text = "Preuzmi aktuelna lica sa realcijama";
            this.btnPreuzmiAktivna.UseVisualStyleBackColor = true;
            this.btnPreuzmiAktivna.Visible = false;
            this.btnPreuzmiAktivna.Click += new System.EventHandler(this.btnPreuzmiAktivna_Click);
            // 
            // tbUkupno
            // 
            this.tbUkupno.Location = new System.Drawing.Point(401, 48);
            this.tbUkupno.Name = "tbUkupno";
            this.tbUkupno.Size = new System.Drawing.Size(100, 20);
            this.tbUkupno.TabIndex = 17;
            this.tbUkupno.Visible = false;
            // 
            // FormNoviNalog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(798, 464);
            this.Controls.Add(this.groupBox1);
            this.Name = "FormNoviNalog";
            this.Text = "FormNoviNalog";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.gbNovaStavka.ResumeLayout(false);
            this.gbNovaStavka.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStavke)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnPreuzmiAktivna;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dgvStavke;
        private System.Windows.Forms.TextBox tbIznos;
        private System.Windows.Forms.ComboBox cbLice;
        private System.Windows.Forms.Button btnDodajStavku;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox gbNovaStavka;
        private System.Windows.Forms.Button btnUnesi;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbZiro;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbBrojNaloga;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbGodina;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tbMesec;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnUnesiNalog;
        private System.Windows.Forms.Button btnObrisiStavku;
        private System.Windows.Forms.TextBox tbRedndacija;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnIzmeni;
        private System.Windows.Forms.Label lblUkupno;
        private System.Windows.Forms.Button btnNoviKomitent;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbFirma;
        private System.Windows.Forms.TextBox tbUkupno;
    }
}