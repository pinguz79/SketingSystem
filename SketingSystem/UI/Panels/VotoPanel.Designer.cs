namespace SketingSystem.UI.Panels
{
    partial class VotoPanel
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
            lbl = new Label();
            txt = new TextBox();
            SuspendLayout();
            // 
            // lbl
            // 
            lbl.Location = new Point(5, 5);
            lbl.Name = "lbl";
            lbl.Size = new Size(110, 30);
            lbl.TabIndex = 0;
            lbl.Text = "lbl";
            lbl.TextAlign = ContentAlignment.BottomCenter;
            lbl.UseMnemonic = false;
            // 
            // txt
            // 
            txt.Location = new Point(5, 40);
            txt.Name = "txt";
            txt.Size = new Size(110, 23);
            txt.TabIndex = 1;
            txt.TextAlign = HorizontalAlignment.Center;
            txt.TextChanged += txt_TextChanged;
            txt.KeyDown += txt_KeyDown;
            txt.Leave += txt_Leave;
            // 
            // VotoPanel
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(txt);
            Controls.Add(lbl);
            Margin = new Padding(5);
            Name = "VotoPanel";
            Size = new Size(120, 68);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lbl;
        private TextBox txt;
    }
}
