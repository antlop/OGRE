namespace OGRE
{
    partial class LoginPage
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
            this.LoginScreen = new System.Windows.Forms.Panel();
            this.LoggedInCheckBox = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.PasswordTextBox = new System.Windows.Forms.TextBox();
            this.UsernameTextBox = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.LoginScreen.SuspendLayout();
            this.SuspendLayout();
            // 
            // LoginScreen
            // 
            this.LoginScreen.Controls.Add(this.LoggedInCheckBox);
            this.LoginScreen.Controls.Add(this.label2);
            this.LoginScreen.Controls.Add(this.label1);
            this.LoginScreen.Controls.Add(this.PasswordTextBox);
            this.LoginScreen.Controls.Add(this.UsernameTextBox);
            this.LoginScreen.Controls.Add(this.button1);
            this.LoginScreen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LoginScreen.Location = new System.Drawing.Point(0, 0);
            this.LoginScreen.Name = "LoginScreen";
            this.LoginScreen.Size = new System.Drawing.Size(464, 223);
            this.LoginScreen.TabIndex = 2;
            // 
            // LoggedInCheckBox
            // 
            this.LoggedInCheckBox.AutoSize = true;
            this.LoggedInCheckBox.Enabled = false;
            this.LoggedInCheckBox.Location = new System.Drawing.Point(169, 197);
            this.LoggedInCheckBox.Name = "LoggedInCheckBox";
            this.LoggedInCheckBox.Size = new System.Drawing.Size(134, 19);
            this.LoggedInCheckBox.TabIndex = 5;
            this.LoggedInCheckBox.Text = "Keep me Logged in";
            this.LoggedInCheckBox.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(89, 92);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 15);
            this.label2.TabIndex = 4;
            this.label2.Text = "Password:";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(89, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 15);
            this.label1.TabIndex = 3;
            this.label1.Text = "Username:";
            // 
            // PasswordTextBox
            // 
            this.PasswordTextBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.PasswordTextBox.Location = new System.Drawing.Point(89, 110);
            this.PasswordTextBox.Name = "PasswordTextBox";
            this.PasswordTextBox.Size = new System.Drawing.Size(291, 20);
            this.PasswordTextBox.TabIndex = 2;
            this.PasswordTextBox.Text = "Oatney";
            this.PasswordTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // UsernameTextBox
            // 
            this.UsernameTextBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.UsernameTextBox.Location = new System.Drawing.Point(89, 55);
            this.UsernameTextBox.Name = "UsernameTextBox";
            this.UsernameTextBox.Size = new System.Drawing.Size(291, 20);
            this.UsernameTextBox.TabIndex = 1;
            this.UsernameTextBox.Text = "Devan";
            this.UsernameTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // button1
            // 
            this.button1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button1.Location = new System.Drawing.Point(169, 146);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(135, 45);
            this.button1.TabIndex = 0;
            this.button1.Text = "Sign In";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // LoginPage
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(464, 223);
            this.ControlBox = false;
            this.Controls.Add(this.LoginScreen);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "LoginPage";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "LoginPage";
            this.LoginScreen.ResumeLayout(false);
            this.LoginScreen.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel LoginScreen;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox PasswordTextBox;
        private System.Windows.Forms.TextBox UsernameTextBox;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckBox LoggedInCheckBox;
    }
}