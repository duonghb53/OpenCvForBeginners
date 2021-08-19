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
        public Mat ReadImage(string pathImg, ImreadModes mode)
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
    }
}
