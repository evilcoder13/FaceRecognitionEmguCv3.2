using Emgu.CV;
using Emgu.Util;
using Emgu.CV.Structure;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Emgu.CV.CvEnum;
using System.Diagnostics;
namespace FaceRecognition
{
    public partial class MainForm : Form
    {
        System.ComponentModel.BackgroundWorker bckGroundTrainer = new System.ComponentModel.BackgroundWorker();

        public MainForm()
        {
            InitializeComponent();
            this.bckGroundTrainer.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bckGroundTrainer_DoWork);
            this.bckGroundTrainer.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bckGroundTrainer_RunWorkerCompleted);
        }


        private void bckGroundTrainer_DoWork(object sender, DoWorkEventArgs e)
        {

            var worker = sender as BackgroundWorker;
            e.Result = TrainRecognizer(worker, e);
        }

        private bool TrainRecognizer(BackgroundWorker worker, DoWorkEventArgs e)
        {
            if (worker.CancellationPending)
            {
                e.Cancel = true;
            }
            else
            {
                var hasTrainedRecognizer = _recognizerEngine.TrainRecognizer();
                return hasTrainedRecognizer;
            }
            return false;
        }

        private void bckGroundTrainer_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                MessageBox.Show(e.Error.Message);
            }
            else if (e.Cancelled)
            {
                lblUsername.Text = "Training has been cancelled!";
            }
            else
            {
                var result = (bool)e.Result;
                lblUsername.Text = result ? "Training has been completed successfully!" : "Training could not be completed, An Error Occurred";
            }
            //btnTrain.Enabled = true;
        }

        VideoCapture _capture = new VideoCapture(Emgu.CV.CvEnum.CaptureType.Winrt);
        Image<Bgr, byte> ImageFrame;
        private CascadeClassifier _cascadeClassifier;
        private bool _hasRecognizedFace;
        private RecognizerEngine _recognizerEngine;
        private readonly String _databasePath = Application.StartupPath + "/face_store.db";
        private readonly String _trainerDataPath = Application.StartupPath + "/traineddata";
        private void MainForm_Load(object sender, EventArgs e)
        {
            //Train the recognizer here
            _recognizerEngine = new RecognizerEngine(_databasePath, _trainerDataPath);
            bckGroundTrainer.RunWorkerAsync();
            _cascadeClassifier = new CascadeClassifier(Application.StartupPath + "/haarcascade_frontalface_alt2.xml");
            //_capture = new VideoCapture(Emgu.CV.CvEnum.CaptureType.Winrt);
            //Application.Idle += new EventHandler(ProcessFrame);
            //Mat frame = new Mat();
            //_capture.Retrieve(frame);
            //imgCamUser.Image = frame;
            //if (frame != null)
            //        imgCamUser.Image = ToBitmapSource(frame);
        }

        private void btnCapture_Click(object sender, EventArgs e)
        {
            if (_capture == null)
            {
                try
                {
                    _capture = new VideoCapture(Emgu.CV.CvEnum.CaptureType.Winrt);
                    
                }
                catch (NullReferenceException excpt)
                {
                    MessageBox.Show(excpt.Message);
                }
            }
            //ProcessFrame(null, null);
            if (_capture != null)
            {
                if (captureInProgress)
                {  //if camera is getting frames then stop the capture and set button Text
                    // "Start" for resuming capture
                    Application.Idle -= ProcessFrame;
                }
                else
                {
                    //if camera is NOT getting frames then start the capture and set button
                    // Text to "Stop" for pausing capture
                    Application.Idle += ProcessFrame;
                }

                captureInProgress = !captureInProgress;
            }


        }
        bool captureInProgress=false;
        void ProcessFrame(object sender, EventArgs arg)
        {
            //_cascadeClassifier = new CascadeClassifier(Application.StartupPath + "/haarcascade_frontalface_default.xml");

            using (ImageFrame = _capture.QueryFrame().ToImage<Bgr, byte>())
            {

                if (ImageFrame != null)
                {
                    var grayframe = ImageFrame.Convert<Gray, byte>();
                    var faces = _cascadeClassifier.DetectMultiScale(grayframe, 1.1, 10, Size.Empty); //the actual face detection happens here
                    int faceIndex = 1;
                    foreach (var face in faces)
                    {
                        ImageFrame.Draw(face, new Bgr(Color.BurlyWood), 3); //the detected face(s) is highlighted here using a box that is drawn around it/them
                        int predictedUserId;
                        Bitmap map = ImageFrame.Copy(face).Bitmap;
                        if (faceIndex == 1)
                            imageBox1.Image = new Image<Rgb, byte>(map);
                        else if (faceIndex==2)
                            imageBox2.Image = new Image<Rgb, byte>(map);
                        else if (faceIndex==3)
                            imageBox3.Image = new Image<Rgb, byte>(map);
                        faceIndex++;
                        try
                        {
                            predictedUserId = _recognizerEngine.RecognizeUser(new Image<Gray, byte>(map));
                            //Debug.WriteLine(predictedUserId);
                        }
                        catch { predictedUserId = -1; }
                        if (predictedUserId == -1)
                        {
                            saveAFace(face, map);
                        }
                        else
                        {
                            //proceed to documents library
                            IDataStoreAccess dataStore = new DataStoreAccess(_databasePath);
                            var username = dataStore.GetUsername(predictedUserId);
                            if (username != String.Empty)
                            {
                                lblUsername.Text =
                                    String.Format("{1} Face Recognized as {0}",username,faces.Length);
                            }
                            else
                            {
                                saveAFace(face, map);
                                //MessageBox.Show("No Username for this face, Kindly register this face", "Authentication Result",
                                //MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }

                        }
                    }
                    
                }

                imgCamUser.Image = ImageFrame;  //line 2


            }   //line 1
        }

        void saveAFace(Rectangle face, Bitmap ImageFrame)
        {
            var faceToSave = new Image<Gray, byte>(ImageFrame);
            Byte[] file;
            IDataStoreAccess dataStore = new DataStoreAccess(_databasePath);

            var username = Guid.NewGuid().ToString();
            var filePath = Application.StartupPath + String.Format("/{0}.bmp", username);
            faceToSave.ToBitmap().Save(filePath);
            using (var stream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            {
                using (var reader = new BinaryReader(stream))
                {
                    file = reader.ReadBytes((int)stream.Length);
                }
            }
            var result = dataStore.SaveFace(username, file);
            //_recognizerEngine.TrainRecognizer();
            bckGroundTrainer.RunWorkerAsync();
            MessageBox.Show(result, "Save Result", MessageBoxButtons.OK);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void fromPictureToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var img = WinformUtilities.OpenImageFile();
            string id_names = WinformUtilities.TrainImage(img);
            MessageBox.Show(string.Format("Xác định được những người sau: {0}", id_names));
            //Need train multiple image of same person?
        }

        private void fromPictureToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var img = WinformUtilities.OpenImageFile();
            try
            {
                var img1 = WinformUtilities.RecognizeImage(img);
                imgCamUser.Image = img1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void fromMultiPicturesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var imgs = WinformUtilities.OpenMultiImageFile();
            StringBuilder sb = new StringBuilder();
            foreach(var img in imgs)
                sb.Append(","+WinformUtilities.TrainImage(img));
            string regNames = sb.ToString();
            regNames = regNames.StartsWith(",") ? regNames.Substring(1) : regNames;
            MessageBox.Show(string.Format("Xác định được những người sau: {0}", regNames));
        }
    }

}
