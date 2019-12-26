namespace PrintQueueManagement
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
            this.printerStatusLabel = new System.Windows.Forms.Label();
            this.compNameLabel = new System.Windows.Forms.Label();
            this.jobInfoLabel = new System.Windows.Forms.Label();
            this.loadingGif = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.loadingGif)).BeginInit();
            this.SuspendLayout();
            // 
            // printerStatusLabel
            // 
            this.printerStatusLabel.AutoSize = true;
            this.printerStatusLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.printerStatusLabel.Location = new System.Drawing.Point(420, 79);
            this.printerStatusLabel.Name = "printerStatusLabel";
            this.printerStatusLabel.Size = new System.Drawing.Size(85, 29);
            this.printerStatusLabel.TabIndex = 0;
            this.printerStatusLabel.Text = "label1";
            // 
            // compNameLabel
            // 
            this.compNameLabel.AutoSize = true;
            this.compNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.compNameLabel.Location = new System.Drawing.Point(13, 79);
            this.compNameLabel.Name = "compNameLabel";
            this.compNameLabel.Size = new System.Drawing.Size(79, 29);
            this.compNameLabel.TabIndex = 1;
            this.compNameLabel.Text = "label1";
            // 
            // jobInfoLabel
            // 
            this.jobInfoLabel.AutoSize = true;
            this.jobInfoLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.jobInfoLabel.Location = new System.Drawing.Point(13, 13);
            this.jobInfoLabel.Name = "jobInfoLabel";
            this.jobInfoLabel.Size = new System.Drawing.Size(79, 29);
            this.jobInfoLabel.TabIndex = 2;
            this.jobInfoLabel.Text = "label1";
            // 
            // loadingGif
            // 
            this.loadingGif.ErrorImage = null;
            this.loadingGif.Image = global::PrintQueueManagement.Properties.Resources.giphy;
            this.loadingGif.InitialImage = global::PrintQueueManagement.Properties.Resources.giphy;
            this.loadingGif.Location = new System.Drawing.Point(348, 49);
            this.loadingGif.Name = "loadingGif";
            this.loadingGif.Size = new System.Drawing.Size(66, 59);
            this.loadingGif.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.loadingGif.TabIndex = 3;
            this.loadingGif.TabStop = false;
            this.loadingGif.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(530, 117);
            this.Controls.Add(this.loadingGif);
            this.Controls.Add(this.jobInfoLabel);
            this.Controls.Add(this.compNameLabel);
            this.Controls.Add(this.printerStatusLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.Opacity = 0.6D;
            this.Text = "Form1";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.loadingGif)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label printerStatusLabel;
        private System.Windows.Forms.Label compNameLabel;
        private System.Windows.Forms.Label jobInfoLabel;
        private System.Windows.Forms.PictureBox loadingGif;
    }
}

