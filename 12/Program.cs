using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    const string arquivoContatos = "contatos.txt";

    static void Main()
    {
        int opcao;
        do
        {
            Console.Clear();
            Console.WriteLine("=== Gerenciador de Contatos ===");
            Console.WriteLine("1 - Adicionar novo contato");
            Console.WriteLine("2 - Listar contatos cadastrados");
            Console.WriteLine("3 - Sair");
            Console.Write("Escolha uma opção: ");

            if (!int.TryParse(Console.ReadLine(), out opcao))
            {
                Console.WriteLine("Opção inválida. Pressione qualquer tecla para continuar...");
                Console.ReadKey();
                continue;
            }

            switch (opcao)
            {
                case 1:
                    AdicionarContato();
                    break;
                case 2:
                    ListarContatos();
                    break;
                case 3:
                    Console.WriteLine("Encerrando programa...");
                    break;
                default:
                    Console.WriteLine("Opção inválida. Pressione qualquer tecla para continuar...");
                    Console.ReadKey();
                    break;
            }

        } while (opcao != 3);
    }

    static void AdicionarContato()
    {
        Console.Clear();
        Console.WriteLine("=== Adicionar Novo Contato ===");

        Console.Write("Nome: ");
        string nome = Console.ReadLine();

        Console.Write("Telefone: ");
        string telefone = Console.ReadLine();

        Console.Write("Email: ");
        string email = Console.ReadLine();

        try
        {
            using (StreamWriter sw = new StreamWriter(arquivoContatos, append: true))
            {
                sw.WriteLine($"{nome},{telefone},{email}");
            }

            Console.WriteLine("\nContato cadastrado com sucesso!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro ao salvar o contato: {ex.Message}");
        }

        Console.WriteLine("\nPressione qualquer tecla para voltar ao menu...");
        Console.ReadKey();
    }

    static void ListarContatos()
    {
        Console.Clear();
        Console.WriteLine("=== Formato de Exibição ===");
        Console.WriteLine("1 - Markdown");
        Console.WriteLine("2 - Tabela");
        Console.WriteLine("3 - Texto Puro");
        Console.Write("Escolha um formato: ");

        string entrada = Console.ReadLine();
        ContatoFormatter formatter = entrada switch
        {
            "1" => new MarkdownFormatter(),
            "2" => new TabelaFormatter(),
            "3" => new RawTextFormatter(),
            _ => null
        };

        if (formatter == null)
        {
            Console.WriteLine("Formato inválido.");
            Console.ReadKey();
            return;
        }

        try
        {
            if (!File.Exists(arquivoContatos) || new FileInfo(arquivoContatos).Length == 0)
            {
                Console.WriteLine("\nNenhum contato cadastrado.");
            }
            else
            {
                List<Contato> contatos = new List<Contato>();

                using (StreamReader sr = new StreamReader(arquivoContatos))
                {
                    string linha;
                    while ((linha = sr.ReadLine()) != null)
                    {
                        var partes = linha.Split(',');
                        if (partes.Length == 3)
                        {
                            contatos.Add(new Contato(partes[0], partes[1], partes[2]));
                        }
                    }
                }

                Console.WriteLine();
                formatter.ExibirContatos(contatos);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro ao ler os contatos: {ex.Message}");
        }

        Console.WriteLine("\nPressione qualquer tecla para voltar ao menu...");
        Console.ReadKey();
    }
}