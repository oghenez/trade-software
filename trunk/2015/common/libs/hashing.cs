using System;
using System.Text;
using System.Security.Cryptography;

namespace common
{
    /// <summary>
    /// Hash algorithms
    /// </summary>
    public enum HashType : int
    {
        SHA1,
        SHA256,
        SHA384,
        SHA512,
        MD5,
        RIPEMD160
    }

    public static class Hash
    {
        public static string FromString(string input, HashType hashtype)
        {
            Byte[] clearBytes;
            Byte[] hashedBytes;
            string output = String.Empty;

            switch (hashtype)
            {
                case HashType.RIPEMD160:
                    clearBytes = new UTF8Encoding().GetBytes(input);
                    RIPEMD160 myRIPEMD160 = RIPEMD160Managed.Create();
                    hashedBytes = myRIPEMD160.ComputeHash(clearBytes);
                    output = BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
                    break;
                case HashType.MD5:
                    clearBytes = new UTF8Encoding().GetBytes(input);
                    hashedBytes = ((HashAlgorithm)CryptoConfig.CreateFromName("MD5")).ComputeHash(clearBytes);
                    output = BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
                    break;
                case HashType.SHA1:
                    clearBytes = Encoding.UTF8.GetBytes(input);
                    SHA1CryptoServiceProvider sha1 = new SHA1CryptoServiceProvider();
                    sha1.ComputeHash(clearBytes);
                    hashedBytes = sha1.Hash;
                    sha1.Clear();
                    output = BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
                    break;
                case HashType.SHA256:
                    clearBytes = Encoding.UTF8.GetBytes(input);
                    SHA256 sha256 = new SHA256Managed();
                    sha256.ComputeHash(clearBytes);
                    hashedBytes = sha256.Hash;
                    sha256.Clear();
                    output = BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
                    break;
                case HashType.SHA384:
                    clearBytes = Encoding.UTF8.GetBytes(input);
                    SHA384 sha384 = new SHA384Managed();
                    sha384.ComputeHash(clearBytes);
                    hashedBytes = sha384.Hash;
                    sha384.Clear();
                    output = BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
                    break;
                case HashType.SHA512:
                    clearBytes = Encoding.UTF8.GetBytes(input);
                    SHA512 sha512 = new SHA512Managed();
                    sha512.ComputeHash(clearBytes);
                    hashedBytes = sha512.Hash;
                    sha512.Clear();
                    output = BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
                    break;
            }
            return output;
        }
    }
}