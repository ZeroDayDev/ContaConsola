using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ContaConsola.Clases;

namespace ContaConsola
{
    internal class EF
    {
        public static void Funciones(int Pointer, List<Clases.Cuentas> listaCuentas)
        {
            string nombreCuenta, valor, fecha = "{no existente}", endAnswer;
            int id;

            Dictionary<string, int> dict = new Dictionary<string, int>();

            string answer;

            switch (Pointer)
            {
                case 2:

                    //Crear el ER y BG de una vez, ya estoy cansado

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
                    dict = FileManagerSystem.LecturaNomenclatura(@"c:\ProgramaConta\Nomenclatura1.csv", false);
                    string filePath = @"c:\ProgramaConta\Partidas\Junio.csv";
                    List<int> sumasTotal = new List<int>();
                    List<int> debeTotal = new List<int>();
                    List<int> haberTotal = new List<int>();

                    try
                    {
                        if (!File.Exists(@"c:\ProgramaConta\Partidas\Junio.csv"))
                        {
                            Console.WriteLine("El archivo de lectura es inexistente, prueba con otro.");
                        }

                        using (StreamReader sr = File.OpenText(@"c:\ProgramaConta\Partidas\Junio.csv"))
                        {
                            string s = "";
                            Console.Clear();

                            while ((s = sr.ReadLine()) != null)
                            {

                                string[] ids = s.Split(";");
                                string myKey = "";


                                foreach (Cuentas cuenta in listaCuentas)
                                {
                                    myKey = dict.FirstOrDefault(x => x.Value == cuenta.ID).Key;

                                    if (ids[1] == myKey)
                                    {
                                        if (ids[0] == "si" || ids[0] == "Fecha")
                                        {
                                            int sumasCuenta = cuenta.valores.Sum(x => Convert.ToInt32(x));


                                            if (cuenta.Clasificacion == "Activos" || cuenta.Clasificacion == "Activos Corrientes" || cuenta.Clasificacion == "Activos No corrientes" || cuenta.Clasificacion == "Activos Fijos" || cuenta.Clasificacion == "Gastos" || cuenta.Clasificacion == "Costo de venta")
                                            {
                                                cuenta.valores.ForEach(x =>
                                                {
                                                    if (Convert.ToInt32(x) > 0)
                                                    {
                                                        debeTotal.Add(Convert.ToInt32(x));
                                                    }                                                    
                                                    if (Convert.ToInt32(x) < 0)
                                                    {
                                                        haberTotal.Add(Convert.ToInt32(x) * -1);
                                                    }
                                                });
                                            }

                                            if (cuenta.Clasificacion == "Pasivos" || cuenta.Clasificacion == "Pasivos No corrientes" || cuenta.Clasificacion == "Patrimonio" || cuenta.Clasificacion == "Ingresos")
                                            {
                                                cuenta.valores.ForEach(x =>
                                                {
                                                    if (Convert.ToInt32(x) < 0)
                                                    {
                                                        debeTotal.Add(Convert.ToInt32(x));
                                                    }
                                                    if (Convert.ToInt32(x) > 0)
                                                    {
                                                        haberTotal.Add(Convert.ToInt32(x) * -1);
                                                    }
                                                });

                                                sumasCuenta = sumasCuenta * -1;
                                            }

                                            sumasTotal.Add(sumasCuenta);

                                            //cuenta.valores.ForEach(valores => Console.WriteLine(valores));
                                            //Console.WriteLine(myKey);
                                            Console.WriteLine($"{myKey}     |     Saldo: Q{sumasCuenta}");
                                        }
                                    }
                                }

                            }
                        }

                        int debeFinal = debeTotal.Sum(x => Convert.ToInt32(x));
                        int haberFinal = haberTotal.Sum(x => Convert.ToInt32(x));
                        int totalFinal = sumasTotal.Sum(x => Convert.ToInt32(x));
                        Console.WriteLine("\nEl total del debe es de Q" + debeFinal);
                        Console.WriteLine("El total del haber es de Q" + haberFinal);
                        Console.WriteLine("El total de es de Q" + totalFinal + "\n");

                        Console.WriteLine("\nPulsa cualquier tecla para salir");
                        Console.ReadLine();
                        Console.Clear();
                    }

                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.ToString());
                    }
                    break;

                case 4:
                    dict = FileManagerSystem.LecturaNomenclatura(@"c:\ProgramaConta\Nomenclatura1.csv", true);

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




                    break;
            }
        }

    }
}
