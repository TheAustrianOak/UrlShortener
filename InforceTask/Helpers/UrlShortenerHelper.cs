using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InforceTask.Helper
{
    public static class UrlShortenerHelper
    {
        private const int NUMBER_OF_CHARACTERS = 6;
        public static string ToUniqueBase64Url(this Guid guid, int characters)
        {
            var base64 = Convert.ToBase64String(guid.ToByteArray()).Replace("/", string.Empty).Replace("+", string.Empty);
            return base64.Substring(0, characters);
        }

        public static string Generate()
        {
            var code = Guid.NewGuid().ToUniqueBase64Url(NUMBER_OF_CHARACTERS);

            return code;
        }
    }
}
