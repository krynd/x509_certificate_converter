/*
 *  SMIME_CSharp
 *  Author: Robert Hritz
 *  Purpose: Convert base64-encoded string provided by web host to certificate
 *              Anonymized version uploaded to GitHub as proof of work.
 *  Version: 1.0
 *  Date: 2018-05-19
 *  
 *  Planned revisions: Add error handling, ability to select various certificate formats from drop-down, logging.
 *  Future major revision: Convert to general purpose certificate converter
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cert_Creator_SMIME_CSharp
{
    class Program
    {
        static void Main(string[] args)
        {


            var tempPath = System.IO.Path.GetTempPath();
            var certOut = tempPath + "cert.crt";
            var certPass = "password";

            var base64Cert = "base64 encoded string";
            var cert = new System.Security.Cryptography.X509Certificates.X509Certificate2(Convert.FromBase64String(base64Cert), certPass, System.Security.Cryptography.X509Certificates.X509KeyStorageFlags.PersistKeySet);


            if (cert != null)
            {
                var b = new System.IO.BinaryWriter(System.IO.File.Open(certOut, System.IO.FileMode.Create));

                var binCert = cert.Export(System.Security.Cryptography.X509Certificates.X509ContentType.Cert, certPass);
                b.Write(binCert);
            }
        }
    }
}
