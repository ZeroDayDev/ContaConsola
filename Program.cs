using ContaConsola;
using System;
using System.IO;
using System.Text;

namespace HelloWorld
{

    class Basics
    {
        

        public static List<Clases.Cuentas> ExecOrigins()
        {
            FileManagerSystem.EscrituraInicial(@"c:\ProgramaConta", @"c:\ProgramaConta\Partidas");
            FileManagerSystem.CreacionPartida();
            Dictionary<string, int> dict = new Dictionary<string, int>();

            string clasificacionCuenta;
            List<Clases.Cuentas> cuentas = new List<Clases.Cuentas>();

            dict = FileManagerSystem.LecturaNomenclatura(@"c:\ProgramaConta\Nomenclatura1.csv", false);


            //Registro de cuentas tras guardado de datos en diccionario
            foreach (var item in dict)
            {
                clasificacionCuenta = Clases.Cuentas.RegistroClasf(item.Value);

                //Console.WriteLine($"{item.Key} | {clasificacionCuenta}");

                Clases.Cuentas cuenta = new Clases.Cuentas(item.Value, clasificacionCuenta);
                cuentas.Add(cuenta);
            }

            return cuentas;

        }
    }

    class Program
    {

        static void Main(string[] args)
        {
            List<Clases.Cuentas> cuentas = new List<Clases.Cuentas>();
            cuentas = Basics.ExecOrigins();
            

            //Variables para apuntar y mantener ciclos
            int Pointer;
            bool whiling;

            whiling = true;

            while (whiling)
            {
                //Inicio programa visible
                Console.WriteLine("Bienvenido usuario, a que procedera?");
                Console.WriteLine("1. Partidas");
                Console.WriteLine("2. Nomenclatura cuentas");
                Console.WriteLine("3. Balance general y Estado de resultados");
                Console.WriteLine("4. Creditos y licencia");
                Console.WriteLine("5. Salir");

                //El puntero toma el input, si no es un numero, apunta a 0, reiniciandolo
                OpcionElegida();

                switch (Pointer)
                {
                    case 1:
                        whiling = false;
                        Console.Clear();
                        Console.WriteLine("1. Ingresar partida");
                        Console.WriteLine("2. Retiro partida");
                        Console.WriteLine("3. Modificar partida");
                        Console.WriteLine("4. Visualizar partidas");
                        Console.WriteLine("5. Salir"); 
                        break;

                    case 2:
                        whiling = false;
                        Console.Clear();
                        Console.WriteLine("1. Visualizar nomenclatura");
                        Console.WriteLine("2. Modificar nomenclatura");
                        Console.WriteLine("3. Crear fichero");
                        Console.WriteLine("4. Modificar fichero");
                        Console.WriteLine("5. Remover fichero");
                        Console.WriteLine("6. Salir");
                        
                        break;

                    case 3:
                        whiling = false;
                        Console.Clear();
                        Console.WriteLine("1. Visualizar Balance general y Estado de resultados");
                        Console.WriteLine("2. Crear BG y ER con valores");
                        Console.WriteLine("3. Crear archivo de BG y ER");
                        Console.WriteLine("4. Salir");
                        break;

                    case 4:
                        whiling = false;
                        Console.Clear();
                        Console.WriteLine("Gracias por revisar esto, pero no tengo ni idea de licencias.");
                        Console.WriteLine("Creado por Kleyver De Leon, con el equipo que conformaba a los siguientes integrantes:");
                        Console.WriteLine("Ivan Giron, David Enrique y Kevin Miguel.");
                        break;
                    case 5:
                        whiling = false;
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Esa opcion no existe, intentelo de nuevo.");
                        OpcionElegida();
                        break;
                }

                switch (Pointer)
                {
                    case 1:
                        OpcionElegida();
                        Console.Clear();
                        Partidas.Funciones(Pointer, cuentas);
                        break;
                    case 2:
                        OpcionElegida();
                        Console.Clear();
                        Nomenclaturas.Funciones(Pointer);
                        Console.Clear();
                        break;
                    case 3:
                        Console.WriteLine("A programar!");
                        break;
                    default:
                        Console.WriteLine("Error p");
                        break;

                }

                whiling = true;

            }

            void OpcionElegida()
            {
                try
                {
                    Pointer = Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Pointer = 0;
                }
            }
        }
    }


}