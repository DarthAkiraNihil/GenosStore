using System;
using GenosStore.Services.Interface.Common;
using Microsoft.Win32;

namespace GenosStore.Services.Implementation.Common {
    public class SaveService: ISaveService {
        public string SpawnSaveDialog() {
            SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog();
            dlg.FileName = "Receipt"; // Default file name
            dlg.DefaultExt = ".text"; // Default file extension
            dlg.Filter = "Text documents (.pdf)|*.pdf"; // Filter files by extension

            // Show save file dialog box
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