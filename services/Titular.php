<?php

class Titular
{
    private string $nome;
    private string $cpf;
    private string $endereco;

    public function __construct(string $nome, string $cpf, string $endereco)
    {
        $this->setNome($nome);
        $this->setCpf($cpf);
        $this->setEndereco($endereco);
    }

    public function setNome(string $nome): void
    {
        $trimmedNome = trim($nome);
        if (strlen($trimmedNome) < 3) {
            throw new Exception("O nome do titular deve ter pelo menos 3 caracteres.");
        }

        if (preg_match('/\d/', $trimmedNome)) {
            throw new Exception("O nome do titular não pode conter números.");
        }

        $this->nome = $trimmedNome;
    }

    public function setCpf(string $cpf): void
    {
        if (strlen($cpf) !== 11 || !ctype_digit($cpf)) {
            throw new Exception("O CPF deve conter exatamente 11 dígitos numéricos.");
        }

        $this->cpf = $cpf;
    }

    public function setEndereco(string $endereco): void
    {
        $trimmedEndereco = trim($endereco);
        if ($trimmedEndereco === "") {
            throw new Exception("O endereço não pode ser vazio.");
        }

        $this->endereco = $trimmedEndereco;
    }

    public function getNome(): string
    {
        return $this->nome;
    }

    public function getCpf(): string
    {
        return $this->cpf;
    }

    public function getEndereco(): string
    {
        return $this->endereco;
    }

    public function __toString(): string
    {
        return sprintf(
            "Nome: %s, CPF: %s, Endereço: %s",
            $this->nome,
            $this->cpf,
            $this->endereco
        );
    }
}

?>