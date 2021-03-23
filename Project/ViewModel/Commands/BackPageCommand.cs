using Project.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Project.ViewModel.Commands
{
    class BackPageCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        public event Action Back;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            Back();
        }
        public BackPageCommand(Action back)
        {
            this.Back = back;
        }
    }
}
