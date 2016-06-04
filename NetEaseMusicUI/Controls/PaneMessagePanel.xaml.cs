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

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace NetEaseMusicUI.Controls
{
    public sealed partial class PaneMessagePanel : UserControl
    {

        public bool IsWideMode
        {
            get { return (bool)GetValue(IsWideModeProperty); }
            set { SetValue(IsWideModeProperty, value); }
        }

        // Using a DependencyProperty as the backing store for IsWideMode.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IsWideModeProperty =
            DependencyProperty.Register("IsWideMode", typeof(bool), typeof(PaneMessagePanel), new PropertyMetadata(true,(s,e)=> 
            {
                var p = s as PaneMessagePanel;
                if (p!=null)
                {
                    p.SetItemsPostion((bool)e.NewValue);
                }
            }));



        public PaneMessagePanel()
        {
            this.InitializeComponent();
            this.Loaded += (s,e)=>
            {
                SetItemsPostion(this.IsWideMode);
            };
        }


        private void SetItemsPostion(bool isWide)
        {
            if (isWide)
            {
                this.Width = (double)App.Current.Resources["PaneOpenWidth"];
                name.Visibility = Visibility.Visible;

                Grid.SetColumn(image, 0);
                Grid.SetColumnSpan(image, 1);

                Grid.SetColumn(name, 1);
                Grid.SetColumnSpan(name, 1);

                Grid.SetColumn(messageBT, 2);
                Grid.SetColumnSpan(messageBT, 1);

                Grid.SetColumn(settingsBT, 3);
                Grid.SetColumnSpan(settingsBT, 1);

                Grid.SetRow(image, 0);
                Grid.SetRowSpan(image, 3);

                Grid.SetRow(name, 0);
                Grid.SetRowSpan(name, 3);

                Grid.SetRow(messageBT, 0);
                Grid.SetRowSpan(messageBT, 3);

                Grid.SetRow(settingsBT, 0);
                Grid.SetRowSpan(settingsBT, 3);

            }
            else
            {
                this.Width = (double)App.Current.Resources["PaneCompactWidth"];

                name.Visibility = Visibility.Collapsed;

                Grid.SetColumn(image, 0);
                Grid.SetColumnSpan(image, 4);

                //Grid.SetColumn(name, 0);
                //Grid.SetColumnSpan(name, 4);

                Grid.SetColumn(messageBT, 0);
                Grid.SetColumnSpan(messageBT, 4);

                Grid.SetColumn(settingsBT, 0);
                Grid.SetColumnSpan(settingsBT, 4);


                Grid.SetRow(image, 0);
                Grid.SetRowSpan(image, 1);

                //Grid.SetRow(name, 0);
                //Grid.SetRowSpan(name, 3);

                Grid.SetRow(messageBT, 1);
                Grid.SetRowSpan(messageBT, 1);

                Grid.SetRow(settingsBT, 2);
                Grid.SetRowSpan(settingsBT, 1);
            }
        }
    }
}
