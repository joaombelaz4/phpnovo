using System;

namespace SistemaBancario
{
    public class Titular
    {
        private string nome;
        private string cpf;
        private string endereco;

        public Titular(string nome, string cpf, string endereco)
        {
            setNome(nome);
            setCpf(cpf);
            setEndereco(endereco);
        }
        
        public Titular()
        {
        }

        public void setNome(string nome)
        {
            if (nome.Trim().Length < 3)
            {
                throw new ArgumentException("O nome do titular deve ter pelo menos 3 caracteres.");
            }

            if (nome.Any(char.IsDigit))
            {
                throw new ArgumentException("O nome do titular não pode conter números.");
            }

            this.nome = nome;
        }

        public void setCpf(string cpf)
        {
            if (cpf.Length != 11 || !cpf.All(char.IsDigit))
            {
                throw new ArgumentException("O CPF deve conter exatamente 11 dígitos numéricos.");
            }

            this.cpf = cpf;
        }

        public void setEndereco(string endereco)
        {
            if (string.IsNullOrWhiteSpace(endereco))
            {
                throw new ArgumentException("O endereço não pode ser vazio.");
            }

            this.endereco = endereco;
        }

        public string getNome()
        {
            return nome;
        }
        public string getCpf()
        {
            return cpf;
        }
        public string getEndereco()
        {
            return endereco;
        }

        public override string ToString()
        {
            return $"Nome: {nome}, CPF: {cpf}, Endereço: {endereco}";
        }
    }
}