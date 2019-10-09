using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace QuipVid.Video
{
    public class VideoPlayer : View
    {
        public static readonly BindableProperty ControlsEnabledProperty = BindableProperty.Create(
            propertyName: nameof(ControlsEnabled), 
            returnType: typeof(bool), 
            declaringType: typeof(VideoPlayer),
            defaultValue: true
        );

        public bool ControlsEnabled
        {
            get => (bool) GetValue(ControlsEnabledProperty);
            set => SetValue(ControlsEnabledProperty, value);
        }
        
        public static readonly BindableProperty SourceProperty = BindableProperty.Create(
            propertyName: nameof(Source), 
            returnType: typeof(VideoSource), 
            declaringType: typeof(VideoPlayer),
            defaultValue: null
        );
        
        [TypeConverter(typeof(VideoSourceConverter))]
        public VideoSource Source
        {
            get => (VideoSource) GetValue(SourceProperty);
            set => SetValue(SourceProperty, value);
        }
        
        public static readonly BindableProperty AutoPlayProperty = BindableProperty.Create(
            propertyName: nameof(AutoPlay), 
            returnType: typeof(bool), 
            declaringType: typeof(VideoPlayer),
            defaultValue: false
        );
        
        public bool AutoPlay
        {
            get => (bool) GetValue(AutoPlayProperty);
            set => SetValue(AutoPlayProperty, value);
        }
    }
}
