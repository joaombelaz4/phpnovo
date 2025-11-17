<?php

class Titular
{
    private $nome;
    private $cpf;
    private $endereco;

    public function __construct($nome = null, $cpf = null, $endereco = null)
    {
        if ($nome != null && $cpf != null && $endereco != null) {
            $this->setNome($nome);
            $this->setCpf($cpf);
            $this->setEndereco($endereco);
        }
    }

    public function setNome($nome)
    {
        if (strlen(trim($nome)) < 3) {
            throw new Exception("O nome do titular deve ter pelo menos 3 caracteres.");
        }

        if (preg_match('/[0-9]/', $nome)) {
            throw new Exception("O nome do titular não pode conter números.");
        }

        $this->nome = $nome;
    }

    public function setCpf($cpf)
    {
        if (strlen($cpf) != 11 || !is_numeric($cpf)) {
            throw new Exception("O CPF deve conter exatamente 11 dígitos numéricos.");
        }

        $this->cpf = $cpf;
    }

    public function setEndereco($endereco)
    {
        if (trim($endereco) == "") {
            throw new Exception("O endereço não pode ser vazio.");
        }

        $this->endereco = $endereco;
    }

    public function getNome()
    {
        return $this->nome;
    }

    public function getCpf()
    {
        return $this->cpf;
    }

    public function getEndereco()
    {
        return $this->endereco;
    }

    public function __toString()
    {
        return "Nome: " . $this->nome . ", CPF: " . $this->cpf . ", Endereço: " . $this->endereco;
    }
}

?>