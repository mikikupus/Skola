namespace UceniciMenu
{
    partial class UcenikForm
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbsifra = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lbocena = new System.Windows.Forms.Label();
            this.lbtelefon = new System.Windows.Forms.Label();
            this.lbime = new System.Windows.Forms.Label();
            this.lbprezime = new System.Windows.Forms.Label();
            this.btexit = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.Controls.Add(this.btexit);
            this.panel1.Controls.Add(this.lbprezime);
            this.panel1.Controls.Add(this.lbime);
            this.panel1.Controls.Add(this.lbtelefon);
            this.panel1.Controls.Add(this.lbocena);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.lbsifra);
            this.panel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(124, 44);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(499, 354);
            this.panel1.TabIndex = 0;
            // 
            // lbsifra
            // 
            this.lbsifra.AutoSize = true;
            this.lbsifra.Location = new System.Drawing.Point(96, 103);
            this.lbsifra.Name = "lbsifra";
            this.lbsifra.Size = new System.Drawing.Size(62, 25);
            this.lbsifra.TabIndex = 0;
            this.lbsifra.Text = "Šifra:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(111, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(280, 39);
            this.label2.TabIndex = 1;
            this.label2.Text = "Podaci o učeniku";
            // 
            // lbocena
            // 
            this.lbocena.AutoSize = true;
            this.lbocena.Location = new System.Drawing.Point(96, 252);
            this.lbocena.Name = "lbocena";
            this.lbocena.Size = new System.Drawing.Size(81, 25);
            this.lbocena.TabIndex = 2;
            this.lbocena.Text = "Ocena:";
            // 
            // lbtelefon
            // 
            this.lbtelefon.AutoSize = true;
            this.lbtelefon.Location = new System.Drawing.Point(96, 215);
            this.lbtelefon.Name = "lbtelefon";
            this.lbtelefon.Size = new System.Drawing.Size(90, 25);
            this.lbtelefon.TabIndex = 3;
            this.lbtelefon.Text = "Telefon:";
            // 
            // lbime
            // 
            this.lbime.AutoSize = true;
            this.lbime.Location = new System.Drawing.Point(96, 139);
            this.lbime.Name = "lbime";
            this.lbime.Size = new System.Drawing.Size(52, 25);
            this.lbime.TabIndex = 4;
            this.lbime.Text = "Ime:";
            // 
            // lbprezime
            // 
            this.lbprezime.AutoSize = true;
            this.lbprezime.Location = new System.Drawing.Point(96, 176);
            this.lbprezime.Name = "lbprezime";
            this.lbprezime.Size = new System.Drawing.Size(96, 25);
            this.lbprezime.TabIndex = 5;
            this.lbprezime.Text = "Prezime:";
            // 
            // btexit
            // 
            this.btexit.Location = new System.Drawing.Point(118, 305);
            this.btexit.Name = "btexit";
            this.btexit.Size = new System.Drawing.Size(227, 35);
            this.btexit.TabIndex = 6;
            this.btexit.Text = "Izađi";
            this.btexit.UseVisualStyleBackColor = true;
            this.btexit.Click += new System.EventHandler(this.btexit_Click);
            // 
            // UcenikForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel1);
            this.Name = "UcenikForm";
            this.Text = "UcenikForm";
            this.Load += new System.EventHandler(this.UcenikForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lbprezime;
        private System.Windows.Forms.Label lbime;
        private System.Windows.Forms.Label lbtelefon;
        private System.Windows.Forms.Label lbocena;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbsifra;
        private System.Windows.Forms.Button btexit;
    }
}