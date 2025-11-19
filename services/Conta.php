<?php
require_once 'Titular.php';
abstract class Conta
{
    protected int $numero;
    protected Titular $titular;
    protected float $saldo;

    public function __construct(int $numero, Titular $titular)
    {
        $this->setNumero($numero);
        $this->titular = $titular;
        $this->saldo = 0.0;
    }

    public function setNumero(int $numero): void
    {
        if ($numero <= 0) {
            throw new Exception("O número da conta deve ser positivo.");
        }
        $this->numero = $numero;
    }

    public function getNumero(): int
    {
        return $this->numero;
    }

    public function getTitular(): Titular
    {
        return $this->titular;
    }

    public function getSaldo(): float
    {
        return $this->saldo;
    }

    abstract public function depositar(float $valor): void;
    
    abstract public function sacar(float $valor): void;

    public function __toString(): string
    {
        return sprintf(
            "Conta Número: %d, Titular: %s, Saldo: R$ %.2f",
            $this->numero,
            $this->titular->getNome(),
            $this->saldo
        );
    }

    public function transferir(Conta $contaDestino, float $valor): void
    {
        if ($valor <= 0) {
            throw new Exception("O valor da transferência deve ser positivo.");
        }

        if ($contaDestino === $this) {
            throw new Exception("Não é possível transferir para a mesma conta.");
        }


        $this->sacar($valor);
        $contaDestino->depositar($valor);
    }
}

?>