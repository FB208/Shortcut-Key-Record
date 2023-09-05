using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ShortcutKeyRecord.Helper
{
    public static class FileHelper
    {
        /// <summary>
        /// 读文件到byte[]
        /// </summary>
        /// <param name="fileName">硬盘文件路径</param>
        /// <returns></returns>
        public static byte[] ReadFileToByte(string fileName)
        {
            FileStream pFileStream = null;
            byte[] pReadByte = new byte[0];
            try
            {
                pFileStream = new FileStream(fileName, FileMode.Open, FileAccess.Read);
                BinaryReader r = new BinaryReader(pFileStream);
                r.BaseStream.Seek(0, SeekOrigin.Begin);    //将文件指针设置到文件开
                pReadByte = r.ReadBytes((int)r.BaseStream.Length);
                return pReadByte;
            }
            catch
            {
                return pReadByte;
            }
            finally
            {
                if (pFileStream != null)
                    pFileStream.Close();
            }
        }

        /// <summary>
        /// 写byte[]到fileName
        /// </summary>
        /// <param name="pReadByte">byte[]</param>
        /// <param name="fileName">保存至硬盘路径</param>
        /// <returns></returns>
        public static bool WriteByteToFile(byte[] pReadByte, string fileName)
        {
            FileStream pFileStream = null;
            try
            {
                pFileStream = new FileStream(fileName, FileMode.OpenOrCreate);
                pFileStream.Write(pReadByte, 0, pReadByte.Length);
            }
            catch
            {
                return false;
            }
            finally
            {
                if (pFileStream != null)
                    pFileStream.Close();
            }
            
            return true;
        }

        /// <summary>
        /// 二进制流转字符串
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        public static string Bytes2String(byte[] bytes)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(Encoding.UTF8.GetString(bytes, 0, bytes.Length));

            return sb.ToString();
        }
    }
}
