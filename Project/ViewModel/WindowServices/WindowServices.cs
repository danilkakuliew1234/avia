using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using LocalEntities;
using Project.View;

namespace Project.ViewModel.WindowServices
{
    class WindowServices : IWindowService
    {
        public AvailableFlightWindow CreateAvaibleFlightWindow<T>(Ticket ticket) where T : Page, new()
        {
            Page page = new T();
            AvaibleFlightWindowViewModel avaibleFlightWindowViewModel = new AvaibleFlightWindowViewModel(ticket);
            page.DataContext = avaibleFlightWindowViewModel;
            return (AvailableFlightWindow)page;
        }

        public View.AccountInformation CreateInformationAccountWindow<T>(LocalEntities.AccountInformation accountInformation) where T : Page, new()
        {
            Page page = new T();
            page.DataContext = new AccountInformationViewModel(accountInformation);
            return page as View.AccountInformation;
        }

        public Window ShowWindow<T>() where T : Window, new()
        {
            Window page = new T();
            page.Show();
            return page;
        }
    }
}
