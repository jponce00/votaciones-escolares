namespace SV.AppForms
{
    partial class FormResults
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
            GbCandidates = new GroupBox();
            FlpCandidates = new FlowLayoutPanel();
            BtnClose = new Button();
            GbCandidates.SuspendLayout();
            SuspendLayout();
            // 
            // GbCandidates
            // 
            GbCandidates.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            GbCandidates.Controls.Add(FlpCandidates);
            GbCandidates.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            GbCandidates.Location = new Point(12, 12);
            GbCandidates.Name = "GbCandidates";
            GbCandidates.Size = new Size(1429, 591);
            GbCandidates.TabIndex = 0;
            GbCandidates.TabStop = false;
            GbCandidates.Text = "Candidatos";
            // 
            // FlpCandidates
            // 
            FlpCandidates.Dock = DockStyle.Fill;
            FlpCandidates.FlowDirection = FlowDirection.TopDown;
            FlpCandidates.Location = new Point(3, 31);
            FlpCandidates.Name = "FlpCandidates";
            FlpCandidates.Size = new Size(1423, 557);
            FlpCandidates.TabIndex = 0;
            // 
            // BtnClose
            // 
            BtnClose.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            BtnClose.Location = new Point(12, 609);
            BtnClose.Name = "BtnClose";
            BtnClose.Size = new Size(127, 46);
            BtnClose.TabIndex = 1;
            BtnClose.Text = "Cerrar";
            BtnClose.UseVisualStyleBackColor = true;
            BtnClose.Click += BtnClose_Click;
            // 
            // FormResults
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1453, 794);
            Controls.Add(BtnClose);
            Controls.Add(GbCandidates);
            Name = "FormResults";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Resultados";
            Load += FormResults_Load;
            GbCandidates.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private GroupBox GbCandidates;
        private FlowLayoutPanel FlpCandidates;
        private Button BtnClose;
    }
}