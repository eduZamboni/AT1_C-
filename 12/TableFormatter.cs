using System;
using System.Collections.Generic;

public class TabelaFormatter : ContatoFormatter
{
    public override void ExibirContatos(List<Contato> contatos)
    {
        Console.WriteLine("-----------------------------------------------");
        Console.WriteLine("| Nome           | Telefone        | Email            |");
        Console.WriteLine("-----------------------------------------------");

        foreach (var c in contatos)
        {
            Console.WriteLine($"| {c.Nome,-14} | {c.Telefone,-15} | {c.Email,-16} |");
        }

        Console.WriteLine("-----------------------------------------------");
    }
}