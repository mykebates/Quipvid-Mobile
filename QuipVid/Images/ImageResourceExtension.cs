using System;
using System.Reflection;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace QuipVid.Images
{
    [ContentProperty(nameof(Source))]
    public class ImageResourceExtension : IMarkupExtension
    {
        public string Source { get; set; }
        
        public object ProvideValue(IServiceProvider serviceProvider)
        {
            if (Source == null) return null;
            
            var imageSource = ImageSource.FromResource(Source, Assembly.GetAssembly(typeof(ImageResourceExtension)));
            return imageSource;
        }
    }
}