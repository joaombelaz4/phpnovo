<?php
require_once 'Conta.php';
class ContaCorrente extends Conta
{
    public function depositar(float $valor): void
    {
        if ($valor <= 0) {
            throw new Exception("O valor do depósito deve ser positivo.");
        }

       
        $valorComTaxa = $valor * 0.99;
        $this->saldo += $valorComTaxa;
    }

    public function sacar(float $valor): void
    {
        if ($valor <= 0) {
            throw new Exception("O valor do saque deve ser positivo.");
        }

        $valorComTaxa = $valor * 1.01;
        
        if ($valorComTaxa > $this->saldo) {
            throw new Exception("Saldo insuficiente para o saque.");
        }

        $this->saldo -= $valorComTaxa;
    }

    public function __toString(): string
    {
        return "Conta Corrente - " . parent::__toString();
    }
}

?>