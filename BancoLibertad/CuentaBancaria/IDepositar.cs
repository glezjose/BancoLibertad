using System;
using System.Collections.Generic;
using System.Text;

namespace BancoLibertad.CuentaBancaria
{
    public interface IDepositar
    {
        void Depositar(int iIdCuentaDeposito, int iTipoCuenta, decimal dMonto, string cConcepto);

        void Depositar(int iIdCuenta, int iTipoCuenta, decimal dMonto);
    }
}
