using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.View;
using LocalEntities;
using System.Windows.Input;
using Project.ViewModel.Commands;
using System.Windows;

namespace Project.ViewModel
{
    class MainWindowViewModel : BaseViewModel
    {
        public ICommand NextPageCommand
        {
            get => nextPageCommand;
            set
            {
                OnPropertyChanged(nameof(NextPageCommand));
                nextPageCommand = value;
            }
        }
        public ICommand BackPageCommand
        {
            get => backPageCommand;
            set
            {
                OnPropertyChanged(nameof(BackPageCommand));
                backPageCommand = value;
            }
        }
        public ICommand AvaibleFlightsCommand
        {
            get => avaibleFlightCommand;
            set
            {
                OnPropertyChanged(nameof(AvaibleFlightsCommand));
                avaibleFlightCommand = value;
            }
        }
        public ICommand NewsVisibilityCommand
        {
            get => newsVisibilityCommand;
            set
            {
                OnPropertyChanged(nameof(NewsVisibilityCommand));
                newsVisibilityCommand = value;
            }
        }
        public ICommand LoginUserCommand
        {
            get => loginUserCommand;
            set
            {
                OnPropertyChanged(nameof(LoginUserCommand));
                loginUserCommand = value;
            }
        }
        public Visibility AvaibleFlightVisibility
        {
            get => avaibleFlightVisibility;
            set
            {
                OnPropertyChanged(nameof(AvaibleFlightVisibility));
                avaibleFlightVisibility = value;
            }
        }
        public Visibility NewsVisibility
        {
            get => newsVisibility;
            set
            {
                OnPropertyChanged(nameof(NewsVisibility));
                newsVisibility = value;
            }
        }
        public List<AvailableFlightWindow> Tickets
        {
            get => tickets;
            set
            {
                OnPropertyChanged(nameof(Tickets));
                tickets = value;
            }
        }
        public AvailableFlightWindow Page
        {
            get => page;
            set
            {
                OnPropertyChanged(nameof(Page));
                page = value;
            }
        }
        public bool Authorized
        {
            get => authorized;
            set
            {
                OnPropertyChanged(nameof(Authorized));
                authorized = value;
            }
        }
        public string Login
        {
            get => login;
            set
            {
                OnPropertyChanged(nameof(Login));
                login = value;
            }
        }
        private List<AvailableFlightWindow> tickets = new List<AvailableFlightWindow>();
        private AvailableFlightWindow page;
        private ICommand nextPageCommand;
        private ICommand backPageCommand;
        private ICommand avaibleFlightCommand;
        private ICommand newsVisibilityCommand;
        private ICommand loginUserCommand;
        private Visibility avaibleFlightVisibility;
        private Visibility newsVisibility;
        private int currentPage;
        private string login;
        private bool authorized = false;
        public MainWindowViewModel()
        {
            currentPage = 0;

            NextPageCommand = new NextPageCommand(Next);
            BackPageCommand = new BackPageCommand(Back);
            AvaibleFlightsCommand = new AvaibleFlightCommand(SetVisibilityFlights);
            NewsVisibilityCommand = new NewsVisibilityCommand(SetVisibilityNews);
            LoginUserCommand = new LoginUserCommand(this);

            WindowServices.IWindowService windowService = new WindowServices.WindowServices();

            List<AvailableFlightWindow> tempTickets = new List<AvailableFlightWindow>();

            foreach(Ticket ticket in new Project.Model.GetTicketsModel().GetTickets())
            {
                Tickets.Add(windowService.CreateAvaibleFlightWindow<AvailableFlightWindow>(ticket));
            }

            Page = Tickets[currentPage];

            NewsVisibility = Visibility.Visible;
            AvaibleFlightVisibility = Visibility.Collapsed;
        }
        private void Next()
        {
            if(Tickets.Count - 1 > currentPage)
            {
                Page = Tickets[currentPage];
                currentPage++;
            }
        }
        private void Back()
        {
            if(!(Tickets.Count - 1 > currentPage))
            {
                Page = Tickets[currentPage];
                currentPage--;
            }
            if (currentPage == 1)
            {
                Page = Tickets[currentPage];
                currentPage--;
            } else if(currentPage == 0)
            {
                Page = Tickets[currentPage];
            }
        }
        private void SetVisibilityFlights()
        {
            if (AvaibleFlightVisibility == Visibility.Visible)
            {
                AvaibleFlightVisibility = Visibility.Collapsed;
                NewsVisibility = Visibility.Visible;
            }
        }
        private void SetVisibilityNews()
        {
            if (NewsVisibility == Visibility.Visible)
            {
                NewsVisibility = Visibility.Collapsed;
                AvaibleFlightVisibility = Visibility.Visible;
            }
        }
    }
}
