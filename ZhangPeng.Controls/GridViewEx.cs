using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Composition;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Hosting;

namespace ZhangPeng.Controls
{
    public class GridViewEx:GridView
    {
        // Properties


        public double ItemHeight
        {
            get { return (double)GetValue(ItemHeightProperty); }
            set { SetValue(ItemHeightProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ItemHeight.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ItemHeightProperty =
            DependencyProperty.Register("ItemHeight", typeof(double), typeof(GridViewEx), new PropertyMetadata(0.00));




        public Thickness GridViewExRefreshIconMargin
        {
            get { return (Thickness)GetValue(GridViewExRefreshIconMarginProperty); }
            set { SetValue(GridViewExRefreshIconMarginProperty, value); }
        }

        // Using a DependencyProperty as the backing store for GridViewExRefreshIconMargin.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty GridViewExRefreshIconMarginProperty =
            DependencyProperty.Register("GridViewExRefreshIconMargin", typeof(Thickness), typeof(GridViewEx), new PropertyMetadata(new Thickness(0,-30,0,0)));



        public double ItemWidthSuggest
        {
            get { return (double)GetValue(ItemWidthSuggestProperty); }
            set { SetValue(ItemWidthSuggestProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ItemWidthSuggest.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ItemWidthSuggestProperty =
            DependencyProperty.Register("ItemWidthSuggest", typeof(double), typeof(GridViewEx), new PropertyMetadata(0.00));



        // Events
        public delegate void RefreshRequestedEventHandler(object sender, EventArgs e);
        public event RefreshRequestedEventHandler RefreshRequested;
        private void OnRefreshRequested()
        {
            if (RefreshRequested != null)
            {
                RefreshRequested(this, new EventArgs());
            }
        }
        public delegate void ScrollToBottomEventHandler(object sender, EventArgs e);
        public event ScrollToBottomEventHandler ScrollToBottom;
        public virtual void OnScrollToBottom()
        {
            if (ScrollToBottom != null)
            {
                ScrollToBottom(this, new EventArgs());
            }
        }

        // 自适应宽度所需
        private ItemsWrapGrid _itemsWrapGrid;
        // 下拉刷新用到的私有变量
        private ScrollViewer _scrollViewer;
        SymbolIcon _refreshIcon;
        CompositionPropertySet _scrollerViewerManipulation;
        ExpressionAnimation _rotationAnimation, _opacityAnimation, _offsetAnimation;

        Visual _refreshIconVisual;
        float _refreshIconOffsetY;
        const float REFRESH_ICON_MAX_OFFSET_Y = 20.0f;

        bool _refresh;
        DateTime _pulledDownTime, _restoredTime;

        public GridViewEx()
        {
            DefaultStyleKey = typeof(GridViewEx);
        }

        protected override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            this.Loaded += GridViewEx_Loaded;
            this.SizeChanged += (s, ee) =>
            {
                _itemsWrapGrid = this.GetFirstDescendantOfType<ItemsWrapGrid>();
                if (_itemsWrapGrid==null)
                {
                    return;
                }
                int colum = (int)Math.Floor(ee.NewSize.Width / this.ItemWidthSuggest);
                _itemsWrapGrid.ItemWidth = ee.NewSize.Width / colum;
                if (colum > 1)
                {
                    this.ItemContainerStyle = (this.GetTemplateChild("RootLayout") as Grid).Resources["GridViewItemStyle2"] as Style;
                }
                else
                {
                    this.ItemContainerStyle = (this.GetTemplateChild("RootLayout") as Grid).Resources["GridViewItemStyle1"] as Style;
                }
            };

            if (Windows.ApplicationModel.DesignMode.DesignModeEnabled)
            {
                return;
            }
            _scrollViewer = this.GetFirstDescendantOfType<ScrollViewer>();
            var binding = new Windows.UI.Xaml.Data.Binding { Source = _scrollViewer, Path = new PropertyPath("VerticalOffset") };
            BindingOperations.SetBinding(this, VerticalOffsetProperty, binding);

            _refreshIcon = this.GetTemplateChild("RefreshIcon") as SymbolIcon;
            _scrollViewer.DirectManipulationStarted += OnDirectManipulationStarted;
            _scrollViewer.DirectManipulationCompleted += OnDirectManipulationCompleted;
            _scrollerViewerManipulation = ElementCompositionPreview.GetScrollViewerManipulationPropertySet(_scrollViewer);
            var compositor = _scrollerViewerManipulation.Compositor;
            // At the moment there are three things happening when pulling down the list -
            // 1. The Refresh Icon fades in.
            // 2. The Refresh Icon rotates (400°).
            // 3. The Refresh Icon gets pulled down a bit (REFRESH_ICON_MAX_OFFSET_Y)
            // QUESTION 5
            // Can we also have Geometric Path animation so we can also draw the Refresh Icon along the way?
            //

            // Create a rotation expression animation based on the overpan distance of the ScrollViewer.
            _rotationAnimation = compositor.CreateExpressionAnimation("min(max(0, ScrollManipulation.Translation.Y) * Multiplier, MaxDegree)");
            _rotationAnimation.SetScalarParameter("Multiplier", 10.0f);
            _rotationAnimation.SetScalarParameter("MaxDegree", 400.0f);
            _rotationAnimation.SetReferenceParameter("ScrollManipulation", _scrollerViewerManipulation);

            // Create an opacity expression animation based on the overpan distance of the ScrollViewer.
            _opacityAnimation = compositor.CreateExpressionAnimation("min(max(0, ScrollManipulation.Translation.Y) / Divider, 1)");
            _opacityAnimation.SetScalarParameter("Divider", 30.0f);
            _opacityAnimation.SetReferenceParameter("ScrollManipulation", _scrollerViewerManipulation);

            // Create an offset expression animation based on the overpan distance of the ScrollViewer.
            _offsetAnimation = compositor.CreateExpressionAnimation("(min(max(0, ScrollManipulation.Translation.Y) / Divider, 1)) * MaxOffsetY");
            _offsetAnimation.SetScalarParameter("Divider", 30.0f);
            _offsetAnimation.SetScalarParameter("MaxOffsetY", REFRESH_ICON_MAX_OFFSET_Y);
            _offsetAnimation.SetReferenceParameter("ScrollManipulation", _scrollerViewerManipulation);

            // Get the RefreshIcon's Visual.
            _refreshIconVisual = ElementCompositionPreview.GetElementVisual(_refreshIcon);
            // Set the center point for the rotation animation
            //if (!Windows.ApplicationModel.DesignMode.DesignModeEnabled)
            //{
            //    _refreshIconVisual.CenterPoint = new Vector3(Convert.ToSingle(_refreshIcon.Width / 2), Convert.ToSingle(_refreshIcon.Height / 2), 0);
            //}
            // Kick off the animations.
            _refreshIconVisual.StartAnimation("RotationAngleInDegrees", _rotationAnimation);
            _refreshIconVisual.StartAnimation("Opacity", _opacityAnimation);
            _refreshIconVisual.StartAnimation("Offset.Y", _offsetAnimation);
            this.Unloaded += (s, e) =>
            {
                _scrollViewer.DirectManipulationStarted -= OnDirectManipulationStarted;
                _scrollViewer.DirectManipulationCompleted -= OnDirectManipulationCompleted;
            };
            //加速度计，摇一摇
            //_accelerometer = Accelerometer.GetDefault();
            //if (_accelerometer != null)
            //{
            //    // Establish the report interval
            //    uint minReportInterval = _accelerometer.MinimumReportInterval;
            //    uint reportInterval = minReportInterval > 16 ? minReportInterval : 16;
            //    _accelerometer.ReportInterval = reportInterval;

            //    // Assign an event handler for the reading-changed event
            //    _accelerometer.ReadingChanged += new TypedEventHandler<Accelerometer, AccelerometerReadingChangedEventArgs>(ReadingChanged);
            //}
        }

        private void GridViewEx_Loaded(object sender, RoutedEventArgs e)
        {
            // 为了响应式
            _itemsWrapGrid = this.GetFirstDescendantOfType<ItemsWrapGrid>();
            _itemsWrapGrid.ItemHeight = this.ItemHeight;
            int c = (int)Math.Floor(this.ActualWidth / this.ItemWidthSuggest);
            _itemsWrapGrid.ItemWidth = this.ActualWidth / c;
            if (c > 1)
            {
                this.ItemContainerStyle = (this.GetTemplateChild("RootLayout") as Grid).Resources["GridViewItemStyle2"] as Style;
            }
            else
            {
                this.ItemContainerStyle = (this.GetTemplateChild("RootLayout") as Grid).Resources["GridViewItemStyle1"] as Style;
            }
            // to advoid crash in xaml designer
            if (!Windows.ApplicationModel.DesignMode.DesignModeEnabled)
            {
                _refreshIconVisual.CenterPoint = new Vector3(Convert.ToSingle(_refreshIcon.Width / 2), Convert.ToSingle(_refreshIcon.Height / 2), 0);
            }
            //this.SizeChanged += (s, ee) =>
            //{
            //    int colum = (int)Math.Floor(ee.NewSize.Width / this.ItemWidthSuggest);
            //    _itemsWrapGrid.ItemWidth = ee.NewSize.Width / colum;
            //};
        }

        //Private Methods
        void OnDirectManipulationStarted(object sender, object e)
        {
            // QUESTION 1
            // I cannot think of a better way to monitor overpan changes, maybe there should be an Animating event?
            //
            Windows.UI.Xaml.Media.CompositionTarget.Rendering += OnCompositionTargetRendering;

            // Initialise the values.
            _refresh = false;
        }

        void OnDirectManipulationCompleted(object sender, object e)
        {
            Windows.UI.Xaml.Media.CompositionTarget.Rendering -= OnCompositionTargetRendering;

            //Debug.WriteLine($"ScrollViewer Rollback animation duration: {(_restoredTime - _pulledDownTime).Milliseconds}");

            // The ScrollViewer's rollback animation is appx. 200ms. So if the duration between the two DateTimes we recorded earlier
            // is greater than 250ms, we should cancel the refresh.
            var cancelled = (_restoredTime - _pulledDownTime) > TimeSpan.FromMilliseconds(250);

            if (_refresh)
            {
                if (cancelled)
                {
                    System.Diagnostics.Debug.WriteLine("GridViewEx Refresh cancelled...");
                }
                else
                {
                    OnRefreshRequested();
                    _refresh = false;
                    System.Diagnostics.Debug.WriteLine("GridViewEx Refresh now!!!");
                }
            }
        }

        void OnCompositionTargetRendering(object sender, object e)
        {
            // QUESTION 2
            // What I've noticed is that I have to manually stop and
            // start the animation otherwise the Offset.Y is 0. Why?
            //
            _refreshIconVisual.StopAnimation("Offset.Y");

            // QUESTION 3
            // Why is the Translation always (0,0,0)?
            //
            //Vector3 translation;
            //var translationStatus = _scrollerViewerManipulation.TryGetVector3("Translation", out translation);
            //switch (translationStatus)
            //{
            //    case CompositionGetValueStatus.Succeeded:
            //        Debug.WriteLine($"ScrollViewer's Translation Y: {translation.Y}");
            //        break;
            //    case CompositionGetValueStatus.TypeMismatch:
            //    case CompositionGetValueStatus.NotFound:
            //    default:
            //        break;
            //}

            _refreshIconOffsetY = _refreshIconVisual.Offset.Y;
            //Debug.WriteLine($"RefreshIcon's Offset Y: {_refreshIconOffsetY}");

            // Question 4
            // It's not always the case here as the user can pull it all the way down and then push it back up to
            // CANCEL a refresh!! Though I cannot seem to find an easy way to detect right after the finger is lifted.
            // DirectManipulationCompleted is called too late.
            // What might be really helpful is to have a DirectManipulationDelta event with velocity and other values.
            //
            // At the moment I am calculating the time difference between the list gets pulled all the way down and rolled back up.
            // 
            if (!_refresh)
            {
                _refresh = _refreshIconOffsetY == REFRESH_ICON_MAX_OFFSET_Y;
            }

            if (_refreshIconOffsetY == REFRESH_ICON_MAX_OFFSET_Y)
            {
                _pulledDownTime = DateTime.Now;
                //Debug.WriteLine($"When the list is pulled down: {_pulledDownTime}");
            }

            if (_refresh && _refreshIconOffsetY <= 1)
            {
                _restoredTime = DateTime.Now;
                //Debug.WriteLine($"When the list is back up: {_restoredTime}");
            }

            _refreshIconVisual.StartAnimation("Offset.Y", _offsetAnimation);
        }
        //private async void ReadingChanged(object sender, AccelerometerReadingChangedEventArgs e)
        //{
        //    await Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
        //    {
        //        AccelerometerReading reading = e.Reading;
        //        var x = String.Format("{0,5:0.00}", reading.AccelerationX);
        //        var y = String.Format("{0,5:0.00}", reading.AccelerationY);
        //        var z = String.Format("{0,5:0.00}", reading.AccelerationZ);
        //        if ((Math.Abs(reading.AccelerationX) + Math.Abs(reading.AccelerationX) + Math.Abs(reading.AccelerationX)) > 5)
        //            OnShakeReflesh();

        //    });
        //}
        public double VerticalOffset
        {
            get
            {
                return (double)GetValue(VerticalOffsetProperty);
            }
            set { SetValue(VerticalOffsetProperty, value); }
        }

        // Using a DependencyProperty as the backing store for VerticalOffset.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty VerticalOffsetProperty =
            DependencyProperty.Register("VerticalOffset", typeof(double), typeof(GridViewEx), new PropertyMetadata(0, OnVerticalOffsetPropertyChanged));

        private static void OnVerticalOffsetPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var a = (d as GridViewEx)._scrollViewer.ViewportHeight;
            var b = (d as GridViewEx)._scrollViewer.ExtentHeight;
            var c = (d as GridViewEx)._scrollViewer.VerticalOffset;
            if ((b - a - c) <= 100)
            {
                (d as GridViewEx).OnScrollToBottom();
            }
        }


        //public event EventHandler ShakeReflesh;
        //public virtual void OnShakeReflesh()
        //{
        //    if (ShakeReflesh != null)
        //    {
        //        ShakeReflesh(this, new EventArgs());
        //    }
        //}

        public void ScrollToTop()
        {
            _scrollViewer.ChangeView(0, 0, 1);
        }
    }
}
