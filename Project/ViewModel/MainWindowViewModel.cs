using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.View;
using LocalEntities;

namespace Project.ViewModel
{
    class MainWindowViewModel : BaseViewModel
    {
        public List<AvailableFlightWindow> Tickets
        {
            get => tickets;
            set
            {
                OnPropertyChanged(nameof(Tickets));
                tickets = value;
            }
        }
        private List<AvailableFlightWindow> tickets = new List<AvailableFlightWindow>();
        public MainWindowViewModel()
        {
            WindowServices.IWindowService windowService = new WindowServices.WindowServices();

            List<AvailableFlightWindow> tempTickets = new List<AvailableFlightWindow>();

            foreach(Ticket ticket in new Project.Model.GetTicketsModel().GetTickets())
            {
                Tickets.Add(windowService.CreateAvaibleFlightWindow<AvailableFlightWindow>(ticket));
            }

        }
    }
}
