namespace SketingSystem.UI.UserControls
{
    partial class GaraView
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
                _mainForm.GiudiceUpdated -= MainForm_GiudiceUpdated;
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
            flpMainPanel = new FlowLayoutPanel();
            SuspendLayout();
            // 
            // flpMainPanel
            // 
            flpMainPanel.AutoScroll = true;
            flpMainPanel.Dock = DockStyle.Fill;
            flpMainPanel.FlowDirection = FlowDirection.TopDown;
            flpMainPanel.WrapContents = false;
            flpMainPanel.Location = new Point(0, 0);
            flpMainPanel.Name = "flpMainPanel";
            flpMainPanel.Size = new Size(901, 424);
            flpMainPanel.TabIndex = 0;
            // 
            // GaraView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(flpMainPanel);
            Name = "GaraView";
            Size = new Size(901, 424);
            Load += GaraView_Load;
            ResumeLayout(false);
        }

        #endregion

        private FlowLayoutPanel flpMainPanel;
    }
}
