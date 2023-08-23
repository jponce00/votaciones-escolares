namespace SV.AppForms
{
    partial class FormUsers
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
            label1 = new Label();
            groupBox1 = new GroupBox();
            TxtOldPassword = new TextBox();
            TxtConfirmPassword = new TextBox();
            label5 = new Label();
            label4 = new Label();
            TxtPassword = new TextBox();
            TxtUsername = new TextBox();
            TxtName = new TextBox();
            label3 = new Label();
            label2 = new Label();
            BtnSave = new Button();
            BtnClose = new Button();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(18, 46);
            label1.Name = "label1";
            label1.Size = new Size(71, 21);
            label1.TabIndex = 0;
            label1.Text = "Nombre:";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(TxtOldPassword);
            groupBox1.Controls.Add(TxtConfirmPassword);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(TxtPassword);
            groupBox1.Controls.Add(TxtUsername);
            groupBox1.Controls.Add(TxtName);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(547, 305);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "Datos";
            // 
            // TxtOldPassword
            // 
            TxtOldPassword.Location = new Point(207, 245);
            TxtOldPassword.Name = "TxtOldPassword";
            TxtOldPassword.Size = new Size(173, 29);
            TxtOldPassword.TabIndex = 9;
            TxtOldPassword.UseSystemPasswordChar = true;
            // 
            // TxtConfirmPassword
            // 
            TxtConfirmPassword.Location = new Point(207, 193);
            TxtConfirmPassword.Name = "TxtConfirmPassword";
            TxtConfirmPassword.Size = new Size(173, 29);
            TxtConfirmPassword.TabIndex = 8;
            TxtConfirmPassword.UseSystemPasswordChar = true;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(18, 248);
            label5.Name = "label5";
            label5.Size = new Size(137, 21);
            label5.TabIndex = 7;
            label5.Text = "Contraseña actual:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(18, 196);
            label4.Name = "label4";
            label4.Size = new Size(164, 21);
            label4.TabIndex = 6;
            label4.Text = "Confirmar contraseña:";
            // 
            // TxtPassword
            // 
            TxtPassword.Location = new Point(207, 142);
            TxtPassword.Name = "TxtPassword";
            TxtPassword.Size = new Size(173, 29);
            TxtPassword.TabIndex = 5;
            TxtPassword.UseSystemPasswordChar = true;
            TxtPassword.KeyUp += TxtPassword_KeyUp;
            // 
            // TxtUsername
            // 
            TxtUsername.Location = new Point(207, 93);
            TxtUsername.Name = "TxtUsername";
            TxtUsername.Size = new Size(173, 29);
            TxtUsername.TabIndex = 4;
            // 
            // TxtName
            // 
            TxtName.Location = new Point(207, 43);
            TxtName.Name = "TxtName";
            TxtName.Size = new Size(319, 29);
            TxtName.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(18, 96);
            label3.Name = "label3";
            label3.Size = new Size(67, 21);
            label3.TabIndex = 2;
            label3.Text = "Usuario:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(18, 145);
            label2.Name = "label2";
            label2.Size = new Size(138, 21);
            label2.TabIndex = 1;
            label2.Text = "Nueva contraseña:";
            // 
            // BtnSave
            // 
            BtnSave.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            BtnSave.Location = new Point(361, 333);
            BtnSave.Name = "BtnSave";
            BtnSave.Size = new Size(92, 35);
            BtnSave.TabIndex = 2;
            BtnSave.Text = "Guardar";
            BtnSave.UseVisualStyleBackColor = true;
            BtnSave.Click += BtnSave_Click;
            // 
            // BtnClose
            // 
            BtnClose.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            BtnClose.Location = new Point(459, 333);
            BtnClose.Name = "BtnClose";
            BtnClose.Size = new Size(100, 35);
            BtnClose.TabIndex = 3;
            BtnClose.Text = "Cerrar";
            BtnClose.UseVisualStyleBackColor = true;
            // 
            // FormUsers
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(571, 383);
            Controls.Add(BtnClose);
            Controls.Add(BtnSave);
            Controls.Add(groupBox1);
            MaximizeBox = false;
            Name = "FormUsers";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Control de usuario";
            Load += FormUsers_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label label1;
        private GroupBox groupBox1;
        private Label label2;
        private TextBox TxtUsername;
        private TextBox TxtName;
        private Label label3;
        private TextBox TxtOldPassword;
        private TextBox TxtConfirmPassword;
        private Label label5;
        private Label label4;
        private TextBox TxtPassword;
        private Button BtnSave;
        private Button BtnClose;
    }
}