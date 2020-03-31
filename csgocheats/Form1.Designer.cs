namespace csgocheats
{
    partial class main
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
            this.ghostHackLabel = new System.Windows.Forms.Label();
            this.ghostHackButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.wallHacksDeactivate = new System.Windows.Forms.Button();
            this.cheatStatus = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.SuspendLayout();
            // 
            // ghostHackLabel
            // 
            this.ghostHackLabel.AutoSize = true;
            this.ghostHackLabel.Location = new System.Drawing.Point(12, 86);
            this.ghostHackLabel.Name = "ghostHackLabel";
            this.ghostHackLabel.Size = new System.Drawing.Size(149, 20);
            this.ghostHackLabel.TabIndex = 0;
            this.ghostHackLabel.Text = "Activate Wall Hacks";
            this.ghostHackLabel.Click += new System.EventHandler(this.Label1_Click);
            // 
            // ghostHackButton
            // 
            this.ghostHackButton.Location = new System.Drawing.Point(191, 78);
            this.ghostHackButton.Name = "ghostHackButton";
            this.ghostHackButton.Size = new System.Drawing.Size(86, 37);
            this.ghostHackButton.TabIndex = 1;
            this.ghostHackButton.Text = "Activate";
            this.ghostHackButton.UseVisualStyleBackColor = true;
            this.ghostHackButton.Click += new System.EventHandler(this.GhostHackButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(640, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Currently, limit features are available. This will simply allow you to toggle wal" +
    "l hacks for now.";
            this.label1.Click += new System.EventHandler(this.Label1_Click_1);
            // 
            // wallHacksDeactivate
            // 
            this.wallHacksDeactivate.Enabled = false;
            this.wallHacksDeactivate.Location = new System.Drawing.Point(283, 78);
            this.wallHacksDeactivate.Name = "wallHacksDeactivate";
            this.wallHacksDeactivate.Size = new System.Drawing.Size(130, 37);
            this.wallHacksDeactivate.TabIndex = 3;
            this.wallHacksDeactivate.Text = "Deactivate";
            this.wallHacksDeactivate.UseVisualStyleBackColor = true;
            this.wallHacksDeactivate.Click += new System.EventHandler(this.WallHacksDeactivate_Click);
            // 
            // cheatStatus
            // 
            this.cheatStatus.AutoSize = true;
            this.cheatStatus.Location = new System.Drawing.Point(22, 49);
            this.cheatStatus.Name = "cheatStatus";
            this.cheatStatus.Size = new System.Drawing.Size(139, 20);
            this.cheatStatus.TabIndex = 4;
            this.cheatStatus.Text = "Status: Up to date";
            this.cheatStatus.Click += new System.EventHandler(this.Label2_Click);
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BackgroundWorker1_DoWork);
            // 
            // main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(705, 140);
            this.Controls.Add(this.cheatStatus);
            this.Controls.Add(this.wallHacksDeactivate);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ghostHackButton);
            this.Controls.Add(this.ghostHackLabel);
            this.Name = "main";
            this.Text = "CSGO Trainer";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label ghostHackLabel;
        private System.Windows.Forms.Button ghostHackButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button wallHacksDeactivate;
        private System.Windows.Forms.Label cheatStatus;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}

