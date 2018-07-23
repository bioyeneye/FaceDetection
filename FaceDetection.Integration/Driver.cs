using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaceDetection.Integration
{
    public class Driver
    {
        public string ApiKey { get; set; }
        public string BaseUrl { get; set; }
        public string RequestParameters { get; set; }

        public Driver(string apiKey, string baseUrl, string requestParameters = null)
        {
            ApiKey = apiKey;
            BaseUrl = baseUrl;
            RequestParameters = requestParameters;
        }
    }
}
