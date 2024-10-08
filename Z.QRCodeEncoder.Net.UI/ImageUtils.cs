using System.Collections.Generic;
using System.Drawing;

namespace Z.QRCodeEncoder.Net.UI
{

    /// <summary>
    /// 图像工具
    /// </summary>
    public class ImageUtils
    {

        /// <summary>
        /// 黑色刷子
        /// </summary>
        private static readonly Brush BLACK_BRUSH = new SolidBrush(Color.Black);

        /// <summary>
        /// 二维码bool[,]转Bitmap
        /// </summary>
        /// <param name="bytes">bool[,](false白 true黑)</param>
        /// <param name="pixelSize">像素尺寸</param>
        /// <returns>Bitmap</returns>
        public static Bitmap QrMatrix2Bitmap(bool[,] bytes, int pixelSize)
        {
            int length = bytes.GetLength(0);
            List<Rectangle> rects = new List<Rectangle>();
            for (int x = 0; x < length; x++)
            {
                for (int y = 0; y < length; y++)
                {
                    if (bytes[x, y])
                    {
                        rects.Add(new Rectangle((x + 1) * pixelSize, (y + 1) * pixelSize, pixelSize, pixelSize));
                    }
                }
            }
            int size = (length + 2) * pixelSize;
            Bitmap bitmap = new Bitmap(size, size);
            using (Graphics g = Graphics.FromImage(bitmap))
            {
                g.FillRectangles(BLACK_BRUSH, rects.ToArray());
            }
            return bitmap;
        }

    }
}
