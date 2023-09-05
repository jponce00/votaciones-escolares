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
        private List<Student>? _students;

        private int _gradeId = 0;
        private int _studentId = 0;
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
            if (CmbStudents.Text.Trim().Length == 0)
            {
                MessageBoxComponent.ShowWarning("Debe completar el campo Nombre.");
                CmbStudents.Focus();

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
            TxtTeam.Text = string.Empty;
            LblImage.Text = string.Empty;
            PbImage.Image = null;

            TxtTeam.Focus();
        }

        private async Task LoadGradesAsync()
        {
            try
            {
                _grades = await _unitOfWork.Grade
                .GetEntityQuery(g => g.ShiftId.Equals(_loginInfo.Shift))
                .OrderBy(g => g.Name)
                .ToListAsync();

                if (_grades.Any())
                {
                    foreach (var grade in _grades)
                    {
                        CmbGrades.Items.Add(grade.Name);
                    }

                    CmbGrades.SelectedIndex = 0;
                }
                else
                {
                    MessageBoxComponent.ShowWarning("Debe agregar un Grado para poder agregar un candidato.");
                }
            }
            catch (Exception)
            {
                MessageBoxComponent.ShowWarning("Ocurrió un error al cargar los grados.");
            }
        }

        private void LoadStudents()
        {
            try
            {
                _students = _unitOfWork.Student
                    .GetEntityQuery(s => s.GradeId.Equals(_gradeId))
                    .OrderBy(s => s.Name)
                    .ToList();

                CmbStudents.Items.Clear();

                if (_students.Any())
                {
                    foreach (var student in _students)
                    {
                        CmbStudents.Items.Add(student.Name);
                    }

                    CmbStudents.SelectedIndex = 0;
                }
                else
                {
                    MessageBoxComponent.ShowWarning("Debe agregar alumnos al grado para poder agregar el candidato.");
                }
            }
            catch (Exception)
            {
                MessageBoxComponent.ShowError("Ocurrió un error al cargar los estudiantes del grado.");
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
                            Team = TxtTeam.Text,
                            StudentId = _students!.FirstOrDefault(s => s.Name == CmbStudents.Text)!.Id,
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
                    catch (NullReferenceException)
                    {
                        MessageBoxComponent.ShowWarning("El alumno debe ser elegido de entre las opciones.");
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
                            candidate.Team = TxtTeam.Text;
                            candidate.StudentId = _students!.FirstOrDefault(s => s.Name == CmbStudents.Text)!.Id;

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
                catch (NullReferenceException)
                {
                    MessageBoxComponent.ShowWarning("Ocurrió un error al guardar el candidato.");
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
                    var candidate = await _unitOfWork.Candidate.GetCandidateWithGradeAsync((int)this._id);

                    if (candidate != null)
                    {
                        TxtTeam.Text = candidate.Team;
                        CmbGrades.Text = _grades!.FirstOrDefault(g => g.Id == candidate.GradeId)!.Name;
                        CmbStudents.Text = _students!.FirstOrDefault(s => s.Id == candidate.StudentId)!.Name;
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

        private void CmbGrades_SelectedIndexChanged(object sender, EventArgs e)
        {
            _gradeId = _grades!.FirstOrDefault(g => g.Name == CmbGrades.Text)!.Id;
            this.LoadStudents();
        }
    }
}
