namespace OGRE
{
    partial class SubmissionsManagement
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
            this.SubmissionsListBox = new System.Windows.Forms.ListBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.SubmitManualEntryButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.ManualEntryNumberIncrementor = new System.Windows.Forms.NumericUpDown();
            this.ManualEntryNameTextBox = new System.Windows.Forms.TextBox();
            this.button4 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ManualEntryNumberIncrementor)).BeginInit();
            this.SuspendLayout();
            // 
            // SubmissionsListBox
            // 
            this.SubmissionsListBox.FormattingEnabled = true;
            this.SubmissionsListBox.Location = new System.Drawing.Point(12, 12);
            this.SubmissionsListBox.Name = "SubmissionsListBox";
            this.SubmissionsListBox.Size = new System.Drawing.Size(360, 290);
            this.SubmissionsListBox.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 308);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(158, 25);
            this.button1.TabIndex = 1;
            this.button1.Text = "Remove Selected";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(176, 308);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(196, 25);
            this.button2.TabIndex = 2;
            this.button2.Text = "Remove And Refund Selected";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.SubmitManualEntryButton);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.ManualEntryNumberIncrementor);
            this.groupBox1.Controls.Add(this.ManualEntryNameTextBox);
            this.groupBox1.Location = new System.Drawing.Point(12, 370);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(360, 127);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Manual Entry";
            // 
            // SubmitManualEntryButton
            // 
            this.SubmitManualEntryButton.Location = new System.Drawing.Point(74, 96);
            this.SubmitManualEntryButton.Name = "SubmitManualEntryButton";
            this.SubmitManualEntryButton.Size = new System.Drawing.Size(218, 25);
            this.SubmitManualEntryButton.TabIndex = 4;
            this.SubmitManualEntryButton.Text = "Submit";
            this.SubmitManualEntryButton.UseVisualStyleBackColor = true;
            this.SubmitManualEntryButton.Click += new System.EventHandler(this.SubmitManualEntryButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "Entry Amount";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(53, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "Name";
            // 
            // ManualEntryNumberIncrementor
            // 
            this.ManualEntryNumberIncrementor.Location = new System.Drawing.Point(100, 56);
            this.ManualEntryNumberIncrementor.Maximum = new decimal(new int[] {
            9999999,
            0,
            0,
            0});
            this.ManualEntryNumberIncrementor.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.ManualEntryNumberIncrementor.Name = "ManualEntryNumberIncrementor";
            this.ManualEntryNumberIncrementor.Size = new System.Drawing.Size(254, 20);
            this.ManualEntryNumberIncrementor.TabIndex = 1;
            this.ManualEntryNumberIncrementor.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ManualEntryNumberIncrementor.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // ManualEntryNameTextBox
            // 
            this.ManualEntryNameTextBox.Location = new System.Drawing.Point(100, 29);
            this.ManualEntryNameTextBox.Name = "ManualEntryNameTextBox";
            this.ManualEntryNameTextBox.Size = new System.Drawing.Size(254, 20);
            this.ManualEntryNameTextBox.TabIndex = 0;
            this.ManualEntryNameTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(12, 339);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(360, 25);
            this.button4.TabIndex = 5;
            this.button4.Text = "Decrement Selected Entry by 1";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.Button4_Click);
            // 
            // SubmissionsManagement
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(384, 509);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.SubmissionsListBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SubmissionsManagement";
            this.ShowInTaskbar = false;
            this.Text = "EVENT SUBMISSIONS";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ManualEntryNumberIncrementor)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox SubmissionsListBox;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button SubmitManualEntryButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown ManualEntryNumberIncrementor;
        private System.Windows.Forms.TextBox ManualEntryNameTextBox;
        private System.Windows.Forms.Button button4;
    }
}