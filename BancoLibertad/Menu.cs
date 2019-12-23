using BancoLibertad.CuentaBancaria;
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
            Console.WriteLine("\nBienvenido a Banco Libertad, ¿Que movimiento desea realizar?\n");
            Console.WriteLine("1. Registrar Cuenta\n2. Ingresar a cuenta\n3. Salir");

            switch (Console.ReadLine())
            {
                case "1":
                    Console.WriteLine("\nElija el tipo de cuenta a registrar por favor.");
                    Console.WriteLine("\n1. Cuenta Normal\n2. Cuenta Universitaria");

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
                            iIdCuenta = -1;
                            Console.WriteLine("Por favor elija una opción valida.");
                        }
                        if (iIdCuenta != -1)
                        {
                            OpcionMovimiento(_oNormal, _oUniversitario, iTipoCuenta);
                        }
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Por favor elija una opción valida.");
                    }
                    return true;

                case "2":
                    Console.WriteLine("Elija el tipo de cuenta a la cual desea ingresar");
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


                        if (iIdCuenta != -1)
                        {
                            OpcionMovimiento(_oNormal, _oUniversitario, iTipoCuenta);
                        }
                        return true;
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Por favor elija una opción valida.sdxcsdfs");
                        return false;
                    }



                case "3":
                    return false;

                default:
                    Console.Clear();
                    Console.WriteLine("\nPor favor elija una opción valida.");
                    return true;
            }
        }
        public static void OpcionMovimiento(Normal _oNormal, Universitario _oUniversitario, short iTipoCuenta)
        {
            bool lValidar = true;
            while (lValidar)
            {
                Console.WriteLine("\nSeleccione una operación a realizar:\n\n1. Retirar\n2. Depositar\n3. Consultar Saldo\n4. Menú Principal");

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
                        lValidar = true;
                        break;

                    case "2":
                        Console.WriteLine("\nSeleccione el tipo de deposito:\n\n1. Deposito a otra cuenta\n2. Deposito a cuenta personal");
                        try
                        {
                            int _iOpcionDeposito = Convert.ToInt32(Console.ReadLine());

                            if (_iOpcionDeposito == 1)
                            {
                                Console.WriteLine("\nSeleccione el tipo de cuenta a depositar:\n\n1. Cuenta Normal\n2. Cuenta Universitaria");

                                try
                                {
                                    int _iOpcionCuenta = Convert.ToInt32(Console.ReadLine());
                                    int iIdCuentaDeposito;

                                    if (_iOpcionCuenta == 1)
                                    {
                                        iTipoCuenta = 1;

                                        iIdCuentaDeposito = _oNormal.ValidarNumeroCuenta();

                                        string cConcepto = _oNormal.ObtenerConcepto();
                                        bool verificador = true;

                                        while (verificador)
                                        {
                                            try
                                            {
                                                decimal dMonto = _oNormal.MontoDepositar();
                                                verificador = false;
                                                _oNormal.Depositar(iIdCuentaDeposito, iTipoCuenta, dMonto, cConcepto);


                                            }
                                            catch (FormatException)
                                            {
                                                Console.WriteLine("\nPor favor ingrese un monto válido, intente de nuevo...\n");
                                                verificador = true;
                                            }
                                        }


                                    }
                                    else if (_iOpcionCuenta == 2)
                                    {
                                        iTipoCuenta = 2;

                                        iIdCuentaDeposito = _oUniversitario.ValidarNumeroCuenta();

                                        string cConcepto = _oUniversitario.ObtenerConcepto();
                                        bool verificador = true;

                                        while (verificador)
                                        {
                                            try
                                            {
                                                decimal dMonto = _oUniversitario.MontoDepositar();

                                                verificador = false;

                                                _oUniversitario.Depositar(iIdCuentaDeposito, iTipoCuenta, dMonto, cConcepto);

                                                lValidar = false;
                                            }
                                            catch (FormatException)
                                            {
                                                Console.WriteLine("\nPor favor ingrese un monto válido, intente de nuevo...\n");
                                                verificador = true;
                                            }
                                        }
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
                                    if (iTipoCuenta == 1)
                                    {
                                        bool verificador = true;
                                        while (verificador)
                                        {
                                            try
                                            {
                                                decimal dMonto = _oNormal.MontoDepositar();
                                                verificador = false;
                                                _oNormal.Depositar(iIdCuenta, iTipoCuenta, dMonto);


                                            }
                                            catch (FormatException)
                                            {
                                                Console.WriteLine("\nPor favor ingrese un monto válido, intente de nuevo...\n");
                                                verificador = true;
                                            }
                                        }


                                    }
                                    else if (iTipoCuenta == 2)
                                    {
                                        bool verificador = true;
                                        while (verificador)
                                        {
                                            try
                                            {
                                                decimal dMonto = _oUniversitario.MontoDepositar();
                                                verificador = false;
                                                _oUniversitario.Depositar(iIdCuenta, iTipoCuenta, dMonto);

                                            }
                                            catch (FormatException)
                                            {
                                                Console.WriteLine("\nPor favor ingrese un monto válido, intente de nuevo...\n");
                                                verificador = true;
                                            }
                                        }

                                    }
                                    else
                                    {
                                        Console.WriteLine("Por favor elija una opción valida.");

                                    }

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

                        lValidar = false;
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

                    case "4":
                        Console.Clear();
                        lValidar = false;
                        break;

                    default:
                        Console.Clear();
                        Console.WriteLine("Por favor elija una opción valida.");
                        lValidar = true;
                        break;
                }
            }
        }

        public static void Main(string[] args)
        {
            Normal _oNormal = new Normal();
            Universitario _oUniversitario = new Universitario();
            try
            {
                while (OpcionMenu(_oNormal, _oUniversitario)) ;

            }
            catch (FormatException)
            {
                Console.WriteLine("Por favor elija una opción valida");
            }
        }
    }
}
