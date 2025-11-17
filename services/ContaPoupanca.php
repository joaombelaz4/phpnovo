<?php

class ContaPoupanca extends Conta
{
    public function __construct($numero = null, $titular = null)
    {
        parent::__construct($numero, $titular);
    }

    public function depositar($valor)
    {
        if ($valor <= 0) {
            throw new Exception("O valor do depósito deve ser positivo.");
        }

        $this->saldo = $this->saldo + $valor;
    }

    public function sacar($valor)
    {
        $valorComTaxa = $valor * 1.005;
        
        if ($valor <= 0) {
            throw new Exception("O valor do saque deve ser positivo.");
        }
        
        if ($valorComTaxa > $this->saldo) {
            throw new Exception("Saldo insuficiente para o saque.");
        }

        $this->saldo = $this->saldo - $valorComTaxa;
    }

    public function __toString()
    {
        return "Conta Poupança - " . parent::__toString();
    }
}

?>