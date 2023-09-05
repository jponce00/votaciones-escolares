namespace SV.AppForms
{
    partial class FormCandidatesAdd
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
            CmbStudents = new ComboBox();
            label1 = new Label();
            CmbGrades = new ComboBox();
            TxtTeam = new TextBox();
            label3 = new Label();
            label2 = new Label();
            groupBox2 = new GroupBox();
            LblImage = new Label();
            BtnImage = new Button();
            PbImage = new PictureBox();
            BtnSave = new Button();
            BtnClose = new Button();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)PbImage).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(CmbStudents);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(CmbGrades);
            groupBox1.Controls.Add(TxtTeam);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(510, 215);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Datos generales";
            // 
            // CmbStudents
            // 
            CmbStudents.AutoCompleteMode = AutoCompleteMode.Append;
            CmbStudents.AutoCompleteSource = AutoCompleteSource.ListItems;
            CmbStudents.FormattingEnabled = true;
            CmbStudents.Location = new Point(107, 160);
            CmbStudents.Name = "CmbStudents";
            CmbStudents.Size = new Size(339, 29);
            CmbStudents.TabIndex = 7;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(6, 163);
            label1.Name = "label1";
            label1.Size = new Size(68, 21);
            label1.TabIndex = 6;
            label1.Text = "Alumno:";
            // 
            // CmbGrades
            // 
            CmbGrades.DropDownStyle = ComboBoxStyle.DropDownList;
            CmbGrades.FormattingEnabled = true;
            CmbGrades.Location = new Point(107, 102);
            CmbGrades.Name = "CmbGrades";
            CmbGrades.Size = new Size(177, 29);
            CmbGrades.TabIndex = 5;
            CmbGrades.SelectedIndexChanged += CmbGrades_SelectedIndexChanged;
            // 
            // TxtTeam
            // 
            TxtTeam.Location = new Point(107, 43);
            TxtTeam.Name = "TxtTeam";
            TxtTeam.Size = new Size(271, 29);
            TxtTeam.TabIndex = 4;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(6, 105);
            label3.Name = "label3";
            label3.Size = new Size(56, 21);
            label3.TabIndex = 2;
            label3.Text = "Grado:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(6, 46);
            label2.Name = "label2";
            label2.Size = new Size(63, 21);
            label2.TabIndex = 1;
            label2.Text = "Planilla:";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(LblImage);
            groupBox2.Controls.Add(BtnImage);
            groupBox2.Controls.Add(PbImage);
            groupBox2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            groupBox2.Location = new Point(544, 12);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(283, 300);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "Imagen";
            // 
            // LblImage
            // 
            LblImage.Location = new Point(72, 201);
            LblImage.Name = "LblImage";
            LblImage.Size = new Size(154, 21);
            LblImage.TabIndex = 3;
            LblImage.Text = "Img. 300x330 px";
            LblImage.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // BtnImage
            // 
            BtnImage.Location = new Point(72, 251);
            BtnImage.Name = "BtnImage";
            BtnImage.Size = new Size(154, 35);
            BtnImage.TabIndex = 2;
            BtnImage.Text = "Seleccionar imagen";
            BtnImage.UseVisualStyleBackColor = true;
            BtnImage.Click += BtnImage_Click;
            // 
            // PbImage
            // 
            PbImage.Location = new Point(72, 46);
            PbImage.Name = "PbImage";
            PbImage.Size = new Size(154, 143);
            PbImage.TabIndex = 1;
            PbImage.TabStop = false;
            // 
            // BtnSave
            // 
            BtnSave.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            BtnSave.Location = new Point(338, 244);
            BtnSave.Name = "BtnSave";
            BtnSave.Size = new Size(91, 36);
            BtnSave.TabIndex = 2;
            BtnSave.Text = "Guardar";
            BtnSave.UseVisualStyleBackColor = true;
            BtnSave.Click += BtnSave_Click;
            // 
            // BtnClose
            // 
            BtnClose.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            BtnClose.Location = new Point(435, 244);
            BtnClose.Name = "BtnClose";
            BtnClose.Size = new Size(87, 36);
            BtnClose.TabIndex = 3;
            BtnClose.Text = "Cerrar";
            BtnClose.UseVisualStyleBackColor = true;
            BtnClose.Click += BtnClose_Click;
            // 
            // FormCandidatesAdd
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(839, 324);
            Controls.Add(BtnClose);
            Controls.Add(BtnSave);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            MaximizeBox = false;
            Name = "FormCandidatesAdd";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Candidatos";
            Load += FormCandidatesAdd_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)PbImage).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private Label label2;
        private GroupBox groupBox2;
        private Label label3;
        private ComboBox CmbGrades;
        private TextBox TxtTeam;
        private Button BtnImage;
        private PictureBox PbImage;
        private Button BtnSave;
        private Button BtnClose;
        private Label LblImage;
        private ComboBox CmbStudents;
        private Label label1;
    }
}