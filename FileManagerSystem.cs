using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Drawing;

namespace ContaConsola
{
    public class FileManagerSystem
    {
        public static void EscrituraInicial(string pathRaiz, string pathPartidas)
        {
            //Creacion de nomenclatura ejercicio 5
            try
            {
                if (!Directory.Exists(pathRaiz))
                {
                    DirectoryInfo di = Directory.CreateDirectory(pathRaiz);
                    DirectoryInfo di2 = Directory.CreateDirectory(pathPartidas);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            try
            {
                string filePath = @"c:\ProgramaConta\Nomenclatura1.csv";
                if (!File.Exists(filePath))
                {
                    using (StreamWriter sw = File.CreateText(filePath))
                    {
                        sw.WriteLine("1;Activos");
                        sw.WriteLine("11;Activos Corrientes");
                        sw.WriteLine("111;Caja");
                        sw.WriteLine("112;Bancos");
                        sw.WriteLine("113;Inventarios");
                        sw.WriteLine("114;Clientes");
                        sw.WriteLine("115;Documentos por cobrar");
                        sw.WriteLine("116;Seguros por cobrar");
                        sw.WriteLine("117;IVA por cobrar");
                        sw.WriteLine("118;Inversiones");
                        sw.WriteLine("12;Activos No corrientes");
                        sw.WriteLine("121;Activos fijos	");
                        sw.WriteLine("1211;Terrenos");
                        sw.WriteLine("1212;Maquinaria");
                        sw.WriteLine("1213;Vehiculos");
                        sw.WriteLine("1214;Mobiliario y equipo");
                        sw.WriteLine("1215;Equipo de computo");
                        sw.WriteLine("2;Pasivos");
                        sw.WriteLine("21;Pasivos No corrientes");
                        sw.WriteLine("211;Cuota patronal por pagar");
                        sw.WriteLine("212;Cuota laboral por pagar");
                        sw.WriteLine("213;Prestamos Bancarios");
                        sw.WriteLine("214;Proveedores");
                        sw.WriteLine("215;IVA por pagar");
                        sw.WriteLine("216;Acreedores");
                        sw.WriteLine("217;Documentos por pagar");
                        sw.WriteLine("3;Patrimonio");
                        sw.WriteLine("31;Utilidades de años anteriores");
                        sw.WriteLine("32;patrimonio");
                        sw.WriteLine("33;Reserva legal");
                        sw.WriteLine("4;Ingresos");
                        sw.WriteLine("41;Ventas");
                        sw.WriteLine("5;Gastos");
                        sw.WriteLine("51;Bonificacion incentiva");
                        sw.WriteLine("52;Horas extras");
                        sw.WriteLine("53;Sueldos");
                        sw.WriteLine("54;Seguros (Gastos)");
                        sw.WriteLine("55;Cuota patronal");
                        sw.WriteLine("56;Aguinaldo");
                        sw.WriteLine("57;Bono 14");
                        sw.WriteLine("58;Papeleria y utiles");
                        sw.WriteLine("59;Servicios telefonicos");
                        sw.WriteLine("510;Salario de Ventas");
                        sw.WriteLine("511;Salario Administracion");
                        sw.WriteLine("512;Horas extras Ventas");
                        sw.WriteLine("513;Horas extras Administracion");
                        sw.WriteLine("514;Bonificacion incentivo Ventas");
                        sw.WriteLine("6;Costos de venta");
                        sw.WriteLine("61;costo de venta");

                    }
                }

                using (StreamReader sr = File.OpenText(filePath))
                {
                    string s = "";
                    while ((s = sr.ReadLine()) != null)
                    {
                        //Console.WriteLine(s);
                    }
                }
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public static void CreacionPartida()
        {
            string filePath = @"c:\ProgramaConta\Partidas\Partidas.csv";

            try 
            {
                if(!File.Exists(filePath))
                {
                    using (StreamWriter sw = File.CreateText(filePath))
                    {
                        sw.WriteLine("Fecha;Cuentas;Debe;Haber");
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public static void ModificacionPartida(string fecha, string valor, string nombreCuenta, string clasfCuenta)
        {
            string filePath = @"c:\ProgramaConta\Partidas\Partidas.csv";

            try
            {
                var position = 0L; // track the reading position
                var newLineLength = Environment.NewLine.Length;

                using (var inputStream = File.Open(filePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                using (var reader = new StreamReader(inputStream))

                using (var outputStream = File.Open(filePath, FileMode.Open, FileAccess.Write, FileShare.Read))
                using (var writer = new StreamWriter(outputStream))
                {

                    while (!reader.EndOfStream)
                    {
                        var line = reader.ReadLine();

                        position += line.Length + newLineLength;
                    }

                    outputStream.Seek(position, SeekOrigin.Begin);

                    if (clasfCuenta == "Activos" || clasfCuenta == "Activos Corrientes" || clasfCuenta == "Activos No corrientes" || clasfCuenta == "Activos Fijos" || clasfCuenta == "Gastos" || clasfCuenta == "Costo de venta")
                    {
                        if(Math.Sign(Convert.ToDouble(valor)) >= 0)
                        {
                            writer.WriteLine($"{fecha};{nombreCuenta};{valor};");
                        }
                        else
                        {
                            writer.WriteLine($"{fecha};{nombreCuenta};;{valor}");
                        }
                        
                    }

                    else if (clasfCuenta == "Pasivos" || clasfCuenta == "Pasivos No corrientes" || clasfCuenta == "Patrimonio" || clasfCuenta == "Ingresos")
                    {
                        if (Math.Sign(Convert.ToDouble(valor)) >= 0)
                        {
                            writer.WriteLine($"{fecha};{nombreCuenta};;{valor}");
                        }
                        else
                        {
                            writer.WriteLine($"{fecha};{nombreCuenta};{valor};");
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public static void VisualizarNomenclatura(string path)
        {
            try
            {
                if (!File.Exists(path))
                {
                    Console.WriteLine("El archivo de lectura es inexistente, prueba con otro.");
                }

                using (StreamReader sr = File.OpenText(path))
                {
                    string s = "";
                    Console.WriteLine("ID   |   CUENTA");

                    while ((s = sr.ReadLine()) != null)
                    {

                        string[] ids = s.Split(";");

                        for(int i = 0; i < ids.Length; i++)
                        {
                            if(i < ids.Length - 1)
                            {
                                while (ids[i].Length < 6)
                                {
                                    ids[i] = "0" + ids[i];
                                }
                               
                                Thread.Sleep(50);
                                Console.WriteLine($"{ids[i]} | {ids[i + 1]}");
                                continue;
                            }
                            else
                            {
                                break;
                            }
                        }
                    }
                }
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public static Dictionary<string, int> Lectura(string path, bool print)
        {
            Dictionary<string, int> diccionario = new Dictionary<string, int>();

            try
            {
                if (!File.Exists(path))
                {
                    Console.WriteLine("El archivo de lectura es inexistente, prueba con otro.");
                }

                using (StreamReader sr = File.OpenText(path))
                {
                    string s = "";

                    while ((s = sr.ReadLine()) != null)
                    {

                        string[] ids = s.Split(";");

                        for (int i = 0; i < ids.Length; i++)
                        {
                            if (i < ids.Length - 1)
                            {
                                /*string idCode = ids[i];

                                for (int e = 0; e < idCode.Length; e++)
                                {
                                    if (idCode[e] == 1) { Console.WriteLine("Es activo"); }
                                    if (idCode[e] == 2) { Console.WriteLine("Es pasivo"); }
                                }*/

                                while (ids[i].Length < 6)
                                {
                                    ids[i] = "0" + ids[i];
                                }

                                Thread.Sleep(20);

                                diccionario.Add(ids[i + 1], Convert.ToInt32(ids[i]));
                                
                                int asdInt;
                                diccionario.TryGetValue(ids[i + 1], out asdInt);

                                if (print) { Console.WriteLine($"{ids[i + 1]}"); }

                                continue;
                            }
                            else
                            {
                                break;
                            }

                        }
                    }
                }
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            return diccionario;
        }
    }
}
