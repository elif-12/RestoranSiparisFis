using System.Windows.Forms;

namespace RestoranSiparisFis
{
    partial class MasaForm
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
            this.lblToplam = new System.Windows.Forms.Label();
            this.btnFisYazdir = new System.Windows.Forms.Button();
            this.btnSil = new System.Windows.Forms.Button();
            this.lvwSiparisler = new System.Windows.Forms.ListView();
            this.flowMasalar = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // lblToplam
            // 
            this.lblToplam.AutoSize = true;
            this.lblToplam.Location = new System.Drawing.Point(314, 622);
            this.lblToplam.Name = "lblToplam";
            this.lblToplam.Size = new System.Drawing.Size(44, 16);
            this.lblToplam.TabIndex = 2;
            this.lblToplam.Text = "label1";
            this.lblToplam.Click += new System.EventHandler(this.lblToplam_Click);
            // 
            // btnFisYazdir
            // 
            this.btnFisYazdir.Location = new System.Drawing.Point(756, 54);
            this.btnFisYazdir.Name = "btnFisYazdir";
            this.btnFisYazdir.Size = new System.Drawing.Size(110, 46);
            this.btnFisYazdir.TabIndex = 3;
            this.btnFisYazdir.Text = "Yazdır";
            this.btnFisYazdir.UseVisualStyleBackColor = true;
            this.btnFisYazdir.Click += new System.EventHandler(this.btnFisYazdir_Click);
            // 
            // btnSil
            // 
            this.btnSil.Location = new System.Drawing.Point(756, 132);
            this.btnSil.Name = "btnSil";
            this.btnSil.Size = new System.Drawing.Size(110, 52);
            this.btnSil.TabIndex = 4;
            this.btnSil.Text = "Sil";
            this.btnSil.UseVisualStyleBackColor = true;
            this.btnSil.Click += new System.EventHandler(this.button1_Click);
            // 
            // lvwSiparisler
            // 
            this.lvwSiparisler.HideSelection = false;
            this.lvwSiparisler.Location = new System.Drawing.Point(84, 495);
            this.lvwSiparisler.Name = "lvwSiparisler";
            this.lvwSiparisler.Size = new System.Drawing.Size(212, 143);
            this.lvwSiparisler.TabIndex = 5;
            this.lvwSiparisler.UseCompatibleStateImageBehavior = false;
            this.lvwSiparisler.SelectedIndexChanged += new System.EventHandler(this.lvwSiparisler_SelectedIndexChanged);
            // 
            // flowMasalar
            // 
            this.flowMasalar.AutoScroll = true;
            this.flowMasalar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flowMasalar.Location = new System.Drawing.Point(84, 54);
            this.flowMasalar.Name = "flowMasalar";
            this.flowMasalar.Size = new System.Drawing.Size(600, 400);
            this.flowMasalar.TabIndex = 6;
            // 
            // MasaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LavenderBlush;
            this.ClientSize = new System.Drawing.Size(962, 663);
            this.Controls.Add(this.flowMasalar);
            this.Controls.Add(this.lvwSiparisler);
            this.Controls.Add(this.btnSil);
            this.Controls.Add(this.btnFisYazdir);
            this.Controls.Add(this.lblToplam);
            this.Name = "MasaForm";
            this.Text = "MasaForm";
            this.Load += new System.EventHandler(this.MasaForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblToplam;
        private System.Windows.Forms.Button btnFisYazdir;
        private System.Windows.Forms.Button btnSil;
        private System.Windows.Forms.ListView lvwSiparisler;
        private System.Windows.Forms.FlowLayoutPanel flowMasalar;
    }
}