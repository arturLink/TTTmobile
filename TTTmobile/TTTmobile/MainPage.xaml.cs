using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;

namespace TTTmobile
{
    public partial class MainPage : ContentPage
    {
        Xamarin.Forms.Button btn, mangValik, buttons;
        Grid TripsTrapsTrull;

        private string[,] board = new string[3, 3];
        string curCh = "X";
        public MainPage()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    board[i, j] = "-";
                }
            }

            TripsTrapsTrull = new Grid
            {
                ColumnSpacing = 3,
                RowSpacing = 3,
                BackgroundColor = Color.Gray,
                VerticalOptions = LayoutOptions.CenterAndExpand,

                RowDefinitions =
                {
                new RowDefinition { Height = new GridLength(1, GridUnitType.Star) },
                new RowDefinition { Height = new GridLength(1, GridUnitType.Star) },
                new RowDefinition { Height = new GridLength(1, GridUnitType.Star) }
            },
                ColumnDefinitions =
            {
                new ColumnDefinition {Width=new GridLength(1, GridUnitType.Star)},
                new ColumnDefinition {Width=new GridLength(1, GridUnitType.Star)},
                new ColumnDefinition {Width=new GridLength(1, GridUnitType.Star)},
            }
            };
            int a = 0;
            int b = 0;
            for (int i = 0; i < 9; i++)
            {
                btn = new Xamarin.Forms.Button()
                {
                    Text = "",
                    BackgroundColor = Color.Blue,
                    TabIndex = i,
                };
                btn.Clicked += Btn_Clicked;
                TripsTrapsTrull.Children.Add(btn, b, a);
                b++;
                if (b == 3)
                {
                    a++;
                    b = 0;
                }
            }
            Content = TripsTrapsTrull;

            mangValik = new Xamarin.Forms.Button()
            {
                Text = "(X) või O",
                BackgroundColor = Color.Gray,
            };
            mangValik.Clicked += MangValik_Clicked; ;
        }

        private void MangValik_Clicked(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private async void Btn_Clicked(object sender, EventArgs e)
        {
            Xamarin.Forms.Button baton = (Xamarin.Forms.Button)sender;

            int row = Grid.GetRow(baton);
            int col = Grid.GetColumn(baton);

            if (board[row, col] != "-")
            {
                return;
            }

            board[row, col] = curCh;
            baton.Text = curCh;

            string winner = CheckWinner(board);


            if (winner != "-")
            {
                // We have a winner!
                await DisplayAlert("Winner", "Player " + winner + " wins!", "OK");

                //for (int rowC = 0; rowC < 3; rowC++)
                //{
                //    for (int column = 0; column < 3; column++)
                //    {
                //        board[row, column] = " ";
                //        Xamarin.Forms.Button button = (Xamarin.Forms.Button)board.Children
                //            .First(b => Grid.GetRow(b) == row && Grid.GetColumn(b) == column);
                //        button.Text = "";
                //        button.IsEnabled = true;
                //    }
                //}


                //// Reset the game board
                //int rowRes = 0;
                //int colRes = 0;
                //for (int i = 0; i < 9; i++)
                //{
                //    Xamarin.Forms.Button button = GetButton(rowRes, colRes); // Get the button at the specified row and column
                //    button.Text = ""; // Clear the text of the button
                //    button.IsEnabled = true; // Enable the button
                //    //button.Clicked += Btn_Clicked;
                //    rowRes++;
                //    if (rowRes == 3)
                //    {
                //        colRes++;
                //        rowRes = 0;
                //    }
                //}
            }
            else
            {
                // Switch players
                if (curCh == "X")
                {
                    curCh = "O";
                }
                else if (curCh == "O")
                {
                    curCh = "X";
                }
                //curCh = curCh == "X" ? "O" : "X";
            }
        }
        private string CheckWinner(string[,] board)
        {
            //row
            for (int i = 0; i < 3; i++)
            {
                if (board[i, 0] != "-" && board[i, 0] == board[i, 1] && board[i, 1] == board[i, 2])
                {
                    return board[i, 0];
                }
            }

            //col
            for (int i = 0; i < 3; i++)
            {
                if (board[0, i] != "-" && board[0, i] == board[1, i] && board[1, i] == board[2, i])
                {
                    return board[0, i];
                }
            }

            //diag
            if (board[0, 0] != "-" && board[0, 0] == board[1, 1] && board[1, 1] == board[2, 2])
            {
                return board[0, 0];
            }
            if (board[0, 2] != "-" && board[0, 2] == board[1, 1] && board[1, 1] == board[2, 0])
            {
                return board[0, 2];
            }

            //draw
            return "-";
        }

        private Xamarin.Forms.Button GetButton(int row, int col)
        {
            foreach (var child in TripsTrapsTrull.Children)
            {
                if (Grid.GetRow(child) == row && Grid.GetColumn(child) == col && child is Xamarin.Forms.Button button)
                {
                    return button;
                }
            }
            return null;
        }
    }
}
