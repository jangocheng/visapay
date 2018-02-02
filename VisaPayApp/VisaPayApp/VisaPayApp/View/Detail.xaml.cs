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
	public partial class Detail : ContentPage
	{
		public Detail ()
		{
			InitializeComponent ();
		    BindingContext = new DetailViewModel();
		}
	}
}