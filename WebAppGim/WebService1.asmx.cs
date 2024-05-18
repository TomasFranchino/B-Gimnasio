using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using ClasesGimnasio;

namespace WebAppGim
{
    /// <summary>
    /// Descripción breve de WebService1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class WebService1 : System.Web.Services.WebService
    {
        [WebMethod]
        public void PostProfesor(Calendario profe)
        {
            Repositorio.calendarios.Add(profe);
        }

        [WebMethod]
        public List<Calendario> GetProfesores()
        {
            return Repositorio.calendarios;
        }

        [WebMethod]
        public Calendario GetProfesor(int id)
        {
            return Repositorio.calendarios.Find(x => x.id == id);
        }

        [WebMethod]
        public void DeleteProfesor(int id)
        {
            Calendario profe = Repositorio.calendarios.Find(x => x.id == id);
            Repositorio.calendarios.Remove(profe);
        }

        [WebMethod]
        public void PutProfesor(Calendario nuevoProfe)
        {
            Calendario profe = Repositorio.calendarios.Find(x => x.id == nuevoProfe.id);
            Repositorio.calendarios.Remove(profe);
            Repositorio.calendarios.Add(nuevoProfe);
        }

        [WebMethod]
        public int CalcularSueldoProfe(int id)
        {
            Calendario profe = new Calendario();
            return profe.calcularSueldoProfe(id);
        }

        [WebMethod]
        public bool ClasesSinAlumnos(int id)
        {
            Calendario profe = new Calendario();
            return profe.clasesSinAlumnos(id);
        }

        [WebMethod]
        public List<Clases> GetClases()
        {
            return Repositorio.clases;
        }

        [WebMethod]
        public Clases GetClase(int id)
        {
            return Repositorio.clases.Find(x => x.id == id);
        }

        [WebMethod]
        public void DeleteClase(int id)
        {
            Clases clase = Repositorio.clases.Find(x => x.id == id);
            Repositorio.clases.Remove(clase);
        }

        [WebMethod]
        public void PutClases(Clases nuevaClase)
        {
            Clases clase = Repositorio.clases.Find(x => x.id == nuevaClase.id);
            Repositorio.clases.Remove(clase);
            Repositorio.clases.Add(nuevaClase);
        }

        [WebMethod]
        public void PostClase(Clases clase)
        {
            Repositorio.clases.Add(clase);
        }
    }
}
