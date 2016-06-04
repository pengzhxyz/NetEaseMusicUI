using SamplesCommon.ImageLoader;
using SamplesCommon;
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
using Windows.UI.Xaml.Hosting;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Microsoft.Graphics.Canvas.Effects;
using Microsoft.Graphics.Canvas;
using System.Threading.Tasks;
using Microsoft.Graphics.Canvas.UI.Xaml;
using Windows.UI;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace NetEaseMusicUI.Controls
{
    public sealed partial class PlayingView : UserControl
    {
        private Compositor _compositor;
        private UIElement _rootGrid;
        private Visual _rootGridVisual, _playerDiskVisual, _playerNeedleVisual, _coverBackImageVisual;
        Vector3KeyFrameAnimation _openPlayingViewScaleAnimation, _closePlayingViewScaleAnimation;
        ScalarKeyFrameAnimation _openPlayingViewOpacityAnimation, _closePlayingViewOpacityAnimation;
        ScalarKeyFrameAnimation _diskRotationAnimation, _needleStartAnimation, _needleStopAnimation;
        CanvasBitmap _coverCanvasBitmap;

        private bool _opened = false;
        private bool _isRotating = false;
        public PlayingView()
        {
            this.InitializeComponent();
            this.SizeChanged += PlayingView_SizeChanged;
            this.Loaded += PlayingView_Loaded;
        }

        private void PlayingView_Loaded(object sender, RoutedEventArgs e)
        {
            if (Windows.ApplicationModel.DesignMode.DesignModeEnabled)
            {
                return;
            }
            // get the private fields
            _rootGrid = this.RootGrid;
            _rootGridVisual = ElementCompositionPreview.GetElementVisual(this.RootGrid);
            _compositor = _rootGridVisual.Compositor;
            _playerDiskVisual = ElementCompositionPreview.GetElementVisual(this.playerDiskGrid);
            _playerNeedleVisual = ElementCompositionPreview.GetElementVisual(this.playerNeedle);
            //_coverBackImageVisual = ElementCompositionPreview.GetElementVisual(this.coverBGImage);
            this.backCanvasControl.CreateResources += BackCanvasControl_CreateResources;
            this.backCanvasControl.Draw += BackCanvasControl_Draw;

            // prepare animations
            var liner = _compositor.CreateLinearEasingFunction();
            _openPlayingViewScaleAnimation = _compositor.CreateVector3KeyFrameAnimation();
            _openPlayingViewScaleAnimation.InsertKeyFrame(0.0f, new System.Numerics.Vector3(0.0f,0f,1f));
            _openPlayingViewScaleAnimation.InsertKeyFrame(1.0f, new System.Numerics.Vector3(1f,1f,1f),liner);
            _openPlayingViewScaleAnimation.Duration = TimeSpan.FromMilliseconds(300);

            _closePlayingViewScaleAnimation = _compositor.CreateVector3KeyFrameAnimation();
            _closePlayingViewScaleAnimation.InsertKeyFrame(0.0f, new System.Numerics.Vector3(1f, 1f, 1f));
            _closePlayingViewScaleAnimation.InsertKeyFrame(1.0f, new System.Numerics.Vector3(0f, 0f, 1f), liner);
            _closePlayingViewScaleAnimation.Duration = TimeSpan.FromMilliseconds(300);

            _closePlayingViewOpacityAnimation = _compositor.CreateScalarKeyFrameAnimation();
            _closePlayingViewOpacityAnimation.InsertKeyFrame(0.0f, 1.0f);
            _closePlayingViewOpacityAnimation.InsertKeyFrame(1.0f, 0.3f,liner);
            _closePlayingViewOpacityAnimation.Duration = TimeSpan.FromMilliseconds(300);

            _openPlayingViewOpacityAnimation = _compositor.CreateScalarKeyFrameAnimation();
            _openPlayingViewOpacityAnimation.InsertKeyFrame(0.0f, 0.3f);
            _openPlayingViewOpacityAnimation.InsertKeyFrame(1.0f, 1.0f, liner);
            _openPlayingViewOpacityAnimation.Duration = TimeSpan.FromMilliseconds(300);
            // Playing rotation animation
            _diskRotationAnimation = _compositor.CreateScalarKeyFrameAnimation();
            _diskRotationAnimation.InsertKeyFrame(0.0f, 0f);
            _diskRotationAnimation.InsertKeyFrame(1f, 360.0f, liner);
            _diskRotationAnimation.Duration = TimeSpan.FromSeconds(30);
            _diskRotationAnimation.IterationBehavior = AnimationIterationBehavior.Forever;

            _needleStartAnimation = _compositor.CreateScalarKeyFrameAnimation();
            _needleStartAnimation.InsertKeyFrame(0f, -30f);
            _needleStartAnimation.InsertKeyFrame(1f, 0f, liner);
            _needleStartAnimation.Duration = TimeSpan.FromMilliseconds(500);

            _needleStopAnimation = _compositor.CreateScalarKeyFrameAnimation();
            _needleStopAnimation.InsertKeyFrame(0f, 0f);
            _needleStopAnimation.InsertKeyFrame(1f, -30f, liner);
            _needleStopAnimation.Duration = TimeSpan.FromMilliseconds(500);

            // set centerpoint
            _rootGridVisual.CenterPoint = new System.Numerics.Vector3(0.0f, (float)RootGrid.ActualHeight, 0.0f);
            _playerDiskVisual.CenterPoint = new System.Numerics.Vector3((float)(this.playerDiskGrid.ActualWidth / 2), (float)(this.playerDiskGrid.ActualHeight / 2), 0f);
            _playerNeedleVisual.CenterPoint = new System.Numerics.Vector3((float)(this.playerNeedle.ActualWidth / 2), 0f, 0f);


            // Set initial state of the visuals
            //_rootGridVisual.Scale = new System.Numerics.Vector3(0.0f, 0f, 1f);
            _playerNeedleVisual.RotationAngleInDegrees = -30f;

            // Note: Using storyboard instead of Composition API
            // Because blur appeares after compostion animation
            // It confused me!!
            _rootGrid.RenderTransform = new CompositeTransform() { ScaleX = 0, ScaleY = 0 };

            // Set CoverBackground Effect; Don't support GaussionEffect!!
            //PrepareBlurCover();
        }


        private void BackCanvasControl_CreateResources(Microsoft.Graphics.Canvas.UI.Xaml.CanvasControl sender, Microsoft.Graphics.Canvas.UI.CanvasCreateResourcesEventArgs args)
        {
            args.TrackAsyncAction(CreateResourcesAsync(sender).AsAsyncAction());
        }

        private void BackCanvasControl_Draw(Microsoft.Graphics.Canvas.UI.Xaml.CanvasControl sender, Microsoft.Graphics.Canvas.UI.Xaml.CanvasDrawEventArgs args)
        {
            var gaussionBlurEffect = new GaussianBlurEffect() { BlurAmount = 20,BorderMode=EffectBorderMode.Hard, Source = _coverCanvasBitmap };
            args.DrawingSession.DrawImage(gaussionBlurEffect);
            // scaling
            var canvasViusal = ElementCompositionPreview.GetElementVisual(this.backCanvasControl);
            float d = (float)_coverCanvasBitmap.Size.Width;
            float w = (float)this.scrollViewer.ActualWidth;
            float scale = w / d;
            canvasViusal.Scale = new System.Numerics.Vector3(scale);
        }
        async Task CreateResourcesAsync(CanvasControl sender)
        {
            _coverCanvasBitmap = await CanvasBitmap.LoadAsync(sender, "Assets/Images/cover_qilixiang.jpg");
        }
        // often crash in xaml desigher when using visualstateManager to change the relativePanel properties
        // so put the resoponse logic to the sizeChanged 
        private void PlayingView_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (e.NewSize.Width>=(double)App.Current.Resources["MediumWindowSnapPoint"])
            {
                RelativePanel.SetRightOf(this.lyricsGrid, this.playerGrid);
                RelativePanel.SetBelow(this.lyricsGrid, null);
            }
            else
            {
                RelativePanel.SetRightOf(this.lyricsGrid, null);
                RelativePanel.SetBelow(this.lyricsGrid, this.playerGrid);
            }
            
        }

        private void PrepareBlurCover()
        {
            CompositionSurfaceBrush surfaceBrush = _compositor.CreateSurfaceBrush();
            surfaceBrush = CreateBrushFromAsset("player_disk_cover.scale-200.png");
            var gaussionBlurEffect = new GaussianBlurEffect() { BlurAmount = 20, Source = new CompositionEffectSourceParameter("ImageSource") };
            var effectFactory = _compositor.CreateEffectFactory(gaussionBlurEffect);
            var myEffact = effectFactory.CreateBrush();

            //CreateEffectFactory Don't surpport GaussionBlurEffect!!

            //this.coverBGCompositionImage.Brush = myEffact;
        }

        private CompositionSurfaceBrush CreateBrushFromAsset(string name, out Size size)
        {
            IImageLoader imageLoader = ImageLoaderFactory.CreateImageLoader(_compositor);
            CompositionDrawingSurface surface = imageLoader.LoadImageFromUri(new Uri("ms-appx:///Assets/Images/"+name));
            size = surface.Size;
            return _compositor.CreateSurfaceBrush(surface);
        }

        private CompositionSurfaceBrush CreateBrushFromAsset(string name)
        {
            Size size;
            return CreateBrushFromAsset(name, out size);
        }

        public bool GetIsOpened()
        {
            return _opened;
        }
        public bool GetIsRotating()
        {
            return _isRotating;
        }
        public void ClosePlayingView()
        {
            // Note: Using storyboard instead of Composition API
            // Because blur appeares after compostion animation
            // It confused me!!
            this.Storyboard_Close.Begin();

            //_rootGridVisual.StartAnimation("Scale", _closePlayingViewScaleAnimation);
            //_rootGridVisual.StartAnimation("Opacity", _closePlayingViewOpacityAnimation);
            _opened = false;
        }
        public void OpenPlayingView()
        {
            // Note: Using storyboard instead of Composition API
            // Because blur appeares after compostion animation
            // It confused me!!

            this.Storyboard_Open.Begin();

            //_rootGridVisual.StartAnimation("Scale", _openPlayingViewScaleAnimation);
            //_rootGridVisual.StartAnimation("Opacity", _openPlayingViewOpacityAnimation);
            _opened = true;
        }

        public void StartDiskRotate()
        {
            _playerDiskVisual.StartAnimation("RotationAngleInDegrees", _diskRotationAnimation);
            _playerNeedleVisual.StartAnimation("RotationAngleInDegrees", _needleStartAnimation);
            _isRotating = true;
        }
        public void StopDiskRotate()
        {
            _playerDiskVisual.StopAnimation("RotationAngleInDegrees");
            _playerNeedleVisual.StartAnimation("RotationAngleInDegrees", _needleStopAnimation);
            _isRotating = false;
        }
    }
}
