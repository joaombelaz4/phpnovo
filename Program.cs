using System;

namespace SistemaBancario
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Conta> contas = new List<Conta>();

            while (true)
            {
                Console.WriteLine("Sistema Bancário");
                Console.WriteLine("1. Criar Conta Corrente");
                Console.WriteLine("2. Criar Conta Poupança");
                Console.WriteLine("3. Listar Contas");
                Console.WriteLine("4. Depositar");
                Console.WriteLine("5. Sacar");
                Console.WriteLine("6. Transferir");
                Console.WriteLine("7. Sair");
                Console.Write("Escolha uma opção: ");
                string opcao = Console.ReadLine();

            inicioSistema:
                try
                {
                    switch (opcao)
                    {
                        case "1":
                            CriarConta("1");
                            PressioneEnterParaContinuar();
                            break;
                        case "2":
                            CriarConta("2");
                            PressioneEnterParaContinuar();
                            break;
                        case "3":
                            ListarContas();
                            PressioneEnterParaContinuar();
                            break;
                        case "4":
                            RealizarDeposito();
                            PressioneEnterParaContinuar();
                            break;
                        case "5":
                            RealizarSaque();
                            PressioneEnterParaContinuar();
                            break;
                        case "6":
                            RealizarTransferencia();
                            PressioneEnterParaContinuar();
                            break;
                        case "7":
                            return;
                        default:
                            Console.WriteLine("Opção inválida.");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Erro: {ex.Message}");
                    PressioneEnterParaContinuar();
                    Console.ReadLine();
                    goto inicioSistema;
                }
            }

            void CriarConta(string tipo)
            {

                int numero = contas.Count + 1;

                Console.Write("Digite o nome do titular: ");
                string nome = Console.ReadLine();

                Console.Write("Digite o CPF do titular (apenas números): ");
                string cpf = Console.ReadLine();

                Console.Write("Digite o endereço do titular: ");
                string endereco = Console.ReadLine();

                Titular titular = new Titular(nome, cpf, endereco);

                if (tipo == "1")
                    contas.Add(new ContaCorrente(numero, titular));
                else if (tipo == "2")
                    contas.Add(new ContaPoupanca(numero, titular));
                else
                {
                    Console.WriteLine("Tipo de conta inválido.");
                    return;
                }

                Console.WriteLine("Conta criada com sucesso!");
            }

            void ListarContas()
            {
                if (contas.Count == 0)
                {
                    Console.WriteLine("Nenhuma conta cadastrada.");
                    return;
                }

                foreach (var conta in contas)
                {
                    Console.WriteLine(conta);
                }
            }

            void RealizarDeposito()
            {
                Console.Write("Digite o número da conta: ");
                int numeroConta = int.Parse(Console.ReadLine());

                Conta conta = contas.Find(c => c.getNumero() == numeroConta);
                if (conta == null)
                {
                    Console.WriteLine("Conta não encontrada.");
                    return;
                }

                Console.Write("Digite o valor do depósito: ");
                decimal valor = decimal.Parse(Console.ReadLine());

                conta.Depositar(valor);
                Console.WriteLine("Depósito realizado com sucesso!");
            }

            void RealizarSaque()
            {
                Console.Write("Digite o número da conta: ");
                int numeroConta = int.Parse(Console.ReadLine());

                Conta conta = contas.Find(c => c.getNumero() == numeroConta);
                if (conta == null)
                {
                    Console.WriteLine("Conta não encontrada.");
                    return;
                }

                Console.Write("Digite o valor do saque: ");
                decimal valor = decimal.Parse(Console.ReadLine());

                conta.Sacar(valor);
                Console.WriteLine("Saque realizado com sucesso!");
            }

            void RealizarTransferencia()
            {
                Console.Write("Digite o número da conta de origem: ");
                int numeroContaOrigem = int.Parse(Console.ReadLine());

                Conta contaOrigem = contas.Find(c => c.getNumero() == numeroContaOrigem);
                if (contaOrigem == null)
                {
                    Console.WriteLine("Conta de origem não encontrada.");
                    return;
                }

                Console.Write("Digite o número da conta de destino: ");
                int numeroContaDestino = int.Parse(Console.ReadLine());

                Conta contaDestino = contas.Find(c => c.getNumero() == numeroContaDestino);
                if (contaDestino == null)
                {
                    Console.WriteLine("Conta de destino não encontrada.");
                    return;
                }

                Console.Write("Digite o valor da transferência: ");
                decimal valor = decimal.Parse(Console.ReadLine());

                contaOrigem.Transferir(contaDestino, valor);
                Console.WriteLine("Transferência realizada com sucesso!");
            }

            void PressioneEnterParaContinuar()
            {
                Console.WriteLine("Pressione Enter para continuar...");
                Console.ReadLine();
            }
        }
    }
}