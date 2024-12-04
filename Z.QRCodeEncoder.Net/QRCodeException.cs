using System;
using System.Runtime.Serialization;

namespace Z.QRCodeEncoder.Net
{

    /// <summary>
    /// QRCode异常
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
        /// <param name="message">详细信息</param>
        public QRCodeException(string message) : base(message) { }
        /// <summary>
        /// QRCode异常
        /// </summary>
        /// <param name="message">详细信息</param>
        /// <param name="innerException">内部异常</param>
        public QRCodeException(string message, Exception innerException) : base(message, innerException) { }
        /// <summary>
        /// QRCode异常
        /// </summary>
        /// <param name="info">序列化信息</param>
        /// <param name="context">流上下文</param>
        protected QRCodeException(SerializationInfo info, StreamingContext context) : base(info, context) { }

    }
}
