using System;
using System.Collections.Generic;
using System.Text;

namespace prog2_lab3.ViewModel.Administrator
{
    class AdministratorViewModel
    {
        private ILoadWindow codeBehind;
        public AdministratorViewModel(ILoadWindow codeBehind)
        {
            this.codeBehind = codeBehind;
        }
    }
}
