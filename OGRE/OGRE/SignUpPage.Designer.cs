namespace OGRE
{
    partial class SignUpPage
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
            this.label3 = new System.Windows.Forms.Label();
            this.BankKeyTextBox = new System.Windows.Forms.TextBox();
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
            this.LoginScreen.Controls.Add(this.label3);
            this.LoginScreen.Controls.Add(this.BankKeyTextBox);
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
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(77, 134);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(118, 15);
            this.label3.TabIndex = 6;
            this.label3.Text = "Guild Bank Passkey:";
            // 
            // BankKeyTextBox
            // 
            this.BankKeyTextBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.BankKeyTextBox.Location = new System.Drawing.Point(77, 152);
            this.BankKeyTextBox.Name = "BankKeyTextBox";
            this.BankKeyTextBox.Size = new System.Drawing.Size(291, 20);
            this.BankKeyTextBox.TabIndex = 5;
            this.BankKeyTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(77, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 15);
            this.label2.TabIndex = 4;
            this.label2.Text = "Password:";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(77, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(228, 15);
            this.label1.TabIndex = 3;
            this.label1.Text = "Enter The Name of Your Main Character:";
            // 
            // PasswordTextBox
            // 
            this.PasswordTextBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.PasswordTextBox.Location = new System.Drawing.Point(77, 97);
            this.PasswordTextBox.Name = "PasswordTextBox";
            this.PasswordTextBox.Size = new System.Drawing.Size(291, 20);
            this.PasswordTextBox.TabIndex = 2;
            this.PasswordTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // UsernameTextBox
            // 
            this.UsernameTextBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.UsernameTextBox.Location = new System.Drawing.Point(77, 44);
            this.UsernameTextBox.Name = "UsernameTextBox";
            this.UsernameTextBox.Size = new System.Drawing.Size(291, 20);
            this.UsernameTextBox.TabIndex = 1;
            this.UsernameTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // button1
            // 
            this.button1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button1.Location = new System.Drawing.Point(152, 184);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(135, 27);
            this.button1.TabIndex = 0;
            this.button1.Text = "Sign Up";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // SignUpPage
            // 
            this.AcceptButton = this.button1;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(464, 223);
            this.Controls.Add(this.LoginScreen);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "SignUpPage";
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
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox BankKeyTextBox;
    }
}