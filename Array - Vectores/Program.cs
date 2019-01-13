/*
 * Proyecto: Array_Vectores
 * Descripción: Este proyecto se realizo como parte de una serie de publicaciones para 
 * describir la definición e implementación de arreglos.
 * Fecha: 2019-01-12
 * UrlPublicación: https://aprendetesto.blogspot.com/2019/01/arreglos-vectores.html
*/

using System;
using System.Collections.Generic;

namespace Array_Vectores
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Presiona una tecla para comenzar...");
            Console.ReadLine();

            ArregloSimple();
            ArregloSimpleVariable(8);
            
            Console.WriteLine("\nIntroduce 5 números enteros");
            ArregloCapturaDeUsuario();

            Console.WriteLine("\nPresiona una tecla para terminar...");
            Console.ReadLine();
        }


        /// <summary>
        /// Representa la definición e inicialización de un array de números
        /// </summary>
        static void ArregloSimple()
        {
            /*Declaración*/
            int[] aiVector_1 = new int[5];
            aiVector_1[0] = 9;
            aiVector_1[1] = 18;
            aiVector_1[2] = 27;
            aiVector_1[3] = 36;
            aiVector_1[4] = 45;

            /*Declaración e inicializació*/
            int[] aiVector_2 = new int[5] { 10, 20, 30, 40, 50 };

            /*Imprimir vectores*/

            Console.Write("Vector 1: ");
            ImprimirArray(aiVector_1);            

            Console.Write("Vector 2: ");
            ImprimirArray(aiVector_2);
        }


        /// <summary>
        /// Arreglo de longitud variables con números enteros
        /// </summary>
        static void ArregloSimpleVariable(int iLongitud)
        {
            int[] iVector_3 = new int[iLongitud];
            for (int i = 0; i < iLongitud; i++)
                iVector_3[i] = i + 1;

            Console.Write("Vector 3: ");
            ImprimirArray(iVector_3);
        }
            

        /// <summary>
        /// Captura 5 números capturados por el usuario y los imprime en pantalla
        /// </summary>
        static void ArregloCapturaDeUsuario()
        {
            int[] iVector_4 = new int[5];
            string sEntrada = string.Empty;

            for (int i = 0; i < iVector_4.Length; i++)
            {
                Console.Write("Escribe un número para la posición " + i + " y presiona enter >>");
                sEntrada = Console.ReadLine();
                iVector_4[i] = Convert.ToByte(sEntrada);
            }

            Console.Write("Vector 4: ");
            ImprimirArray(iVector_4);
        }


        /// <summary>
        /// Imprime los elementos de un vector
        /// </summary>
        /// <param name="aiParam">Vector a imprimir</param>
        static void ImprimirArray(int[] aiParam)
        {
            for (int i = 0; i < aiParam.Length; i++)
                Console.Write(string.Format("{0} ", aiParam[i]));

            Console.WriteLine();
        }


    }
}
