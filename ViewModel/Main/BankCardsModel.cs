using System.Collections.ObjectModel;
using GenosStore.Model.Entity.Orders;
using GenosStore.Model.Entity.User;
using GenosStore.Services.Interface;
using GenosStore.Utility.AbstractViewModels;

namespace GenosStore.ViewModel.Main {
    public class BankCardsModel: RequiresUserViewModel {

        private ObservableCollection<BankSystem> _bankSystems;

        public ObservableCollection<BankSystem> BankSystems {
            get { return _bankSystems; }
            set {
                _bankSystems = value;
                NotifyPropertyChanged("BankSystems");
            }
        }

        private BankCard _selectedCard;

        public BankCard SelectedCard {
            get { return _selectedCard; }
            set {
                _selectedCard = value;
                NotifyPropertyChanged("SelectedCard");
            }
        }

        private ObservableCollection<BankCard> _customerBankCards;

        public ObservableCollection<BankCard> CustomerBankCards {
            get { return _customerBankCards; }
            set {
                _customerBankCards = value;
                NotifyPropertyChanged("CustomerBankCards");
            }
        }
        
        public BankCardsModel(IServices services, User user) : base(services, user) {
            BankSystems = new ObservableCollection<BankSystem>(
                _services.Entity.Orders.BankSystems.List()
            );
            CustomerBankCards = new ObservableCollection<BankCard>((user as Customer)?.BankCards);
        }
    }
}