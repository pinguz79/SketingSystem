namespace SketingSystem
{
    partial class FormMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            msMainMenu = new MenuStrip();
            tsmiAnagrafica = new ToolStripMenuItem();
            tsmiDiscipline = new ToolStripMenuItem();
            tsmiNuovaDisciplina = new ToolStripMenuItem();
            tssDiscipline = new ToolStripSeparator();
            tsmiCategorie = new ToolStripMenuItem();
            tsmiNuovaCategoria = new ToolStripMenuItem();
            tssCategorie = new ToolStripSeparator();
            tsmiGiudici = new ToolStripMenuItem();
            tsmiNuovoGiudice = new ToolStripMenuItem();
            tssGiudici = new ToolStripSeparator();
            tssAnagrafica = new ToolStripSeparator();
            tsmiIscritti = new ToolStripMenuItem();
            tsmiGara = new ToolStripMenuItem();
            tcMain = new TabControl();
            msMainMenu.SuspendLayout();
            SuspendLayout();
            // 
            // msMainMenu
            // 
            msMainMenu.Items.AddRange(new ToolStripItem[] { tsmiAnagrafica, tsmiGara });
            msMainMenu.Location = new Point(0, 0);
            msMainMenu.Name = "msMainMenu";
            msMainMenu.Size = new Size(800, 24);
            msMainMenu.TabIndex = 0;
            msMainMenu.Text = "menuStrip1";
            // 
            // tsmiAnagrafica
            // 
            tsmiAnagrafica.DropDownItems.AddRange(new ToolStripItem[] { tsmiDiscipline, tsmiCategorie, tsmiGiudici, tssAnagrafica, tsmiIscritti });
            tsmiAnagrafica.Name = "tsmiAnagrafica";
            tsmiAnagrafica.Size = new Size(76, 20);
            tsmiAnagrafica.Text = "&Anagrafica";
            // 
            // tsmiDiscipline
            // 
            tsmiDiscipline.DropDownItems.AddRange(new ToolStripItem[] { tsmiNuovaDisciplina, tssDiscipline });
            tsmiDiscipline.Name = "tsmiDiscipline";
            tsmiDiscipline.Size = new Size(125, 22);
            tsmiDiscipline.Text = "&Discipline";
            // 
            // tsmiNuovaDisciplina
            // 
            tsmiNuovaDisciplina.Name = "tsmiNuovaDisciplina";
            tsmiNuovaDisciplina.Size = new Size(109, 22);
            tsmiNuovaDisciplina.Text = "&Nuova";
            tsmiNuovaDisciplina.Click += tsmiNuovaDisciplina_Click;
            // 
            // tssDiscipline
            // 
            tssDiscipline.Name = "tssDiscipline";
            tssDiscipline.Size = new Size(106, 6);
            // 
            // tsmiCategorie
            // 
            tsmiCategorie.DropDownItems.AddRange(new ToolStripItem[] { tsmiNuovaCategoria, tssCategorie });
            tsmiCategorie.Name = "tsmiCategorie";
            tsmiCategorie.Size = new Size(125, 22);
            tsmiCategorie.Text = "&Categorie";
            // 
            // tsmiNuovaCategoria
            // 
            tsmiNuovaCategoria.Name = "tsmiNuovaCategoria";
            tsmiNuovaCategoria.Size = new Size(109, 22);
            tsmiNuovaCategoria.Text = "&Nuova";
            tsmiNuovaCategoria.Click += tsmiNuovaCategoria_Click;
            // 
            // tssCategorie
            // 
            tssCategorie.Name = "tssCategorie";
            tssCategorie.Size = new Size(106, 6);
            // 
            // tsmiGiudici
            // 
            tsmiGiudici.DropDownItems.AddRange(new ToolStripItem[] { tsmiNuovoGiudice, tssGiudici });
            tsmiGiudici.Name = "tsmiGiudici";
            tsmiGiudici.Size = new Size(125, 22);
            tsmiGiudici.Text = "&Giudici";
            // 
            // tsmiNuovoGiudice
            // 
            tsmiNuovoGiudice.Name = "tsmiNuovoGiudice";
            tsmiNuovoGiudice.Size = new Size(110, 22);
            tsmiNuovoGiudice.Text = "&Nuovo";
            tsmiNuovoGiudice.Click += tsmiNuovoGiudice_Click;
            // 
            // tssGiudici
            // 
            tssGiudici.Name = "tssGiudici";
            tssGiudici.Size = new Size(107, 6);
            // 
            // tssAnagrafica
            // 
            tssAnagrafica.Name = "tssAnagrafica";
            tssAnagrafica.Size = new Size(122, 6);
            // 
            // tsmiIscritti
            // 
            tsmiIscritti.Name = "tsmiIscritti";
            tsmiIscritti.Size = new Size(125, 22);
            tsmiIscritti.Text = "&Iscritti";
            tsmiIscritti.Click += tsmiIscritti_Click;
            // 
            // tsmiGara
            // 
            tsmiGara.Name = "tsmiGara";
            tsmiGara.Size = new Size(43, 20);
            tsmiGara.Text = "&Gara";
            // 
            // tcMain
            // 
            tcMain.Dock = DockStyle.Fill;
            tcMain.Location = new Point(0, 24);
            tcMain.Name = "tcMain";
            tcMain.SelectedIndex = 0;
            tcMain.Size = new Size(800, 426);
            tcMain.TabIndex = 1;
            // 
            // FormMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(tcMain);
            Controls.Add(msMainMenu);
            MainMenuStrip = msMainMenu;
            MaximizeBox = false;
            Name = "FormMain";
            Text = "Sketing System";
            WindowState = FormWindowState.Maximized;
            Load += FormMain_Load;
            msMainMenu.ResumeLayout(false);
            msMainMenu.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip msMainMenu;
        private ToolStripMenuItem tsmiAnagrafica;
        private ToolStripMenuItem tsmiDiscipline;
        private TabControl tcMain;
        private ToolStripMenuItem tsmiNuovaDisciplina;
        private ToolStripSeparator tssDiscipline;
        private ToolStripMenuItem tsmiCategorie;
        private ToolStripMenuItem tsmiNuovaCategoria;
        private ToolStripSeparator tssCategorie;
        private ToolStripSeparator tssAnagrafica;
        private ToolStripMenuItem tsmiIscritti;
        private ToolStripMenuItem tsmiGiudici;
        private ToolStripMenuItem tsmiNuovoGiudice;
        private ToolStripSeparator tssGiudici;
        private ToolStripMenuItem tsmiGara;
    }
}
