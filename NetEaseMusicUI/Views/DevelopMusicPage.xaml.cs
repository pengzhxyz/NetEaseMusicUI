using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// “空白页”项模板在 http://go.microsoft.com/fwlink/?LinkId=234238 上提供

namespace NetEaseMusicUI.Views
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class DevelopMusicPage : Page
    {
        public DevelopMusicPage()
        {
            this.InitializeComponent();
            this.Loaded += DevelopMusicPage_Loaded;
        }

        private void DevelopMusicPage_Loaded(object sender, RoutedEventArgs e)
        {

            // Set the CarouselView source
            this.carousel.ItemImageSource = new List<string>
            {
                "http://p4.music.126.net/yswUYtWoHBnXz4uYq4HZEg==/1409573914070721.jpg",
                "http://p3.music.126.net/Ly3B9Twjb2O9vMPjZYYZuw==/1424967076836399.jpg",
                "http://p4.music.126.net/l0ZAQC3npuC2vC8UfRz-HA==/1379887100071771.jpg",
                "http://p4.music.126.net/TaCcthvJqZTDci_v4Ca2Pg==/1407374890545932.jpg",
                "http://p3.music.126.net/K-75OTYxan0Qe81l4s_x4w==/1373290029966926.jpg",
                "http://p3.music.126.net/4G7osnjysCp8_VcjoQ0oXA==/1415071471085570.jpg"
            };
        }
    }
}
