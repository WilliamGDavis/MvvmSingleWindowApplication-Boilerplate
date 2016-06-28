using MVVM_Single_Window_Application_Boilerplate.Helpers;
using System.Windows.Input;

namespace MVVM_Single_Window_Application_Boilerplate.ViewModels
{
    class PageOneViewModel
    {
        #region UpdateControl
        RelayCommand _updateControl;
        public ICommand UpdateControl
        {
            get
            {
                if (_updateControl == null)
                    _updateControl = new RelayCommand(param => UpdateControlExecute(), param => CanUpdateControlExecute()); //Pass the "CommandParameter" from the XAML view

                return _updateControl;
            }
        }

        void UpdateControlExecute()
        {
            PageSwitcher.Instance.CurrentView = PageSwitcher.Instance.PageTwoView;
        }

        bool CanUpdateControlExecute()
        {
            return true;
        }
        #endregion - UpdateControl
    }
}
