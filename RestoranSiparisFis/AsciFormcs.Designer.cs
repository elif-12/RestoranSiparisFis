﻿namespace RestoranSiparisFis
{
    partial class AsciForm
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
            this.lvwAsciSiparisler = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // lvwAsciSiparisler
            // 
            this.lvwAsciSiparisler.HideSelection = false;
            this.lvwAsciSiparisler.Location = new System.Drawing.Point(140, 45);
            this.lvwAsciSiparisler.Name = "lvwAsciSiparisler";
            this.lvwAsciSiparisler.Size = new System.Drawing.Size(316, 222);
            this.lvwAsciSiparisler.TabIndex = 0;
            this.lvwAsciSiparisler.UseCompatibleStateImageBehavior = false;
            this.lvwAsciSiparisler.SelectedIndexChanged += new System.EventHandler(this.lvwAsciSiparisler_SelectedIndexChanged);
            // 
            // AsciForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lvwAsciSiparisler);
            this.Name = "AsciForm";
            this.Text = "AsciFormcs";
            this.Load += new System.EventHandler(this.AsciFormcs_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lvwAsciSiparisler;
    }
}