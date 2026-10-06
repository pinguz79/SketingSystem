using System.ComponentModel;

namespace SketingSystem
{
    public partial class FormDisciplina : Form
    {
        public FormDisciplina()
        {
            InitializeComponent();
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string NomeDisciplina
        {
            get => txtNome.Text.Trim();
            set => txtNome.Text = value;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (btnDelete.Cursor == Cursors.No) return;

            DialogResult = DialogResult.Yes;
            Close();
        }

        internal void SafeDelete(bool safe)
        {
            tpDelete.SetToolTip(btnDelete, !safe ? "Attenzine: partecipanti iscritti a questa disciplina. Eliminandola verranno rimossi" : null);
        }

        internal void CanDelete(bool enabled)
        {
            btnDelete.Visible = true;
            btnDelete.ForeColor = enabled ? SystemColors.ControlText : Color.DarkGray;
            btnDelete.BackColor = enabled ? SystemColors.Control : Color.FromArgb(235, 235, 235);
            btnDelete.Cursor = enabled ? Cursors.Hand : Cursors.No;
            tpDelete.SetToolTip(btnDelete, !enabled ? "Non è possibile eliminare una disciplina con gare associate." : null);
        }
    }
}
