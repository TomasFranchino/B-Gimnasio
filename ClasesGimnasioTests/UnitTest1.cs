using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Globalization;
using ClasesGimnasio;

namespace ClasesGimnasioTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            //Genero los datos a utilizar
            List<Clases> clases = new List<Clases>
            {
                new Clases(0,"Entrenamiento funcional", 10,"2024-05-15", 3),
                new Clases(1, "Yoga", 5, "2024-05-15", 0)
            };
            Calendario profe = new Calendario(1, 24733598, "Educacion Fisica", "Carmen", clases);
            Repositorio.calendarios = new List<Calendario> { profe };

            //act
            var sueldo = profe.calcularSueldoProfe(1);


            Assert.AreEqual(75000, sueldo);
        }

        [TestMethod]
        public void TestMethod2() 
        {
            //Creo los datos
            var calendario = new Calendario(1, 24733598, "Educacion Fisica", "Carmen", new List<Clases>());
            Repositorio.calendarios = new List<Calendario> { calendario };

            //Act
            var sueldo = calendario.calcularSueldoProfe(1);

            
            Assert.AreEqual(0, sueldo);
        }

        [TestMethod]
        public void TestMethod3() 
        {
            // Creo los datos
            List<Clases> clases = new List<Clases>
            {
                new Clases(0,"Entrenamiento funcional", 10,"2024-05-15", 3),
                new Clases(1, "Yoga", 0, "2024-05-15", 0)
            };
            Calendario profe = new Calendario(1, 24733598, "Educacion Fisica", "Carmen", clases);
            Repositorio.calendarios = new List<Calendario> { profe };

            //act
            var resultado = profe.clasesSinAlumnos(1);

            Assert.IsTrue(resultado);
        }
        
        [TestMethod]
        public void TestMethod4()
        {
            // Creo los datos
            List<Clases> clases = new List<Clases>
            {
                new Clases(0,"Entrenamiento funcional", 10,"2024-05-15", 3),
                new Clases(1, "Yoga", 5, "2024-05-15", 0)
            };
            Calendario profe = new Calendario(1, 24733598, "Educacion Fisica", "Carmen", clases);
            Repositorio.calendarios = new List<Calendario> { profe };

            //act
            var resultado = profe.clasesSinAlumnos(1);

            Assert.IsFalse(resultado);
        }

        

    }
}
