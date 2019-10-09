using Xamarin.Forms;

namespace QuipVid.Video
{
    public class FileVideoSource : VideoSource
    {
        public static readonly BindableProperty FileProperty = BindableProperty.Create(
            propertyName: nameof(File),
            returnType: typeof(string),
            declaringType: typeof(FileVideoSource)
        );

        public string File
        {
            get => (string) GetValue(FileProperty);
            set => SetValue(FileProperty, value);
        }
    }
}
