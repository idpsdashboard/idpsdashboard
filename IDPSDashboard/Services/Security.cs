using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDPSDashboard.Services
{
    public class Encryption
    {

        private Encryption()
        {
        }

        public static QueryString EncryptQueryString(QueryString queryString)
        {
            QueryString newQueryString = new QueryString();
            string nm = String.Empty;
            string val = String.Empty;
            foreach (string name in queryString)
            {
                nm = name;
                val = queryString[name];
                newQueryString.Add(Encryption.Hex(nm),Encryption.Hex(val));
            }
            return newQueryString;
        }

        public static QueryString DecryptQueryString(QueryString queryString)
        {
            QueryString newQueryString = new QueryString();
            string nm;
            string val;
            foreach (string name in queryString)
            {
                nm = Encryption.DeHex(name);
                val = Encryption.DeHex(queryString[name]);
                newQueryString.Add(nm, val);
            }
            return newQueryString;
        }

        public static string DeHex(string hexstring)
        {
            string ret = String.Empty;
            StringBuilder sb = new StringBuilder(hexstring.Length / 2);
            for (int i = 0; i <= hexstring.Length - 1; i = i + 2)
            {
                sb.Append((char)int.Parse(hexstring.Substring(i, 2), NumberStyles.HexNumber));
            }
            return sb.ToString();
        }

        public static string Hex(string sData)
        {
            string temp = String.Empty; ;
            string newdata = String.Empty;
            StringBuilder sb = new StringBuilder(sData.Length * 2);
            for (int i = 0; i < sData.Length; i++)
            {
                if ((sData.Length - (i + 1)) > 0)
                {
                    temp = sData.Substring(i, 2);
                    if (temp == @"\n") newdata += "0A";
                    else if (temp == @"\b") newdata += "20";
                    else if (temp == @"\r") newdata += "0D";
                    else if (temp == @"\c") newdata += "2C";
                    else if (temp == @"\\") newdata += "5C";
                    else if (temp == @"\0") newdata += "00";
                    else if (temp == @"\t") newdata += "07";
                    else
                    {
                        sb.Append(String.Format("{0:X2}", (int)(sData.ToCharArray())[i]));
                        i--;
                    }
                }
                else
                {
                    sb.Append(String.Format("{0:X2}", (int)(sData.ToCharArray())[i]));
                }
                i++;
            }
            return sb.ToString();
        }
    }
}
