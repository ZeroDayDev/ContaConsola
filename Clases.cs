namespace ContaConsola
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
                Console.WriteLine($"Se ha hecho un ingreso en la fecha {fecha}, con un valor positivo de {valor} en la cuenta {nombreCuenta}");
            }

            public static string RegistroClasf(int id)
            {
                string idString = Convert.ToString(id);
                string idSumando = "";
                string clasfFinal = "CRIT_ERROR";



                for (int i = 0; i < idString.Length; i++)
                {
     
                    //Primer gran renglon
                    if (idString[i] == '1')
                    {
                        idSumando = idSumando + "1";
                        //clasfFinal = $"Activos | Tamaño: {idString.Length}";

                        /*if(idString.Length > 1)
                        {
                            if (idString[i + 1] == '1') { clasfFinal = $"Activos Corrientes | Tamaño: {idString.Length}"; }
                            
                            if (idString[i + 1] == '2')
                            {
                                clasfFinal = $"Activos No corrientes | Tamaño: {idString.Length}";

                                if(idString.Length > 2)
                                {
                                    if (idString[i + 1] == '1') { clasfFinal = "Activos fijos asdasd"; }
                                }
                            }

                            break;

                        }*/
                    }  

                    //Segundo gran renglon
                    if (idString[i] == '2')
                    {
                        idSumando = idSumando + "2";
                        /*clasfFinal = "Pasivos";

                        if(idString.Length > 1)
                        {
                            //ESTO HAY QUE MODIFICARLO SI SE QUIERE QUE SEA MULTINOMENCLATURA [En la seccion de nomenclaturas, eventualmente]
                            if (idString[i + 1] == '1') { clasfFinal = "Pasivos No corrientes"; }
                        }*/
                    }

                    if (idString[i] == '3')
                    {
                        idSumando = idSumando + "3";
                        //clasfFinal = "Patrimonio";
                    }   

                    if (idString[i] == '4')
                    {
                        idSumando = idSumando + "4";
                        //clasfFinal = "Ingresos";
                    }

                    if (idString[i] == '5')
                    {
                        idSumando = idSumando + "5";
                        //clasfFinal = "Gastos";
                    }

                    if (idString[i] == '6')
                    {
                        idSumando = idSumando + "6";
                        //clasfFinal = "Costo de venta";
                    }
                }

                if (idSumando.StartsWith("1"))
                {
                    Console.WriteLine("Activos Corrientes");
                    if (idSumando.StartsWith("11"))
                    {
                        Console.WriteLine("Activos Corrientes");
                    }                    
                    if (idSumando.StartsWith("12"))
                    {

                    }
                }

                return clasfFinal;

            }

            void gettedActivos()
            {

            }
        }

    }
}
