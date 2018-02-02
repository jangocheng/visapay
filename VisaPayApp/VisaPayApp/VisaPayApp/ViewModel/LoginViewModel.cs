using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using VisaPayApp.View;
using Xamarin.Forms;
using PropertyChangingEventHandler = System.ComponentModel.PropertyChangingEventHandler;

namespace VisaPayApp.ViewModel
{
    public class LoginViewModel: INotifyPropertyChanging
    {
        public Command Logar { get; set; }
        public Command Cadastrar { get; set; }

        public LoginViewModel()
        {
            Logar = new Command(Execute, CanExecute);
            Cadastrar = new Command(ExecuteCadastro, CanExecute);
        }
        public void Execute()
        {
            ExecuteLogin();
        }
        public void ExecuteCadastro()
        {
            App.Current.MainPage = new Cadastro();
        }

        public void ExecuteLogin()
        {
            // App.Current.MainPage = new NavigationPage(new MasterDetail());
            App.Current.MainPage = new MasterDetail();
        }

        public bool CanExecute()
        {
            return true;
        }
        public event PropertyChangingEventHandler PropertyChanging;
    }
}
