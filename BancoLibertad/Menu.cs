﻿using BancoLibertad.CuentaBancaria;
using System;
using System.Collections.Generic;

namespace BancoLibertad
{
    public class Menu
    {
        public static int iIdCuenta;
        public static short iTipoCuenta;
        public static bool OpcionMenu(Normal _oNormal, Universitario _oUniversitario)
        {
            Console.WriteLine("\nBienvenido a Banco Libertad, que movimiento desea realizar?");
            Console.WriteLine("1. Registrar Cuenta\n2. Ingresar a cuenta\n3. Salir");

            switch (Console.ReadLine())
            {
                case "1":
                    Console.WriteLine("Elija el tipo de cuenta por favor.");
                    Console.WriteLine("1. Cuenta Normal\n2. Cuenta Universitaria");

                    try
                    {
                        int _iOpcionCuenta = Convert.ToInt32(Console.ReadLine());

                        if (_iOpcionCuenta == 1)
                        {
                            iIdCuenta = _oNormal.RegistrarCuenta();
                            iTipoCuenta = 1;
                        }
                        else if (_iOpcionCuenta == 2)
                        {
                            iIdCuenta = _oUniversitario.RegistrarCuenta();
                            iTipoCuenta = 2;
                        }
                        else
                        {
                            Console.WriteLine("Por favor elija una opción valida.");
                        }

                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Por favor elija una opción valida.");
                    }

                    if (iIdCuenta != -1)
                    {
                        OpcionMovimiento(_oNormal, _oUniversitario, iTipoCuenta);
                    }

                    return true;

                case "2":
                    Console.WriteLine("Elija el tipo de cuenta por favor.");
                    Console.WriteLine("1. Cuenta Normal\n2. Cuenta Universitaria");

                    try
                    {
                        int _iOpcionCuenta = Convert.ToInt32(Console.ReadLine());

                        if (_iOpcionCuenta == 1)
                        {
                            iIdCuenta = _oNormal.IngresarCuenta();
                            iTipoCuenta = 1;
                        }
                        else if (_iOpcionCuenta == 2)
                        {
                            iIdCuenta = _oUniversitario.IngresarCuenta();
                            iTipoCuenta = 2;
                        }
                        else
                        {
                            Console.WriteLine("Por favor elija una opción valida.");
                        }

                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Por favor elija una opción valida.");
                    }

                    if (iIdCuenta != -1)
                    {
                        OpcionMovimiento(_oNormal, _oUniversitario, iTipoCuenta);
                    }

                    return true;
                case "3":
                    return false;

                default:
                    Console.Clear();
                    Console.WriteLine("Por favor elija una opción valida.");
                    return true;
            }
        }
        public static void OpcionMovimiento(Normal _oNormal, Universitario _oUniversitario, short iTipoCuenta)
        {
            bool lValidar = true;
            while (lValidar)
            {
                Console.WriteLine("1. Retirar\n2. Depositar\n3. Consultar Saldo");

                switch (Console.ReadLine())
                {
                    case "1":
                        Console.Write("Por favor indique el monto a retirar: ");
                        try
                        {
                            decimal dMonto = Convert.ToDecimal(Console.ReadLine());

                            if (iTipoCuenta == 1)
                            {
                                _oNormal.Retirar(iIdCuenta, dMonto);
                            }
                            else if (iTipoCuenta == 2)
                            {
                                _oUniversitario.Retirar(iIdCuenta, dMonto);
                            }

                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("Por favor ingrese un monto válido.");
                        }
                        lValidar = false;
                        break;

                    case "2":
                        Console.WriteLine("1. Deposito a otra cuenta\n2. Deposito a cuenta personal");
                        try
                        {
                            int _iOpcionDeposito = Convert.ToInt32(Console.ReadLine());

                            if (_iOpcionDeposito == 1)
                            {
                                Console.WriteLine("1. Cuenta Normal\n2. Cuenta Universitaria");

                                try
                                {
                                    int _iOpcionCuenta = Convert.ToInt32(Console.ReadLine());
                                    int iIdCuentaDeposito

                                    if (_iOpcionCuenta == 1)
                                    {
                                        iTipoCuenta = 1;

                                        iIdCuentaDeposito = _oNormal.ValidarNumeroCuenta();

                                        string cConcepto = _oNormal.ObtenerConcepto();
                                    }
                                    else if (_iOpcionCuenta == 2)
                                    {
                                        iTipoCuenta = 2;

                                        iIdCuentaDeposito = _oUniversitario.ValidarNumeroCuenta();

                                        string cConcepto = _oUniversitario.ObtenerConcepto();
                                    }
                                    else
                                    {
                                        Console.WriteLine("Por favor elija una opción valida.");
                                    }

                                }
                                catch (FormatException)
                                {
                                    Console.WriteLine("Por favor elija una opción valida.");
                                }



                            }
                            else if (_iOpcionDeposito == 2)
                            {
                               //Aqui va deposito a cuenta personal.

                            }
                            else
                            {
                                Console.WriteLine("Por favor elija una opción valida.");
                            }

                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("Por favor elija una opción valida.");
                        }

                        lValidar = true;
                        break;

                    case "3":
                        if (iTipoCuenta == 1)
                        {
                            Console.WriteLine(_oNormal.ConsultarSaldo(_oNormal._lstNormal[iIdCuenta].dSaldo));
                        }
                        else if (iTipoCuenta == 2)
                        {
                            Console.WriteLine(_oNormal.ConsultarSaldo(_oUniversitario._lstUniversitarios[iIdCuenta].dSaldo));
                        }
                        lValidar = true;
                        break;

                    default:
                        Console.Clear();
                        Console.WriteLine("Por favor elija una opción valida.");
                        lValidar = true;
                        break;
                }
            }
        }

        public

        static void Main(string[] args)
        {
            Normal _oNormal = new Normal();
            Universitario _oUniversitario = new Universitario();
            try
            {
                while (OpcionMenu(_oNormal, _oUniversitario)) ;

            }
            catch (FormatException)
            {
                Console.WriteLine("Por favor elija una opción valida.");
            }
        }
    }
}