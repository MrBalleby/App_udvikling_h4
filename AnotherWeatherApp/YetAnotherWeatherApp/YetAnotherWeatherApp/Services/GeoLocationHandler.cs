using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using YetAnotherWeatherApp.Models;
using Xamarin.Essentials;

namespace YetAnotherWeatherApp.Services
{
    public class GeoLocationHandler
    {
        public GeoLocationModel GetCoordinates()
        {
            return GetCorrdinatesAsync().Result;
        }
        private async Task<GeoLocationModel> GetCorrdinatesAsync()
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
