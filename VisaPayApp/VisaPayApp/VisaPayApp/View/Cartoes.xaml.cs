using VisaPayApp.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace VisaPayApp.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Cartoes : ContentPage
	{
		public Cartoes ()
		{
			InitializeComponent ();
		    BindingContext = new CartoesViewModel();
		}
	}
}