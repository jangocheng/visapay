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
	public partial class Dispositivos : ContentPage
	{
		public Dispositivos ()
		{
			InitializeComponent ();
		    BindingContext = new DispositivosViewModel();
		}
	}
}