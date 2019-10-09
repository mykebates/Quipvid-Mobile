using System;
using Xamarin.Forms;

namespace QuipVid.Video
{
    public class VideoSourceConverter : TypeConverter
    {
        public override object ConvertFromInvariantString(string value)
        {
            if (!string.IsNullOrWhiteSpace(value))
            {
                return Uri.TryCreate(value, UriKind.Absolute, out var uri) && uri.Scheme != "file"
                    ? VideoSource.FromUri(value)
                    : VideoSource.FromResource(value);
            }
            
            throw new InvalidOperationException("Cannot convert null or whitespace to ImageSource");
        }
    }
}
