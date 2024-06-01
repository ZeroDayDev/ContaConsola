using ClosedXML.Excel;
using DocumentFormat.OpenXml.Vml;
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
            string nombreArchivo = "junio", archivo = @"c:\ProgramaConta\Partidas\Junio.csv", archivo2 = @"c:\ProgramaConta\EFS\ER_" + nombreArchivo + ".csv";

            Dictionary<string, int> dict = new Dictionary<string, int>();

            switch (Pointer)
            {
                case 1:
                    Console.WriteLine("MES A VISUALIZAR Y CREAR: ");
                    Console.WriteLine("1. JUNIO");
                    Console.WriteLine("2. JULIO");
                    Console.WriteLine("3. AMBOS");
                    string archivoAElegir3 = Console.ReadLine().ToLower();

                    if (archivoAElegir3.Contains("jun") || archivoAElegir3.Contains("1"))
                    {
                        nombreArchivo = "junio";
                        archivo = @"c:\ProgramaConta\Partidas\Junio.csv";
                        archivo2 = @"c:\ProgramaConta\EFS\ER_" + nombreArchivo + ".csv";
                        crearBG(dict, archivo, nombreArchivo, archivo2);
                    }

                    if (archivoAElegir3.Contains("jul") || archivoAElegir3.Contains("2"))
                    {
                        nombreArchivo = "julio";
                        archivo = @"c:\ProgramaConta\Partidas\Julio.csv";
                        archivo2 = @"c:\ProgramaConta\EFS\ER_" + nombreArchivo + ".csv";
                        crearBG(dict, archivo, nombreArchivo, archivo2);
                    }
                    if (archivoAElegir3.Contains("am") || archivoAElegir3.Contains("3"))
                    {
                        nombreArchivo = "junio";
                        archivo = @"c:\ProgramaConta\Partidas\Junio.csv";
                        archivo2 = @"c:\ProgramaConta\EFS\ER_" + nombreArchivo + ".csv";
                        crearBG(dict, archivo, nombreArchivo, archivo2);

                        nombreArchivo = "julio";
                        archivo = @"c:\ProgramaConta\Partidas\Julio.csv";
                        archivo2 = @"c:\ProgramaConta\EFS\ER_" + nombreArchivo + ".csv";
                        crearBG(dict, archivo, nombreArchivo, archivo2);
                    }
                    else
                    {
                        Console.WriteLine("No escojiste ninguna opcion.");
                    }


                    Console.WriteLine("\nPulsa cualquier tecla para salir");
                    Console.ReadLine();
                    Console.Clear();

                    break;
                case 2:
                    
                    //Crear el ER y BG de una vez, ya estoy cansado



                    Console.WriteLine("MES A VISUALIZAR Y CREAR: ");
                    Console.WriteLine("1. JUNIO");
                    Console.WriteLine("2. JULIO");
                    Console.WriteLine("3. AMBOS");
                    string archivoAElegir2 = Console.ReadLine().ToLower();

                    if (archivoAElegir2.Contains("jun") || archivoAElegir2.Contains("1"))
                    {
                        nombreArchivo = "junio";
                        archivo = @"c:\ProgramaConta\Partidas\Junio.csv";
                        crearER(dict, archivo, nombreArchivo);
                    }

                    if (archivoAElegir2.Contains("jul") || archivoAElegir2.Contains("2"))
                    {
                        nombreArchivo = "julio";
                        archivo = @"c:\ProgramaConta\Partidas\Julio.csv";
                        crearER(dict, archivo, nombreArchivo);
                    }           
                    if (archivoAElegir2.Contains("am") || archivoAElegir2.Contains("3"))
                    {
                        nombreArchivo = "junio";
                        archivo = @"c:\ProgramaConta\Partidas\Junio.csv";
                        crearER(dict, archivo, nombreArchivo);

                        nombreArchivo = "julio";
                        archivo = @"c:\ProgramaConta\Partidas\Julio.csv";
                        crearER(dict, archivo, nombreArchivo);
                    }
                    else
                    {
                        Console.WriteLine("No escojiste ninguna opcion.");
                    }


                    Console.WriteLine("\nPulsa cualquier tecla para salir");
                    Console.ReadLine();
                    Console.Clear();


                    break;

                case 3:
                    dict = FileManagerSystem.LecturaNomenclatura(@"c:\ProgramaConta\Nomenclatura1.csv", false);

                    //Activos
                    double caja = 0, bancos = 0, inventarios = 0, clientes = 0, documentosCobrar = 0, segurosCobrar = 0, ivaCobrar = 0, inversiones = 0;
                    //Activos fijos
                    double terrenos = 0, maquinaria = 0, vehiculos = 0, mobYequipo = 0, equipoComputo = 0;
                    //Pasivos
                    double cuotaPatronalPagar = 0, cuotaLaboralPagar = 0, prestamosBancarios = 0, proveedores = 0, ivaPagar = 0, acreedores = 0, docPagar = 0;
                    //Patrimonio
                    double utilidadesAnteriores = 0, patrimonio = 0, reservaLegal = 0;
                    //Ingresos
                    double ventas = 0;
                    //Gastos
                    double bonificacionIncentiva = 0, horasExtras = 0, sueldos = 0, segurosGasto = 0, cuotaPatronal = 0, aguinaldo = 0, bono14 = 0, papeleriaYUtiles = 0, serviciosTelefonicos = 0;
                    double salarioVentas = 0, salarioAdministracion = 0, horasExtrasVentas = 0, horasExtrasAdmin = 0, bonIncentivoVentas = 0;
                    //Costo de venta
                    double costoDeVenta = 0;

                    double total = 0;

                    Console.WriteLine("MES A VISUALIZAR: ");
                    Console.WriteLine("1. JUNIO");
                    Console.WriteLine("2. JULIO");
                    Console.WriteLine("3. AMBOS");
                    string archivoAElegir4 = Console.ReadLine().ToLower();
                    string archivo3 = @"c:\ProgramaConta\Partidas\Junio.csv";

                    if (archivoAElegir4.Contains("jun") || archivoAElegir4.Contains("1"))
                    {
                        nombreArchivo = "junio";
                        archivo3 = @"c:\ProgramaConta\Partidas\Junio.csv";
                    }

                    if (archivoAElegir4.Contains("jul") || archivoAElegir4.Contains("2"))
                    {
                        nombreArchivo = "julio";
                        archivo3 = @"c:\ProgramaConta\Partidas\Julio.csv";
                    }
                    if (archivoAElegir4.Contains("am") || archivoAElegir4.Contains("3"))
                    {
                        nombreArchivo = "junio";
                        archivo3 = @"c:\ProgramaConta\Partidas\Junio.csv";

                        nombreArchivo = "julio";
                        archivo3 = @"c:\ProgramaConta\Partidas\Julio.csv";
                    }
                    else
                    {
                        Console.WriteLine("No escojiste ninguna opcion.");
                    }

                    try
                    {
                        if (!File.Exists(archivo3))
                        {
                            Console.WriteLine("El archivo de lectura es inexistente, prueba con otro.");
                        }

                        using (StreamReader sr = File.OpenText(archivo3))
                        {
                            string s = "";
                            Console.Clear();

                            while ((s = sr.ReadLine()) != null)
                            {

                                string[] ids = s.Split(";");

                                Console.WriteLine(s);

                                caja += calcCuentas("Caja", ids);
                                bancos += calcCuentas("Bancos", ids);
                                clientes += calcCuentas("Clientes", ids);
                                documentosCobrar += calcCuentas("Documentos por cobrar", ids);
                                segurosCobrar += calcCuentas("Seguros por cobrar", ids);
                                ivaCobrar += calcCuentas("IVA por cobrar", ids);
                                inversiones += calcCuentas("Inversiones", ids);
                                terrenos += calcCuentas("Terrenos", ids);
                                maquinaria += calcCuentas("Maquinaria", ids);
                                vehiculos += calcCuentas("Vehiculos", ids);
                                mobYequipo += calcCuentas("Mobiliario y equipo", ids);
                                equipoComputo += calcCuentas("Equipo de computo", ids);
                                cuotaPatronalPagar += calcCuentas("Cuota patronal por pagar", ids);
                                cuotaLaboralPagar += calcCuentas("Cuota laboral por pagar", ids);
                                prestamosBancarios += calcCuentas("Prestamos Bancarios", ids);
                                proveedores += calcCuentas("Proveedores", ids);
                                ivaPagar += calcCuentas("IVA por pagar", ids);
                                acreedores += calcCuentas("Acreedores", ids);
                                docPagar += calcCuentas("Documentos por pagar", ids);
                                utilidadesAnteriores += calcCuentas("Utilidades de años anteriores", ids);
                                patrimonio += calcCuentas("patrimonio", ids);
                                reservaLegal += calcCuentas("Reserva legal", ids);
                                ventas += calcCuentas("Ventas", ids);
                                bonificacionIncentiva += calcCuentas("Bonificacion incentiva", ids);
                                horasExtras += calcCuentas("Horas extras", ids);
                                sueldos += calcCuentas("Sueldos", ids);
                                segurosGasto += calcCuentas("Seguros (Gastos)", ids);
                                cuotaPatronal += calcCuentas("Cuota patronal", ids);
                                aguinaldo += calcCuentas("Aguinaldo", ids);
                                bono14 += calcCuentas("Bono 14", ids);
                                papeleriaYUtiles += calcCuentas("Papeleria y utiles", ids);
                                serviciosTelefonicos += calcCuentas("Servicios telefonicos", ids);
                                salarioVentas += calcCuentas("Salario de Ventas", ids);
                                salarioAdministracion += calcCuentas("Salario Administracion", ids);
                                horasExtrasVentas += calcCuentas("Horas extras Ventas", ids);
                                horasExtrasAdmin += calcCuentas("Horas extras Administracion", ids);
                                bonIncentivoVentas += calcCuentas("Bonificacion incentivo Ventas", ids);
                                costoDeVenta += calcCuentas("costo de venta", ids);  
                            }
                        }
                        Console.WriteLine($"El saldo final de caja: {caja}");
                        Console.WriteLine($"El saldo final de bancos: {bancos}");
                        Console.WriteLine($"El saldo final de clientes: {clientes}");
                        Console.WriteLine($"El saldo final de documentos por cobrar: {documentosCobrar}");
                        Console.WriteLine($"El saldo final de seguros por cobrar: {segurosCobrar}");
                        Console.WriteLine($"El saldo final de iva por cobrar: {ivaCobrar}");
                        Console.WriteLine($"El saldo final de inversiones: {inversiones}");
                        Console.WriteLine($"El saldo final de terrenos: {terrenos}");
                        Console.WriteLine($"El saldo final de maquinaria: {maquinaria}");
                        Console.WriteLine($"El saldo final de vehiculos: {vehiculos}");
                        Console.WriteLine($"El saldo final de mobiliario y equipo: {mobYequipo}");
                        Console.WriteLine($"El saldo final de equipo de computo: {equipoComputo}");
                        Console.WriteLine($"El saldo final de cuota patronal por pagar: {cuotaPatronalPagar}");
                        Console.WriteLine($"El saldo final de cuota laboral por pagar: {cuotaLaboralPagar}");
                        Console.WriteLine($"El saldo final de prestamos bancarios: {prestamosBancarios}");
                        Console.WriteLine($"El saldo final de proveedores: {proveedores}");
                        Console.WriteLine($"El saldo final de iva por pagar: {ivaPagar}");
                        Console.WriteLine($"El saldo final de acreedores: {acreedores}");
                        Console.WriteLine($"El saldo final de documentos por pagar: {docPagar}");
                        Console.WriteLine($"El saldo final de utilidades de años anteriores: {utilidadesAnteriores}");
                        Console.WriteLine($"El saldo final de patrimonio: {patrimonio}");
                        Console.WriteLine($"El saldo final de reserva legal: {reservaLegal}");
                        Console.WriteLine($"El saldo final de ventas: {ventas}");
                        Console.WriteLine($"El saldo final de bonificacion incentiva: {bonificacionIncentiva}");
                        Console.WriteLine($"El saldo final de horas extras: {horasExtras}");
                        Console.WriteLine($"El saldo final de sueldos: {sueldos}");
                        Console.WriteLine($"El saldo final de seguros (gasto): {segurosGasto}");
                        Console.WriteLine($"El saldo final de cuota patronal: {cuotaPatronal}");
                        Console.WriteLine($"El saldo final de aguinaldo: {aguinaldo}");
                        Console.WriteLine($"El saldo final de bono 14: {bono14}");
                        Console.WriteLine($"El saldo final de papeleria y utiles: {papeleriaYUtiles}");
                        Console.WriteLine($"El saldo final de servicios telefonicos: {serviciosTelefonicos}");
                        Console.WriteLine($"El saldo final de salario ventas: {salarioVentas}");
                        Console.WriteLine($"El saldo final de salario administracion: {salarioAdministracion}");
                        Console.WriteLine($"El saldo final de horas extras de ventas: {horasExtrasVentas}");
                        Console.WriteLine($"El saldo final de horas extras de administracion: {horasExtrasAdmin}");
                        Console.WriteLine($"El saldo final de bonificacion incentivo ventas: {bonIncentivoVentas}");
                        Console.WriteLine($"El saldo final de costo de venta: {costoDeVenta}");

                        double totalBalance = caja + bancos + clientes + documentosCobrar + segurosCobrar + ivaCobrar + inversiones + terrenos + maquinaria + vehiculos + mobYequipo + equipoComputo + cuotaLaboralPagar + cuotaPatronalPagar + prestamosBancarios + proveedores + ivaPagar + acreedores+docPagar+utilidadesAnteriores+patrimonio+reservaLegal+ventas+bonificacionIncentiva+horasExtras+sueldos+segurosGasto+cuotaPatronal+aguinaldo+bono14+papeleriaYUtiles+serviciosTelefonicos+salarioVentas+salarioAdministracion+horasExtrasVentas+horasExtrasAdmin+bonIncentivoVentas+costoDeVenta;

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

        static double calcCuentas(string cuenta, string[] select)
        {
            double final = 0, debe = 0, haber = 0;

            if (select[1] == cuenta && !string.IsNullOrEmpty(select[2]))
            {
                debe = debe + Convert.ToDouble(select[2]);
            }
            if (select[1] == cuenta && !string.IsNullOrEmpty(select[3]))
            {
                haber = haber + Convert.ToDouble(select[3]);
              
            }

            final = debe - haber;

            return final;
        }
      
        static void crearER(Dictionary<string, int> dict, string archivo, string nombreArchivo)
        {
            dict = FileManagerSystem.LecturaNomenclatura(@"c:\ProgramaConta\Nomenclatura1.csv", false);
            double ventas = 0, devolucionesVentas = 0, ventasNetas = 0, costoVenta = 0, utilidadVenta = 0, gastosOperacion = 0, utilidadOperacion = 0, OtrosGastosIngre = 0, utilidadSobreOtros = 0, ISR = 0, total = 0;


            try
            {
                if (!File.Exists(archivo))
                {
                    Console.WriteLine("El archivo de lectura es inexistente, prueba con otro.");
                }

                using (StreamReader sr = File.OpenText(archivo))
                {
                    string s = "";

                    while ((s = sr.ReadLine()) != null)
                    {

                        string[] ids = s.Split(";");

                        try
                        {
                            if (ids[1] == "Ventas" && !string.IsNullOrEmpty(ids[3]))
                            {
                                ventas += Convert.ToDouble(ids[3]);
                            }
                            if (ids[1] == "Ventas" && !string.IsNullOrEmpty(ids[2]))
                            {
                                devolucionesVentas += Convert.ToDouble(ids[2]);
                            }
                            if (ids[1] == "costo de venta" && !string.IsNullOrEmpty(ids[2]))
                            {
                                costoVenta += Convert.ToDouble(ids[2]);
                            }
                            if (ids[1] == "Bonificacion incentiva" || ids[1] == "Horas extras" || ids[1] == "Sueldos" || ids[1] == "Seguros (Gastos)" || ids[1] == "Cuota patronal" || ids[1] == "Aguinaldo" || ids[1] == "Bono 14" || ids[1] == "Papeleria y utiles" || ids[1] == "Servicios telefonicos" || ids[1] == "Salario de Ventas" || ids[1] == "Salario Administracion" || ids[1] == "Horas extras Ventas" || ids[1] == "Horas extras Administracion" || ids[1] == "Bonificacion incentivo Ventas")
                            {
                                if (!string.IsNullOrEmpty(ids[3]))
                                {
                                    gastosOperacion += Convert.ToDouble(ids[3]);
                                }

                                gastosOperacion += Convert.ToDouble(ids[2]);
                            }

                            ventasNetas = ventas - devolucionesVentas;
                            utilidadVenta = ventas - costoVenta;
                            utilidadOperacion = utilidadVenta - gastosOperacion;
                            utilidadSobreOtros = utilidadOperacion - OtrosGastosIngre;

                            if (utilidadSobreOtros > 1)
                            {
                                //ISR = utilidadSobreOtros * 0.05;
                            }

                            total = utilidadSobreOtros - ISR;



                        }
                        catch { }
                    }
                }

                Console.WriteLine($"EMPRESA XY");
                Console.WriteLine($"POR EL MES TERMINADO DE {nombreArchivo.ToUpper()}");
                Console.WriteLine($"CIFRAS (Q)");
                Console.WriteLine($"Ventas: {ventas}");
                Console.WriteLine($"Devoluciones ventas: {devolucionesVentas}");
                Console.WriteLine($"Ventas netas: {ventasNetas}");
                Console.WriteLine($"Costo de venta: {costoVenta}");
                Console.WriteLine($"Utilidades en ventas: {utilidadVenta}");
                Console.WriteLine($"Gastos de operacion: {gastosOperacion}");
                Console.WriteLine($"Utilidad en operacion: {utilidadOperacion}");
                Console.WriteLine($"Utilidad sobre otros gastos e ingresos: {OtrosGastosIngre}");   
                Console.WriteLine($"ISR: {ISR}");

                if (total > 0)
                    Console.WriteLine($"Ganancia del ejercicio Q{total}");
                else
                    Console.WriteLine($"Perdida del ejercicio Q{total}");

                if (total > 0)
                {
                    try
                    {

                        if (!File.Exists(@"c:\ProgramaConta\EFS\ER_" + nombreArchivo + ".csv"))
                        {
                            using (StreamWriter sw = File.CreateText(@"c:\ProgramaConta\EFS\ER_" + nombreArchivo + ".csv"))
                            {
                                sw.WriteLine($"EMPRESA XY;0");
                                sw.WriteLine($"POR EL MES TERMINADO DE {nombreArchivo.ToUpper()};0");
                                sw.WriteLine($"CIFRAS (Q);0");
                                sw.WriteLine($"Ventas: ;Q{ventas}");
                                sw.WriteLine($"Devoluciones ventas: ;Q{devolucionesVentas}");
                                sw.WriteLine($"Ventas netas: ;Q{ventasNetas}");
                                sw.WriteLine($"Costo de venta: ;Q{costoVenta}");
                                sw.WriteLine($"Utilidades en ventas: ;Q{utilidadVenta}");
                                sw.WriteLine($"Gastos de operacion: ;Q{gastosOperacion}");
                                sw.WriteLine($"Utilidad en operacion: ;Q{utilidadOperacion}");
                                sw.WriteLine($"Utilidad sobre otros gastos e ingresos: ;Q{OtrosGastosIngre}");
                                sw.WriteLine($"ISR: ;Q{ISR}");
                                sw.WriteLine($"Ganancia del ejercicio: ;Q{total}");

                            }                  
                        }

                        if(!File.Exists("C:\\ProgramaConta/EstadoResultado_" + nombreArchivo + ".xlsx"))
                        {
                            using (var workbook = new XLWorkbook())
                            {
                                var worksheet = workbook.Worksheets.Add("EstadoResultado");
                                worksheet.Cell("A1").Value = "EMPRESA XY";
                                worksheet.Cell("A2").Value = $"POR EL MES TERMINADO DE {nombreArchivo.ToUpper()}";
                                worksheet.Cell("A3").Value = $"CIFRAS (Q)";
                                #region Estilos de celdas titulos
                                worksheet.Columns("A").AdjustToContents();
                                worksheet.Columns("B").AdjustToContents();
                                worksheet.Cell("A1").Style.Fill.SetBackgroundColor(XLColor.DarkBlue); worksheet.Cell("A1").Style.Font.Bold = true; worksheet.Cell("A1").Style.Font.SetFontColor(XLColor.White);
                                worksheet.Cell("A2").Style.Fill.SetBackgroundColor(XLColor.Blue); worksheet.Cell("A2").Style.Font.Bold = true;    worksheet.Cell("A2").Style.Font.SetFontColor(XLColor.White);
                                worksheet.Cell("A3").Style.Fill.SetBackgroundColor(XLColor.Blue); worksheet.Cell("A3").Style.Font.Bold = true;    worksheet.Cell("A3").Style.Font.SetFontColor(XLColor.White);
                                #endregion

                                worksheet.Cell("A4").Value = $"Ventas:";
                                worksheet.Cell("B4").Value = ventas;
                                worksheet.Cell("A5").Value = $"Devoluciones ventas:";
                                worksheet.Cell("B5").Value = devolucionesVentas;
                                worksheet.Cell("A6").Value = $"Ventas netas:";
                                worksheet.Cell("B6").Value = ventasNetas;
                                worksheet.Cell("A7").Value = $"Costo de venta:";
                                worksheet.Cell("B7").Value = costoVenta;
                                worksheet.Cell("A8").Value = $"Utilidades en ventas:";
                                worksheet.Cell("B8").Value = utilidadVenta;
                                worksheet.Cell("A9").Value = $"Gastos de operacion:";
                                worksheet.Cell("B9").Value = gastosOperacion;
                                worksheet.Cell("A10").Value = $"Utilidad en operacion:";
                                worksheet.Cell("B10").Value = utilidadOperacion;
                                worksheet.Cell("A11").Value = $"Utilidad sobre otros gastos e ingresos:";
                                worksheet.Cell("B11").Value = OtrosGastosIngre;
                                worksheet.Cell("B12").Style.Border.SetBottomBorder(XLBorderStyleValues.Double);
                                worksheet.Cell("A12").Value = $"ISR:";
                                worksheet.Cell("B12").Value = ISR;
                                worksheet.Cell("A13").Style.Font.SetFontColor(XLColor.Green);
                                worksheet.Cell("A13").Style.Fill.SetBackgroundColor(XLColor.LightGreen);
                                worksheet.Cell("B13").Style.Font.SetFontColor(XLColor.Green);
                                worksheet.Cell("A13").Value = $"Ganancia del ejercicio:";
                                worksheet.Cell("B13").Value = $"Q{total}";
                                workbook.SaveAs("C:\\ProgramaConta/EstadoResultado_" + nombreArchivo + ".xlsx");
                            }
                        }        
                    }

                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.ToString());
                    }

                    Console.WriteLine($"\nSe ha registrado una ganancia en el ejercicio de Q{total}\n");
                }
                else
                {
                    try
                    {

                        if (!File.Exists(@"c:\ProgramaConta\EFS\ER_" + nombreArchivo + ".csv"))
                        {
                            using (StreamWriter sw = File.CreateText(@"c:\ProgramaConta\EFS\ER_" + nombreArchivo + ".csv"))
                            {
                                sw.WriteLine($"EMPRESA XY;0");
                                sw.WriteLine($"POR EL MES TERMINADO DE {nombreArchivo.ToUpper()};0");
                                sw.WriteLine($"CIFRAS (Q);0");
                                sw.WriteLine($"Ventas: ;Q{ventas}");
                                sw.WriteLine($"Devoluciones ventas: ;Q{devolucionesVentas}");
                                sw.WriteLine($"Ventas netas: ;Q{ventasNetas}");
                                sw.WriteLine($"Costo de venta: ;Q{costoVenta}");
                                sw.WriteLine($"Utilidades en ventas: ;Q{utilidadVenta}");
                                sw.WriteLine($"Gastos de operacion: ;Q{gastosOperacion}");
                                sw.WriteLine($"Utilidad en operacion: ;Q{utilidadOperacion}");
                                sw.WriteLine($"Utilidad sobre otros gastos e ingresos: ;Q{OtrosGastosIngre}");
                                sw.WriteLine($"ISR: ;Q{ISR}");
                                sw.WriteLine($"Perdida del ejercicio: ;Q{total}");

                            }

                        }

                        if (!File.Exists("C:\\ProgramaConta/EstadoResultado_" + nombreArchivo + ".xlsx"))
                        {

                            using (var workbook = new XLWorkbook())
                            {
                                var worksheet = workbook.Worksheets.Add("EstadoResultado");
                                worksheet.Cell("A1").Value = "EMPRESA XY";
                                worksheet.Cell("A2").Value = $"POR EL MES TERMINADO DE {nombreArchivo.ToUpper()}";
                                worksheet.Cell("A3").Value = $"CIFRAS (Q)";
                                #region Estilos de celdas titulos
                                

                                worksheet.Cell("A1").Style.Fill.SetBackgroundColor(XLColor.DarkBlue); worksheet.Cell("A1").Style.Font.Bold = true; worksheet.Cell("A1").Style.Font.SetFontColor(XLColor.White);
                                worksheet.Cell("A2").Style.Fill.SetBackgroundColor(XLColor.Blue); worksheet.Cell("A2").Style.Font.Bold = true; worksheet.Cell("A2").Style.Font.SetFontColor(XLColor.White);
                                worksheet.Cell("A3").Style.Fill.SetBackgroundColor(XLColor.Blue); worksheet.Cell("A3").Style.Font.Bold = true; worksheet.Cell("A3").Style.Font.SetFontColor(XLColor.White);
                                #endregion

                                worksheet.Cell("A4").Value = $"Ventas:";
                                worksheet.Cell("B4").Value = ventas;
                                worksheet.Cell("A5").Value = $"Devoluciones ventas:";
                                worksheet.Cell("B5").Value = devolucionesVentas;
                                worksheet.Cell("A6").Value = $"Ventas netas:";
                                worksheet.Cell("B6").Value = ventasNetas;
                                worksheet.Cell("A7").Value = $"Costo de venta:";
                                worksheet.Cell("B7").Value = costoVenta;
                                worksheet.Cell("A8").Value = $"Utilidades en ventas:";
                                worksheet.Cell("B8").Value = utilidadVenta;
                                worksheet.Cell("A9").Value = $"Gastos de operacion:";
                                worksheet.Cell("B9").Value = gastosOperacion;
                                worksheet.Cell("A10").Value = $"Utilidad en operacion:";
                                worksheet.Cell("B10").Value = utilidadOperacion;
                                worksheet.Cell("A11").Value = $"Utilidad sobre otros gastos e ingresos:";
                                worksheet.Cell("B11").Value = OtrosGastosIngre;
                                worksheet.Cell("B12").Style.Border.SetBottomBorder(XLBorderStyleValues.Double);
                                worksheet.Cell("A12").Value = $"ISR:";
                                worksheet.Cell("B12").Value = ISR;
                                worksheet.Cell("A13").Style.Font.SetFontColor(XLColor.Red);
                                worksheet.Cell("A13").Style.Fill.SetBackgroundColor(XLColor.LightSalmon);
                                worksheet.Cell("B13").Style.Font.SetFontColor(XLColor.Red);
                                worksheet.Cell("A13").Value = $"Perdida del ejercicio:";
                                worksheet.Cell("B13").Value = total;

                                worksheet.Columns("A").AdjustToContents();
                                worksheet.Columns("B").AdjustToContents();


                                workbook.SaveAs("C:\\ProgramaConta/EstadoResultado_" + nombreArchivo + ".xlsx");
                            }
                        }
                    }

                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.ToString());
                    }

                    Console.WriteLine($"\nSe ha registrado una perdida en el ejercicio de Q{total}\n");
                }

            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
        static void crearBG(Dictionary<string, int> dict, string archivo, string nombreArchivo, string archivo2)
        {
            dict = FileManagerSystem.LecturaNomenclatura(@"c:\ProgramaConta\Nomenclatura1.csv", false);
            double activoCorriente = 0, dispYEquivEfectivo = 0, docCobrar = 0, clientes = 0, cuentasIncobrables= 0, totalClientes = 0, inventarios = 0, segurosPorCobrar = 0, Inversiones = 0, impuestos = 0;
            double activoNoCorriente = 0, docCobrar2 = 0, inversiones = 0, propiedadP = 0, depreciacion = 0, totalpropiedadP = 0;
            double totalActivo = 0;

            double pasivoCorriente = 0, docPagar = 0, prestBancarios = 0, acreedores = 0, proveedores = 0, debitoFiscal = 0, prestaciones = 0;
            double pasivoNoCorriente = 0, prestBancarios2 = 0, docPagar2 = 0, hipotecas = 0;
            double totalPasivo = 0;

            double totalCapital = 0, capital = 0, utilidades = 0, reservaLegal = 0, utilidadEjercicio = 0, pasivoCapital = 0;
            double totalFinal = 0;

            try
            {
                if (!File.Exists(archivo2))
                {
                    Console.WriteLine("El archivo de lectura es inexistente, prueba con otro.");
                }

                using (StreamReader sr = File.OpenText(archivo2))
                {
                    string s = "";

                    while ((s = sr.ReadLine()) != null)
                    {
                        string[] ids = s.Split(";");

                        string asd = ids[1].TrimStart('-');
                        asd = asd.TrimStart('Q');

                        utilidadEjercicio = Convert.ToDouble(asd);

                    }
                }
            } catch (Exception ex){ Console.WriteLine(ex.ToString()); }

            try
            {
                if (!File.Exists(archivo))
                {
                    Console.WriteLine("El archivo de lectura es inexistente, prueba con otro.");
                }

                using (StreamReader sr = File.OpenText(archivo))
                {
                    string s = "";

                    while ((s = sr.ReadLine()) != null)
                    {

                        string[] ids = s.Split(";");

                        try
                        {

                            if (ids[1] == "Bancos" && !string.IsNullOrEmpty(ids[2]) || ids[1] == "Caja" && !string.IsNullOrEmpty(ids[2]))
                            {
                                dispYEquivEfectivo += Convert.ToDouble(ids[2]);
                            }
                            if (ids[1] == "Bancos" && !string.IsNullOrEmpty(ids[3]) || ids[1] == "Caja" && !string.IsNullOrEmpty(ids[3]))
                            {
                                dispYEquivEfectivo -= Convert.ToDouble(ids[3]);
                            }

                            if (ids[1] == "Documentos por cobrar" && !string.IsNullOrEmpty(ids[2]))
                            {
                                docCobrar += Convert.ToDouble(ids[2]);
                            }
                            if (ids[1] == "Documentos por cobrar" && !string.IsNullOrEmpty(ids[3]))
                            {
                                docCobrar -= Convert.ToDouble(ids[3]);
                            }

                            if (ids[1] == "Clientes" && !string.IsNullOrEmpty(ids[2]))
                            {
                                clientes += Convert.ToDouble(ids[2]);
                            }
                            if (ids[1] == "Clientes" && !string.IsNullOrEmpty(ids[3]))
                            {
                                clientes -= Convert.ToDouble(ids[3]);
                            }

                            if (ids[1] == "Inventarios" && !string.IsNullOrEmpty(ids[2]))
                            {
                                inventarios += Convert.ToDouble(ids[2]);
                            }
                            if (ids[1] == "Inventarios" && !string.IsNullOrEmpty(ids[3]))
                            {
                                inventarios -= Convert.ToDouble(ids[3]);
                            }

                            if (ids[1] == "Seguros por cobrar" && !string.IsNullOrEmpty(ids[2]))
                            {
                                segurosPorCobrar += Convert.ToDouble(ids[2]);
                            }
                            if (ids[1] == "Seguros por cobrar" && !string.IsNullOrEmpty(ids[3]))
                            {
                                segurosPorCobrar -= Convert.ToDouble(ids[3]);
                            }

                            if (ids[1] == "IVA por cobrar" && !string.IsNullOrEmpty(ids[2]))
                            {
                                impuestos += Convert.ToDouble(ids[2]);
                            }
                            if (ids[1] == "IVA por cobrar" && !string.IsNullOrEmpty(ids[3]))
                            {
                                impuestos -= Convert.ToDouble(ids[3]);
                            }

                            if (ids[1] == "Inversiones" && !string.IsNullOrEmpty(ids[2]))
                            {
                                inversiones += Convert.ToDouble(ids[2]);
                            }
                            if (ids[1] == "Inversiones" && !string.IsNullOrEmpty(ids[3]))
                            {
                                inversiones -= Convert.ToDouble(ids[3]);
                            }

                            totalClientes = clientes - cuentasIncobrables;

                            activoCorriente = dispYEquivEfectivo + docCobrar + totalClientes + inventarios + segurosPorCobrar + inversiones + impuestos;                            

                            if (ids[1] == "Terrenos" && !string.IsNullOrEmpty(ids[2]) || ids[1] == "Maquinaria" && !string.IsNullOrEmpty(ids[2]) || ids[1] == "Vehiculos" && !string.IsNullOrEmpty(ids[2]) || ids[1] == "Mobiliario y equipo" && !string.IsNullOrEmpty(ids[2]) || ids[1] == "Equipo de computo" && !string.IsNullOrEmpty(ids[2]))
                            {
                                propiedadP += Convert.ToDouble(ids[2]);
                            }
                            if (ids[1] == "Terrenos" && !string.IsNullOrEmpty(ids[3]) || ids[1] == "Maquinaria" && !string.IsNullOrEmpty(ids[3]) || ids[1] == "Vehiculos" && !string.IsNullOrEmpty(ids[3]) || ids[1] == "Mobiliario y equipo" && !string.IsNullOrEmpty(ids[3]) || ids[1] == "Equipo de computo" && !string.IsNullOrEmpty(ids[3]))
                            {
                                propiedadP -= Convert.ToDouble(ids[3]);
                            }

                            propiedadP -= depreciacion;
                            activoNoCorriente = docCobrar2 + propiedadP;

                            totalActivo = activoCorriente + activoNoCorriente;


                            if (ids[1] == "Documentos por pagar" && !string.IsNullOrEmpty(ids[2]))
                            {
                                docPagar += Convert.ToDouble(ids[2]);
                            }
                            if (ids[1] == "Documentos por pagar" && !string.IsNullOrEmpty(ids[3]))
                            {
                                docPagar -= Convert.ToDouble(ids[3]);
                            }

                            if (ids[1] == "Prestamos Bancarios" && !string.IsNullOrEmpty(ids[2]))
                            {
                                prestBancarios += Convert.ToDouble(ids[2]);
                            }
                            if (ids[1] == "Prestamos Bancarios" && !string.IsNullOrEmpty(ids[3]))
                            {
                                prestBancarios -= Convert.ToDouble(ids[3]);
                            }

                            if (ids[1] == "Acreedores" && !string.IsNullOrEmpty(ids[2]))
                            {
                                acreedores += Convert.ToDouble(ids[2]);
                            }
                            if (ids[1] == "Acreedores" && !string.IsNullOrEmpty(ids[3]))
                            {
                                acreedores -= Convert.ToDouble(ids[3]);
                            }

                            if (ids[1] == "Proveedores" && !string.IsNullOrEmpty(ids[2]))
                            {
                                proveedores += Convert.ToDouble(ids[2]);
                            }
                            if (ids[1] == "Proveedores" && !string.IsNullOrEmpty(ids[3]))
                            {
                                proveedores -= Convert.ToDouble(ids[3]);
                            }     

                            if (ids[1] == "IVA por pagar" && !string.IsNullOrEmpty(ids[2]))
                            {
                                debitoFiscal += Convert.ToDouble(ids[2]);
                            }
                            if (ids[1] == "IVA por pagar" && !string.IsNullOrEmpty(ids[3]))
                            {
                                debitoFiscal -= Convert.ToDouble(ids[3]);
                            }
                            
                            if (ids[1] == "Cuota laboral por pagar" && !string.IsNullOrEmpty(ids[2]) || ids[1] == "Cuota patronal por pagar" && !string.IsNullOrEmpty(ids[2]))
                            {
                                prestaciones += Convert.ToDouble(ids[2]);
                                Console.WriteLine(prestaciones);
                            }
                            if (ids[1] == "Cuota laboral por pagar" && !string.IsNullOrEmpty(ids[3]) || ids[1] == "Cuota patronal por pagar" && !string.IsNullOrEmpty(ids[3]))
                            {
                                prestaciones -= Convert.ToDouble(ids[3]);
                                Console.WriteLine(prestaciones);
                            }

                            pasivoCorriente = docPagar + prestBancarios + acreedores + proveedores + prestaciones + debitoFiscal;
                            totalPasivo = pasivoCorriente + pasivoNoCorriente;

                            if (ids[1] == "Patrimonio" && !string.IsNullOrEmpty(ids[2]))
                            {
                                capital += Convert.ToDouble(ids[2]);
                            }
                            if (ids[1] == "Patrimonio" && !string.IsNullOrEmpty(ids[3]))
                            {
                                capital -= Convert.ToDouble(ids[3]);
                            }                            
                            
                            if (ids[1] == "Utilidades de años anteriores" && !string.IsNullOrEmpty(ids[2]))
                            {
                                utilidades += Convert.ToDouble(ids[2]);
                            }
                            if (ids[1] == "Utilidades de años anteriores" && !string.IsNullOrEmpty(ids[3]))
                            {
                                utilidades -= Convert.ToDouble(ids[3]);
                            }                          
                            
                            if (ids[1] == "Reserva legal" && !string.IsNullOrEmpty(ids[2]))
                            {
                                reservaLegal += Convert.ToDouble(ids[2]);
                            }
                            if (ids[1] == "Reserva legal" && !string.IsNullOrEmpty(ids[3]))
                            {
                                reservaLegal -= Convert.ToDouble(ids[3]);
                            }

                            totalCapital = capital + utilidades + reservaLegal + utilidadEjercicio * -1;

                            totalFinal = totalPasivo + totalCapital;

                        }
                        catch { }
                    }
                }

                Console.WriteLine($"Disponibilidad efectivo y equivalentes: Q{dispYEquivEfectivo}");
                Console.WriteLine($"Documentos por cobrar: Q{docCobrar}");
                Console.WriteLine($"Clientes: Q{clientes}");
                Console.WriteLine($"Cuentas incobrables: Q{cuentasIncobrables}");
                Console.WriteLine($"total clientes: Q{totalClientes}");
                Console.WriteLine($"Inventarios: Q{inventarios}");
                Console.WriteLine($"Seguros por cobrar: Q{segurosPorCobrar}");
                Console.WriteLine($"Inversiones: Q{inversiones}");
                Console.WriteLine($"Impuesto por liquidar: Q{impuestos}");
                Console.WriteLine($"\nTotal activo corriente: Q{activoCorriente}\n");  
                
                Console.WriteLine($"Documentos por cobrar: Q{docCobrar2}");
                Console.WriteLine($"Inversiones: Q0");
                Console.WriteLine($"Propiedad, planta y equipo: Q{propiedadP}");
                Console.WriteLine($"Depreciacion acumulada: Q{depreciacion}");
                Console.WriteLine($"Total de propiedad, planta y equipo: Q{propiedadP}");
                Console.WriteLine($"\nTotal activo no corriente: Q{activoNoCorriente}\n");

                Console.WriteLine($"\nTotal activo: Q{totalActivo}\n\n");                
                
                Console.WriteLine($"Documentos por pagar: Q{docPagar}");
                Console.WriteLine($"Prestamos bancarios: Q{prestBancarios}");
                Console.WriteLine($"Acreedores: Q{acreedores}");
                Console.WriteLine($"Proveedores: Q{proveedores}");
                Console.WriteLine($"Prestaciones por pagar: Q{prestaciones}");
                Console.WriteLine($"Debito fiscal: Q{debitoFiscal}");
                Console.WriteLine($"\nTotal pasivo corriente: Q{pasivoCorriente}\n");
                
                Console.WriteLine($"Prestamos bancarios: Q{prestBancarios2}");
                Console.WriteLine($"Documentos por pagar: Q{docPagar2}");
                Console.WriteLine($"Hipotecas: Q{hipotecas}");
                Console.WriteLine($"\nTotal pasivo no corriente: Q{pasivoNoCorriente}\n");

                Console.WriteLine($"\nTotal pasivo: Q{totalPasivo}\n\n");

                Console.WriteLine($"Capital: Q{capital}");
                Console.WriteLine($"Utilidades de años anteriores: Q{utilidades}");
                Console.WriteLine($"Reserva legal: Q{reservaLegal}");
                Console.WriteLine($"Utilidad del ejercicio (Perdida o ganancia): Q{utilidadEjercicio}");
                Console.WriteLine($"\nTotal de capital: Q{totalCapital}\n\n")
                    ;
                Console.WriteLine($"\nPasivo + capital: Q{totalFinal}\n\n");

                try
                {
                    if (!File.Exists(@"c:\ProgramaConta\EFS\BG_" + nombreArchivo + ".csv"))
                    {
                        using (StreamWriter sw = File.CreateText(@"c:\ProgramaConta\EFS\BG_" + nombreArchivo + ".csv"))
                        {
                            sw.WriteLine($"EMPRESA XY;0");
                            sw.WriteLine($"POR EL MES TERMINADO DE {nombreArchivo.ToUpper()};0");
                            sw.WriteLine($"CIFRAS (Q);0");
                            sw.WriteLine($"Disponibilidad efectivo y equivalentes: ;Q{dispYEquivEfectivo}");
                            sw.WriteLine($"Documentos por cobrar: ;Q{docCobrar}");
                            sw.WriteLine($"Clientes: ;Q{clientes}");
                            sw.WriteLine($"Cuentas incobrables: ;Q{cuentasIncobrables}");
                            sw.WriteLine($"total clientes: ;Q{totalClientes}");
                            sw.WriteLine($"Inventarios: ;Q{inventarios}");
                            sw.WriteLine($"Seguros por cobrar: ;Q{segurosPorCobrar}");
                            sw.WriteLine($"Inversiones: ;Q{inversiones}");
                            sw.WriteLine($"Impuesto por liquidar: ;Q{impuestos}");
                            sw.WriteLine($"\nTotal activo corriente: ;Q{activoCorriente}\n");
                            
                            sw.WriteLine($"Documentos por cobrar: ;Q{docCobrar2}");
                            sw.WriteLine($"Inversiones: ;Q0");
                            sw.WriteLine($"Propiedad, planta y equipo: ;Q{propiedadP}");
                            sw.WriteLine($"Depreciacion acumulada: ;Q{depreciacion}");
                            sw.WriteLine($"Total de propiedad, planta y equipo: ;Q{totalpropiedadP}");
                            sw.WriteLine($"\nTotal activo no corriente: ;Q{activoNoCorriente}\n");
                            
                            sw.WriteLine($"\nTotal activo: ;Q{totalActivo}\n\n");
                            
                            sw.WriteLine($"Documentos por pagar: ;Q{docPagar * -1}");
                            sw.WriteLine($"Prestamos bancarios: ;Q{prestBancarios * -1}");
                            sw.WriteLine($"Acreedores: ;Q{acreedores * -1}");
                            sw.WriteLine($"Proveedores: ;Q{proveedores * -1}");
                            sw.WriteLine($"Prestaciones por pagar: ;Q{prestaciones * -1}");
                            sw.WriteLine($"Debito fiscal: ;Q{debitoFiscal * -1}");
                            sw.WriteLine($"\nTotal pasivo corriente: ;Q{pasivoCorriente * -1}\n");
                            
                            sw.WriteLine($"Prestamos bancarios: ;Q{prestBancarios2 * -1}");
                            sw.WriteLine($"Documentos por pagar: ;Q{docPagar2 * -1}");
                            sw.WriteLine($"Hipotecas: ;Q{hipotecas * -1}");
                            sw.WriteLine($"\nTotal pasivo no corriente: ;Q{pasivoNoCorriente * -1}\n");
                            
                            sw.WriteLine($"\nTotal pasivo: ;Q{totalPasivo * -1}\n\n");
                            
                            sw.WriteLine($"Capital: ;Q{capital *-1}");
                            sw.WriteLine($"Utilidades de años anteriores: ;Q{utilidades *-1}");
                            sw.WriteLine($"Reserva legal: ;Q{reservaLegal * -1}");
                            sw.WriteLine($"Utilidad del ejercicio (Perdida o ganancia): ;Q{utilidadEjercicio * -1}");
                            sw.WriteLine($"\nTotal de capital: ;Q{totalCapital * -1}\n\n");
                            
                            sw.WriteLine($"\nPasivo + capital: ;Q{totalFinal * -1}\n\n");

                        }
                    }

                    if (!File.Exists("C:\\ProgramaConta/BalanceGeneral_" + nombreArchivo + ".xlsx"))
                    {

                        using (var workbook = new XLWorkbook())
                        {
                            var worksheet = workbook.Worksheets.Add("BalanceGeneral");
                            worksheet.Cell("A1").Value = "EMPRESA XY";
                            worksheet.Cell("A2").Value = $"POR EL MES TERMINADO DE {nombreArchivo.ToUpper()}";
                            worksheet.Cell("A3").Value = $"CIFRAS (Q)";
                            #region Estilos de celdas titulos
                            
                            worksheet.Cell("A1").Style.Fill.SetBackgroundColor(XLColor.DarkBlue); worksheet.Cell("A1").Style.Font.Bold = true; worksheet.Cell("A1").Style.Font.SetFontColor(XLColor.White);
                            worksheet.Cell("A2").Style.Fill.SetBackgroundColor(XLColor.Blue); worksheet.Cell("A2").Style.Font.Bold = true; worksheet.Cell("A2").Style.Font.SetFontColor(XLColor.White);
                            worksheet.Cell("A3").Style.Fill.SetBackgroundColor(XLColor.Blue); worksheet.Cell("A3").Style.Font.Bold = true; worksheet.Cell("A3").Style.Font.SetFontColor(XLColor.White);
                            #endregion

                            worksheet.Cell("A5").Value = $"Disponibilidad efectivo y equivalentes:";
                            worksheet.Cell("B5").Value = dispYEquivEfectivo;
                            worksheet.Cell("A6").Value = $"Documentos por cobrar:";
                            worksheet.Cell("B6").Value = docCobrar;
                            worksheet.Cell("A7").Value = $"Clientes:";
                            worksheet.Cell("B7").Value = clientes;
                            worksheet.Cell("A8").Value = $"Cuentas incobrables:";
                            worksheet.Cell("B8").Value = cuentasIncobrables;
                            worksheet.Cell("A9").Value = $"total clientes:";
                            worksheet.Cell("B9").Value = totalClientes;
                            worksheet.Cell("A10").Value = $"Inventarios:";
                            worksheet.Cell("B10").Value = inventarios;
                            worksheet.Cell("A11").Value = $"Seguros por cobrar:";
                            worksheet.Cell("B11").Value = segurosPorCobrar;
                            worksheet.Cell("A12").Value = $"Inversiones";
                            worksheet.Cell("B12").Value = inversiones;
                            worksheet.Cell("A13").Value = $"Impuesto por liquidar:";
                            worksheet.Cell("B13").Value = impuestos;
                            worksheet.Cell("A14").Value = $"Total activo corriente:";
                            worksheet.Cell("B14").Value = activoCorriente;
                            worksheet.Cell("B14").Style.Border.SetBottomBorder(XLBorderStyleValues.Double);

                            worksheet.Cell("A16").Value = $"Documentos por cobrar:";
                            worksheet.Cell("B16").Value = docCobrar2;
                            worksheet.Cell("A17").Value = $"Inversiones:";
                            worksheet.Cell("B17").Value = 0;
                            worksheet.Cell("A18").Value = $"Propiedad, planta y equipo:";
                            worksheet.Cell("B18").Value = propiedadP;
                            worksheet.Cell("A19").Value = $"Depreciacion acumulada:";
                            worksheet.Cell("B19").Value = depreciacion;
                            worksheet.Cell("A20").Value = $"Total de propiedad, planta y equipo:";
                            worksheet.Cell("B20").Value = totalpropiedadP;
                            worksheet.Cell("A21").Value = $"Total activo no corriente:";
                            worksheet.Cell("B21").Value = activoNoCorriente;
                            worksheet.Cell("B21").Style.Border.SetBottomBorder(XLBorderStyleValues.Double);

                            worksheet.Cell("A23").Value = $"Total activo:";
                            worksheet.Cell("B23").Value = totalActivo;
                            worksheet.Cell("B23").Style.Border.SetBottomBorder(XLBorderStyleValues.Double);

                            worksheet.Cell("A25").Value = $"Documentos por pagar:";
                            worksheet.Cell("B25").Value = docPagar * -1;
                            worksheet.Cell("A26").Value = $"Prestamos bancarios:";
                            worksheet.Cell("B26").Value = prestBancarios * -1;
                            worksheet.Cell("A27").Value = $"Acreedores:";
                            worksheet.Cell("B27").Value = acreedores * -1;
                            worksheet.Cell("A28").Value = $"Proveedores:";
                            worksheet.Cell("B28").Value = proveedores * -1;
                            worksheet.Cell("A29").Value = $"Prestaciones por pagar:";
                            worksheet.Cell("B29").Value = prestaciones * -1;
                            worksheet.Cell("A30").Value = $"Debito fiscal:";
                            worksheet.Cell("B30").Value = debitoFiscal * -1;
                            worksheet.Cell("A31").Value = $"Total pasivo corriente:";
                            worksheet.Cell("B31").Value = pasivoCorriente * -1;
                            worksheet.Cell("B31").Style.Border.SetBottomBorder(XLBorderStyleValues.Double);

                            worksheet.Cell("A33").Value = $"Prestamos bancarios:";
                            worksheet.Cell("B33").Value = prestBancarios2 * -1;
                            worksheet.Cell("A34").Value = $"Documentos por pagar:";
                            worksheet.Cell("B34").Value = docPagar2 * -1;
                            worksheet.Cell("A35").Value = $"Hipotecas:";
                            worksheet.Cell("B35").Value = hipotecas * -1;
                            worksheet.Cell("A36").Value = $"Total pasivo no corriente:";
                            worksheet.Cell("B36").Value = pasivoNoCorriente * -1;
                            worksheet.Cell("B31").Style.Border.SetBottomBorder(XLBorderStyleValues.Double);

                            worksheet.Cell("A38").Value = $"Total pasivo:";
                            worksheet.Cell("B38").Value = totalPasivo * -1;
                            worksheet.Cell("B38").Style.Border.SetBottomBorder(XLBorderStyleValues.Double);

                            worksheet.Cell("A40").Value = $"Capital:";
                            worksheet.Cell("B40").Value = capital * -1;
                            worksheet.Cell("A41").Value = $"Utilidades de años anteriores:";
                            worksheet.Cell("B41").Value = utilidades * -1;
                            worksheet.Cell("A42").Value = $"Reserva legal:";
                            worksheet.Cell("B42").Value = reservaLegal * -1;
                            worksheet.Cell("A43").Value = $"Utilidad del ejercicio (Perdida o ganancia):";
                            worksheet.Cell("B43").Value = utilidadEjercicio * -1;
                            worksheet.Cell("B43").Style.Border.SetBottomBorder(XLBorderStyleValues.Double);

                            worksheet.Cell("A45").Value = $"Total de capital:";
                            worksheet.Cell("B45").Value = totalCapital * -1;
                            worksheet.Cell("B45").Style.Border.SetBottomBorder(XLBorderStyleValues.Double);

                            worksheet.Cell("A47").Value = $"Pasivo + capital:";
                            worksheet.Cell("B47").Value = totalFinal * -1;
                            worksheet.Cell("B47").Style.Border.SetBottomBorder(XLBorderStyleValues.Double);

                            worksheet.Columns("A").AdjustToContents();
                            worksheet.Columns("B").AdjustToContents();


                            workbook.SaveAs("C:\\ProgramaConta/BalanceGeneral_" + nombreArchivo + ".xlsx");
                        }
                    }
                } catch(Exception ex) { Console.WriteLine(ex.ToString()); } 

            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
