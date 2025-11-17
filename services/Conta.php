<?php

abstract class Conta
{
    protected $numero;
    protected $titular;
    protected $saldo;

    public function __construct($numero = null, $titular = null)
    {
        if ($numero != null && $titular != null) {
            $this->setNumero($numero);
            $this->setTitular($titular);
            $this->saldo = 0;
        }
    }

    public function setNumero($numero)
    {
        if ($numero <= 0) {
            throw new Exception("O número da conta deve ser positivo.");
        }
        $this->numero = $numero;
    }

    public function setTitular($titular)
    {
        if ($titular == null) {
            throw new Exception("O titular da conta não pode ser nulo.");
        }
        $this->titular = $titular;
    }

    public function getNumero()
    {
        return $this->numero;
    }

    public function getTitular()
    {
        return $this->titular;
    }

    public function getSaldo()
    {
        return $this->saldo;
    }

    abstract public function depositar($valor);
    
    abstract public function sacar($valor);

    public function __toString()
    {
        return "Conta Número: " . $this->numero . ", Titular: " . $this->titular->getNome() . ", Saldo: R$ " . number_format($this->saldo, 2, ',', '.');
    }

    public function transferir($contaDestino, $valor)
    {
        if ($contaDestino == null) {
            throw new Exception("A conta de destino não pode ser nula.");
        }

        $this->sacar($valor);
        $contaDestino->depositar($valor);
    }
}

?>