using System;

namespace Z.QRCodeEncoder.Net
{

    /// <summary>
    /// Reed-Solomon(里德-所罗门码)
    /// <para>仅适用于QrCode</para>
    /// <para>@createDate 2023/05/16 11:11:11</para>
    /// <para>@author ALI[ali-k@foxmail.com]</para>
    /// <para>@since 1.0.0</para>
    /// </summary>
    public class ReedSolomon
    {

        /// <summary>
        /// 多项式0
        /// </summary>
        public static readonly GenericGFPoly Zero = new GenericGFPoly(new int[] { 0 });

        /// <summary>
        /// GenericGFPoly数组
        /// </summary>
        private static readonly GenericGFPoly[] GenericGFPolyArray = new GenericGFPoly[69];

        static ReedSolomon()
        {
            // 初始化GenericGFPoly数组
            GenericGFPolyArray[0] = new GenericGFPoly(new int[] { 1 });
            // 最大值68
            // 数据来源 ISO/IEC 18004-2015 -> Annex A -> Table A.1 -> Number of error correction codewords列最大值
            for (int i = 1; i < 69; i++)
            {
                GenericGFPolyArray[i] = GenericGFPolyArray[i - 1].Multiply(new GenericGFPoly(new int[] { 1, GenericGF.Exp(i - 1) }));
            }
        }

        /// <summary>
        /// 编码
        /// </summary>
        /// <param name="coefficients">系数</param>
        /// <param name="degree">次数</param>
        /// <returns>结果</returns>
        public static int[] Encoder(int[] coefficients, int degree)
        {
            GenericGFPoly info = new GenericGFPoly(coefficients);
            info = info.MultiplyByMonomial(degree, 1);
            GenericGFPoly remainder = info.RemainderOfDivide(GenericGFPolyArray[degree]);
            // 纠错码
            int[] result = remainder.Coefficients;
            int length = result.Length;
            // 长度不够前面补0
            int padding = degree - length;
            if (padding == 0)
            {
                return result;
            }
            else
            {
                int[] resultPadding = new int[degree];
                Array.Copy(result, 0, resultPadding, padding, length);
                return resultPadding;
            }
        }

    }
}
