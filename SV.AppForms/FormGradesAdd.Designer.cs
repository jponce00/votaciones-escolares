namespace SV.AppForms
{
    partial class FormGradesAdd
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
            GBoxGradesAdd = new GroupBox();
            TxtSubName = new TextBox();
            TxtName = new TextBox();
            label2 = new Label();
            label1 = new Label();
            BtnAdd = new Button();
            BtnClose = new Button();
            GBoxGradesAdd.SuspendLayout();
            SuspendLayout();
            // 
            // GBoxGradesAdd
            // 
            GBoxGradesAdd.Controls.Add(TxtSubName);
            GBoxGradesAdd.Controls.Add(TxtName);
            GBoxGradesAdd.Controls.Add(label2);
            GBoxGradesAdd.Controls.Add(label1);
            GBoxGradesAdd.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            GBoxGradesAdd.Location = new Point(12, 12);
            GBoxGradesAdd.Name = "GBoxGradesAdd";
            GBoxGradesAdd.Size = new Size(526, 166);
            GBoxGradesAdd.TabIndex = 0;
            GBoxGradesAdd.TabStop = false;
            GBoxGradesAdd.Text = "Datos";
            // 
            // TxtSubName
            // 
            TxtSubName.Location = new Point(123, 94);
            TxtSubName.Name = "TxtSubName";
            TxtSubName.Size = new Size(100, 29);
            TxtSubName.TabIndex = 3;
            // 
            // TxtName
            // 
            TxtName.Location = new Point(123, 41);
            TxtName.Name = "TxtName";
            TxtName.Size = new Size(179, 29);
            TxtName.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(22, 97);
            label2.Name = "label2";
            label2.Size = new Size(66, 21);
            label2.TabIndex = 1;
            label2.Text = "Sección:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(22, 44);
            label1.Name = "label1";
            label1.Size = new Size(71, 21);
            label1.TabIndex = 0;
            label1.Text = "Nombre:";
            // 
            // BtnAdd
            // 
            BtnAdd.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            BtnAdd.Location = new Point(330, 193);
            BtnAdd.Name = "BtnAdd";
            BtnAdd.Size = new Size(101, 31);
            BtnAdd.TabIndex = 1;
            BtnAdd.Text = "Guardar";
            BtnAdd.UseVisualStyleBackColor = true;
            BtnAdd.Click += BtnAdd_Click;
            // 
            // BtnClose
            // 
            BtnClose.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            BtnClose.Location = new Point(437, 193);
            BtnClose.Name = "BtnClose";
            BtnClose.Size = new Size(101, 31);
            BtnClose.TabIndex = 2;
            BtnClose.Text = "Cerrar";
            BtnClose.UseVisualStyleBackColor = true;
            BtnClose.Click += BtnClose_Click;
            // 
            // FormGradesAdd
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(550, 243);
            Controls.Add(BtnClose);
            Controls.Add(BtnAdd);
            Controls.Add(GBoxGradesAdd);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "FormGradesAdd";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Grado";
            Load += FormGradesAdd_Load;
            GBoxGradesAdd.ResumeLayout(false);
            GBoxGradesAdd.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox GBoxGradesAdd;
        private Button BtnAdd;
        private Button BtnClose;
        private Label label2;
        private Label label1;
        private TextBox TxtSubName;
        private TextBox TxtName;
    }
}