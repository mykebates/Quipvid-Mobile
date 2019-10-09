using System;
using System.ComponentModel;
using AVFoundation;
using AVKit;
using Foundation;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using QuipVid.Video;
using QuipVid.iOS.Video;

[assembly: ExportRenderer(typeof(VideoPlayer), typeof(VideoPlayerRenderer))]
namespace QuipVid.iOS.Video
{
    public class VideoPlayerRenderer : ViewRenderer<VideoPlayer, UIView>
    {
        private AVPlayer _player;
        private AVPlayerItem _playerItem;
        private AVPlayerViewController _playerViewController;

        public override UIViewController ViewController => _playerViewController;

        protected override void OnElementChanged(ElementChangedEventArgs<VideoPlayer> args)
        {
            base.OnElementChanged(args);

            if (args.NewElement != null)
            {
                if (Control == null)
                {
                    _playerViewController = new AVPlayerViewController();
                    
                    _player = new AVPlayer();

                    _playerViewController.Player = _player;
                    
                    SetNativeControl(_playerViewController.View);
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
            base.Dispose(disposing);

            if (_player != null)
            {
                _player.ReplaceCurrentItemWithPlayerItem(null);
            }
        }

        private void SetControlsEnabled()
        {
            ((AVPlayerViewController) ViewController).ShowsPlaybackControls = Element.ControlsEnabled;
        }

        private void SetSource()
        {
            AVAsset asset = null;

            if (Element.Source is UriVideoSource)
            {
                var uri = (Element.Source as UriVideoSource)?.Uri;

                if (!string.IsNullOrWhiteSpace(uri))
                {
                    asset = AVAsset.FromUrl(new NSUrl(uri));
                }
            }

            if (asset != null)
            {
                _playerItem = new AVPlayerItem(asset);
            }
            else
            {
                _playerItem = null;
            }
            
            _player.ReplaceCurrentItemWithPlayerItem(_playerItem);

            if (_playerItem != null && Element.AutoPlay)
            {
                _player.Play();
            }
        }
    }
}
