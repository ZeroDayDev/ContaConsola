using System.Drawing;

namespace ContaConsola
{


    internal class Clases
    {

        public class BalanceGeneral
        {
        }
        public class EstadoDeResultados
        {
        }
        public class Cuentas
        {
            private int IDcuenta;
            private string ClasfCuenta;
            public List<string> fechas = new List<string>();
            public List<string> valores = new List<string>();
            public int ID { get => IDcuenta; }
            public string Clasificacion { get => ClasfCuenta; }



            public Cuentas(int idConstructor, string ClasificacionCuenta)
            {
                IDcuenta = idConstructor;
                ClasfCuenta = ClasificacionCuenta;
            }

            public string IngresoPartida(string fecha, string valor, string nombreCuenta)
            {
                if (Clasificacion == "Activos" || Clasificacion == "Activos Corrientes" || Clasificacion == "Activos No corrientes" || Clasificacion == "Activos Fijos" || Clasificacion == "Gastos" || Clasificacion == "Costo de venta")
                {
                    valores.Add(valor);
                }

                else if (Clasificacion == "Pasivos" || Clasificacion == "Pasivos No corrientes" || Clasificacion == "Patrimonio" || Clasificacion == "Ingresos" || Clasificacion == "Regulador de activos")
                {
                    double valorNum = Convert.ToDouble(valor);

                    valorNum = valorNum * -1;
                    string valorStr = Convert.ToString(valorNum);

                    valores.Add(valorStr);
                }

                string fechaPartida = Convert.ToString(DateTime.Parse(fecha));

                if(fecha == "si")
                {
                    fechas.Add(fecha);
                    fechaPartida = fecha;
                }
                else
                {
                    fechaPartida = fecha;
                    fechas.Add(fechaPartida);
                }

                Console.WriteLine($"Se ha hecho un ingreso en la fecha {fechaPartida}, con un valor positivo de {valor} en la cuenta {nombreCuenta}");

                return Clasificacion;
            }

            public static string RegistroClasf(int id)
            {
                string idString = Convert.ToString(id);
                string idSumando = "";
                string clasfFinal = "CRIT_ERROR";



                for (int i = 0; i < idString.Length; i++)
                {

                    //Primer gran renglon
                    switch (idString[i])
                    {
                        case '1':
                            idSumando = idSumando + "1";
                            break;
                        case '2':
                            idSumando = idSumando + "2";
                            break;
                        case '3':
                            idSumando = idSumando + "3";
                            break;
                        case '4':
                            idSumando = idSumando + "4";
                            break;
                        case '5':
                            idSumando = idSumando + "5";
                            break;
                        case '6':
                            idSumando = idSumando + "6";
                            break;
                        
                    }
                }

                if (idSumando.StartsWith("1"))
                {
                    clasfFinal = "Activos";

                    if (idSumando.StartsWith("11"))
                    {
                        clasfFinal = "Activos Corrientes";
                    }                    
                    if (idSumando.StartsWith("12"))
                    {
                        clasfFinal = "Activos Fijos";
                    }
                    if (idSumando.StartsWith("13"))
                    {
                        clasfFinal = "Regulador de activos";
                    }                   
                    if (idSumando.StartsWith("14"))
                    {
                        clasfFinal = "Activos no corrientes";
                    }


                }

                if (idSumando.StartsWith("2"))
                {
                    clasfFinal = "Pasivos";

                    if (idSumando.StartsWith("21"))
                    {
                        clasfFinal = "Pasivos No corrientes";
                    }
                    if (idSumando.StartsWith("22"))
                    {
                        clasfFinal = "Pasivos Corrientes";
                    }

                }

                if (idSumando.StartsWith("3"))
                {
                    clasfFinal = "Patrimonio";
                }

                if (idSumando.StartsWith("4"))
                {
                    clasfFinal = "Ingresos";
                }

                if (idSumando.StartsWith("5"))
                {
                    clasfFinal = "Gastos";
                }

                if (idSumando.StartsWith("6"))
                {
                    clasfFinal = "Costo de venta";
                }

                return clasfFinal;

            }

            static public void IngresoPartidaInicial(List<Cuentas> listaCuentas)
            {
                Dictionary<string, int> dict = new Dictionary<string, int>();

                dict = FileManagerSystem.LecturaNomenclatura(@"c:\ProgramaConta\Nomenclatura1.csv", false);
                string filePath = @"c:\ProgramaConta\Partidas\Junio.csv";

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

                                    if (cuenta.Clasificacion == "Activos" || cuenta.Clasificacion == "Activos Corrientes" || cuenta.Clasificacion == "Activos No corrientes" || cuenta.Clasificacion == "Activos Fijos" || cuenta.Clasificacion == "Gastos" || cuenta.Clasificacion == "Costo de venta")
                                    {
                                        if (!string.IsNullOrEmpty(ids[2]))
                                        {
                                            cuenta.valores.Add(ids[2]);
                                        }

                                        if (!string.IsNullOrEmpty(ids[3]))
                                        {
                                            double valorNum = Convert.ToDouble(ids[3]);
                                            valorNum = valorNum * -1;
                                            string valorStr = Convert.ToString(valorNum);

                                            cuenta.valores.Add(valorStr);
                                        }
                                    }

                                    else if (cuenta.Clasificacion == "Pasivos" || cuenta.Clasificacion == "Pasivos No corrientes" || cuenta.Clasificacion == "Patrimonio" || cuenta.Clasificacion == "Ingresos")
                                    {


                                        if (!string.IsNullOrEmpty(ids[2]))
                                        {
                                            double valorNum = Convert.ToDouble(ids[2]);
                                            valorNum = valorNum * -1;
                                            string valorStr = Convert.ToString(valorNum);

                                            cuenta.valores.Add(valorStr);
                                        }

                                        if (!string.IsNullOrEmpty(ids[3]))
                                        {
                                            cuenta.valores.Add(ids[3]);
                                        }

                                    }
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

        }

    }
}
