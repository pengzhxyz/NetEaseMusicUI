using System;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using GalaSoft.MvvmLight.Threading;
using GalaSoft.MvvmLight.Views;
using Microsoft.Practices.ServiceLocation;
using NetEaseMusicUI.Model;
using System.Collections.ObjectModel;

namespace NetEaseMusicUI.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private readonly IDataService _dataService;
        private readonly INavigationService _navigationService;

        private RelayCommand<string> _navigateCommand;


        #region Properties

        #region PageMenuItemList

        /// <summary>
        /// The <see cref="PageMenuItemList" /> property's name.
        /// </summary>
        public const string PageMenuItemListPropertyName = "PageMenuItemList";

        private ObservableCollection<MenuItemSource> _pageMenuItemList = new ObservableCollection<MenuItemSource>();

        /// <summary>
        /// Sets and gets the PageMenuItemList property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public ObservableCollection<MenuItemSource> PageMenuItemList
        {
            get
            {
                return _pageMenuItemList;
            }

            set
            {
                if (_pageMenuItemList == value)
                {
                    return;
                }

                _pageMenuItemList = value;
                RaisePropertyChanged(PageMenuItemListPropertyName);
            }
        }
        #endregion

        #region MyMusicMenuItemList
        /// <summary>
        /// The <see cref="MyMusicMenuItemList" /> property's name.
        /// </summary>
        public const string MyMusicMenuItemListPropertyName = "MyMusicMenuItemList";

        private ObservableCollection<MenuItemSource> _myMusicMenuItemList = new ObservableCollection<MenuItemSource>();

        /// <summary>
        /// Sets and gets the MyMusicMenuItemList property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public ObservableCollection<MenuItemSource> MyMusicMenuItemList
        {
            get
            {
                return  _myMusicMenuItemList;
            }

            set
            {
                if ( _myMusicMenuItemList == value)
                {
                    return;
                }

                 _myMusicMenuItemList = value;
                RaisePropertyChanged(MyMusicMenuItemListPropertyName);
            }
        }
        #endregion

        #region CreatedSongListMenuItemList
        /// <summary>
        /// The <see cref="CreatedSongListMenuItemList" /> property's name.
        /// </summary>
        public const string CreatedSongListMenuItemListPropertyName = "CreatedSongListMenuItemList";

        private ObservableCollection<MenuItemSource> _createdSongListMenuItemList = new ObservableCollection<MenuItemSource>();

        /// <summary>
        /// Sets and gets the CreatedSongListMenuItemList property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public ObservableCollection<MenuItemSource> CreatedSongListMenuItemList
        {
            get
            {
                return _createdSongListMenuItemList;
            }

            set
            {
                if (_createdSongListMenuItemList == value)
                {
                    return;
                }

                _createdSongListMenuItemList = value;
                RaisePropertyChanged(CreatedSongListMenuItemListPropertyName);
            }
        }
        #endregion

        #region FavSongListMenuItemList
        /// <summary>
        /// The <see cref="FavSongListMenuItemList" /> property's name.
        /// </summary>
        public const string FavSongListMenuItemListPropertyName = "FavSongListMenuItemList";

        private ObservableCollection<MenuItemSource> _FavSongListMenuItemList = new ObservableCollection<MenuItemSource>();

        /// <summary>
        /// Sets and gets the FavSongListMenuItemList property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public ObservableCollection<MenuItemSource> FavSongListMenuItemList
        {
            get
            {
                return _FavSongListMenuItemList;
            }

            set
            {
                if (_FavSongListMenuItemList == value)
                {
                    return;
                }

                _FavSongListMenuItemList = value;
                RaisePropertyChanged(FavSongListMenuItemListPropertyName);
            }
        }
        #endregion
        #endregion

        public RelayCommand<string> NavigateCommand
        {
            get
            {
                return _navigateCommand
                       ?? (_navigateCommand = new RelayCommand<string>(
                           p => _navigationService.NavigateTo(ViewModelLocator.SecondPageKey, p),
                           p => !string.IsNullOrEmpty(p)));
            }
        }


        public MainViewModel(
            IDataService dataService,
            INavigationService navigationService)
        {
            _dataService = dataService;
            _navigationService = navigationService;
            Initialize();
        }
        private async Task Initialize()
        {
            this.PageMenuItemList = new ObservableCollection<MenuItemSource>()
            {
                new MenuItemSource(Windows.UI.Xaml.Controls.Symbol.Find,"搜索",typeof(SecondPage)),
                new MenuItemSource(Windows.UI.Xaml.Controls.Symbol.Audio,"发现音乐",typeof(SecondPage)),
                new MenuItemSource(Windows.UI.Xaml.Controls.Symbol.People,"朋友",typeof(SecondPage)),
            };

            this.MyMusicMenuItemList = new ObservableCollection<MenuItemSource>()
            {
                new MenuItemSource(Windows.UI.Xaml.Controls.Symbol.OpenLocal,"本地音乐",typeof(SecondPage)),
                new MenuItemSource(Windows.UI.Xaml.Controls.Symbol.Download,"下载管理",typeof(SecondPage)),
                new MenuItemSource(Windows.UI.Xaml.Controls.Symbol.Add,"我的收藏",typeof(SecondPage)),
                new MenuItemSource(Windows.UI.Xaml.Controls.Symbol.World,"我的电台",typeof(SecondPage)),
            };
        }
    }
}