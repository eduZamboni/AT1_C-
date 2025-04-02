using System;

class Programa
{
    static void Main()
    {
        Random random = new Random();
        int numeroSecreto = random.Next(1, 51);
        int tentativas = 5;
        int tentativaAtual = 1;
        bool acertou = false;

        Console.WriteLine("------ Jogo: Adivinhe o número entre 1 e 50 ------");
        Console.WriteLine("Você tem 5 tentativas!");

        while (tentativaAtual <= tentativas)
        {
            Console.Write($"\nTentativa {tentativaAtual}: Digite um número de 1 a 50: ");
            string entrada = Console.ReadLine();

            if (!int.TryParse(entrada, out int chute))
            {
                Console.WriteLine("Por favor, digite um número inteiro.");
                continue;
            }

            if (chute < 1 || chute > 50)
            {
                Console.WriteLine("O número deve estar entre 1 e 50.");
                continue;
            }

            if (chute == numeroSecreto)
            {
                Console.WriteLine("Parabéns! Você acertou!");
                acertou = true;
                break;
            }
            else if (chute < numeroSecreto)
            {
                Console.WriteLine("Tente um número maior.");
            }
            else
            {
                Console.WriteLine("Tente um número menor.");
            }

            tentativaAtual++;
        }

        if (!acertou)
        {
            Console.WriteLine($"\n Fim do jogo! O número correto era: {numeroSecreto}");
        }

    }
}