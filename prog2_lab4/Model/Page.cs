using System.Windows.Controls;

namespace prog2_lab4.Model
{
    public class Page
    {
        public Page(UserControl UserControl, object DataContext)
        {
            this.UserControl = UserControl;
            this.DataContext = DataContext;
        }
        public UserControl UserControl;
        public object DataContext;
    }
}
