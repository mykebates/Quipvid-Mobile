using System.Collections.Generic;
using Xamarin.Forms;

namespace QuipVid.Controls
{
    public class QuipSearchHandler : SearchHandler
    {
        public QuipSearchHandler()
        {
            ShowsResults = true;
            Placeholder = "Enter search term";
            PlaceholderColor = (Color) App.Current.Resources["NavigationAccent"];
            TextColor = Color.White;
            BackgroundColor = (Color) App.Current.Resources["NavigationPrimary"];

            if (Device.RuntimePlatform == Device.Android)
            {
                SearchBoxVisibility = SearchBoxVisibility.Collapsible;
            }
            else
            {
                SearchBoxVisibility = SearchBoxVisibility.Expanded;
            }
        }

        protected override void OnQueryChanged(string oldValue, string newValue)
        {
            base.OnQueryChanged(oldValue, newValue);

            if (string.IsNullOrWhiteSpace(newValue))
            {
                ItemsSource = null;
                return;
            }

            ItemsSource = new List<string>
            {
                "Search results 1",
                "Search results 2",
                "Search results 3",
                "Search results 4",
                "Search results 5",
                "Search results 6",
            };
        }
    }
}