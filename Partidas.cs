using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ContaConsola
{
    internal class Partidas
    {
        
        public static void Funciones(int Pointer)
        {
            string answer;

            switch (Pointer)
            {
                case 1:
                    Console.WriteLine("¿Usaras el sistema automatico? S/N");
                    answer = Console.ReadLine().ToLower();

                    if (answer == "s")
                    {

                    }

                    else if (answer == "n")
                    {
                        /*
                         * Sistema de partidas manual
                                                    */
                        string nombreCuenta, valor, fecha;
                        int id;
                        Dictionary<string, int> dict = new Dictionary<string, int>();

                        dict = FileManagerSystem.Lectura(@"c:\ProgramaConta\Nomenclatura1.csv");

                        //INICIO DE PARTIDA
                        Console.WriteLine("Nombre de la cuenta a modificar: ");
                        nombreCuenta = Console.ReadLine();

                        if(!dict.TryGetValue(nombreCuenta, out id))
                        {
                            Console.Clear();
                            Console.WriteLine($"No existe la cuenta {nombreCuenta}");
                            return;
                        }

                        Console.WriteLine(id);

                        Console.WriteLine("¿De cuanto es el valor que modificara?\nADVERTENCIA: Si es un activo, gasto o costo de venta, dejarlo positivamente si aumenta\nLo mismo al contrario del resto de cuentas:");
                        valor = Console.ReadLine().ToLower();

                        Console.WriteLine("¿Fecha del movimiento?");
                        fecha = Console.ReadLine().ToLower();

                        Clases.Cuentas cuenta = new Clases.Cuentas(id, "activo");
                    }

                    else { Console.Clear(); Console.WriteLine("No respondiste nada, volviendo al menu principal"); }
                    
                    break;
            }
        }
    }
}
