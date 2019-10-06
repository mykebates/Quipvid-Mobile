using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using QuipVid.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace QuipVid.Controls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HorizontalCardSet : StackLayout
    {
        public List<string> Items { get; set; }
        public HorizontalCardSet()
        {
            InitializeComponent();
            Items = new List<string>
            {
                "Item 1",
                "Item 2",
                "Item 3",
                "Item 4",
                "Item 5",
            };
            CardSet.ItemsSource = Items;
            CardSet.ItemTemplate = new HorizontalCardSetDataTemplateSelector
            {
                Items = Items,
                FirstCardTemplate = (DataTemplate) CardSet.Resources["FirstCardTemplate"],
                DefaultCardTemplate = (DataTemplate) CardSet.Resources["DefaultCardTemplate"],
                LastCardTemplate = (DataTemplate) CardSet.Resources["LastCardTemplate"],
            };
        }

        public class HorizontalCardSetDataTemplateSelector : DataTemplateSelector
        {
            public DataTemplate FirstCardTemplate { get; set; }
            public DataTemplate DefaultCardTemplate { get; set; }
            public DataTemplate LastCardTemplate { get; set; }

            public List<string> Items;

            protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
            {
                var castItem = (string) item;
                var index = Items.IndexOf(castItem);

                if (index == 0)
                {
                    return FirstCardTemplate;
                }

                if (index == Items.Count - 1)
                {
                    return LastCardTemplate;
                }

                return DefaultCardTemplate;
            }
        }
    }
}

