using Project.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Project.ViewModel.Commands
{
    class NextPageCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        private Action next;
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            next();
        }

        public NextPageCommand(Action next)
        {
            this.next = next;
        }
    }
}
