using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace NetEaseMusicUI.Model
{
    /// <summary>
    /// 左边栏的MenuItem的Source，包裹歌单列表等
    /// </summary>
    public class MenuItemSource
    {
        public MenuItemSource(Symbol symbol,string displayName,Type pageType)
        {
            Symbol = symbol;
            DisplayName = displayName;
            PageType = pageType;
        }
        public Symbol Symbol { get; set; }
        public string DisplayName { get; set; }
        public Type PageType { get; set; }
    }
}
