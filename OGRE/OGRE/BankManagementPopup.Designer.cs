namespace OGRE
{
    partial class BankManagementPopup
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
            this.ApproveButton = new System.Windows.Forms.Button();
            this.AddItemToEventButton = new System.Windows.Forms.Button();
            this.RemoveItemButton = new System.Windows.Forms.Button();
            this.ItemNameLabel = new System.Windows.Forms.Label();
            this.IconPictureBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.IconPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // ApproveButton
            // 
            this.ApproveButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.ApproveButton.Location = new System.Drawing.Point(28, 113);
            this.ApproveButton.Name = "ApproveButton";
            this.ApproveButton.Size = new System.Drawing.Size(238, 41);
            this.ApproveButton.TabIndex = 0;
            this.ApproveButton.Text = "Approve Item";
            this.ApproveButton.UseVisualStyleBackColor = true;
            this.ApproveButton.Click += new System.EventHandler(this.ApproveButton_Click);
            // 
            // AddItemToEventButton
            // 
            this.AddItemToEventButton.Location = new System.Drawing.Point(28, 160);
            this.AddItemToEventButton.Name = "AddItemToEventButton";
            this.AddItemToEventButton.Size = new System.Drawing.Size(238, 41);
            this.AddItemToEventButton.TabIndex = 1;
            this.AddItemToEventButton.Text = "Add Item To Event";
            this.AddItemToEventButton.UseVisualStyleBackColor = true;
            this.AddItemToEventButton.Click += new System.EventHandler(this.AddItemToEventButton_Click);
            // 
            // RemoveItemButton
            // 
            this.RemoveItemButton.Location = new System.Drawing.Point(28, 207);
            this.RemoveItemButton.Name = "RemoveItemButton";
            this.RemoveItemButton.Size = new System.Drawing.Size(238, 41);
            this.RemoveItemButton.TabIndex = 2;
            this.RemoveItemButton.Text = "Remove Item";
            this.RemoveItemButton.UseVisualStyleBackColor = true;
            this.RemoveItemButton.Click += new System.EventHandler(this.RemoveItemButton_Click);
            // 
            // ItemNameLabel
            // 
            this.ItemNameLabel.AutoEllipsis = true;
            this.ItemNameLabel.AutoSize = true;
            this.ItemNameLabel.Location = new System.Drawing.Point(98, 13);
            this.ItemNameLabel.Name = "ItemNameLabel";
            this.ItemNameLabel.Size = new System.Drawing.Size(41, 15);
            this.ItemNameLabel.TabIndex = 4;
            this.ItemNameLabel.Text = "label1";
            // 
            // IconPictureBox
            // 
            this.IconPictureBox.Location = new System.Drawing.Point(28, 13);
            this.IconPictureBox.Name = "IconPictureBox";
            this.IconPictureBox.Size = new System.Drawing.Size(64, 64);
            this.IconPictureBox.TabIndex = 3;
            this.IconPictureBox.TabStop = false;
            // 
            // BankManagementPopup
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(295, 279);
            this.Controls.Add(this.ItemNameLabel);
            this.Controls.Add(this.IconPictureBox);
            this.Controls.Add(this.RemoveItemButton);
            this.Controls.Add(this.AddItemToEventButton);
            this.Controls.Add(this.ApproveButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "BankManagementPopup";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Management";
            ((System.ComponentModel.ISupportInitialize)(this.IconPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ApproveButton;
        private System.Windows.Forms.Button AddItemToEventButton;
        private System.Windows.Forms.Button RemoveItemButton;
        private System.Windows.Forms.PictureBox IconPictureBox;
        private System.Windows.Forms.Label ItemNameLabel;
    }
}