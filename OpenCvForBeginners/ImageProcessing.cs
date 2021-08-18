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
        public Mat ReadImage(string pathImg)
        {
            return Cv2.ImRead(pathImg, ImreadModes.Grayscale);
        }
    }
}
