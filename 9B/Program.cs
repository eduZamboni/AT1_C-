using System;
using System.IO;

public class Produto
{
    public string Nome;
    public int Quantidade;
    public decimal Preco;

    public override string ToString()
    {
        return $"{Nome},{Quantidade},{Preco.ToString("F2")}";
    }

    public static Produto FromCsv(string linha)
    {
        string[] partes = linha.Split(',');
        return new Produto
        {
            Nome = partes[0],
            Quantidade = int.Parse(partes[1]),
            Preco = decimal.Parse(partes[2])
        };
    }
}

class EstoqueArquivo
{
    const string arquivo = "estoque.txt";

    static void Main()
    {
        string opcao;

        do
        {
            Console.WriteLine("\n----- Menu Estoque -----");
            Console.WriteLine("1 - Inserir Produto");
            Console.WriteLine("2 - Listar Produtos");
            Console.WriteLine("3 - Sair");
            Console.Write("Escolha uma opção: ");
            opcao = Console.ReadLine();

            if (opcao == "1")
            {
                int produtosAtuais = ContarLinhas();
                if (produtosAtuais >= 5)
                {
                    Console.WriteLine("Limite de produtos atingido!");
                    continue;
                }

                Produto p = new Produto();

                Console.Write("Nome do produto: ");
                p.Nome = Console.ReadLine();

                Console.Write("Quantidade: ");
                int.TryParse(Console.ReadLine(), out p.Quantidade);

                Console.Write("Preço unitário: ");
                decimal.TryParse(Console.ReadLine(), out p.Preco);

                try
                {
                    using (StreamWriter sw = File.AppendText(arquivo))
                    {
                        sw.WriteLine(p.ToString());
                    }
                    Console.WriteLine("Produto salvo com sucesso!");
                }
                catch
                {
                    Console.WriteLine("Erro ao salvar o produto.");
                }
            }
            else if (opcao == "2")
            {
                Console.WriteLine("\n----- Produtos Cadastrados -----");

                if (!File.Exists(arquivo) || new FileInfo(arquivo).Length == 0)
                {
                    Console.WriteLine("Nenhum produto cadastrado.");
                    continue;
                }

                try
                {
                    string[] linhas = File.ReadAllLines(arquivo);
                    foreach (string linha in linhas)
                    {
                        Produto p = Produto.FromCsv(linha);
                        Console.WriteLine($"Produto: {p.Nome} | Quantidade: {p.Quantidade} | Preço: R$ {p.Preco:F2}");
                    }
                }
                catch
                {
                    Console.WriteLine("Erro ao ler o arquivo.");
                }
            }

        } while (opcao != "3");

        Console.WriteLine("Programa encerrado.");
    }

    static int ContarLinhas()
    {
        if (!File.Exists(arquivo)) return 0;
        return File.ReadAllLines(arquivo).Length;
    }
}