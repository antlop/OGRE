namespace OGRE
{
    partial class MainPage
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
            this.MainTabControl = new System.Windows.Forms.TabControl();
            this.BankTab = new System.Windows.Forms.TabPage();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.label1 = new System.Windows.Forms.Label();
            this.TabComboBox = new System.Windows.Forms.ComboBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.EventTab = new System.Windows.Forms.TabPage();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.CurrentEventEntries = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.eventTokenSubmissionCount = new System.Windows.Forms.NumericUpDown();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.EventItemsList = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.AddBankTabButton = new System.Windows.Forms.Button();
            this.NewTabNameTextBox = new System.Windows.Forms.TextBox();
            this.ManageBankTabButton = new System.Windows.Forms.Button();
            this.SelectedItemIcon = new System.Windows.Forms.PictureBox();
            this.AddonPathTextBox = new System.Windows.Forms.TextBox();
            this.FolderDialButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.MainTabControl.SuspendLayout();
            this.BankTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.EventTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.eventTokenSubmissionCount)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SelectedItemIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // MainTabControl
            // 
            this.MainTabControl.Controls.Add(this.BankTab);
            this.MainTabControl.Controls.Add(this.EventTab);
            this.MainTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainTabControl.Location = new System.Drawing.Point(0, 0);
            this.MainTabControl.Multiline = true;
            this.MainTabControl.Name = "MainTabControl";
            this.MainTabControl.SelectedIndex = 0;
            this.MainTabControl.Size = new System.Drawing.Size(800, 450);
            this.MainTabControl.TabIndex = 6;
            this.MainTabControl.Visible = false;
            this.MainTabControl.SelectedIndexChanged += new System.EventHandler(this.MainTabControl_SelectedIndexChanged);
            // 
            // BankTab
            // 
            this.BankTab.Controls.Add(this.splitContainer1);
            this.BankTab.Location = new System.Drawing.Point(4, 22);
            this.BankTab.Name = "BankTab";
            this.BankTab.Padding = new System.Windows.Forms.Padding(3);
            this.BankTab.Size = new System.Drawing.Size(792, 424);
            this.BankTab.TabIndex = 0;
            this.BankTab.Text = "Bank";
            this.BankTab.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(3, 3);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.label3);
            this.splitContainer1.Panel1.Controls.Add(this.FolderDialButton);
            this.splitContainer1.Panel1.Controls.Add(this.AddonPathTextBox);
            this.splitContainer1.Panel1.Controls.Add(this.NewTabNameTextBox);
            this.splitContainer1.Panel1.Controls.Add(this.AddBankTabButton);
            this.splitContainer1.Panel1.Controls.Add(this.ManageBankTabButton);
            this.splitContainer1.Panel1.Controls.Add(this.groupBox1);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Controls.Add(this.TabComboBox);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tableLayoutPanel2);
            this.splitContainer1.Size = new System.Drawing.Size(786, 418);
            this.splitContainer1.SplitterDistance = 262;
            this.splitContainer1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Bank Tab:";
            // 
            // TabComboBox
            // 
            this.TabComboBox.FormattingEnabled = true;
            this.TabComboBox.Location = new System.Drawing.Point(3, 24);
            this.TabComboBox.Name = "TabComboBox";
            this.TabComboBox.Size = new System.Drawing.Size(203, 21);
            this.TabComboBox.TabIndex = 0;
            this.TabComboBox.SelectedIndexChanged += new System.EventHandler(this.TabComboBox_SelectedIndexChanged);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.AutoScroll = true;
            this.tableLayoutPanel2.BackColor = System.Drawing.Color.White;
            this.tableLayoutPanel2.ColumnCount = 4;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(518, 416);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // EventTab
            // 
            this.EventTab.Controls.Add(this.splitContainer2);
            this.EventTab.Location = new System.Drawing.Point(4, 22);
            this.EventTab.Name = "EventTab";
            this.EventTab.Padding = new System.Windows.Forms.Padding(3);
            this.EventTab.Size = new System.Drawing.Size(792, 424);
            this.EventTab.TabIndex = 1;
            this.EventTab.Text = "Event";
            this.EventTab.UseVisualStyleBackColor = true;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(3, 3);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.CurrentEventEntries);
            this.splitContainer2.Panel1.Controls.Add(this.label2);
            this.splitContainer2.Panel1.Controls.Add(this.eventTokenSubmissionCount);
            this.splitContainer2.Panel1.Controls.Add(this.button2);
            this.splitContainer2.Panel1.Controls.Add(this.button1);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.EventItemsList);
            this.splitContainer2.Size = new System.Drawing.Size(786, 418);
            this.splitContainer2.SplitterDistance = 364;
            this.splitContainer2.TabIndex = 0;
            // 
            // CurrentEventEntries
            // 
            this.CurrentEventEntries.AutoSize = true;
            this.CurrentEventEntries.Location = new System.Drawing.Point(27, 169);
            this.CurrentEventEntries.Name = "CurrentEventEntries";
            this.CurrentEventEntries.Size = new System.Drawing.Size(201, 15);
            this.CurrentEventEntries.TabIndex = 4;
            this.CurrentEventEntries.Text = "Number of Tickets in Current Event: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(27, 101);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(156, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "Number Of Banked Tickets:";
            // 
            // eventTokenSubmissionCount
            // 
            this.eventTokenSubmissionCount.Location = new System.Drawing.Point(30, 253);
            this.eventTokenSubmissionCount.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.eventTokenSubmissionCount.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.eventTokenSubmissionCount.Name = "eventTokenSubmissionCount";
            this.eventTokenSubmissionCount.Size = new System.Drawing.Size(120, 20);
            this.eventTokenSubmissionCount.TabIndex = 2;
            this.eventTokenSubmissionCount.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(30, 208);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(301, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "Add Single Ticket";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.Button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(156, 250);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(175, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Add Multiple Tickets";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // EventItemsList
            // 
            this.EventItemsList.AutoScroll = true;
            this.EventItemsList.BackColor = System.Drawing.Color.Lime;
            this.EventItemsList.ColumnCount = 4;
            this.EventItemsList.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.EventItemsList.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.EventItemsList.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.EventItemsList.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.EventItemsList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.EventItemsList.Location = new System.Drawing.Point(0, 0);
            this.EventItemsList.Name = "EventItemsList";
            this.EventItemsList.RowCount = 2;
            this.EventItemsList.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.EventItemsList.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.EventItemsList.Size = new System.Drawing.Size(418, 418);
            this.EventItemsList.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.SelectedItemIcon);
            this.groupBox1.Location = new System.Drawing.Point(4, 217);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(253, 195);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // AddBankTabButton
            // 
            this.AddBankTabButton.Location = new System.Drawing.Point(212, 60);
            this.AddBankTabButton.Name = "AddBankTabButton";
            this.AddBankTabButton.Size = new System.Drawing.Size(44, 23);
            this.AddBankTabButton.TabIndex = 4;
            this.AddBankTabButton.Text = "Add";
            this.AddBankTabButton.UseVisualStyleBackColor = true;
            // 
            // NewTabNameTextBox
            // 
            this.NewTabNameTextBox.Location = new System.Drawing.Point(3, 62);
            this.NewTabNameTextBox.Name = "NewTabNameTextBox";
            this.NewTabNameTextBox.Size = new System.Drawing.Size(203, 20);
            this.NewTabNameTextBox.TabIndex = 5;
            this.NewTabNameTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // ManageBankTabButton
            // 
            this.ManageBankTabButton.BackgroundImage = global::OGRE.Properties.Resources._84380;
            this.ManageBankTabButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ManageBankTabButton.Location = new System.Drawing.Point(226, 24);
            this.ManageBankTabButton.Name = "ManageBankTabButton";
            this.ManageBankTabButton.Size = new System.Drawing.Size(25, 23);
            this.ManageBankTabButton.TabIndex = 3;
            this.ManageBankTabButton.UseVisualStyleBackColor = true;
            this.ManageBankTabButton.Click += new System.EventHandler(this.ManageBankTabButton_Click);
            // 
            // SelectedItemIcon
            // 
            this.SelectedItemIcon.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SelectedItemIcon.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.SelectedItemIcon.Location = new System.Drawing.Point(183, 19);
            this.SelectedItemIcon.Margin = new System.Windows.Forms.Padding(0);
            this.SelectedItemIcon.MinimumSize = new System.Drawing.Size(64, 64);
            this.SelectedItemIcon.Name = "SelectedItemIcon";
            this.SelectedItemIcon.Size = new System.Drawing.Size(64, 64);
            this.SelectedItemIcon.TabIndex = 0;
            this.SelectedItemIcon.TabStop = false;
            // 
            // AddonPathTextBox
            // 
            this.AddonPathTextBox.Location = new System.Drawing.Point(78, 93);
            this.AddonPathTextBox.Name = "AddonPathTextBox";
            this.AddonPathTextBox.Size = new System.Drawing.Size(127, 20);
            this.AddonPathTextBox.TabIndex = 6;
            // 
            // FolderDialButton
            // 
            this.FolderDialButton.Location = new System.Drawing.Point(213, 91);
            this.FolderDialButton.Name = "FolderDialButton";
            this.FolderDialButton.Size = new System.Drawing.Size(44, 23);
            this.FolderDialButton.TabIndex = 7;
            this.FolderDialButton.UseVisualStyleBackColor = true;
            this.FolderDialButton.Click += new System.EventHandler(this.FolderDialButton_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 96);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 15);
            this.label3.TabIndex = 8;
            this.label3.Text = "Addon Path:";
            // 
            // MainPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.MainTabControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainPage";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "OGRE";
            this.MainTabControl.ResumeLayout(false);
            this.BankTab.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.EventTab.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.eventTokenSubmissionCount)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SelectedItemIcon)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl MainTabControl;
        private System.Windows.Forms.TabPage BankTab;
        private System.Windows.Forms.TabPage EventTab;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ComboBox TabComboBox;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.Label CurrentEventEntries;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown eventTokenSubmissionCount;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TableLayoutPanel EventItemsList;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.PictureBox SelectedItemIcon;
        private System.Windows.Forms.TextBox NewTabNameTextBox;
        private System.Windows.Forms.Button AddBankTabButton;
        private System.Windows.Forms.Button ManageBankTabButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button FolderDialButton;
        private System.Windows.Forms.TextBox AddonPathTextBox;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
    }
}

