using BlackHole.UI.Helpers;
using Windows.Storage;

namespace BlackHole.UI.ViewModels
{
    public class SettingsViewModel : BasePropertyChanged
    {
        private bool _isNotPhone;
        public bool isNotPhone
        {
            get { return _isNotPhone; }
            set
            {
                _isNotPhone = value;
                RaisePropertyChanged(nameof(isNotPhone));
            }
        }

        private bool _canDrag;
        public bool canDrag
        {
            get { return _canDrag; }
            set
            {
                _canDrag = value;
                RaisePropertyChanged(nameof(canDrag));
                UpdateCanDrag();
            }
        }

        public SettingsViewModel()
        {
            isNotPhone = DeviceTypeHelper.GetDeviceType() == DeviceType.Phone ? false : true;
            canDrag = isNotPhone ? GetCanDrag() : false; 
        }

        private bool GetCanDrag()
        {
            return (bool)ApplicationData.Current.RoamingSettings.Values[((Application)Windows.UI.Xaml.Application.Current).canDragKey];
        }

        private void UpdateCanDrag()
        {
            ApplicationData.Current.RoamingSettings.Values[((Application)Windows.UI.Xaml.Application.Current).canDragKey] = canDrag;
        }
    }
}
