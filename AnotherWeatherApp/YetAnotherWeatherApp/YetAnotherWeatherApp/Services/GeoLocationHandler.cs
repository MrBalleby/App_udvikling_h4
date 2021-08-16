using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using YetAnotherWeatherApp.Models;
using Xamarin.Essentials;
using System.ComponentModel;

namespace YetAnotherWeatherApp.Services
{
    public static class GeoLocationHandler
    {
        public static async Task<GeoLocationModel> GetCorrdinatesAsync()
        {
            try
            {
                var location = await Geolocation.GetLastKnownLocationAsync();

                if (location != null)
                {
                    GeoLocationModel geoLocationModel = new GeoLocationModel()
                    {
                        lat = location.Latitude.ToString(),
                        lon = location.Longitude.ToString()
                    };
                    return geoLocationModel;
                }
                ErrorModel.Instance.ErrorMessage = "Could not get Location";
                return null;
            }
            catch (FeatureNotSupportedException fnsEx)
            {
                ErrorModel.Instance.ErrorMessage = "No GPS is available";
                return null;
            }
            catch (FeatureNotEnabledException fneEx)
            {
                ErrorModel.Instance.ErrorMessage = "GPS not enabled";
                return null;
            }
            catch (PermissionException pEx)
            {
                ErrorModel.Instance.ErrorMessage = "GPS permission error";
                return null;
            }
            catch (Exception ex)
            {
                ErrorModel.Instance.ErrorMessage = "An unknown error occured";
                return null;
            }
        }
    }
}
