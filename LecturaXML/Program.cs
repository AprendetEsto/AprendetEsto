/* 
   * Proyecto: LecturaXML
   * Descripción: Este proyecto se realizo con la finalidad de ejemplificar lo mencionado
   * en la publicación "Lectura de archivos xml - XmlDocument"
   * Fecha: 2018-06-30 
   * UrlPublicacion: https://aprendetesto.blogspot.com/2018/07/lectura-de-archivos-xml-xmldocument.html
*/

using System;
using System.Xml;

namespace LecturaXML
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Presiona una tecla para comenzar...");
            Console.ReadLine();

            string sXml = "<Usuario nombre = \"Wade\" apellido = \"El deforme Wilson\">" +
                            "<Perfil fechaRegistro = \"2018-06-30T17:31:02\" status = \"activo\"></Perfil>" +
                                "<Preferencias status = \"true\">" +
                                    "<Preferencia nombre = \"Programacion\" valor = \"C#, ASP.NET, MVC, Kotlin, MongoDB, WebService\"></Preferencia>" +
                                    "<Preferencia nombre = \"Cocina\" valor = \"Recetas a la parrilla, mariscos, comida picante\"></Preferencia>" +
                                    "<Preferencia nombre = \"Gatos\" valor = \"Gorditos y bonitos, miau!\" ></Preferencia>" +
                                "</Preferencias>" +
                          "</Usuario>";

            try
            {
                XmlDocument oXmlDoc = new XmlDocument();
                oXmlDoc.LoadXml(sXml);

                /* - Obtener el valor de Usuario.apellido. */
                string sApellido = oXmlDoc.DocumentElement.GetAttribute("apellido");

                /* - Obtener el valor de Perfil.fechaRegistro. */
                XmlElement oPerfil = ((XmlElement)oXmlDoc.DocumentElement.GetElementsByTagName("Perfil")[0]);
                string sFechaRegistro = oPerfil.GetAttribute("fechaRegistro");

                /* - Obtener el valor de Preferencias:Preferencia.valor donde el atributo nombre tenga el valor Gatos. */
                XmlNodeList oPreferencia = oXmlDoc.DocumentElement.GetElementsByTagName("Preferencia");
                string sValor = string.Empty;

                foreach (XmlElement oNodo in oPreferencia)
                {
                    if (oNodo.GetAttribute("nombre") == "Gatos")
                        sValor = oNodo.GetAttribute("valor");
                }

                /* Mostrar salidas */
                Console.WriteLine(string.Format("Punto 1: {0}", sApellido));
                Console.WriteLine(string.Format("Punto 2: {0}", sFechaRegistro));
                Console.WriteLine(string.Format("Punto 3: {0}", sValor));
            }
            catch (Exception ex)
            {

                throw;
            }

            Console.WriteLine("\r\nPresiona una tecla para terminar...");
            Console.ReadLine();
        }
    }
}
