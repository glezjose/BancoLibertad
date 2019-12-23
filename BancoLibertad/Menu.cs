using BancoLibertad.CuentaBancaria;
using System;
using System.Collections.Generic;

namespace BancoLibertad
{
    public class Menu
    {
        public static int iIdCuenta;
        public static short iTipoCuenta;

        /// <summary>
        /// Menú principal del sistema.
        /// </summary>
        /// <param name="_oNormal">Objeto de tipo cliente normal</param>
        /// <param name="_oUniversitario">Objeto de tipo cliente universitario</param>
        /// <returns></returns>
        public static bool OpcionMenu(Normal _oNormal, Universitario _oUniversitario)
        {
            Console.WriteLine("\nBienvenido a Banco Libertad, ¿Que movimiento desea realizar?\n");
            Console.WriteLine("1. Registrar Cuenta\n2. Ingresar a cuenta\n3. Salir");
            // Switch con el menú de opciones del menú principal.
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
                            iIdCuenta = _oNormal.RegistrarCuenta();// Se invoca al método que registra una cuenta nueva de tipo normal.
                            iTipoCuenta = 1;
                        }
                        else if (_iOpcionCuenta == 2)
                        {
                            iIdCuenta = _oUniversitario.RegistrarCuenta();// Se invoca al método que registra una cuenta nueva de tipo universitario.
                            iTipoCuenta = 2;
                        }
                        else
                        {
                            iIdCuenta = -1;
                            Console.WriteLine("Por favor elija una opción valida.");
                        }
                        if (iIdCuenta != -1)
                        {
                            OpcionMovimiento(_oNormal, _oUniversitario, iTipoCuenta);// Invoca al metodo Opcion Movimiento para desplegar el menu de opciones de movimientos.
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
                            iIdCuenta = _oNormal.IngresarCuenta();// Método para ingresar a la cuenta elegida de tipo normal.
                            iTipoCuenta = 1;
                        }
                        else if (_iOpcionCuenta == 2)
                        {
                            iIdCuenta = _oUniversitario.IngresarCuenta();// Método para ingresar a la cuenta elegida de tipo universitario.
                            iTipoCuenta = 2;
                        }
                        else
                        {
                            Console.WriteLine("Por favor elija una opción valida.");
                        }


                        if (iIdCuenta != -1)
                        {
                            OpcionMovimiento(_oNormal, _oUniversitario, iTipoCuenta);// Invoca al método Opción Movimiento para desplegar el menú de opciones de movimientos.
                        }
                        return true;
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Por favor elija una opción valida.sdxcsdfs");
                        return false;
                    }

                case "3":// Opcion para terminar la ejecución del programa.
                    return false;

