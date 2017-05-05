using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Data.Json;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace LearnToCook
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class CookeryTerms : Page
    {
        private JsonObject PageData;
        private List<CookeryTerm> PageCookeryTerms = new List<CookeryTerm>();

        public CookeryTerms()
        {
            this.InitializeComponent();
            GetPage();
        }

        private void GetPage()
        {
            PageData = App.CookeryTermsData;
            mainPageTitle.Text = PageData["PageTitle"].GetString();
            mainPageSubtitle.Text = PageData["Subtitle"].GetString();

            var array = PageData["CookeryTerms"].GetArray();

            foreach (var term in array)
            {
                JsonObject aTerm = term.GetObject();

                CookeryTerm cookeryTerm = new CookeryTerm
                {
                    Term = aTerm["Term"].GetString(),
                    Explanation = aTerm["Explanation"].GetString()
                };

                PageCookeryTerms.Add(cookeryTerm);
            }

        }
    }
}
