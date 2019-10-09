using Xamarin.Forms;

namespace QuipVid.Video
{
    public class ResourceVideoSource : VideoSource
    {
        public static readonly BindableProperty PathProperty = BindableProperty.Create(
            propertyName: nameof(Path),
            returnType: typeof(string),
            declaringType: typeof(ResourceVideoSource)
        );

        public string Path
        {
            get => (string) GetValue(PathProperty);
            set => SetValue(PathProperty, value);
        }
    }
}
