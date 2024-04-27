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
                    Console.Read();
                    Console.Clear();
                    break;
            }
        }
    }

}
