using System;
using System.Collections.Generic;
using System.Text;

namespace YetAnotherWeatherApp.Services
{
    public static class DeviceOrientationHandler
    {
        public static Orientation GetOrientation { get; set; }
        public enum Orientation
        {
            None,
            Portrait,
            Landscape
        }
    }
}
