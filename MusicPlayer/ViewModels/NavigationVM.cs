using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayer.ViewModels
{
    public class NavigationVM : ViewModelBase
    {
        public NavigationVM()
        {
            //first time created assigns the currentvm to loginvm
            CurrentVM = new LoginVM(this);
        }

        private ViewModelBase? currentvm;
        public ViewModelBase CurrentVM
        {
            get => currentvm!;
            set => this.RaiseAndSetIfChanged(ref currentvm, value);
        }
    }
}

