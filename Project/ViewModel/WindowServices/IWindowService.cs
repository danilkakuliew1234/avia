using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using LocalEntities;
using Project.View;

namespace Project.ViewModel.WindowServices
{
    public interface IWindowService
    {
        AvailableFlightWindow CreateAvaibleFlightWindow<T>(Ticket ticket) where T : Page, new();
    }
}
