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
                nextPageCommand = value;
                OnPropertyChanged(nameof(NextPageCommand));
            }
        }
        public ICommand BackPageCommand
        {
            get => backPageCommand;
            set
            {
                backPageCommand = value;
                OnPropertyChanged(nameof(BackPageCommand));
            }
        }
        public ICommand AvaibleFlightsCommand
        {
            get => avaibleFlightCommand;
            set
            {
                avaibleFlightCommand = value;
                OnPropertyChanged(nameof(AvaibleFlightsCommand));
            }
        }
        public ICommand NewsVisibilityCommand
        {
            get => newsVisibilityCommand;
            set
            {
                newsVisibilityCommand = value;
                OnPropertyChanged(nameof(NewsVisibilityCommand));
            }
        }
        public ICommand LoginUserCommand
        {
            get => loginUserCommand;
            set
            {
                loginUserCommand = value;
                OnPropertyChanged(nameof(LoginUserCommand));
            }
        }
        public Visibility AvaibleFlightVisibility
        {
            get => avaibleFlightVisibility;
            set
            {
                avaibleFlightVisibility = value;
                OnPropertyChanged(nameof(AvaibleFlightVisibility));
            }
        }
        public Visibility NewsVisibility
        {
            get => newsVisibility;
            set
            {
                newsVisibility = value;
                OnPropertyChanged(nameof(NewsVisibility));
            }
        }
        public Visibility InfoButtonVisibility
        {
            get => infoButtonVisibility;
            set
            {
                infoButtonVisibility = value;
                OnPropertyChanged(nameof(InfoButtonVisibility));
            }
        }
        public Visibility LoginButtonVisibility
        {
            get => loginButtonVisibility;
            set
            {
                loginButtonVisibility = value;
                OnPropertyChanged(nameof(LoginButtonVisibility));
            }
        }
        public List<AvailableFlightWindow> Tickets
        {
            get => tickets;
            set
            {
                tickets = value;
                OnPropertyChanged(nameof(Tickets));
            }
        }
        public AvailableFlightWindow Page
        {
            get => page;
            set
            {
                page = value;
                OnPropertyChanged(nameof(Page));
            }
        }
        public bool Authorized
        {
            get => authorized;
            set
            {
                if (value)
                {
                    InfoButtonVisibility = Visibility.Visible;
                    LoginButtonVisibility = Visibility.Collapsed;
                }
                authorized = value;
                OnPropertyChanged(nameof(Authorized));
            }
        }
        public string Login
        {
            get => login;
            set
            {
                login = $"Здравствуйте, {value}";
                OnPropertyChanged(nameof(Login));
            }
        }
        private List<AvailableFlightWindow> tickets = new List<AvailableFlightWindow>();
        private AvailableFlightWindow page;
        private ICommand nextPageCommand;
        private ICommand backPageCommand;
        private ICommand avaibleFlightCommand;
        private ICommand newsVisibilityCommand;
        private ICommand loginUserCommand;
        private Visibility infoButtonVisibility;
        private Visibility loginButtonVisibility;
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
            InfoButtonVisibility = Visibility.Collapsed;
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
            }
        }
        private void SetVisibilityFlights()
        {
            if (NewsVisibility == Visibility.Visible)
            {
                NewsVisibility = Visibility.Collapsed;
                AvaibleFlightVisibility = Visibility.Visible;
            }
        }
        private void SetVisibilityNews()
        {
            if (AvaibleFlightVisibility == Visibility.Visible)
            {
                AvaibleFlightVisibility = Visibility.Collapsed;
                NewsVisibility = Visibility.Visible;
            }
        }
    }
}
