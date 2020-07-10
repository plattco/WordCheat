using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Xamarin.Forms;


namespace WordCheatFinal
{
    class MainPage : ContentPage
    {
        public EnglishWords EnglishDictionary = new EnglishWords("words.txt");
        Entry Letters;
        Entry Count;
        Button Clear;
        Button Find;
        CheckBox Dup;
        Label DupLabel;
        Label Display;

        public MainPage()
        {
            Letters = new Entry { Text = "Enter letters" };
            Clear = new Button();
            Clear.HeightRequest = 75;
            Clear.WidthRequest = 190;
            Clear.Text = "CLEAR";
            Clear.FontSize = 40;
            Clear.TextColor = Color.Black;
            Find = new Button();
            Find.HeightRequest = 75;
            Find.WidthRequest = 190;
            Find.Text = "FIND";
            Find.FontSize = 40;
            Find.TextColor = Color.Black;
            Dup = new CheckBox();
            DupLabel = new Label();
            DupLabel.Text = "Duplicate Letters?";
            DupLabel.FontSize = 18;
            //         Dup.Text = "Duplicate Letters?"
            Count = new Entry { Text = "Length" };
            Display = new Label();
            Display.Text = "Results";
            Display.HorizontalTextAlignment = Xamarin.Forms.TextAlignment.Center;

            StackLayout panel = new StackLayout();
            StackLayout panel2 = new StackLayout();
            StackLayout innerPanel = new StackLayout();
            ScrollView scrolly = new ScrollView();

            panel.Children.Add(Letters);
            //panel.Children.Add(Clear);
            //panel.Children.Add(Find);
            panel.Children.Add(panel2);
            panel.Children.Add(innerPanel);
            // panel.Children.Add(Dup);
            panel.Children.Add(Count);
            scrolly.Content = Display;
            panel.Children.Add(scrolly);
            //panel.Children.Add(Display);
            panel.Spacing = 10;
            panel.Padding = new Thickness(10, 20, 10, 10);
            panel2.Children.Add(Clear);
            panel2.Children.Add(Find);
            panel2.Spacing = 10;
            panel2.Orientation = StackOrientation.Horizontal;
            innerPanel.Orientation = StackOrientation.Horizontal;
            innerPanel.Children.Add(DupLabel);
            innerPanel.Children.Add(Dup);
            

          /*  StackLayout panel2 = new StackLayout();
            panel2.HorizontalOptions = LayoutOptions.Center;
            panel2.Orientation = StackOrientation.Horizontal;
            panel2.Children.Add(Clear);
            panel2.Children.Add(Find);
            panel2.Spacing = 20;
            panel2.Padding = new Thickness(10, 10, 10, 10);

            */

            this.Content = panel;
            //this.Content = panel2;
            

            Find.Clicked += OnClick;
            Clear.Clicked += Clear_Clicked;
        }

        private void Clear_Clicked(object sender, EventArgs e)
        {
            Display.Text = "Results";
        }

        private void OnClick(object sender, EventArgs e)
        {
            int temp = int.Parse(Count.Text);
            
            List<string> possibleWords = EnglishDictionary.AvailableWords(Letters.Text.ToUpper(), temp, Dup.IsChecked);
            string resulty = String.Join("\r\n", possibleWords);//possibleWords.ToString();
            Display.Text = resulty;
            }

       
        }
    }
