using BusinessLogic;
using DataModel.Entities;
using GeneralExtensions;
using Persistence.Migrations;
using SketingSystem.Helpers;
using SketingSystem.UI.UserControls;

namespace SketingSystem
{
    public partial class FormMain : Form
    {
        private readonly IDataService _dataService;
        private readonly TabManager _tabManager;

        private const string _version = "v0.0.1 (DEMO)";

        // =====================================================
        // EVENT HUB (UI SYNC)
        // =====================================================

        public event Action<Categoria>? CategoriaAdded;
        public event Action<Categoria>? CategoriaUpdated;

        public event Action<Disciplina>? DisciplinaAdded;
        public event Action<Disciplina>? DisciplinaUpdated;

        public event Action<Giudice>? GiudiceAdded;
        public event Action<Giudice>? GiudiceUpdated;

        public FormMain(IDataService dataService)
        {
            InitializeComponent();

            _dataService = dataService;
            _tabManager = new TabManager(tcMain);

            CategoriaAdded += (categoria) => (_tabManager.GetTab("Iscritti")?.GetMainControl() as PartecipantiView)?.AddCategoria(categoria);
            DisciplinaAdded += (disciplina) => (_tabManager.GetTab("Iscritti")?.GetMainControl() as PartecipantiView)?.AddDisciplina(disciplina);
            GiudiceAdded += (giudice) => AddGiudiceGara(giudice);
            CategoriaUpdated += (categoria) => BuildGaraMenu();
            DisciplinaUpdated += (disciplina) => UpdateDisciplina(disciplina);
        }

        private void UpdateDisciplina(Disciplina disciplina)
        {
            (_tabManager.GetTab("Iscritti")?.GetMainControl() as PartecipantiView)?.UpdateDisciplina(disciplina);
            BuildGaraMenu();
        }

        private void AddGiudiceGara(Giudice giudice)
        {
            var gare = _dataService.GetGare();
            foreach (var gara in gare)
            {
                gara.Giudici.Add(giudice);
                foreach (var p in gara.Partecipanti)
                {
                    if (!gara.Voti.ContainsKey(p) || !gara.Voti[p].ContainsKey(giudice))
                    {
                        var votazione = new Votazione { Giudice = giudice, Partecipante = p, Gara = gara };
                        gara.Votazioni.Add(votazione);
                    }
                }
                _dataService.SaveChanges();

                var garaView = _tabManager.GetTab($"Gara{gara.Disciplina.Nome.ToCamelCase()}Categoria{gara.Categoria.Nome.ToCamelCase()}")?.GetMainControl() as GaraView;
                foreach (var tab in _tabManager.GetAllTabs())
                {
                    var tabname = tab.Name;
                    var garaname = $"tabGara{gara.Disciplina.Nome.ToCamelCase()}Categoria{gara.Categoria.Nome.ToCamelCase()}";
                    var x = tabname == garaname;
                }
                garaView?.AddGiudice(giudice);
            }
        }

        // =====================================================
        // LOAD
        // =====================================================

        private void FormMain_Load(object sender, EventArgs e)
        {
            LoadDiscipline();
            LoadCategorie();
            LoadGiudici();

            BuildGaraMenu();

            Text += $" - {_version}";
        }

        // =====================================================
        // MENU BUILD CENTRALIZZATO
        // =====================================================

        private void BuildGaraMenu()
        {
            tsmiGara.DropDownItems.Clear();

            foreach (var disciplinaItem in tsmiDiscipline.DropDownItems.OfType<ToolStripMenuItem>())
            {
                if (disciplinaItem.Tag is not Disciplina disciplina)
                    continue;

                var disciplinaMenu = new ToolStripMenuItem()
                {
                    Text = disciplina.Nome,
                    Name = $"tsmiGara{disciplina.Nome.ToCamelCase()}",
                    Tag = disciplina
                };

                foreach (var categoriaItem in tsmiCategorie.DropDownItems.OfType<ToolStripMenuItem>())
                {
                    if (categoriaItem.Tag is not Categoria categoria)
                        continue;

                    var subItem = new ToolStripMenuItem()
                    {
                        Text = categoria.Nome,
                        Name = $"tsmiGara{disciplina.Nome.ToCamelCase()}Categoria{categoria.Nome.ToCamelCase()}",
                        Tag = new { Disciplina = disciplina, Categoria = categoria }
                    };

                    subItem.Click += tsmiGaraMenuItem_Click;
                    disciplinaMenu.DropDownItems.Add(subItem);
                }

                tsmiGara.DropDownItems.Add(disciplinaMenu);
            }
        }

