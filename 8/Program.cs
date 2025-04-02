using System;

public class Funcionario
{
    public string Nome { get; set; }
    public string Cargo { get; set; }
    public decimal SalarioBase { get; set; }

    public Funcionario(string nome, decimal salarioBase)
    {
        Nome = nome;
        Cargo = "Funcionário";
        SalarioBase = salarioBase;
    }

    public virtual decimal CalcularSalario()
    {
        return SalarioBase;
    }
}

public class Gerente : Funcionario
{
    public Gerente(string nome, decimal salarioBase)
        : base(nome, salarioBase)
    {
        Cargo = "Gerente";
    }

    public override decimal CalcularSalario()
    {
        return SalarioBase * 1.20m; // Bônus de 20%
    }
}

public class Program
{
    public static void Main()
    {
        Funcionario func = new Funcionario("Carlos Souza", 3000m);
        Console.WriteLine($"Funcionário: {func.Nome}");
        Console.WriteLine($"Cargo: {func.Cargo}");
        Console.WriteLine($"Salário: {func.CalcularSalario():C2}\n");

        Gerente gerente = new Gerente("Paulo Zamboni", 5000m);
        Console.WriteLine($"Funcionário: {gerente.Nome}");
        Console.WriteLine($"Cargo: {gerente.Cargo}");
        Console.WriteLine($"Salário (com bônus de 20%): {gerente.CalcularSalario():C2}");
    }
}