<?php
require_once 'Conta.php';
class ContaPoupanca extends Conta
{
    public function depositar(float $valor): void
    {
        if ($valor <= 0) {
            throw new Exception("O valor do depósito deve ser positivo.");
        }

        $this->saldo += $valor;
    }

    public function sacar(float $valor): void
    {
        if ($valor <= 0) {
            throw new Exception("O valor do saque deve ser positivo.");
        }

        $valorComTaxa = $valor * 1.005;
        
        if ($valorComTaxa > $this->saldo) {
            throw new Exception("Saldo insuficiente para o saque.");
        }

        $this->saldo -= $valorComTaxa;
    }

    public function __toString(): string
    {
        return "Conta Poupança - " . parent::__toString();
    }
}

?>