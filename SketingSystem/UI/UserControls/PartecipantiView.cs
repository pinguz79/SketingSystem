using BusinessLogic;
using DataModel.Entities;
using System.ComponentModel;
using System.Net.Http.Headers;

namespace SketingSystem.UI.UserControls
{
    public partial class PartecipantiView : UserControl
    {
        private readonly IDataService _dataService;

        private readonly BindingSource _bsPartecipanti = new();
        private readonly BindingSource _bsCategorie = new();
        private readonly BindingSource _bsDiscipline = new();

        private bool isLoading = false;
        private bool isDataModified = false;

        private BindingList<Partecipante> _allPartecipanti = [];

        private BindingList<Categoria> _categorie = [];
        private BindingList<Categoria> _filtroCategorie = [];

        private BindingList<Disciplina> _discipline = [];
        private BindingList<Disciplina> _filtroDiscipline = [];

        public PartecipantiView(IDataService dataService)
        {
            InitializeComponent();

            _dataService = dataService;

            dgvPartecipanti.DataSource = _bsPartecipanti;
        }

        private void PartecipantiView_Load(object sender, EventArgs e)
        {
            isLoading = true;

            LoadCategorie();
            LoadDiscipline();
            LoadPartecipanti();

            pnlEditor.Visible = false;

            UpdateButtonStates();
        }

        // =========================
        // PARTECIPANTI
        // =========================

        private void LoadPartecipanti()
        {
            isLoading = true;

            _allPartecipanti = new BindingList<Partecipante>(_dataService.GetPartecipanti());
            _allPartecipanti.ToList().ForEach(p => p.InitializeNotifications());

            _bsPartecipanti.DataSource = _allPartecipanti;
        }

        private void dgvPartecipanti_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dgvPartecipanti.ClearSelection();
            dgvPartecipanti.CurrentCell = null;
            isLoading = false;
        }

        // =========================
        // CATEGORIE
        // =========================

        private void LoadCategorie()
        {
            var categorie = _dataService.GetCategorie();

            _categorie = new BindingList<Categoria>(categorie);
            _bsCategorie.DataSource = _categorie;

            cmbCategoria.DataSource = _bsCategorie;
            cmbCategoria.DisplayMember = "Nome";
            cmbCategoria.ValueMember = "Id";

            _filtroCategorie =
            [
                new Categoria { Id = Guid.Empty, Nome = "(Tutte)" },
                .. categorie
            ];

            cmbFiltroCategoria.DataSource = _filtroCategorie;
            cmbFiltroCategoria.DisplayMember = "Nome";
            cmbFiltroCategoria.ValueMember = "Id";
        }

        // =========================
        // DISCIPLINE
        // =========================

        private void LoadDiscipline()
        {
            var discipline = _dataService.GetDiscipline();

            _discipline = new BindingList<Disciplina>(discipline);
            _bsDiscipline.DataSource = _discipline;

            clbDiscipline.DataSource = _bsDiscipline;
            clbDiscipline.DisplayMember = "Nome";
            clbDiscipline.ValueMember = "Id";

            _filtroDiscipline =
            [
                new Disciplina { Id = Guid.Empty, Nome = "(Tutte)" },
                .. discipline
            ];

            cmbFiltroDisciplina.DataSource = _filtroDiscipline;
            cmbFiltroDisciplina.DisplayMember = "Nome";
            cmbFiltroDisciplina.ValueMember = "Id";
        }

        // =========================
        // BUTTONS
        // =========================

        private void UpdateButtonStates()
        {
            if (pnlEditor.Visible)
            {
                btnNuovo.Enabled = false;
                btnSalva.Enabled = isDataModified;
                btnElimina.Enabled = !isDataModified && dgvPartecipanti.CurrentRow != null;
            }
            else
            {
                btnNuovo.Enabled = true;
                btnSalva.Enabled = false;
                btnElimina.Enabled = false;
            }
        }

        private void btnNuovo_Click(object sender, EventArgs e)
        {
            ClearEditor();
            pnlEditor.Visible = true;
            isDataModified = false;
            UpdateButtonStates();
            txtNome.Focus();
        }

        private void ClearEditor()
        {
            txtNome.Clear();
            cmbCategoria.SelectedIndex = -1;

            for (int i = 0; i < clbDiscipline.Items.Count; i++)
                clbDiscipline.SetItemChecked(i, false);
        }

        // =========================
        // SAVE / DELETE
        // =========================

