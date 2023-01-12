namespace PravougaonikGrafika
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
            this.txtelement = new System.Windows.Forms.TextBox();
            this.btdodaj = new System.Windows.Forms.Button();
            this.btukloni = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtelement
            // 
            this.txtelement.Location = new System.Drawing.Point(34, 28);
            this.txtelement.Name = "txtelement";
            this.txtelement.Size = new System.Drawing.Size(100, 20);
            this.txtelement.TabIndex = 0;
            // 
            // btdodaj
            // 
            this.btdodaj.Location = new System.Drawing.Point(34, 54);
            this.btdodaj.Name = "btdodaj";
            this.btdodaj.Size = new System.Drawing.Size(75, 23);
            this.btdodaj.TabIndex = 1;
            this.btdodaj.Text = "Dodaj";
            this.btdodaj.UseVisualStyleBackColor = true;
            this.btdodaj.Click += new System.EventHandler(this.btdodaj_Click);
            // 
            // btukloni
            // 
            this.btukloni.Location = new System.Drawing.Point(34, 83);
            this.btukloni.Name = "btukloni";
            this.btukloni.Size = new System.Drawing.Size(75, 23);
            this.btukloni.TabIndex = 2;
            this.btukloni.Text = "Ukloni";
            this.btukloni.UseVisualStyleBackColor = true;
            this.btukloni.Click += new System.EventHandler(this.btukloni_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btukloni);
            this.Controls.Add(this.btdodaj);
            this.Controls.Add(this.txtelement);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtelement;
        private System.Windows.Forms.Button btdodaj;
        private System.Windows.Forms.Button btukloni;
    }
}

