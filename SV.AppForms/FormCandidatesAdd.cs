using Microsoft.EntityFrameworkCore;
using SV.Domain.Entities;
using SV.Infrastructure.Persistences.Interfaces;
using SV.Utilities.Components;
using SV.Utilities.Static;

namespace SV.AppForms
{
    public partial class FormCandidatesAdd : Form
    {
        private readonly int? _id;
        private readonly IUnitOfWork _unitOfWork;
        private readonly LoginInfo _loginInfo;

        private List<Grade>? _grades;
        private string? _filePath;

        public FormCandidatesAdd(IUnitOfWork unitOfWork, LoginInfo loginInfo, int? id = null)
        {
            _unitOfWork = unitOfWork;
            _loginInfo = loginInfo;
            _id = id;

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

            if (TxtTeam.Text.Trim().Length == 0)
            {
                MessageBoxComponent.ShowWarning("Debe completar el campo Planilla.");
                TxtTeam.Focus();

                return false;
            }

            if (CmbGrades.Text.Trim().Length == 0)
            {
                MessageBoxComponent.ShowWarning("Debe elegir el Grado del candidato");
                CmbGrades.Focus();

                return false;
            }

            return true;
        }

        private void CleanTexts()
        {
            TxtName.Text = string.Empty;
            TxtTeam.Text = string.Empty;
            LblImage.Text = string.Empty;
            PbImage.Image = null;

            TxtName.Focus();
        }

        private async Task LoadGradesAsync()
        {
            try
            {
                _grades = await _unitOfWork.Grade
                .GetEntityQuery(g => g.ShiftId.Equals(_loginInfo.Shift))
                .OrderBy(g => g.Name)
                .ToListAsync();

                foreach (var grade in _grades)
                {
                    CmbGrades.Items.Add(grade.Name);
                }

                CmbGrades.SelectedIndex = 0;
            }
            catch (Exception)
            {
                MessageBoxComponent.ShowWarning("Debe agregar un Grado para poder agregar un candidato.");
            }
        }

        private async void BtnSave_Click(object sender, EventArgs e)
        {
            if (this._id == null)
            {
                if (this.ValidateData())
                {
                    try
                    {
                        Candidate candidate = new()
                        {
                            Name = TxtName.Text,
                            Team = TxtTeam.Text,
                            GradeId = _grades!.FirstOrDefault(g => g.Name == CmbGrades.Text)!.Id,
                            ShiftId = _loginInfo.Shift
                        };

                        if (_filePath != null)
                        {
                            candidate.AttachmentName = LblImage.Text;
                            candidate.AttachmentData = ConvertionComponent.ConvertImageToBytes(_filePath!);
                        }

                        var isSuccess = await _unitOfWork.Candidate.RegisterAsync(candidate);

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
                        MessageBoxComponent.ShowError("Ocurrió un error al guardar el candidato.");
                    }
                }
            }
            else
            {
                try
                {
                    var candidate = await _unitOfWork.Candidate.GetByIdAsync((int)this._id);

                    if (candidate != null)
                    {
                        if (this.ValidateData())
                        {
                            candidate.Name = TxtName.Text;
                            candidate.Team = TxtTeam.Text;
                            candidate.GradeId = _grades!.FirstOrDefault(g => g.Name == CmbGrades.Text)!.Id;

                            if (_filePath != null)
                            {
                                candidate.AttachmentName = LblImage.Text;
                                candidate.AttachmentData = ConvertionComponent.ConvertImageToBytes(_filePath!);
                            }

                            var isSuccess = await _unitOfWork.Candidate.EditAsync(candidate);

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
                        MessageBoxComponent.ShowError(ReplyMessage.MESSAGE_DOESNOT_EXIST);
                    }
                }
                catch (Exception)
                {
                    MessageBoxComponent.ShowError("Ocurrió un error al actualizar el candidato.");
                }
            }
        }

        private async void FormCandidatesAdd_Load(object sender, EventArgs e)
        {
            await this.LoadGradesAsync();
            PbImage.SizeMode = PictureBoxSizeMode.Zoom;

            if (this._id != null)
            {
                try
                {
                    var candidate = await _unitOfWork.Candidate.GetByIdAsync((int)this._id);

                    if (candidate != null)
                    {
                        TxtName.Text = candidate.Name;
                        TxtTeam.Text = candidate.Team;
                        CmbGrades.Text = _grades!.FirstOrDefault(g => g.Id == candidate.GradeId)!.Name;
                        LblImage.Text = "Sin imagen";

                        if (candidate.AttachmentData != null)
                        {
                            LblImage.Text = candidate.AttachmentName;

                            using MemoryStream ms = new(candidate.AttachmentData);
                            PbImage.Image = Image.FromStream(ms);
                        }
                    }
                    else
                    {
                        MessageBoxComponent.ShowWarning(ReplyMessage.MESSAGE_DOESNOT_EXIST);
                        this.Dispose();
                    }
                }
                catch (Exception)
                {
                    MessageBoxComponent.ShowError("Ocurrió un error al cargar el candidato.");
                    this.Dispose();
                }
            }
            else
            {
                this.CleanTexts();
            }
        }

        private void BtnImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new()
            {
                Filter = "Archivos de Imagen|*.jpg;*.jpeg;*.png;*.gif;*.bmp"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                _filePath = openFileDialog.FileName;

                LblImage.Text = _filePath.Split("\\").Last();

                PbImage.Image = Image.FromFile(_filePath);
            }
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
