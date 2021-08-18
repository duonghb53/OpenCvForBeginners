using OpenCvSharp;
using OpenCvSharp.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OpenCvForBeginners
{
    public partial class Form1 : Form
    {
        private ImageProcessing imageProcessing;
        private Commons commons;
        public Form1()
        {
            InitializeComponent();
            imageProcessing = new ImageProcessing();
            commons = new Commons();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string pathImg = commons.OpenFile();
            Mat image = imageProcessing.ReadImage(pathImg);
            //Cv2.ImShow("Image", image);
            pictureBox1.Image = BitmapConverter.ToBitmap(image);
            Cv2.ImWrite("temp.jpg", image);
        }
    }
}
