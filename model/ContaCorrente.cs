using System;

namespace SistemaBancario
{
    public class ContaCorrente: Conta
    {
        public ContaCorrente(int numero, Titular titular) : base(numero, titular)
        {
        }
        public ContaCorrente()
        {
        }
        public override void Depositar(decimal valor)
        {
            if (valor <= 0)
                throw new ArgumentException("O valor do depósito deve ser positivo.");

            saldo += valor * 0.99m; // Taxa de depósito de 1%
        }

        public override void Sacar(decimal valor)
        {
            decimal valorComTaxa = valor * 1.01m; // Taxa de saque de 1%
            if (valor <= 0)
                throw new ArgumentException("O valor do saque deve ser positivo.");
            if (valorComTaxa > saldo)
                throw new InvalidOperationException("Saldo insuficiente para o saque.");

            saldo -= valorComTaxa;
        }

        public override string ToString()
        {
            return $"Conta Corrente - {base.ToString()}";
        }
    }
}