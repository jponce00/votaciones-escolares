using SV.Domain.Entities;
using SV.Infrastructure.Persistences.Interfaces;
using SV.Utilities.Components;
using SV.Utilities.Static;

namespace SV.AppForms
{
    public partial class FormStudentsAdd : Form
    {
        private readonly int? _studentId;
        private readonly int _gradeId;
        private readonly IUnitOfWork _unitOfWork;

        public FormStudentsAdd(IUnitOfWork unitOfWork, int gradeId, int? studentId = null)
        {
            _unitOfWork = unitOfWork;
            _studentId = studentId;
            _gradeId = gradeId;

            InitializeComponent();
        }

        private bool ValidateData()
        {
            if (TxtName.Text.Trim().Length == 0)
            {
                MessageBoxComponent.ShowWarning("Debe completar el campo Nombre.");
                TxtName.Focus();

                return false;
            }

            return true;
        }

        private void CleanTexts()
        {
            TxtName.Text = string.Empty;

            TxtName.Focus();
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private async void BtnSave_Click(object sender, EventArgs e)
        {
            if (_studentId == null)
            {
                if (this.ValidateData())
                {
                    try
                    {
                        Student student = new()
                        {
                            Name = TxtName.Text.Trim(),
                            GradeId = _gradeId,
                            CreatedYear = DateTime.Now.Year
                        };

                        var isSuccess = await _unitOfWork.Student.RegisterAsync(student);

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
                        MessageBoxComponent.ShowError("Ocurrió un error al agregar un estudiante.");
                    }
                }
            }
            else
            {
                try
                {
                    var student = await _unitOfWork.Student.GetByIdAsync((int)_studentId!);

                    if (student != null)
                    {
                        if (this.ValidateData())
                        {
                            student.Name = TxtName.Text.Trim();
                            student.Id = (int)_studentId!;

                            var isSuccess = await _unitOfWork.Student.EditAsync(student);

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
                    MessageBoxComponent.ShowError("Ocurrió un error al actualizar el estudiante.");
                }
            }
        }

        private async void FormStudentsAdd_Load(object sender, EventArgs e)
        {
            if (this._studentId != null)
            {
                try
                {
                    var student = await _unitOfWork.Student.GetByIdAsync((int)_studentId!);

                    if (student != null)
                    {
                        TxtName.Text = student.Name;
                    }
                    else
                    {
                        MessageBoxComponent.ShowWarning(ReplyMessage.MESSAGE_DOESNOT_EXIST);
                    }
                }
                catch (Exception)
                {
                    MessageBoxComponent.ShowError("Ocurrió un error al cargar el estudiante.");
                    this.Dispose();
                }
            }
        }
    }
}
