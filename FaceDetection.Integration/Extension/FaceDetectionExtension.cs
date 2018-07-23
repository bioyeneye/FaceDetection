using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FaceDetection.Integration.Response;

namespace FaceDetection.Integration.Extension
{
    public static class FaceDetectionExtension
    {
        public static bool IsMale(this FaceResponse response)
        {
            return response.faceAttributes.gender == "male";
        }
    }
}
