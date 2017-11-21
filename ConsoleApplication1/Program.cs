using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Text;

namespace Crtypto
{
    using System.Net.Json;

    class Program
    {
        static void Main(string[] args)
        {
            // generating public/private keys
            //
            //Debug.WriteLine("private: " + RSA.ToXmlString(true));
            //Debug.WriteLine("public: " + RSA.ToXmlString(false));

            var publicKey =
                "<RSAKeyValue><Modulus>51l+rhtsFd/CsNoE9Uoduj+KEjwAvafTfb57vev+wovQn7hUDkw9BmUL97RH/sh/nuSvBIwDdeUVSg2Ciz8lNLrf4Y5e2b55KMePsGyHWoZmxinGPS7ur4KJHOfeBa+GxdC8/4pWBJ6E+pBj3dCbPDPKYVz7DQMHdXcQZ4Bq4v8=</Modulus><Exponent>AQAB</Exponent></RSAKeyValue>";

            //var privateKey =
              //  "<RSAKeyValue><Modulus>21wEnTU+mcD2w0Lfo1Gv4rtcSWsQJQTNa6gio05AOkV/Er9w3Y13Ddo5wGtjJ19402S71HUeN0vbKILLJdRSES5MHSdJPSVrOqdrll/vLXxDxWs/U0UT1c8u6k/Ogx9hTtZxYwoeYqdhDblof3E75d9n2F0Zvf6iTb4cI7j6fMs=</Modulus><Exponent>AQAB</Exponent><P>/aULPE6jd5IkwtWXmReyMUhmI/nfwfkQSyl7tsg2PKdpcxk4mpPZUdEQhHQLvE84w2DhTyYkPHCtq/mMKE3MHw==</P><Q>3WV46X9Arg2l9cxb67KVlNVXyCqc/w+LWt/tbhLJvV2xCF/0rWKPsBJ9MC6cquaqNPxWWEav8RAVbmmGrJt51Q==</Q><DP>8TuZFgBMpBoQcGUoS2goB4st6aVq1FcG0hVgHhUI0GMAfYFNPmbDV3cY2IBt8Oj/uYJYhyhlaj5YTqmGTYbATQ==</DP><DQ>FIoVbZQgrAUYIHWVEYi/187zFd7eMct/Yi7kGBImJStMATrluDAspGkStCWe4zwDDmdam1XzfKnBUzz3AYxrAQ==</DQ><InverseQ>QPU3Tmt8nznSgYZ+5jUo9E0SfjiTu435ihANiHqqjasaUNvOHKumqzuBZ8NRtkUhS6dsOEb8A2ODvy7KswUxyA==</InverseQ><D>cgoRoAUpSVfHMdYXW9nA3dfX75dIamZnwPtFHq80ttagbIe4ToYYCcyUz5NElhiNQSESgS5uCgNWqWXt5PnPu4XmCXx6utco1UVH8HGLahzbAnSy6Cj3iUIQ7Gj+9gQ7PkC434HTtHazmxVgIR5l56ZjoQ8yGNCPZnsdYEmhJWk=</D></RSAKeyValue>";
            var privateKey =
                "<RSAKeyValue><Modulus>51l+rhtsFd/CsNoE9Uoduj+KEjwAvafTfb57vev+wovQn7hUDkw9BmUL97RH/sh/nuSvBIwDdeUVSg2Ciz8lNLrf4Y5e2b55KMePsGyHWoZmxinGPS7ur4KJHOfeBa+GxdC8/4pWBJ6E+pBj3dCbPDPKYVz7DQMHdXcQZ4Bq4v8=</Modulus><Exponent>AQAB</Exponent><P>+QvGlLMxjvLhrEf/ZoMuVIAGNq1xzaJmpfBka4t3lcDYGlhQR59vsYaNDl3U43iUYgrXkCmlUgEpyApTKNa/tQ==</P><Q>7c843Eetk3JjxAQD1JPh4C1N6Crx+dX5cIy5gldcd789XzrESgSP8DX7ySjnOeWflDvirGHzaSWvfVi3J5vAYw==</Q><DP>ORDasu4QmAnNbjWdLzc14YToZ5T8s7rXvIRF7mKpxzXGDttXoeHFrS8AmV8kze6uSXzkghMY356GnWDIR15V1Q==</DP><DQ>HyT/dmHwypm1lStNcR64+0oTpO9S53xtgZ78gKR+WLR0Di+9G1CDpVr8kbjIp516C8jYA+mEHmYwGINw4UAVrw==</DQ><InverseQ>RUz0T08x6Rhx8SdLCgPUsMzrJoojB6CNdv2JNpsZ7cgsY508DB00wodBQkzotHbtAXSkUl7gtAr4LiEz5NENzg==</InverseQ><D>IVeOFin16rR20DB+V3BTls89JxdGZLmmatsZkAvONHFHDhstjhP3FZAEPgeu+pgggHYP3UAP6EgC80sS0zO0uOhtPb349e9+6Zxe22aietY1ZlYPOm5v/XlNGfXNed/n8TaBYDpwbvSUL4Oc5xRNyagSlx2/F7Xw4pdBl4poKgU=</D></RSAKeyValue>";

            var testData = Encoding.UTF8.GetBytes("testing");
            Array.Reverse(testData, 0, testData.Length);

            using (var rsa = new RSACryptoServiceProvider())
            {

                try
                {
                    
                    // client encrypting data with public key issued by server
                    //
                    rsa.FromXmlString(publicKey);

                    var encryptedData = rsa.Encrypt(testData, true);

                    var base64Encrypted = Convert.ToBase64String(encryptedData);
                    Console.WriteLine(base64Encrypted);
                    
                }
                finally
                {
                    rsa.PersistKeyInCsp = false;
                }

            }
        }
    }
}
