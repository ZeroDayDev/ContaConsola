using ContaConsola;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace HelloWorld
{
    static class Nomenclaturas
    {
        public static void Funciones(int Pointer)
        {
            switch(Pointer)
            {
                case 1:
                    FileManagerSystem.VisualizarNomenclatura(@"c:\ProgramaConta\Nomenclatura1.csv");
                    Console.WriteLine("\nPulsa cualquier tecla para salir");
                    Console.ReadLine();
                    Console.Clear();
                    break;
                case 2:
                    FileManagerSystem.EscrituraInicial(@"c:\ProgramaConta", @"c:\ProgramaConta\Partidas", @"c:\ProgramaConta\EFS");
                    Console.WriteLine("Escritura finalizada.");

                    Console.WriteLine("\nPulsa cualquier tecla para salir");
                    Console.ReadLine();
                    Console.Clear();
                    break;
            }
        }
    }

}
