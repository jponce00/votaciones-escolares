using SV.Infrastructure.Persistences.Interfaces;
using SV.Utilities.Components;
using SV.Utilities.Dtos.User;

namespace SV.AppForms
{
    public partial class FormLogin : Form
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly FormGrades _formGrades;

        private readonly LoginInfo _loginInfo;

        public FormLogin(IUnitOfWork unitOfWork, FormGrades formGrades, LoginInfo loginInfo)
        {
            _unitOfWork = unitOfWork;
            _formGrades = formGrades;

            _loginInfo = loginInfo;

            InitializeComponent();
        }

        private async Task LoadShiftsAsync()
        {
            var shifts = (await this._unitOfWork.Shift.GetAllAsync())
                .OrderBy(s => s.Id);

            foreach (var shift in shifts)
            {
                CmbShift.Items.Add(shift.Id + ". " + shift.Name);
            }

            CmbShift.SelectedIndex = 0;
        }

        private void CleanTexts()
        {
            TxtUsername.Text = string.Empty;
            TxtPassword.Text = string.Empty;

            TxtUsername.Focus();
        }

        private async void BtnLogin_Click(object sender, EventArgs e)
        {
            UserDto userDto = new()
            {
                UserName = TxtUsername.Text.ToLower(),
                Password = Encrypt.GetSha256(TxtPassword.Text)
            };

            var isSuccess = await _unitOfWork.User.LoginSucceeded(userDto);

            if (isSuccess)
            {
                int shift = Convert.ToInt32(CmbShift.Text.Split(".")[0]);

                _loginInfo.Shift = shift;
                _loginInfo.IsLogued = true;

                this.CleanTexts();

                MainForm mainForm = new(this, _formGrades);
                mainForm.Show();
                this.Hide();
            }
        }

        private async void FormLogin_Load(object sender, EventArgs e)
        {
            await LoadShiftsAsync();
        }
    }
}
