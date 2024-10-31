using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Utilities.Converters
{
    public static class ImageConverter
    {
        public static byte[]? ImageToBytes(string path) => File.ReadAllBytes(path);
    }
}
