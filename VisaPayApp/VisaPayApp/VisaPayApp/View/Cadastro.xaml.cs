
using VisaPayApp.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace VisaPayApp.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Cadastro : ContentPage
	{
		public Cadastro ()
		{
			InitializeComponent ();
		    BindingContext = new CadastroViewModel();
		}
	}
}