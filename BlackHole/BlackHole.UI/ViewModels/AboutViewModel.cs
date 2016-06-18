using BlackHole.UI;
using BlackHole.UI.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Store;
using Windows.Networking.Connectivity;
using Windows.System;
using Windows.UI.Popups;

namespace BlackHole.UI.ViewModels
{
    public class AboutViewModel : BasePropertyChanged
    {
        private MessageDialog _dialog;

        private bool _donated;
        public bool donated
        {
            get { return _donated; }
            set
            {
                _donated = value;
                RaisePropertyChanged(nameof(donated));
            }
        }

        private bool _working;
        public bool working
        {
            get { return _working; }
            set
            {
                _working = value;
                RaisePropertyChanged(nameof(working));
            }
        }

        private ICommand _SendEmailCommand;
        public ICommand SendEmailCommand
        {
            get
            {
                if (_SendEmailCommand == null)
                {
                    _SendEmailCommand = new Command(SendEmail, CanCommand);
                }
                return _SendEmailCommand;
            }
            set { _SendEmailCommand = value; }
        }

        private ICommand _RateAndReviewCommand;
        public ICommand RateAndReviewCommand
        {
            get
            {
                if (_RateAndReviewCommand == null)
                {
                    _RateAndReviewCommand = new Command(RateAndReview, CanCommand);
                }
                return _RateAndReviewCommand;
            }
            set { _RateAndReviewCommand = value; }
        }

        private ICommand _DonateCommand;
        public ICommand DonateCommand
        {
            get
            {
                if (_DonateCommand == null)
                {
                    _DonateCommand = new Command(Donate, CanCommand);
                }
                return _DonateCommand;
            }
            set { _DonateCommand = value; }
        }

        public AboutViewModel()
        {
            HasDonated();
        }

        private bool HasDonated()
        {
            //if (((Application)Application.Current).licenseInfo.ProductLicenses["Donation"].IsActive)
            //{
            //    donated = true;
            //}
            //else
            //{
            //    donated = false;
            //}
            return false;
        }

        private bool CanCommand()
        {
            if (working)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private async void SendEmail()
        {
            var mailto = new Uri("mailto:?to=blackholeapp@outlook.com&subject=Black Hole Windows Feedback");
            await Launcher.LaunchUriAsync(mailto);
        }

        private async void RateAndReview()
        {
            string packageFamilyName = Package.Current.Id.FamilyName;
            await Launcher.LaunchUriAsync(new Uri("ms-windows-store:REVIEW?PFN=" + packageFamilyName));
        }

        private async void Donate()
        {
            //For Testing Only
            //StorageFile file = await StorageFile.GetFileFromApplicationUriAsync(new Uri("ms-appx:///DesignData/WindowsStoreProxy.xml"));
            //await CurrentAppSimulator.ReloadSimulatorAsync(file);


            ConnectionProfile connections = NetworkInformation.GetInternetConnectionProfile();
            if (connections != null && connections.GetNetworkConnectivityLevel() == NetworkConnectivityLevel.InternetAccess)
            {
                try
                {
                    working = true;
                    //await CurrentApp.RequestProductPurchaseAsync("donation");
                }
                catch (ArgumentException)
                {
                    await PurchaseError();
                }
                catch (COMException)
                {
                    await PurchaseError();
                }
                catch (OutOfMemoryException)
                {
                    await PurchaseError();
                }
                finally
                {
                    HasDonated();
                    working = false;
                }
            }
            else
            {
                _dialog = new MessageDialog("The Windows Store couldn't be reached, please check your internet connection and try again", "Connection Error");
                await _dialog.ShowAsync();
            }
        }

        private async Task PurchaseError()
        {
            _dialog = new MessageDialog("Something went wrong with your donation, please check your internet connection and try again", "Error");
            await _dialog.ShowAsync();
        }
    }
}
