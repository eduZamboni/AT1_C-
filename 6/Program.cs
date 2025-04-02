using System;

public class Aluno
{
    public string Nome;
    public int Matricula;
    public string Curso;
    public double MediaDasNotas;

    public void ExibirDados()
    {
        Console.WriteLine($"Nome: {Nome}");
        Console.WriteLine($"Matrícula: {Matricula}");
        Console.WriteLine($"Curso: {Curso}");
        Console.WriteLine($"Média das Notas: {MediaDasNotas}");
    }

    public string VerificarAprovacao()
    {
        if (MediaDasNotas >= 7)
            return "Aprovado";
        else
            return "Reprovado";
    }
}

public class TestaAluno
{
    public static void Main(string[] args)
    {
        Aluno aluno = new Aluno();
        aluno.Nome = "Paulo Eduardo Zamboni";
        aluno.Matricula = 12345;
        aluno.Curso = "Engenharia de Software";
        aluno.MediaDasNotas = 8.2;

        Console.WriteLine("Dados do Aluno");
        aluno.ExibirDados();

        Console.WriteLine("\n Situação do Aluno");
        Console.WriteLine(aluno.VerificarAprovacao());
    }
}