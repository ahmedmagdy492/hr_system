using hr_system.Utility;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace hr_system.Repository
{
    public class Sha256Hasher : IPasswordHasher
    {
        private readonly SHA256 sHA256;

        public Sha256Hasher()
        {
            sHA256 = SHA256.Create();
        }
        public string Hash(string password)
        {
            byte[] rawData = sHA256.ComputeHash(Encoding.UTF8.GetBytes(password));
            return Converter.ConvertToByteArrayToStringBuilder(rawData);
        }
    }
}