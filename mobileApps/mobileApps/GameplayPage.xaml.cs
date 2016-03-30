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
using System.Windows.Media.Imaging;

namespace mobileApps
{
    public partial class GameplayPage : PhoneApplicationPage
    {
        IsolatedStorageSettings userSettings = IsolatedStorageSettings.ApplicationSettings; //Used to store usernames

        DispatcherTimer startTimer = new DispatcherTimer();// Used for the countdown to start the game.
        DispatcherTimer gamePlayTimer = new DispatcherTimer();// Used for the time in the game.

        bool gameStarted = false;// To check of the game is running or not
        string player = "";
        int countdownTime = 3;

        int totalGoblins = 0;
        int playTime = 15;//The time limlit of the game

        public GameplayPage()
        {
            InitializeComponent();

            player = userSettings["username"].ToString();

            startTimer.Interval = new TimeSpan(0,0,0,1,0);
            startTimer.Tick += new EventHandler(gameTimer_Tick);

            gamePlayTimer.Interval = new TimeSpan(0, 0, 0, 1, 0);
            gamePlayTimer.Tick += new EventHandler(gamePlayTimer_Tick);
        }

        private void gameTimer_Tick(object sender, EventArgs e) {
            if (countdownTime >= 0)
            {
                if (countdownTime == 0)
                {
                    txtCountdown.Text = "Begin";
                    countdownTime--;

                    txtTime.Text = playTime.ToString();//Sets the textbox on the canvas to the time limit
                    gamePlayTimer.Start();//Starts the game play timer.
                    spawnGoblin();//Spawns goblins on the screen
                }  
                else {
                    txtCountdown.Text = countdownTime.ToString() + "...";
                    countdownTime--;
                }
            }
            else {
                txtCountdown.Visibility = Visibility.Collapsed;
                startTimer.Stop();
            }
        }


        private void gamePlayTimer_Tick(object sender, EventArgs e) {
            if (playTime == 0)
            {
                gamePlayTimer.Stop();
                PlayingCanvas.Children.Clear();
            }
            else {
                playTime--;
                txtTime.Text = playTime.ToString();

            }
        }


        private void hbtnTap_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            if (gameStarted == false)
            {
                gameStarted = true;
                startTimer.Start();
            }
            else {
            }
        }

        private void spawnGoblin()
        {
            Image NewGoblin = new Image();
            NewGoblin.Name = "goblin" + totalGoblins.ToString();
            NewGoblin.Source = new BitmapImage(new Uri("goblin.png" , UriKind.RelativeOrAbsolute));
            NewGoblin.Height = 60;
            NewGoblin.Width = 60;
            NewGoblin.Tap += NewGoblin_Tap;

            Random number = new Random();
            int leftposition = number.Next(0,405);
            int rightposition = number.Next(0,646);

            Canvas.SetLeft(NewGoblin, leftposition);
            Canvas.SetTop(NewGoblin, rightposition);
             
            PlayingCanvas.Children.Add(NewGoblin);

        }

        private void NewGoblin_Tap(object sender, System.Windows.Input.GestureEventArgs e) {
            Image image = sender as Image;
            PlayingCanvas.Children.Remove(image);
            totalGoblins++;

            txtScore.Text = totalGoblins.ToString();
            spawnGoblin();

        }

    }

    
}