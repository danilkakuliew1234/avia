using Project.View;
using Project.ViewModel.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Project.ViewModel
{
    class LoginWindowViewModel : BaseViewModel
    {
        public string Login
        {
            get => login;
            set
            {
                login = value;
                OnPropertyChanged(nameof(Login));
            }
        }
        public string Password
        {
            get => password;
            set
            {
                password = value;
                OnPropertyChanged(nameof(Password));
            }
        }
        public bool IsLoggined
        {
            get => isLoggined;
            set
            {
                if (value)
                {
                    mainWindowViewModel.Authorized = value;
                    mainWindowViewModel.Login = Login;
                    loginWindow.Close();
                }
                isLoggined = value;
                OnPropertyChanged(nameof(IsLoggined));
            }
        }
        public ICommand LoginCommand
        {
            get => loginCommand;
            set
            {
                OnPropertyChanged(nameof(LoginCommand));
                loginCommand = value;
            }
        }
        private LoginWindow loginWindow;
        private string login;
        private string password;
        private bool isLoggined;
        private MainWindowViewModel mainWindowViewModel;
        private ICommand loginCommand;
        public LoginWindowViewModel(MainWindowViewModel mainWindowViewModel, LoginWindow loginWindow)
        {
            this.mainWindowViewModel = mainWindowViewModel;
            this.loginWindow = loginWindow;
            LoginCommand = new LoginCommand(this);
        }
    }
}
