using SV.Infrastructure.Persistences.Interfaces;
using SV.Utilities.Components;
using SV.Utilities.Static;

namespace SV.AppForms
{
    public partial class FormUsers : Form
    {
        private readonly LoginInfo _loginInfo;
        private readonly IUnitOfWork _unitOfWork;

        public FormUsers(LoginInfo loginInfo, IUnitOfWork unitOfWork)
        {
            _loginInfo = loginInfo;
            _unitOfWork = unitOfWork;

            InitializeComponent();
        }

        private async Task LoadUser()
        {
            try
            {
                var user = await _unitOfWork.User.GetByIdAsync(_loginInfo.UserId);

                if (user != null)
                {
                    TxtName.Text = user.Name;
                    TxtUsername.Text = user.UserName;
                }
                else
                {
                    MessageBoxComponent.ShowError(ReplyMessage.MESSAGE_FAILED);
                }
            }
            catch (Exception)
            {
                MessageBoxComponent.ShowError("Ocurrió un error al cargar los datos del usuario.");
            }
        }

        private void ChangeStateTexts(bool value)
        {
            TxtConfirmPassword.Enabled = value;
            TxtOldPassword.Enabled = value;

            TxtConfirmPassword.Text = string.Empty;
            TxtOldPassword.Text = string.Empty;
        }

        private bool ValidateData()
        {
            if (TxtName.Text.Trim().Length == 0)
            {
                MessageBoxComponent.ShowWarning("Debe completar el campo Nombre.");
                TxtName.Focus();

                return false;
            }

            if (TxtUsername.Text.Trim().Length == 0)
            {
                MessageBoxComponent.ShowWarning("Debe completar el campo Usuario.");
                TxtUsername.Focus();

                return false;
            }

            return true;
        }

        private async Task<bool> ValidatePasswordChanged()
        {
            string newPassword = TxtPassword.Text.Trim();
            string confirmPassword = TxtConfirmPassword.Text.Trim();

            if (newPassword != confirmPassword)
            {
                MessageBoxComponent.ShowWarning("La confirmación de la contraseña no coincide.");
                TxtConfirmPassword.Focus();

                return false;
            }

            string oldPassword = TxtOldPassword.Text.Trim();

            bool verifyPassword = await _unitOfWork.User.VerifyPassword(_loginInfo.UserId, Encrypt.GetSha256(oldPassword));

            if (!verifyPassword)
            {
                MessageBoxComponent.ShowWarning("La contraseña actual es incorrecta.");
                TxtOldPassword.Focus();

                return false;
            }

            return true;
        }

        private async void FormUsers_Load(object sender, EventArgs e)
        {
            await this.LoadUser();

            TxtPassword.Text = string.Empty;
            this.ChangeStateTexts(false);
        }

        private void TxtPassword_KeyUp(object sender, KeyEventArgs e)
        {
            bool value = TxtPassword.Text.Trim().Length > 0;

            this.ChangeStateTexts(value);
        }

        private async void BtnSave_Click(object sender, EventArgs e)
        {
            var user = await _unitOfWork.User.GetByIdAsync(_loginInfo.UserId);

            if (user != null)
            {
                if (this.ValidateData())
                {
                    user.Name = TxtName.Text.Trim();
                    user.UserName = TxtUsername.Text.Trim();

                    if ((TxtPassword.Text.Trim().Length > 0 && (await this.ValidatePasswordChanged())) || TxtPassword.Text.Trim().Length == 0)
                    {
                        if (TxtPassword.Text.Trim().Length > 0)
                        {
                            user.Password = Encrypt.GetSha256(TxtPassword.Text.Trim());
                        }

                        var isSuccess = await _unitOfWork.User.EditAsync(user);

                        if (isSuccess)
                        {
                            MessageBoxComponent.ShowInfo(ReplyMessage.MESSAGE_UPDATE);
                        }
                        else
                        {
                            MessageBoxComponent.ShowWarning(ReplyMessage.MESSAGE_FAILED);
                        }

                        this.Close();
                    }
                }
            }
            else
            {
                MessageBoxComponent.ShowError(ReplyMessage.MESSAGE_DOESNOT_EXIST);
                this.Close();
            }
        }
    }
}
