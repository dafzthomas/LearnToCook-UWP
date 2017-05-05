using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
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
    public sealed partial class Recipes : Page
    {
        private RecipeInfoPage PageData;

        public Recipes()
        {
            this.InitializeComponent();
            GetPage();
        }

        private void GetPage()
        {
            PageData = App.RecipePageData;
            mainPageTitle.Text = PageData.PageTitle;
            mainPageSubtitle.Text = PageData.Subtitle;
            
        }

        private void GridView_ItemClick(object sender, ItemClickEventArgs e)
        {
            App.selectedRecipe = (Recipe)e.ClickedItem;
            Frame.Navigate(typeof(SingleRecipe));
        }
    }
}