                default:
                    Console.Clear();
                    Console.WriteLine("\nPor favor elija una opción valida.");
                    return true;
            }
        }
        /// <summary>
        /// Método para desplegar el menú de Opciones de Movimientos (Switch).
        /// </summary>
        /// <param name="_oNormal">Objeto de tipo cliente normal</param>
        /// <param name="_oUniversitario">Objeto de tipo cliente universitario</param>
        /// <param name="iTipoCuenta">tipo de cuenta (universitario o normal)</param>
        public static void OpcionMovimiento(Normal _oNormal, Universitario _oUniversitario, short iTipoCuenta)
        {
            bool lValidar = true;
            while (lValidar)
            {
                Console.WriteLine("\nSeleccione una operación a realizar:\n\n1. Retirar\n2. Depositar\n3. Consultar Saldo\n4. Menú Principal");

                switch (Console.ReadLine())
                {
                    case "1":// Retirar
                        Console.Clear();
                        Console.Write("Por favor indique el monto a retirar: ");
                        try
                        {
                            decimal dMonto = Convert.ToDecimal(Console.ReadLine());

                            if (iTipoCuenta == 1)
                            {
                                _oNormal.Retirar(iIdCuenta, dMonto);// Método de la clase normal para retirar.
                            }
                            else if (iTipoCuenta == 2)
                            {
                                _oUniversitario.Retirar(iIdCuenta, dMonto);// Método de la clase universitario para retirar.
                            }

                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("Por favor ingrese un monto válido.");
                        }
                        lValidar = true;
                        break;

                    case "2":// Depositar
                        Console.Clear();
                        Console.WriteLine("\nSeleccione el tipo de deposito:\n\n1. Deposito a otra cuenta\n2. Deposito a cuenta personal");
                        try
                        {
                            int _iOpcionDeposito = Convert.ToInt32(Console.ReadLine());

                            if (_iOpcionDeposito == 1) // Si se elige deposito a otra cuenta
                            {
                                Console.WriteLine("\nSeleccione el tipo de cuenta a depositar:\n\n1. Cuenta Normal\n2. Cuenta Universitaria");

                                try
                                {
                                    int _iOpcionCuenta = Convert.ToInt32(Console.ReadLine());
                                    int iIdCuentaDeposito;

                                    if (_iOpcionCuenta == 1)
                                    {
                                        iTipoCuenta = 1;

                                        iIdCuentaDeposito = _oNormal.ValidarNumeroCuenta();// Se valida que exista la cuenta a la cual se desea depositar.

                                        if (iIdCuentaDeposito!=-1)
                                        {
                                            string cConcepto = _oNormal.ObtenerConcepto();// Se invoca al método que captura el concepto del deposito.
                                            bool verificador = true;

                                            while (verificador)
                                            {
                                                try
                                                {
                                                    decimal dMonto = _oNormal.MontoDepositar();// Se invoca al método que captura el monto a depositar.
                                                    verificador = false;
                                                    _oNormal.Depositar(iIdCuentaDeposito, iTipoCuenta, dMonto, cConcepto);// Se invoca al método que Depositar el cual hace la implementación de dicho método de la Interfaz IDepositar en la clase Normal. 


                                                }
                                                catch (FormatException)
                                                {
                                                    Console.WriteLine("\nPor favor ingrese un monto válido, intente de nuevo...\n");
                                                    verificador = true;
                                                }
                                            }

                                        }

                                    }
                                    else if (_iOpcionCuenta == 2)
                                    {
                                        iTipoCuenta = 2;

                                        iIdCuentaDeposito = _oUniversitario.ValidarNumeroCuenta();// Se valida que exista la cuenta a la cual se desea depositar.

                                        if (iIdCuentaDeposito!=-1)
                                        {
                                            string cConcepto = _oUniversitario.ObtenerConcepto();// Se invoca al método que captura el concepto del deposito.
                                            bool verificador = true;

                                            while (verificador)
                                            {
                                                try
                                                {
                                                    decimal dMonto = _oUniversitario.MontoDepositar();// Se invoca al método que captura el monto a depositar.

                                                    verificador = false;

                                                    _oUniversitario.Depositar(iIdCuentaDeposito, iTipoCuenta, dMonto, cConcepto);// Se invoca al método que Depositar el cual hace la implementación de dicho método de la Interfaz IDepositar en la clase Universitario. 

                                                    lValidar = false;
                                                }
                                                catch (FormatException)
                                                {
                                                    Console.WriteLine("\nPor favor ingrese un monto válido, intente de nuevo...\n");
                                                    verificador = true;
                                                }
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
                            else if (_iOpcionDeposito == 2)// Si se elige deposito a la misma cuenta.
                            {
                                    if (iTipoCuenta == 1) // Tipo de cuenta normal
                                    {
                                        bool verificador = true;
                                        while (verificador)
                                        {
                                            try
                                            {
                                                decimal dMonto = _oNormal.MontoDepositar();// Se invoca al método que captura el monto a depositar.
                                            verificador = false;
                                                _oNormal.Depositar(iIdCuenta, iTipoCuenta, dMonto);// Se hace la instancia del objeto Normal para instanciar el método Depositar.


                                        }
                                            catch (FormatException)
                                            {
                                                Console.WriteLine("\nPor favor ingrese un monto válido, intente de nuevo...\n");
                                                verificador = true;
                                            }
                                        }


                                    }
                                    else if (iTipoCuenta == 2) // Tipo de cuenta universitario.
                                {
                                        bool verificador = true;
                                        while (verificador)
                                        {
                                            try
                                            {
                                                decimal dMonto = _oUniversitario.MontoDepositar();// Se invoca al método que captura el monto a depositar.
                                            verificador = false;
                                                _oUniversitario.Depositar(iIdCuenta, iTipoCuenta, dMonto);// Se hace la instancia del objeto Universitario para instanciar el método Depositar.

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

                    case "3":// Consulta el saldo del cliente.
                        Console.Clear();
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

            // Cuando la opcion seleccionada no sea la opcion de salir(Que el booleano sea falso)
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
