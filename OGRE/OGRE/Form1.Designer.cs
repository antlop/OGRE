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
            this.AddonPathLabel = new System.Windows.Forms.Label();
            this.FolderDialButton = new System.Windows.Forms.Button();
            this.AddonPathTextBox = new System.Windows.Forms.TextBox();
            this.NewTabNameTextBox = new System.Windows.Forms.TextBox();
            this.AddBankTabButton = new System.Windows.Forms.Button();
            this.ManageBankTabButton = new System.Windows.Forms.Button();
            this.ItemDetailGroupBox = new System.Windows.Forms.GroupBox();
            this.BankItemManage = new System.Windows.Forms.Button();
            this.SelectedItemIcon = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.TabComboBox = new System.Windows.Forms.ComboBox();
            this.BankListBox = new System.Windows.Forms.ListBox();
            this.EventTab = new System.Windows.Forms.TabPage();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.ManagementToolsBox = new System.Windows.Forms.GroupBox();
            this.ManageSubmissionsButton = new System.Windows.Forms.Button();
            this.EventWinnerLabel = new System.Windows.Forms.Label();
            this.RemoveEventItemButton = new System.Windows.Forms.Button();
            this.EventWinnerButton = new System.Windows.Forms.Button();
            this.SelectedItemLabel = new System.Windows.Forms.Label();
            this.CurrentEventEntries = new System.Windows.Forms.Label();
            this.BankedTicketsLabel = new System.Windows.Forms.Label();
            this.eventTokenSubmissionCount = new System.Windows.Forms.NumericUpDown();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.EventItemsList = new System.Windows.Forms.ListBox();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.BankKeyLabel = new System.Windows.Forms.Label();
            this.ChangeBankKeyButton = new System.Windows.Forms.Button();
            this.BankKeyTextBox = new System.Windows.Forms.TextBox();
            this.MainTabControl.SuspendLayout();
            this.BankTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.ItemDetailGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SelectedItemIcon)).BeginInit();
            this.EventTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.ManagementToolsBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.eventTokenSubmissionCount)).BeginInit();
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
            this.splitContainer1.Panel1.Controls.Add(this.BankKeyLabel);
            this.splitContainer1.Panel1.Controls.Add(this.ChangeBankKeyButton);
            this.splitContainer1.Panel1.Controls.Add(this.BankKeyTextBox);
            this.splitContainer1.Panel1.Controls.Add(this.AddonPathLabel);
            this.splitContainer1.Panel1.Controls.Add(this.FolderDialButton);
            this.splitContainer1.Panel1.Controls.Add(this.AddonPathTextBox);
            this.splitContainer1.Panel1.Controls.Add(this.NewTabNameTextBox);
            this.splitContainer1.Panel1.Controls.Add(this.AddBankTabButton);
            this.splitContainer1.Panel1.Controls.Add(this.ManageBankTabButton);
            this.splitContainer1.Panel1.Controls.Add(this.ItemDetailGroupBox);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Controls.Add(this.TabComboBox);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.BankListBox);
            this.splitContainer1.Size = new System.Drawing.Size(786, 418);
            this.splitContainer1.SplitterDistance = 262;
            this.splitContainer1.TabIndex = 0;
            // 
            // AddonPathLabel
            // 
            this.AddonPathLabel.AutoSize = true;
            this.AddonPathLabel.Location = new System.Drawing.Point(4, 96);
            this.AddonPathLabel.Name = "AddonPathLabel";
            this.AddonPathLabel.Size = new System.Drawing.Size(73, 15);
            this.AddonPathLabel.TabIndex = 8;
            this.AddonPathLabel.Text = "Addon Path:";
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
            // AddonPathTextBox
            // 
            this.AddonPathTextBox.Location = new System.Drawing.Point(78, 93);
            this.AddonPathTextBox.Name = "AddonPathTextBox";
            this.AddonPathTextBox.Size = new System.Drawing.Size(127, 20);
            this.AddonPathTextBox.TabIndex = 6;
            // 
            // NewTabNameTextBox
            // 
            this.NewTabNameTextBox.Location = new System.Drawing.Point(3, 62);
            this.NewTabNameTextBox.Name = "NewTabNameTextBox";
            this.NewTabNameTextBox.Size = new System.Drawing.Size(203, 20);
            this.NewTabNameTextBox.TabIndex = 5;
            this.NewTabNameTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
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
            // ItemDetailGroupBox
            // 
            this.ItemDetailGroupBox.Controls.Add(this.BankItemManage);
            this.ItemDetailGroupBox.Controls.Add(this.SelectedItemIcon);
            this.ItemDetailGroupBox.Location = new System.Drawing.Point(4, 217);
            this.ItemDetailGroupBox.Name = "ItemDetailGroupBox";
            this.ItemDetailGroupBox.Size = new System.Drawing.Size(253, 195);
            this.ItemDetailGroupBox.TabIndex = 2;
            this.ItemDetailGroupBox.TabStop = false;
            // 
            // BankItemManage
            // 
            this.BankItemManage.Location = new System.Drawing.Point(183, 86);
            this.BankItemManage.Name = "BankItemManage";
            this.BankItemManage.Size = new System.Drawing.Size(64, 23);
            this.BankItemManage.TabIndex = 9;
            this.BankItemManage.Text = "Manage";
            this.BankItemManage.UseVisualStyleBackColor = true;
            this.BankItemManage.Click += new System.EventHandler(this.BankItemManage_Click);
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
            // BankListBox
            // 
            this.BankListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BankListBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.BankListBox.FormattingEnabled = true;
            this.BankListBox.Location = new System.Drawing.Point(0, 0);
            this.BankListBox.Name = "BankListBox";
            this.BankListBox.Size = new System.Drawing.Size(518, 416);
            this.BankListBox.TabIndex = 0;
            this.BankListBox.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.BankListBox_DrawItem);
            this.BankListBox.SelectedIndexChanged += new System.EventHandler(this.BankListBox_SelectedIndexChanged);
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
            this.splitContainer2.Panel1.Controls.Add(this.ManagementToolsBox);
            this.splitContainer2.Panel1.Controls.Add(this.CurrentEventEntries);
            this.splitContainer2.Panel1.Controls.Add(this.BankedTicketsLabel);
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
            // ManagementToolsBox
            // 
            this.ManagementToolsBox.Controls.Add(this.ManageSubmissionsButton);
            this.ManagementToolsBox.Controls.Add(this.EventWinnerLabel);
            this.ManagementToolsBox.Controls.Add(this.RemoveEventItemButton);
            this.ManagementToolsBox.Controls.Add(this.EventWinnerButton);
            this.ManagementToolsBox.Controls.Add(this.SelectedItemLabel);
            this.ManagementToolsBox.Location = new System.Drawing.Point(30, 183);
            this.ManagementToolsBox.Name = "ManagementToolsBox";
            this.ManagementToolsBox.Size = new System.Drawing.Size(301, 230);
            this.ManagementToolsBox.TabIndex = 5;
            this.ManagementToolsBox.TabStop = false;
            this.ManagementToolsBox.Text = "Management Tools";
            // 
            // ManageSubmissionsButton
            // 
            this.ManageSubmissionsButton.Location = new System.Drawing.Point(6, 201);
            this.ManageSubmissionsButton.Name = "ManageSubmissionsButton";
            this.ManageSubmissionsButton.Size = new System.Drawing.Size(289, 23);
            this.ManageSubmissionsButton.TabIndex = 9;
            this.ManageSubmissionsButton.Text = "Manage Submissions";
            this.ManageSubmissionsButton.UseVisualStyleBackColor = true;
            this.ManageSubmissionsButton.Click += new System.EventHandler(this.ManageSubmissionsButton_Click);
            // 
            // EventWinnerLabel
            // 
            this.EventWinnerLabel.AutoSize = true;
            this.EventWinnerLabel.Location = new System.Drawing.Point(187, 48);
            this.EventWinnerLabel.Name = "EventWinnerLabel";
            this.EventWinnerLabel.Size = new System.Drawing.Size(70, 15);
            this.EventWinnerLabel.TabIndex = 8;
            this.EventWinnerLabel.Text = "...pending...";
            // 
            // RemoveEventItemButton
            // 
            this.RemoveEventItemButton.Location = new System.Drawing.Point(6, 111);
            this.RemoveEventItemButton.Name = "RemoveEventItemButton";
            this.RemoveEventItemButton.Size = new System.Drawing.Size(175, 23);
            this.RemoveEventItemButton.TabIndex = 7;
            this.RemoveEventItemButton.Text = "Remove Item From Event";
            this.RemoveEventItemButton.UseVisualStyleBackColor = true;
            this.RemoveEventItemButton.Click += new System.EventHandler(this.RemoveEventItemButton_Click);
            // 
            // EventWinnerButton
            // 
            this.EventWinnerButton.Location = new System.Drawing.Point(6, 43);
            this.EventWinnerButton.Name = "EventWinnerButton";
            this.EventWinnerButton.Size = new System.Drawing.Size(175, 23);
            this.EventWinnerButton.TabIndex = 6;
            this.EventWinnerButton.Text = "Roll For Winner";
            this.EventWinnerButton.UseVisualStyleBackColor = true;
            this.EventWinnerButton.Click += new System.EventHandler(this.EventWinnerButton_Click);
            // 
            // SelectedItemLabel
            // 
            this.SelectedItemLabel.AutoEllipsis = true;
            this.SelectedItemLabel.AutoSize = true;
            this.SelectedItemLabel.Location = new System.Drawing.Point(6, 93);
            this.SelectedItemLabel.Name = "SelectedItemLabel";
            this.SelectedItemLabel.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.SelectedItemLabel.Size = new System.Drawing.Size(41, 15);
            this.SelectedItemLabel.TabIndex = 0;
            this.SelectedItemLabel.Text = "label2";
            this.SelectedItemLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // CurrentEventEntries
            // 
            this.CurrentEventEntries.AutoSize = true;
            this.CurrentEventEntries.Location = new System.Drawing.Point(27, 60);
            this.CurrentEventEntries.Name = "CurrentEventEntries";
            this.CurrentEventEntries.Size = new System.Drawing.Size(201, 15);
            this.CurrentEventEntries.TabIndex = 4;
            this.CurrentEventEntries.Text = "Number of Tickets in Current Event: ";
            // 
            // BankedTicketsLabel
            // 
            this.BankedTicketsLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.BankedTicketsLabel.AutoSize = true;
            this.BankedTicketsLabel.Location = new System.Drawing.Point(27, 17);
            this.BankedTicketsLabel.Name = "BankedTicketsLabel";
            this.BankedTicketsLabel.Size = new System.Drawing.Size(156, 15);
            this.BankedTicketsLabel.TabIndex = 3;
            this.BankedTicketsLabel.Text = "Number Of Banked Tickets:";
            // 
            // eventTokenSubmissionCount
            // 
            this.eventTokenSubmissionCount.Location = new System.Drawing.Point(30, 136);
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
            this.button2.Location = new System.Drawing.Point(30, 94);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(301, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "Add Single Ticket";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.Button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(156, 136);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(175, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Add Multiple Tickets";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // EventItemsList
            // 
            this.EventItemsList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.EventItemsList.FormattingEnabled = true;
            this.EventItemsList.Location = new System.Drawing.Point(0, 0);
            this.EventItemsList.Name = "EventItemsList";
            this.EventItemsList.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.EventItemsList.Size = new System.Drawing.Size(418, 418);
            this.EventItemsList.TabIndex = 0;
            this.EventItemsList.SelectedIndexChanged += new System.EventHandler(this.EventItemsList_SelectedIndexChanged);
            // 
            // BankKeyLabel
            // 
            this.BankKeyLabel.AutoSize = true;
            this.BankKeyLabel.Location = new System.Drawing.Point(4, 133);
            this.BankKeyLabel.Name = "BankKeyLabel";
            this.BankKeyLabel.Size = new System.Drawing.Size(61, 15);
            this.BankKeyLabel.TabIndex = 11;
            this.BankKeyLabel.Text = "Bank Key:";
            // 
            // ChangeBankKeyButton
            // 
            this.ChangeBankKeyButton.Location = new System.Drawing.Point(168, 161);
            this.ChangeBankKeyButton.Name = "ChangeBankKeyButton";
            this.ChangeBankKeyButton.Size = new System.Drawing.Size(83, 23);
            this.ChangeBankKeyButton.TabIndex = 10;
            this.ChangeBankKeyButton.Text = "Change Key";
            this.ChangeBankKeyButton.UseVisualStyleBackColor = true;
            this.ChangeBankKeyButton.Click += new System.EventHandler(this.ChangeBankKeyButton_Click);
            // 
            // BankKeyTextBox
            // 
            this.BankKeyTextBox.Location = new System.Drawing.Point(4, 163);
            this.BankKeyTextBox.Name = "BankKeyTextBox";
            this.BankKeyTextBox.Size = new System.Drawing.Size(158, 20);
            this.BankKeyTextBox.TabIndex = 9;
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
            this.Shown += new System.EventHandler(this.MainPage_Shown);
            this.MainTabControl.ResumeLayout(false);
            this.BankTab.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ItemDetailGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SelectedItemIcon)).EndInit();
            this.EventTab.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.ManagementToolsBox.ResumeLayout(false);
            this.ManagementToolsBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.eventTokenSubmissionCount)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl MainTabControl;
        private System.Windows.Forms.TabPage BankTab;
        private System.Windows.Forms.TabPage EventTab;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ComboBox TabComboBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.Label CurrentEventEntries;
        private System.Windows.Forms.Label BankedTicketsLabel;
        private System.Windows.Forms.NumericUpDown eventTokenSubmissionCount;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox ItemDetailGroupBox;
        private System.Windows.Forms.PictureBox SelectedItemIcon;
        private System.Windows.Forms.TextBox NewTabNameTextBox;
        private System.Windows.Forms.Button AddBankTabButton;
        private System.Windows.Forms.Button ManageBankTabButton;
        private System.Windows.Forms.Label AddonPathLabel;
        private System.Windows.Forms.Button FolderDialButton;
        private System.Windows.Forms.TextBox AddonPathTextBox;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.ListBox EventItemsList;
        private System.Windows.Forms.ListBox BankListBox;
        private System.Windows.Forms.Button BankItemManage;
        private System.Windows.Forms.GroupBox ManagementToolsBox;
        private System.Windows.Forms.Button ManageSubmissionsButton;
        private System.Windows.Forms.Label EventWinnerLabel;
        private System.Windows.Forms.Button RemoveEventItemButton;
        private System.Windows.Forms.Button EventWinnerButton;
        private System.Windows.Forms.Label SelectedItemLabel;
        private System.Windows.Forms.Label BankKeyLabel;
        private System.Windows.Forms.Button ChangeBankKeyButton;
        private System.Windows.Forms.TextBox BankKeyTextBox;
    }
}

