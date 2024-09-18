using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using ZXing;
using ZXing.QrCode.Internal;

namespace Z.QRCodeEncoder.Net.Test
{

    /// <summary>
    /// 程序入口
    /// </summary>
    public class Program
    {

        private static readonly string path = "D:/Z.QRCodeEncoder.Net.Test/";

        /// <summary>
        /// 启动类
        /// </summary>
        /// <param name="args">参数</param>
        public static void Main(string[] args)
        {
            Test();
            //CoverageTest();
            //IntegrityTest();
        }

        /// <summary>
        /// 测试
        /// </summary>
        public static void Test()
        {
            // 生成二维码
            string content = "1234😀";
            int level = 0;
            int? mode = 3;
            int? versionNumber = 1;
            string path = Program.path + "Test/";
            Directory.CreateDirectory(path);
            QRCode qrCode1 = new QRCode(content, level, mode, versionNumber);
            Bitmap bitmap1 = ImageUtils.QrMatrix2Bitmap(qrCode1.Matrix, 10);
            ImageUtils.SaveBitmap(bitmap1, path + "qr1.png");
            // 识别二维码
            BarcodeReader reader1 = new BarcodeReader();
            Result result1 = reader1.Decode(bitmap1);
            Console.WriteLine(result1);
            // 生成ZXing二维码
            ZXing.QrCode.Internal.QRCode qrCode2 = Encoder.encode(content, GetLevel(level), GetHints(versionNumber, mode));
            Bitmap bitmap2 = ImageUtils.QrMatrix2Bitmap(qrCode2.Matrix.Array, 10);
            ImageUtils.SaveBitmap(bitmap2, path + "qr2.png");
            // 识别ZXing二维码
            BarcodeReader reader2 = new BarcodeReader();
            Result result2 = reader2.Decode(bitmap2);
            Console.WriteLine(result2);
            // 生成8个模板
            byte[][,] patterns = qrCode1.MaskPattern.Patterns;
            for (int i = 0; i < 8; i++)
            {
                Bitmap bitmap = ImageUtils.QrMatrix2Bitmap(patterns[i], 10);
                ImageUtils.SaveBitmap(bitmap, path + "pattern" + i + ".png");
            }
        }

        /// <summary>
        /// 覆盖测试
        /// </summary>
        public static void CoverageTest()
        {
            string content = "12345678901234567890";
            int level = 3;
            int mode = 3;
            int versionNumber = 7;
            string path = Program.path + "CoverageTest/";
            Directory.CreateDirectory(path);
            QRCode qrCode1 = new QRCode(content);
            Bitmap bitmap1 = ImageUtils.QrMatrix2Bitmap(qrCode1.Matrix, 10);
            ImageUtils.SaveBitmap(bitmap1, path + "qr1.png");
            QRCode qrCode2 = new QRCode(content, level);
            Bitmap bitmap2 = ImageUtils.QrMatrix2Bitmap(qrCode2.Matrix, 10);
            ImageUtils.SaveBitmap(bitmap2, path + "qr2.png");
            QRCode qrCode3 = new QRCode(content, level, mode);
            Bitmap bitmap3 = ImageUtils.QrMatrix2Bitmap(qrCode3.Matrix, 10);
            ImageUtils.SaveBitmap(bitmap3, path + "qr3.png");
            QRCode qrCode4 = new QRCode(content, level, mode, versionNumber);
            Bitmap bitmap4 = ImageUtils.QrMatrix2Bitmap(qrCode4.Matrix, 10);
            ImageUtils.SaveBitmap(bitmap4, path + "qr4.png");
        }

        /// <summary>
        /// 完整性测试
        /// </summary>
        public static void IntegrityTest()
        {
            IntegrityTest("12345", 0);
            IntegrityTest("ABCD", 1);
            IntegrityTest("abc", 2);
            IntegrityTest("啊😀", 3);
        }

        /// <summary>
        /// 完整性测试
        /// </summary>
        private static void IntegrityTest(string content, int mode)
        {
            // 版本号 1-40
            for (int versionNumber = 1; versionNumber < 40; versionNumber++)
            {
                // 纠错等级 0-3
                for (int level = 0; level < 3; level++)
                {
                    bool[,] matrix = new QRCode(content, level, mode, versionNumber).Matrix;
                    byte[][] array = Encoder.encode(content, GetLevel(level), GetHints(versionNumber, mode)).Matrix.Array;
                    int dimension = matrix.GetLength(0);
                    for (int i = 0; i < dimension; i++)
                    {
                        for (int j = 0; j < dimension; j++)
                        {
                            if (matrix[i, j] != (array[j][i] == 1))
                            {
                                throw new Exception("编码模式 " + mode + " 版本号 " + versionNumber + " 纠错等级 " + level + " i " + i + " j " + j);
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 获取配置
        /// </summary>
        private static Dictionary<EncodeHintType, object> GetHints(int? versionNumber, int? mode)
        {
            Dictionary<EncodeHintType, object> hints = new Dictionary<EncodeHintType, object>();
            if (versionNumber != null)
            {
                hints.Add(EncodeHintType.QR_VERSION, versionNumber);
            }
            if (mode == 3)
            {
                hints.Add(EncodeHintType.CHARACTER_SET, "UTF-8");
            }
            return hints;
        }

        /// <summary>
        /// 获取纠错等级
        /// </summary>
        private static ErrorCorrectionLevel GetLevel(int level)
        {
            switch (level)
            {
                default:
                case 0:
                    {
                        return ErrorCorrectionLevel.L;
                    }
                case 1:
                    {
                        return ErrorCorrectionLevel.M;
                    }
                case 2:
                    {
                        return ErrorCorrectionLevel.Q;
                    }
                case 3:
                    {
                        return ErrorCorrectionLevel.H;
                    }
            }
        }

    }
}
