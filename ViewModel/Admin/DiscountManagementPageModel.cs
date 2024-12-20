using System;
using System.Collections.ObjectModel;
using System.Linq;
using GenosStore.Model.Entity.Item;
using GenosStore.Model.Entity.Orders;
using GenosStore.Model.Entity.User;
using GenosStore.Services.Interface;
using GenosStore.Utility;
using GenosStore.Utility.AbstractViewModels;
using Xamarin.Forms.Platform.WPF;

namespace GenosStore.ViewModel.Admin {
    public class DiscountManagementPageModel: RequiresUserViewModel {
        
        public ObservableCollection<ItemType> ItemTypes { get; set; }

        private string _discountValueValidationError;

        public string DiscountValueValidationError {
            get { return _discountValueValidationError; }
            set {
                _discountValueValidationError = value;
                NotifyPropertyChanged("DiscountValueValidationError");
            }
        }
        
        private ItemType _selectedType;

        public ItemType SelectedType {
            get { return _selectedType; }
            set {
                _selectedType = value;
                GetItemsAndDiscountInfo(_selectedType);
                NotifyPropertyChanged("SelectedType");
            }
        }

        public class ItemAndDiscountInfo {
            public Item Item { get; set; }
            public string DiscountInfo { get; set; }
        }

        private ItemAndDiscountInfo _itemAndDiscountInfo;

        public ItemAndDiscountInfo CurrentItem {
            get { return _itemAndDiscountInfo; }
            set {
                _itemAndDiscountInfo = value;
                NotifyPropertyChanged("CurrentItem");
            }
        }
        
        private ObservableCollection<ItemAndDiscountInfo> _itemsOfSelectedType;

        public ObservableCollection<ItemAndDiscountInfo> ItemsOfSelectedType {
            get { return _itemsOfSelectedType; }
            set {
                _itemsOfSelectedType = value;
                NotifyPropertyChanged("ItemsOfSelectedType");
            }
        }

        #region ActivateDiscountCommand

        private readonly RelayCommand _activateDiscount;

        public RelayCommand ActivateDiscountCommand {
            get { return _activateDiscount; }
        }

        private void ActivateDiscount(object parameter) {
            var item = ItemsOfSelectedType.FirstOrDefault(i => i.Item.Id == (int) parameter);

            var activeDiscount = new ActiveDiscount() {
                Value = 0.0,
                EndsAt = DateTime.Now
            };
                
            item.Item.ActiveDiscount = activeDiscount;
            CurrentItem = item;
            GetItemsAndDiscountInfo(_selectedType);
        }

        private bool CanActivateDiscount(object parameter) {
            var item = ItemsOfSelectedType.FirstOrDefault(i => i.Item.Id == (int) parameter);
            return item?.Item.ActiveDiscount == null;
        }

        #endregion

        #region EditDiscountCommand

        private readonly RelayCommand _editDiscount;

        public RelayCommand EditDiscountCommand {
            get { return _editDiscount; }
        }

        private void EditDiscount(object parameter) {
            CurrentItem = ItemsOfSelectedType.FirstOrDefault(i => i.Item.Id == (int) parameter);
            GetItemsAndDiscountInfo(_selectedType);
        }

        private bool CanEditDiscount(object parameter) {
            var item = ItemsOfSelectedType.FirstOrDefault(i => i.Item.Id == (int) parameter);
            return item?.Item.ActiveDiscount != null;
        }

        #endregion

        #region DeactivateDiscountCommand

        private readonly RelayCommand _deactivateDiscount;

        public RelayCommand DeactivateDiscountCommand {
            get { return _deactivateDiscount; }
        }

        private void DeactivateDiscount(object parameter) {
            var item = ItemsOfSelectedType.FirstOrDefault(i => i.Item.Id == (int) parameter);
            _services.Entity.Orders.ActiveDiscounts.Deactivate(item?.Item.ActiveDiscount);
            GetItemsAndDiscountInfo(_selectedType);
        }

        private bool CanDeactivateDiscount(object parameter) {
            var item = ItemsOfSelectedType.FirstOrDefault(i => i.Item.Id == (int) parameter);
            return item?.Item.ActiveDiscount != null;
        }

        #endregion

        #region SaveDiscountCommand

        private readonly RelayCommand _saveDiscount;

        public RelayCommand SaveDiscountCommand {
            get { return _saveDiscount; }
        }

        private void SaveDiscount(object parameter) {
            if (CurrentItem.Item.ActiveDiscount.Value < 0.0 || CurrentItem.Item.ActiveDiscount.Value > 1.0) {
                DiscountValueValidationError = "Некорректный множитель цены";
                return;
            }
            
            _services.Entity.Items.All.Save();
            GetItemsAndDiscountInfo(_selectedType);
        }

        private bool CanSaveDiscount(object parameter) {
            return CurrentItem?.Item?.ActiveDiscount?.EndsAt != null && CurrentItem?.Item?.ActiveDiscount?.Value != null;
        }

        #endregion

        private void GetItemsAndDiscountInfo(ItemType itemType) {
            ItemsOfSelectedType = new ObservableCollection<ItemAndDiscountInfo>(
                _services.Entity.Items.All.List().Where(i => i.ItemType.Id == itemType.Id).Select(
                    i => {
                        var it = new ItemAndDiscountInfo();
                        
                        it.Item = i;
                        
                        if (i.ActiveDiscount == null) {
                            it.DiscountInfo = "без скидки";
                        } else {
                            it.DiscountInfo = $"назначена скидка {i.ActiveDiscount.Value} до {i.ActiveDiscount.EndsAt}";
                        }
                        
                        return it;
                    }
                )
            );
        }
        
        public DiscountManagementPageModel(IServices services, User user) : base(services, user) {
            
            _activateDiscount = new RelayCommand(ActivateDiscount, CanActivateDiscount);
            _editDiscount = new RelayCommand(EditDiscount, CanEditDiscount);
            _deactivateDiscount = new RelayCommand(DeactivateDiscount, CanDeactivateDiscount);
            _saveDiscount = new RelayCommand(SaveDiscount, CanSaveDiscount);
            
            ItemTypes = new ObservableCollection<ItemType>(
                _services.Entity.Items.ItemTypes.List().ToList()
            );
            
            Title = "Управление скидками";
        }
    }
}