using System;

public class ContaBancaria
{
    public string Titular { get; set; }
    private decimal saldo;
   
    public ContaBancaria(string titular)
    {
        Titular = titular;
        saldo = 0m;
    }

    public void Depositar(decimal valor)
    {
        if (valor <= 0)
        {
            Console.WriteLine("O valor do depósito deve ser positivo!");
            return;
        }
        saldo += valor;
        Console.WriteLine($"Depósito de R$ {valor:F2} realizado com sucesso!");
    }

    public void Sacar(decimal valor)
    {
        if (valor > saldo)
        {
            Console.WriteLine("Saldo insuficiente para realizar o saque!");
            return;
        }
        saldo -= valor;
        Console.WriteLine($"Saque de R$ {valor:F2} realizado com sucesso!");
    }

    public void ExibirSaldo()
    {
        Console.WriteLine($"Saldo atual: R$ {saldo:F2}");
    }
}

public class Program
{
    public static void Main()
    {
        ContaBancaria conta = new ContaBancaria("Paulo Zamboni");
        
        Console.WriteLine($"Titular: {conta.Titular}\n");
        
        conta.Depositar(500m);
        conta.ExibirSaldo();

        Console.WriteLine("\nTentativa de saque: R$ 700,00");
        conta.Sacar(700m);

        conta.Sacar(200m);
        conta.ExibirSaldo();
    }
}