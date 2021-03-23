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
    class AvaibleFlightWindowViewModel : icommand
    {
        public ICommand BuyTicket
        {
            get => buyTicket;
            set
            {
                OnPropertyChanged(nameof(BuyTicket));
                buyTicket = value;
            }
        }
        public DateTime StartFlightTime
        {
            get => startFlightTime;
            set
            {
                OnPropertyChanged(nameof(StartFlightTime));
                startFlightTime = value;
            }
        }
        public DateTime EndFlightTime
        {
            get => endFlightTime;
            set
            {
                OnPropertyChanged(nameof(EndFlightTime));
                endFlightTime = value;
            }
        }
        public string AviaName
        {
            get => aviaName;
            set
            {
                OnPropertyChanged(nameof(AviaName));
                aviaName = value;
            }
        }
        public string From
        {
            get => from;
            set
            {
                OnPropertyChanged(nameof(From));
                from = value;
            }
        }
        public string To
        {
            get => to;
            set
            {
                OnPropertyChanged(nameof(To));
                to = value;
            }
        }
        public int Price
        {
            get => price;
            set
            {
                OnPropertyChanged(nameof(Price));
                price = value;
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
