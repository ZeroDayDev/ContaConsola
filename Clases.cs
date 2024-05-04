﻿namespace ContaConsola
{


    internal class Clases
    {

        public class BalanceGeneral
        {
            private long ID;
            private string[] fechas = Array.Empty<string>();
            private Cuentas[] cuentas = Array.Empty<Cuentas>();
        }
        public class EstadoDeResultados
        {
            private long ID;
            private string[] fechas = Array.Empty<string>();
            private Cuentas[] cuentas = Array.Empty<Cuentas>();
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

            public void IngresoPartida(string fecha, string valor, string nombreCuenta)
            {
                if (Clasificacion == "Activos" || Clasificacion == "Activos Corrientes" || Clasificacion == "Activos No corrientes" || Clasificacion == "Activos Fijos" || Clasificacion == "Gastos" || Clasificacion == "Costo de venta")
                {
                    valores.Add(valor);
                }

                else if (Clasificacion == "Pasivos" || Clasificacion == "Pasivos No corrientes" || Clasificacion == "Patrimonio" || Clasificacion == "Ingresos")
                {
                    int valorNum = Convert.ToInt32(valor);

                    valorNum = valorNum * -1;
                    string valorStr = Convert.ToString(valorNum);

                    valores.Add(valorStr);
                }

                fechas.Add(Convert.ToString(DateTime.Parse(fecha)));
                

                Console.WriteLine($"Se ha hecho un ingreso en la fecha {Convert.ToString(DateTime.Parse(fecha))}, con un valor positivo de {valor} en la cuenta {nombreCuenta}");
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
                        clasfFinal = "Activos No corrientes";
                    }
                    if (idSumando.StartsWith("121"))
                    {
                        clasfFinal = "Activos Fijos";
                    }
                }

                if (idSumando.StartsWith("2"))
                {
                    clasfFinal = "Pasivos";

                    if (idSumando.StartsWith("21"))
                    {
                        clasfFinal = "Pasivos No corrientes";
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

        }

    }
}
