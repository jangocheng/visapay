using VisaPayApp.Model;
using VisaPayApp.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace VisaPayApp.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Menu : ContentPage
	{
		public Menu ()
		{
			InitializeComponent ();
		    var menu = new MenuViewModel();
            BindingContext = menu;

		    this.ListView.ItemTapped += async (sender, e) =>
		    {
		        var _menu = e.Item as Model.Menus;
		        menu.Execute(_menu.Id);
		    };

		}
	}
}