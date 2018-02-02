using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using VisaPayApp.Droid.Annotations;
using VisaPayApp.View;
using Xamarin.Forms;

namespace VisaPayApp.ViewModel
{
    public class ReceberViewModel: INotifyPropertyChanged
    {
        public Command ButtonPagar { get; set; }

        public ReceberViewModel()
        {
            ButtonPagar = new Command(Execute, CanExecute);
        }
        public bool CanExecute()
        {
            return true;
        }
        public void Execute()
        {
            App.NavigateMaster(new RecebendoNfc());
        }
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
