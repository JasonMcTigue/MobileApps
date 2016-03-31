using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.IO.IsolatedStorage;

namespace mobileApps
{
    public partial class highScorePage : PhoneApplicationPage
    {
        IsolatedStorageSettings userSettings = IsolatedStorageSettings.ApplicationSettings;
        public highScorePage()
        {
            InitializeComponent();

            if (userSettings.Contains("highscore"))
            {
                highScoreText.Text = "High Score " + userSettings["highscore"].ToString();
            }
            else {
                highScoreText.Text = "You havent played a game yet";
            }
        }
    }
}