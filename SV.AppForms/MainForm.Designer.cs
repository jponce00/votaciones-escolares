namespace SV.AppForms
{
    partial class MainForm
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            btnOpenGrades = new Button();
            label1 = new Label();
            PbUser = new PictureBox();
            toolTipUser = new ToolTip(components);
            ((System.ComponentModel.ISupportInitialize)PbUser).BeginInit();
            SuspendLayout();
            // 
            // btnOpenGrades
            // 
            btnOpenGrades.Location = new Point(73, 143);
            btnOpenGrades.Name = "btnOpenGrades";
            btnOpenGrades.Size = new Size(103, 39);
            btnOpenGrades.TabIndex = 1;
            btnOpenGrades.Text = "Grados";
            btnOpenGrades.UseVisualStyleBackColor = true;
            btnOpenGrades.Click += btnOpenGrades_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 24F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(238, 32);
            label1.Name = "label1";
            label1.Size = new Size(295, 45);
            label1.TabIndex = 2;
            label1.Text = "Sistema Votaciones";
            // 
            // PbUser
            // 
            PbUser.Image = (Image)resources.GetObject("PbUser.Image");
            PbUser.Location = new Point(723, 12);
            PbUser.Name = "PbUser";
            PbUser.Size = new Size(36, 34);
            PbUser.SizeMode = PictureBoxSizeMode.Zoom;
            PbUser.TabIndex = 3;
            PbUser.TabStop = false;
            PbUser.Click += PbUser_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(PbUser);
            Controls.Add(label1);
            Controls.Add(btnOpenGrades);
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "MainForm";
            FormClosing += MainForm_FormClosing;
            Load += MainForm_Load;
            ((System.ComponentModel.ISupportInitialize)PbUser).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button btnOpenGrades;
        private Label label1;
        private PictureBox PbUser;
        private ToolTip toolTipUser;
    }
}