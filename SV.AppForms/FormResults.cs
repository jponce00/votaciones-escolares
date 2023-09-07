using SV.Infrastructure.Persistences.Interfaces;
using SV.Utilities.Components;

namespace SV.AppForms
{
    public partial class FormResults : Form
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly LoginInfo _loginInfo;

        public FormResults(IUnitOfWork unitOfWork, LoginInfo loginInfo)
        {
            _unitOfWork = unitOfWork;
            _loginInfo = loginInfo;

            InitializeComponent();
        }

        private async Task LoadCandidatesAreaAsync()
        {
            var candidates = await _unitOfWork.Vote.GetResultsAsync(_loginInfo.Shift);

            const int WIDTH_BOX = 305;
            const int HEIGHT_BOX = 365;
            const int MARGIN_BOX = 10;

            const int WIDTH_PB = 300;
            const int HEIGHT_PB = 300;

            int numCandidates = 0;

            FlpCandidates.Controls.Clear();

            foreach (var candidate in candidates)
            {
                Panel panel = new()
                {
                    Size = new Size(WIDTH_BOX, HEIGHT_BOX)
                };

                Button button = new()
                {
                    Text = candidate.Team,
                    Size = new Size(WIDTH_PB, HEIGHT_PB),
                    TextAlign = ContentAlignment.TopCenter,
                    ImageAlign = ContentAlignment.BottomCenter,
                    Padding = new Padding(5),
                    Location = new Point(2, 19)
                };

                using MemoryStream ms = new(candidate.Picture!);
                button.Image = Image.FromStream(ms);

                Label label = new()
                {
                    Text = $"# de votos: {candidate.Votes}",
                    TextAlign = ContentAlignment.MiddleCenter,
                    AutoSize = false,
                    Size = new Size(WIDTH_BOX - 5, 30),
                    Location = new Point(2, HEIGHT_PB + 25)
                };

                panel.Controls.Add(button);
                panel.Controls.Add(label);

                FlpCandidates.Controls.Add(panel);

                numCandidates++;
            }

            int paddingX = (int)Math.Ceiling((GbCandidates.Width - (numCandidates * WIDTH_BOX)) * 0.5 - (numCandidates * MARGIN_BOX));
            int paddingY = (int)Math.Ceiling((FlpCandidates.Height - HEIGHT_BOX) * 0.5);

            FlpCandidates.Padding = new Padding(paddingX, paddingY, paddingX, paddingY);
        }

        private async void FormResults_Load(object sender, EventArgs e)
        {
            await this.LoadCandidatesAreaAsync();
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
