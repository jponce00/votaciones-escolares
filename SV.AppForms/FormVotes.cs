using SV.Domain.Entities;
using SV.Infrastructure.Persistences.Interfaces;
using SV.Utilities.Components;
using SV.Utilities.Static;

namespace SV.AppForms
{
    public partial class FormVotes : Form
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly LoginInfo _loginInfo;

        private bool correctPass = false;

        private List<Grade>? _grades;
        private List<Student>? _students;

        private int _gradeId = 0;
        private int _studentId = 0;
        private int _candidateId = 0;

        public FormVotes(IUnitOfWork unitOfWork, LoginInfo loginInfo)
        {
            _unitOfWork = unitOfWork;
            _loginInfo = loginInfo;

            InitializeComponent();
        }

        private void LoadGrades()
        {
            try
            {
                _grades = _unitOfWork.Grade
                    .GetEntityQuery(g => g.ShiftId.Equals(_loginInfo.Shift))
                    .OrderBy(g => g.Name)
                    .ToList();

                CmbGrades.Items.Clear();
                foreach (var grade in _grades)
                {
                    CmbGrades.Items.Add(grade.Name);
                }

                CmbGrades.SelectedIndex = 0;
            }
            catch (Exception)
            {
                MessageBoxComponent.ShowError("Ocurrió un error al cargar los grados.");
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
                    MessageBoxComponent.ShowWarning("No hay estudiantes agregados para este grado todavía.");
                }
            }
            catch (Exception)
            {
                MessageBoxComponent.ShowError("Ocurrió un error al cargar los estudiantes.");
            }
        }

        private void DesignCandidatesArea()
        {
            var candidates = _unitOfWork.Candidate
                .GetEntityQuery(c => c.CreatedYear.Equals(DateTime.Now.Year) && c.ShiftId.Equals(_loginInfo.Shift))
                .ToList();

            const int WIDTH_BOX = 300;
            const int HEIGHT_BOX = 330;
            const int MARGIN_BOX = 10;
            int numCandidates = 0;

            FlpVote.Controls.Clear();

            foreach (var candidate in candidates)
            {
                if (candidate.AttachmentData != null)
                {
                    Button button = new()
                    {
                        Tag = candidate.Id,
                        Text = candidate.Team,
                        Size = new Size(WIDTH_BOX, HEIGHT_BOX),
                        Margin = new Padding(MARGIN_BOX),
                        TextAlign = ContentAlignment.TopCenter,
                        ImageAlign = ContentAlignment.MiddleCenter,
                        Padding = new Padding(5)
                    };

                    using MemoryStream ms = new(candidate.AttachmentData);
                    button.Image = Image.FromStream(ms);

                    button.Click += Button_Click!;

                    FlpVote.Controls.Add(button);

                    numCandidates++;
                }
            }

            int paddingX = (int)Math.Ceiling((GbVote.Width - (numCandidates * WIDTH_BOX)) * 0.5 - (numCandidates * MARGIN_BOX));
            int paddingY = (int)Math.Ceiling((FlpVote.Height - HEIGHT_BOX) * 0.5);

            FlpVote.Padding = new Padding(paddingX, paddingY, paddingX, paddingY);
        }

        private void Button_Click(object sender, EventArgs e)
        {
            Button? button = sender as Button;

            foreach (Control control in FlpVote.Controls)
            {
                if (control is Button controlButton)
                {
                    control.Enabled = controlButton.Tag == button!.Tag;
                }
            }

            this.BtnVote.Enabled = true;
            _candidateId = Convert.ToInt32(button!.Tag);
        }

        private async void FormVotes_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!correctPass)
            {
                e.Cancel = true;

                string password = InputBox.Show("Ingrese la contraseña de administrador.", "Salir");

                if (!string.IsNullOrEmpty(password))
                {
                    var isSuccess = await _unitOfWork.User.VerifyPassword(_loginInfo.UserId, Encrypt.GetSha256(password));

                    if (isSuccess)
                    {
                        correctPass = true;
                        this.Close();
                    }
                    else
                    {
                        MessageBoxComponent.ShowWarning("Contraseña incorrecta.");
                    }
                }
            }
            else
            {
                correctPass = false;
            }
        }

        private void CmbGrades_SelectedIndexChanged(object sender, EventArgs e)
        {
            _gradeId = _grades!.FirstOrDefault(g => g.Name == CmbGrades.Text)!.Id;
            this.LoadStudents();
        }

        private void FormVotes_Load(object sender, EventArgs e)
        {
            this.LoadGrades();
            this.DesignCandidatesArea();
        }

        private void BtnChange_Click(object sender, EventArgs e)
        {
            this.BtnVote.Enabled = false;
            _candidateId = 0;

            foreach (Control control in FlpVote.Controls)
            {
                control.Enabled = true;
            }
        }

        private async void BtnVote_Click(object sender, EventArgs e)
        {
            try
            {
                Vote vote = new()
                {
                    StudentId = _studentId,
                    GradeId = _gradeId,
                    ShiftId = _loginInfo.Shift,
                    CandidateId = _candidateId
                };

                var isSuccess = await _unitOfWork.Vote.RegisterAsync(vote);

                if (isSuccess)
                {
                    MessageBoxComponent.ShowInfo(ReplyMessage.MESSAGE_VOTE_SUCCESS);
                }
                else
                {
                    MessageBoxComponent.ShowWarning(ReplyMessage.MESSAGE_VOTE_ERROR);
                }

                this.BtnVote.Enabled = false;
                _candidateId = 0;

                foreach (Control control in FlpVote.Controls)
                {
                    control.Enabled = true;
                }
            }
            catch (Exception)
            {
                MessageBoxComponent.ShowError(ReplyMessage.MESSAGE_EXCEPTION);
            }
        }

        private void CmbStudents_SelectedIndexChanged(object sender, EventArgs e)
        {
            _studentId = _students!.FirstOrDefault(s => s.Name == CmbStudents.Text)!.Id;
        }
    }
}
