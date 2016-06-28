using MVVM_Single_Window_Application_Boilerplate.Helpers;
using System.ComponentModel;

namespace MVVM_Single_Window_Application_Boilerplate.ViewModels
{
    abstract class BaseViewModel : INotifyPropertyChanged
    {

        public PageSwitcher PageSwitcher
        {
            get { return PageSwitcher.Instance; }
        }

        #region INPC Members
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        #region INCP Methods
        public void RaisePropertyChanged(string propertyName)
        {
            //Use a handler to prevent threading issues
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
