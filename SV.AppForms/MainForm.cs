﻿namespace SV.AppForms
{
    public partial class MainForm : Form
    {
        private readonly FormLogin _formLogin;
        private readonly FormGrades _formGrades;
        private readonly FormUsers _formUsers;
        private readonly FormCandidates _formCandidates;

        public MainForm(FormLogin formLogin, FormGrades formGrades, FormUsers formUsers, FormCandidates formCandidates)
        {
            _formLogin = formLogin;
            _formGrades = formGrades;
            _formUsers = formUsers;
            _formCandidates = formCandidates;

            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            this.toolTipUser.SetToolTip(PbUser, "Configurar usuario");
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            _formLogin.Show();
        }

        private void btnOpenGrades_Click(object sender, EventArgs e)
        {
            _formGrades.ShowDialog();
        }

        private void PbUser_Click(object sender, EventArgs e)
        {
            _formUsers.ShowDialog();
        }

        private void BtnCandidates_Click(object sender, EventArgs e)
        {
            _formCandidates.ShowDialog();
        }
    }
}