        // =====================================================
        // LOAD INITIAL DATA
        // =====================================================

        private void LoadCategorie()
        {
            foreach (var c in _dataService.GetCategorie())
                AddCategoria(c);
        }

        private void LoadDiscipline()
        {
            foreach (var d in _dataService.GetDiscipline())
                AddDisciplina(d);
        }

        private void LoadGiudici()
        {
            foreach (var g in _dataService.GetGiudici())
                AddGiudice(g);
        }

        // =====================================================
        // ADD METHODS
        // =====================================================

        private void AddCategoria(Categoria categoria)
        {
            var item = new ToolStripMenuItem()
            {
                Text = categoria.Nome,
                Name = $"tsmi{categoria.Nome.ToCamelCase()}",
                Tag = categoria
            };

            item.Click += tsmiCategoriaMenuItem_Click;
            tsmiCategorie.DropDownItems.Add(item);

            CategoriaAdded?.Invoke(categoria);

            BuildGaraMenu();
        }

        private void AddDisciplina(Disciplina disciplina)
        {
            var item = new ToolStripMenuItem()
            {
                Text = disciplina.Nome,
                Name = $"tsmi{disciplina.Nome.ToCamelCase()}",
                Tag = disciplina
            };

            item.Click += tsmiDisciplinaMenuItem_Click;
            tsmiDiscipline.DropDownItems.Add(item);

            DisciplinaAdded?.Invoke(disciplina);

            BuildGaraMenu();
        }

        private void AddGiudice(Giudice giudice)
        {
            var item = new ToolStripMenuItem()
            {
                Text = giudice.Nome,
                Name = $"tsmi{giudice.Nome.ToCamelCase()}",
                Tag = giudice
            };

            item.Click += tsmiGiudiceMenuItem_Click;
            tsmiGiudici.DropDownItems.Add(item);

            GiudiceAdded?.Invoke(giudice);
        }

        // =====================================================
        // CREATE NEW ITEMS
        // =====================================================

        private void tsmiNuovaDisciplina_Click(object sender, EventArgs e)
        {
            using var form = new FormDisciplina();

            if (form.ShowDialog() == DialogResult.OK)
            {
                var d = _dataService.AddDisciplina(form.NomeDisciplina);
                _dataService.SaveChanges();

                AddDisciplina(d);
            }
        }

        private void tsmiNuovaCategoria_Click(object sender, EventArgs e)
        {
            using var form = new FormCategoria();

            if (form.ShowDialog() == DialogResult.OK)
            {
                var c = _dataService.AddCategoria(form.NomeCategoria);
                _dataService.SaveChanges();

                AddCategoria(c);
            }
        }

        private void tsmiNuovoGiudice_Click(object sender, EventArgs e)
        {
            using var form = new FormGiudice();

            if (form.ShowDialog() == DialogResult.OK)
            {
                var g = _dataService.AddGiudice(form.NomeGiudice);
                _dataService.SaveChanges();

                AddGiudice(g);
            }
        }

        // =====================================================
        // EDIT EVENTS
        // =====================================================

