using MVVM_Single_Window_Application_Boilerplate.ViewModels;
using MVVM_Single_Window_Application_Boilerplate.Views;
using System.Collections.Generic;
using System.Windows.Controls;

/// <summary>
/// A simple class that allows a user to change views (UserControls) within a single-window application
/// To add a view to the list, add a private Method and a pu
/// </summary>
namespace MVVM_Single_Window_Application_Boilerplate.Helpers
{
    class PageSwitcher : BaseViewModel
    {
        #region Singleton
        private static PageSwitcher _instance;
        private PageSwitcher() { }
        public static PageSwitcher Instance
        {
            get { return _instance ?? (_instance = new PageSwitcher()); }
        }
        #endregion Singleton

        #region Properties and Members
        private Dictionary<string, UserControl> _views;
        private Dictionary<string, UserControl> Views
        {
            get
            {
                if (_views == null)
                    _views = new Dictionary<string, UserControl>()
                    {
                        { "PageOneView", Instance.PageOneView },
                        { "PageTwoView", Instance.PageTwoView }
                    };
                return _views;
            }
        }

        private UserControl _currentView;
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

        private UserControl _pageOneView;
        private UserControl PageOneView
        {
            get
            {
                if (_pageOneView == null)
                    _pageOneView = new PageOneView();
                return _pageOneView;
            }
        }

        private UserControl _pageTwoView;
        private UserControl PageTwoView
        {
            get
            {
                if (_pageTwoView == null)
                    _pageTwoView = new PageTwoView();
                return _pageTwoView;
            }
        }
        #endregion Properties and Members

        #region Methods
        /// <summary>
        /// Change the View, typically done from the ViewModel page (using an ICommand)
        /// </summary>
        /// <param name="requestedView">Passed in by the RelayCommand</param>
        public void ChangeView(object requestedView)
        {
            string newView = requestedView.ToString();

            //Throw an error if the View is not in the Views dictionary
            if (!Views.ContainsKey(newView))
                throw new KeyNotFoundException(string.Format("{0} is not a valid View", newView));

            //Update the CurrentView
            CurrentView = Views[newView];
        }
        #endregion Methods
    }
}
