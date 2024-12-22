using System;
using GenosStore.Services.Interface.Common;
using Microsoft.Win32;

namespace GenosStore.Services.Implementation.Common {
    public class SaveService: ISaveService {
        public string SpawnSaveDialog(string filename) {
            var dlg = new SaveFileDialog {
                FileName = filename,
                DefaultExt = ".pdf",
                Filter = "PDF документы (.pdf) | *.pdf",
            };
            
            
            bool? result = dlg.ShowDialog();

            if (result == null) {
                return null;
            }

            if (result == true) {
                return dlg.FileName;
            }
            return null;
        }
    }
}