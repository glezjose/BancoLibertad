using System;
using System.Collections.Generic;
using System.Text;

namespace BancoLibertad.CuentaBancaria
{
    public class Universitario : CuentaBancaria
    {
        public override int RegistrarCuenta()
        {
            int iIdCuenta;
            Cliente.Universitario oUniversitario = new Cliente.Universitario();
            try
            {
                Console.Write("Ingrese su Nombre: ");
                oUniversitario.cNombre = Console.ReadLine();

                Console.Write("Ingrese su Apellido: ");
                oUniversitario.cApellido = Console.ReadLine();

                Console.Write("Ingrese el Nombre de su tutor: ");
                oUniversitario.cNombreTutor = Console.ReadLine();

                Console.Write("Ingrese el Nombre de su universidad: ");
                oUniversitario.cInstituto = Console.ReadLine();

                Console.Write("Ingrese un NIP para su cuenta: ");
                oUniversitario.iNIP = Convert.ToInt32(Console.ReadLine());

                if (_lstUniversitarios == null)
                {
                    _lstUniversitarios = new List<Cliente.Universitario>();
                    oUniversitario.iIdClienteUniversitario = 0;
                    iIdCuenta = 0;
                }
                else
                {
                    oUniversitario.iIdClienteUniversitario = _lstUniversitarios.Count;
                    iIdCuenta = _lstUniversitarios.Count;
                }

                oUniversitario.dSaldo = 0;

                _lstUniversitarios.Add(oUniversitario);

                Console.Clear();
                Console.WriteLine("\nBienvenido, " + oUniversitario.cNombre + ".\n");
                Console.WriteLine("\nSu numero de cuenta es: " + oUniversitario.iIdClienteUniversitario+"\n");
            }
            catch (FormatException)
            {
                Console.WriteLine("Por favor ingrese una opción valida.");
                iIdCuenta = -1;
            }
            return iIdCuenta;
        }

        public override int IngresarCuenta()
        {
            int iIdCuenta;
            try
            {
                Console.WriteLine("Ingrese su número de cuenta: ");
                iIdCuenta = Convert.ToInt32(Console.ReadLine());
                try
                {
                    if (iIdCuenta == _lstUniversitarios[iIdCuenta].iIdClienteUniversitario)
                    {
                        Console.WriteLine("Digite su NIP: ");
                        int iNIP = Convert.ToInt32(Console.ReadLine());
                        if (iNIP != _lstUniversitarios[iIdCuenta].iNIP)
                        {
                            Console.WriteLine("\nEl NIP ingresado es incorrecto,redirigiendo al menú principal...\n");
                            iIdCuenta = -1;
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("Bienvenido, " + _lstUniversitarios[iIdCuenta].cNombre + ".\n");
                        }
                    }
                }
                catch (ArgumentOutOfRangeException)
                {
                    Console.WriteLine("\nLa cuenta a la cual quiere ingresar no existe, redirigiendo al Menú Principal...");
                    iIdCuenta = -1;
                }

            }
            catch (FormatException)
            {
                Console.WriteLine("Por favor ingrese un número válido.");
                iIdCuenta = -1;
            }
            catch (NullReferenceException)
            {
                Console.WriteLine("\nLa cuenta a la cual quiere ingresar no existe, redirigiendo al Menú Principal...");
                iIdCuenta = -1;


            }
            return iIdCuenta;
        }
        public override void Retirar(int iIdCuenta, decimal dMonto)
        {
            if (dMonto < 3000)
            {
                if (_lstUniversitarios[iIdCuenta].dSaldo >= dMonto)
                {
                    _lstUniversitarios[iIdCuenta].dSaldo -= dMonto;
                    Console.WriteLine("Transacción exitosa!\nSe ha retirado: $" + dMonto + ".");
                }
                else
                {
                    Console.WriteLine("\nUsted no cuenta con el saldo suficiente para realizar esta transacción.");
                }
            }
            else
            {
                Console.WriteLine("Al tener una cuenta universitaria, usted no puede realizar retiros mayores a los 3000 pesos mexicanos.\nSe requiere autorización de su tutor: " + _lstUniversitarios[iIdCuenta].cNombreTutor + ".");
            }
        }

        public override int ValidarNumeroCuenta()
        {
            int iIdCuenta;
            Console.Write("Por favor indique el número de cuenta: ");
            iIdCuenta = Convert.ToInt32(Console.ReadLine());
            try
            {
                if (iIdCuenta == _lstUniversitarios[iIdCuenta].iIdClienteUniversitario)
                {
                    Console.WriteLine("El número de cuenta ingresado le pertenece a, " + _lstUniversitarios[iIdCuenta].cNombre + " " + _lstUniversitarios[iIdCuenta].cApellido + ".");
                }
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.WriteLine("No existe este número de cuenta.");
                iIdCuenta = -1;
            }
            return iIdCuenta;
        }

        public new void Depositar(int iIdCuentaDeposito, int iTipoCuenta, decimal dMonto, string cConcepto)
        {
            if (iTipoCuenta == 1)
            {
                _lstNormal[iIdCuentaDeposito].dSaldo += dMonto;
                Console.WriteLine("\n\nSe a depositado con exito: $" + dMonto + " a la cuenta de " + _lstNormal[iIdCuentaDeposito].cNombre + " " + _lstNormal[iIdCuentaDeposito].cApellido + " por concepto de " + cConcepto);
            }
            else if (iTipoCuenta == 2)
            {
                _lstUniversitarios[iIdCuentaDeposito].dSaldo += dMonto;
                Console.WriteLine("\n\nSe a depositado con exito: $" + dMonto + " a la cuenta universitaria de " + _lstUniversitarios[iIdCuentaDeposito].cNombre + " " + _lstUniversitarios[iIdCuentaDeposito].cApellido + " por concepto de " + cConcepto);
            }


        }
        public new void Depositar(int iIdCuenta, int iTipoCuenta, decimal dMonto)
        {
            if (iTipoCuenta == 1)
            {
                _lstNormal[iIdCuenta].dSaldo += dMonto;
                Console.WriteLine("\n\nSe a depositado con exito: $" + dMonto + " a tu cuenta con numero: " + _lstNormal[iIdCuenta].iIdClienteNormal);
            }
            else if (iTipoCuenta == 2)
            {
                _lstUniversitarios[iIdCuenta].dSaldo += dMonto;
                Console.WriteLine("\n\nSe a depositado con exito: $" + dMonto + " a tu cuenta universitaria con numero: " + _lstUniversitarios[iIdCuenta].iIdClienteUniversitario);
            }


        }

    }
}
