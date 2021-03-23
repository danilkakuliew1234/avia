using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.View;
using LocalEntities;
using System.Windows.Input;
using Project.ViewModel.Commands;

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
        private List<AvailableFlightWindow> tickets = new List<AvailableFlightWindow>();
        private AvailableFlightWindow page;
        private ICommand nextPageCommand;
        private ICommand backPageCommand;
        private int currentPage;
        public MainWindowViewModel()
        {
            currentPage = 0;

            NextPageCommand = new NextPageCommand(Next);
            BackPageCommand = new BackPageCommand(Back);

            WindowServices.IWindowService windowService = new WindowServices.WindowServices();

            List<AvailableFlightWindow> tempTickets = new List<AvailableFlightWindow>();

            foreach(Ticket ticket in new Project.Model.GetTicketsModel().GetTickets())
            {
                Tickets.Add(windowService.CreateAvaibleFlightWindow<AvailableFlightWindow>(ticket));
            }

            Page = Tickets[currentPage];
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
    }
}
