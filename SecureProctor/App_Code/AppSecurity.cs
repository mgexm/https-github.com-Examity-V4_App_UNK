using System;
using System.IO;
using System.Xml;
using System.Text;
using System.Security.Cryptography;

namespace SecureProctor
{
    public class AppSecurity
    {

        private static byte[] key = { };
        private static byte[] IV = { 0x12, 0x34, 0x56, 0x78, 0x90, 0xab, 0xcd, 0xef };
        private static string Decryption(string stringToDecrypt, string sEncryptionKey)
        {
            byte[] inputByteArray = new byte[stringToDecrypt.Length + 1];
            try
            {
                key = System.Text.Encoding.UTF8.GetBytes(sEncryptionKey.Substring(0));
                DESCryptoServiceProvider des = new DESCryptoServiceProvider();
                inputByteArray = Convert.FromBase64String(stringToDecrypt);
                MemoryStream ms = new MemoryStream();
                CryptoStream cs = new CryptoStream(ms, des.CreateDecryptor(key, IV), CryptoStreamMode.Write);
                cs.Write(inputByteArray, 0, inputByteArray.Length);
                cs.FlushFinalBlock();
                System.Text.Encoding encoding = System.Text.Encoding.UTF8;
                return encoding.GetString(ms.ToArray());
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
        private static string Encryption(string stringToEncrypt, string SEncryptionKey)
        {
            try
            {
                key = System.Text.Encoding.UTF8.GetBytes(SEncryptionKey.Substring(0));
                DESCryptoServiceProvider des = new DESCryptoServiceProvider();
                byte[] inputByteArray = Encoding.UTF8.GetBytes(stringToEncrypt);
                MemoryStream ms = new MemoryStream();
                CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(key, IV), CryptoStreamMode.Write);
                cs.Write(inputByteArray, 0, inputByteArray.Length);
                cs.FlushFinalBlock();
                return Convert.ToBase64String(ms.ToArray());
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
        public static string Encrypt(string srtEncrypt)
        {
            return (Encryption(srtEncrypt, System.Configuration.ConfigurationManager.AppSettings["SaltKey"].ToString()));
        }
        public static string Decrypt(string srtDecrypt)
        {
            //return (Decryption(srtDecrypt.Replace(" ", "+"), System.Configuration.ConfigurationManager.AppSettings["SaltKey"].ToString()));
            srtDecrypt = srtDecrypt.Replace(" ", "+");
            int mod4 = srtDecrypt.Length % 4;
            if (mod4 > 0)
            {
                srtDecrypt += new string('=', 4 - mod4);
            }
            return (Decryption(srtDecrypt, System.Configuration.ConfigurationManager.AppSettings["SaltKey"].ToString()));

        }
        //public string ImageToBase64(string strImgeName)
        //{
        //    try
        //    {
        //        strImgeName = System.Web.HttpContext.Current.Server.MapPath("~/Student\\Student_Identity\\") + strImgeName;
        //        string base64String = string.Empty;
        //        using (System.Drawing.Image image = System.Drawing.Image.FromFile(strImgeName))
        //        {
        //            using (MemoryStream m = new MemoryStream())
        //            {
        //                image.Save(m, image.RawFormat);
        //                byte[] imageBytes = m.ToArray();
        //                base64String = Convert.ToBase64String(imageBytes);
        //                return "data:image/png;base64," + base64String;
        //            }
        //        }
        //    }
        //    catch
        //    {
        //        return string.Empty;
        //    }
        //}

        public string ImageToBase64(string strImgeName)
        {
            try
            {
                strImgeName = System.Web.HttpContext.Current.Server.MapPath("~/Student\\Student_Identity\\") + strImgeName;
                string base64String = string.Empty;

                byte[] imageArray = System.IO.File.ReadAllBytes(strImgeName);
                base64String = System.Convert.ToBase64String(imageArray);
                return "data:image/png;base64," + base64String;
            }
            catch
            {
                return string.Empty;
            }
        }


    }
}