using ContaConsola;
using System;
using System.IO;
using System.Text;

namespace HelloWorld
{

    class Program
    {
        static void Main(string[] args)
        {
            //Variables para apuntar y mantener ciclos
            int Pointer;
            bool whiling;

            FileManagerSystem.EscrituraInicial(@"c:\ProgramaConta");
            //FileManagerSystem.Lectura(@"c:\ProgramaConta\Nomenclatura1.csv");


            
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
                        break;
                }

                switch (Pointer)
                {
                    case 1:
                        OpcionElegida();
                        Console.Clear();
                        Partidas.Funciones(Pointer);
                        break;
                    case 2:
                        OpcionElegida();
                        Console.Clear();
                        Nomenclaturas.Funciones(Pointer);
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