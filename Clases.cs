using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            private long IDcuenta;
            private string ClasfCuenta;
            public List<string> fechas = new List<string>();
            public List<string> valores = new List<string>();
            public long ID { get => IDcuenta; }
            public string Clasificacion { get => ClasfCuenta; }



            public Cuentas(long idConstructor, string ClasificacionCuenta)
            {
                IDcuenta = idConstructor;
                ClasfCuenta = ClasificacionCuenta;
            }

            public static void IngresoPartida(int id)
            {
                switch (id)
                {
                    case 1:

                        break;
                }
            }
        }

    }
}
