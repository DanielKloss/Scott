using Windows.System.Profile;
using Windows.UI.ViewManagement;

namespace BlackHole.UI.Helpers
{
    public enum DeviceType
    {
        Phone,
        Desktop,
        Tablet,
        IOT,
        SurfaceHub,
        Other
    }

    public static class DeviceTypeHelper
    {
        public static DeviceType GetDeviceType()
        {
            switch (AnalyticsInfo.VersionInfo.DeviceFamily)
            {
                case "Windows.Mobile":
                    return DeviceType.Phone;
                case "Windows.Desktop":
                    return UIViewSettings.GetForCurrentView().UserInteractionMode == UserInteractionMode.Mouse ? DeviceType.Desktop : DeviceType.Tablet;
                case "Windows.Universal":
                    return DeviceType.IOT;
                case "Windows.Team":
                    return DeviceType.SurfaceHub;
                default:
                    return DeviceType.Other;
            }
        }
    }
}
