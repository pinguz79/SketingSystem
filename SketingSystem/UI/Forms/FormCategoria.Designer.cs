namespace SketingSystem
{
    partial class FormCategoria
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            lblNome = new Label();
            txtNome = new TextBox();
            btnCancel = new Button();
            btnDelete = new Button();
            btnSave = new Button();
            tlpButtons = new TableLayoutPanel();
            tpDelete = new ToolTip(components);
            tlpButtons.SuspendLayout();
            SuspendLayout();
            // 
            // lblNome
            // 
            lblNome.AutoSize = true;
            lblNome.Location = new Point(12, 15);
            lblNome.Name = "lblNome";
            lblNome.Size = new Size(97, 15);
            lblNome.TabIndex = 0;
            lblNome.Text = "Nome Categoria:";
            // 
            // txtNome
            // 
            txtNome.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtNome.Location = new Point(115, 12);
            txtNome.Name = "txtNome";
            txtNome.Size = new Size(366, 23);
            txtNome.TabIndex = 1;
            // 
            // btnCancel
            // 
            btnCancel.Anchor = AnchorStyles.None;
            btnCancel.Location = new Point(15, 3);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(86, 23);
            btnCancel.TabIndex = 0;
            btnCancel.Text = "Annulla";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // btnDelete
            // 
            btnDelete.Anchor = AnchorStyles.None;
            btnDelete.Location = new Point(131, 3);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(86, 23);
            btnDelete.TabIndex = 1;
            btnDelete.Text = "Elimina";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Visible = false;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnSave
            // 
            btnSave.Anchor = AnchorStyles.None;
            btnSave.Location = new Point(248, 3);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(86, 23);
            btnSave.TabIndex = 2;
            btnSave.Text = "Salva";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // tlpButtons
            // 
            tlpButtons.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tlpButtons.ColumnCount = 3;
            tlpButtons.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33333F));
            tlpButtons.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33333F));
            tlpButtons.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33333F));
            tlpButtons.Controls.Add(btnCancel, 0, 0);
            tlpButtons.Controls.Add(btnDelete, 1, 0);
            tlpButtons.Controls.Add(btnSave, 2, 0);
            tlpButtons.Location = new Point(70, 47);
            tlpButtons.Name = "tlpButtons";
            tlpButtons.RowCount = 1;
            tlpButtons.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlpButtons.Size = new Size(350, 30);
            tlpButtons.TabIndex = 2;
            // 
            // FormCategoria
            // 
            AcceptButton = btnSave;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnCancel;
            ClientSize = new Size(493, 82);
            Controls.Add(tlpButtons);
            Controls.Add(txtNome);
            Controls.Add(lblNome);
            Name = "FormCategoria";
            Text = "Categoria";
            tlpButtons.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblNome;
        private TextBox txtNome;

        private Button btnCancel;
        private Button btnDelete;
        private Button btnSave;

        private TableLayoutPanel tlpButtons;
        private ToolTip tpDelete;
    }
}