        private void btnSalva_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNome.Text))
                return;

            if (cmbCategoria.SelectedItem == null)
                return;

            Partecipante partecipante;

            bool isNew =
                dgvPartecipanti.CurrentRow == null ||
                dgvPartecipanti.CurrentRow.DataBoundItem == null;

            if (isNew)
            {
                partecipante = new Partecipante();
                _dataService.AddPartecipante(partecipante);
            }
            else
            {
                dynamic row = dgvPartecipanti.CurrentRow.DataBoundItem;
                partecipante = _dataService.GetPartecipanteById(row.Id);
            }

            partecipante.Nome = txtNome.Text.Trim();
            partecipante.Categoria = cmbCategoria.SelectedItem as Categoria;
            partecipante.Discipline = clbDiscipline.CheckedItems.Cast<Disciplina>().ToList();

            _dataService.SaveChanges();

            LoadPartecipanti();

            pnlEditor.Visible = false;
            isDataModified = false;
            UpdateButtonStates();
        }

        private void btnElimina_Click(object sender, EventArgs e)
        {
            if (dgvPartecipanti.CurrentRow == null)
                return;

            dynamic row = dgvPartecipanti.CurrentRow.DataBoundItem;

            _dataService.DeletePartecipante(row.Id);
            _dataService.SaveChanges();

            LoadPartecipanti();

            pnlEditor.Visible = false;
            isDataModified = false;
            UpdateButtonStates();
        }

        // =========================
        // SELECTION
        // =========================

        private void dgvPartecipanti_SelectionChanged(object sender, EventArgs e)
        {
            if (isLoading)
                return;

            if (dgvPartecipanti.SelectedRows.Count == 0)
            {
                pnlEditor.Visible = false;
                UpdateButtonStates();
                return;
            }

            if (dgvPartecipanti.CurrentRow?.DataBoundItem == null)
                return;

            dynamic row = dgvPartecipanti.CurrentRow.DataBoundItem;

            txtNome.Text = row.Nome;

            cmbCategoria.SelectedItem = _categorie.FirstOrDefault(c => c.Id == row.CategoriaId);

            ICollection<Disciplina> selectedDiscipline = row.Discipline;

            for (int i = 0; i < clbDiscipline.Items.Count; i++)
            {
                var disciplina = clbDiscipline.Items[i] as Disciplina;
                bool isChecked = selectedDiscipline.Any(d => d.Id == disciplina.Id);
                clbDiscipline.SetItemChecked(i, isChecked);
            }

            pnlEditor.Visible = true;
            isDataModified = false;

            UpdateButtonStates();
        }

        private void InputFields_Changed(object sender, EventArgs e)
        {
            if (isLoading)
                return;

            isDataModified = true;
            UpdateButtonStates();
        }

        // =========================
        // FILTER
        // =========================

        private void btnFiltra_Click(object sender, EventArgs e) => ApplyFilters();

        private void ApplyFilters()
        {
            IEnumerable<Partecipante> query = _allPartecipanti;
            string nome = txtFiltroNome.Text.Trim();

            if (!string.IsNullOrWhiteSpace(nome))
            {
                query = query.Where(p => p.Nome.Contains(nome, StringComparison.OrdinalIgnoreCase));
            }

            if (cmbFiltroCategoria.SelectedItem is Categoria categoria && categoria.Id != Guid.Empty)
            {
                query = query.Where(p => p.CategoriaId == categoria.Id);
            }

            if (cmbFiltroDisciplina.SelectedItem is Disciplina disciplina && disciplina.Id != Guid.Empty)
            {
                query = query.Where(p => p.Discipline.Any(d => d.Id == disciplina.Id));
            }

            isLoading = true;
            _bsPartecipanti.DataSource = query;

            dgvPartecipanti.ClearSelection();
            dgvPartecipanti.CurrentCell = null;
            pnlEditor.Visible = false;
            isDataModified = false;
            UpdateButtonStates();
        }

        // =========================
        // FORMAT
        // =========================

        private string FormatDiscipline(ICollection<Disciplina> disciplines)
        {
            if (disciplines == null || disciplines.Count == 0)
                return "";

            if (disciplines.Count == 1)
                return disciplines.First().Nome;

            string names = string.Join(", ", disciplines.Select(d => d.Nome));

            return names.Length > 50 ? $"{disciplines.Count} discipline" : names;
        }

        public void AddCategoria(Categoria categoria)
        {
            _categorie.Add(categoria);

            // evita duplicazioni nel filtro
            if (!_filtroCategorie.Any(c => c.Id == categoria.Id))
                _filtroCategorie.Add(categoria);
        }

        public void AddDisciplina(Disciplina disciplina)
        {
            _discipline.Add(disciplina);
            // evita duplicazioni nel filtro
            if (!_filtroDiscipline.Any(d => d.Id == disciplina.Id))
                _filtroDiscipline.Add(disciplina);
        }

        private void dgvPartecipanti_MouseDown(object sender, MouseEventArgs e)
        {
            var hit = dgvPartecipanti.HitTest(e.X, e.Y);

            if (hit.Type == DataGridViewHitTestType.None)
            {
                dgvPartecipanti.ClearSelection();
                dgvPartecipanti.CurrentCell = null;

                pnlEditor.Visible = false;
                UpdateButtonStates();
            }
        }

        internal void UpdateDisciplina(Disciplina disciplina)
        {
            //ApplyFilters();
        }
    }
}