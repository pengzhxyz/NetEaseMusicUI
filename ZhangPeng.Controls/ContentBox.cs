using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Documents;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Markup;
using Windows.UI.Xaml.Media;

// The Templated Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234235

namespace ZhangPeng.Controls
{
    [ContentProperty(Name =nameof(Content))]
    public sealed class ContentBox : Control
    {
        public ContentBox()
        {
            this.DefaultStyleKey = typeof(ContentBox);
        }



        public string Header
        {
            get { return (string)GetValue(HeaderProperty); }
            set { SetValue(HeaderProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Header.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty HeaderProperty =
            DependencyProperty.Register("Header", typeof(string), typeof(ContentBox), new PropertyMetadata(string.Empty));



        public string MoreText
        {
            get { return (string)GetValue(MoreTextProperty); }
            set { SetValue(MoreTextProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MoreText.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MoreTextProperty =
            DependencyProperty.Register("MoreText", typeof(string), typeof(ContentBox), new PropertyMetadata("更多"));




        public ImageSource IconSource
        {
            get { return (ImageSource)GetValue(IconSourceProperty); }
            set { SetValue(IconSourceProperty, value); }
        }

        // Using a DependencyProperty as the backing store for IconSource.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IconSourceProperty =
            DependencyProperty.Register("IconSource", typeof(ImageSource), typeof(ContentBox), new PropertyMetadata(null));



        public object Content
        {
            get { return (object)GetValue(ContentProperty); }
            set { SetValue(ContentProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Content.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ContentProperty =
            DependencyProperty.Register("Content", typeof(object), typeof(ContentBox), new PropertyMetadata(null));


    }
}
