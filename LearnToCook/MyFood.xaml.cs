using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Media.Capture;
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
    public sealed partial class MyFood : Page
    {
        public MyFood()
        {
            this.InitializeComponent();
            GetCurrentFolderItems();
        }

        private async void GetCurrentFolderItems()
        {
            StorageFolder appFolder =  KnownFolders.CameraRoll;
            
            IReadOnlyList<StorageFile> filesInFolder = await appFolder.GetFilesAsync();
            
            foreach (StorageFile file in filesInFolder)
            {

                if (file.Name.Contains("food"))
                {
                    displayImage(file, gallery);
                }
            }
        }

        private async void takePictureButton_Click(object sender, RoutedEventArgs e)
        {
            CameraCaptureUI captureUI = new CameraCaptureUI();
            captureUI.PhotoSettings.Format = CameraCaptureUIPhotoFormat.Jpeg;
            
            StorageFile photo = await captureUI.CaptureFileAsync(CameraCaptureUIMode.Photo);

            if (photo != null)
            {
                await photo.CopyAsync(KnownFolders.CameraRoll, "food-picture.jpg", NameCollisionOption.GenerateUniqueName);
                displayImage(photo, gallery);
            }

        }

        private static async void displayImage(StorageFile myFile, VariableSizedWrapGrid gallery)
        {
            BitmapImage img = new BitmapImage();
            Image myImage = new Image();

            img.SetSource(await myFile.OpenAsync(FileAccessMode.Read));
            
            myImage.Stretch = Stretch.UniformToFill;
            myImage.Source = img;
            myImage.Margin = new Thickness(5);
            gallery.Children.Add(myImage);
        }

        private void gallery_Tapped(object sender, TappedRoutedEventArgs e)
        {
            Frame.Navigate(typeof(SingleImage), gallery.Children.ToArray());
        }
    }
}
