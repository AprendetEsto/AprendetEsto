/* 
   * Proyecto: Validación de XML utilizando su respectivo XSD
   * Descripción: Valida XML correspondientes a un CFDI v3.3 (facturación SAT, México)
   * Fecha: 2018-08-19
   * UrlPublicacion: https://aprendetesto.blogspot.com/2018/08/validacion-xml-tipo-cfdi-contra-su-xsd.html
*/

using System;
using System.Collections.Generic;
using System.Text;

using System.IO;
using System.Xml;
using System.Xml.Schema;

namespace ValidacionXSD
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Presiona una tecla para comenzar...");
            Console.ReadLine();

            try
            {
                /* Lectura de cfdi */
                string sPathXML = @".\xml\cfdi_1.xml";
                byte[] yXml = File.ReadAllBytes(sPathXML);

                /* Llamado al método y verificación de resultado */
                string sResultado = Valida_con_XSD(yXml);
                if (string.IsNullOrWhiteSpace(sResultado))
                {
                    Console.WriteLine("Xml válido.");
                    Console.ReadLine();
                }

                Console.WriteLine("Xml inválido: " + sResultado);

            }
            catch (Exception ex)
            {

                throw;
            }

            Console.WriteLine("Presiona una tecla para terminar...");
            Console.ReadLine();
        }


        /// <summary>
        /// Método de validación XML contra XSD
        /// </summary>
        /// <param name="yXML">Secuencia de bytes del XML</param>
        /// <returns>string. Empty si el resultado es válido de lo contrario devuleve un mensaje con información del error</returns>
        private static string Valida_con_XSD(byte[] yXML)
        {
            MemoryStream oMemoStream = null;
            XmlReader oXmlReader = null;
            XmlReaderSettings oXmlReadSettings = null;

            try
            {
                /* Configuración del validador */
                oXmlReadSettings = new XmlReaderSettings();
                oXmlReadSettings.ValidationType = ValidationType.Schema;

                /* Colección de archivos XSD */
                XmlSchemaSet oSchemaSet = new XmlSchemaSet();
                oSchemaSet.XmlResolver = null;
                oSchemaSet.Add(null, @".\xsd\cfdv33.xsd");
                oSchemaSet.Add(null, @".\xsd\catCFDI.xsd");
                oSchemaSet.Add(null, @".\xsd\tdCFDI.xsd");
                oSchemaSet.Compile();

                /* Asignación de shcemas */
                oXmlReadSettings.Schemas = oSchemaSet;                

                /* Lectura y validación del CFDI*/
                oMemoStream = new MemoryStream(yXML);
                oXmlReader = XmlReader.Create(oMemoStream, oXmlReadSettings);
                while (oXmlReader.Read()) { }

                return string.Empty;
            }
            catch(XmlSchemaException XmlSchemaEx)
            {
                /* Captura de mensajes */
                return XmlSchemaEx.Message;
            }
            catch(XmlException XmlEx)
            {
                /* Captura de mensajes */
                return XmlEx.Message;
            }
            catch (Exception ex)
            {
                /* Algo salio muy mal 7n7 */
                throw;
            }
        }

        
    }
}
