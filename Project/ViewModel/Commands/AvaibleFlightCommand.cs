using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Project.ViewModel.Commands
{
    class AvaibleFlightCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        private Action avaibleFlightMethod;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            avaibleFlightMethod();
        }
        public AvaibleFlightCommand(Action avaibleFlightMethod)
        {
            this.avaibleFlightMethod = avaibleFlightMethod;
        }
    }
}
