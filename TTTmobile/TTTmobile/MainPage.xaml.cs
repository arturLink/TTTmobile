using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace TTTmobile
{
    public partial class MainPage : ContentPage
    {
        string curCh = "X";
        Button btn, mangValik, buttons;
        public MainPage()
        {
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
            bool win = checkWinner();
            if (win == true)
            {
                await DisplayAlert("Alert", "You have been alerted", "OK");
            }
        }
        private bool checkWinner()
        {
            // check rows
            if (btn.TabIndex == 1 && btn.TabIndex == 2 && btn.TabIndex == 3) { return true; }
            if (btn.TabIndex == 4 && btn.TabIndex == 5 && btn.TabIndex == 6) { return true; }
            if (btn.TabIndex == 7 && btn.TabIndex == 8 && btn.TabIndex == 9) { return true; }

            // check columns
            if (btn.TabIndex == 1 && btn.TabIndex == 4 && btn.TabIndex == 7) { return true; }
            if (btn.TabIndex == 2 && btn.TabIndex == 5 && btn.TabIndex == 8) { return true; }
            if (btn.TabIndex == 3 && btn.TabIndex == 6 && btn.TabIndex == 9) { return true; }

            // check diags
            if (btn.TabIndex == 1 && btn.TabIndex == 5 && btn.TabIndex == 9) { return true; }
            if (btn.TabIndex == 3 && btn.TabIndex == 5 && btn.TabIndex == 7) { return true; }

            return false;
        }
    }
}
