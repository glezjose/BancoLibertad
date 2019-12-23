using System;
using System.Collections.Generic;
using System.Text;

namespace BancoLibertad.CuentaBancaria
{
    public class Normal : CuentaBancaria
    {
        public override int RegistrarCuenta()
        {
            int iIdCuenta;
            Cliente.Normal oNormal = new Cliente.Normal();
            try
            {
                Console.Write("Por favor ingrese su nombre: ");
                oNormal.cNombre = Console.ReadLine();

                Console.Write("Por favor ingrese su apellido: ");
                oNormal.cApellido = Console.ReadLine();

                Console.Write("Por favor ingrese el Nombre de su empresa: ");
                oNormal.cEmpresa = Console.ReadLine();

                Console.Write("Por favor ingrese un NIP para su cuenta: ");
                oNormal.iNIP = Convert.ToInt32(Console.ReadLine());

                if (_lstNormal == null)
                {
                    _lstNormal = new List<Cliente.Normal>();
                    oNormal.iIdClienteNormal = 0;
                    iIdCuenta = 0;
                }
                else
                {
                    oNormal.iIdClienteNormal = _lstNormal.Count;
                    iIdCuenta = _lstNormal.Count;
                }

                oNormal.dSaldo = 0;

                _lstNormal.Add(oNormal);

                Console.Clear();
                Console.WriteLine("Bienvenido, " + oNormal.cNombre + ".\n");
                Console.WriteLine("Su numero de cuenta es: " + oNormal.iIdClienteNormal);
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
                Console.WriteLine("Por favor ingrese su número de cuenta: ");
                iIdCuenta = Convert.ToInt32(Console.ReadLine());
                try
                {
                    if (iIdCuenta == _lstNormal[iIdCuenta].iIdClienteNormal)
                    {
                        Console.WriteLine("Por favor ingrese su NIP: ");
                        int iNIP = Convert.ToInt32(Console.ReadLine());
                        if (iNIP != _lstNormal[iIdCuenta].iNIP)
                        {
                            Console.WriteLine("El NIP ingresado es incorrecto.");
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("Bienvenido, " + _lstNormal[iIdCuenta].cNombre + ".\n");
                        }
                    }
                }
                catch (ArgumentOutOfRangeException)
                {
                    Console.WriteLine("No existe este número de cuenta.");
                    iIdCuenta = -1;
                }

            }
            catch (FormatException)
            {
                Console.WriteLine("Por favor ingrese un número válido.");
                iIdCuenta = -1;
            }
            return iIdCuenta;
        }
        public override void Retirar(int iIdCuenta, decimal dMonto)
        {
            if(_lstNormal[iIdCuenta].dSaldo >= dMonto)
            {
                _lstNormal[iIdCuenta].dSaldo -= dMonto;
                Console.WriteLine("Transacción exitosa!\nSe ha retirado: $" + dMonto + ".");
            }
            else
            {
                Console.WriteLine("Usted no cuenta con el saldo suficiente para realizar esta transacción.");
            }
        }

        public override int ValidarNumeroCuenta()
        {
            int iIdCuenta;
            Console.Write("Por favor indique el número de cuenta: ");
            iIdCuenta = Convert.ToInt32(Console.ReadLine());
            try
            {
                if (iIdCuenta == _lstNormal[iIdCuenta].iIdClienteNormal)
                {
                    Console.WriteLine("El número de cuenta ingresado le pertenece a, " + _lstNormal[iIdCuenta].cNombre + " " + _lstNormal[iIdCuenta].cApellido + ".");
                }
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.WriteLine("No existe este número de cuenta.");
                iIdCuenta = -1;
            }
            return iIdCuenta;
        }
    }
}

