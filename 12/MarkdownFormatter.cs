using System;
using System.Collections.Generic;

public class MarkdownFormatter : ContatoFormatter
{
    public override void ExibirContatos(List<Contato> contatos)
    {
        Console.WriteLine("## Lista de Contatos\n");
        foreach (var c in contatos)
        {
            Console.WriteLine($"- **Nome:** {c.Nome}");
            Console.WriteLine($"- Telefone: {c.Telefone}");
            Console.WriteLine($"- Email: {c.Email}\n");
        }
    }
}