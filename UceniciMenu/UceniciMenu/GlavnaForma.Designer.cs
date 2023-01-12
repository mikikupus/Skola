namespace UceniciMenu
{
    partial class GlavnaForma
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
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripTxtSifra = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripProsecnaOcena = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.unosToolStripMenuItemUnos = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.BtUnos = new System.Windows.Forms.Button();
            this.txtocena = new System.Windows.Forms.TextBox();
            this.txttelefon = new System.Windows.Forms.TextBox();
            this.txtprezime = new System.Windows.Forms.TextBox();
            this.txtime = new System.Windows.Forms.TextBox();
            this.txtsifra = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lbucenici = new System.Windows.Forms.ListBox();
            this.toolStripSearch = new System.Windows.Forms.ToolStripButton();
            this.toolStripDelete = new System.Windows.Forms.ToolStripButton();
            this.ListaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ProsecnaOcenaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripTxtSifra,
            this.toolStripSearch,
            this.toolStripSeparator1,
            this.toolStripDelete,
            this.toolStripSeparator2,
            this.toolStripProsecnaOcena});
            this.toolStrip1.Location = new System.Drawing.Point(0, 46);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(800, 50);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripTxtSifra
            // 
            this.toolStripTxtSifra.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.toolStripTxtSifra.Name = "toolStripTxtSifra";
            this.toolStripTxtSifra.Size = new System.Drawing.Size(100, 50);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 50);
            // 
            // toolStripProsecnaOcena
            // 
            this.toolStripProsecnaOcena.AutoSize = false;
            this.toolStripProsecnaOcena.Name = "toolStripProsecnaOcena";
            this.toolStripProsecnaOcena.Size = new System.Drawing.Size(150, 34);
            this.toolStripProsecnaOcena.Text = "Prosečna ocena:";
            this.toolStripProsecnaOcena.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 50);
            // 
            // menuStrip1
            // 
            this.menuStrip1.AutoSize = false;
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 46);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.unosToolStripMenuItemUnos,
            this.ListaToolStripMenuItem,
            this.ProsecnaOcenaToolStripMenuItem});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(73, 42);
            this.toolStripMenuItem1.Text = "Show";
            // 
            // unosToolStripMenuItemUnos
            // 
            this.unosToolStripMenuItemUnos.Checked = true;
            this.unosToolStripMenuItemUnos.CheckState = System.Windows.Forms.CheckState.Checked;
            this.unosToolStripMenuItemUnos.Name = "unosToolStripMenuItemUnos";
            this.unosToolStripMenuItemUnos.Size = new System.Drawing.Size(223, 30);
            this.unosToolStripMenuItemUnos.Text = "Unos";
            this.unosToolStripMenuItemUnos.Click += new System.EventHandler(this.UnosToolStripMenuItem_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.BtUnos);
            this.panel1.Controls.Add(this.txtocena);
            this.panel1.Controls.Add(this.txttelefon);
            this.panel1.Controls.Add(this.txtprezime);
            this.panel1.Controls.Add(this.txtime);
            this.panel1.Controls.Add(this.txtsifra);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(31, 99);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(201, 234);
            this.panel1.TabIndex = 2;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(65, 10);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(54, 24);
            this.label6.TabIndex = 11;
            this.label6.Text = "Unos";
            // 
            // BtUnos
            // 
            this.BtUnos.Location = new System.Drawing.Point(18, 180);
            this.BtUnos.Name = "BtUnos";
            this.BtUnos.Size = new System.Drawing.Size(162, 23);
            this.BtUnos.TabIndex = 10;
            this.BtUnos.Text = "Unos";
            this.BtUnos.UseVisualStyleBackColor = true;
            this.BtUnos.Click += new System.EventHandler(this.BtUnos_Click);
            // 
            // txtocena
            // 
            this.txtocena.Location = new System.Drawing.Point(80, 154);
            this.txtocena.Name = "txtocena";
            this.txtocena.Size = new System.Drawing.Size(100, 20);
            this.txtocena.TabIndex = 9;
            // 
            // txttelefon
            // 
            this.txttelefon.Location = new System.Drawing.Point(80, 128);
            this.txttelefon.Name = "txttelefon";
            this.txttelefon.Size = new System.Drawing.Size(100, 20);
            this.txttelefon.TabIndex = 8;
            // 
            // txtprezime
            // 
            this.txtprezime.Location = new System.Drawing.Point(80, 102);
            this.txtprezime.Name = "txtprezime";
            this.txtprezime.Size = new System.Drawing.Size(100, 20);
            this.txtprezime.TabIndex = 7;
            // 
            // txtime
            // 
            this.txtime.Location = new System.Drawing.Point(80, 76);
            this.txtime.Name = "txtime";
            this.txtime.Size = new System.Drawing.Size(100, 20);
            this.txtime.TabIndex = 6;
            // 
            // txtsifra
            // 
            this.txtsifra.Location = new System.Drawing.Point(80, 50);
            this.txtsifra.Name = "txtsifra";
            this.txtsifra.Size = new System.Drawing.Size(100, 20);
            this.txtsifra.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(31, 157);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(42, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Ocena:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(27, 131);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Telefon:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(27, 105);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Prezime:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(47, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(27, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Ime:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(43, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Sifra:";
            // 
            // lbucenici
            // 
            this.lbucenici.FormattingEnabled = true;
            this.lbucenici.Location = new System.Drawing.Point(265, 99);
            this.lbucenici.Name = "lbucenici";
            this.lbucenici.Size = new System.Drawing.Size(262, 238);
            this.lbucenici.TabIndex = 3;
            // 
            // toolStripSearch
            // 
            this.toolStripSearch.AutoSize = false;
            this.toolStripSearch.Image = global::UceniciMenu.res.Search;
            this.toolStripSearch.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripSearch.Name = "toolStripSearch";
            this.toolStripSearch.Size = new System.Drawing.Size(70, 40);
            this.toolStripSearch.Text = "Pretraži";
            this.toolStripSearch.Click += new System.EventHandler(this.toolStripSearch_Click);
            // 
            // toolStripDelete
            // 
            this.toolStripDelete.AutoSize = false;
            this.toolStripDelete.Image = global::UceniciMenu.res.Delete;
            this.toolStripDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDelete.Name = "toolStripDelete";
            this.toolStripDelete.Size = new System.Drawing.Size(70, 40);
            this.toolStripDelete.Text = "Ukloni";
            this.toolStripDelete.Click += new System.EventHandler(this.toolStripDelete_Click);
            // 
            // ListaToolStripMenuItem
            // 
            this.ListaToolStripMenuItem.Checked = true;
            this.ListaToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ListaToolStripMenuItem.Name = "ListaToolStripMenuItem";
            this.ListaToolStripMenuItem.Size = new System.Drawing.Size(223, 30);
            this.ListaToolStripMenuItem.Text = "Lista";
            this.ListaToolStripMenuItem.Click += new System.EventHandler(this.ListaToolStripMenuItem_Click);
            // 
            // ProsecnaOcenaToolStripMenuItem
            // 
            this.ProsecnaOcenaToolStripMenuItem.Checked = true;
            this.ProsecnaOcenaToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ProsecnaOcenaToolStripMenuItem.Name = "ProsecnaOcenaToolStripMenuItem";
            this.ProsecnaOcenaToolStripMenuItem.Size = new System.Drawing.Size(223, 30);
            this.ProsecnaOcenaToolStripMenuItem.Text = "Prosečna ocena";
            this.ProsecnaOcenaToolStripMenuItem.Click += new System.EventHandler(this.ProsecnaOcenaToolStripMenuItem_Click);
            // 
            // GlavnaForma
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lbucenici);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "GlavnaForma";
            this.Text = "Ucenici";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripTextBox toolStripTxtSifra;
        private System.Windows.Forms.ToolStripButton toolStripSearch;
        private System.Windows.Forms.ToolStripLabel toolStripProsecnaOcena;
        private System.Windows.Forms.ToolStripButton toolStripDelete;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem unosToolStripMenuItemUnos;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button BtUnos;
        private System.Windows.Forms.TextBox txtocena;
        private System.Windows.Forms.TextBox txttelefon;
        private System.Windows.Forms.TextBox txtprezime;
        private System.Windows.Forms.TextBox txtime;
        private System.Windows.Forms.TextBox txtsifra;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ListBox lbucenici;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem ListaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ProsecnaOcenaToolStripMenuItem;
    }
}

