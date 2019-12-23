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
                Console.Write("Ingrese su Nombre: ");
                oNormal.cNombre = Console.ReadLine();

                Console.Write("Ingrese su Apellido: ");
                oNormal.cApellido = Console.ReadLine();

                Console.Write("Ingrese el Nombre de su Empresa: ");
                oNormal.cEmpresa = Console.ReadLine();

                Console.Write("Ingrese un NIP para su cuenta: ");
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
                Console.WriteLine("\nBienvenido, " + oNormal.cNombre + ".\n");
                Console.WriteLine("\nSu numero de cuenta es: " + oNormal.iIdClienteNormal+ "\n");
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
                    if (iIdCuenta == _lstNormal[iIdCuenta].iIdClienteNormal)
                    {
                        Console.WriteLine("Digite su NIP: ");
                        int iNIP = Convert.ToInt32(Console.ReadLine());
                        if (iNIP != _lstNormal[iIdCuenta].iNIP)
                        {
                            Console.WriteLine("\nEl NIP ingresado es incorrecto,redirigiendo al menú principal...\n");
                            iIdCuenta = -1;

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
            if(_lstNormal[iIdCuenta].dSaldo >= dMonto)
            {
                _lstNormal[iIdCuenta].dSaldo -= dMonto;
                Console.WriteLine("Transacción exitosa!\nSe ha retirado: $" + dMonto + ".");
            }
            else
            {
                Console.WriteLine("\nUsted no cuenta con el saldo suficiente para realizar esta transacción.");
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
                    Console.WriteLine("\nEl número de cuenta ingresado le pertenece a, " + _lstNormal[iIdCuenta].cNombre + " " + _lstNormal[iIdCuenta].cApellido + ".");
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
            if (iTipoCuenta==1)
            {
                _lstNormal[iIdCuentaDeposito].dSaldo += dMonto;
                Console.WriteLine("\n\nSe a depositado con exito: $"+dMonto+" a la cuenta de "+ _lstNormal[iIdCuentaDeposito].cNombre+" "+ _lstNormal[iIdCuentaDeposito].cApellido+" por concepto de "+cConcepto);
            }
            else if (iTipoCuenta==2)
            {
                _lstUniversitarios[iIdCuentaDeposito].dSaldo += dMonto;
                Console.WriteLine("\n\nSe a depositado con exito: $" + dMonto + " a la cuenta universitaria de " + _lstNormal[iIdCuentaDeposito].cNombre + " " + _lstNormal[iIdCuentaDeposito].cApellido + " por concepto de " + cConcepto);
            }
        }
    }
}

