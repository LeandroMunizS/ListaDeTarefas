using System;
using System.Collections.Generic;
using System.IO;

namespace GerenciadorDeTarefas
{
    class Program
    {
        static List<string> tarefas = new List<string>();
        const string arquivoTarefas = "tarefas.txt";

        static void Main(string[] args)
        {
            CarregarTarefas();

            Console.WriteLine("Bem-vindo ao Gerenciador de Tarefas!");
            bool continuar = true;

            while (continuar)
            {
                Console.WriteLine("\nEscolha uma opção:");
                Console.WriteLine("1. Adicionar tarefa");
                Console.WriteLine("2. Listar tarefas");
                Console.WriteLine("3. Marcar tarefa como concluída");
                Console.WriteLine("4. Sair");

                int opcao = int.Parse(Console.ReadLine());

                switch (opcao)
                {
                    case 1:
                        AdicionarTarefa();
                        break;
                    case 2:
                        ListarTarefas();
                        break;
                    case 3:
                        MarcarTarefaConcluida();
                        break;
                    case 4:
                        continuar = false;
                        break;
                    default:
                        Console.WriteLine("Opção inválida. Tente novamente.");
                        break;
                }
            }

            SalvarTarefas();
            Console.WriteLine("Obrigado por usar o Gerenciador de Tarefas!");
        }

        static void AdicionarTarefa()
        {
            Console.Write("Digite a descrição da tarefa: ");
            string descricao = Console.ReadLine();
            tarefas.Add(descricao);
            Console.WriteLine("Tarefa adicionada com sucesso!");
        }

        static void ListarTarefas()
        {
            Console.WriteLine("\nLista de tarefas:");
            for (int i = 0; i < tarefas.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {tarefas[i]}");
            }
        }

        static void MarcarTarefaConcluida()
        {
            Console.Write("Digite o número da tarefa concluída: ");
            int indice = int.Parse(Console.ReadLine()) - 1;

            if (indice >= 0 && indice < tarefas.Count)
            {
                Console.WriteLine($"Tarefa '{tarefas[indice]}' marcada como concluída!");
                tarefas.RemoveAt(indice);
            }
            else
            {
                Console.WriteLine("Tarefa não encontrada. Verifique o número digitado.");
            }
        }

        static void CarregarTarefas()
        {
            if (File.Exists(arquivoTarefas))
            {
                tarefas = new List<string>(File.ReadAllLines(arquivoTarefas));
            }
        }

        static void SalvarTarefas()
        {
            File.WriteAllLines(arquivoTarefas, tarefas);
        }
    }
}
