﻿using System;
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
            
        }
    }
}
