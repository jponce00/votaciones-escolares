using SV.Domain.Entities;
using SV.Infrastructure.FileExcel;
using SV.Infrastructure.Persistences.Interfaces;
using SV.Utilities.Components;
using SV.Utilities.Static;

namespace SV.AppForms
{
    public partial class FormGrades : Form
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IReadExcel _readExcel;
        private readonly LoginInfo _loginInfo;

        public FormGrades(IUnitOfWork unitOfWork, IReadExcel readExcel, LoginInfo loginInfo)
        {
            _unitOfWork = unitOfWork;
            _readExcel = readExcel;
            _loginInfo = loginInfo;

            InitializeComponent();
        }

        private async void FormGrades_Load(object sender, EventArgs e)
        {
            await this.LoadGradesAsync();
            this.DesignGrid();
        }

        private void FormGrades_FormClosing(object sender, FormClosingEventArgs e)
        {
        }

        private async Task LoadGradesAsync()
        {
            var grades = (await _unitOfWork.Grade.GetAllAsync())
                .Where(g => g.ShiftId.Equals(_loginInfo.Shift))
                .GroupJoin(await _unitOfWork.Student.GetAllAsync(), g => g.Id, s => s.GradeId, (g, s) => new
                {
                    g.Id,
                    g.Name,
                    g.Section,
                    Value = s.Any(st => st.CreatedYear == DateTime.Now.Year)
                })
                .OrderBy(g => g.Name)
                .ThenBy(g => g.Section)
                .ToList();

            this.dgvGrades.DataSource = grades;

            this.dgvGrades.Columns.Clear();

            this.dgvGrades.Columns.Add("Id", "Id");
            this.dgvGrades.Columns.Add("Name", "Grado");
            this.dgvGrades.Columns.Add("Section", "Sección");

            this.dgvGrades.Columns["Id"].DataPropertyName = "Id";
            this.dgvGrades.Columns["Name"].DataPropertyName = "Name";
            this.dgvGrades.Columns["Section"].DataPropertyName = "Section";

            this.dgvGrades.Columns.Add(new DataGridViewCheckBoxColumn
            {
                Name = "Updated",
                HeaderText = "Actualizado",
                DataPropertyName = "Value",
                ReadOnly = true
            });
        }

        private void DesignGrid()
        {
            this.dgvGrades.Columns["Id"].Visible = false;

            this.dgvGrades.AllowUserToResizeRows = false;
            this.dgvGrades.AllowUserToResizeColumns = false;
            this.dgvGrades.AllowUserToAddRows = false;
            this.dgvGrades.AllowUserToDeleteRows = false;
            this.dgvGrades.RowHeadersVisible = false;
        }

        private async void BtnOpenAdd_Click(object sender, EventArgs e)
        {
            FormGradesAdd formGradesAdd = new(_unitOfWork, _loginInfo.Shift);

            formGradesAdd.ShowDialog();

            if (formGradesAdd.IsDisposed)
            {
                await this.LoadGradesAsync();
                this.DesignGrid();
            }
        }

        private async void BtnUpdate_Click(object sender, EventArgs e)
        {
            if (dgvGrades.RowCount == 0)
            {
                return;
            }

            try
            {
                var id = (int)this.dgvGrades.CurrentRow.Cells[0].Value;

                FormGradesAdd formGradesAdd = new(_unitOfWork, _loginInfo.Shift, id);

                formGradesAdd.ShowDialog();

                if (formGradesAdd.IsDisposed)
                {
                    await this.LoadGradesAsync();
                    this.DesignGrid();
                }
            }
            catch (Exception)
            {
            }
        }

        private async void BtnDelete_Click(object sender, EventArgs e)
        {
            if (dgvGrades.RowCount == 0)
            {
                return;
            }

            var id = (int)this.dgvGrades.CurrentRow.Cells[0].Value;
            DialogResult resp;

            resp = MessageBoxComponent.ShowQuestion("¿Desea eliminar el elemento seleccionado?", "Eliminar");

            if (resp == DialogResult.Yes)
            {
                try
                {
                    var isSuccess = await _unitOfWork.Grade.RemoveAsync(id);

                    if (isSuccess)
                    {
                        MessageBoxComponent.ShowInfo(ReplyMessage.MESSAGE_DELETE);

                        await this.LoadGradesAsync();
                        this.DesignGrid();
                    }
                    else
                    {
                        MessageBoxComponent.ShowError(ReplyMessage.MESSAGE_FAILED);
                    }
                }
                catch (Exception)
                {
                    MessageBoxComponent.ShowError("Ocurrió un error al eliminar el Grado.");
                }
            }
        }

        private async void BtnAddStudents_Click(object sender, EventArgs e)
        {
            if (dgvGrades.RowCount == 0)
            {
                return;
            }

            try
            {
                int gradeId = (int)this.dgvGrades.CurrentRow.Cells[0].Value;

                FormStudents formStudents = new(_unitOfWork, _readExcel, gradeId);

                formStudents.ShowDialog();

                if (formStudents.IsDisposed)
                {
                    await this.LoadGradesAsync();
                    this.DesignGrid();
                }
            }
            catch (Exception)
            {
            }
        }
    }
}
