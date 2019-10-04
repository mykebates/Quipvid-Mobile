using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarouselView.FormsPlugin.Abstractions;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace QuipVid.Controls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class QuipCarousel : StackLayout
    {
        public ObservableCollection<string> Items { get; private set; }
        
        public QuipCarousel()
        {
            InitializeComponent();
            Items = new ObservableCollection<string>
            {
                "String 1",
                "String 2",
                "String 3",
                "String 4",
            };
            CarouselView.ItemsSource = Items;
        }

        public void RefreshItems()
        {
            var tempItems = new List<string>();
            
            foreach (var item in Items.ToList())
            {
                tempItems.Add(item);
                Items.Remove(item);
            }

            foreach (var item in tempItems)
            {
                Items.Add(item);
            }
        }
    }
}

