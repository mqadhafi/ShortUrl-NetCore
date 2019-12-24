using System;
using System.Security.Cryptography;
using System.Text;

namespace ShortUrl.Business.Extensions
{
    internal static class KeyGeneratorExtension
    {
        private static readonly char[] _chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890".ToCharArray();

        public static string GetUniqueKey(int size)
        {
            byte[] data = new byte[4 * size];
            using (var rngCryptoServiceProvider = new RNGCryptoServiceProvider())
            {
                rngCryptoServiceProvider.GetBytes(data);
            }
            var result = new StringBuilder(size);
            for (int i = 0; i < size; i++)
            {
                uint rnd = BitConverter.ToUInt32(data, i * 4);
                long index = rnd % _chars.Length;

                result.Append(_chars[index]);
            }
            return result.ToString();
        }
    }
}