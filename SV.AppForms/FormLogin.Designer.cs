namespace SV.AppForms
{
    partial class FormLogin
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
            GbLogin = new GroupBox();
            CmbShift = new ComboBox();
            label3 = new Label();
            BtnLogin = new Button();
            TxtPassword = new TextBox();
            TxtUsername = new TextBox();
            label2 = new Label();
            label1 = new Label();
            GbLogin.SuspendLayout();
            SuspendLayout();
            // 
            // GbLogin
            // 
            GbLogin.Controls.Add(CmbShift);
            GbLogin.Controls.Add(label3);
            GbLogin.Controls.Add(BtnLogin);
            GbLogin.Controls.Add(TxtPassword);
            GbLogin.Controls.Add(TxtUsername);
            GbLogin.Controls.Add(label2);
            GbLogin.Controls.Add(label1);
            GbLogin.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            GbLogin.Location = new Point(28, 12);
            GbLogin.Name = "GbLogin";
            GbLogin.Size = new Size(402, 282);
            GbLogin.TabIndex = 0;
            GbLogin.TabStop = false;
            GbLogin.Text = "Iniciar sesión";
            // 
            // CmbShift
            // 
            CmbShift.DropDownStyle = ComboBoxStyle.DropDownList;
            CmbShift.FormattingEnabled = true;
            CmbShift.Location = new Point(147, 153);
            CmbShift.Name = "CmbShift";
            CmbShift.Size = new Size(146, 29);
            CmbShift.TabIndex = 6;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(36, 156);
            label3.Name = "label3";
            label3.Size = new Size(68, 21);
            label3.TabIndex = 5;
            label3.Text = "Jornada:";
            // 
            // BtnLogin
            // 
            BtnLogin.Location = new Point(129, 226);
            BtnLogin.Name = "BtnLogin";
            BtnLogin.Size = new Size(154, 37);
            BtnLogin.TabIndex = 4;
            BtnLogin.Text = "Entrar";
            BtnLogin.UseVisualStyleBackColor = true;
            BtnLogin.Click += BtnLogin_Click;
            // 
            // TxtPassword
            // 
            TxtPassword.Location = new Point(147, 106);
            TxtPassword.Name = "TxtPassword";
            TxtPassword.Size = new Size(237, 29);
            TxtPassword.TabIndex = 3;
            TxtPassword.Text = "admin";
            TxtPassword.UseSystemPasswordChar = true;
            // 
            // TxtUsername
            // 
            TxtUsername.Location = new Point(147, 59);
            TxtUsername.Name = "TxtUsername";
            TxtUsername.Size = new Size(237, 29);
            TxtUsername.TabIndex = 2;
            TxtUsername.Text = "admin";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(36, 109);
            label2.Name = "label2";
            label2.Size = new Size(92, 21);
            label2.TabIndex = 1;
            label2.Text = "Contraseña:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(36, 62);
            label1.Name = "label1";
            label1.Size = new Size(67, 21);
            label1.TabIndex = 0;
            label1.Text = "Usuario:";
            // 
            // FormLogin
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(458, 319);
            Controls.Add(GbLogin);
            Name = "FormLogin";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Login";
            Load += FormLogin_Load;
            GbLogin.ResumeLayout(false);
            GbLogin.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox GbLogin;
        private Label label2;
        private Label label1;
        private Button BtnLogin;
        private TextBox TxtPassword;
        private TextBox TxtUsername;
        private ComboBox CmbShift;
        private Label label3;
    }
}