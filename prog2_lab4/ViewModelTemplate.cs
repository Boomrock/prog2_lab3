using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace prog2_lab4
{
    internal class ViewModelTemplate
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}