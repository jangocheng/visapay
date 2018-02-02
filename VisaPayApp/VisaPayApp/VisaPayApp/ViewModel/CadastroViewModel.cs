using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Text;
using VisaPayApp.View;
using Xamarin.Forms;

namespace VisaPayApp.ViewModel
{
    public class CadastroViewModel: INotifyCollectionChanged
    {
        public Command Cadastrar { get; set; }

        public CadastroViewModel()
        {
            Cadastrar = new Command(Execute, CanExecute);
        }
        public bool CanExecute()
        {
            return true;
        }
        public void Execute()
        {
           App.Current.MainPage = new MasterDetail(); 
        }

        public event NotifyCollectionChangedEventHandler CollectionChanged;
    }
}
