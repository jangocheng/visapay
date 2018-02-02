using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using VisaPayApp.Model;
using VisaPayApp.View;
using Xamarin.Forms;
using PropertyChangingEventHandler = System.ComponentModel.PropertyChangingEventHandler;

namespace VisaPayApp.ViewModel
{
    public class MenuViewModel: INotifyPropertyChanging
    {
        public List<Menus> ListMenu { get; set; }
        public Command ButtonMenu { get; set; }


        public MenuViewModel()
        {
            CarregaMenu();
        }
        public void Execute(int menu)
        {
            switch (menu)
            {
                case 1:
                    App.NavigateMaster(new Cartoes());
                break;
            }
        }

        private void CarregaMenu()
        {
            ListMenu = new List<Menus>();
            ListMenu.Add(new Menus { Nome = "Cartões", Id = 1});
            ListMenu.Add(new Menus { Nome = "Adicionar Creditos", Id = 2 });
            ListMenu.Add(new Menus { Nome = "Dispositivos", Id = 3 });
        }

        public bool CanExecute()
        {
            return true;
        }
        public event PropertyChangingEventHandler PropertyChanging;
    }
}
