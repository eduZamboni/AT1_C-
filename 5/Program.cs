using System;

class Program
{
    static void Main()
    {
        DateTime dataFormatura = new DateTime(2027, 12, 15);

        Console.Write("Digite a data atual : ");
        string entrada = Console.ReadLine();

        if (!DateTime.TryParse(entrada, out DateTime dataAtual))
        {
            Console.WriteLine("Data inválida!");
            return;
        }

        if (dataAtual > DateTime.Today)
        {
            Console.WriteLine("Erro: A data informada não pode ser no futuro!");
            return;
        }

        if (dataAtual > dataFormatura)
        {
            Console.WriteLine("Parabéns! Você já deveria estar formado!");
            return;
        }

        int anos = dataFormatura.Year - dataAtual.Year;
        int meses = dataFormatura.Month - dataAtual.Month;
        int dias = dataFormatura.Day - dataAtual.Day;

        if (dias < 0)
        {
            meses--;
            DateTime mesAnterior = dataFormatura.AddMonths(-1);
            dias += DateTime.DaysInMonth(mesAnterior.Year, mesAnterior.Month);
        }

        if (meses < 0)
        {
            anos--;
            meses += 12;
        }

        if (anos > 0)
        {
            Console.WriteLine($"Faltam {anos} ano(s), {meses} mês(es) e {dias} dia(s) para sua formatura!");
        }
        else if (meses > 0) 
        {
            Console.WriteLine($"Faltam {meses} mês(es) e {dias} dia(s) para sua formatura!");
        }
        else
        {
            Console.WriteLine($"Faltam {dias} dia(s) para sua formatura!");
        }

        int totalMesesRestantes = anos * 12 + meses;
        if (totalMesesRestantes < 6)
        {
            Console.WriteLine("A reta final chegou! Prepare-se para a formatura!");
        }
    }
}