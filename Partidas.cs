using HelloWorld;
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
        
        public static void Funciones(int Pointer, List<Clases.Cuentas> listaCuentas)
        {
            string nombreCuenta, valor, fecha;
            int id;

            Dictionary<string, int> dict = new Dictionary<string, int>();

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


                        dict = FileManagerSystem.Lectura(@"c:\ProgramaConta\Nomenclatura1.csv", true);

                        //INICIO DE PARTIDA
                        Console.WriteLine("Nombre de la cuenta a modificar: ");
                        nombreCuenta = Console.ReadLine();

                        if (!dict.TryGetValue(nombreCuenta, out id))
                        {
                            Console.Clear();
                            Console.WriteLine($"No existe la cuenta {nombreCuenta}");
                            return;
                        }



                        Console.WriteLine("¿De cuanto es el valor que modificara?\nADVERTENCIA: Si es un activo, gasto o costo de venta, dejarlo positivamente si aumenta\nSi disminuye, ponerlo en negativo:");
                        valor = Console.ReadLine().ToLower();

                        Console.WriteLine("¿Fecha del movimiento?");
                        fecha = Console.ReadLine().ToLower();

                        foreach(var cuenta in listaCuentas)
                        {
                            if (cuenta.ID == id)
                            {
                                cuenta.IngresoPartida(fecha, valor, nombreCuenta);
                            }
                        }

                    }

                    else { Console.Clear(); Console.WriteLine("No respondiste nada, volviendo al menu principal"); }
                    
                    break;

                case 4:
                    //INICIO DE PARTIDA
                    dict = FileManagerSystem.Lectura(@"c:\ProgramaConta\Nomenclatura1.csv", true);

                    Console.WriteLine("Nombre de la cuenta a visualizar: ");
                    nombreCuenta = Console.ReadLine();

                    if (!dict.TryGetValue(nombreCuenta, out id))
                    {
                        Console.Clear();
                        Console.WriteLine($"No existe la cuenta {nombreCuenta}");
                        return;
                    }

                    foreach (var cuenta in listaCuentas)
                    {
                        if (cuenta.ID == id)
                        {
                            Console.WriteLine("FECHAS    |    VALORES");
                            cuenta.fechas.ForEach(fechas => Console.Write(fechas));
                            Console.Write("  |  ");
                            cuenta.valores.ForEach(valores => Console.Write(valores + "\n"));
                        }
                    }
                    break;
            }
        }
    }
}
