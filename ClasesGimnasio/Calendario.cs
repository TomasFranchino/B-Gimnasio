using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ClasesGimnasio
{
    public class Calendario
    {
        public int id {  get; set; }
        public int dniProfesor { get; set; }
        public string titulo { get; set; }
        public string nombre { get; set; }
        public List<Clases> clases { get; set; }

        public Calendario(int id, int dniProfesor, string titulo, string nombre, List<Clases> clases)
        {
            this.id = id;
            this.dniProfesor = dniProfesor;
            this.nombre = nombre;
            this.titulo = titulo;
            this.clases = clases;
        }
        public Calendario() { }
     
        public int calcularSueldoProfe(int id)
        {
            int sueldo =0;
            List<Calendario> profe = Repositorio.calendarios.FindAll(x => x.id == id);
            foreach (var profesor in profe)
            {
                foreach (var clase in profesor.clases)
                {
                    sueldo = (clase.cantAlumnos * 5000) + sueldo;
                }
            }
            return sueldo;
        }
        
        public bool clasesSinAlumnos(int id)
        {
            bool respuesta = false;
            List<Calendario> profe = Repositorio.calendarios.FindAll(x => x.id == id);
            foreach(var profesor in profe)
            {
                foreach (var clase in profesor.clases)
                {
                    if (clase.cantAlumnos == 0)
                    {
                        respuesta = true;
                    }
                }
            }
            return respuesta;
        }
    };  

}

