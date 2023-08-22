namespace SV.AppForms
{
    partial class FormStudents
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
            DgvStudents = new DataGridView();
            BtnAdd = new Button();
            BtnDelete = new Button();
            LblGrade = new Label();
            BtnClose = new Button();
            BtnImportExcel = new Button();
            BtnDeleteAll = new Button();
            BtnUpdate = new Button();
            ((System.ComponentModel.ISupportInitialize)DgvStudents).BeginInit();
            SuspendLayout();
            // 
            // DgvStudents
            // 
            DgvStudents.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DgvStudents.Location = new Point(12, 142);
            DgvStudents.Name = "DgvStudents";
            DgvStudents.RowTemplate.Height = 25;
            DgvStudents.Size = new Size(735, 333);
            DgvStudents.TabIndex = 0;
            // 
            // BtnAdd
            // 
            BtnAdd.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            BtnAdd.Location = new Point(12, 91);
            BtnAdd.Name = "BtnAdd";
            BtnAdd.Size = new Size(90, 36);
            BtnAdd.TabIndex = 1;
            BtnAdd.Text = "Agregar";
            BtnAdd.UseVisualStyleBackColor = true;
            BtnAdd.Click += BtnAdd_Click;
            // 
            // BtnDelete
            // 
            BtnDelete.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            BtnDelete.Location = new Point(211, 91);
            BtnDelete.Name = "BtnDelete";
            BtnDelete.Size = new Size(84, 36);
            BtnDelete.TabIndex = 2;
            BtnDelete.Text = "Eliminar";
            BtnDelete.UseVisualStyleBackColor = true;
            BtnDelete.Click += BtnDelete_Click;
            // 
            // LblGrade
            // 
            LblGrade.AutoSize = true;
            LblGrade.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            LblGrade.Location = new Point(339, 27);
            LblGrade.Name = "LblGrade";
            LblGrade.Size = new Size(64, 25);
            LblGrade.TabIndex = 3;
            LblGrade.Text = "Grado";
            // 
            // BtnClose
            // 
            BtnClose.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            BtnClose.Location = new Point(301, 91);
            BtnClose.Name = "BtnClose";
            BtnClose.Size = new Size(92, 36);
            BtnClose.TabIndex = 4;
            BtnClose.Text = "Cerrar";
            BtnClose.UseVisualStyleBackColor = true;
            BtnClose.Click += BtnClose_Click;
            // 
            // BtnImportExcel
            // 
            BtnImportExcel.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            BtnImportExcel.Location = new Point(624, 91);
            BtnImportExcel.Name = "BtnImportExcel";
            BtnImportExcel.Size = new Size(123, 36);
            BtnImportExcel.TabIndex = 5;
            BtnImportExcel.Text = "Importar excel";
            BtnImportExcel.UseVisualStyleBackColor = true;
            BtnImportExcel.Click += BtnImportExcel_Click;
            // 
            // BtnDeleteAll
            // 
            BtnDeleteAll.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            BtnDeleteAll.Location = new Point(494, 91);
            BtnDeleteAll.Name = "BtnDeleteAll";
            BtnDeleteAll.Size = new Size(124, 36);
            BtnDeleteAll.TabIndex = 6;
            BtnDeleteAll.Text = "Quitar todos";
            BtnDeleteAll.UseVisualStyleBackColor = true;
            BtnDeleteAll.Click += BtnDeleteAll_Click;
            // 
            // BtnUpdate
            // 
            BtnUpdate.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            BtnUpdate.Location = new Point(108, 91);
            BtnUpdate.Name = "BtnUpdate";
            BtnUpdate.Size = new Size(97, 36);
            BtnUpdate.TabIndex = 7;
            BtnUpdate.Text = "Actualizar";
            BtnUpdate.UseVisualStyleBackColor = true;
            BtnUpdate.Click += BtnUpdate_Click;
            // 
            // FormStudents
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(759, 487);
            Controls.Add(BtnUpdate);
            Controls.Add(BtnDeleteAll);
            Controls.Add(BtnImportExcel);
            Controls.Add(BtnClose);
            Controls.Add(LblGrade);
            Controls.Add(BtnDelete);
            Controls.Add(BtnAdd);
            Controls.Add(DgvStudents);
            MaximizeBox = false;
            Name = "FormStudents";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Estudiantes";
            Load += FormStudents_Load;
            ((System.ComponentModel.ISupportInitialize)DgvStudents).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView DgvStudents;
        private Button BtnAdd;
        private Button BtnDelete;
        private Label LblGrade;
        private Button BtnClose;
        private Button BtnImportExcel;
        private Button BtnDeleteAll;
        private Button BtnUpdate;
    }
}