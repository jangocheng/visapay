using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using VisaPayApp.Droid.Annotations;
using VisaPayApp.Droid.Services.Repositories;
using VisaPayApp.Model;
using VisaPayApp.Services.Repositories;
using VisaPayApp.View;
using Xamarin.Forms;

namespace VisaPayApp.ViewModel
{
    public class CadastroViewModel: INotifyPropertyChanged
    {
        public Command Cadastrar { get; set; }
        public Pessoa _pessoa { get; set; }
        public Pessoa pessoa
        {
            get { return _pessoa; }
            set
            {
                _pessoa = value;
                OnPropertyChanged();
            }
        }

        public PessoaRepository _conexao { get; set; }
        public CadastroViewModel()
        {
            Cadastrar = new Command(Execute, CanExecute);
            _conexao = new PessoaRepository();
            pessoa = new Pessoa();
        }
        public bool CanExecute()
        {
            return true;
        }
        public void Execute()
        {
            if (ValidaCampo())
            {
                _conexao.add(pessoa);
                App.Current.MainPage.DisplayAlert("Message", "Caadastrado com sucesso", "OK");
                App.Current.MainPage = new MasterDetail();
            }
            else
            {
                App.Current.MainPage.DisplayAlert("Atenção", "Campos Obrigatórios não preenchido", "Entendi");
            }
        }

        private bool ValidaCampo()
        {
            if (String.IsNullOrEmpty(pessoa.Nome) || String.IsNullOrEmpty(pessoa.Email) || String.IsNullOrEmpty(pessoa.Senha))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
