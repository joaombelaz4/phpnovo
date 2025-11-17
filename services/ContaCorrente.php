<?php

class ContaCorrente extends Conta
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

        $this->saldo = $this->saldo + ($valor * 0.99);
    }

    public function sacar($valor)
    {
        $valorComTaxa = $valor * 1.01;
        
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
        return "Conta Corrente - " . parent::__toString();
    }
}

?>