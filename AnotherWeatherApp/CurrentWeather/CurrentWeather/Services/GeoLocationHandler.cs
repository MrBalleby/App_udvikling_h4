using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CurrentWeather.Models;
using Xamarin.Essentials;

namespace CurrentWeather.Services
{
    public class GeoLocationHandler
    {
        public async Task<GeoLocationModel> GetCorrdinatesAsync()
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
                return null;
            }
            catch (FeatureNotSupportedException fnsEx)
            {
                return null;
            }
            catch (FeatureNotEnabledException fneEx)
            {
                return null;
            }
            catch (PermissionException pEx)
            {
                return null;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
