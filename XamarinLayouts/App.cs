using System;
using Xamarin.Forms;
using System.Reflection;
using System.Linq;

namespace XamarinLayouts
{
	public class App
	{
		public static Page GetMainPage ()
		{	
			return new MainPage ();
		}
	}

	public class MainPage : ContentPage
	{
		public MainPage()
		{
			Grid grid = new Grid (){
				Padding = new Thickness(
					20,
					Device.OnPlatform(40, 20, 20),
					20,
					20
				),
				RowSpacing = 10
			};

			grid.RowDefinitions.Add (new RowDefinition() {
				Height = new GridLength(1, GridUnitType.Auto)
			});
			grid.RowDefinitions.Add (new RowDefinition() {
				Height = new GridLength(1, GridUnitType.Star)
			});

			grid.ColumnDefinitions.Add (new ColumnDefinition() {
				Width = new GridLength(1, GridUnitType.Star)
			});

			StackLayout entryBar = new StackLayout () {
				Orientation = StackOrientation.Horizontal,
				Spacing = 20
			};

			var entry = new Entry () {
				Placeholder = "Enter a URL"
			};
			entryBar.Children.Add (entry);


			var button = new Button () { 
				Text = "Go"
			};
			entryBar.Children.Add (button);

			Grid.SetRow (entryBar, 0);
			grid.Children.Add (entryBar);

			var webView = new WebView () {
				HorizontalOptions = LayoutOptions.FillAndExpand,
				VerticalOptions = LayoutOptions.FillAndExpand,
				Source = new UrlWebViewSource () {
					Url = "http://www.google.com"
				}
			};
			Grid.SetRow (webView, 1);
			grid.Children.Add (webView);

			button.Clicked += (s, e) => {
				webView.Source = new UrlWebViewSource() {
					Url = entry.Text
				};
			};

			this.Content = grid;
		}
	}
}