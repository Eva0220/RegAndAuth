using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InformBez.Utilts
{
    public static class Utilts
    {
        public static string GetUUID()
        {
            var procStartInfo = new ProcessStartInfo("cmd", "/c " + "wmic csproduct get UUID")
            {
                RedirectStandardOutput = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };

            var proc = new Process() { StartInfo = procStartInfo };
            proc.Start();

            return proc.StandardOutput.ReadToEnd().Replace("UUID", string.Empty).Trim().ToUpper();
        }
        public static byte[] GenerateSalt()
        {
            const int SaltLength = 64;
            byte[] salt = new byte[SaltLength];

            var Rand = RandomNumberGenerator.Create();
            Rand.GetBytes(salt);

            return salt;
        }
        public static byte[] GenerateHash(string password, byte[] salt)
        {
            byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
            byte[] saltedPassword = new byte[salt.Length + passwordBytes.Length];

            return MD5.HashData(saltedPassword);
        }
        public static string GetHashPassword(string password)
        {
            byte[] salt = GenerateSalt();
            byte[] Hash = GenerateHash(password, salt);
            string HashString = Convert.ToBase64String(Hash);
            return HashString;

        }
    }
    }