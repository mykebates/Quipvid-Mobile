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
            TextColor = Color.White;
            BackgroundColor = (Color) App.Current.Resources["NavigationPrimary"];
            
            // Currently setting the SearchBoxVisibility or the PlaceholderColor in iOS does not work properly
            // https://github.com/xamarin/Xamarin.Forms/issues/6726
            // https://github.com/xamarin/Xamarin.Forms/issues/7695
            if (!(Device.RuntimePlatform == Device.iOS))
            {
                SearchBoxVisibility = SearchBoxVisibility.Collapsible;
                PlaceholderColor = (Color) App.Current.Resources["NavigationAccent"];
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