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
                        string id, nombrecuenta, valor, fecha; 

                        Console.WriteLine("Cuenta a modificar (ID o nombre): ");
                        id = Console.ReadLine().ToLower();
                        nombrecuenta = id;

                        Console.WriteLine("¿De cuanto es el valor que modificara?\nADVERTENCIA: Si es un activo, gasto o costo de venta, dejarlo positivamente si aumenta\nLo mismo al contrario del resto de cuentas:");
                        valor = Console.ReadLine().ToLower();

                        Console.WriteLine("¿Fecha del movimiento?");
                        fecha = Console.ReadLine().ToLower();

                        Clases.Cuentas cuenta = new Clases.Cuentas(1, "activo");
                    }

                    else { Console.Clear(); Console.WriteLine("No respondiste nada, volviendo al menu principal"); }
                    
                    break;
            }
        }
    }
}
