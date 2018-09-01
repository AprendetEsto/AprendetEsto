/*
 * Proyecto: EscrituraXML
 * Descripción: Este proyecto se realizo con la finalidad de ejemplificar lo mencionado
 * en la publicación "Escritura archivos xml - XmlDocument"
 * Fecha: 2018-06-30 
 * UrlPublicacion: https://aprendetesto.blogspot.com/2018/06/escritura-de-archivos-xml-xmldocument.html
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Xml;   //Referencia a namespace System.Xml
using System.IO;

namespace EscrituraXML
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Presiona una tecla para comenzar...");
            Console.ReadLine();

            try
            {
                getXmlEjemplo();
            }
            catch (Exception ex)
            {
                Console.WriteLine(string.Format("Algo salio mal: {0}", ex.Message));                
            }

            Console.WriteLine("Presiona una tecla para terminar...");
            Console.ReadLine();
        }


        /// <summary>
        /// Construye y guarda la estructura XML en la ruta definida.
        /// </summary>
        private static void getXmlEjemplo()
        {                                    
            try
            {                
                XmlDocument oXml = new XmlDocument();   //Instancia de objeto XmlDocument que representa un XML

                /*Nodo Usuario*/
                XmlElement oUsuario = oXml.CreateElement("Usuario");
                oUsuario.SetAttribute("nombre", "Wade");
                oUsuario.SetAttribute("apellido", "El deforme Wilson");

                /*Nodo Usuario:Perfil*/
                XmlElement oPerfil = oXml.CreateElement("Perfil");
                oPerfil.SetAttribute("fechaRegistro", "2018-06-30T17:31:02");
                oPerfil.SetAttribute("status", "activo");

                /*Nodo Usuario:Preferenicas*/
                XmlElement oPreferencias = oXml.CreateElement("Preferencias");
                oPreferencias.SetAttribute("status","true");

                /*Nodos Usuario:Preferenicas:Preferencia*/
                XmlElement oPreferencia_1 = oXml.CreateElement("Preferencia");
                oPreferencia_1.SetAttribute("Programacion", "C#, ASP.NET, MVC, Lotlin, MongoDB, WebService");

                XmlElement oPreferencia_2 = oXml.CreateElement("Preferencia");
                oPreferencia_2.SetAttribute("Cocina", "Recetas a la parrilla, mariscos, comida picante");

                XmlElement oPreferencia_3 = oXml.CreateElement("Preferencia");
                oPreferencia_3.SetAttribute("Gatos", "Gorditos y bonitos, miau!");
                
                /*Se agregan los nodos hijo "Preferencia" dentro de su nodo padre "Preferencias"*/
                oPreferencias.AppendChild(oPreferencia_1);
                oPreferencias.AppendChild(oPreferencia_2);
                oPreferencias.AppendChild(oPreferencia_3);

                oUsuario.AppendChild(oPerfil);          /*Se agrega el nodo Perfil como hijo de nodo Usuario*/
                oUsuario.AppendChild(oPreferencias);    /*Se agrega el nodo Preferencias como hijo de nodo Usuario*/

                oXml.AppendChild(oUsuario);             /*El nodo padre Usuario se agrega al documento XML*/
                oXml.Save(@"C:\Exactamente\donde\lo\voy\a\guardar\UsuarioXML.xml");
            }
            catch (Exception ex)
            {                
                throw ex;
            }
        }




    }
}
