using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Project.View;
using Project.ViewModel.WindowServices;

namespace Project.ViewModel.Commands
{
    class LoginUserCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        private LoginWindow loginWindow;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if(loginWindow == null)
            {
                IWindowService windowService = new WindowServices.WindowServices();
                loginWindow = windowService.ShowWindow<LoginWindow>() as LoginWindow;
            }
            loginWindow.Closed += (a, e) =>
            {
                loginWindow.Close();
                loginWindow = null;
            };
        }
        public LoginUserCommand()
        {

        }
    }
}
