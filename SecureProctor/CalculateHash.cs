using System;
using System.Security;
using System.Security.Cryptography;
using System.Text;

namespace SecureProctor
{
    public class CalculateHash
    {
        public static string GenerateHash(string TransactionKey, string x_login, string x_fp_sequence, string x_fp_timestamp, string x_amount, string x_currency)
        {
            StringBuilder sb = new StringBuilder();
            // x_login^x_fp_sequence^x_fp_timestamp^x_amount^x_currency
            //String x_login = "WSP-ACTIV-70";
            //String x_fp_sequence = "123";
            //String x_fp_timestamp = "1228774539";
            //String x_amount = "100.00";
            //String x_currency = ""; // default empty

            sb.Append(x_login)
              .Append("^")
              .Append(x_fp_sequence)
              .Append("^")
              .Append(x_fp_timestamp)
              .Append("^")
              .Append(x_amount)
              .Append("^")
              .Append(x_currency);

            // Convert string to array of bytes.
            byte[] data = Encoding.UTF8.GetBytes(sb.ToString());

            // key
            byte[] key = Encoding.UTF8.GetBytes(TransactionKey);

            // Create HMAC-MD5 Algorithm;
            HMACMD5 hmac = new HMACMD5(key);

            // Create HMAC-SHA1 Algorithm;
            //HMACSHA1 hmac = new HMACSHA1(key);

            // Compute hash.
            byte[] hashBytes = hmac.ComputeHash(data);

            // Convert to HEX string.
            String x_fp_hash = System.BitConverter.ToString(hashBytes).Replace("-", "");

            String msg = String.Format("x_login = {0}, x_fp_sequence = {1}, x_fp_timestamp = {2}, x_amount = {3}, x_currency= {4}.\n x_fp_hash = {5}", x_login, x_fp_sequence, x_fp_timestamp, x_amount, x_currency, x_fp_hash);

            return x_fp_hash.ToLower();

        }

    }
}
