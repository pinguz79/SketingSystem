using BusinessLogic;
using DataModel.Entities;
using GeneralExtensions;
using Persistence.Migrations;
using SketingSystem.UI.Panels;

namespace SketingSystem.UI.UserControls
{
    public partial class GaraView : UserControl
    {
        private readonly IDataService _dataService;
        private readonly Disciplina _disciplina;
        private readonly Categoria _categoria;
        private Gara _gara;

        private FormMain _mainForm;

        public GaraView(IDataService dataService, Disciplina disciplina, Categoria categoria, FormMain formMain)
        {
            InitializeComponent();
            _dataService = dataService;
            _disciplina = disciplina;
            _categoria = categoria;
            _mainForm = formMain;

            _mainForm.GiudiceUpdated += MainForm_GiudiceUpdated;
        }

        private void MainForm_GiudiceUpdated(Giudice giudice)
        {
            foreach (Control ctrlPartecipante in flpMainPanel.Controls)
            {
                if (ctrlPartecipante is not Panel pnlPartecipante)
                    continue;

                FlowLayoutPanel flpGiudici = pnlPartecipante.Controls.OfType<FlowLayoutPanel>().FirstOrDefault();

                if (flpGiudici == null)
                    continue;

                foreach (GiudicePanel pnlGiudice in flpGiudici.Controls.OfType<GiudicePanel>())
                {
                    if (pnlGiudice.Giudice?.Id != giudice.Id)
                        continue;

                    // aggiorna reference
                    pnlGiudice.Giudice = giudice;

                    // forza refresh UI
                    pnlGiudice.RefreshGiudice();
                }
            }
        }
        private void GaraView_Load(object sender, EventArgs e)
        {
            // Verifica se la gara esiste nel database
            _gara = _dataService.GetGara(_disciplina, _categoria) ?? _dataService.AddGara(_disciplina, _categoria);

            if (_gara.Giudici.Count != _dataService.GetGiudici().Count)
                _gara.Giudici = _dataService.GetGiudici();
            if (_gara.Votazioni.Count != _gara.Giudici.Count * _gara.Partecipanti.Count())
            {
                foreach (var p in _gara.Partecipanti)
                {
                    if (!_gara.Voti.ContainsKey(p))
                        _gara.Voti[p] = new Dictionary<Giudice, Votazione>();
                    foreach (var g in _gara.Giudici)
                    {
                        if (!_gara.Voti[p].ContainsKey(g))
                        {
                            if (!_gara.Votazioni.Any(gg => gg.Giudice.Id == g.Id && gg.Partecipante.Id == p.Id))
                            {
                                var votazione = new Votazione { Giudice = g, Partecipante = p, Gara = _gara };
                                _gara.Votazioni.Add(votazione);
                                _gara.Voti[p][g] = votazione;
                            }
                        }
                    }
                }
            }
            _dataService.SaveChanges();

            BeginInvoke((MethodInvoker)delegate
            {
                foreach (var p in _gara.Partecipanti)
                {
                    flpMainPanel.Controls.Add(CreatePartecipantePanel(p, _gara.Voti[p]));
                }
            });
        }

