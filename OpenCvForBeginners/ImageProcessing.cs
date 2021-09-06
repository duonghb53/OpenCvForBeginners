using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCvForBeginners
{
    class ImageProcessing
    {
        /// <summary>
        /// Đọc ảnh từ máy tính theo đường dẫn
        /// </summary>
        /// <param name="pathImg">Đường dẫn ảnh</param>
        /// <returns></returns>
        public Mat ReadImage(string pathImg, ImreadModes mode = ImreadModes.Color)
        {
            return Cv2.ImRead(pathImg, mode);
        }

        /// <summary>
        /// Lưu ảnh
        /// </summary>
        /// <param name="path">Tên file ảnh lưu</param>
        /// <param name="image">Image</param>
        internal void SaveImage(string path, Mat image)
        {
            Cv2.ImWrite(path, image);
        }

        internal void ResizeImage(string strPathImage)
        {
            var imageIn = ReadImage(strPathImage);
            var imageOut = new Mat();
            Console.WriteLine(imageIn.Width + "-" + imageIn.Height);
            int width = 1000, height = (int)(width / (float)imageIn.Width * imageIn.Height);
            Cv2.Resize(imageIn, imageOut, new Size(width, height), 0, 0, InterpolationFlags.Nearest);
            Console.WriteLine(imageOut.Width + "-" + imageOut.Height);
            Cv2.ImShow("Nearest", imageOut);


            Cv2.Resize(imageIn, imageOut, new Size(width, height), 0, 0, InterpolationFlags.Linear);
            Console.WriteLine(imageOut.Width + "-" + imageOut.Height);
            Cv2.ImShow("Linear", imageOut);

            Cv2.Resize(imageIn, imageOut, new Size(width, height), 0, 0, InterpolationFlags.Cubic);
            Console.WriteLine(imageOut.Width + "-" + imageOut.Height);
            Cv2.ImShow("Bicubic", imageOut);

            //Cv2.Resize(imageIn, imageOut, new Size(), 1.5, 1.2);
            //Console.WriteLine(imageOut.Width + "-" + imageOut.Height);

            //Cv2.ImShow("Image resize 2", imageOut);
        }
    }
}
