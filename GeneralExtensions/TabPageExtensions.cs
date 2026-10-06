using DataModel.Entities;

namespace GeneralExtensions
{
    public static class TabPageExtensions
    {
        public static UserControl GetMainControl(this TabPage tabPage) => tabPage.Controls.OfType<UserControl>().FirstOrDefault();
    }
}