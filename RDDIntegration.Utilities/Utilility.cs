using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace RDDIntegration.Utilities
{
    public class Utilility
    {
        public static string GetCurrentTimeStamp()
        {
            var dd = DateTime.Now.Day;
            var mm = DateTime.Now.Month < 10 ? "0" + DateTime.Now.Month : DateTime.Now.Month.ToString();
            var yyyy = DateTime.Now.Year;
            var hours = DateTime.Now.Hour;
            var minutes = DateTime.Now.Minute;
            var seconds = DateTime.Now.Second;
            var timestamp = $"{yyyy}-{mm}-{dd}T{hours}:{minutes}:{seconds}+000000";

            return timestamp;
        }

        public static string SHA512Hash(string input)
        {
            var InputBytes = Encoding.UTF8.GetBytes(input);
            using (var Sha512String = new SHA512Managed())
            {
                var hash = Sha512String.ComputeHash(InputBytes);
                return BitConverter.ToString(hash).Replace("-", "");
            }
        }
    }
}
