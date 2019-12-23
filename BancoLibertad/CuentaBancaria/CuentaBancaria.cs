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
        /// <returns>Regresa la ID de la cuenta.</returns>
        public abstract int RegistrarCuenta();

        /// <summary>
        /// Método abstracto para ingresar a una cuenta.
        /// </summary>
        /// <returns>Regresa la ID de la cuenta.</returns>
        public abstract int IngresarCuenta();

        /// <summary>
        /// Método abstracto para validar el número de cuenta a depositar.
        /// </summary>
        /// <returns></returns>
        public abstract int ValidarNumeroCuenta();

        /// <summary>
        /// Método para consultar saldo de alguna cuenta.
        /// </summary>
        /// <param name="dSaldo"></param>
        /// <returns>Regresa una cadena con el saldo.</returns>
        public string ConsultarSaldo(decimal dSaldo) {
            return "\nSu saldo es: " + dSaldo + ".";
        }

        /// <summary>
        /// Método para obtener el concepto del depósito.
        /// </summary>
        /// <returns>Regresa el concepto en cadena.</returns>
        public string ObtenerConcepto()
        {
            Console.WriteLine("\nIngrese el concepto del depósito: ");
            return Console.ReadLine();
        }

        /// <summary>
        /// Método que se usa para obtener el monto a depositar.
        /// </summary>
        /// <returns>Regresa el monto a depositar.</returns>
        public decimal MontoDepositar()
        {
            Console.WriteLine("\nIngrese el monto a depositar: ");
            return Convert.ToInt32(Console.ReadLine());
        }

        /// <summary>
        /// Método que se utiliza para depositar a otra cuenta.
        /// </summary>
        /// <param name="iIdCuentaDeposito">La ID de la cuenta a depositar</param>
        /// <param name="iTipoCuenta">El tipo de cuenta(1: Normal, 2: Universitaria)</param>
        /// <param name="dMonto">El monto a depositar</param>
        /// <param name="cConcepto">El concepto del deposito</param>
        public void Depositar(int iIdCuentaDepositoM, int iTipoCuenta, decimal dMonto, string cConcepto) { }
       
        /// <summary>
        /// Método que se utiliza para depositar a la misma cuenta.
        /// </summary>
        /// <param name="iIdCuenta">La ID de la cuenta personal.</param>
        /// <param name="iTipoCuenta">El tipo de cuenta.</param>
        /// <param name="dMonto">El monto a depositar.</param>
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
