using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Lacey.Medusa.Common.Core.Utils
{
    public static class CryptoUtils
    {
        public static string Md5Hash(this string input)
        {
            using var md5 = MD5.Create();
            return string.Join("", md5.ComputeHash(Encoding.ASCII.GetBytes(input)).Select(x => x.ToString("X2")));
        }

        public static string Md4Hash(this string input)
        {
            // get padded uints from bytes
            var bytes = Encoding.ASCII.GetBytes(input).ToList();
            var bitCount = (uint)(bytes.Count) * 8;
            bytes.Add(128);
            while (bytes.Count % 64 != 56) bytes.Add(0);
            var uints = new List<uint>();
            for (var i = 0; i + 3 < bytes.Count; i += 4)
                uints.Add(bytes[i] | (uint)bytes[i + 1] << 8 | (uint)bytes[i + 2] << 16 | (uint)bytes[i + 3] << 24);
            uints.Add(bitCount);
            uints.Add(0);

            // run rounds
            uint a = 0x67452301, b = 0xefcdab89, c = 0x98badcfe, d = 0x10325476;
            uint Rol(uint x, uint y) => x << (int)y | x >> 32 - (int)y;
            for (var q = 0; q + 15 < uints.Count; q += 16)
            {
                var chunk = uints.GetRange(q, 16);
                uint aa = a, bb = b, cc = c, dd = d;

                void Round(Func<uint, uint, uint, uint> f, uint[] y)
                {
                    foreach (var i in new[] { y[0], y[1], y[2], y[3] })
                    {
                        a = Rol(a + f(b, c, d) + chunk[(int)(i + y[4])] + y[12], y[8]);
                        d = Rol(d + f(a, b, c) + chunk[(int)(i + y[5])] + y[12], y[9]);
                        c = Rol(c + f(d, a, b) + chunk[(int)(i + y[6])] + y[12], y[10]);
                        b = Rol(b + f(c, d, a) + chunk[(int)(i + y[7])] + y[12], y[11]);
                    }
                }

                Round((x, y, z) => (x & y) | (~x & z), new uint[] { 0, 4, 8, 12, 0, 1, 2, 3, 3, 7, 11, 19, 0 });
                Round((x, y, z) => (x & y) | (x & z) | (y & z), new uint[] { 0, 1, 2, 3, 0, 4, 8, 12, 3, 5, 9, 13, 0x5a827999 });
                Round((x, y, z) => x ^ y ^ z, new uint[] { 0, 2, 1, 3, 0, 8, 4, 12, 3, 9, 11, 15, 0x6ed9eba1 });
                a += aa; b += bb; c += cc; d += dd;
            }

            // return hex encoded string
            var outBytes = new[] { a, b, c, d }.SelectMany(BitConverter.GetBytes).ToArray();
            return BitConverter.ToString(outBytes).Replace("-", "");
        }
    }
}