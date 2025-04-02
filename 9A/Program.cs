using System;

public class Produto
{
    public string Nome;
    public int Quantidade;
    public decimal Preco;
}

class EstoqueArray
{
    static void Main()
    {
        Produto[] produtos = new Produto[5];
        int contador = 0;
        string opcao;

        do
        {
            Console.WriteLine("\n---- Menu Estoque ----");
            Console.WriteLine("1 - Inserir Produto");
            Console.WriteLine("2 - Listar Produtos");
            Console.WriteLine("3 - Sair");
            Console.Write("Escolha uma opção: ");
            opcao = Console.ReadLine();

            if (opcao == "1")
            {
                if (contador >= 5)
                {
                    Console.WriteLine("Todos os produtos foram cadastrados!");
                }
                else
                {
                    Produto p = new Produto();

                    Console.Write("Nome do produto: ");
                    p.Nome = Console.ReadLine();

                    Console.Write("Quantidade: ");
                    int.TryParse(Console.ReadLine(), out p.Quantidade);

                    Console.Write("Preço unitário: ");
                    decimal.TryParse(Console.ReadLine(), out p.Preco);

                    produtos[contador] = p;
                    contador++;
                    Console.WriteLine("Produto inserido com sucesso!");
                }
            }
            else if (opcao == "2")
            {
                Console.WriteLine("\n----- Produtos Cadastrados -----");

                if (contador == 0)
                {
                    Console.WriteLine("Nenhum produto cadastrado.");
                }
                else
                {
                    for (int i = 0; i < contador; i++)
                    {
                        Produto p = produtos[i];
                        Console.WriteLine($"Produto: {p.Nome} | Quantidade: {p.Quantidade} | Preço: R$ {p.Preco:F2}");
                    }
                }
            }

        } while (opcao != "3");

        Console.WriteLine("Programa encerrado.");
    }
}