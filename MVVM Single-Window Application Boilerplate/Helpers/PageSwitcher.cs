using MVVM_Single_Window_Application_Boilerplate.ViewModels;
using MVVM_Single_Window_Application_Boilerplate.Views;
using System.Windows.Controls;

namespace MVVM_Single_Window_Application_Boilerplate.Helpers
{
    class PageSwitcher : BaseViewModel
    {
        UserControl _pageOneView;
        UserControl _pageTwoView;
        UserControl _currentView;

        #region Singleton
        private static PageSwitcher _instance;
        private PageSwitcher() { }
        public static PageSwitcher Instance
        {
            get { return _instance ?? (_instance = new PageSwitcher()); }
        }
        #endregion


        public UserControl PageOneView
        {
            get
            {
                if (_pageOneView == null)
                    _pageOneView = new PageOneView();
                return _pageOneView;
            }
        }

        public UserControl PageTwoView
        {
            get
            {
                if (_pageTwoView == null)
                    _pageTwoView = new PageTwoView();
                return _pageTwoView;
            }
        }

        public UserControl CurrentView
        {
            get
            {
                if (_currentView == null)
                    _currentView = PageOneView;
                return _currentView;
            }
            set
            {
                if (_currentView != value)
                    _currentView = value;
                RaisePropertyChanged("CurrentView");
            }
        }
    }
}
