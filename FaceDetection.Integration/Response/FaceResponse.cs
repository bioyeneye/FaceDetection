using FaceDetection.Integration.Model;

namespace FaceDetection.Integration.Response
{
    public class FaceResponse
    {
        public string faceId { get; set; }
        public FaceRectangle faceRectangle { get; set; }
        public FaceAttributes faceAttributes { get; set; }
    }

}
