using Project.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Project.ViewModel.Commands
{
    class LoginCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        private LoginWindowViewModel loginWindowViewModel;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            loginWindowViewModel.IsLoggined = new AuthModel().Auth(loginWindowViewModel.Login, loginWindowViewModel.Password);
        }
        public LoginCommand(LoginWindowViewModel loginWindowViewModel)
        {
            this.loginWindowViewModel = loginWindowViewModel;
        }
    }
}
