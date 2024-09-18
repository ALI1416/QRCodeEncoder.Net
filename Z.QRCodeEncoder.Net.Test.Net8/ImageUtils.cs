using SkiaSharp;

namespace Z.QRCodeEncoder.Net.Test.Net8
{

    /// <summary>
    /// 图像工具
    /// </summary>
    public class ImageUtils
    {

        /// <summary>
        /// 黑色笔
        /// </summary>
        private static readonly SKPaint PAINT = new SKPaint()
        {
            Color = SKColors.Black
        };

        /// <summary>
        /// 二维码bool[,]转SKBitmap
        /// </summary>
        /// <param name="bytes">bool[,](false白 true黑)</param>
        /// <param name="pixelSize">像素尺寸</param>
        /// <returns>SKBitmap</returns>
        public static SKBitmap QrMatrix2Image(bool[,] bytes, int pixelSize)
        {
            int length = bytes.GetLength(0);
            int size = (length + 2) * pixelSize;
            SKBitmap bitmap = new SKBitmap(size, size);
            using SKCanvas canvas = new SKCanvas(bitmap);
            for (int x = 0; x < length; x++)
            {
                for (int y = 0; y < length; y++)
                {
                    if (bytes[x, y])
                    {
                        canvas.DrawRect((x + 1) * pixelSize, (y + 1) * pixelSize, pixelSize, pixelSize, PAINT);
                    }
                }
            }
            return bitmap;
        }

        /// <summary>
        /// 二维码bool[,]转SKBitmap
        /// </summary>
        /// <param name="bytes">byte[][](0白 1黑)</param>
        /// <param name="pixelSize">像素尺寸</param>
        /// <returns>SKBitmap</returns>
        public static SKBitmap QrMatrix2Image(byte[,] bytes, int pixelSize)
        {
            int length = bytes.GetLength(0);
            int size = (length + 2) * pixelSize;
            SKBitmap bitmap = new SKBitmap(size, size);
            using SKCanvas canvas = new SKCanvas(bitmap);
            for (int x = 0; x < length; x++)
            {
                for (int y = 0; y < length; y++)
                {
                    if (bytes[x, y] == 1)
                    {
                        canvas.DrawRect((x + 1) * pixelSize, (y + 1) * pixelSize, pixelSize, pixelSize, PAINT);
                    }
                }
            }
            return bitmap;
        }

        /// <summary>
        /// 二维码byte[][]转SKBitmap
        /// </summary>
        /// <param name="bytes">byte[][](0白 1黑)</param>
        /// <param name="pixelSize">像素尺寸</param>
        /// <returns>SKBitmap</returns>
        public static SKBitmap QrMatrix2Image(byte[][] bytes, int pixelSize)
        {
            int length = bytes.Length;
            int size = (length + 2) * pixelSize;
            SKBitmap bitmap = new SKBitmap(size, size);
            using SKCanvas canvas = new SKCanvas(bitmap);
            // ZXing反转了xy轴
            for (int y = 0; y < length; y++)
            {
                for (int x = 0; x < length; x++)
                {
                    if (bytes[y][x] == 1)
                    {
                        canvas.DrawRect((x + 1) * pixelSize, (y + 1) * pixelSize, pixelSize, pixelSize, PAINT);
                    }
                }
            }
            return bitmap;
        }

        /// <summary>
        /// 保存SKBitmap为PNG图片
        /// </summary>
        /// <param name="image">SKBitmap</param>
        /// <param name="path">路径</param>
        public static void SaveImage(SKBitmap image, string path)
        {
            using FileStream outputStream = File.OpenWrite(path);
            image.Encode(SKEncodedImageFormat.Png, 100).SaveTo(outputStream);
        }

    }
}
