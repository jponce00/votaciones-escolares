namespace SV.AppForms
{
    partial class FormGrades
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
            dgvGrades = new DataGridView();
            BtnOpenAdd = new Button();
            BtnUpdate = new Button();
            BtnDelete = new Button();
            BtnAddStudents = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvGrades).BeginInit();
            SuspendLayout();
            // 
            // dgvGrades
            // 
            dgvGrades.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvGrades.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvGrades.Location = new Point(12, 12);
            dgvGrades.MultiSelect = false;
            dgvGrades.Name = "dgvGrades";
            dgvGrades.ReadOnly = true;
            dgvGrades.RowTemplate.Height = 25;
            dgvGrades.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvGrades.Size = new Size(564, 219);
            dgvGrades.TabIndex = 0;
            // 
            // BtnOpenAdd
            // 
            BtnOpenAdd.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            BtnOpenAdd.Location = new Point(12, 246);
            BtnOpenAdd.Name = "BtnOpenAdd";
            BtnOpenAdd.Size = new Size(101, 37);
            BtnOpenAdd.TabIndex = 1;
            BtnOpenAdd.Text = "Nuevo";
            BtnOpenAdd.UseVisualStyleBackColor = true;
            BtnOpenAdd.Click += BtnOpenAdd_Click;
            // 
            // BtnUpdate
            // 
            BtnUpdate.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            BtnUpdate.Location = new Point(119, 246);
            BtnUpdate.Name = "BtnUpdate";
            BtnUpdate.Size = new Size(101, 37);
            BtnUpdate.TabIndex = 2;
            BtnUpdate.Text = "Actualizar";
            BtnUpdate.UseVisualStyleBackColor = true;
            BtnUpdate.Click += BtnUpdate_Click;
            // 
            // BtnDelete
            // 
            BtnDelete.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            BtnDelete.Location = new Point(226, 246);
            BtnDelete.Name = "BtnDelete";
            BtnDelete.Size = new Size(101, 37);
            BtnDelete.TabIndex = 3;
            BtnDelete.Text = "Eliminar";
            BtnDelete.UseVisualStyleBackColor = true;
            BtnDelete.Click += BtnDelete_Click;
            // 
            // BtnAddStudents
            // 
            BtnAddStudents.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            BtnAddStudents.Location = new Point(420, 246);
            BtnAddStudents.Name = "BtnAddStudents";
            BtnAddStudents.Size = new Size(156, 37);
            BtnAddStudents.TabIndex = 4;
            BtnAddStudents.Text = "Agregar alumnos";
            BtnAddStudents.UseVisualStyleBackColor = true;
            BtnAddStudents.Click += BtnAddStudents_Click;
            // 
            // FormGrades
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(588, 305);
            Controls.Add(BtnAddStudents);
            Controls.Add(BtnDelete);
            Controls.Add(BtnUpdate);
            Controls.Add(BtnOpenAdd);
            Controls.Add(dgvGrades);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "FormGrades";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Grados";
            FormClosing += FormGrades_FormClosing;
            Load += FormGrades_Load;
            ((System.ComponentModel.ISupportInitialize)dgvGrades).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvGrades;
        private Button BtnOpenAdd;
        private Button BtnUpdate;
        private Button BtnDelete;
        private Button BtnAddStudents;
    }
}