using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VisaPayApp.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace VisaPayApp.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Receber : ContentPage
	{
		public Receber ()
		{
			InitializeComponent ();
		    BindingContext = new ReceberViewModel();
		}


	    protected override void OnAppearing()
	    {
	        base.OnAppearing();

	        this.txtValor.Focus();

	    }
    }
}