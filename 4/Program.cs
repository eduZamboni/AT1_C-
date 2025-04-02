using System;

class Program
{
    static void Main()
    {
        Console.Write("Digite sua data de nascimento : ");
        string entrada = Console.ReadLine();

        if (!DateTime.TryParse(entrada, out DateTime dataNascimento))
        {
            Console.WriteLine("Data inválida!");
            return;
        }

        DateTime hoje = DateTime.Today;
        DateTime proximoAniversario = new DateTime(hoje.Year, dataNascimento.Month, dataNascimento.Day);

        if (proximoAniversario < hoje)
        {
            proximoAniversario = proximoAniversario.AddYears(1);
        }

        int diasRestantes = (proximoAniversario - hoje).Days;

        Console.WriteLine($"\nFaltam {diasRestantes} dia(s) para seu próximo aniversário.");

        if (diasRestantes < 7)
        {
            Console.WriteLine("Falta menos de uma semana para o seu aniversário!");
        }
    }
}