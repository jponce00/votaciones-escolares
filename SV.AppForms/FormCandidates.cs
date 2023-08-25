using Microsoft.EntityFrameworkCore;
using SV.Infrastructure.Persistences.Interfaces;
using SV.Utilities.Components;
using SV.Utilities.Static;

namespace SV.AppForms
{
    public partial class FormCandidates : Form
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly LoginInfo _loginInfo;

        public FormCandidates(IUnitOfWork unitOfWork, LoginInfo loginInfo)
        {
            _unitOfWork = unitOfWork;
            _loginInfo = loginInfo;

            InitializeComponent();
        }

        private async Task LoadCandidatesAsync()
        {
            var candidates = await _unitOfWork.Candidate.GetEntityQuery(c => c.ShiftId.Equals(_loginInfo.Shift))
                .Join(_unitOfWork.Grade.GetEntityQuery(), c => c.GradeId, g => g.Id, (c, g) => new
                {
                    c.Id,
                    c.Name,
                    c.Team,
                    Grade = g.Name,
                    HasImage = c.AttachmentName != null,
                    IsUpdated = c.CreatedYear == DateTime.Now.Year
                })
                .ToListAsync();

            this.DgvCandidates.DataSource = candidates;

            this.DgvCandidates.Columns.Clear();

            this.DgvCandidates.Columns.Add("Id", "Id");
            this.DgvCandidates.Columns.Add("Team", "Planilla");
            this.DgvCandidates.Columns.Add("Name", "Candidato");
            this.DgvCandidates.Columns.Add("Grade", "Grado");

            this.DgvCandidates.Columns["Id"].DataPropertyName = "Id";
            this.DgvCandidates.Columns["Team"].DataPropertyName = "Team";
            this.DgvCandidates.Columns["Name"].DataPropertyName = "Name";
            this.DgvCandidates.Columns["Grade"].DataPropertyName = "Grade";

            this.DgvCandidates.Columns.Add(new DataGridViewCheckBoxColumn
            {
                Name = "HasImage",
                HeaderText = "Tiene foto",
                DataPropertyName = "HasImage",
                ReadOnly = true
            });

            this.DgvCandidates.Columns.Add(new DataGridViewCheckBoxColumn
            {
                Name = "IsUpdated",
                HeaderText = "Actualizado",
                DataPropertyName = "IsUpdated",
                ReadOnly = true
            });
        }

        private void DesignGrid()
        {
            this.DgvCandidates.Columns["Id"].Visible = false;
            this.DgvCandidates.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            this.DgvCandidates.Columns["Team"].Width = (int)(this.DgvCandidates.Width * 0.2);
            this.DgvCandidates.Columns["Team"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            this.DgvCandidates.Columns["Name"].Width = (int)(this.DgvCandidates.Width * 0.4);
            this.DgvCandidates.Columns["Name"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            this.DgvCandidates.Columns["Grade"].Width = (int)(this.DgvCandidates.Width * 0.2);
            this.DgvCandidates.Columns["Grade"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            this.DgvCandidates.Columns["HasImage"].Width = (int)(this.DgvCandidates.Width * 0.1);
            this.DgvCandidates.Columns["IsUpdated"].Width = (int)(this.DgvCandidates.Width * 0.1);

            this.DgvCandidates.AllowUserToResizeRows = false;
            this.DgvCandidates.AllowUserToResizeColumns = false;
            this.DgvCandidates.AllowUserToAddRows = false;
            this.DgvCandidates.AllowUserToDeleteRows = false;
            this.DgvCandidates.RowHeadersVisible = false;
            this.DgvCandidates.MultiSelect = false;
            this.DgvCandidates.ReadOnly = true;
            this.DgvCandidates.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private async void FormCandidates_Load(object sender, EventArgs e)
        {
            await this.LoadCandidatesAsync();
            this.DesignGrid();
        }

        private async void BtnAdd_Click(object sender, EventArgs e)
        {
            FormCandidatesAdd formCandidatesAdd = new(_unitOfWork, _loginInfo);

            formCandidatesAdd.ShowDialog();

            if (formCandidatesAdd.IsDisposed)
            {
                await this.LoadCandidatesAsync();
                this.DesignGrid();
            }
        }

        private async void BtnUpdate_Click(object sender, EventArgs e)
        {
            if (this.DgvCandidates.RowCount == 0)
            {
                return;
            }

            try
            {
                int candidateId = (int)this.DgvCandidates.CurrentRow.Cells[0].Value;

                FormCandidatesAdd formCandidatesAdd = new(_unitOfWork, _loginInfo, candidateId);

                formCandidatesAdd.ShowDialog();

                if (formCandidatesAdd.IsDisposed)
                {
                    await this.LoadCandidatesAsync();
                    this.DesignGrid();
                }
            }
            catch (Exception)
            {
            }
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void BtnDelete_Click(object sender, EventArgs e)
        {
            if (DgvCandidates.RowCount == 0)
            {
                return;
            }

            int candidateId = (int)this.DgvCandidates.CurrentRow.Cells[0].Value;
            DialogResult resp;

            resp = MessageBoxComponent.ShowQuestion("¿Desea eliminar el elemento seleccionado?", "Eliminar");

            if (resp == DialogResult.Yes)
            {
                try
                {
                    var isSuccess = await _unitOfWork.Candidate.RemoveAsync(candidateId);

                    if (isSuccess)
                    {
                        MessageBoxComponent.ShowInfo(ReplyMessage.MESSAGE_DELETE);
                        await this.LoadCandidatesAsync();
                        this.DesignGrid();
                    }
                    else
                    {
                        MessageBoxComponent.ShowError(ReplyMessage.MESSAGE_FAILED);
                    }
                }
                catch (Exception)
                {
                    MessageBoxComponent.ShowError("Ocurrió un error al eliminar el candidato.");
                }
            }
        }
    }
}
