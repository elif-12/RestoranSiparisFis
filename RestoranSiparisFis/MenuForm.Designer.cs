using System.Windows.Forms;

namespace RestoranSiparisFis
{
    partial class MenuForm
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
            this.flowKategoriler = new System.Windows.Forms.FlowLayoutPanel();
            this.flowUrunler = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // flowKategoriler
            // 
            this.flowKategoriler.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowKategoriler.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowKategoriler.Location = new System.Drawing.Point(0, 0);
            this.flowKategoriler.Name = "flowKategoriler";
            this.flowKategoriler.Size = new System.Drawing.Size(1416, 475);
            this.flowKategoriler.TabIndex = 3;
            this.flowKategoriler.WrapContents = false;
            this.flowKategoriler.Paint += new System.Windows.Forms.PaintEventHandler(this.flowKategoriler_Paint);
            // 
            // flowUrunler
            // 
            this.flowUrunler.AutoScroll = true;
            this.flowUrunler.Location = new System.Drawing.Point(394, 12);
            this.flowUrunler.Name = "flowUrunler";
            this.flowUrunler.Size = new System.Drawing.Size(930, 613);
            this.flowUrunler.TabIndex = 4;
            // 
            // MenuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LavenderBlush;
            this.ClientSize = new System.Drawing.Size(1416, 475);
            this.Controls.Add(this.flowUrunler);
            this.Controls.Add(this.flowKategoriler);
            this.Name = "MenuForm";
            this.Text = "MenuForm";
            this.Load += new System.EventHandler(this.MenuForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbKategori;
        private System.Windows.Forms.ListBox lstUrunler;
        private System.Windows.Forms.Button btnEkle;
        private System.Windows.Forms.FlowLayoutPanel flowKategoriler;
        private System.Windows.Forms.FlowLayoutPanel flowUrunler;
    }
}