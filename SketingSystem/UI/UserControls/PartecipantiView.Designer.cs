namespace SketingSystem.UI.UserControls
{
    partial class PartecipantiView
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.SplitContainer scMain;

        private System.Windows.Forms.DataGridView dgvPartecipanti;

        private System.Windows.Forms.Panel pnlEditor;
        private System.Windows.Forms.TableLayoutPanel tlpEditor;

        private System.Windows.Forms.Label lblNome;
        private System.Windows.Forms.Label lblCategoria;
        private System.Windows.Forms.Label lblDiscipline;

        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.ComboBox cmbCategoria;
        private System.Windows.Forms.CheckedListBox clbDiscipline;

        private System.Windows.Forms.Button btnNuovo;
        private System.Windows.Forms.Button btnSalva;
        private System.Windows.Forms.Button btnElimina;

        private System.Windows.Forms.TextBox txtFiltroNome;
        private System.Windows.Forms.ComboBox cmbFiltroCategoria;
        private System.Windows.Forms.ComboBox cmbFiltroDisciplina;
        private System.Windows.Forms.Button btnFiltra;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            pnlTop = new Panel();
            btnNuovo = new Button();
            btnSalva = new Button();
            btnElimina = new Button();
            txtFiltroNome = new TextBox();
            cmbFiltroCategoria = new ComboBox();
            cmbFiltroDisciplina = new ComboBox();
            btnFiltra = new Button();
            scMain = new SplitContainer();
            dgvPartecipanti = new DataGridView();
            pnlEditor = new Panel();
            tlpEditor = new TableLayoutPanel();
            lblNome = new Label();
            txtNome = new TextBox();
            lblCategoria = new Label();
            cmbCategoria = new ComboBox();
            lblDiscipline = new Label();
            clbDiscipline = new CheckedListBox();
            pnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)scMain).BeginInit();
            scMain.Panel1.SuspendLayout();
            scMain.Panel2.SuspendLayout();
            scMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPartecipanti).BeginInit();
            pnlEditor.SuspendLayout();
            tlpEditor.SuspendLayout();
            SuspendLayout();
            // 
            // pnlTop
            // 
            pnlTop.Controls.Add(btnNuovo);
            pnlTop.Controls.Add(btnSalva);
            pnlTop.Controls.Add(btnElimina);
            pnlTop.Controls.Add(txtFiltroNome);
            pnlTop.Controls.Add(cmbFiltroCategoria);
            pnlTop.Controls.Add(cmbFiltroDisciplina);
            pnlTop.Controls.Add(btnFiltra);
            pnlTop.Dock = DockStyle.Top;
            pnlTop.Location = new Point(0, 0);
            pnlTop.Name = "pnlTop";
            pnlTop.Size = new Size(1089, 60);
            pnlTop.TabIndex = 1;
            // 
            // btnNuovo
            // 
            btnNuovo.Location = new Point(10, 10);
            btnNuovo.Name = "btnNuovo";
            btnNuovo.Size = new Size(90, 23);
            btnNuovo.TabIndex = 0;
            btnNuovo.Text = "Nuovo";
            btnNuovo.Click += btnNuovo_Click;
            // 
            // btnSalva
            // 
            btnSalva.Location = new Point(110, 10);
            btnSalva.Name = "btnSalva";
            btnSalva.Size = new Size(90, 23);
            btnSalva.TabIndex = 1;
            btnSalva.Text = "Salva";
            btnSalva.Click += btnSalva_Click;
            // 
            // btnElimina
            // 
            btnElimina.Location = new Point(210, 10);
            btnElimina.Name = "btnElimina";
            btnElimina.Size = new Size(90, 23);
            btnElimina.TabIndex = 2;
            btnElimina.Text = "Elimina";
            btnElimina.Click += btnElimina_Click;
            // 
            // txtFiltroNome
            // 
            txtFiltroNome.Location = new Point(350, 10);
            txtFiltroNome.Name = "txtFiltroNome";
            txtFiltroNome.PlaceholderText = "Nome...";
            txtFiltroNome.Size = new Size(150, 23);
            txtFiltroNome.TabIndex = 3;
            // 
            // cmbFiltroCategoria
            // 
            cmbFiltroCategoria.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbFiltroCategoria.Location = new Point(510, 10);
            cmbFiltroCategoria.Name = "cmbFiltroCategoria";
            cmbFiltroCategoria.Size = new Size(150, 23);
            cmbFiltroCategoria.TabIndex = 4;
            // 
            // cmbFiltroDisciplina
            // 
            cmbFiltroDisciplina.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbFiltroDisciplina.Location = new Point(670, 10);
            cmbFiltroDisciplina.Name = "cmbFiltroDisciplina";
            cmbFiltroDisciplina.Size = new Size(150, 23);
            cmbFiltroDisciplina.TabIndex = 5;
            // 
            // btnFiltra
            // 
            btnFiltra.Location = new Point(826, 10);
            btnFiltra.Name = "btnFiltra";
            btnFiltra.Size = new Size(80, 23);
            btnFiltra.TabIndex = 6;
            btnFiltra.Text = "Filtra";
            btnFiltra.Click += btnFiltra_Click;
            // 
            // scMain
            // 
            scMain.Dock = DockStyle.Fill;
            scMain.Location = new Point(0, 60);
            scMain.Name = "scMain";
            scMain.Orientation = Orientation.Horizontal;
            // 
            // scMain.Panel1
            // 
            scMain.Panel1.Controls.Add(dgvPartecipanti);
            // 
            // scMain.Panel2
            // 
            scMain.Panel2.Controls.Add(pnlEditor);
            scMain.Size = new Size(1089, 530);
            scMain.SplitterDistance = 376;
            scMain.TabIndex = 0;
            // 
            // dgvPartecipanti
            // 
            dgvPartecipanti.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvPartecipanti.Dock = DockStyle.Fill;
            dgvPartecipanti.Location = new Point(0, 0);
            dgvPartecipanti.MultiSelect = false;
            dgvPartecipanti.Name = "dgvPartecipanti";
            dgvPartecipanti.ReadOnly = true;
            dgvPartecipanti.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPartecipanti.Size = new Size(1089, 376);
            dgvPartecipanti.TabIndex = 0;
            dgvPartecipanti.DataBindingComplete += dgvPartecipanti_DataBindingComplete;
            dgvPartecipanti.SelectionChanged += dgvPartecipanti_SelectionChanged;
            dgvPartecipanti.MouseDown += dgvPartecipanti_MouseDown;
            // 
            // pnlEditor
            // 
            pnlEditor.Controls.Add(tlpEditor);
            pnlEditor.Dock = DockStyle.Fill;
            pnlEditor.Location = new Point(0, 0);
            pnlEditor.Name = "pnlEditor";
            pnlEditor.Size = new Size(1089, 150);
            pnlEditor.TabIndex = 0;
            // 
            // tlpEditor
            // 
            tlpEditor.ColumnCount = 2;
            tlpEditor.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 100F));
            tlpEditor.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tlpEditor.Controls.Add(lblNome, 0, 0);
            tlpEditor.Controls.Add(txtNome, 1, 0);
            tlpEditor.Controls.Add(lblCategoria, 0, 1);
            tlpEditor.Controls.Add(cmbCategoria, 1, 1);
            tlpEditor.Controls.Add(lblDiscipline, 0, 2);
            tlpEditor.Controls.Add(clbDiscipline, 1, 2);
            tlpEditor.Dock = DockStyle.Fill;
            tlpEditor.Location = new Point(0, 0);
            tlpEditor.Name = "tlpEditor";
            tlpEditor.RowCount = 3;
            tlpEditor.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tlpEditor.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tlpEditor.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlpEditor.Size = new Size(1089, 150);
            tlpEditor.TabIndex = 0;
            // 
            // lblNome
            // 
            lblNome.Dock = DockStyle.Fill;
            lblNome.Location = new Point(3, 0);
            lblNome.Name = "lblNome";
            lblNome.Size = new Size(94, 30);
            lblNome.TabIndex = 0;
            lblNome.Text = "Nome";
            lblNome.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtNome
            // 
            txtNome.Dock = DockStyle.Fill;
            txtNome.Location = new Point(103, 3);
            txtNome.Name = "txtNome";
            txtNome.Size = new Size(983, 23);
            txtNome.TabIndex = 1;
            txtNome.TextChanged += InputFields_Changed;
            // 
            // lblCategoria
            // 
            lblCategoria.Dock = DockStyle.Fill;
            lblCategoria.Location = new Point(3, 30);
            lblCategoria.Name = "lblCategoria";
            lblCategoria.Size = new Size(94, 30);
            lblCategoria.TabIndex = 2;
            lblCategoria.Text = "Categoria";
            lblCategoria.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // cmbCategoria
            // 
            cmbCategoria.Dock = DockStyle.Fill;
            cmbCategoria.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCategoria.Location = new Point(103, 33);
            cmbCategoria.Name = "cmbCategoria";
            cmbCategoria.Size = new Size(983, 23);
            cmbCategoria.TabIndex = 3;
            cmbCategoria.SelectedIndexChanged += InputFields_Changed;
            // 
            // lblDiscipline
            // 
            lblDiscipline.Dock = DockStyle.Fill;
            lblDiscipline.Location = new Point(3, 60);
            lblDiscipline.Name = "lblDiscipline";
            lblDiscipline.Size = new Size(94, 90);
            lblDiscipline.TabIndex = 4;
            lblDiscipline.Text = "Discipline";
            lblDiscipline.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // clbDiscipline
            // 
            clbDiscipline.Dock = DockStyle.Fill;
            clbDiscipline.Location = new Point(103, 63);
            clbDiscipline.Name = "clbDiscipline";
            clbDiscipline.Size = new Size(983, 84);
            clbDiscipline.TabIndex = 5;
            clbDiscipline.ItemCheck += InputFields_Changed;
            // 
            // PartecipantiView
            // 
            Controls.Add(scMain);
            Controls.Add(pnlTop);
            Name = "PartecipantiView";
            Size = new Size(1089, 590);
            Load += PartecipantiView_Load;
            pnlTop.ResumeLayout(false);
            pnlTop.PerformLayout();
            scMain.Panel1.ResumeLayout(false);
            scMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)scMain).EndInit();
            scMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvPartecipanti).EndInit();
            pnlEditor.ResumeLayout(false);
            tlpEditor.ResumeLayout(false);
            tlpEditor.PerformLayout();
            ResumeLayout(false);
        }
    }
}