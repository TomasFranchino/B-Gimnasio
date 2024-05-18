using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ClasesGimnasio
{
    public class Repositorio
    {
        public static List<Clases> clases = new List<Clases>()
        {
        new Clases(0,"Entrenamiento funcional", 10,"2024-05-15", 3),
        new Clases(1, "Yoga", 5, "2024-05-15", 0),
        new Clases(2, "Zumba", 8, "2024-05-20", 2),
        new Clases(3, "Zumba", 6, "2024-05-20", 1)
        };

        public static List<Calendario> calendarios = new List<Calendario>()
        {
        new Calendario(0, 44938493, "Educacion Fisica", "Yani", new List<Clases> {clases[1]}),
        new Calendario(1, 44938493, "Educacion Fisica", "Cati", new List<Clases> {clases[3]}),
        new Calendario(2,44938493, "Educacion Fisica", "Carlos", new List<Clases> {clases[2]}),
        new Calendario(3, 44938493, "Educacion Fisica", "Tomi", new List<Clases> {clases[0]})
        };





        //static Calendario profeCarlos = calendarios[2];
        //static Calendario profeTomi = calendarios[3];
        //static Calendario profeCati = calendarios[1];
        //static Calendario profeYani = calendarios[0];

        //static Clases clase1 = new Clases("Entrenamiento funcional", 10, "2024-05-10", profeYani);
        //static Clases clase2 = new Clases("Yoga", 5, "2024-05-15", profeCati);
        //static Clases clase3 = new Clases("Zumba", 8, "2024-05-20", profeCarlos);
        //static Clases clase4 = new Clases("Zumba", 6, "2024-05-20", profeTomi);
    }
}
