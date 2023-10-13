using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaWindowsForms
{
    internal class CMenuPrincipal
    {
        //Definición de variables globales.
        public static string origen = @"Archivos/Usuarios.txt";
        public static string tempUsuario = "";
        public static string tempClave = "";
        public static string respuesta = "";
        public static string[,] usuarios = new string[1000, 1];

        //Métodos.
        public static string iniciarSesion(string usuario, string clave)
        {
            //Condición para determinar si es el administrador o no.
            if (usuario == "admin")
            {
                if (clave == "admin")
                {
                    respuesta = "admin";
                }
                else
                {
                    respuesta = "¡Contraseña inválida!";
                }
            }
            else
            {
                //Si el archivo especificado por path no existe, se crea.
                string path = origen;
                if (!File.Exists(path))
                {
                    //Crear un archivo para escribir. 
                    using (StreamWriter sw = File.CreateText(path))
                    {

                    }
                }

                //Abrir el archivo del que se va a leer. 
                using (StreamReader sr = File.OpenText(path))
                {
                    string s = "";
                    while ((s = sr.ReadLine()) != null)
                    {
                        Console.WriteLine(s);
                    }
                }

                //Ciclo para validar si el usuario existe y la contraseña es válida. 
                foreach (string line in System.IO.File.ReadLines(origen))
                {
                    string[] vectorFila = line.Split(',');
                    if (usuario == vectorFila[0])
                    {
                        tempUsuario = vectorFila[0];
                        tempClave = vectorFila[1];
                    }
                }

                //Condición para validar si el usuario y la contraseña existen en la base de datos.
                if (usuario == tempUsuario)
                {
                    if (clave == tempClave)
                    {
                        respuesta = "user";
                    }
                    else
                    {
                        respuesta = "¡Contraseña inválida!";
                    }
                }
                else
                {
                    respuesta = "¡El usuario no existe!";
                }
            }
            return respuesta;
        }
    }
}
