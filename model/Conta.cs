using System;

namespace SistemaBancario
{
    public abstract class Conta
    {
        protected int numero;
        protected Titular titular;
        protected decimal saldo;

        public Conta(int numero, Titular titular)
        {
            setNumero(numero);
            setTitular(titular);
            this.saldo = 0;
        }

        public Conta()
        {
        }

        public void setNumero(int numero)
        {
            if (numero <= 0)
            {
                throw new ArgumentException("O número da conta deve ser positivo.");
            }
            this.numero = numero;
        }

        public void setTitular(Titular titular)
        {
            if (titular == null)
            {
                throw new ArgumentException("O titular da conta não pode ser nulo.");
            }
            this.titular = titular;
        }

        public int getNumero()
        {
            return numero;
        }
        public Titular getTitular()
        {
            return titular;
        }

        public decimal getSaldo()
        {
            return saldo;
        }

        public abstract void Depositar(decimal valor);
        public abstract void Sacar(decimal valor);
        public override string ToString()
        {
            return $"Conta Número: {numero}, Titular: {titular.getNome()}, Saldo: {saldo:C}";
        }

        public void Transferir(Conta contaDestino, decimal valor)
        {
            if (contaDestino == null)
            {
                throw new ArgumentException("A conta de destino não pode ser nula.");
            }

            this.Sacar(valor);
            contaDestino.Depositar(valor);
        }
        
    }
}