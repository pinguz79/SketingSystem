using System;
using System.Collections.Generic;
using System.Text;

namespace SketingSystem.Helpers
{
    public class TabManager
    {
        private readonly TabControl _tabControl;

        public TabManager(TabControl tabControl)
        {
            _tabControl = tabControl;

            _tabControl.DrawMode = TabDrawMode.OwnerDrawFixed;
            _tabControl.DrawItem += DrawTab;
            _tabControl.MouseDown += MouseDown;
        }

        public void OpenTab(string key, string title, UserControl control)
        {
            var tab = _tabControl.TabPages.Cast<TabPage>().FirstOrDefault(t => t.Name == key);

            if (tab == null)
            {
                tab = new TabPage
                {
                    Name = key,
                    Text = title
                };

                control.Dock = DockStyle.Fill;
                tab.Controls.Add(control);

                _tabControl.TabPages.Add(tab);
            }
            _tabControl.SelectedTab = tab;
        }

        internal IEnumerable<TabPage> GetAllTabs() => _tabControl.TabPages.Cast<TabPage>();

        internal TabPage GetTab(string tabName) => _tabControl.TabPages.Cast<TabPage>().FirstOrDefault(t => t.Name == $"tab{tabName}");

        private void DrawTab(object sender, DrawItemEventArgs e)
        {
            var tab = _tabControl.TabPages[e.Index];
            var rect = _tabControl.GetTabRect(e.Index);

            e.Graphics.DrawString(tab.Text, SystemFonts.DefaultFont, Brushes.Black, rect.X + 2, rect.Y + 4);

            var closeRect = new Rectangle(rect.Right - 15, rect.Top + 4, 10, 10);
            e.Graphics.DrawString("x", SystemFonts.DefaultFont, Brushes.Red, closeRect);
        }

        private void MouseDown(object sender, MouseEventArgs e)
        {
            for (int i = 0; i < _tabControl.TabPages.Count; i++)
            {
                var rect = _tabControl.GetTabRect(i);
                var closeRect = new Rectangle(rect.Right - 15, rect.Top + 4, 10, 10);

                if (closeRect.Contains(e.Location) || e.Button == MouseButtons.Middle && rect.Contains(e.Location))
                {
                    _tabControl.TabPages.RemoveAt(i);
                    return;
                }
            }
        }
    }
}
