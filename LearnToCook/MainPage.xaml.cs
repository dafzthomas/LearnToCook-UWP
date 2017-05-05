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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace LearnToCook
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            //NavigationCacheMode = NavigationCacheMode.Enabled;
            HomeButton_Click(null,null);
        }

        public void CloseBurgerMenu ()
        {
            MySplitView.IsPaneOpen = false;
        }

        public void EnableNavigationButtons ()
        {
            HomeButton.IsEnabled = true;
            AboutButton.IsEnabled = true;
            KitchenManagementButton.IsEnabled = true;
            CookeryTermsButton.IsEnabled = true;
            BasicKitchenEquipmentButton.IsEnabled = true;
            RecipeButton.IsEnabled = true;
            MyFoodButton.IsEnabled = true;
            QuizButton.IsEnabled = true;
            EssentialTipsButton.IsEnabled = true;
        }

        private void HamburgerButton_Click(object sender, RoutedEventArgs e)
        {
            MySplitView.IsPaneOpen = !MySplitView.IsPaneOpen;
        }

        private void HomeButton_Click(object sender, RoutedEventArgs e)
        {
            EnableNavigationButtons();

            pageFrame.Navigate(typeof(Introduction));
            AppHeaderTitle.Text = "Home";
            HomeButton.IsEnabled = false;

            CloseBurgerMenu();
        }

        private void AboutButton_Click(object sender, RoutedEventArgs e)
        {
            EnableNavigationButtons();

            pageFrame.Navigate(typeof(About));
            AppHeaderTitle.Text = "About";
            AboutButton.IsEnabled = false;

            CloseBurgerMenu();  
        }

        private void QuizButton_Click(object sender, RoutedEventArgs e)
        {
            EnableNavigationButtons();

            pageFrame.Navigate(typeof(Quiz));
            AppHeaderTitle.Text = "Quiz";
            QuizButton.IsEnabled = false;

            CloseBurgerMenu();
        }

        private void KitchenManagementButton_Click(object sender, RoutedEventArgs e)
        {
            EnableNavigationButtons();

            pageFrame.Navigate(typeof(KitchenManagement));
            AppHeaderTitle.Text = "Kitchen";
            KitchenManagementButton.IsEnabled = false;

            CloseBurgerMenu();
        }

        private void CookeryTermsButton_Click(object sender, RoutedEventArgs e)
        {
            EnableNavigationButtons();

            pageFrame.Navigate(typeof(CookeryTerms));
            AppHeaderTitle.Text = "Cookery Terms";
            CookeryTermsButton.IsEnabled = false;

            CloseBurgerMenu();
        }

        private void BasicKitchenEquipmentButton_Click(object sender, RoutedEventArgs e)
        {
            EnableNavigationButtons();

            pageFrame.Navigate(typeof(BasicKitchenEquipment));
            AppHeaderTitle.Text = "Kitchen Equipment";
            BasicKitchenEquipmentButton.IsEnabled = false;

            CloseBurgerMenu();
        }

        private void MyFoodButton_Click(object sender, RoutedEventArgs e)
        {
            EnableNavigationButtons();

            pageFrame.Navigate(typeof(MyFood));
            AppHeaderTitle.Text = "My Food";
            MyFoodButton.IsEnabled = false;

            CloseBurgerMenu();
        }

        private void RecipeButton_Click(object sender, RoutedEventArgs e)
        {
            EnableNavigationButtons();

            pageFrame.Navigate(typeof(Recipes));
            AppHeaderTitle.Text = "Recipes";
            RecipeButton.IsEnabled = false;

            CloseBurgerMenu();
        }

        private void EssentialTipsButton_Click(object sender, RoutedEventArgs e)
        {
            EnableNavigationButtons();

            pageFrame.Navigate(typeof(EssentialTips));
            AppHeaderTitle.Text = "Essential Tips";
            EssentialTipsButton.IsEnabled = false;

            CloseBurgerMenu();
        }
    }
}
