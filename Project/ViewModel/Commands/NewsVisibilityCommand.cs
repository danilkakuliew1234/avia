using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Project.ViewModel.Commands
{
    class NewsVisibilityCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        private Action method;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            method();
        }
        public NewsVisibilityCommand(Action method)
        {
            this.method = method;
        }
    }
}
