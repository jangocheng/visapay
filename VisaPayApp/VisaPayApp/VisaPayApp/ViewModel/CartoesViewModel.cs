using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using VisaPayApp.Droid.Annotations;
using VisaPayApp.Model;

namespace VisaPayApp.ViewModel
{
    public class CartoesViewModel: INotifyPropertyChanged
    {
        public List<Cartao> ListCartao { get; set; }

        public CartoesViewModel()
        {
            Cartoes();
        }

        public void Cartoes()
        {
            ListCartao = new List<Cartao>();
            ListCartao.Add(new Cartao
            {
                Nome = "RODRIGO J P SILVA",
                Numero = "0000 0000 0000 0000",
                MesVencimento = 07,
                AnoVencimento = 2016

            });
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
