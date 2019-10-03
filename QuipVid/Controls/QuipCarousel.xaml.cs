using System;
using System.Collections.Generic;
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
        public QuipCarousel()
        {
            InitializeComponent();
        }
    }
}

