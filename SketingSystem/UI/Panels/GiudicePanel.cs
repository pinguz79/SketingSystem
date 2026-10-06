using DataModel.Entities;
using GeneralExtensions;
using System.ComponentModel;

namespace SketingSystem.UI.Panels
{
    public partial class GiudicePanel : UserControl
    {
        public GiudicePanel()
        {
            InitializeComponent();
        }

        private Giudice _giudice;
        private Votazione _votazione;

        public event EventHandler DataChanged;

        private void vpVoto_DataChanged(object sender, EventArgs e)
        {
            VotoPanel pnl = sender as VotoPanel;
            switch (pnl.Text)
            {
                case "Tecnica":
                    Votazione.Tecnica = pnl.Voto.Value;
                    break;
                case "Interpretazione":
                    Votazione.Interpretazione = pnl.Voto.Value;
                    break;
                case "Show":
                    Votazione.Show = pnl.Voto.Value;
                    break;
            }
            vpTotale.Voto = Votazione.Totale;
            DataChanged?.Invoke(this, EventArgs.Empty);
        }

        public void RefreshGiudice() => lbl.Text = Giudice?.Nome;

        [Browsable(true)]
        [Category("Data")]
        [Description("Giudice associato al pannello.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public Giudice Giudice
        {
            get => _giudice;
            set
            {
                _giudice = value;
                flpMain.Name = $"flpGiudice_{$"{value}".ToCamelCase()}";
                lbl.Name = $"lblGiudice_{$"{value}".ToCamelCase()}";
                lbl.Text = $"{value}";
            }
        }

        [Browsable(true)]
        [Category("Data")]
        [Description("Votazioni del Giudice.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public Votazione Votazione
        {
            get => _votazione;
            set
            {
                _votazione = value;
                vpTecnica.Name = $"vpTecnica_{$"{value}".ToCamelCase()}";
                vpTecnica.Voto = value.Tecnica;
                vpTecnica.Text = "Tecnica";
                vpTecnica.BackColor = Color.White;
                vpInterpretazioneMusicalita.Name = $"vpInterpretazioneMusicalita_{$"{value}".ToCamelCase()}";
                vpInterpretazioneMusicalita.Voto = value.Interpretazione;
                vpInterpretazioneMusicalita.Text = "Interpretazione";
                vpInterpretazioneMusicalita.BackColor = Color.FromArgb(250, 250, 250);
                vpShow.Name = $"vpShow_{$"{value}".ToCamelCase()}";
                vpShow.Voto = value.Show;
                vpShow.Text = "Show";
                vpShow.BackColor = Color.White;
                vpPadding.Voto = null;
                vpPadding.BackColor = Color.Transparent;
                vpTotale.Name = $"vpTotale_{$"{value}".ToCamelCase()}";
                vpTotale.Voto = value.Totale;
                vpTotale.Text = "Totale";
                vpTotale.BackColor = Color.FromArgb(250, 250, 250);
            }
        }
    }
}
