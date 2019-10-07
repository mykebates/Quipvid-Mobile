using System.Linq;

namespace QuipVid.ViewModels
{
    public class DetailsCardViewModel : BaseViewModel
    {
        private string _description = "";
        public string Description
        {
            get => _description;
            set
            {
                SetProperty(ref _description, value);
                OnPropertyChanged(nameof(VisibleDescription));
            }
        }

        private bool _descriptionExpanded = false;
        public bool DescriptionExpanded
        {
            get => _descriptionExpanded;
            set
            {
                SetProperty(ref _descriptionExpanded, value);
                OnPropertyChanged(nameof(VisibleDescription));
            }
        }

        public string VisibleDescription =>
            DescriptionExpanded ? Description : $"{new string(Description.Take(50).ToArray())}...";
    }
}
