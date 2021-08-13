using System;
using System.Collections.Generic;
using System.Text;

namespace YetAnotherWeatherApp.Models
{
    public class ErrorModel
    {
        private static ErrorModel instance = null;
        public ErrorModel() { }
        public static ErrorModel Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ErrorModel();
                }
                return instance;
            }
        }
        public string ErrorMessage { get; set; }
    }
}
