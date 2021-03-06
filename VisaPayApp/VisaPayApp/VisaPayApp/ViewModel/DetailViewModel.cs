﻿using System;
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
        public Command ButtonReceber { get; set; }

        public DetailViewModel()
        {
            ButtonCartao = new Command(ExecuteAddCartao, CanExecute);
            ButtonReceber = new Command(ExecuteReceber, CanExecute);
        }

        public void ExecuteAddCartao()
        {
            App.NavigateMaster(new CartaoView());
        }

        public void ExecuteReceber()
        {
            App.NavigateMaster(new Receber());
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
