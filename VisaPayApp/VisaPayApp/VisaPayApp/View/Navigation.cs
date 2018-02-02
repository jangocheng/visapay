using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace VisaPayApp.View
{
    public class Navigation: NavigationPage
    {
        public Navigation()
        {
            BarBackgroundColor = Color.FromHex("#fff");
        }

        public Navigation(Page root):base(root)
        {
            BarBackgroundColor = Color.FromHex("#fff");
        }
    }
}
