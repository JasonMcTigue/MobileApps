using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using mobileApps.Resources;
using System.IO.IsolatedStorage;


namespace mobileApps
{
    public partial class MainPage : PhoneApplicationPage
    {
        IsolatedStorageSettings userSettings = IsolatedStorageSettings.ApplicationSettings; //Used to store usernames
         
        // Constructor
        public MainPage()
        {
            InitializeComponent();

            // Sample code to localize the ApplicationBar
            //BuildLocalizedApplicationBar();
        }


        private void userNameBox_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            if (userNameBox.Text == "Enter a username") {
                userNameBox.Text = "";
            }
        }

        private void btn_PlayGame_Click(object sender, RoutedEventArgs e)
        {
            bool isValidName = checkUserName(userNameBox.Text); 

            if (isValidName == true) {
                if (userSettings.Contains("username"))
                {
                    userSettings.Remove("username"); //Checks to see if the username has already been added and if it has it is removed 
                    userSettings.Add("username", userNameBox.Text);//and added again.
                }
                else {
                    userSettings.Add("username", userNameBox.Text);//if the username hasnt been added before it adds it here
                }

                NavigationService.Navigate(new Uri("/GameplayPage.xaml", UriKind.Relative)); //Navigates to the gameplay page when a valid username is entered 
            }
            else{
                MessageBox.Show("Username must be between three and ten characters and have at least one letter");
            }

        }

        //Checks to see if the username entered is a valid one eg not blank
        private bool checkUserName(string username) {
            bool result = false; // if condition is returned false the isValidName if statement returns false

            //Checks the username to see if its a letter or a digit and that the username has at least on letter and that the text isnt equal to Enter a username. 
            //Also stops the user from pressing play straigh away.
            //Added extra condition where the username length must be greater than 2 and equal to or less that 10.
            if (username.All(char.IsLetterOrDigit) && username.Any(char.IsLetter) && ((username.Length > 2) && (username.Length <=10) ) && !(username == "Enter a username")) result = true;

            return result;

        }

        private void btn_highscore_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/highScorePage.xaml", UriKind.Relative));
        }



        // Sample code for building a localized ApplicationBar
        //private void BuildLocalizedApplicationBar()
        //{
        //    // Set the page's ApplicationBar to a new instance of ApplicationBar.
        //    ApplicationBar = new ApplicationBar();

        //    // Create a new button and set the text value to the localized string from AppResources.
        //    ApplicationBarIconButton appBarButton = new ApplicationBarIconButton(new Uri("/Assets/AppBar/appbar.add.rest.png", UriKind.Relative));
        //    appBarButton.Text = AppResources.AppBarButtonText;
        //    ApplicationBar.Buttons.Add(appBarButton);

        //    // Create a new menu item with the localized string from AppResources.
        //    ApplicationBarMenuItem appBarMenuItem = new ApplicationBarMenuItem(AppResources.AppBarMenuItemText);
        //    ApplicationBar.MenuItems.Add(appBarMenuItem);
        //}
    }
}