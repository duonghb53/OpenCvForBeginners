using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCvForBeginners
{
    class Constants
    {
        public static readonly string[] PREPROCESSING_IMAGE = { "Resize", "Crop" };
    }

    public enum Processing
    {
        RESIZE = 0,
        CROP
    }
}
