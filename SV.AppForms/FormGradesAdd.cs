using SV.Domain.Entities;
using SV.Infrastructure.Persistences.Interfaces;
using SV.Utilities.Components;
using SV.Utilities.Static;

namespace SV.AppForms
{
    public partial class FormGradesAdd : Form
    {
        private readonly int? _id;
        private readonly int _shiftId;

        private readonly IUnitOfWork _unitOfWork;

        public FormGradesAdd(IUnitOfWork unitOfWork, int shiftId, int? id = null)
        {
            _id = id;
            _unitOfWork = unitOfWork;
            _shiftId = shiftId;

            InitializeComponent();
        }

        private void CleanTexts()
        {
            this.TxtName.Text = string.Empty;
            this.TxtSubName.Text = string.Empty;

            this.TxtName.Focus();
        }

        private bool ValidateData()
        {
            if (this.TxtName.Text.Trim().Length == 0)
            {
                MessageBoxComponent.ShowWarning("Debe completar el campo Nombre.");
                this.TxtName.Focus();

                return false;
            }

            if (this.TxtSubName.Text.Trim().Length == 0)
            {
                MessageBoxComponent.ShowWarning("Debe completar el campo Sección.");
                this.TxtSubName.Focus();

                return false;
            }

            return true;
        }

        private async void BtnAdd_Click(object sender, EventArgs e)
        {
            if (this._id == null)
            {
                if (this.ValidateData())
                {
                    try
                    {
                        Grade grade = new()
                        {
                            Name = TxtName.Text,
                            Section = TxtSubName.Text,
                            ShiftId = _shiftId
                        };

                        var isSuccess = await this._unitOfWork.Grade.RegisterAsync(grade);

                        if (isSuccess)
                        {
                            MessageBoxComponent.ShowInfo(ReplyMessage.MESSAGE_SAVE);
                            this.CleanTexts();
                        }
                        else
                        {
                            MessageBoxComponent.ShowError(ReplyMessage.MESSAGE_FAILED);
                        }
                    }
                    catch (Exception)
                    {
                        MessageBoxComponent.ShowError("Ocurrió un error al actualizar el Grado.");
                    }
                }
            }
            else
            {
                try
                {
                    var grade = await this._unitOfWork.Grade.GetByIdAsync((int)this._id);

                    if (grade != null)
                    {
                        if (this.ValidateData())
                        {
                            grade.Name = TxtName.Text;
                            grade.Section = TxtSubName.Text;
                            grade.Id = (int)this._id;

                            var isSuccess = await this._unitOfWork.Grade.EditAsync(grade);

                            if (isSuccess)
                            {
                                MessageBoxComponent.ShowInfo(ReplyMessage.MESSAGE_UPDATE);
                                this.Dispose();
                            }
                            else
                            {
                                MessageBoxComponent.ShowError(ReplyMessage.MESSAGE_FAILED);
                            }
                        }
                    }
                    else
                    {
                        MessageBoxComponent.ShowWarning(ReplyMessage.MESSAGE_DOESNOT_EXIST);
                    }
                }
                catch (Exception)
                {
                    MessageBoxComponent.ShowError("Ocurrió un error al actualizar el Grado.");
                }
            }
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private async void FormGradesAdd_Load(object sender, EventArgs e)
        {
            if (this._id != null)
            {
                try
                {
                    var grade = await this._unitOfWork.Grade.GetByIdAsync((int)this._id);

                    if (grade != null)
                    {
                        TxtName.Text = grade!.Name;
                        TxtSubName.Text = grade!.Section;
                    }
                    else
                    {
                        MessageBoxComponent.ShowWarning(ReplyMessage.MESSAGE_DOESNOT_EXIST);
                    }
                }
                catch (Exception)
                {
                    MessageBoxComponent.ShowError("Ocurrió un error al cargar el Grado.");
                    this.Dispose();
                }
            }
        }
    }
}
