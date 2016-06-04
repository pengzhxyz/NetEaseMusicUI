using NetEaseMusicUI.Model;
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
    public sealed partial class MenuItem : UserControl
    {




        public MenuItemSource MenuSource
        {
            get { return (MenuItemSource)GetValue(MenuSourceProperty); }
            set { SetValue(MenuSourceProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MenuSource.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MenuSourceProperty =
            DependencyProperty.Register("MenuSource", typeof(MenuItemSource), typeof(MenuItem), new PropertyMetadata(null,(s,e)=> 
            {
                var menuitem = s as MenuItem;
                if (menuitem!=null)
                {
                    menuitem.icon.Symbol = (e.NewValue as MenuItemSource).Symbol;
                    menuitem.menuNameTB.Text = (e.NewValue as MenuItemSource).DisplayName;
                }
            }));




        public MenuItem()
        {
            this.InitializeComponent();
        }
    }
}
