using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientSide {
    class ImageHandler {

        public static byte[] readImage(string filePath) {
            FileInfo fiImage = new FileInfo(filePath);
            long length = fiImage.Length;
            FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read);
            byte[] imageArr = new byte[Convert.ToInt32(length)];
            int iBytesRead = fs.Read(imageArr, 0, Convert.ToInt32(length));
            fs.Close();
            return imageArr;
        }

    }
}
