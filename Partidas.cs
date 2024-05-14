using HelloWorld;
using System;
using System.Collections;
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
            string nombreCuenta, valor, fecha, endAnswer;
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
                        Console.WriteLine("No se ha desarrollado.");
                    }

                    else if (answer == "n")
                    {
                        /*
                         * Sistema de partidas manual
                                                    */
                        bool terminado = false;

                        do
                        {
                            //INICIO DE PARTIDA
                            dict = FileManagerSystem.Lectura(@"c:\ProgramaConta\Nomenclatura1.csv", true);

                            Console.WriteLine("\nNombre de la cuenta a modificar: ");
                            nombreCuenta = Console.ReadLine().Trim();

                            var query = dict.Keys.Where(key => key.Contains(nombreCuenta)).ToList();

                            try
                            {
                                if (!dict.TryGetValue(query.ElementAt(0), out id))
                                {

                                }
                            }
                            catch
                            {
                                Console.Clear();
                                Console.WriteLine($"No existe la cuenta {nombreCuenta}");
                                return;
                            }

                            Console.WriteLine("¿De cuanto es el valor que modificara?\nADVERTENCIA: Si es un activo, gasto o costo de venta, dejarlo positivamente si aumenta\nSi disminuye, ponerlo en negativo:");
                            valor = Console.ReadLine().ToLower();

                            /*
                             AUTOMATIZAR EL INGRESO DE VALORES, OSEA SIN EXPLICACIONES
                             MEJORAR EL SISTEMA DE FECHAS, NO ESTAR INGRESANDO TODO EL TIEMPO
                             HACER VISUALIZACION DE PARTIDAS DINAMICA (Hay que hacerlo leyendo el csv)
                             PRACTICAR YA EL TEMA DE PEDIR VALORES (PARA CALCULAR)
                             EMPEZAR YA CON EL BALANCE DE SALDOS
                             EMPEZAR YA CON LOS EF
                             */

                            Console.WriteLine("¿Fecha del movimiento?");
                            fecha = Console.ReadLine().ToLower();


                            foreach (var cuenta in listaCuentas)
                            {
                                if (cuenta.ID == id)
                                {
                                    string clasfCuenta;
                                    clasfCuenta = cuenta.IngresoPartida(fecha, valor, query.ElementAt(0));
                                    FileManagerSystem.ModificacionPartida(fecha, valor, query.ElementAt(0), clasfCuenta);
                                }
                            }

                            Console.WriteLine("¿ULTIMO MOVIMIENTO DE ESTA PARTIDA? Y/N | Si/No");
                            endAnswer = Console.ReadLine().ToLower();

                            if (endAnswer == "y" || endAnswer == "si" || endAnswer == "afirmativo")
                            {
                                terminado = true;
                            }
                            else if(endAnswer == "n" || endAnswer == "no" || endAnswer == "negativo")
                            {
                                Console.Clear();
                                Console.WriteLine("Reingresando a la misma partida.");
                            }
                            else
                            {
                                Console.Clear();
                                Console.WriteLine("Reingresando a la misma partida.");
                            }
                        }
                        while (!terminado);

                        

                    }

                    else { Console.Clear(); Console.WriteLine("No respondiste nada, volviendo al menu principal"); }
                    
                    break;

                case 4:
                    //INICIO DE PARTIDA
                    dict = FileManagerSystem.Lectura(@"c:\ProgramaConta\Nomenclatura1.csv", true);

                    Console.WriteLine("Nombre de la cuenta a visualizar: ");
                    nombreCuenta = Console.ReadLine();


                    var query2 = dict.Keys.Where(key => key.Contains(nombreCuenta)).ToList();

                    try
                    {
                        if (!dict.TryGetValue(query2.ElementAt(0), out id))
                        {

                        }
                    }
                    catch
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

                            for( int i = 0; i < cuenta.fechas.Count; i++ )
                            {
                                Console.WriteLine(cuenta.fechas[i].ToString() + " | " + cuenta.valores.ToString());
                            }
                            
                        }
                    }
                    break;
            }
        }
    }
}
