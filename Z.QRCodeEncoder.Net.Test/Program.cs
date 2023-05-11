using System.Drawing;

namespace Z.QRCodeEncoder.Net.Test
{
    /// <summary>
    /// 程序入口
    /// </summary>
    public class Program
    {

        /// <summary>
        /// 启动类
        /// </summary>
        /// <param name="args">参数</param>
        public static void Main(string[] args)
        {
            QRCodeTest();
        }

        private static readonly string content = "爱上对方过后就哭了啊123456789012345678901234567890";
        private static readonly int level = 3;
        private static readonly string path = "E:/qr2.png";

        /// <summary>
        /// 二维码测试
        /// </summary>
        public static void QRCodeTest()
        {
            // 生成二维码
            QRCode qrCode = new QRCode(content, level);
            Bitmap bitmap = ImageUtils.QrBytes2Bitmap(qrCode.Matrix, 10);
            ImageUtils.SaveBitmap(bitmap, path);
        }

    }
}
