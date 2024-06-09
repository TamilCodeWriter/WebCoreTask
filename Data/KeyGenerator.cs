namespace WebCoreTask.Data
{
    using System;
    using System.Security.Cryptography;

    public class KeyGenerator
    {
        public static byte[] GenerateRandomKey(int keySizeInBytes)
        {
            if (keySizeInBytes < 32)
            {
                throw new ArgumentOutOfRangeException(nameof(keySizeInBytes), "Key size must be at least 256 bits (32 bytes) for HMAC-SHA256.");
            }

            byte[] key = new byte[keySizeInBytes];
            using (var rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(key);
            }
            return key;
        }
    }

}
