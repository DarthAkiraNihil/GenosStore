using System;
using System.Collections.ObjectModel;
using System.Data.Entity.Core.Metadata.Edm;
using System.Linq;
using GenosStore.Model.Entity.Orders;
using GenosStore.Model.Entity.User;
using GenosStore.Services.Interface;
using GenosStore.Utility;
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

        private BankCard _currentCard;

        public BankCard CurrentCard {
            get { return _currentCard; }
            set {
                _currentCard = value;
                NotifyPropertyChanged("CurrentCard");
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

        #region AddCardCommand

        private readonly RelayCommand _addCardCommand;

        public RelayCommand AddCardCommand {
            get { return _addCardCommand; }
        }

        private void AddCard(object parameter) {
            CurrentCard = new BankCard();
        }

        private bool CanAddCard(object parameter) {
            return true;
        }

        #endregion

        #region EditCardCommand

        private readonly RelayCommand _editCardCommand;

        public RelayCommand EditCardCommand {
            get { return _editCardCommand; }
        }

        private void EditCard(object parameter) {
            CurrentCard = CustomerBankCards.First(i => i.Id == Convert.ToInt32(parameter));
        }

        private bool CanEditCard(object parameter) {
            return true;
        }

        #endregion

        #region DeleteCardCommand

        private readonly RelayCommand _deleteCardCommand;

        public RelayCommand DeleteCardCommand {
            get { return _deleteCardCommand; }
        }

        private void DeleteCard(object parameter) {
            int id = (int) parameter;
            _services.Entity.Orders.BankCards.Delete(id);
            _services.Entity.Orders.BankCards.Save();
            CustomerBankCards = new ObservableCollection<BankCard>((_user as Customer)?.BankCards);
        }

        private bool CanDeleteCard(object parameter) {
            return true;
        }

        #endregion

        #region SaveCardCommand

        private readonly RelayCommand _saveCardCommand;

        public RelayCommand SaveCardCommand {
            get { return _saveCardCommand; }
        }

        private void SaveCard(object parameter) {

            if (CurrentCard.Id == 0) {
                _services.Entity.Orders.BankCards.Create(CurrentCard);
                (_user as Customer)?.BankCards.Add(CurrentCard);
            } else {
                _services.Entity.Orders.BankCards.Update(CurrentCard);
            }
            _services.Entity.Orders.BankCards.Save();
            CustomerBankCards = new ObservableCollection<BankCard>((_user as Customer)?.BankCards);
            CurrentCard = null;
        }

        private bool CanSaveCard(object parameter) {
            return CurrentCard != null;
        }

        #endregion
        public BankCardsModel(IServices services, User user) : base(services, user) {
            BankSystems = new ObservableCollection<BankSystem>(
                _services.Entity.Orders.BankSystems.List()
            );
            CustomerBankCards = new ObservableCollection<BankCard>((_user as Customer)?.BankCards);

            _editCardCommand = new RelayCommand(EditCard, CanEditCard);
            _saveCardCommand = new RelayCommand(SaveCard, CanSaveCard);
            _deleteCardCommand = new RelayCommand(DeleteCard, CanDeleteCard);
            _addCardCommand = new RelayCommand(AddCard, CanAddCard);
            
            Title = "Банковские карты";
        }
    }
}