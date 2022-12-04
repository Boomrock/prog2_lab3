using System.Windows.Controls;

namespace prog2_lab3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public interface ILoadWindow
    {
        /// <summary>
        /// Загрузка нужной page
        /// </summary>
        /// <param name="page">экземпляр Page</param>
        void LoadPage(Page page);
    }
}
