using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;

namespace task3_kamenoznicy
{
    class HMACGenerator
    {
        public int SelectedMove { get; set; }
        public string HMACValue { get; set; }
        public string HMACKey { get; set; }

        public HMACGenerator(int argsCount)
        {
            CreateKey(argsCount);
            SelectedMove = GetRandomMoveNumber(argsCount);
            ASCIIEncoding encoding = new ASCIIEncoding();
            HMACSHA256 hmacsha256 = new HMACSHA256(encoding.GetBytes(HMACKey));
            HMACValue = ByteToString(hmacsha256.ComputeHash(encoding.GetBytes((SelectedMove + 1).ToString())));

        }
        private static int GetRandomMoveNumber(int maxValue)
        {
            var number = RandomNumberGenerator.GetInt32(maxValue);
            return number;
        }

        private static int GetRandomNumber()
        {
            var number = RandomNumberGenerator.GetInt32(Int32.MaxValue);
            return number;
        }

        private void CreateKey(int argsCount)
        {
            HMACKey = "";
            for (int i = 0; i < argsCount; i++)
            {
                HMACKey += GetRandomNumber().ToString("X");
            }
        }

        private static string ByteToString(byte[] buff)
        {
            string sbinary = "";
            for (int i = 0; i < buff.Length; i++)
            {
                sbinary += buff[i].ToString("X2");
            }
            return (sbinary);
        }
    }
}
