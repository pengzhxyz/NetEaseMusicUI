using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Composition;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace NetEaseMusicUI.Controls
{
    public sealed partial class PlayBar : UserControl
    {

        private PlayingView _playingView;

        public PlayBar()
        {
            this.InitializeComponent();
            _playingView = this.PlayingView;
            this.coverImage.Tapped += CoverImage_Tapped;
            this.playBT.Click += PlayBT_Click;
        }

        private void PlayBT_Click(object sender, RoutedEventArgs e)
        {
            if (_playingView.GetIsRotating())
            {
                _playingView.StopDiskRotate();
            }
            else
            {
                _playingView.StartDiskRotate();
            }
        }

        private void CoverImage_Tapped(object sender, TappedRoutedEventArgs e)
        {
            if (_playingView.GetIsOpened())
            {
                ClosePlayingView();
            }
            else
            {
                OpenPlayingView();
            }
        }

        public void ClosePlayingView()
        {
            _playingView.ClosePlayingView();
        }
        public void OpenPlayingView()
        {
            _playingView.OpenPlayingView();
        }
    }
}
