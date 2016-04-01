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
        IsolatedStorageSettings userSettings = IsolatedStorageSettings.ApplicationSettings;
       

        DispatcherTimer startTimer = new DispatcherTimer();// Used for the countdown to start the game.
        DispatcherTimer gamePlayTimer = new DispatcherTimer();// Used for the time in the game.

        bool gameStarted = false;// To check of the game is running or not
        string player = "";//Stores the players name
        int countdownTime = 3;//The amount of time it takes the game to start after the user has tapped the screen

        int totalGoblins = 0;//Counter for the amount of goblins the user has taped in the game
        int playTime = 45;//The time limlit of the game

        public GameplayPage()
        {
            InitializeComponent();

            player = userSettings["username"].ToString();//Takes in players name from isolated storage and stores in in player variable

            startTimer.Interval = new TimeSpan(0,0,0,1,0);//Sets a timer of one second
            startTimer.Tick += new EventHandler(gameTimer_Tick);//calls the gameTimer method

            gamePlayTimer.Interval = new TimeSpan(0, 0, 0, 1, 0);
            gamePlayTimer.Tick += new EventHandler(gamePlayTimer_Tick);
        }

        private void gameTimer_Tick(object sender, EventArgs e) {
            if (countdownTime >= 0)
            {
                if (countdownTime == 0)
                {
                    txtCountdown.Text = "Start Tapping";
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
                txtCountdown.Visibility = Visibility.Collapsed;//Makes the message disaper
                startTimer.Stop();
            }
        }


        private void gamePlayTimer_Tick(object sender, EventArgs e) {
            if (playTime == 0)
            {
                gamePlayTimer.Stop();//When the timer reaches 0 the game stops
                PlayingCanvas.Children.Clear();//the canvas is cleared
                populateResults();//and the populate results method is called
            }
            else {
                playTime--;//Other wise the timer keeps decreasing
                txtTime.Text = playTime.ToString();//COnverts the play time to a string so it can be displayed on the screen.

            }
        }

        private void hbtnTap_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            if (gameStarted == false)
            {
                gameStarted = true;//If the user taps the screen the game starts
                startTimer.Start();//Starts the timer
            }
            else {
                //Other wise nothing will happen
            }
        }

        private void spawnGoblin()
        {
            Image NewGoblin = new Image();//Creates a new image
            NewGoblin.Name = "goblin" + totalGoblins.ToString(); //gives the image a name of goblin so they are all unique
            NewGoblin.Source = new BitmapImage(new Uri("goblin.png" , UriKind.RelativeOrAbsolute));//finds where you have saved the image
            NewGoblin.Height = 60;
            NewGoblin.Width = 60;
            NewGoblin.Tap += NewGoblin_Tap;//associates a tap event with any new goblin that is made

            Random number = new Random();//creates the image at random locations between the coordinates
            int leftposition = number.Next(0,405);
            int rightposition = number.Next(0,646);

            Canvas.SetLeft(NewGoblin, leftposition);
            Canvas.SetTop(NewGoblin, rightposition);
             
            PlayingCanvas.Children.Add(NewGoblin);//adds a new goblin to the screen

        }



        private void NewGoblin_Tap(object sender, System.Windows.Input.GestureEventArgs e) {
            Image image = sender as Image;
            PlayingCanvas.Children.Remove(image);//removes the tapped goblin
            totalGoblins++;//adds it to a counter

            txtScore.Text = totalGoblins.ToString();//displays the score on the screen
            spawnGoblin();//then spawns anotehr goblin

        }

        private void populateResults() {
            txtResultTitle.Text = "Times Up " + player; //Displays the times up messgae and the players username
            txtResultMessage.Text = comment();// Calls a method to display a message depending on what the user has scored on the game.
            txtScoreTotal.Text = totalGoblins.ToString();//Displays the total amount of points the player got in the game.

            resultsGrid.Visibility = Visibility.Visible; //Makes the result screen appear on the screen when the timer has ended
        }

        private string comment() {
            string resultComment = "";

            //A series of messages that is displayed to the user givin what score they achieved in the game
            if (totalGoblins >= 0 && totalGoblins <= 20) {
                resultComment = "Poor attempt you could do better";
            }

            else if (totalGoblins >= 20 && totalGoblins <= 40)
            {
                resultComment = "Not a bad attempt but you could do better";
            }

            else if (totalGoblins >= 40 && totalGoblins <= 60)
            {
                resultComment = "Good job, your getting good!";
            }

            else if (totalGoblins >= 60)
            {
                resultComment = "Your a pro";
            }

           // setLocalScore();
            return resultComment;

        }

        private void btnSkip_Click(object sender, RoutedEventArgs e)
        {
            setHighScore(); // calls the method for setting the users high score.
            NavigationService.GoBack();//brings the user back a page
        }

        //Method for setting the high score using isolated storage 
        private void setHighScore() {

            if (userSettings.Contains("highscore")) {
                int highscore = Int32.Parse(userSettings["highscore"].ToString());//varibale for storing the highscore so it can be displayed on the screen

                if (highscore < totalGoblins)
                {
                    userSettings.Remove("highscore");// if the same high score is already in the game it is removed...
                    userSettings.Add("highscore", totalGoblins.ToString());//and then added again
                }
                
            }
            //If its the users first time playing the game 
            else {
                userSettings.Add("highscore", totalGoblins.ToString());
            }

        }

        private void btnUpload_Click(object sender, RoutedEventArgs e)
        {
           
        }
    }

    
}