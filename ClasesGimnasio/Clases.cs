using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace ClasesGimnasio
{
    public class Clases
    {
        public int id {  get; set; }
        public string tema {  get; set; }
        public int cantAlumnos {  get; set; }
        public string fechaInicio { get; set; }
        public int  idProfesor {  get; set; }
        public Clases(int id, string tema, int cantAlumnos, string fechaInicio, int idProfesor) 
        {
            this.id = id;
            this.tema = tema;
            this.cantAlumnos = cantAlumnos;
            this.fechaInicio = fechaInicio; 
            this.idProfesor = idProfesor;
        }
        public Clases() { }
        //B-Gimnasio: generar una clase para manejar el calendario del profesor, 
        //tendrá los datos del profesor, su título, y la lista de clases que da, 
        //cada clase tiene su tema, cantidad de gente anotada y fecha de inicio.
        //La clase  calendario tiene que calcular el sueldo el profe, la cual es 
        //5000 por los alumnos que tenga en total de todas las clases y saber si hay
        //clases sin alumnos




    }
}
