namespace SV.AppForms
{
    partial class FormStudentsAdd
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
            groupBox1 = new GroupBox();
            TxtName = new TextBox();
            label1 = new Label();
            BtnSave = new Button();
            BtnClose = new Button();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(TxtName);
            groupBox1.Controls.Add(label1);
            groupBox1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(442, 114);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Datos";
            // 
            // TxtName
            // 
            TxtName.Location = new Point(108, 53);
            TxtName.Name = "TxtName";
            TxtName.Size = new Size(328, 29);
            TxtName.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(21, 56);
            label1.Name = "label1";
            label1.Size = new Size(68, 21);
            label1.TabIndex = 0;
            label1.Text = "Nombre";
            // 
            // BtnSave
            // 
            BtnSave.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            BtnSave.Location = new Point(261, 155);
            BtnSave.Name = "BtnSave";
            BtnSave.Size = new Size(89, 36);
            BtnSave.TabIndex = 1;
            BtnSave.Text = "Guardar";
            BtnSave.UseVisualStyleBackColor = true;
            BtnSave.Click += BtnSave_Click;
            // 
            // BtnClose
            // 
            BtnClose.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            BtnClose.Location = new Point(359, 155);
            BtnClose.Name = "BtnClose";
            BtnClose.Size = new Size(89, 36);
            BtnClose.TabIndex = 2;
            BtnClose.Text = "Cerrar";
            BtnClose.UseVisualStyleBackColor = true;
            BtnClose.Click += BtnClose_Click;
            // 
            // FormStudentsAdd
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(466, 203);
            Controls.Add(BtnClose);
            Controls.Add(BtnSave);
            Controls.Add(groupBox1);
            Name = "FormStudentsAdd";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Estudiante";
            Load += FormStudentsAdd_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private TextBox TxtName;
        private Label label1;
        private Button BtnSave;
        private Button BtnClose;
    }
}