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
        char curCh = 'X';
        Button btn, mangValik;
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

        private void Btn_Clicked(object sender, EventArgs e)
        {
            Button baton = (Button)sender;
            
        }
    }
}
