
namespace The_Last_Days_Patcher
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panelDefault = new System.Windows.Forms.Panel();
            this.patchStats = new System.Windows.Forms.Label();
            this.fileCount = new System.Windows.Forms.Label();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.panelError = new System.Windows.Forms.Panel();
            this.tryAgain = new System.Windows.Forms.Button();
            this.errorTitle = new System.Windows.Forms.Label();
            this.credits = new System.Windows.Forms.Label();
            this.patcherTitle = new The_Last_Days_Patcher.TransparentLabel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panelDefault.SuspendLayout();
            this.panelError.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::The_Last_Days_Patcher.Properties.Resources.topimage;
            this.pictureBox1.Location = new System.Drawing.Point(-8, -3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(320, 160);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // panelDefault
            // 
            this.panelDefault.Controls.Add(this.patchStats);
            this.panelDefault.Controls.Add(this.fileCount);
            this.panelDefault.Controls.Add(this.progressBar);
            this.panelDefault.Location = new System.Drawing.Point(0, 157);
            this.panelDefault.Name = "panelDefault";
            this.panelDefault.Size = new System.Drawing.Size(304, 255);
            this.panelDefault.TabIndex = 6;
            this.panelDefault.Visible = false;
            // 
            // patchStats
            // 
            this.patchStats.AutoSize = true;
            this.patchStats.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.patchStats.Location = new System.Drawing.Point(28, 94);
            this.patchStats.Name = "patchStats";
            this.patchStats.Size = new System.Drawing.Size(113, 13);
            this.patchStats.TabIndex = 1;
            this.patchStats.Text = "Downloading Files...";
            this.patchStats.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // fileCount
            // 
            this.fileCount.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.fileCount.AutoSize = true;
            this.fileCount.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.fileCount.Location = new System.Drawing.Point(229, 94);
            this.fileCount.Name = "fileCount";
            this.fileCount.Size = new System.Drawing.Size(47, 13);
            this.fileCount.TabIndex = 2;
            this.fileCount.Text = "000/000";
            this.fileCount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(32, 111);
            this.progressBar.MarqueeAnimationSpeed = 1;
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(240, 23);
            this.progressBar.Step = 1;
            this.progressBar.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.progressBar.TabIndex = 0;
            // 
            // panelError
            // 
            this.panelError.Controls.Add(this.tryAgain);
            this.panelError.Controls.Add(this.errorTitle);
            this.panelError.Location = new System.Drawing.Point(0, 157);
            this.panelError.Name = "panelError";
            this.panelError.Size = new System.Drawing.Size(304, 255);
            this.panelError.TabIndex = 7;
            this.panelError.Visible = false;
            // 
            // tryAgain
            // 
            this.tryAgain.Location = new System.Drawing.Point(86, 168);
            this.tryAgain.Name = "tryAgain";
            this.tryAgain.Size = new System.Drawing.Size(133, 23);
            this.tryAgain.TabIndex = 1;
            this.tryAgain.Text = "Try Again";
            this.tryAgain.UseVisualStyleBackColor = true;
            this.tryAgain.Click += new System.EventHandler(this.tryAgain_Click);
            // 
            // errorTitle
            // 
            this.errorTitle.AutoSize = true;
            this.errorTitle.ForeColor = System.Drawing.Color.Crimson;
            this.errorTitle.Location = new System.Drawing.Point(5, 61);
            this.errorTitle.Name = "errorTitle";
            this.errorTitle.Size = new System.Drawing.Size(295, 90);
            this.errorTitle.TabIndex = 0;
            this.errorTitle.Text = resources.GetString("errorTitle.Text");
            this.errorTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // credits
            // 
            this.credits.AutoSize = true;
            this.credits.Font = new System.Drawing.Font("Segoe UI", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.credits.Location = new System.Drawing.Point(93, 416);
            this.credits.Name = "credits";
            this.credits.Size = new System.Drawing.Size(119, 12);
            this.credits.TabIndex = 8;
            this.credits.Text = "Patcher by Marcos Tomaz";
            // 
            // patcherTitle
            // 
            this.patcherTitle.AutoSize = true;
            this.patcherTitle.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.patcherTitle.ForeColor = System.Drawing.SystemColors.Window;
            this.patcherTitle.Location = new System.Drawing.Point(25, 49);
            this.patcherTitle.Name = "patcherTitle";
            this.patcherTitle.Size = new System.Drawing.Size(254, 37);
            this.patcherTitle.TabIndex = 9;
            this.patcherTitle.Text = "The Last Days Client";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(304, 431);
            this.Controls.Add(this.patcherTitle);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.credits);
            this.Controls.Add(this.panelDefault);
            this.Controls.Add(this.panelError);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "The Last Days Client Patcher";
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panelDefault.ResumeLayout(false);
            this.panelDefault.PerformLayout();
            this.panelError.ResumeLayout(false);
            this.panelError.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private TransparentLabel transparentLabel1;
        private TransparentLabel transparentLabel2;
        private System.Windows.Forms.Panel panelDefault;
        private System.Windows.Forms.Panel panelError;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Label errorTitle;
        private System.Windows.Forms.Button tryAgain;
        private System.Windows.Forms.Label credits;
        private System.Windows.Forms.Label patchStats;
        private System.Windows.Forms.Label fileCount;
        private TransparentLabel patcherTitle;
    }
}

