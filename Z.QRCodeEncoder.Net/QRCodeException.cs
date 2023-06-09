using System;

namespace Z.QRCodeEncoder.Net
{

    /// <summary>
    /// QRCode异常类
    /// <para>@createDate 2023/06/09 11:11:11</para>
    /// <para>@author ALI[ali-k@foxmail.com]</para>
    /// <para>@since 1.1.0</para>
    /// </summary>
    public class QRCodeException : Exception
    {

        /// <summary>
        /// QRCode异常
        /// </summary>
        public QRCodeException() : base() { }
        /// <summary>
        /// QRCode异常
        /// </summary>
        /// <param name="message">信息</param>
        public QRCodeException(string message) : base(message) { }

    }
}
