using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.ViewModel
{
    class AccountInformationViewModel : BaseViewModel
    {
        public string FirstName
        {
            get => firstName;
            set
            {
                firstName = value;
                OnPropertyChanged(nameof(FirstName));
            }
        }
        public string LastName
        {
            get => lastName;
            set
            {
                lastName = value;
                OnPropertyChanged(nameof(LastName));
            }
        }
        public string Name
        {
            get => name;
            set
            {
                name = value;
                OnPropertyChanged(nameof(Name));
            }
        }
        public string AccountNumber
        {
            get => accountNumber;
            set
            {
                accountNumber = value;
                OnPropertyChanged(nameof(AccountNumber));
            }
        }
        public string CardNumber
        {
            get => cardNumber;
            set
            {
                cardNumber = value;
                OnPropertyChanged(nameof(CardNumber));
            }
        }
        public string EndDate
        {
            get => endDate;
            set
            {
                endDate = value;
                OnPropertyChanged(nameof(EndDate));
            }
        }


        private string firstName;
        private string lastName;
        private string name;
        private string accountNumber;
        private string cardNumber;
        private string endDate;

        public AccountInformationViewModel(LocalEntities.AccountInformation accountInformation)
        {
            FirstName = accountInformation.FirstName.Trim();
            LastName = accountInformation.LastName.Trim();
            Name = accountInformation.Name.Trim();
            AccountNumber = accountInformation.AccountNumber.Trim();
            CardNumber = accountInformation.CardNumber.Trim();
            EndDate = accountInformation.EndDate.Trim();
        }
    }
}
