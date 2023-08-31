namespace SV.AppForms
{
    partial class FormVotes
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
            CmbGrades = new ComboBox();
            BtnContinue = new Button();
            label2 = new Label();
            label1 = new Label();
            GbVote = new GroupBox();
            FlpVote = new FlowLayoutPanel();
            BtnVote = new Button();
            BtnChange = new Button();
            groupBox1.SuspendLayout();
            GbVote.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            groupBox1.Controls.Add(CmbStudents);
            groupBox1.Controls.Add(CmbGrades);
            groupBox1.Controls.Add(BtnContinue);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(1432, 268);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Datos del votante";
            // 
            // CmbStudents
            // 
            CmbStudents.DropDownStyle = ComboBoxStyle.DropDownList;
            CmbStudents.FormattingEnabled = true;
            CmbStudents.Location = new Point(138, 116);
            CmbStudents.Name = "CmbStudents";
            CmbStudents.Size = new Size(414, 29);
            CmbStudents.TabIndex = 4;
            CmbStudents.SelectedIndexChanged += CmbStudents_SelectedIndexChanged;
            // 
            // CmbGrades
            // 
            CmbGrades.DropDownStyle = ComboBoxStyle.DropDownList;
            CmbGrades.FormattingEnabled = true;
            CmbGrades.Location = new Point(138, 53);
            CmbGrades.Name = "CmbGrades";
            CmbGrades.Size = new Size(414, 29);
            CmbGrades.TabIndex = 3;
            CmbGrades.SelectedIndexChanged += CmbGrades_SelectedIndexChanged;
            // 
            // BtnContinue
            // 
            BtnContinue.Location = new Point(452, 180);
            BtnContinue.Name = "BtnContinue";
            BtnContinue.Size = new Size(100, 34);
            BtnContinue.TabIndex = 2;
            BtnContinue.Text = "Continuar";
            BtnContinue.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(37, 119);
            label2.Name = "label2";
            label2.Size = new Size(68, 21);
            label2.TabIndex = 1;
            label2.Text = "Alumno:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(37, 56);
            label1.Name = "label1";
            label1.Size = new Size(56, 21);
            label1.TabIndex = 0;
            label1.Text = "Grado:";
            // 
            // GbVote
            // 
            GbVote.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            GbVote.BackColor = Color.Transparent;
            GbVote.Controls.Add(FlpVote);
            GbVote.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            GbVote.Location = new Point(12, 300);
            GbVote.Margin = new Padding(0);
            GbVote.Name = "GbVote";
            GbVote.Size = new Size(1432, 446);
            GbVote.TabIndex = 1;
            GbVote.TabStop = false;
            GbVote.Text = "Voto";
            // 
            // FlpVote
            // 
            FlpVote.BorderStyle = BorderStyle.FixedSingle;
            FlpVote.Dock = DockStyle.Fill;
            FlpVote.FlowDirection = FlowDirection.TopDown;
            FlpVote.Location = new Point(3, 25);
            FlpVote.Name = "FlpVote";
            FlpVote.Size = new Size(1426, 418);
            FlpVote.TabIndex = 0;
            // 
            // BtnVote
            // 
            BtnVote.BackColor = SystemColors.Control;
            BtnVote.Enabled = false;
            BtnVote.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            BtnVote.ForeColor = SystemColors.ControlText;
            BtnVote.Location = new Point(126, 763);
            BtnVote.Name = "BtnVote";
            BtnVote.Size = new Size(83, 34);
            BtnVote.TabIndex = 2;
            BtnVote.Text = "Votar";
            BtnVote.UseVisualStyleBackColor = true;
            BtnVote.Click += BtnVote_Click;
            // 
            // BtnChange
            // 
            BtnChange.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            BtnChange.Location = new Point(15, 763);
            BtnChange.Name = "BtnChange";
            BtnChange.Size = new Size(105, 34);
            BtnChange.TabIndex = 3;
            BtnChange.Text = "Cambiar";
            BtnChange.UseVisualStyleBackColor = true;
            BtnChange.Click += BtnChange_Click;
            // 
            // FormVotes
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1456, 809);
            Controls.Add(BtnChange);
            Controls.Add(BtnVote);
            Controls.Add(GbVote);
            Controls.Add(groupBox1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormVotes";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Votaciones";
            WindowState = FormWindowState.Maximized;
            FormClosing += FormVotes_FormClosing;
            Load += FormVotes_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            GbVote.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private ComboBox CmbStudents;
        private ComboBox CmbGrades;
        private Button BtnContinue;
        private Label label2;
        private Label label1;
        private GroupBox GbVote;
        private Button BtnVote;
        private FlowLayoutPanel FlpVote;
        private Button BtnChange;
    }
}