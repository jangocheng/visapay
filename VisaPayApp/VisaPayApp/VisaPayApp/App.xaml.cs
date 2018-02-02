using System.Threading.Tasks;
using VisaPayApp.View;
using Xamarin.Forms;

namespace VisaPayApp
{
    public partial class App : Application
	{
	    public static MasterDetailPage MasterDetail { get; set; }

	    public async static Task NavigateMaster(Page page)
	    {
	        App.MasterDetail.IsPresented = false;
	        await App.MasterDetail.Detail.Navigation.PushAsync(page);
	    }
        public App ()
		{
			InitializeComponent();

			MainPage = new Login();
		}

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
