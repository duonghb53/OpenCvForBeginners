using OpenCvSharp;
using System;
using System.Windows.Forms;

namespace OpenCvForBeginners
{
    public partial class Form1 : Form
    {
        private ImageProcessing imageProcessing;
        private Commons commons;
        private bool isVideoRunning = false;
        private VideoCapture videoCapture;

        private string _strPathImage = null;
        public Form1()
        {
            InitializeComponent();
            imageProcessing = new ImageProcessing();
            commons = new Commons();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            foreach(var item in Constants.PREPROCESSING_IMAGE)
            {
                comboBox1.Items.Add(item);
            }
        }

        /// <summary>
        /// Sự kiện khi Click button Open Image
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            // Lấy đường dẫn ảnh
            _strPathImage = commons.OpenFile(false);

            // Kiểm tra xem có chọn file không
            if (_strPathImage != null)
            {
                // Đọc ảnh
                Mat image = imageProcessing.ReadImage(_strPathImage, ImreadModes.Color);

                // Hiển thị ảnh lên PictureBox
                commons.ShowImage(pictureBox1, image);

                // Lưu ảnh
                imageProcessing.SaveImage("temp.jpg", image);
            }
        }

        /// <summary>
        /// Sự kiện khi click Open Video
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            // Lấy đường dẫn Video
            string pathVideo = commons.OpenFile(true);
            // Kiểm tra xem có chọn file không
            if (pathVideo != null)
            {
                isVideoRunning = true;

                // Đọc videp từ đường dẫn
                videoCapture = new VideoCapture(pathVideo);
                var fps = videoCapture.Fps;
                int sleepTime = (int)(1000.0 / fps);
                Mat image = new Mat();

                while (isVideoRunning)
                {
                    // Đọc ảnh từ video
                    videoCapture.Read(image);

                    // Nếu đến cuối video
                    if (image.Empty()) break;

                    // Hiển thị ảnh lên PictureBox
                    commons.ShowImage(pictureBox1, image);
                    Cv2.WaitKey(sleepTime);
                }
            }
        }

        /// <summary>
        /// Sự kiện mở/tắt Camera
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            videoCapture = new VideoCapture(0);
            Mat image = new Mat();
            var fps = videoCapture.Fps;
            int sleepTime = (int)(1000.0 / fps);

            VideoWriter videoWriter = new VideoWriter("Output.mp4", FourCC.Default, fps, new OpenCvSharp.Size(videoCapture.FrameWidth, videoCapture.FrameHeight));

            isVideoRunning = !isVideoRunning;
            if (isVideoRunning)
            {
                button3.Text = "Stop Camera";
            }
            else
            {
                button3.Text = "Start Camera";
            }

            while (isVideoRunning)
            {
                // Đọc ảnh từ video
                videoCapture.Read(image);

                // Nếu đến cuối video
                if (image.Empty()) break;

                // Hiển thị ảnh lên PictureBox
                commons.ShowImage(pictureBox1, image);

                // Save Video
                videoWriter.Write(image);
                Cv2.WaitKey(sleepTime);
            }

            videoWriter.Dispose();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            isVideoRunning = false;
            if (videoCapture != null) videoCapture.Dispose();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var iPreprocessing = comboBox1.SelectedIndex;
            if (iPreprocessing == -1) MessageBox.Show("Vui lòng chọn kiểu xử lý", "Warning");
            switch (iPreprocessing)
            {
                case (int)Processing.RESIZE:
                    imageProcessing.ResizeImage(_strPathImage);
                    break;
                case (int)Processing.CROP:

                    break;
            }
        }
    }
}
