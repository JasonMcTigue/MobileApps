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
using System.Windows.Threading;

namespace mobileApps
{
    public partial class GameplayPage : PhoneApplicationPage
    {
        IsolatedStorageSettings userSettings = IsolatedStorageSettings.ApplicationSettings; //Used to store usernames
        DispatcherTimer gameStartTimer = new DispatcherTimer();// Used for the countdown to start the game.

        bool gameStarted = false;// To check of the game is running or not
        string player = "";
        int countdownTime = 3;

        public GameplayPage()
        {
            InitializeComponent();

            player = userSettings["username"].ToString();

            gameStartTimer.Interval = new TimeSpan(0,0,0,1,0);
            gameStartTimer.Tick += new EventHandler(gameTimer_Tick);
        }

        private void gameTimer_Tick(object sender, EventArgs e) {
            if (countdownTime >= 0)
            {
                if (countdownTime == 0)
                {
                    txtCountdown.Text = "Begin";
                    countdownTime--;
                }
                else {
                    txtCountdown.Text = countdownTime.ToString() + "...";
                    countdownTime--;
                }
            }
            else {
                txtCountdown.Visibility = Visibility.Collapsed;
                gameStartTimer.Stop();
            }
        }

        private void hbtnTap_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            if (gameStarted == false)
            {
                gameStarted = true;
                gameStartTimer.Start();
            }
            else {
            }
        }
    }
}