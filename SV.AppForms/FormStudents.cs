using SV.Domain.Entities;
using SV.Infrastructure.FileExcel;
using SV.Infrastructure.Persistences.Interfaces;
using SV.Utilities.Components;
using SV.Utilities.Static;

namespace SV.AppForms
{
    public partial class FormStudents : Form
    {
        private readonly int _gradeId;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IReadExcel _readExcel;

        public FormStudents(IUnitOfWork unitOfWork, IReadExcel readExcel, int gradeId)
        {
            _unitOfWork = unitOfWork;
            _readExcel = readExcel;
            _gradeId = gradeId;

            InitializeComponent();
        }

        private async Task LoadStudentsAsync()
        {
            var students = (await _unitOfWork.Student
                .GetAllAsync())
                .Where(s => s.GradeId.Equals(_gradeId))
                .Select((s, i) => new
                {
                    s.Id,
                    Num = i + 1,
                    s.Name
                })
                .ToList();

            this.DgvStudents.DataSource = students;
            this.DgvStudents.Columns.Clear();

            this.DgvStudents.Columns.Add("Id", "Id");
            this.DgvStudents.Columns.Add("Num", "No.");
            this.DgvStudents.Columns.Add("Name", "Nombre");

            this.DgvStudents.Columns["Id"].DataPropertyName = "Id";
            this.DgvStudents.Columns["Num"].DataPropertyName = "Num";
            this.DgvStudents.Columns["Name"].DataPropertyName = "Name";
        }

        private void DesignGrid()
        {
            this.DgvStudents.Columns["Id"].Visible = false;
            this.DgvStudents.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            this.DgvStudents.Columns["Num"].Width = (int)(this.DgvStudents.Width * 0.1);
            this.DgvStudents.Columns["Num"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            this.DgvStudents.Columns["Name"].Width = (int)(this.DgvStudents.Width * 0.9);
            this.DgvStudents.Columns["Name"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            this.DgvStudents.AllowUserToResizeRows = false;
            this.DgvStudents.AllowUserToResizeColumns = false;
            this.DgvStudents.AllowUserToAddRows = false;
            this.DgvStudents.AllowUserToDeleteRows = false;
            this.DgvStudents.RowHeadersVisible = false;
            this.DgvStudents.MultiSelect = false;
            this.DgvStudents.ReadOnly = true;
            this.DgvStudents.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private async void BtnAdd_Click(object sender, EventArgs e)
        {
            FormStudentsAdd formStudentsAdd = new(_unitOfWork, _gradeId);

            formStudentsAdd.ShowDialog();

            if (formStudentsAdd.IsDisposed)
            {
                await this.LoadStudentsAsync();
                this.DesignGrid();
            }
        }

        private async void FormStudents_Load(object sender, EventArgs e)
        {
            await this.LoadStudentsAsync();
            this.DesignGrid();

            try
            {
                var grade = await _unitOfWork.Grade.GetByIdAsync(_gradeId);

                LblGrade.Text = $"{grade.Name} {grade.Section}";
            }
            catch (Exception)
            {
                MessageBoxComponent.ShowError("Ocurrió un error al cargar el Grado.");
                this.Dispose();
            }
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private async void BtnImportExcel_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new()
            {
                Filter = "Archivos Excel|*.xlsx"
            };

            try
            {
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = openFileDialog.FileName;
                    IEnumerable<Student> students = _readExcel.ReadFromExcel(filePath, _gradeId);

                    var isSuccess = await _unitOfWork.Student.RegisterManyAsync(students);

                    if (isSuccess)
                    {
                        MessageBoxComponent.ShowInfo(ReplyMessage.MESSAGE_SAVE_MANY);
                        await this.LoadStudentsAsync();
                        this.DesignGrid();
                    }
                    else
                    {
                        MessageBoxComponent.ShowError(ReplyMessage.MESSAGE_FAILED);
                    }
                }
            }
            catch (Exception)
            {
                MessageBoxComponent.ShowError("Ocurrió un error al agregar los estudiantes.");
            }
        }

        private async void BtnDeleteAll_Click(object sender, EventArgs e)
        {
            DialogResult resp;

            resp = MessageBoxComponent.ShowQuestion("¿Desea eliminar los estudiantes del grado?", "Eliminar lista");

            if (resp == DialogResult.Yes)
            {
                try
                {
                    var isSuccess = await _unitOfWork.Student.RemoveManyAsync(_gradeId);

                    if (isSuccess)
                    {
                        MessageBoxComponent.ShowInfo(ReplyMessage.MESSAGE_DELETE_MANY);
                        await this.LoadStudentsAsync();
                        this.DesignGrid();
                    }
                    else
                    {
                        MessageBoxComponent.ShowError(ReplyMessage.MESSAGE_FAILED);
                    }
                }
                catch (Exception)
                {
                    MessageBoxComponent.ShowError("Ocurrió un error al eliminar los estudiantes.");
                }
            }
        }

        private async void BtnUpdate_Click(object sender, EventArgs e)
        {
            if (DgvStudents.RowCount == 0)
            {
                return;
            }

            try
            {
                var studentId = (int)this.DgvStudents.CurrentRow.Cells[0].Value;

                FormStudentsAdd formStudentsAdd = new(_unitOfWork, _gradeId, studentId);

                formStudentsAdd.ShowDialog();

                if (formStudentsAdd.IsDisposed)
                {
                    await this.LoadStudentsAsync();
                    this.DesignGrid();
                }
            }
            catch (Exception)
            {
            }
        }

        private async void BtnDelete_Click(object sender, EventArgs e)
        {
            if (DgvStudents.RowCount == 0)
            {
                return;
            }

            int studentId = (int)DgvStudents.CurrentRow.Cells[0].Value;
            DialogResult resp;

            resp = MessageBoxComponent.ShowQuestion("¿Desea eliminar el elemento seleccionado?", "Eliminar");

            if (resp == DialogResult.Yes)
            {
                try
                {
                    var isSuccess = await _unitOfWork.Student.RemoveAsync(studentId);

                    if (isSuccess)
                    {
                        MessageBoxComponent.ShowInfo(ReplyMessage.MESSAGE_DELETE);
                        await this.LoadStudentsAsync();
                        this.DesignGrid();
                    }
                    else
                    {
                        MessageBoxComponent.ShowError(ReplyMessage.MESSAGE_FAILED);
                    }
                }
                catch (Exception)
                {
                    MessageBoxComponent.ShowError("Ocurrió un error al eliminar el estudiante.");
                }
            }
        }
    }
}
