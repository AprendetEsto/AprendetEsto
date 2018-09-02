/*
 * Proyecto: AnalizaCSD
 * Descripción: Este proyecto se realizo con la finalidad de ejemplificar lo mencionado
 * en la publicación "Cómo leer un certificado X509"
 * Fecha: 2018-09-01
 * UrlPublicacion: https://aprendetesto.blogspot.com/2018/09/como-leer-un-certificado-x509.html
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Agregue using
using System.IO;
using System.Security.Cryptography.X509Certificates;

namespace AnalizaCSD
{
    class Program
    {                
        static void Main(string[] args)
        {
            Console.WriteLine("Preisona una tecla para comenzar...");
            Console.ReadLine();

            try
            {
                string sPathCer = "./CSD/CSD01_AAA010101AAA.cer";
                byte[] yCert = File.ReadAllBytes(sPathCer);
                X509Certificate2 oCSD = new X509Certificate2(yCert);

                /*Vigencia del CSD*/
                string sInicio = oCSD.GetEffectiveDateString();
                string sFinal = oCSD.GetExpirationDateString();
                Console.WriteLine("Fecha de inicio del certificado: " + sInicio);
                Console.WriteLine("Fecha de expiración del certificado: " + sFinal);
                Console.WriteLine();

                /*No. de Serie del Certificado*/
                string sNoSerie = Encoding.ASCII.GetString(oCSD.GetSerialNumber().Reverse().ToArray());            
                Console.WriteLine("Número de Serie: " + sNoSerie);
                Console.WriteLine();

                /*Issuer*/
                string sIssuer = oCSD.Issuer;
                Console.WriteLine("Issue: " + sIssuer);
                Console.WriteLine();

                /*El certificado incluye la llave privada?*/
                bool bExisteKey = oCSD.HasPrivateKey;
                Console.WriteLine("Contiene llave privada? - " + bExisteKey.ToString());
                Console.WriteLine();

                /*Subject*/
                string sSubject = oCSD.Subject;
                Console.WriteLine("Subject: " + sSubject);
                Console.WriteLine();

                /*Thubprint*/
                string sThumprint = oCSD.Thumbprint;
                Console.WriteLine("Thumbprint: " + sThumprint);
                Console.WriteLine();

                /*Certificado en base 64*/
                string sCertRaw = Convert.ToBase64String(oCSD.Export(X509ContentType.Cert));
                Console.WriteLine("Certificado: " + sCertRaw);
                Console.WriteLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }

            Console.WriteLine("Preisona una tecla para terminar...");
            Console.ReadLine();
        }       
    }
}
