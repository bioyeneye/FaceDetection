using System;
using System.Drawing;
using System.Windows.Forms;
using FaceDetection.Integration;
using FaceDetection.Integration.Extension;
using FaceDetection.Integration.Helper;
using FaceDetection.Integration.Response;
using Microsoft.Azure.CognitiveServices.Vision.Face;
using Newtonsoft.Json;

namespace FaceDetection.Test
{
    public partial class Form1 : Form
    {
        private string picturePath = String.Empty;
        private Face _face;
        private Driver _driver;

        private readonly IFaceClient faceClient;

        public Form1()
        {
            InitializeComponent();
            btnAnalysis.Enabled = false;
            _driver = new Driver(Constants.subscriptionKey, Constants.uriBase);
            _face = new Face(_driver);
            faceClient = new FaceClient(
                new ApiKeyServiceClientCredentials(Constants.subscriptionKey),
                new System.Net.Http.DelegatingHandler[] { });

            faceClient.BaseUri = new Uri(Constants.uriBaseFrom);
        }

        private void btnSelectPicture_Click(object sender, EventArgs e)
        {

            var dialog = new OpenFileDialog
            {
                Multiselect = false,
                Title = @"Select a picture",
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures),
                Filter = @"PNG (*.png)|*.png|JPG (*.jpg)|*.jpg|All files (*.*)|*.*"
            };

     
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                picturePath = dialog.FileName;
                btnAnalysis.Enabled = true;
                pictureBox1.Image = Image.FromFile(picturePath);
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }

        private async void btnAnalysis_Click(object sender, EventArgs e)
        {
            /*Install-Package Microsoft.Azure.CognitiveServices.Vision.Face -Version 2.0.0-preview*/

            var dataFromLibrary = await _face.ProcessAndAnalysisUsingImagePath(picturePath);
            var objectData = JsonConvert.DeserializeObject<FaceResponse[]>(dataFromLibrary);
            txtResult.Text = dataFromLibrary;

            switch (objectData.Length)
            {
                case 0: MessageBox.Show("No face detected");
                    break;

                case 1: MessageBox.Show("Can proceed with storage");
                    break;

                default: MessageBox.Show("Take a single person selfie");
                    break;
            }

            MessageBox.Show(objectData[0].IsMale().ToString());
        
            /*IList<FaceAttributeType> faceAttributes =
                new FaceAttributeType[]
                {
                    FaceAttributeType.Gender, FaceAttributeType.Age,
                    FaceAttributeType.Smile, FaceAttributeType.Emotion,
                    FaceAttributeType.Glasses, FaceAttributeType.Hair,
                    
                };
            IList<DetectedFace> faceList;

            try
            {
                using (Stream imageFileStream = File.OpenRead(picturePath))
                {
                    // The second argument specifies to return the faceId, while
                    // the third argument specifies not to return face landmarks.
                    faceList =
                        await faceClient.Face.DetectWithStreamAsync(
                            imageFileStream, true, false, faceAttributes);

                    MessageBox.Show(faceList.Count.ToString());
                }
            }
            // Catch and display Face API errors.
            catch (APIErrorException f)
            {
                MessageBox.Show(f.Message);
            }
            // Catch and display all other errors.
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }*/

        }
    }
}
