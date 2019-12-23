using System;
using System.Collections.Generic;

namespace BancoLibertad.CuentaBancaria
{
    public abstract class CuentaBancaria: IDepositar
    {
        /// <summary>
        /// Lista declarada para los clientes con cuentas universitarias.
        /// </summary>
        public List<Cliente.Universitario> _lstUniversitarios;
        /// <summary>
        /// Lista declarada para los clientes con cuentas normales.
        /// </summary>
        public List<Cliente.Normal> _lstNormal;

        /// <summary>
        /// Método abstracto para retirar fondos de una cuenta.
        /// </summary>
        /// <param name="iIdCuenta">La ID de la cuenta que se desea retirar fondos.</param>
        /// <param name="dMonto">El monto a retirar.</param>
        public abstract void Retirar(int iIdCuenta, decimal dMonto);

        /// <summary>
        /// Método abstracto para registrar una cuenta nueva.
        /// </summary>
        /// <returns></returns>
        public abstract int RegistrarCuenta();

        /// <summary>
        /// Método abstracto para ingresar a una cuenta.
        /// </summary>
        /// <returns></returns>
        public abstract int IngresarCuenta();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public abstract int ValidarNumeroCuenta();

        public string ConsultarSaldo(decimal dSaldo) {
            return "\nSu saldo es: " + dSaldo + ".";
        }

        public string ObtenerConcepto()
        {
            Console.WriteLine("\nIngrese el concepto del depósito: ");
            return Console.ReadLine();
        }
        public decimal MontoDepositar()
        {
            Console.WriteLine("\nIngrese el monto a depositar: ");
            return Convert.ToInt32(Console.ReadLine());
        }


        public void Depositar(int iIdCuentaDeposito, int iTipoCuenta, decimal dMonto, string cConcepto) { }
       

        public void Depositar(int iIdCuenta, int iTipoCuenta, decimal dMonto)
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
