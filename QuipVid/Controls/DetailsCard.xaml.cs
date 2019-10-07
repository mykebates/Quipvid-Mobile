using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuipVid.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace QuipVid.Controls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetailsCard : StackLayout
    {
        public DetailsCardViewModel DetailsCardViewModel { get; set; }
        public DetailsCard()
        {
            InitializeComponent();
            DetailsCardViewModel = new DetailsCardViewModel
            {
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Eget felis eget nunc lobortis. Faucibus nisl tincidunt eget nullam non. Lacus vestibulum sed arcu non odio euismod lacinia at quis."
            };
            
            BindingContext = DetailsCardViewModel;

            SetupEvents();
        }

        private void SetupEvents()
        {
            var tapGestureRecognizer = new TapGestureRecognizer();
            tapGestureRecognizer.Tapped += OnDescriptionSection_Clicked;
            DescriptionSection.GestureRecognizers.Add(tapGestureRecognizer);
        }

        private void OnDescriptionSection_Clicked(object sender, EventArgs eventArgs)
        {
            DetailsCardViewModel.DescriptionExpanded = !DetailsCardViewModel.DescriptionExpanded;

            DescriptionToggle.Rotation = DetailsCardViewModel.DescriptionExpanded ? 180 : 0;
        }
    }
}

