using System;

namespace SistemaBancario
{
    public class ContaPoupanca : Conta
    {
        public ContaPoupanca(int numero, Titular titular) : base(numero, titular)
        {
        }
        public ContaPoupanca()
        {
        }
        public override void Depositar(decimal valor)
        {
            if (valor <= 0)
                throw new ArgumentException("O valor do depósito deve ser positivo.");

            this.saldo += valor;
        }

        public override void Sacar(decimal valor)
        {
            decimal valorComTaxa = valor * 1.005m; // Taxa de saque de 0.5%
            if (valor <= 0)
                throw new ArgumentException("O valor do saque deve ser positivo.");
            if (valorComTaxa > saldo)
                throw new InvalidOperationException("Saldo insuficiente para o saque.");

            saldo -= valorComTaxa;
        }

        public override string ToString()
        {
             return $"Conta Poupança - {base.ToString()}";
        }
    }
}