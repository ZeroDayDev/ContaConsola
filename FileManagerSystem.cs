using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ContaConsola
{
    public class FileManagerSystem
    {
        public static void EscrituraInicial(string path)
        {
            //Creacion de nomenclatura ejercicio 5
            try
            {
                if (Directory.Exists(path))
                {
                }
                DirectoryInfo di = Directory.CreateDirectory(path);
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
                        sw.WriteLine("11;Corrientes");
                        sw.WriteLine("111;Caja");
                        sw.WriteLine("112;Bancos");
                        sw.WriteLine("113;Inventarios");
                        sw.WriteLine("114;Clientes");
                        sw.WriteLine("115;Documentos por cobrar");
                        sw.WriteLine("116;Seguros por cobrar");
                        sw.WriteLine("117;IVA por cobrar");
                        sw.WriteLine("118;Inversiones");
                        sw.WriteLine("12;No corrientes");
                        sw.WriteLine("121;Activos fijos	");
                        sw.WriteLine("1211;Terrenos");
                        sw.WriteLine("1212;Maquinaria");
                        sw.WriteLine("1213;Vehiculos");
                        sw.WriteLine("1214;Mobiliario y equipo");
                        sw.WriteLine("1215;Equipo de computo");
                        sw.WriteLine("2;Pasivo");
                        sw.WriteLine("21;Corrientes");
                        sw.WriteLine("211;Cuota patronal por pagar");
                        sw.WriteLine("212;Cuota laboral por pagar");
                        sw.WriteLine("213;Prestamos Bancarios");
                        sw.WriteLine("214;Proveedores");
                        sw.WriteLine("215;IVA por pagar");
                        sw.WriteLine("216;Acreedores    ");
                        sw.WriteLine("217;Documentos por pagar");
                        sw.WriteLine("3;Patrimonio");
                        sw.WriteLine("31;Utilidades de años anteriores");
                        sw.WriteLine("32;Patrimonio");
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

        public static Dictionary<int, string> Lectura(string path)
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

                    while ((s = sr.ReadLine()) != null)
                    {

                        string[] ids = s.Split(";");

                        for (int i = 0; i < ids.Length; i++)
                        {
                            if (i < ids.Length - 1)
                            {
                                string idCode = ids[i];

                                for (int e = 0; e < idCode.Length; e++)
                                {
                                    if (idCode[e] == 1) { Console.WriteLine("Es activo"); }
                                    if (idCode[e] == 2) { Console.WriteLine("Es pasivo"); }
                                }

                                switch (idCode)
                                {
                                    case "1":
                                        Console.WriteLine("Es activo");
                                        break;
                                    case "2":
                                        Console.WriteLine("Es pasivo");
                                        break;
                                }
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

            string nombreCuenta = "AAA";
            int IDCuenta = 00000;
            Dictionary<int, string> diccionario = new Dictionary<int, string>();

            diccionario.Add(IDCuenta, nombreCuenta);

            return diccionario;
        }
    }
}
