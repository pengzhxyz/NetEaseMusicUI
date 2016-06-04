using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Documents;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Shapes;

// The Templated Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234235

namespace ZhangPeng.Controls
{
    public sealed class RoundImage : Control
    {




        public string Source
        {
            get { return (string)GetValue(SourceProperty); }
            set { SetValue(SourceProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Source.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SourceProperty =
            DependencyProperty.Register("Source", typeof(string), typeof(RoundImage), new PropertyMetadata(null,(s,e)=> {
                var rimage = (s as RoundImage);
                if (rimage!=null)
                {
                    if (rimage._ellipse!=null)
                    {
                        Uri uristring = new Uri((string)e.NewValue);
                        rimage._ellipse.Fill = new ImageBrush() { ImageSource=new BitmapImage(uristring)};
                    }
                }
            }));



        private Ellipse _ellipse;

        public RoundImage()
        {
            this.DefaultStyleKey = typeof(RoundImage);
            this.Loaded += RoundImage_Loaded;
        }

        private void RoundImage_Loaded(object sender, RoutedEventArgs e)
        {
            _ellipse = this.GetTemplateChild("ellipse") as Ellipse;
            Uri uristring = new Uri(Source);
            _ellipse.Fill = new ImageBrush() { ImageSource = new BitmapImage(uristring) };
        }

        

    }
}
