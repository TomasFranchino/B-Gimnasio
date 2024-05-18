using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClasesGimnasio
{
    public class Singleton
    {
        private static Singleton instancia;
        private static string Opercion = "";
        private static string Version = "Version0.15";
        private static string Usuario="";
        public Singleton()
        {

        }

        public static Singleton Instancia
        {
            get
            {
                if (instancia == null)
                {
                    instancia = new Singleton();
                    
                }
                return instancia;
            }
        }
        public static string obtenerVersion()
        {
            return Version;
        }
        public static void establecerUsuario(string usuario)
        {
            Usuario = usuario;
        }
        public static string obtenerUsuario() 
        {
            return Usuario;
        }

        public static void Suma()
        {
            Opercion = "Suma";
            int a = 2;
            int b = 5;
            int suma = a+b;
            string contenido = "Operacion = "+Opercion + suma.ToString()+Version+Usuario; 
            File.WriteAllText("C:/Programacion/cacho.txt", contenido.ToString());
        }

    }
}

