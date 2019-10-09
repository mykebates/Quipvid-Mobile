using System;
using System.ComponentModel;
using Android.Content;
using Android.Widget;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using QuipVid.Video;
using QuipVid.Droid.Video;


[assembly: ExportRenderer(typeof(VideoPlayer), typeof(VideoPlayerRenderer))]
namespace QuipVid.Droid.Video
{
    public class VideoPlayerRenderer : ViewRenderer<VideoPlayer, Android.Widget.RelativeLayout>
    {
        private VideoView _videoView;
        private MediaController _mediaController;
        private bool _isPrepared;
        
        public VideoPlayerRenderer(Context context) : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<VideoPlayer> args)
        {
            base.OnElementChanged(args);

            if (args.NewElement != null)
            {
                if (Control == null)
                {
                    _videoView = new VideoView(Context);
                    
                    var relativeLayout = new Android.Widget.RelativeLayout(Context);
                    relativeLayout.AddView(_videoView);
                    
                    
                    var layoutParams = new Android.Widget.RelativeLayout.LayoutParams(
                        LayoutParams.MatchParent, 
                        LayoutParams.MatchParent
                    );
                    
                    _videoView.LayoutParameters = layoutParams;

                    _videoView.Prepared += OnVideoViewPrepared;
                    
                    SetNativeControl(relativeLayout);
                }
                
                SetControlsEnabled();
                SetSource();
            }
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs args)
        {
            base.OnElementPropertyChanged(sender, args);

            if (args.PropertyName == VideoPlayer.ControlsEnabledProperty.PropertyName)
            {
                SetControlsEnabled();
            }

            if (args.PropertyName == VideoPlayer.SourceProperty.PropertyName)
            {
                SetSource();
            }
        }
        

        protected override void Dispose(bool disposing)
        {
            if (Control != null && _videoView != null)
            {
                _videoView.Prepared -= OnVideoViewPrepared;
            }
            
            base.Dispose(disposing);
        }

        private void OnVideoViewPrepared(object sender, EventArgs args)
        {
            _isPrepared = true;
        }

        private void SetControlsEnabled()
        {
            if (Element.ControlsEnabled)
            {
                _mediaController = new MediaController(Context);
                _mediaController.SetMediaPlayer(_videoView);
                _videoView.SetMediaController(_mediaController);
                return;
            }
            
            _videoView.SetMediaController(null);

            if (_mediaController == null) return;
            
            _mediaController.SetMediaPlayer(null);
            _mediaController = null;
        }
        
        private void SetSource()
        {
            _isPrepared = false;

            var hasSetSource = false;

            if (Element.Source is UriVideoSource)
            {
                var uri = (Element.Source as UriVideoSource)?.Uri;

                if (!string.IsNullOrWhiteSpace(uri))
                {
                    _videoView.SetVideoURI(Android.Net.Uri.Parse(uri));
                    hasSetSource = true;
                }
            }

            if (hasSetSource && Element.AutoPlay)
            {
                _videoView.Start();
            }
        }
    }
}
