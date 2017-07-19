using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Face;
using Emgu.CV.Structure;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaceRecognition
{
    class RecognizerEngine
    {
        private FaceRecognizer _faceRecognizer;
        private DataStoreAccess _dataStoreAccess;
        private String _recognizerFilePath;

        public RecognizerEngine(String databasePath, String recognizerFilePath)
        {
            _recognizerFilePath = recognizerFilePath;
            _dataStoreAccess = new DataStoreAccess(databasePath);
            _faceRecognizer = new LBPHFaceRecognizer(threshold:53); //currently put 53 with 200x200,last test 55 with 200x200 work ok with some bad rec, 78 with 100x100 work ok//should play little more with this number. >100 -> almost recognize all time         //new EigenFaceRecognizer(80, double.PositiveInfinity);
        }

        public bool TrainRecognizer()
        {
            var allFaces = _dataStoreAccess.CallFaces("ALL_USERS");
            if (allFaces != null)
            {
                var faceImages = new Image<Gray, byte>[allFaces.Count];
                var faceLabels = new int[allFaces.Count];
                for (int i = 0; i < allFaces.Count; i++)
                {
                    Stream stream = new MemoryStream();
                    stream.Write(allFaces[i].Image, 0, allFaces[i].Image.Length);
                    var faceImage = new Image<Gray, byte>(new Bitmap(stream));
                    faceImages[i] = faceImage.Resize(200, 200, Inter.Cubic);
                    faceLabels[i] = allFaces[i].UserId;
                }


                _faceRecognizer.Train(faceImages, faceLabels);
                _faceRecognizer.Save(_recognizerFilePath);
            }
            return true;

        }

        public void LoadRecognizerData()
        {
            _faceRecognizer.Load(_recognizerFilePath);
        }

        public int RecognizeUser(Image<Gray, byte> userImage)
        {
            /*  Stream stream = new MemoryStream();
              stream.Write(userImage, 0, userImage.Length);
              var faceImage = new Image<Gray, byte>(new Bitmap(stream));*/
            try
            {
                _faceRecognizer.Load(_recognizerFilePath);
            
                var result = _faceRecognizer.Predict(userImage.Resize(200, 200, Inter.Cubic,false));
                System.Diagnostics.Debug.WriteLine(result.Label + " - " + result.Distance);
                return result.Label;//result.Distance < 100 ? result.Label : -1;
            }
            catch (Exception ex) { if(ex.Message!= "OpenCV: Unsupported file storage format") System.Windows.Forms.MessageBox.Show(ex.Message);
                }

            return -1;
            
        }
    }
}
