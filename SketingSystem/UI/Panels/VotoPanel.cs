using GeneralExtensions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SketingSystem.UI.Panels
{
    public partial class VotoPanel : UserControl
    {
        public VotoPanel()
        {
            InitializeComponent();
        }

        private bool _isDirty;

        private void txt_TextChanged(object sender, EventArgs e) => _isDirty = true;

        private void txt_Leave(object sender, EventArgs e) => CommitEdit();

        private void CommitEdit()
        {
            if (!_isDirty)
                return;

            _isDirty = false;
            DataChanged?.Invoke(this, EventArgs.Empty);
        }

        private void txt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                CommitEdit();

                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        public event EventHandler DataChanged;

        [Browsable(true)]
        [Category("Appearance")]
        [Description("Testo visualizzato nel pannello.")]
        public override string Text
        {
            get => lbl.Text;
            set
            {
                lbl.Name = $"lblVoto_{value.ToCamelCase()}";
                txt.Name = $"txtVoto_{value.ToCamelCase()}";
                lbl.Text = value.Replace(" ", Environment.NewLine);
                Name = $"vp{value.ToCamelCase()}";
            }
        }

        [Browsable(true)]
        [Category("Behavior")]
        [Description("Impedisce la modifica del valore.")]
        [DefaultValue(false)]
        public bool ReadOnly
        {
            get => txt.ReadOnly;
            set => txt.ReadOnly = value;
        }

        [Browsable(true)]
        [Category("Data")]
        [Description("Votazione associata al pannello.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public double? Voto
        {
            get => double.TryParse(txt.Text, out double result) ? result : (double?)null;
            set
            {
                if (value.HasValue)
                {
                    txt.Text = $"{value.Value:f1}";
                    lbl.Visible = true;
                    txt.Visible = true;
                }
                else
                {
                    txt.Text = string.Empty;
                    lbl.Visible = false;
                    txt.Visible = false;
                }
            }
        }
    }
}
