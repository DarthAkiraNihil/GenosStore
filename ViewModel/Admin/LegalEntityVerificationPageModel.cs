using System.Collections.ObjectModel;
using System.Linq;
using GenosStore.Model.Entity.User;
using GenosStore.Services.Interface;
using GenosStore.Utility;
using GenosStore.Utility.AbstractViewModels;

namespace GenosStore.ViewModel.Admin {
    public class LegalEntityVerificationPageModel: RequiresUserViewModel {

        //private ObservableCollection<LegalEntity> _verifiedLegalEntities;
        //private ObservableCollection<LegalEntity> _awaitsVerificationLegalEntities;

        private ObservableCollection<LegalEntity> _verifiedLegalEntities;

        public ObservableCollection<LegalEntity> VerifiedLegalEntities {
            get { return _verifiedLegalEntities; }
            set {
                _verifiedLegalEntities = value;
                NotifyPropertyChanged("VerifiedLegalEntities");
            }
        }

        private ObservableCollection<LegalEntity> _awaitsVerificationLegalEntities;

        public ObservableCollection<LegalEntity> AwaitsVerificationLegalEntities {
            get { return _awaitsVerificationLegalEntities; }
            set {
                _awaitsVerificationLegalEntities = value;
                NotifyPropertyChanged("AwaitsVerificationLegalEntities");
            }
        }

        #region VerifyCommand

        private readonly RelayCommand _verifyCommand;

        public RelayCommand VerifyCommand {
            get { return _verifyCommand; }
        }

        private void Verify(object parameter) {
            var id = (int) parameter;
            var entity = AwaitsVerificationLegalEntities.First(i => i.Id == id);
            _services.Entity.Users.LegalEntities.Verify(_user, entity);
            
            AwaitsVerificationLegalEntities = new ObservableCollection<LegalEntity>(
                _services.Entity.Users.LegalEntities.GetWaitingForVerification(_user)
            );
            VerifiedLegalEntities = new ObservableCollection<LegalEntity>(
                _services.Entity.Users.LegalEntities.GetVerified(_user)
            );
        }

        private bool CanVerify(object parameter) {
            return true;
        }

        #endregion

        #region RevokeVerificationCommand

        private readonly RelayCommand _revokeVerificaitonCommand;

        public RelayCommand RevokeVerificationCommand {
            get { return _revokeVerificaitonCommand; }
        }

        private void RevokeVerification(object parameter) {
            if (Utilities.SpawnQuestionMessageBox("Вопрос", "Вы уверены, что хотите отозвать подтверждение выбранного юр. лица?")) {
                var id = (int) parameter;
                var entity = VerifiedLegalEntities.First(i => i.Id == id);
                _services.Entity.Users.LegalEntities.RevokeVerification(_user, entity);
            
                VerifiedLegalEntities = new ObservableCollection<LegalEntity>(
                    _services.Entity.Users.LegalEntities.GetVerified(_user)
                );
            }
            
        }

        private bool CanRevokeVerification(object parameter) {
            return true;
        }

        #endregion
        
        public LegalEntityVerificationPageModel(IServices services, User user) : base(services, user) {
            VerifiedLegalEntities = new ObservableCollection<LegalEntity>(
                _services.Entity.Users.LegalEntities.GetVerified(_user)
                );

            AwaitsVerificationLegalEntities = new ObservableCollection<LegalEntity>(
                _services.Entity.Users.LegalEntities.GetWaitingForVerification(_user)
            );
            
            _verifyCommand = new RelayCommand(Verify, CanVerify);
            _revokeVerificaitonCommand = new RelayCommand(RevokeVerification, CanRevokeVerification);
            
            Title = "Управление верификации юридических лиц";
        }
        
    }
}