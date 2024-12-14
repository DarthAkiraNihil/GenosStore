using System;
using System.Windows;
using GalaSoft.MvvmLight.Messaging;
using GenosStore.Model.Entity.User;
using GenosStore.Services.Interface;
using GenosStore.Utility;
using GenosStore.Utility.AbstractViewModels;

namespace GenosStore.ViewModel.Admin {
    public class SalesAnalysisReportPageModel: RequiresUserViewModel {

        private DateTime _reportFrom;

        public DateTime ReportFrom {
            get { return _reportFrom; }
            set {
                _reportFrom = value;
                NotifyPropertyChanged("ReportFrom");
            }
        }

        private DateTime _reportTo;

        public DateTime ReportTo {
            get { return _reportTo; }
            set {
                _reportTo = value;
                NotifyPropertyChanged("ReportTo");
            }
        }

        #region GenerateSalesReportCommand

        private readonly RelayCommand _generateSalesReportCommand;

        public RelayCommand GenerateSalesReportCommand {
            get { return _generateSalesReportCommand; }
        }

        private void GenerateSalesReport(object parameter) {
            string path = _services.Common.Saving.SpawnSaveDialog();
            if (path != null) {
                _services.Common.Reports.GenerateSalesAnalysisReport(ReportFrom, ReportTo, path);
                
                MessageBox.Show("CREATE REPORT");
            }
        }

        private bool CanGenerateSalesReport(object parameter) {
            if (ReportFrom > ReportTo) {
                return false;
            }
            return true;
        }

        #endregion
        
        public SalesAnalysisReportPageModel(IServices services, User user) : base(services, user) {
            _generateSalesReportCommand = new RelayCommand(GenerateSalesReport, CanGenerateSalesReport);
            ReportFrom = DateTime.Today;
            ReportTo = DateTime.Today;
        }
        
    }
}