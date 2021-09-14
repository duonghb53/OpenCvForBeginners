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

        internal void Resize(string pathImg)
        {
            var imageIn = ReadImage(pathImg);
            Console.WriteLine(imageIn.Width + "-" + imageIn.Height);
            Mat imageOut = new Mat();
            int newWidth = 1000, newHeight = (int)((float)newWidth / (float) imageIn.Width * imageIn.Height);
            Cv2.Resize(imageIn, imageOut, new Size(), 8, 8, InterpolationFlags.Nearest);

            Cv2.ImShow("Nearest 1 ", imageOut);

            Cv2.Resize(imageIn, imageOut, new Size(), 8, 8, InterpolationFlags.Linear);

            Cv2.ImShow("Linear 2", imageOut);

            Cv2.Resize(imageIn, imageOut, new Size(), 8, 8, InterpolationFlags.Cubic);

            Cv2.ImShow("Cubic 3", imageOut);
        }
    }
}
