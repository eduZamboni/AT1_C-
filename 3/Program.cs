using System;

class Program
{
    static void Main()
    {
        double num1, num2;

        Console.Write("Digite um número: ");
        while(!double.TryParse(Console.ReadLine(), out num1))
        {
            Console.WriteLine("Valor inválido! Tente novamente.");
            Console.Write("Digite um número: ");
        }

        Console.Write("Digite outro número: ");
        while(!double.TryParse(Console.ReadLine(), out num2))
        {
            Console.WriteLine("Valor inválido! Tente novamente.");
            Console.Write("Digite outro número: ");
        }

        Console.WriteLine("\nEscolha a operação:");
        Console.WriteLine("1 - Soma");
        Console.WriteLine("2 - Subtração");
        Console.WriteLine("3 - Multiplicação");
        Console.WriteLine("4 - Divisão");

        Console.Write("Escolha a opção: ");
        string opcao = Console.ReadLine();

        double resultado = 0;
        bool operacaoValida = true;

        switch(opcao)
        {
            case "1":
                resultado = num1 + num2;
                break;
            case "2":
                resultado = num1 - num2;
                break;
            case "3":
                resultado = num1 * num2;
                break;
            case "4":
                if (num2 == 0)
                {
                    Console.WriteLine("Erro: divisão por zero!");
                    operacaoValida = false;
                }
                else
                {
                    resultado = num1 / num2;
                }
                break;
            default:
                Console.WriteLine("Opção inválida!");
                operacaoValida = false;
                break;
        }

        if (operacaoValida)
        {
            Console.WriteLine($"\nResultado: {resultado}");
        }
    }
}