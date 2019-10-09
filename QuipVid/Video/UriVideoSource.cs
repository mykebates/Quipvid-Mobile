using Xamarin.Forms;

namespace QuipVid.Video
{
    public class UriVideoSource : VideoSource
    {
        public static readonly BindableProperty UriProperty = BindableProperty.Create(
            propertyName: nameof(Uri),
            returnType: typeof(string),
            declaringType: typeof(UriVideoSource)
        );

        public string Uri
        {
            get => (string) GetValue(UriProperty);
            set => SetValue(UriProperty, value);
        }
    }
}
