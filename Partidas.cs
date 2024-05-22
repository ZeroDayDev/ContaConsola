using HelloWorld;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
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
            string nombreCuenta, valor = "", fecha = "{no existente}", endAnswer, archivo = @"c:\ProgramaConta\Partidas\Junio.csv";
            int id = 0;
            List<string> query = new List<string>();

            Dictionary<string, int> dict = new Dictionary<string, int>();

            string answer;

            switch (Pointer)
            {
                case 1:
                    bool terminado = false;

                    Console.WriteLine("MES A JORNALIZAR: ");
                    Console.WriteLine("1. JUNIO");
                    Console.WriteLine("2. JULIO");
                    string archivoAElegir = Console.ReadLine();

                    if(archivoAElegir.Contains("jun") || archivoAElegir.Contains("1"))
                    {
                        archivo = @"c:\ProgramaConta\Partidas\Junio.csv";
                    }        
                        
                    if(archivoAElegir.Contains("jul") || archivoAElegir.Contains("2"))
                    {
                        archivo = @"c:\ProgramaConta\Partidas\Julio.csv";
                    }

                    do
                    {
                        //INICIO DE PARTIDA
                        dict = FileManagerSystem.LecturaNomenclatura(@"c:\ProgramaConta\Nomenclatura1.csv", true);

                        bool cuentaIngresada = false;
                        while (!cuentaIngresada)
                        {
                            Console.WriteLine("\nNombre de la cuenta a modificar: ");
                            nombreCuenta = Console.ReadLine().Trim();

                            query = dict.Keys.Where(key => key.Contains(nombreCuenta)).ToList();

                            try
                            {
                                if (!dict.TryGetValue(query.ElementAt(0), out id)) { }
                                cuentaIngresada = true;
                            }
                            catch
                            {
                                Console.Clear();
                                Console.WriteLine($"No existe la cuenta {nombreCuenta}");
                            }
                        }

                        bool valorIngresado = false;

                        while (!valorIngresado)
                        {
                            Console.WriteLine("¿De cuanto es el valor que modificara?");
                            try
                            {
                                double valorIntroducido = Convert.ToDouble(Console.ReadLine());
                                valor = Convert.ToString(valorIntroducido);
                                valorIngresado = true;
                            }
                            catch
                            {
                                Console.Clear();
                                Console.WriteLine($"NO SE HA INGRESADO UN VALOR VALIDO.\n");
                            }
                        }

                        if(fecha == "{no existente}")
                        {
                            bool fechaIngresada = false;

                            while(!fechaIngresada)
                            {
                                try
                                {
                                    Console.WriteLine($"¿Fecha del movimiento?");
                                    fecha = Console.ReadLine().ToLower().Trim();

                                    if(fecha != "si")
                                    {
                                        fecha = Convert.ToString(DateTime.Parse(fecha));
                                    }

                                    fechaIngresada = true;
                                }
                                catch
                                {
                                    Console.Clear();
                                    Console.WriteLine($"NO SE HA INGRESADO UNA FECHA VALIDA.\n");
                                }
                            }
                        }

                        foreach (var cuenta in listaCuentas)
                        {
                            if (cuenta.ID == id)
                            {
                                string clasfCuenta;
                                clasfCuenta = cuenta.IngresoPartida(fecha, valor, query.ElementAt(0));
                                FileManagerSystem.ModificacionPartida(fecha, valor, query.ElementAt(0), clasfCuenta, archivo);
                            }
                        }

                        Console.WriteLine("¿INGRESAR OTRO MOVIMIENTO? Y/N | Si/No");
                        endAnswer = Console.ReadLine().ToLower();

                        if (endAnswer == "y" || endAnswer == "si" || endAnswer == "afirmativo")
                        {
                            Console.Clear();
                            Console.WriteLine("Reingresando a la misma partida.");
                        }
                        else if(endAnswer == "n" || endAnswer == "no" || endAnswer == "negativo")
                        {
                            terminado = true;

                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("Reingresando a la misma partida.");
                        }
                    }
                    while (!terminado);

                    break;

                case 2:
                    dict = FileManagerSystem.LecturaNomenclatura(@"c:\ProgramaConta\Nomenclatura1.csv", false);
                    List<int> debeTotal = new List<int>();
                    List<int> haberTotal = new List<int>();


                    Console.WriteLine("MES A VISUALIZAR: ");
                    Console.WriteLine("1. JUNIO");
                    Console.WriteLine("2. JULIO");
                    string archivoAElegir2 = Console.ReadLine();

                    if (archivoAElegir2.Contains("jun") || archivoAElegir2.Contains("1"))
                    {
                        archivo = @"c:\ProgramaConta\Partidas\Junio.csv";
                    }

                    if (archivoAElegir2.Contains("jul") || archivoAElegir2.Contains("2"))
                    {
                        archivo = @"c:\ProgramaConta\Partidas\Julio.csv";
                    }

                    try
                    {
                        if (!File.Exists(archivo))
                        {
                            Console.WriteLine("El archivo de lectura es inexistente, prueba con otro.");
                        }

                        using (StreamReader sr = File.OpenText(archivo))
                        {
                            string s = "";
                            Console.Clear();

                            while ((s = sr.ReadLine()) != null)
                            {

                                string[] ids = s.Split(";");

                                Console.WriteLine($"{ids[0]}    |   {ids[1]}    |   {ids[2]}    |   {ids[3]}");

                                try
                                {
                                    if (!string.IsNullOrEmpty(ids[2]))
                                    {
                                        debeTotal.Add(Convert.ToInt32(ids[2]));
                                    }              
                                    
                                    if (!string.IsNullOrEmpty(ids[3]))
                                    {
                                        haberTotal.Add(Convert.ToInt32(ids[3]));
                                    }
                                }
                                catch { }
                            }
                        }

                        Console.WriteLine($"La suma de debe es {debeTotal.Sum(x => Convert.ToInt32(x))}");
                        Console.WriteLine($"La suma de haber es {haberTotal.Sum(x => Convert.ToInt32(x))}");
                        Console.WriteLine("\nPulsa cualquier tecla para salir");
                        Console.ReadLine();
                        Console.Clear();
                    }

                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.ToString());
                    }


                    break;

                case 3:
                    dict = FileManagerSystem.LecturaNomenclatura(@"c:\ProgramaConta\Nomenclatura1.csv", true);

                    Console.WriteLine("MES A VISUALIZAR: ");
                    Console.WriteLine("1. JUNIO");
                    Console.WriteLine("2. JULIO");
                    string archivoAElegir3 = Console.ReadLine();

                    if (archivoAElegir3.Contains("jun") || archivoAElegir3.Contains("1"))
                    {
                        archivo = @"c:\ProgramaConta\Partidas\Junio.csv";
                    }

                    if (archivoAElegir3.Contains("jul") || archivoAElegir3.Contains("2"))
                    {
                        archivo = @"c:\ProgramaConta\Partidas\Julio.csv";
                    }

                    Console.WriteLine("Nombre de la cuenta a visualizar: ");
                    nombreCuenta = Console.ReadLine();

                    var query2 = dict.Keys.Where(key => key.Contains(nombreCuenta)).ToList();

                    try
                    {
                        if (!dict.TryGetValue(query2.ElementAt(0), out id)) { }
                    }
                    catch
                    {
                        Console.Clear();
                        Console.WriteLine($"No existe la cuenta {nombreCuenta}");
                        return;
                    }

                    try
                    {
                        if (!File.Exists(archivo))
                        {
                            Console.WriteLine("El archivo de lectura es inexistente, prueba con otro.");
                        }

                        using (StreamReader sr = File.OpenText(archivo))
                        {
                            string s = "";
                            Console.Clear();
                            Console.WriteLine("\nCuenta   |   Debe    |   Haber");

                            while ((s = sr.ReadLine()) != null)
                            {

                                string[] ids = s.Split(";");

                                if (ids[1] == query2.ElementAt(0))
                                {
                                    Console.WriteLine($"{ids[1]}    |   {ids[2]}    |   {ids[3]}");
                                }
                            }
                        }

                        Console.WriteLine("\nPulsa cualquier tecla para salir");
                        Console.ReadLine();
                        Console.Clear();
                    }

                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.ToString());
                    }


                    break;
            }
        }

    }
}
