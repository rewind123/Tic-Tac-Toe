
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Tic_Tac_Toe
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region Private Members

        /// <summary>
        /// current game cell configurations
        /// </summary>
        private MarkType[] results;


        /// <summary
        /// true if player 1's turn or false if player 2's turn
        /// </summary>
        private bool player1Turn;

        private bool gameEnd;
        #endregion

        #region Constructor
        /// <summary>
        /// Default constructor
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();

            NewGame();
        }

        private void NewGame()
        {
            
            //new game of 3x3 cells
            results = new MarkType[9];

            for(var i = 0; i < results.Length; i++)
            {
                results[i] = MarkType.Free;
            }

            player1Turn = true;

            // use linq and lambda expression to iterate each button on the grid

            Container.Children.Cast<Button>().ToList().ForEach(button =>
            {
                button.Content = string.Empty;
                button.Background = Brushes.White;
                button.Foreground = Brushes.Blue;
            });

            gameEnd = false;
        }
        /// <summary>
        /// handles button clicks
        /// </summary>
        /// <param name="sender">the button that was clicked</param>
        /// <param name="e">the events of the click</param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (gameEnd)
            {
                NewGame();
                return;
            }

            //cast sender to a button
            var button = (Button)sender;

            //finds buttons in the array
            var column = Grid.GetColumn(button);
            var row = Grid.GetRow(button);

            var index = column + (row * 3);

            if (results[index] != MarkType.Free)
                return;

            //set results based on player turn
            results[index] = player1Turn ? MarkType.Cross : MarkType.Zero;

            button.Content = player1Turn ? "X" : "O";

            //change 0 to green

            if(!player1Turn)
            {
                button.Foreground = Brushes.Red;
            }

            //bitwise operator to toggle player turn
            player1Turn ^= true;

            //check win condition
            CheckWin();
        }

        /// <summary>
        /// check winner of tic tac toe -> 3 objects in a line/diagonal
        /// </summary>
        private void CheckWin()
        {
            #region horizontal wins
            //checks first row values
            var row0 = (results[0] & results[1] & results[2]) == results[0];

            if(results[0] != MarkType.Free && row0)
            {
                gameEnd = true;

                //highlight winnig cells
                Button0_0.Background = Button1_0.Background = Button2_0.Background = Brushes.Green;
            }

            //check row 2 values
            var row1 = (results[3] & results[4] & results[5]) == results[3];

            if (results[3] != MarkType.Free && row1)
            {
                gameEnd = true;

                //highlight winnig cells
                Button0_1.Background = Button1_1.Background = Button2_1.Background = Brushes.Green;
            }

            //check row 3 values
            var row2 = (results[6] & results[7] & results[8]) == results[6];

            if (results[6] != MarkType.Free && row2)
            {
                gameEnd = true;

                //highlight winnig cells
                Button0_2.Background = Button1_2.Background = Button2_2.Background = Brushes.Green;
            }

            #endregion

            #region vertical wins
            //check for column wins
            //column 1

            var column0 = (results[0] & results[3] & results[6]) == results[0];

            if (results[0] != MarkType.Free && column0)
            {
                gameEnd = true;

                //highlight winnig cells
                Button0_0.Background = Button0_1.Background = Button0_2.Background = Brushes.Green;
            }

            //column 2

            var column1 = (results[1] & results[4] & results[7]) == results[1];

            if (results[1] != MarkType.Free && column1)
            {
                gameEnd = true;

                //highlight winnig cells
                Button1_0.Background = Button1_1.Background = Button1_2.Background = Brushes.Green;
            }

            //column 3

            var column2 = (results[2] & results[5] & results[8]) == results[2];

            if (results[2] != MarkType.Free && column2)
            {
                gameEnd = true;

                //highlight winnig cells
                Button2_0.Background = Button2_1.Background = Button2_2.Background = Brushes.Green;
            }
            #endregion

            #region diagonal win
            //check for diagonal wins

            //top left to bottom right
            var diagonal0 = (results[0] & results[4] & results[8]) == results[0];

            if (results[0] != MarkType.Free && diagonal0)
            {
                gameEnd = true;

                //highlight winnig cells
                Button0_0.Background = Button1_1.Background = Button2_2.Background = Brushes.Green;
            }

            //top right to bottom left
            var diagonal1 = (results[2] & results[4] & results[6]) == results[2];

            if (results[2] != MarkType.Free && diagonal1)
            {
                gameEnd = true;

                //highlight winnig cells
                Button0_2.Background = Button1_1.Background = Button2_0.Background = Brushes.Green;
            }

            #endregion

            //end game if no result is achieved
            if (!results.Any(block => block == MarkType.Free))
            {
                //end game if no result is achieved
                gameEnd = true;

                Container.Children.Cast<Button>().ToList().ForEach(button =>
                {
                    button.Background = Brushes.Orange;
                });
            }

        }
    }
}
#endregion