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
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace LearnToCook
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class SingleRecipe : Page
    {
        public SingleRecipe()
        {
            this.InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            txtTitle.Text = App.selectedRecipe.Title;
            txtText.Text = App.selectedRecipe.Text;
            txtServes.Text = App.selectedRecipe.Serves;
            txtPrepTime.Text = App.selectedRecipe.PrepTime;
            txtCookingTime.Text = App.selectedRecipe.CookingTime;
            txtIngredients.Text = App.selectedRecipe.Ingredients;
            txtMethod.Text = App.selectedRecipe.Method;
            imgMain.Source = new BitmapImage(new Uri(this.BaseUri, App.selectedRecipe.Image));
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            Frame.GoBack();
        }
    }
}
