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
    public class DetailViewModel: INotifyPropertyChanged
    {
        public Command ButtonCartao { get; set; }


        public DetailViewModel()
        {
            ButtonCartao = new Command(ExecuteAddCartao, CanExecute);
        }

        public void ExecuteAddCartao()
        {
            App.NavigateMaster(new CartaoView());
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
