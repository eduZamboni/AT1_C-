using System;
using System.Collections.Generic;

public class RawTextFormatter : ContatoFormatter
{
    public override void ExibirContatos(List<Contato> contatos)
    {
        foreach (var c in contatos)
        {
            Console.WriteLine($"Nome: {c.Nome} | Telefone: {c.Telefone} | Email: {c.Email}");
        }
    }
}