namespace SV.AppForms
{
    partial class FormCandidates
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
            DgvCandidates = new DataGridView();
            BtnAdd = new Button();
            BtnUpdate = new Button();
            BtnDelete = new Button();
            BtnClose = new Button();
            ((System.ComponentModel.ISupportInitialize)DgvCandidates).BeginInit();
            SuspendLayout();
            // 
            // DgvCandidates
            // 
            DgvCandidates.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DgvCandidates.Location = new Point(12, 72);
            DgvCandidates.Name = "DgvCandidates";
            DgvCandidates.RowTemplate.Height = 25;
            DgvCandidates.Size = new Size(682, 308);
            DgvCandidates.TabIndex = 0;
            // 
            // BtnAdd
            // 
            BtnAdd.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            BtnAdd.Location = new Point(12, 34);
            BtnAdd.Name = "BtnAdd";
            BtnAdd.Size = new Size(86, 32);
            BtnAdd.TabIndex = 1;
            BtnAdd.Text = "Agregar";
            BtnAdd.UseVisualStyleBackColor = true;
            BtnAdd.Click += BtnAdd_Click;
            // 
            // BtnUpdate
            // 
            BtnUpdate.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            BtnUpdate.Location = new Point(104, 34);
            BtnUpdate.Name = "BtnUpdate";
            BtnUpdate.Size = new Size(109, 32);
            BtnUpdate.TabIndex = 2;
            BtnUpdate.Text = "Actualizar";
            BtnUpdate.UseVisualStyleBackColor = true;
            BtnUpdate.Click += BtnUpdate_Click;
            // 
            // BtnDelete
            // 
            BtnDelete.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            BtnDelete.Location = new Point(219, 34);
            BtnDelete.Name = "BtnDelete";
            BtnDelete.Size = new Size(87, 32);
            BtnDelete.TabIndex = 3;
            BtnDelete.Text = "Eliminar";
            BtnDelete.UseVisualStyleBackColor = true;
            BtnDelete.Click += BtnDelete_Click;
            // 
            // BtnClose
            // 
            BtnClose.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            BtnClose.Location = new Point(619, 34);
            BtnClose.Name = "BtnClose";
            BtnClose.Size = new Size(75, 32);
            BtnClose.TabIndex = 4;
            BtnClose.Text = "Cerrar";
            BtnClose.UseVisualStyleBackColor = true;
            BtnClose.Click += BtnClose_Click;
            // 
            // FormCandidates
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(706, 392);
            Controls.Add(BtnClose);
            Controls.Add(BtnDelete);
            Controls.Add(BtnUpdate);
            Controls.Add(BtnAdd);
            Controls.Add(DgvCandidates);
            MaximizeBox = false;
            Name = "FormCandidates";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Candidatos";
            Load += FormCandidates_Load;
            ((System.ComponentModel.ISupportInitialize)DgvCandidates).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView DgvCandidates;
        private Button BtnAdd;
        private Button BtnUpdate;
        private Button BtnDelete;
        private Button BtnClose;
    }
}