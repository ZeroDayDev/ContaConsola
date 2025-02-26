﻿using ContaConsola;
using System;
using System.IO;
using System.Text;

namespace HelloWorld
{

    class Basics
    {
        

        public static List<Clases.Cuentas> ExecOrigins()
        {
            FileManagerSystem.EscrituraInicial(@"c:\ProgramaConta", @"c:\ProgramaConta\Partidas", @"c:\ProgramaConta\EFS");
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
            Clases.Cuentas.IngresoPartidaInicial(cuentas);


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
                Console.WriteLine("3. Balance general, Estado de resultados y Balance de saldos");
                Console.WriteLine("4. Creditos y licencia");
                Console.WriteLine("5. Salir");

                //El puntero toma el input, si no es un numero, apunta a 0, reiniciandolo
                OpcionElegida();

                switch (Pointer)
                {
                    case 1:
                        whiling = false;
                        Console.Clear();
                        Console.WriteLine("1. Ingresar partida (Jornalizacion)");
                        Console.WriteLine("2. Ver jornalizacion");
                        Console.WriteLine("3. Visualizar partidas (DMG)");
                        Console.WriteLine("4. Salir"); 
                        break;

                    case 2:
                        whiling = false;
                        Console.Clear();
                        Console.WriteLine("1. Visualizar nomenclatura ");
                        Console.WriteLine("2. Crear fichero");
                        Console.WriteLine("3. Salir");
                        
                        break;

                    case 3:
                        whiling = false;
                        Console.Clear();
                        Console.WriteLine("1. Crear y ver BG");
                        Console.WriteLine("2. Crear y ver ER");
                        Console.WriteLine("3. Visualizar balance de saldos");
                        Console.WriteLine("4. Salir");
                        break;

                    case 4:
                        whiling = false;
                        Console.Clear();
                        Console.WriteLine("Gracias por revisar esto, pero no tengo ni idea de licencias. Asi que todos los derechos reservados.");
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
                        OpcionElegida();
                        Console.Clear();
                        EF.Funciones(Pointer, cuentas);
                        Console.Clear();
                        break;
                    default:
                        Console.WriteLine("Error, seleccion incorrecta");
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