﻿namespace TechStore
{
    partial class uiHelp
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
            this.uiActionIzlaz = new System.Windows.Forms.Button();
            this.uiOutputPrikazPomoci = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // uiActionIzlaz
            // 
            this.uiActionIzlaz.BackColor = System.Drawing.Color.Maroon;
            this.uiActionIzlaz.FlatAppearance.BorderSize = 0;
            this.uiActionIzlaz.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.uiActionIzlaz.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.uiActionIzlaz.ForeColor = System.Drawing.Color.White;
            this.uiActionIzlaz.Location = new System.Drawing.Point(370, 380);
            this.uiActionIzlaz.Name = "uiActionIzlaz";
            this.uiActionIzlaz.Size = new System.Drawing.Size(75, 23);
            this.uiActionIzlaz.TabIndex = 0;
            this.uiActionIzlaz.Text = "Izlaz";
            this.uiActionIzlaz.UseVisualStyleBackColor = false;
            this.uiActionIzlaz.Click += new System.EventHandler(this.UiActionIzlaz_Click);
            // 
            // uiOutputPrikazPomoci
            // 
            this.uiOutputPrikazPomoci.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.uiOutputPrikazPomoci.Location = new System.Drawing.Point(12, 12);
            this.uiOutputPrikazPomoci.Name = "uiOutputPrikazPomoci";
            this.uiOutputPrikazPomoci.Size = new System.Drawing.Size(433, 344);
            this.uiOutputPrikazPomoci.TabIndex = 1;
            this.uiOutputPrikazPomoci.Text = "";
            // 
            // uiHelp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::TechStore.Properties.Resources.pozadina_nova;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(457, 415);
            this.Controls.Add(this.uiOutputPrikazPomoci);
            this.Controls.Add(this.uiActionIzlaz);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "uiHelp";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pomoć";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button uiActionIzlaz;
        private System.Windows.Forms.RichTextBox uiOutputPrikazPomoci;
    }
}