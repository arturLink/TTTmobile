using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;

namespace TTTmobile
{
    public partial class MainPage : ContentPage
    {
        Button btn, mangValik, buttons;

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

            Grid TripsTrapsTrull = new Grid
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
                btn = new Button()
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

            mangValik = new Button()
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
        bool win = true;

        private async void Btn_Clicked(object sender, EventArgs e)
        {
            Button baton = (Button)sender;

            int row = Grid.GetRow(baton);
            int col = Grid.GetColumn(baton);

            if (curCh == "X")
            {
                baton.Text = curCh;
                curCh = "O";
            }
            else if (curCh == "O")
            {
                baton.Text = curCh;
                curCh = "X";
            }

            if (board[row, col] != "-")
            {
                return;
            }

            // Update the board and the button text
            board[row, col] = curCh;
            baton.Text = curCh;

            // Check for a winner
            string winner = CheckWinner(board);

        }
        private string CheckWinner(string[,] board)
        {
            // Check rows
            for (int i = 0; i < 3; i++)
            {
                if (board[i, 0] != "-" && board[i, 0] == board[i, 1] && board[i, 1] == board[i, 2])
                {
                    return board[i, 0];
                }
            }

            // Check columns
            for (int i = 0; i < 3; i++)
            {
                if (board[0, i] != "-" && board[0, i] == board[1, i] && board[1, i] == board[2, i])
                {
                    return board[0, i];
                }
            }

            // Check diagonals
            if (board[0, 0] != "-" && board[0, 0] == board[1, 1] && board[1, 1] == board[2, 2])
            {
                return board[0, 0];
            }
            if (board[0, 2] != "-" && board[0, 2] == board[1, 1] && board[1, 1] == board[2, 0])
            {
                return board[0, 2];
            }

            // No winner
            return "-";
        }
    }
}
