using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Data.Json;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
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
    public sealed partial class Introduction : Page
    {
        public Introduction()
        {
            this.InitializeComponent();
            GetPageData();
        }

        public async void GetPageData()
        {
            // URI for JSON
            var uri = "ms-appx:///Assets/Pages/Introduction.json";
            var pageUri = new Uri(uri);

            // get the file
            var pageFile = await StorageFile.GetFileFromApplicationUriAsync(pageUri);

            // read the contents
            var pageJSON = await FileIO.ReadTextAsync(pageFile);

            var pageObject = JsonObject.Parse(pageJSON).GetObject();

            mainPageTitle.Text = pageObject["PageTitle"].GetString();
            mainPageSubtitle.Text = pageObject["Subtitle"].GetString();
            mainPageText.Text = pageObject["Text"].GetString();
            mainPageImage.Source = new BitmapImage(new Uri(this.BaseUri, pageObject["MainImage"].GetString()));


        }
    }
}
