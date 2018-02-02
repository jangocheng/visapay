using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using VisaPayApp.Droid.Annotations;
using VisaPayApp.Model;
using VisaPayApp.View;
using Xamarin.Forms;

namespace VisaPayApp.ViewModel
{
    public class DispositivosViewModel: INotifyPropertyChanged
    {
        public List<Dispositivo> Dispositivos { get; set; }
        public Command ButtonCadastrar { get; set; }
        public DispositivosViewModel()
        {
            ButtonCadastrar = new Command(Execute, CanExecute);
        }
        public async void Execute()
        {
          await App.NavigateMaster(new DispositivoForm());
        }

        public bool CanExecute()
        {
            return true;
        }
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