        private Panel CreatePartecipantePanel(Partecipante partecipante, Dictionary<Giudice, Votazione> giudici)
        {
            Panel pnl = new Panel
            {
                BackColor = (flpMainPanel.Controls.Count % 2 == 0) ? Color.White : Color.FromArgb(248, 249, 250),
                Height = 180,
                Margin = new Padding(5),
                BorderStyle = BorderStyle.FixedSingle,
                Name = $"pnl{$"{partecipante}".ToCamelCase()}",
                Tag = partecipante,
            };
            pnl.Width = flpMainPanel.ClientSize.Width - pnl.Margin.Left - pnl.Margin.Right - 
                (pnl.VerticalScroll.Visible ? SystemInformation.VerticalScrollBarWidth : 0);

            // =========================
            // HEADER PARTECIPANTE
            // =========================
            Label lblHeader = new Label
            {
                Text = $"{partecipante}",
                Dock = DockStyle.Top,
                Height = 32,
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                BackColor = Color.FromArgb(230, 235, 245),
                TextAlign = ContentAlignment.MiddleLeft,
                Padding = new Padding(10, 0, 0, 0),
                Name = $"lblHeader_{$"{partecipante}".ToCamelCase()}",
                UseMnemonic = false,
            };

            // =========================
            // PANEL CONTENITORE GIUDICI
            // =========================
            FlowLayoutPanel flpGiudici = new FlowLayoutPanel
            {
                FlowDirection = FlowDirection.TopDown,
                Dock = DockStyle.Fill,
                AutoScroll = true,
                WrapContents = false,
                Name = $"flpGiudici_{$"{partecipante}".ToCamelCase()}",
            };
            BeginInvoke((MethodInvoker)delegate
            {
                flpGiudici.SuspendLayout();

                foreach (var g in giudici.Keys)
                {
                    flpGiudici.Controls.Add(CreateGiudiciPanel(flpGiudici, g, giudici[g]));
                }

                AdjustHeight(pnl);
            });

            // =========================
            // Add controls
            // =========================
            pnl.Controls.Add(flpGiudici);
            pnl.Controls.Add(lblHeader);

            return pnl;
        }

        private void AdjustHeight(Panel pnl)
        {
            Label lblHeader = pnl.Controls.OfType<Label>().FirstOrDefault();
            FlowLayoutPanel flpGiudici = pnl.Controls.OfType<FlowLayoutPanel>().FirstOrDefault();

            flpGiudici.ResumeLayout(true);
            // FORZA CALCOLO LAYOUT PRIMA DI MISURARE
            flpGiudici.PerformLayout();
            int giudiciHeight = flpGiudici.PreferredSize.Height;
            // header fisso
            int headerHeight = lblHeader.Height;
            // padding extra di sicurezza
            int padding = 20;
            // qui setti SOLO il parent
            // IMPORTANTISSIMO: misura corretta (non Controls.Sum)
            pnl.Height = headerHeight + giudiciHeight + padding;
        }

        private GiudicePanel CreateGiudiciPanel(FlowLayoutPanel flpParent, Giudice giudice, Votazione voti)
        {
            GiudicePanel pnl = new GiudicePanel
            {
                Margin = new Padding(5),
                Tag = giudice,
                Name = $"gp{$"{giudice}".ToCamelCase()}",
                BackColor = (flpParent.Controls.Count % 2 == 0) ? Color.FromArgb(245, 245, 245) : Color.White,
                Giudice = giudice,
                Votazione = voti,
            };
            pnl.Width = flpParent.ClientSize.Width - pnl.Margin.Left - pnl.Margin.Right - 
                (pnl.VerticalScroll.Visible ? SystemInformation.VerticalScrollBarWidth : 0);
            
            pnl.DataChanged += Pnl_DataChanged;

            return pnl;
        }

        private void Pnl_DataChanged(object? sender, EventArgs e)
        {
            GiudicePanel pnl = sender as GiudicePanel;
            _gara.Voti[pnl.Votazione.Partecipante][pnl.Votazione.Giudice] = pnl.Votazione;
            _dataService.SaveChanges();
        }

        internal void AddGiudice(Giudice giudice)
        {
            flpMainPanel.Controls.OfType<Panel>().ToList().ForEach(p =>
            {
                var partecipante = p.Tag as Partecipante;
                var flpGiudici = p.Controls.OfType<FlowLayoutPanel>().FirstOrDefault();
                if (flpGiudici != null)
                {
                    flpGiudici.Controls.Add(CreateGiudiciPanel(flpGiudici, giudice, _gara.Voti[partecipante][giudice]));
                }
                AdjustHeight(p);
            });
        }
    }
}
