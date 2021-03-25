using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using LocalEntities;
using Project.ViewModel.WindowServices;

namespace Project.ViewModel
{
    class AvaibleFlightWindowViewModel : BaseViewModel
    {
        public ICommand BuyTicket
        {
            get => buyTicket;
            set
            {
                buyTicket = value;
                OnPropertyChanged(nameof(BuyTicket));
            }
        }
        public DateTime StartFlightTime
        {
            get => startFlightTime;
            set
            {
                startFlightTime = value;
                OnPropertyChanged(nameof(StartFlightTime));
            }
        }
        public DateTime EndFlightTime
        {
            get => endFlightTime;
            set
            {
                endFlightTime = value;
                OnPropertyChanged(nameof(EndFlightTime));
            }
        }
        public string AviaName
        {
            get => aviaName;
            set
            {
                aviaName = value;
                OnPropertyChanged(nameof(AviaName));
            }
        }
        public string From
        {
            get => from;
            set
            {
                from = value;
                OnPropertyChanged(nameof(From));
            }
        }
        public string To
        {
            get => to;
            set
            {
                to = value;
                OnPropertyChanged(nameof(To));
            }
        }
        public int Price
        {
            get => price;
            set
            {
                price = value;
                OnPropertyChanged(nameof(Price));
            }
        }
        public int ID { get; set; }
        private ICommand buyTicket;
        private DateTime startFlightTime;
        private DateTime endFlightTime;
        private string aviaName;
        private string from;
        private string to;
        private int price;

        public AvaibleFlightWindowViewModel(Ticket ticket)
        {
            StartFlightTime = ticket.StartTime;
            EndFlightTime = ticket.EndTime;
            AviaName = ticket.AviaName;
            From = ticket.From;
            To = ticket.To;
            Price = ticket.Price;
            ID = ticket.ID;
            BuyTicket = new Commands.BuyTicketCommand(ID);
        }
    }
}
