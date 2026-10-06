using System.ComponentModel;

namespace SketingSystem
{
    public partial class FormCategoria : Form
    {
        public FormCategoria()
        {
            InitializeComponent();
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string NomeCategoria
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

        internal void CanDelete(bool enabled)
        {
            btnDelete.Visible = true;
            btnDelete.ForeColor = enabled ? SystemColors.ControlText : Color.DarkGray;
            btnDelete.BackColor = enabled ? SystemColors.Control : Color.FromArgb(235, 235, 235);
            btnDelete.Cursor = enabled ? Cursors.Hand : Cursors.No;
            tpDelete.SetToolTip(btnDelete, !enabled ? "Non è possibile eliminare una categoria con partecipanti associati." : null);
        }
    }
}
