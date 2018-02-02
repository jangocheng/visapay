using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace VisaPayApp.View
{
	public class MasterDetail : MasterDetailPage
	{
		public MasterDetail ()
		{
		    var navigation = new NavigationPage(new Detail());
		    navigation.BarBackgroundColor = Color.FromHex("#432ee7");
            navigation.ToolbarItems.Add(new ToolbarItem
            {
                Icon = "icon.png"
            });
            
            Detail = navigation;
            Master = new Menu();
		    App.MasterDetail = this;
		}


	}
}