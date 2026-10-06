using static System.Net.WebRequestMethods;

namespace SketingSystem.UI.Panels
{
    partial class GiudicePanel
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            flpMain = new FlowLayoutPanel();
            lbl = new Label();
            vpTecnica = new VotoPanel();
            vpInterpretazioneMusicalita = new VotoPanel();
            vpShow = new VotoPanel();
            vpPadding = new VotoPanel();
            vpTotale = new VotoPanel();
            flpMain.SuspendLayout();
            SuspendLayout();
            // 
            // flpMain
            // 
            flpMain.Controls.Add(lbl);
            flpMain.Controls.Add(vpTecnica);
            flpMain.Controls.Add(vpInterpretazioneMusicalita);
            flpMain.Controls.Add(vpShow);
            flpMain.Controls.Add(vpPadding);
            flpMain.Controls.Add(vpTotale);
            flpMain.Dock = DockStyle.Fill;
            flpMain.Location = new Point(0, 0);
            flpMain.Name = "flpMain";
            flpMain.Size = new Size(1003, 80);
            flpMain.TabIndex = 0;
            // 
            // lbl
            // 
            lbl.Location = new Point(3, 0);
            lbl.Name = "lbl";
            lbl.Size = new Size(200, 80);
            lbl.TabIndex = 0;
            lbl.Text = "lbl";
            lbl.TextAlign = ContentAlignment.MiddleLeft;
            lbl.UseMnemonic = false;
            // 
            // vpTecnica
            // 
            vpTecnica.Location = new Point(211, 5);
            vpTecnica.Margin = new Padding(5);
            vpTecnica.Name = "vpTecnica";
            vpTecnica.Size = new Size(120, 68);
            vpTecnica.TabIndex = 1;
            vpTecnica.DataChanged += vpVoto_DataChanged;
            // 
            // vpInterpretazioneMusicalita
            // 
            vpInterpretazioneMusicalita.Location = new Point(341, 5);
            vpInterpretazioneMusicalita.Margin = new Padding(5);
            vpInterpretazioneMusicalita.Name = "vpInterpretazioneMusicalita";
            vpInterpretazioneMusicalita.Size = new Size(120, 68);
            vpInterpretazioneMusicalita.TabIndex = 2;
            vpInterpretazioneMusicalita.DataChanged += vpVoto_DataChanged;
            // 
            // vpShow
            // 
            vpShow.Location = new Point(471, 5);
            vpShow.Margin = new Padding(5);
            vpShow.Name = "vpShow";
            vpShow.Size = new Size(120, 68);
            vpShow.TabIndex = 3;
            vpShow.DataChanged += vpVoto_DataChanged;
            // 
            // vpPadding
            // 
            vpPadding.Location = new Point(601, 5);
            vpPadding.Margin = new Padding(5);
            vpPadding.Name = "vpPadding";
            vpPadding.Size = new Size(120, 68);
            vpPadding.TabIndex = 4;
            // 
            // vpTotale
            // 
            vpTotale.Location = new Point(731, 5);
            vpTotale.Margin = new Padding(5);
            vpTotale.Name = "vpTotale";
            vpTotale.ReadOnly = true;
            vpTotale.Size = new Size(120, 68);
            vpTotale.TabIndex = 5;
            // 
            // GiudicePanel
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(flpMain);
            Name = "GiudicePanel";
            Size = new Size(1003, 80);
            flpMain.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private FlowLayoutPanel flpMain;
        private Label lbl;
        private VotoPanel vpTecnica;
        private VotoPanel vpInterpretazioneMusicalita;
        private VotoPanel vpShow;
        private VotoPanel vpPadding;
        private VotoPanel vpTotale;
    }
}