        private void tsmiDisciplinaMenuItem_Click(object? sender, EventArgs e)
        {
            var item = sender as ToolStripMenuItem;
            var disciplina = item.Tag as Disciplina;

            var form = new FormDisciplina()
            {
                NomeDisciplina = disciplina.Nome
            };
            form.SafeDelete(!disciplina.Partecipanti.Any());
            form.CanDelete(!disciplina.Gare.Any());

            switch (form.ShowDialog())
            {
                case DialogResult.OK:
                    disciplina.Nome = form.NomeDisciplina;
                    _dataService.SaveChanges();
                    item.Text = disciplina.Nome;
                    DisciplinaUpdated?.Invoke(disciplina);
                    break;

                case DialogResult.Yes:

                    if (MessageBox.Show(
                        $"Sei sicuro di voler eliminare la disciplina '{disciplina.Nome}'?\n" + 
                        $"{(disciplina.Partecipanti.Count != 0 ? $"Attenzione ci sono {disciplina.Partecipanti.Count} partecipanti iscritti a questa disciplina, verrà annullata l'iscrizione.\n" : "")}" +
                        $"Questa operazione è irreversibile.", "Conferma eliminazione", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        _dataService.DeleteDisciplina(disciplina);
                        _dataService.SaveChanges();
                        tsmiDiscipline.DropDownItems.Remove(item);
                        DisciplinaUpdated?.Invoke(disciplina);
                    }
                    break;
            }
        }

        private void tsmiCategoriaMenuItem_Click(object? sender, EventArgs e)
        {
            var item = sender as ToolStripMenuItem;
            var categoria = item.Tag as Categoria;

            var form = new FormCategoria()
            {
                NomeCategoria = categoria.Nome
            };
            form.CanDelete(!categoria.Partecipanti.Any());

            switch (form.ShowDialog())
            {
                case DialogResult.OK:
                    categoria.Nome = form.NomeCategoria;
                    _dataService.SaveChanges();
                    item.Text = categoria.Nome;
                    CategoriaUpdated?.Invoke(categoria);
                    BuildGaraMenu();
                    break;

                case DialogResult.Yes:
                    if (MessageBox.Show($"Sei sicuro di voler eliminare la categoria '{categoria.Nome}'? Questa operazione è irreversibile.", "Conferma eliminazione", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        _dataService.DeleteCategoria(categoria);
                        _dataService.SaveChanges();
                        tsmiCategorie.DropDownItems.Remove(item);
                        CategoriaUpdated?.Invoke(categoria);
                        BuildGaraMenu();
                    }
                    break;
            }
        }

        private void tsmiGiudiceMenuItem_Click(object? sender, EventArgs e)
        {
            var item = sender as ToolStripMenuItem;
            var giudice = item.Tag as Giudice;

            var form = new FormGiudice()
            {
                NomeGiudice = giudice.Nome
            };
            form.CanDelete(!giudice.Votazioni.Any());

            switch(form.ShowDialog())
            {
                case DialogResult.OK:
                    giudice.Nome = form.NomeGiudice;
                    _dataService.SaveChanges();
                    item.Text = giudice.Nome;
                    GiudiceUpdated?.Invoke(giudice);
                    break;
                case DialogResult.Yes:
                    if (MessageBox.Show($"Sei sicuro di voler eliminare il giudice '{giudice.Nome}'? Questa operazione è irreversibile.", "Conferma eliminazione", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        _dataService.DeleteGiudice(giudice);
                        _dataService.SaveChanges();
                        tsmiGiudici.DropDownItems.Remove(item);
                        GiudiceUpdated?.Invoke(giudice);
                    }
                    break;
            }
        }

        // =====================================================
        // NAVIGATION
        // =====================================================

        private void tsmiGaraMenuItem_Click(object? sender, EventArgs e)
        {
            var item = sender as ToolStripMenuItem;
            var data = item.Tag as dynamic;

            var disciplina = data.Disciplina as Disciplina;
            var categoria = data.Categoria as Categoria;

            _tabManager.OpenTab(
                $"tabGara{disciplina.Nome.ToCamelCase()}Categoria{categoria.Nome.ToCamelCase()}",
                $"{disciplina.Nome} - {categoria.Nome}", new GaraView(_dataService, disciplina, categoria, this));
        }

        private void tsmiIscritti_Click(object sender, EventArgs e)
        {
            _tabManager.OpenTab("tabIscritti", "Iscritti", new PartecipantiView(_dataService));
        }
    }
}