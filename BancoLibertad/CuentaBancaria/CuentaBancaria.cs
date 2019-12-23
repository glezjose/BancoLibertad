using System;
using System.Collections.Generic;

namespace BancoLibertad.CuentaBancaria
{
    public abstract class CuentaBancaria: IDepositar
    {
        public List<Cliente.Universitario> _lstUniversitarios;
        public List<Cliente.Normal> _lstNormal;

        public abstract void Retirar(int iIdCuenta, decimal dMonto);

        public abstract int RegistrarCuenta();

        public abstract int IngresarCuenta();

        public abstract int ValidarNumeroCuenta();

        public string ConsultarSaldo(decimal dSaldo) {
            return "Su saldo es: " + dSaldo + ".";
        }

        public string ObtenerConcepto()
        {
            Console.WriteLine("Ingrese el concepto del depósito: ");

            return Console.ReadLine();
        }

        public void Depositar(int iIdCuenta, decimal dMonto)
        {
        }

        public void Depositar(decimal dMonto)
        {
            throw new NotImplementedException();
        }
    }
}
