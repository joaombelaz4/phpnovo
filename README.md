# POO — Sistema Bancário (exemplo)

Projeto didático em C# que demonstra conceitos básicos de Programação Orientada a Objetos (POO): classes, encapsulamento, herança, polimorfismo e abstração.

## Visão Geral
Este pequeno sistema permite criar contas (corrente e poupança), listar contas, depositar, sacar e transferir valores via interface de console.

- Executável principal: [Program.cs](Program.cs) — contém a interação com o usuário e fluxo da aplicação.
- Projeto .NET: [POO-sistema-bancario.csproj](POO-sistema-bancario.csproj)
- Solução: [POO-sistema-bancario.sln](POO-sistema-bancario.sln)

## Conceitos de POO demonstrados
- Abstração: a classe abstrata [`SistemaBancario.Conta`](model/Conta.cs) define a interface comum de contas.
  - [`SistemaBancario.Conta`](model/Conta.cs)
- Herança: contas específicas estendem a classe abstrata:
  - [`SistemaBancario.ContaCorrente`](model/ContaCorrente.cs)
  - [`SistemaBancario.ContaPoupanca`](model/ContaPoupanca.cs)
- Encapsulamento: atributos protegidos e métodos públicos para acesso (ex.: `getSaldo`, `getNumero`, setters com validação).
  - [`SistemaBancario.Titular`](model/Titular.cs) — valida nome, CPF e endereço.
- Polimorfismo: métodos abstratos `Depositar` e `Sacar` implementados diferentemente em cada tipo de conta.

## Estrutura de arquivos
- [Program.cs](Program.cs) — ponto de entrada, menu de operações e exemplos de uso.
- model/
  - [Conta.cs](model/Conta.cs) — classe abstrata base e lógica de transferência.
  - [ContaCorrente.cs](model/ContaCorrente.cs) — implementação de conta corrente (taxas aplicadas).
  - [ContaPoupanca.cs](model/ContaPoupanca.cs) — implementação de conta poupança (taxas diferentes).
  - [Titular.cs](model/Titular.cs) — dados do titular com validações.

## Como executar
Pré-requisitos: .NET 9 SDK instalado.

No diretório do projeto, executar:

```bash
# Restaurar e executar
dotnet build
dotnet run