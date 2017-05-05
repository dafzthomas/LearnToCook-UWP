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
    public sealed partial class Quiz : Page
    {
        private JsonObject PageData;
         
        public Quiz()
        {
            this.InitializeComponent();
            GetPage();
        }

        private async void GetPage()
        {
            PageData = await ContentManager.GetQuizJSON();

            mainPageTitle.Text = PageData["PageTitle"].GetString();
            mainPageSubtitle.Text = PageData["Subtitle"].GetString();
            startButton.Content = PageData["ButtonText"].GetString();
        }

        private void startButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(QuizQuestion), PageData["Questions"].GetArray());
        }
    }
}
